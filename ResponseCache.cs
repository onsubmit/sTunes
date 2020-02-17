//-----------------------------------------------------------------------
// <copyright file="ResponseCache.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides caching of the responses from Spotify's Web APIs
    /// </summary>
    public static class ResponseCache
    {
        /// <summary>
        /// The name of the cache directory
        /// </summary>
        private const string CacheDirectory = "Cache";

        /// <summary>
        /// The mapping between cache key and filename on disk containing the cached response
        /// </summary>
        private static Dictionary<string, string> cacheKeyToFilenameMap = new Dictionary<string, string>();

        /// <summary>
        /// Initializes static members of the <see cref="ResponseCache"/> class
        /// </summary>
        static ResponseCache()
        {
            string cacheDirectory = Path.Combine(Environment.CurrentDirectory, CacheDirectory);
            if (!Directory.Exists(cacheDirectory))
            {
                Directory.CreateDirectory(cacheDirectory);
            }
        }

        /// <summary>
        /// Tries to get a response from the cache
        /// </summary>
        /// <param name="cacheKey">Cache key</param>
        /// <param name="response">Cached response if found</param>
        /// <returns><c>true</c> if response found in cache</returns>
        public static bool TryGet(string cacheKey, out string response)
        {
            response = null;

            if (!cacheKeyToFilenameMap.ContainsKey(cacheKey))
            {
                return false;
            }

            string path = Path.Combine(
                Environment.CurrentDirectory,
                CacheDirectory,
                cacheKeyToFilenameMap[cacheKey]);

            if (!File.Exists(path))
            {
                cacheKeyToFilenameMap.Remove(cacheKey);
                return false;
            }

            response = File.ReadAllText(path);
            return true;
        }

        /// <summary>
        /// Adds or replaces a cached response
        /// </summary>
        /// <param name="cacheKey">The cache key</param>
        /// <param name="response">The response to cache</param>
        public static void AddOrReplace(string cacheKey, string response)
        {
            string filename = $"{Guid.NewGuid()}.json";
            cacheKeyToFilenameMap[cacheKey] = filename;

            string path = Path.Combine(
                Environment.CurrentDirectory,
                CacheDirectory,
                filename);

            File.WriteAllText(path, response);
        }

        /// <summary>
        /// Serializes the cache
        /// </summary>
        /// <returns>Serialized string of the cache</returns>
        public static string Serialize()
        {
            return JsonConvert.SerializeObject(cacheKeyToFilenameMap);
        }

        /// <summary>
        /// Deserializes a string to the cache
        /// </summary>
        /// <param name="value">Serialized string to deserialize</param>
        public static void Deserialize(string value)
        {
            cacheKeyToFilenameMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
        }
    }
}
