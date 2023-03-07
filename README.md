# Microsoft Graph on Azure Static Web Apps with Blazor WebAssembly #

This is the sample application written in Blazor WebAssembly that communicates with Microsoft Graph, running on Azure Static Web Apps.


## Prerequisites ##

* Azure subscription: [Get a free Azure subscription today](https://azure.microsoft.com/free)
* GitHub account: [Get free sign-up today](http://github.com/signup)
* [Visual Studio](https://visualstudio.microsoft.com) or [Visual Studio Code](https://code.visualstudio.com)


## Getting Started ##

1. Fork this repository to your account.
1. Open a GitHub Codespace instance or clone the forked repository to your local computer.
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
