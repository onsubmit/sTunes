//-----------------------------------------------------------------------
// <copyright file="SpotifyApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using OnSubmit.STunes.Helpers;

    /// <summary>
    /// Abstract class providing an interface to one of Spotify's Web APIs
    /// </summary>
    public abstract class SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public abstract bool SupportsCache { get; }

        /// <summary>
        /// Gets or sets the authorization header
        /// </summary>
        public AuthorizationHeader AuthorizationHeader { get; set; }

        /// <summary>
        /// Gets the authorization header
        /// </summary>
        public (HttpRequestHeader Name, string Value) Header => this.AuthorizationHeader.Header;

        /// <summary>
        /// Makes a GET request
        /// </summary>
        /// <param name="baseUri">Base request URI</param>
        /// <param name="query">Query string to add</param>
        /// <param name="header">Request header</param>
        /// <param name="accept">Accept header</param>
        /// <param name="contentType">Content-Type header</param>
        /// <param name="disableCache">Will not return response from cache if <c>true</c></param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        protected async Task<dynamic> Get(
            string baseUri,
            Dictionary<string, string> query = null,
            (HttpRequestHeader, string)? header = null,
            string accept = null,
            string contentType = null,
            bool disableCache = false,
            Action<string> errorCallback = null)
        {
            return await this.MakeRequest(
                baseUri: baseUri,
                method: WebRequestMethods.Http.Get,
                query: query,
                header: header,
                accept: accept,
                contentType: contentType,
                disableCache: disableCache,
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Makes a POST request
        /// </summary>
        /// <param name="baseUri">Base request URI</param>
        /// <param name="query">Query string to add</param>
        /// <param name="body">Request body</param>
        /// <param name="header">Request header</param>
        /// <param name="accept">Accept header</param>
        /// <param name="contentType">Content-Type header</param>
        /// <param name="disableCache">Will not return response from cache if <c>true</c></param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        protected async Task<dynamic> Post(
            string baseUri,
            Dictionary<string, string> query = null,
            string body = null,
            (HttpRequestHeader, string)? header = null,
            string accept = null,
            string contentType = null,
            bool disableCache = false,
            Action<string> errorCallback = null)
        {
            return await this.MakeRequest(
                baseUri: baseUri,
                method: WebRequestMethods.Http.Post,
                body: body,
                query: query,
                header: header,
                accept: accept,
                contentType: contentType,
                disableCache: disableCache,
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Makes a PUT request
        /// </summary>
        /// <param name="baseUri">Base request URI</param>
        /// <param name="query">Query string to add</param>
        /// <param name="body">Request body</param>
        /// <param name="header">Request header</param>
        /// <param name="accept">Accept header</param>
        /// <param name="contentType">Content-Type header</param>
        /// <param name="disableCache">Will not return response from cache if <c>true</c></param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        protected async Task<dynamic> Put(
            string baseUri,
            Dictionary<string, string> query = null,
            string body = null,
            (HttpRequestHeader, string)? header = null,
            string accept = null,
            string contentType = null,
            bool disableCache = false,
            Action<string> errorCallback = null)
        {
            return await this.MakeRequest(
                baseUri: baseUri,
                method: WebRequestMethods.Http.Put,
                body: body,
                query: query,
                header: header,
                accept: accept,
                contentType: contentType,
                disableCache: disableCache,
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Makes a web request
        /// </summary>
        /// <param name="baseUri">Base request URI</param>
        /// <param name="method">HTTP method</param>
        /// <param name="query">Query string to add</param>
        /// <param name="body">Request body</param>
        /// <param name="header">Request header</param>
        /// <param name="accept">Accept header</param>
        /// <param name="contentType">Content-Type header</param>
        /// <param name="disableCache">Will not return response from cache if <c>true</c></param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        private async Task<dynamic> MakeRequest(
            string baseUri,
            string method = WebRequestMethods.Http.Get,
            Dictionary<string, string> query = null,
            string body = null,
            (HttpRequestHeader, string)? header = null,
            string accept = null,
            string contentType = null,
            bool disableCache = false,
            Action<string> errorCallback = null)
        {
            string uri = UriBuilderHelper.Create(baseUri, query).ToString();

            string cacheKey = uri;
            if (!disableCache
                && this.SupportsCache
                && !string.IsNullOrWhiteSpace(body))
            {
                cacheKey = $"{uri}:{body}";
            }

            if (disableCache
                || !this.SupportsCache
                || !ResponseCache.TryGet(cacheKey, out string response))
            {
                bool isError = false;
                (response, isError) = await WebRequestHelper.MakeRequest(
                    uri,
                    method,
                    body,
                    header,
                    accept,
                    contentType,
                    errorCallback);

                if (this.SupportsCache && !isError)
                {
                    ResponseCache.AddOrReplace(cacheKey, response);
                }
            }

            return JsonConvert.DeserializeObject(response);
        }
    }
}
