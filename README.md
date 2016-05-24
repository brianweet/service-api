# Geta Service API

![](http://tc.geta.no/app/rest/builds/buildType:(id:TeamFrederik_ServiceApi_EPiBlogCreateAndPublishNuGetPackage)/statusIcon)

## Geta.ServiceApi.Commerce

* Orders
* Customers
* Carts

## Installation

```
Install-Package Geta.ServiceApi.Commerce -Prerelease
```

## Demo
Quicksilver is being used for the demo playground and needs to be setup in order to run the integration tests.

1. In IIS install a self signed certificate
2. In IIS add serviceapi.localtest.me (point it to C:\Projects\service-api\demo\Sources\EPiServer.Reference.Commerce.Site). Binding should be https (choose the certificate from step 1). If the site doesn't start, it is likely that Skype should be closed. Then site can be started and then Skype can be turned on.
3. Open demo\Quicksilver.sln
4. Built and restore packages
5. Run demo\Setup\SetupDatabases.cmd
6. run update-epidatabase in Package Manager console(This is not just for db update, but for setting up service API permissions correctly as well)
7. Navigate to https://serviceapi.localtest.me admin/store


## Integration tests

1. Make sure the demo environment is setup (default is https://serviceapi.localtest.me)
2. Right click Geta.ServiceApi.Commerce.Tests and choose Run Units Tests
