using NUnit.Framework;
using System.IO;
using WebAPIHomework.Builders;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;
using RestSharp;

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
            RestRequest request = new RestRequest();
            var rq = new Upload_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO",request);
            FileInfo fileInfo = new FileInfo("christmas.jpg");
            long fileLength = fileInfo.Length;
            rq.BuildRequestContentLength(fileLength.ToString(), request);
            rq.BuildRequestBody("christmas.jpg", request);
            rq.BuildRequestDropbox("/WebAPI/christmas.jpg", request);
            rq.BuildRequestContentType("application/octet-stream", request);
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            var response = (RestResponse)client.Post(request);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        
        [Test(Description = "GetFileMetadata")]
         [AllureTag("WebAPIHomeTask")]
         [AllureSeverity(SeverityLevel.critical)]
         [AllureIssue("8911")]
         [AllureTms("532")]
        public void Test2()
        {
            RestRequest request = new RestRequest();
            var rq = new GetFileMetadata_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO", request);
            rq.BuildRequestContentType("application/json", request);
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg", request);
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            var response = (RestResponse)client.Post(request);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }


        [Test(Description = "Delete")]
        [AllureTag("WebAPIHomeTask")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]
        public void Test3()
        {
            RestRequest request = new RestRequest();
            var rq = new Delete_Builder();
            rq.BuildRequestAuthorization("Bearer bWtEVdbfACQAAAAAAAAAAY5OWlskhN29V7LtzF1s4tWb74MV1Tg0-ymJXxrg6TWO", request);
            rq.BuildRequestContentType("application/json", request);
            rq.BuildRequestAddJsonBody("/WebAPI/christmas.jpg", request);
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            var response = (RestResponse)client.Post(request);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}