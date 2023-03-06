using Newtonsoft.Json;

namespace FunctionApp.Models
{
    /// <summary>
    /// This represents the entity for the client principal.
    /// </summary>
    public class ClientPrincipal
    {
        /// <summary>
        /// Gets or sets the identity provider.
        /// </summary>
        [JsonProperty("identityProvider")]
        public string? IdentityProvider { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        [JsonProperty("userDetails")]
        public string? UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        [JsonProperty("userRoles")]
        public IEnumerable<string>? UserRoles { get; set; }
    }
}