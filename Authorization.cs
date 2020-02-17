//-----------------------------------------------------------------------
// <copyright file="Authorization.cs" company="Andy Young">
//     Copyright (c) Andy Young. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace OnSubmit.STunes
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using OnSubmit.STunes.Apis;
    using OnSubmit.STunes.Helpers;

    /// <summary>
    /// Provides mechanisms for authorization and authentication to Spotify's Web APIs
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// The parent form
        /// </summary>
        private Form parent;

        /// <summary>
        /// The access token
        /// </summary>
        private string accessToken;

        /// <summary>
        /// The refresh token
        /// </summary>
        private string refreshToken;

        /// <summary>
        /// The date in UTC when the access token expires
        /// </summary>
        private DateTime accessTokenExpiration = DateTime.MinValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization"/> class
        /// </summary>
        /// <param name="parent">The parent form</param>
        public Authorization(Form parent)
        {
            this.parent = parent;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.AccessToken))
            {
                this.accessToken = Properties.Settings.Default.AccessToken.DecryptString();
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.RefreshToken))
            {
                this.refreshToken = Properties.Settings.Default.RefreshToken.DecryptString();
            }

            this.accessTokenExpiration = Properties.Settings.Default.AccessTokenExpiration;
        }

        /// <summary>
        /// Gets a value indicating whether the access token is expired
        /// </summary>
        private bool IsAccessTokenExpired => this.accessTokenExpiration < DateTime.UtcNow;

        /// <summary>
        /// Gets a value indicating whether the access token is expiring soon
        /// </summary>
        private bool IsAccessTokenNearExpiry => this.accessTokenExpiration - TimeSpan.FromMinutes(10) < DateTime.UtcNow;

        /// <summary>
        /// Gets an access token. May prompt for credentials or refresh if near expiry/expired.
        /// </summary>
        /// <returns>An access token</returns>
        public async Task<string> GetAccessToken()
        {
            if (!string.IsNullOrWhiteSpace(this.accessToken)
                && !this.IsAccessTokenExpired
                && !this.IsAccessTokenNearExpiry)
            {
                // Access token is fresh
                return this.accessToken;
            }
            else if (string.IsNullOrWhiteSpace(this.refreshToken))
            {
                // No refresh token exists, exchange an authorization code for an access token
                string authorizationCode = this.GetAuthorizationCode();
                if (string.IsNullOrWhiteSpace(authorizationCode))
                {
                    MessageBox.Show(
                        "Unable to retrieve authorization code. Exiting.",
                        "Login failure",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Application.Exit();
                }

                (this.accessToken, this.refreshToken, this.accessTokenExpiration) = await this.GetTokens(authorizationCode);
            }
            else
            {
                // Forget expired access tokens
                this.accessToken = null;
            }

            if (string.IsNullOrWhiteSpace(this.accessToken))
            {
                if (string.IsNullOrWhiteSpace(this.refreshToken))
                {
                    MessageBox.Show(
                        "Unable to retrieve refresh token.",
                        "Login failure",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return null;
                }

                (this.accessToken, this.accessTokenExpiration) = await this.RefreshAccessToken(this.refreshToken);
            }

            if (string.IsNullOrWhiteSpace(this.accessToken))
            {
                MessageBox.Show(
                    "Unable to retrieve access token.",
                    "Login failure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

            Properties.Settings.Default.AccessToken = this.accessToken.EncryptString();
            Properties.Settings.Default.RefreshToken = this.refreshToken.EncryptString();
            Properties.Settings.Default.AccessTokenExpiration = this.accessTokenExpiration;
            Properties.Settings.Default.Save();

            return this.accessToken;
        }

        /// <summary>
        /// Gets an authorization code
        /// </summary>
        /// <returns>An authorization code</returns>
        private string GetAuthorizationCode()
        {
            AuthorizeForm authorizeForm = new AuthorizeForm();
            authorizeForm.ShowDialog(this.parent);

            return authorizeForm.AuthorizationCode;
        }

        /// <summary>
        /// Gets an access token from a refresh token
        /// </summary>
        /// <param name="refreshToken">The refresh token</param>
        /// <returns>An access token and its expiration date</returns>
        private async Task<(string accessToken, DateTime expiration)> RefreshAccessToken(string refreshToken)
        {
            string clientId = Properties.Settings.Default.ClientId;
            string clientSecret = Properties.Settings.Default.ClientSecret.DecryptString();

            TokenApi tokenApi = new TokenApi() { AuthorizationHeader = new AuthorizationHeader(clientId, clientSecret) };

            dynamic json = await tokenApi.GetAccessToken(
                refreshToken,
                errorCallback: (errorResponse) =>
                {
                    MessageBox.Show(
                        errorResponse,
                        "Login failure",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                });

            int expiresInSeconds = json.expires_in;
            DateTime expiration = DateTime.UtcNow.AddSeconds(expiresInSeconds);

            return (json.access_token, expiration);
        }

        /// <summary>
        /// Exchanges an authorization code for an access token and refresh token
        /// </summary>
        /// <param name="authorizationCode">The authorization code</param>
        /// <returns>An access token, its expiration date, and a refresh token</returns>
        private async Task<(string accessToken, string refreshToken, DateTime expiration)> GetTokens(string authorizationCode)
        {
            string redirectUri = Properties.Settings.Default.RedirectUri;
            string clientId = Properties.Settings.Default.ClientId;
            string clientSecret = Properties.Settings.Default.ClientSecret.DecryptString();

            TokenApi tokenApi = new TokenApi() { AuthorizationHeader = new AuthorizationHeader(clientId, clientSecret) };

            dynamic json = await tokenApi.GetAccessCode(
                authorizationCode,
                redirectUri,
                errorCallback: (errorResponse) =>
                {
                    MessageBox.Show(
                        errorResponse,
                        "Login failure",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                });

            int expiresInSeconds = json.expires_in;
            DateTime expiration = DateTime.UtcNow.AddSeconds(expiresInSeconds);

            return (json.access_token, json.refresh_token, expiration);
        }
    }
}
