# Geta Service API

![](http://tc.geta.no/app/rest/builds/buildType:(id:TeamFrederik_ServiceApi_EPiBlogCreateAndPublishNuGetPackage)/statusIcon)
[![Platform](https://img.shields.io/badge/Platform-.NET 4.5.2-blue.svg?style=flat)](https://msdn.microsoft.com/en-us/library/w0x726c2%28v=vs.110%29.aspx)
[![Platform](https://img.shields.io/badge/Episerver%20Commerce-%2010-orange.svg?style=flat)](http://world.episerver.com/commerce/)

## Geta.ServiceApi.Commerce

* Orders
* Customers
* Carts

## Installation

Web API:
```
Install-Package Geta.ServiceApi.Commerce
```

WebHooks:
```
Install-Package Geta.ServiceApi.Commerce.WebHooks
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

## Documentation

### Swagger documentation

_Swagger_ documentation is set up on demo environment project:
https://serviceapi.localtest.me/swagger

### Swagger documentation in your project

To include _Swagger_ documentation into your project, install [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) _NuGet_ package:
```
Install-Package Swashbuckle
```

Configure XML Comments in _SwaggerConfig.cs_ in _EnableSwagger_ method:
```
c.IncludeXmlComments(GetServiceApiXmlCommentsPath());
```

And create _GetServiceApiXmlCommentsPath_ method to resolve XML documentation:
```
private static string GetServiceApiXmlCommentsPath()
{
    return $@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\Geta.ServiceApi.Commerce.xml";
}
```

### Service API XML documentation

[XML](docs/service-api-xml.md) version of documentation.

### WebHooks

_Geta.ServiceApi.Commerce.WebHooks_ adds [_ASP.NET WebHooks_](https://github.com/aspnet/WebHooks) to your project and raises these _EPiServer Commerce_ events:
- [InventoryUpdated](http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-Commerce/9/events/inventory-events/) - raised on inventory update. Sends collection of _CatalogKeys_ affected.
- [PriceUpdated](http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-Commerce/9/events/pricing-events/) - raised on price update. Sends collection of _CatalogKeys_ affected and _PriceDetailValues_ affected.
- [OrderGroupUpdated](http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-Commerce/9/Orders/order-events/) - raised on order group update. Sends _OrderGroupId_, _OrderGroupType_ and _OrderGroup_ affected.
- [OrderGroupDeleted](http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-Commerce/9/Orders/order-events/) - raised on order group delete. Sends _OrderGroupId_, _OrderGroupType_ and _OrderGroup_ affected.
