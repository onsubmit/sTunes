//-----------------------------------------------------------------------
// <copyright file="WebRequestHelper.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Helpers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class for making web requests
    /// </summary>
    public static class WebRequestHelper
    {
        /// <summary>
        /// Makes a web request
        /// </summary>
        /// <param name="uri">Request URI</param>
        /// <param name="method">HTTP method</param>
        /// <param name="body">Request body</param>
        /// <param name="header">Request header</param>
        /// <param name="accept">Accept header</param>
        /// <param name="contentType">Content-Type header</param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        public static async Task<(string response, bool isError)> MakeRequest(
            string uri,
            string method,
            string body = null,
            (HttpRequestHeader Name, string Value)? header = null,
            string accept = null,
            string contentType = null,
            Action<string> errorCallback = null)
        {
            bool isError = false;
            string responseString;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Accept = accept;
            request.ContentType = contentType;

            if (header.HasValue)
            {
                request.Headers.Add(header.Value.Name, header.Value.Value);
            }

            if (body != null)
            {
                byte[] bodyBytes = Encoding.ASCII.GetBytes(body);
                request.ContentLength = bodyBytes.Length;

                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                }
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            catch (WebException wex)
            {
                if (wex.Response == null)
                {
                    throw;
                }

                using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                {
                    isError = true;
                    responseString = reader.ReadToEnd();
                    errorCallback?.Invoke(responseString);
                }
            }

            return (responseString, isError);
        }
    }
}
