//-----------------------------------------------------------------------
// <copyright file="Album.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Entities
{
    /// <summary>
    /// Represents an album
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Album"/> class
        /// </summary>
        /// <param name="id">The album ID</param>
        /// <param name="name">The album name</param>
        public Album(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the album's ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the album's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Provides a string representation for the album
        /// </summary>
        /// <returns>The album's name</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Determines if the given object is equal to the current album
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><c>True</c> if the objects are equal, <c>false</c> otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return this == null;
            }

            if (!(obj is Album a))
            {
                return false;
            }

            return a.Id == this.Id;
        }

        /// <summary>
        /// Computes a hash code for the album
        /// </summary>
        /// <returns>A hash code for the album</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
