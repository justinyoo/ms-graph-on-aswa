using BlazorApp.Helpers;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    /// <summary>
    /// This represents the index page component.
    /// </summary>
    public partial class Index : ComponentBase
    {
        /// <summary>
        /// Gets or sets the <see cref="IGraphHelper"/> instance used to make requests to the Graph API.
        /// </summary>
        [Inject]
        public IGraphHelper? Helper { get; set; }

        /// <summary>
        /// Gets the value indicating whether the component should be hidden or not.
        /// </summary>
        protected virtual bool IsHidden { get; private set; } = true;

        /// <summary>
        /// Gets the email of the logged-in user.
        /// </summary>
        protected virtual string? Upn { get; private set; }

        /// <summary>
        /// Gets the display name of the logged-in user.
        /// </summary>
        protected virtual string? DisplayName { get; private set; }

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            if (this.Helper == null)
            {
                throw new InvalidOperationException("User details have not been initialised yet");
            }

            var loggedInUser = await this.Helper.GetLoggedInUserDetailsAsync().ConfigureAwait(false);

            this.IsHidden = loggedInUser == null;

            this.Upn = loggedInUser?.Upn;
            this.DisplayName = loggedInUser?.DisplayName;
        }
    }
}