//-----------------------------------------------------------------------
// <copyright file="Track.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a track
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class
        /// </summary>
        /// <param name="id">The track ID</param>
        /// <param name="name">The track name</param>
        /// <param name="artists">The track artists</param>
        /// <param name="album">The track album</param>
        public Track(string id, string name, HashSet<Artist> artists, Album album)
        {
            this.Id = id;
            this.Name = name;
            this.Artists = artists.ToDictionary(a => a.Id, a => a);
            this.Album = album;
        }

        /// <summary>
        /// Gets the track's ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the track's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Spotify uri for the track
        /// </summary>
        public string Uri => $"spotify:track:{this.Id}";

        /// <summary>
        /// Gets the track's artists
        /// </summary>
        public Dictionary<string, Artist> Artists { get; private set; }
        
        /// <summary>
        /// Gets the track's album
        /// </summary>
        public Album Album { get; private set; }

        /// <summary>
        /// Gets a comma-separated list of the track's artist's names
        /// </summary>
        public string ArtistNames => string.Join(", ", this.Artists.Values);

        /// <summary>
        /// Gets a list of the track's artist's IDs
        /// </summary>
        public IEnumerable<string> ArtistIds => this.Artists.Keys;

        /// <summary>
        /// Provides a string representation for the track
        /// </summary>
        /// <returns>The track's artists followed by its name</returns>
        public override string ToString()
        {
            return $"{ArtistNames} - {this.Name}";
        }

        /// <summary>
        /// Determines if the given object is equal to the current track
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><c>True</c> if the objects are equal, <c>false</c> otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return this == null;
            }

            if (!(obj is Track t))
            {
                return false;
            }

            return t.Id == this.Id;
        }

        /// <summary>
        /// Computes a hash code for the artist
        /// </summary>
        /// <returns>A hash code for the track</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
