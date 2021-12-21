using RestSharp;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace WebAPIHomework.Features
{/*
    [Binding]
    public class GetFileMetadataSteps
    {
        RestRequest Request = new RestRequest();
        RestResponse response = new RestResponse();

        [Given(@"An image is uploaded")]
        public void GivenAnImageIsUploaded()
        {
            var rq = new GetFileMetadata_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO", Request);
            rq.BuildRequestContentType("application/json", Request);
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg", Request);
        }
        
        [When(@"I am sending request to Dropbox")]
        public void WhenIAmSendingRequestToDropbox()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            response = (RestResponse)client.Post(Request);
        }
        
        [Then(@"Getting file metadata should be successful")]
        public void ThenGettingFileMetadataShouldBeSuccessful()
        {
           Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }*/
}
    