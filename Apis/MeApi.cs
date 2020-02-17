//-----------------------------------------------------------------------
// <copyright file="MeApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to Spotify's User Profile Web APIs
    /// </summary>
    public class MeApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => true;

        /// <summary>
        /// Get detailed profile information about the current user (including the current user's username).
        /// </summary>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Detailed profile information about the current user.</returns>
        public async Task<dynamic> GetCurrentUser(Action<dynamic> errorCallback)
        {
            string baseUri = "https://api.spotify.com/v1/me";
            return await this.Get(
                baseUri,
                header: this.Header,
                accept: "application/json",
                contentType: "application/json",
                errorCallback: errorCallback);
        }
    }
}
