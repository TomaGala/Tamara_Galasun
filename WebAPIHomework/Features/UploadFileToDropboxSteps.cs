using System.IO;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;

namespace WebAPIHomework.Features
{
   [Binding]
    public class UploadFileToDropboxSteps
    {
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();

        [Given(@"I want to upload an image ""(.*)"" to get the path ""(.*)""")]
        public void GivenIWantToUploadAnImageToGetThePath(string image, string Path)
        {
            var rq = new Upload_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO", request);
            FileInfo fileInfo = new FileInfo(image);
            long fileLength = fileInfo.Length;
            rq.BuildRequestContentLength(fileLength.ToString(), request);
            rq.BuildRequestBody(image, request);
            rq.BuildRequestDropbox(Path, request);
            rq.BuildRequestContentType("application/octet-stream", request);
        }
        
        [When(@"I send a request to Dropbox")]
        public void WhenISendARequestToDropbox()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            response = (RestResponse)client.Post(request);
        }
        
        [Then(@"The uploading should be successful")]
        public void ThenTheUploadingShouldBeSuccessful()
        {
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
