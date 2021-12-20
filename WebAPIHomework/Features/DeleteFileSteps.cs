using NUnit.Framework;
using TechTalk.SpecFlow;
using WebAPIHomework.Builders;
/*
namespace WebAPIHomework.Features
{
    [Binding]
    public class DeleteFileSteps
    {
        string path;
        bool result = false;

        [Given(@"A picture is uploaded")]
        public void GivenAPictureIsUploaded()
        {
            path = "/WebAPI/christmas.jpg";
        }

        [When(@"I send request to Dropbox")]
        public void WhenISendRequestToDropbox()
        {
            var rq = new Delete_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            rq.BuildRequestContentType("application/json");
            rq.BuildRequestAddJsonBody(path);
            rq.BuildRequestResponse();
            result = true;
        }

        [Then(@"File deleting should be successful")]
        public void ThenFileDeletingShouldBeSuccessful()
        {
            Assert.IsTrue(result == true);
        }
    }
}
*/