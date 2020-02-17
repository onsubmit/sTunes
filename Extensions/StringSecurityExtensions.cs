//-----------------------------------------------------------------------
// <copyright file="StringSecurityExtensions.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Provides encrypting and decrypting for strings
    /// </summary>
    public static class StringSecurityExtensions
    {
        /// <summary>
        /// A byte array used to increase the complexity of the encryption
        /// </summary>
        private static readonly byte[] Entropy = Encoding.Unicode.GetBytes("bfEJ*3bc6TJ*maQVNmkRnX&t7erP!5BOf^R2j3$00#Ae6!k0Xi");

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="input">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public static string EncryptString(this string input)
        {
            if (input == null)
            {
                return null;
            }

            byte[] encryptedData = ProtectedData.Protect(
                Encoding.Unicode.GetBytes(input),
                Entropy,
                DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="encryptedData">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        public static string DecryptString(this string encryptedData)
        {
            if (encryptedData == null)
            {
                return null;
            }

            try
            {
                byte[] decryptedData = ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    Entropy,
                    DataProtectionScope.CurrentUser);

                return Encoding.Unicode.GetString(decryptedData);
            }
            catch
            {
                return null;
            }
        }
    }
}
