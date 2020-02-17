//-----------------------------------------------------------------------
// <copyright file="Artist.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an artist
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Artist"/> class
        /// </summary>
        /// <param name="id">The artist ID</param>
        /// <param name="name">The artist name</param>
        public Artist(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the artist's ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the artist's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the artist's genres
        /// </summary>
        public HashSet<string> Genres { get; set; }

        /// <summary>
        /// Provides a string representation for the artist
        /// </summary>
        /// <returns>The artist's name</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Determines if the given object is equal to the current artist
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><c>True</c> if the objects are equal, <c>false</c> otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return this == null;
            }

            if (!(obj is Artist a))
            {
                return false;
            }

            return a.Id == this.Id;
        }

        /// <summary>
        /// Computes a hash code for the artist
        /// </summary>
        /// <returns>A hash code for the artist</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
