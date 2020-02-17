//-----------------------------------------------------------------------
// <copyright file="PlaylistApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface to Spotify's Playlist Web APIs
    /// </summary>
    public class PlaylistApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => true;

        /// <summary>
        /// Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">ID of the playlist</param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first track to return. Default: 0 (the first object).</param>
        /// <param name="disableCache">Will not return response from cache if <c>true</c></param>
        /// <returns>Full details of the tracks of a playlist owned by a Spotify user.</returns>
        public async Task<dynamic> GetPlaylistTracks(string playlistId, int? limit = null, int? offset = null, bool disableCache = false)
        {
            string baseUri = $"https://api.spotify.com/v1/playlists/{playlistId}/tracks";
            Dictionary<string, string> queryString = new Dictionary<string, string>();
            if (limit.HasValue)
            {
                queryString["limit"] = limit.ToString();
            }

            if (offset.HasValue)
            {
                queryString["offset"] = offset.ToString();
            }

            return await this.Get(
                baseUri,
                query: queryString,
                header: this.Header,
                accept: "application/json",
                contentType: "application/json",
                disableCache: disableCache);
        }

        /// <summary>
        /// Get a list of the playlists owned or followed by the current Spotify user.
        /// </summary>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object). Maximum offset: 100,000. Use with limit to get the next set of playlists.</param>
        /// <returns>The a list of the playlists owned or followed by the current Spotify user.</returns>
        public async Task<dynamic> GetMyPlaylists(int? limit = null, int? offset = null)
        {
            string baseUri = "https://api.spotify.com/v1/me/playlists";
            Dictionary<string, string> queryString = new Dictionary<string, string>();
            if (limit.HasValue)
            {
                queryString["limit"] = limit.ToString();
            }

            if (offset.HasValue)
            {
                queryString["offset"] = offset.ToString();
            }

            return await this.Get(
                baseUri,
                query: queryString,
                accept: "application/json",
                contentType: "application/json",
                header: this.Header);
        }
    }
}
