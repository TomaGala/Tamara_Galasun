using RestSharp;

namespace WebAPIHomework.Builders
{
    abstract class AbstractBuilder
    {
        public abstract void BuildRequestAuthorization(string token, RestRequest request);
        public abstract void BuildRequestContentLength(string length, RestRequest request);
        public abstract void BuildRequestBody(string image, RestRequest request);
        public abstract void BuildRequestDropbox(string path, RestRequest request);
        public abstract void BuildRequestContentType(string ContentType, RestRequest request);
        public abstract void BuildRequestAddJsonBody(string path, RestRequest request);

    }
}
