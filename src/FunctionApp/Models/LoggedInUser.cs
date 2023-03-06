using Microsoft.Graph.Models;

using Newtonsoft.Json;

namespace FunctionApp.Models
{
    /// <summary>
    /// This represents the entity for logged-in user details.
    /// </summary>
    public class LoggedInUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggedInUser" /> class.
        /// </summary>
        /// <param name="user"><see cref="User"/> instance.</param>
        public LoggedInUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            this.Upn = user?.UserPrincipalName;
            this.DisplayName = user?.DisplayName;
            this.Email = user?.Mail;
        }

        /// <summary>
        /// Gets or sets the UPN.
        /// </summary>
        [JsonProperty("upn")]
        public virtual string? Upn { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public virtual string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [JsonProperty("email")]
        public virtual string? Email { get; set; }
    }
}