using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    /// <summary>
    /// This represents the Graph user details component.
    /// </summary>
    public partial class GraphUserDetails : ComponentBase
    {
        /// <summary>
        /// Gets or sets the user's UPN.
        /// </summary>
        [Parameter]
        public virtual string? Upn { get; set; }

        /// <summary>
        /// Gets or sets the user's display name
        /// </summary>
        [Parameter]
        public virtual string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the component is hidden or not.
        /// </summary>
        public virtual bool IsHidden { get; set; } = true;

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            this.IsHidden = this.Upn == null && this.DisplayName == null;
        }
    }
}