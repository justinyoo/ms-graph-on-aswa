targetScope = 'subscription'

param name string
param location string = 'eastasia'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-${name}'
  location: location
}

module wrkspc './logAnalyticsWorkspace.bicep' = {
  name: 'LogAnalyticsWorkspace'
  scope: rg
  params: {
    name: name
    location: location
  }
}

module appins 'applicationInsights.bicep' = {
  name: 'ApplicationInsights'
  scope: rg
  params: {
    name: name
    location: location
    workspaceId: wrkspc.outputs.id
  }
}

module sttapp './staticWebApp.bicep' = {
  name: 'StaticWebApp'
  scope: rg
  params: {
    name: name
    location: location
    appInsightsId: appins.outputs.id
    appInsightsInstrumentationKey: appins.outputs.instrumentationKey
    appInsightsConnectionString: appins.outputs.connectionString
  }
}
