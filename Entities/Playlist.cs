//-----------------------------------------------------------------------
// <copyright file="Playlist.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Entities
{
    /// <summary>
    /// Represents a playlist
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class
        /// </summary>
        /// <param name="id">The playlist ID</param>
        /// <param name="name">The playlist name</param>
        /// <param name="numTracks">The number of tracks in the playlist</param>
        public Playlist(string id, string name, int numTracks)
        {
            this.Id = id;
            this.Name = name;
            this.NumTracks = numTracks;
        }

        /// <summary>
        /// Gets the playlist's ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the playlist's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the number of tracks in the playlist
        /// </summary>
        public int NumTracks { get; private set; }

        /// <summary>
        /// Gets the Spotify uri for the playlist
        /// </summary>
        public string Uri => $"spotify:playlist:{this.Id}";

        /// <summary>
        /// Provides a string representation for the playlist
        /// </summary>
        /// <returns>The playlist's name and how many tracks it has</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.NumTracks})";
        }
    }
}
