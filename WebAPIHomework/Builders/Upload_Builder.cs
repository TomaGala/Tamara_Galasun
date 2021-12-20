using RestSharp;
using System.IO;
using NUnit.Framework;
using WebAPIHomework.Builders;


namespace WebAPIHomework
{
    class Upload_Builder : AbstractBuilder
    {
        RestRequest rq = new RestRequest();
        public override void BuildRequestAuthorization(string token)
        {
           rq.AddHeader("Authorization",token);
        }

        public override void BuildRequestContentLength(string length)
        {
           rq.AddHeader("Content-Length", length);
        }

        public override void BuildRequestBody(string image)
        {
            byte[] data = File.ReadAllBytes(image);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            rq.Parameters.Add(body);
        }


        public override void BuildRequestDropbox(string path)
        {
            rq.AddHeader("Dropbox-API-Arg", "{\"path\":\"" + path + "\",\"mode\":\"add\"}");
        }

        public override void BuildRequestContentType(string ContentType)
        {
           rq.AddHeader("Content-Type", ContentType);
        }

        public override void BuildRequestResponse()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            var response = (RestResponse)client.Post(rq);
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }

        // метод, що наслідується, але не використовується
        public override void BuildRequestAddJsonBody(string path)
        { path = path;}
    }
}
