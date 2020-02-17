//-----------------------------------------------------------------------
// <copyright file="DictionaryExtensions.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Extensions
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// Extension methods for <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts the dictionary to a request data string e.g. query string
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>A request data string</returns>
        public static string ToRequestDataString(this Dictionary<string, string> dictionary)
        {
            if (dictionary == null || dictionary.Keys.Count == 0)
            {
                return null;
            }

            NameValueCollection query = System.Web.HttpUtility.ParseQueryString(string.Empty);
            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                query.Add(kvp.Key, kvp.Value);
            }

            return query.ToString();
        }
    }
}
