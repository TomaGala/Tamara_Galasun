using NUnit.Framework;
using TechTalk.SpecFlow;
/*

namespace WebAPIHomework.Features
{
    [Binding]
    public class GetFileMetadataSteps
    {
        string path;
        bool result = false;
        
        [Given(@"An image is uploaded")]
        public void GivenAnImageIsUploaded()
        {
            path = "/WebAPI/christmas.jpg";
        }
        
        [When(@"I am sending request to Dropbox")]
        public void WhenIAmSendingRequestToDropbox()
        {
            var rq = new GetFileMetadata_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            rq.BuildRequestContentType("application/json");
            rq.BuildRequestAddJsonBody(path);
            rq.BuildRequestResponse();
            result = true;
        }
       
        [Then(@"Getting file metadata should be successful")]
        public void ThenGettingFileMetadataShouldBeSuccessful()
        {
            Assert.IsTrue(result == true);
        }
    }
}*/
