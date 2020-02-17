//-----------------------------------------------------------------------
// <copyright file="AuthorizeApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System;
    using System.Collections.Generic;
    using OnSubmit.STunes.Helpers;

    /// <summary>
    /// Interface to Spotify's Authorization Web APIs
    /// </summary>
    public class AuthorizeApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => false;

        /// <summary>
        /// Gets the full URI for the authorize endpoint
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="responseType">Response type</param>
        /// <param name="redirectUri">Redirect URI</param>
        /// <param name="state">The state</param>
        /// <param name="scope">The scope</param>
        /// <returns>The full URI for the authorize endpoint</returns>
        public Uri GetAuthorizeUri(
            string clientId,
            string responseType,
            string redirectUri,
            string state,
            string scope)
        {
            string baseUri = "https://accounts.spotify.com/authorize";
            Dictionary<string, string> queryString = new Dictionary<string, string>()
            {
                ["client_id"] = clientId,
                ["response_type"] = responseType,
                ["redirect_uri"] = redirectUri,
                ["state"] = state,
                ["scope"] = scope
            };

            return UriBuilderHelper.Create(baseUri, queryString);
        }
    }
}
