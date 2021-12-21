using RestSharp;
using System.IO;
using WebAPIHomework.Builders;


namespace WebAPIHomework
{
    class Upload_Builder : AbstractBuilder
    {
        public override void BuildRequestAuthorization(string token, RestRequest request)
        {

            request.AddHeader("Authorization",token);
        }

        public override void BuildRequestContentLength(string length, RestRequest request)
        {
            request.AddHeader("Content-Length", length);
        }

        public override void BuildRequestBody(string image, RestRequest request)
        {
            byte[] data = File.ReadAllBytes(image);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            request.Parameters.Add(body);
        }


        public override void BuildRequestDropbox(string path, RestRequest request)
        {
            request.AddHeader("Dropbox-API-Arg", "{\"path\":\"" + path + "\",\"mode\":\"add\"}");
        }

        public override void BuildRequestContentType(string ContentType, RestRequest request)
        {
            request.AddHeader("Content-Type", ContentType);
        }


        // метод, що наслідується, але не використовується
        public override void BuildRequestAddJsonBody(string path, RestRequest request)
        { path = path;}
    }
}
