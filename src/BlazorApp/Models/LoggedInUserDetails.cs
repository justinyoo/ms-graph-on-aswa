using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    /// <summary>
    /// This represents the entity for the logged-in user details.
    /// </summary>
    public class LoggedInUserDetails
    {
        /// <summary>
        /// Gets or sets the UPN.
        /// </summary>
        [JsonPropertyName("upn")]
        public virtual string? Upn { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonPropertyName("displayName")]
        public virtual string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonPropertyName("email")]
        public virtual string? Email { get; set; }
    }
}