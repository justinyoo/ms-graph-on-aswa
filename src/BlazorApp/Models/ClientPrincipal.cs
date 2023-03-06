using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    /// <summary>
    /// This represents the entity for the client principal.
    /// </summary>
    public class ClientPrincipal
    {
        /// <summary>
        /// Gets or sets the identity provider.
        /// </summary>
        [JsonPropertyName("identityProvider")]
        public string? IdentityProvider { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        [JsonPropertyName("userDetails")]
        public string? UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        [JsonPropertyName("userRoles")]
        public IEnumerable<string>? UserRoles { get; set; }
    }
}