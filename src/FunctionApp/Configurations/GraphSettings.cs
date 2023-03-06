namespace FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity for Microsoft Graph.
    /// </summary>
    public class GraphSettings
    {
        /// <summary>
        /// Gets the app settings name.
        /// </summary>
        public const string Name = "MsGraph";

        /// <summary>
        /// Gets or sets the tenant ID.
        /// </summary>
        public virtual string? TenantId { get; set; }

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public virtual string? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public virtual string? ClientSecret { get; set; }
    }
}