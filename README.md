# Geta Service API

![](http://tc.geta.no/app/rest/builds/buildType:(id:TeamFrederik_ServiceApi_EPiBlogCreateAndPublishNuGetPackage)/statusIcon)

## Geta.ServiceApi.Commerce

* Orders
* Customers
* Carts


## Demo
Quicksilver is being used for the demo playground and needs to be setup in order to run the integration tests.

1. Open demo\Quicksilver.sln
2. Built and restore packages
3. Run demo\Setup\SetupDatabases.cmd
4. run update-epidatabase in Package Manager console(This is not just for db update, but for setting up service API permissions correctly as well)
5. In IIS install a self signed certificate
6. In IIS add serviceapi.localtest.me (point it to C:\Projects\service-api\demo\Sources\EPiServer.Reference.Commerce.Site). Binding should be https (choose the certificate from step 5).
7. Navigate to https://serviceapi.localtest.me admin/store


## Integration tests

1. Make sure the demo environment is setup (default is https://serviceapi.localtest.me)
2. Right click Geta.ServiceApi.Commerce.Tests and choose Run Units Tests
