using RestSharp;
using TechTalk.SpecFlow;
using NUnit.Framework;
using WebAPIHomework.Builders;

namespace WebAPIHomework.Features
{/*
    [Binding]
    public class DeleteFileSteps
    {
        RestRequest request = new RestRequest();
        RestResponse Response = new RestResponse();

        [Given(@"A picture is uploaded")]
        public void GivenAPictureIsUploaded()
        {
            var rq = new Delete_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO", request);
            rq.BuildRequestContentType("application/json", request);
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg", request);
        }
        
        [When(@"I send request to Dropbox")]
        public void WhenISendRequestToDropbox()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            Response = (RestResponse)client.Post(request);
        }
        
        [Then(@"File deleting should be successful")]
        public void ThenFileDeletingShouldBeSuccessful()
        {
            Assert.True(Response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }*/
}
