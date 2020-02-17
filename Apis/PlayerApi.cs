//-----------------------------------------------------------------------
// <copyright file="PlayerApi.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface to Spotify's Player Web APIs
    /// </summary>
    public class PlayerApi : SpotifyApi
    {
        /// <summary>
        /// Gets a value indicating whether the API supports caching
        /// </summary>
        public override bool SupportsCache => false;

        /// <summary>
        /// Plays the given tracks
        /// </summary>
        /// <param name="trackUris">URIs of the tracks</param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        public async Task<dynamic> PlayTracks(IEnumerable<string> trackUris, Action<string> errorCallback)
        {
            string baseUri = $"https://api.spotify.com/v1/me/player/play";
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                ["uris"] = trackUris.ToArray()
            };

            return await this.Put(
                baseUri,
                body: JsonConvert.SerializeObject(body),
                header: this.Header,
                accept: "application/json",
                contentType: "application/json",
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Plays the given playlist
        /// </summary>
        /// <param name="playlistUri">The URI of the playlist</param>
        /// <param name="errorCallback">Callback to execute when an error is encountered</param>
        /// <returns>Request response</returns>
        public async Task<dynamic> PlayPlaylist(string playlistUri, Action<string> errorCallback)
        {
            string baseUri = $"https://api.spotify.com/v1/me/player/play";
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                ["context_uri"] = playlistUri
            };

            return await this.Put(
                baseUri,
                body: JsonConvert.SerializeObject(body),
                header: this.Header,
                accept: "application/json",
                contentType: "application/json",
                errorCallback: errorCallback);
        }

        /// <summary>
        /// Get information about a user’s available devices.
        /// </summary>
        /// <returns>Information about a user’s available devices.</returns>
        public async Task<dynamic> GetDevices()
        {
            string baseUri = $"https://api.spotify.com/v1/me/player/devices";

            return await this.Get(
                baseUri,
                header: this.Header,
                accept: "application/json",
                contentType: "application/json");
        }

        /// <summary>
        /// Transfers playback to the given device
        /// </summary>
        /// <param name="deviceId">The ID of the device to transfer playback to</param>
        /// <returns>Request response</returns>
        public async Task<dynamic> TransferPlayback(string deviceId)
        {
            string baseUri = $"https://api.spotify.com/v1/me/player";
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                ["device_ids"] = new[] { deviceId }
            };

            return await this.Put(
                baseUri,
                body: JsonConvert.SerializeObject(body),
                header: this.Header,
                accept: "application/json",
                contentType: "application/json");
        }
    }
}
