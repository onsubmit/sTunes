//-----------------------------------------------------------------------
// <copyright file="TokenApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OnSubmit.STunes.Extensions;

    /// <summary>
    /// Interface to Spotify's Token Web APIs
    /// </summary>
    public class TokenApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => false;

        /// <summary>
        /// Gets an authorization code that can be exchanged for an access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code returned from the initial request to the Account /authorize endpoint.</param>
        /// <param name="redirectUri">This parameter is used for validation only (there is no actual redirection). The value of this parameter must exactly match the value of redirect_uri supplied when requesting the authorization code.</param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>An authorization code that can be exchanged for an access token.</returns>
        public async Task<dynamic> GetAccessCode(string authorizationCode, string redirectUri, Action<string> errorCallback)
        {
            string baseUri = "https://accounts.spotify.com/api/token";
            Dictionary<string, string> postData = new Dictionary<string, string>()
            {
                ["grant_type"] = "authorization_code",
                ["code"] = authorizationCode,
                ["redirect_uri"] = redirectUri
            };

            return await this.Post(
                baseUri,
                body: postData.ToRequestDataString(),
                header: this.Header,
                contentType: "application/x-www-form-urlencoded",
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Requests a refreshed access token from the given refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token returned from the authorization code exchange.</param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>A refreshed access token from the given refresh token.</returns>
        public async Task<dynamic> GetAccessToken(string refreshToken, Action<string> errorCallback)
        {
            string baseUri = "https://accounts.spotify.com/api/token";
            Dictionary<string, string> postData = new Dictionary<string, string>()
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = refreshToken
            };

            return await this.Post(
                baseUri,
                body: postData.ToRequestDataString(),
                header: this.Header,
                contentType: "application/x-www-form-urlencoded",
                errorCallback: errorCallback);
        }
    }
}
