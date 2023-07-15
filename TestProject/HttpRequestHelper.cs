using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.WebUtilities;

namespace TestProject
{
    //So i had to write a helper class to create the specific HttpRequest format that we needed to trigger the serverless Function
    public static class HttpRequestHelper
    {
        public static HttpRequest CreateHttpRequest(int a)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "a", a.ToString() }
            };

            var queryString = new QueryString(QueryHelpers.AddQueryString("", queryParameters));

            var request = new DefaultHttpContext().Request;
            request.QueryString = queryString;

            return request;
        }
    }
}
