# Microsoft Graph on Azure Static Web Apps with Blazor WebAssembly #

This is the sample application written in Blazor WebAssembly that communicates with Microsoft Graph, running on Azure Static Web Apps.


## Prerequisites ##

* Azure subscription: [Get a free Azure subscription today](https://azure.microsoft.com/free)
* GitHub account: [Get free sign-up today](http://github.com/signup)
* [Visual Studio](https://visualstudio.microsoft.com) or [Visual Studio Code](https://code.visualstudio.com)


## Getting Started ##

1. Fork this repository to your account.
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
   > Then, copy the URL from the browser's location bar, open a new terminal and paste it with the `curl` command like:
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

1. Update your `.env` file by adding the following lines:

    ```bash
    GITHUB_USERNAME="{{YOUR_GITHUB_USERNAME}}"
    GITHUB_REPOSITORY_NAME="ms-graph-on-aswa"
    ```

1. Run the following command to provision all the apps to Azure:

    ```bash
    azd provision
    ```
