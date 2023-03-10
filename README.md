# Microsoft Graph on Azure Static Web Apps with Blazor WebAssembly #

This is the sample application written in [Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor?WT.mc_id=dotnet-91112-juyoo) that communicates with [Microsoft Graph](https://learn.microsoft.com/graph/overview?WT.mc_id=dotnet-91112-juyoo), running on [Azure Static Web Apps](https://learn.microsoft.com/azure/static-web-apps/overview?WT.mc_id=dotnet-91112-juyoo).


## Prerequisites ##

* Azure subscription: [Get a free Azure subscription today](https://azure.microsoft.com/free?WT.mc_id=dotnet-91112-juyoo)
* GitHub account: [Get free sign-up today](http://github.com/signup)
* [Visual Studio](https://visualstudio.microsoft.com?WT.mc_id=dotnet-91112-juyoo) or [Visual Studio Code](https://code.visualstudio.com?WT.mc_id=dotnet-91112-juyoo)


## Getting Started ##

### Housekeeping ###

1. Fork this repository to your account.
1. Open a GitHub Codespace instance or clone the forked repository to your local computer.


### Resource Provisioning ###

1. Run the following command to login to Azure:

    ```bash
    azd login
    ```

   > If you're running this code on GitHub Codespaces, run the following command instead:
   > 
   > ```bash
   > azd login --use-device-code=false
   > ```
   > 
   > It opens a new web browser and get an error. Copy the URL from the browser's location bar, open a new terminal and paste it with the `curl` command like:
   > 
   > ```bash
   > curl {{COPIED_URL}}
   > ```

1. Run the following command to initialise Azure Dev CLI:

    ```bash
    azd init
    ```

1. Run the following command to integrate with GitHub Actions workflow:

    ```bash
    azd pipeline config
    ```

1. Run the following command to provision all the apps to Azure:

    ```bash
    azd provision
    ```


### App Deployment ###

1. [Register an app to Azure Active Directory](https://learn.microsoft.com/azure/active-directory/develop/quickstart-register-app?WT.mc_id=dotnet-91112-juyoo) and add the following values to GitHub repository secrets:

   * `GRAPH_CLIENT_ID`
   * `GRAPH_CLIENT_SECRET`
   * `GRAPH_TENANT_ID`

   > It would be better to register this app on a different tenant from the tenant where the app is deployed.


#### GitHub Actions Workflow ####

1. Push your code changes to the repository, and it will automatically trigger the GitHub Actions workflow.


#### Manual Deployment ####

If you want to deploy the app from your local machine or GitHub Codespace instance, follow the steps below.

1. Build artifacts

    ```bash
    swa build
    ```

1. Login to Azure

    ```bash
    az login
    ```

   > If you're running this code on GitHub Codespaces, it opens a new web browser and get an error. Copy the URL from the browser's location bar, open a new terminal and paste it with the `curl` command like:
   > 
   > ```bash
   > curl {{COPIED_URL}}
   > ```


1. Get the deployment key from the Azure Static Web App instance. `$AZURE_ENV_NAME` is what you have set the value through `azd init`.

    ```bash
    SWA_TOKEN=$(az staticwebapp secrets list \
      -g rg-$AZURE_ENV_NAME \
      -n sttapp-$AZURE_ENV_NAME \
      --query "properties.apiKey" -o tsv)
    ```

1. Run the following command to deploy

   ```bash
    swa deploy \
      -d $SWA_TOKEN \
      -i src/FunctionApp/bin/Release/net7.0/publish \
      --env default
   ```


## Try More? ##

* [Build ASP.NET App with Microsoft Graph](https://learn.microsoft.com/training/paths/m365-msgraph-dotnet-core-scenarios?WT.mc_id=dotnet-91112-juyoo)
* [Build Web App with Blazor](https://learn.microsoft.com/training/paths/build-web-apps-with-blazor?WT.mc_id=dotnet-91112-juyoo)

