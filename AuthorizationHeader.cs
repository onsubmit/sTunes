//-----------------------------------------------------------------------
// <copyright file="AuthorizationHeader.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes
{
    using System.Net;
    using OnSubmit.STunes.Extensions;

    /// <summary>
    /// Represents an authorization header passed to Spotify's Web APIs
    /// </summary>
    public class AuthorizationHeader
    {
        /// <summary>
        /// The value of the authorization header
        /// </summary>
        private string headerValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationHeader"/> class
        /// </summary>
        /// <param name="accessToken">The access token</param>
        public AuthorizationHeader(string accessToken)
        {
            this.headerValue = $"Bearer {accessToken}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationHeader"/> class
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <param name="clientSecret">The client secret</param>
        public AuthorizationHeader(string clientId, string clientSecret)
        {
            this.headerValue = "Basic " + $"{clientId}:{clientSecret}".ToBase64String();
        }

        /// <summary>
        /// Gets the authorization header
        /// </summary>
        public (HttpRequestHeader Name, string Value) Header => (HttpRequestHeader.Authorization, this.headerValue);
    }
}
