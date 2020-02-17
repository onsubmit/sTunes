//-----------------------------------------------------------------------
// <copyright file="ArtistApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to Spotify's Artist Web APIs
    /// </summary>
    public class ArtistApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => true;

        /// <summary>
        /// Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="artistIds">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns>Spotify catalog information for several artists based on their Spotify IDs.</returns>
        public async Task<dynamic> GetArtists(IEnumerable<string> artistIds)
        {
            string baseUri = $"https://api.spotify.com/v1/artists";
            Dictionary<string, string> queryString = new Dictionary<string, string>()
            {
                ["ids"] = string.Join(",", artistIds)
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
