using RestSharp;
using WebAPIHomework.Builders;


namespace WebAPIHomework
{
    class GetFileMetadata_Builder : AbstractBuilder
    {
        public override void BuildRequestAuthorization(string token, RestRequest request)
        {
            request.AddHeader("Authorization", token);
        }

        public override void BuildRequestContentType(string ContentType, RestRequest request)
        {
           request.AddHeader("Content-Type", ContentType);
        }

        public override void BuildRequestAddJsonBody(string path, RestRequest request)
        {
           request.AddJsonBody(new { file = path });
        }

        // методи, що наслідуються, але не потрібні у використанні 
        public override void BuildRequestContentLength(string length, RestRequest request)
        { length = length;}
        public override void BuildRequestBody(string image, RestRequest request)
        { image = image; }
        public override void BuildRequestDropbox(string path, RestRequest request)
        { path = path; }
    }
}
