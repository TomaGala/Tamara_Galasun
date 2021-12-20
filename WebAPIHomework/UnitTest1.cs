using NUnit.Framework;
using System.IO;
using WebAPIHomework.Builders;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace WebAPIHomework
{
    [AllureNUnit]
    [AllureSuite("DropboxTests")]
    [AllureDisplayIgnored]
    [TestFixture]
    public class UnitTest
    {
        [Test(Description = "Upload")]
        [AllureTag("WebAPIHomeTask")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]
        public void Test1()
        {
            var rq = new Upload_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            FileInfo fileInfo = new FileInfo("christmas.jpg");
            long fileLength = fileInfo.Length;
            rq.BuildRequestContentLength(fileLength.ToString());
            rq.BuildRequestBody("christmas.jpg");
            rq.BuildRequestDropbox("/WebAPI/christmas.jpg");
            rq.BuildRequestContentType("application/octet-stream");
            rq.BuildRequestResponse();
        }

        [Test(Description = "GetFileMetadata")]
         [AllureTag("WebAPIHomeTask")]
         [AllureSeverity(SeverityLevel.critical)]
         [AllureIssue("8911")]
         [AllureTms("532")]
        public void Test2()
        {
            var rq = new GetFileMetadata_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            rq.BuildRequestContentType("application/json");
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg");
            rq.BuildRequestResponse();
        }


        [Test(Description = "Delete")]
        [AllureTag("WebAPIHomeTask")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]
        public void Test3()
        {
            var rq = new Delete_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO");
            rq.BuildRequestContentType("application/json");
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg");
            rq.BuildRequestResponse();
        }
    }
}