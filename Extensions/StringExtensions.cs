//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Extensions
{
    using System;
    using System.Text;

    /// <summary>
    /// Extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to its equivalent string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="value">Value to encode</param>
        /// <returns>A string to its equivalent string representation that is encoded with base-64 digits.</returns>
        public static string ToBase64String(this string value)
        {
            if (value == null)
            {
                return null;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}
