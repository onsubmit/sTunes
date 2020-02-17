//-----------------------------------------------------------------------
// <copyright file="UriBuilderHelper.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Helpers
{
    using System;
    using System.Collections.Generic;
    using OnSubmit.STunes.Extensions;

    /// <summary>
    /// Helper class to build a <see cref="Uri"/>
    /// </summary>
    public static class UriBuilderHelper
    {
        /// <summary>
        /// Creates a URI
        /// </summary>
        /// <param name="baseUri">The base URI</param>
        /// <param name="queryString">The query string</param>
        /// <returns>A URI</returns>
        public static Uri Create(string baseUri, Dictionary<string, string> queryString = null)
        {
            if (queryString == null)
            {
                return new Uri(baseUri);
            }

            UriBuilder uriBuilder = new UriBuilder(baseUri)
            {
                Query = queryString.ToRequestDataString()
            };

            return uriBuilder.Uri;
        }
    }
}
