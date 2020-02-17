//-----------------------------------------------------------------------
// <copyright file="FilterType.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes
{
    /// <summary>
    /// Type of filter
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// No filter
        /// </summary>
        None,

        /// <summary>
        /// Filter by genre
        /// </summary>
        Genre,

        /// <summary>
        /// Filter by artist
        /// </summary>
        Artist,

        /// <summary>
        /// Filter by album
        /// </summary>
        Album,
    }
}
