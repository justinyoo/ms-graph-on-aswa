using BlazorApp.Helpers;
using BlazorApp.Models;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Shared
{
    /// <summary>
    /// This represents the main layout component.
    /// </summary>
    public partial class MainLayout : LayoutComponentBase
    {
        /// <summary>
        /// Gets or sets the <see cref="IGraphHelper"/> instance.
        /// </summary>
        [Inject]
        public IGraphHelper? Helper { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the user is authenticated or not.
        /// </summary>
        protected virtual bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Gets or sets the value indicating whether the login DOM is hidden or not.
        /// </summary>
        protected virtual bool IsLoginHidden { get; private set; } = false;

        /// <summary>
        /// Gets or sets the value indicating whether the logout DOM is hidden or not.
        /// </summary>
        protected virtual bool IsLogoutHidden { get; private set; } = true;

        /// <summary>
        /// Gets the logged-in user's display name.
        /// </summary>
        protected virtual string? DisplayName { get; private set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            await this.GetLogInDetailsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes right after the user logged-in.
        /// </summary>
        protected async Task OnLoggedInAsync()
        {
            await this.GetLogInDetailsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes right after the user logged-out.
        /// </summary>
        protected async Task OnLoggedOutAsync()
        {
            await this.GetLogInDetailsAsync().ConfigureAwait(false);
        }

        private async Task GetLogInDetailsAsync()
        {
            if (this.Helper == null)
            {
                throw new InvalidOperationException("User details have not been initialised yet");
            }

            var authDetails = await this.Helper.GetAuthenticationDetailsAsync().ConfigureAwait(false);

            this.IsAuthenticated = authDetails.ClientPrincipal != null;
            this.IsLoginHidden = this.IsAuthenticated;
            this.IsLogoutHidden = !this.IsAuthenticated;

            var loggedInUser = await this.Helper.GetLoggedInUserDetailsAsync().ConfigureAwait(false);
            this.DisplayName = loggedInUser?.DisplayName ?? "Not a user in this tenant";
        }
    }
}