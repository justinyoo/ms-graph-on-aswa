using System.Net;
using System.Text;

using Azure.Identity;

using FunctionApp.Configurations;
using FunctionApp.Models;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

using Newtonsoft.Json;

namespace FunctionApp.Triggers
{
    /// <summary>
    /// This represents the HTTP trigger entity for user details.
    /// </summary>
    public class UserDetailsHttpTrigger
    {
        private readonly GraphSettings _settings;
        private readonly ILogger _logger;

        /// <summary>
        /// Initialise the new instance of the <see cref="UserDetailsHttpTrigger"/> class.
        /// </summary>
        /// <param name="settings"><see cref="GraphSettings"/> instance.</param>
        /// <param name="loggerFactory"><see cref="ILoggerFactory"/> instance.</param>
        public UserDetailsHttpTrigger(GraphSettings settings, ILoggerFactory loggerFactory)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger<UserDetailsHttpTrigger>();
        }

        /// <summary>
        /// Invokes the HTTP trigger to get user details.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestData"/> instance.</param>
        /// <returns>Returns <see cref="HttpResponseData"/> instance.</returns>
        [Function(nameof(UserDetailsHttpTrigger.GetUserDetailsAsync))]
        [OpenApiOperation(operationId: "getUser", tags: new[] { "registration" }, Summary = "Get user details", Description = "This endpoint gets the user details.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(LoggedInUser), Summary = "Response payload including the logged-in user details.", Description = "Response payload that includes the logged-in user details.")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid request", Description = "This indicates the request is invalid.")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "User not found", Description = "This indicates the user is not found.")]
        public async Task<HttpResponseData> GetUserDetailsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "users/get")] HttpRequestData req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse();
            var request = req.Headers.TryGetValues("x-ms-client-principal", out var result) ? result.FirstOrDefault() : null;
            if (string.IsNullOrWhiteSpace(request))
            {
                response.StatusCode = HttpStatusCode.BadRequest;

                return response;
            }

            var json = Encoding.UTF8.GetString(Convert.FromBase64String(request));
            var principal = JsonConvert.DeserializeObject<ClientPrincipal>(json);

            var credential = new ClientSecretCredential(this._settings?.TenantId, this._settings?.ClientId, this._settings?.ClientSecret);
            var client = new GraphServiceClient(credential);

            var users = await client.Users.GetAsync().ConfigureAwait(false);
            var user = users?.Value.SingleOrDefault(p => p.UserPrincipalName == principal?.UserDetails);
            if (user == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;

                return response;
            }

            var loggedInUser = new LoggedInUser(user);

            response.StatusCode = HttpStatusCode.OK;
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            await response.WriteStringAsync(JsonConvert.SerializeObject(loggedInUser)).ConfigureAwait(false);

            return response;
        }
    }
}