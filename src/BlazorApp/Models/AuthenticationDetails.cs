using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    /// <summary>
    /// This represents the entity for authentication details.
    /// </summary>
    public class AuthenticationDetails
    {
        /// <summary>
        /// Gets or sets the <see cref="Models.ClientPrincipal"/> instance.
        /// </summary>
        [JsonPropertyName("clientPrincipal")]
        public ClientPrincipal? ClientPrincipal { get; set; }
    }
}