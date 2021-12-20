using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIHomework.Builders
{
    abstract class AbstractBuilder
    {
        public abstract void BuildRequestAuthorization(string token);
        public abstract void BuildRequestContentLength(string length);
        public abstract void BuildRequestBody(string image);
        public abstract void BuildRequestDropbox(string path);
        public abstract void BuildRequestContentType(string ContentType);
        public abstract void BuildRequestResponse();
        public abstract void BuildRequestAddJsonBody(string path);

    }
}
