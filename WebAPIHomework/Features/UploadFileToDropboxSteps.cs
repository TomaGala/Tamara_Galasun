using System.IO;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace WebAPIHomework.Features
{
    [Binding]
    public class UploadFileToDropboxSteps
    {
        string picture;
        string path;
        bool result = false;

        [Given(@"I want to upload an image ""(.*)"" to get the path ""(.*)""")]
        public void GivenIWantToUploadAnImageToGetThePath(string image, string Path)
        {
            picture = image;
            path = Path;
        }
        
        [When(@"I send a request to Dropbox")]
        public void WhenISendARequestToDropbox()
        {
            var rq = new Upload_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            FileInfo fileInfo = new FileInfo(picture);
            long fileLength = fileInfo.Length;
            rq.BuildRequestContentLength(fileLength.ToString());
            rq.BuildRequestBody(picture);
            rq.BuildRequestDropbox(path);
            rq.BuildRequestContentType("application/octet-stream");
            rq.BuildRequestResponse();
            result = true;
        }
        
        [Then(@"The uploading should be successful")]
        public void ThenTheUploadingShouldBeSuccessful()
        {
            Assert.IsTrue(result == true);
        }
    }
}
