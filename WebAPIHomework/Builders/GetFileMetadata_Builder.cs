using RestSharp;
using NUnit.Framework;
using WebAPIHomework.Builders;


namespace WebAPIHomework
{
    class GetFileMetadata_Builder : AbstractBuilder
    {
        RestRequest rq = new RestRequest();
        public override void BuildRequestAuthorization(string token)
        {
            rq.AddHeader("Authorization", token);
        }

        public override void BuildRequestContentType(string ContentType)
        {
            rq.AddHeader("Content-Type", ContentType);
        }

        public override void BuildRequestAddJsonBody(string path)
        {
           rq.AddJsonBody(new { file = path });
        }

        public override void BuildRequestResponse()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata");
            var response = (RestResponse)client.Post(rq);
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }

        // методи, що наслідуються, але не потрібні у використанні 
        public override void BuildRequestContentLength(string length)
        { length = length;}
        public override void BuildRequestBody(string image)
        { image = image; }
        public override void BuildRequestDropbox(string path)
        { path = path; }
    }
}
