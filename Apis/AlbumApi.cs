//-----------------------------------------------------------------------
// <copyright file="AlbumApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to Spotify's Album Web APIs
    /// </summary>
    public class AlbumApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => true;

        /// <summary>
        /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="albumIds">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <returns>Spotify catalog information for multiple albums identified by their Spotify IDs.</returns>
        public async Task<dynamic> GetAlbums(IEnumerable<string> albumIds)
        {
            string baseUri = $"https://api.spotify.com/v1/albums";
            Dictionary<string, string> queryString = new Dictionary<string, string>()
            {
                ["ids"] = string.Join(",", albumIds)
            };

            return await this.Get(
                baseUri,
                query: queryString,
                header: this.Header,
                accept: "application/json",
                contentType: "application/json");
        }
    }
}
