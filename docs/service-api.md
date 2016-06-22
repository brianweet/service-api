# Service API

## Order API

### Search orders by modified from date

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/order/0/100/search/?modifiedFrom=2016-06-06%2013:29:53&status=InProgress&status=OnHold HTTP/1.1
Host: serviceapi.localtest.me
Connection: keep-alive
Authorization: Bearer TVAjPbenWwYJ59_c-X1kXUqnRbVp9EJGQ2mQwE7JfcycIAkgx-Ajl45_Go2iOddIWmlysvH9fQMNh-mxFNNZ9HguaMg6WJw9h8newA4BZ7wJ2NwpwTJVurPRomJegDFXbJY4gzP_TKI3QMoXcq1QefcyDO1SwX7letntB90f4HEwNm1lhPT8IDgUbj3UsO1g1rU3tBOGfOlbzSpw13_82Q_7h7aoO62_bMrT6fwfCMra41ZcoQlwtvVfXyk_pt2eL7pMwJZU3egUkxNdkhME1rZ-VcnvlACUwtnLzUnTy1T8z3Snepab8l7V7DgGBPCA
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 4169
Content-Type: application/json; charset=utf-8
Expires: -1
Vary: Accept-Encoding
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 13:35:34 GMT

[{
    "__MetaClass": "PurchaseOrder",
    "CreatorId": null,
    "ModifierId": null,
    "Created": "2016-06-07T13:07:05.773Z",
    "Modified": "2016-06-07T13:20:14.463Z",
    "AdditionalDiscountPercent": "0",
    "ExpirationDate": null,
    "ParentOrderGroupId": "0",
    "TrackingNumber": null,
    "AddressId": "",
    "SiteId": "",
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "Owner": "",
    "Name": "",
    "CustomerName": "",
    "BillingCurrency": "USD",
    "ApplicationId": "201490ff-22cc-436a-bc37-750e7393a803",
    "OrderGroupId": "4",
    "MarketId": "DEFAULT",
    "ProviderId": "",
    "SubTotal": "0.000000000",
    "HandlingTotal": "0.000000000",
    "OwnerOrg": "",
    "ShippingTotal": "0.000000000",
    "TaxTotal": "0.000000000",
    "Status": "InProgress",
    "InstanceId": "cd64c67b-e600-4dc4-8cda-060013efb251",
    "Total": "0.000000000",
    "AffiliateId": "",
    "OrderForms": [{
        "__MetaClass": "OrderFormEx",
        "CreatorId": null,
        "ModifierId": null,
        "Created": "2016-06-07T13:07:05.773Z",
        "Modified": "2016-06-07T13:20:14.463Z",
        "Epi_CouponCodes": null,
        "RMANumber": "",
        "Status": "",
        "BillingAddressId": "",
        "ReturnType": "",
        "ExchangeOrderGroupId": "",
        "Name": "default",
        "ProviderId": "",
        "ReturnAuthCode": "",
        "CapturedPaymentTotal": "0.000000000",
        "OrderGroupId": "4",
        "ReturnComment": "",
        "DiscountAmount": "0.000000000",
        "AuthorizedPaymentTotal": "0.000000000",
        "SubTotal": "0.000000000",
        "HandlingTotal": "0.000000000",
        "ShippingTotal": "0.000000000",
        "TaxTotal": "0.000000000",
        "OrderFormId": "4",
        "Total": "0.000000000",
        "OrigOrderFormId": "",
        "LineItems": [],
        "Discounts": [],
        "Shipments": [{
            "__MetaClass": "ShipmentEx",
            "CreatorId": null,
            "ModifierId": null,
            "Created": "2016-06-07T13:07:05.773Z",
            "Modified": "2016-06-07T13:20:14.463Z",
            "PrevStatus": "",
            "Status": "",
            "ShippingMethodId": "00000000-0000-0000-0000-000000000000",
            "OperationKeys": "",
            "ShipmentTrackingNumber": "",
            "ShipmentId": "9",
            "ShippingAddressId": "",
            "OrderGroupId": "4",
            "Epi_ShippingTax": "0.000000000",
            "SubTotal": "0.000000000",
            "PickListId": "",
            "ShippingMethodName": "",
            "ShippingDiscountAmount": "0.000000000",
            "LineItemIds": "",
            "OrderFormId": "4",
            "ShipmentTotal": "0.000000000",
            "WarehouseCode": "",
            "Discounts": [],
            "OperationKeyMaps": ""
        }],
        "Payments": [],
        "Promotions": []
    }],
    "OrderAddresses": [],
    "OrderNotes": [],
    "ReturnOrderForms": []
}, {
    "__MetaClass": "PurchaseOrder",
    "CreatorId": null,
    "ModifierId": null,
    "Created": "2016-06-07T13:04:50.87Z",
    "Modified": "2016-06-07T13:04:51.24Z",
    "AdditionalDiscountPercent": "0",
    "ExpirationDate": null,
    "ParentOrderGroupId": "0",
    "TrackingNumber": null,
    "AddressId": "",
    "SiteId": "",
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "Owner": "",
    "Name": "",
    "CustomerName": "",
    "BillingCurrency": "USD",
    "ApplicationId": "201490ff-22cc-436a-bc37-750e7393a803",
    "OrderGroupId": "3",
    "MarketId": "DEFAULT",
    "ProviderId": "",
    "SubTotal": "0.000000000",
    "HandlingTotal": "0.000000000",
    "OwnerOrg": "",
    "ShippingTotal": "0.000000000",
    "TaxTotal": "0.000000000",
    "Status": "OnHold",
    "InstanceId": "0989912b-33c2-4c26-ace8-8b0583495162",
    "Total": "0.000000000",
    "AffiliateId": "",
    "OrderForms": [{
        "__MetaClass": "OrderFormEx",
        "CreatorId": null,
        "ModifierId": null,
        "Created": "2016-06-07T13:04:51.007Z",
        "Modified": "2016-06-07T13:04:51.24Z",
        "Epi_CouponCodes": null,
        "RMANumber": "",
        "Status": "",
        "BillingAddressId": "",
        "ReturnType": "",
        "ExchangeOrderGroupId": "",
        "Name": "default",
        "ProviderId": "",
        "ReturnAuthCode": "",
        "CapturedPaymentTotal": "0.000000000",
        "OrderGroupId": "3",
        "ReturnComment": "",
        "DiscountAmount": "0.000000000",
        "AuthorizedPaymentTotal": "0.000000000",
        "SubTotal": "0.000000000",
        "HandlingTotal": "0.000000000",
        "ShippingTotal": "0.000000000",
        "TaxTotal": "0.000000000",
        "OrderFormId": "3",
        "Total": "0.000000000",
        "OrigOrderFormId": "",
        "LineItems": [],
        "Discounts": [],
        "Shipments": [{
            "__MetaClass": "ShipmentEx",
            "CreatorId": null,
            "ModifierId": null,
            "Created": "2016-06-07T13:04:51.023Z",
            "Modified": "2016-06-07T13:04:51.24Z",
            "PrevStatus": "",
            "Status": "",
            "ShippingMethodId": "00000000-0000-0000-0000-000000000000",
            "OperationKeys": "",
            "ShipmentTrackingNumber": "",
            "ShipmentId": "8",
            "ShippingAddressId": "",
            "OrderGroupId": "3",
            "Epi_ShippingTax": "0.000000000",
            "SubTotal": "0.000000000",
            "PickListId": "",
            "ShippingMethodName": "",
            "ShippingDiscountAmount": "0.000000000",
            "LineItemIds": "",
            "OrderFormId": "3",
            "ShipmentTotal": "0.000000000",
            "WarehouseCode": "",
            "Discounts": [],
            "OperationKeyMaps": ""
        }],
        "Payments": [],
        "Promotions": []
    }],
    "OrderAddresses": [],
    "OrderNotes": [],
    "ReturnOrderForms": []
}]
```

### Get order by Order ID

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/order/3023 HTTP/1.1
Authorization: Bearer 6iFJBw7DFPZWHOYmdOypnmzq2jxvwL_1KG6Tj3ZUAsLOZ_bjuKhiERqhlSMOZuV5esVSI4jNBOjEMzbprOZIbFNEbSwdWajxJPQiIVro3aKzn9ZHMKuEN80ZSPIgEJXVCxTCg8mpYrYb6o4sWhGKvSkjp76NndtcXpTlZ787mP6Lti2HKsxs4-WWd-rCmf7HUA2LCk6dIUR8k5PyhSDZ_vxRM8-uxjQl4h3acK4rPTjBfsR48omsz2RyljCuLQ7jvxwSzoAaoWOdD1ThOT0wn2M-LxQ83uPjLyOUH0e_8Pg
Host: serviceapi.localtest.me
Connection: Keep-Alive
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/json; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 06:31:57 GMT
Content-Length: 2098

{
    "__MetaClass": "PurchaseOrder",
    "CreatorId": null,
    "ModifierId": null,
    "Created": "2016-06-02T06:26:24.767Z",
    "Modified": "2016-06-02T06:26:25.017Z",
    "AdditionalDiscountPercent": "0",
    "ExpirationDate": null,
    "ParentOrderGroupId": "0",
    "TrackingNumber": null,
    "Name": "",
    "AddressId": "",
    "InstanceId": "43c99c5f-a0d4-4cfc-8d1e-b57f0c7344ed",
    "OrderGroupId": "3023",
    "Status": "",
    "AffiliateId": "",
    "Total": "0.000000000",
    "ProviderId": "",
    "ShippingTotal": "0.000000000",
    "OwnerOrg": "",
    "SubTotal": "0.000000000",
    "SiteId": "",
    "HandlingTotal": "0.000000000",
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "Owner": "",
    "ApplicationId": "201490ff-22cc-436a-bc37-750e7393a803",
    "BillingCurrency": "USD",
    "MarketId": "DEFAULT",
    "CustomerName": "",
    "TaxTotal": "0.000000000",
    "OrderForms": [{
        "__MetaClass": "OrderFormEx",
        "CreatorId": null,
        "ModifierId": null,
        "Created": "2016-06-02T06:26:24.863Z",
        "Modified": "2016-06-02T06:26:25.017Z",
        "Epi_CouponCodes": null,
        "RMANumber": "",
        "OrderFormId": "3023",
        "Name": "default",
        "ReturnAuthCode": "",
        "OrderGroupId": "3023",
        "BillingAddressId": "",
        "ReturnComment": "",
        "ReturnType": "",
        "Total": "0.000000000",
        "ProviderId": "",
        "ShippingTotal": "0.000000000",
        "OrigOrderFormId": "",
        "HandlingTotal": "0.000000000",
        "CapturedPaymentTotal": "0.000000000",
        "AuthorizedPaymentTotal": "0.000000000",
        "SubTotal": "0.000000000",
        "ExchangeOrderGroupId": "",
        "DiscountAmount": "0.000000000",
        "Status": "",
        "TaxTotal": "0.000000000",
        "LineItems": [],
        "Discounts": [],
        "Shipments": [{
            "__MetaClass": "ShipmentEx",
            "CreatorId": null,
            "ModifierId": null,
            "Created": "2016-06-02T06:26:24.873Z",
            "Modified": "2016-06-02T06:26:25.017Z",
            "PrevStatus": "",
            "Epi_ShippingTax": "0.000000000",
            "OrderFormId": "3023",
            "ShippingMethodName": "",
            "OrderGroupId": "3023",
            "WarehouseCode": "",
            "LineItemIds": "",
            "Status": "",
            "ShipmentId": "3043",
            "SubTotal": "0.000000000",
            "ShipmentTotal": "0.000000000",
            "ShipmentTrackingNumber": "",
            "ShippingAddressId": "",
            "OperationKeys": "",
            "ShippingMethodId": "00000000-0000-0000-0000-000000000000",
            "PickListId": "",
            "ShippingDiscountAmount": "0.000000000",
            "Discounts": [],
            "OperationKeyMaps": ""
        }],
        "Payments": [],
        "Promotions": []
    }],
    "OrderAddresses": [],
    "OrderNotes": [],
    "ReturnOrderForms": []
}
```

### Post Order (add new order)

Request:
```
POST https://serviceapi.localtest.me/episerverapi/commerce/order HTTP/1.1
Authorization: Bearer 6iFJBw7DFPZWHOYmdOypnmzq2jxvwL_1KG6Tj3ZUAsLOZ_bjuKhiERqhlSMOZuV5esVSI4jNBOjEMzbprOZIbFNEbSwdWajxJPQiIVro3aKzn9ZHMKuEN80ZSPIgEJXVCxTCg8mpYrYb6o4sWhGKvSkjp76NndtcXpTlZ787mP6Lti2HKsxs4-WWd-rCmf7HUA2LCk6dIUR8k5PyhSDZ_vxRM8-uxjQl4h3acK4rPTjBfsR48omsz2RyljCuLQ7jvxwSzoAaoWOdD1ThOT0wn2M-LxQ83uPjLyOUH0e_8Pg
Content-Type: application/json; charset=utf-8
Host: serviceapi.localtest.me
Content-Length: 378
Expect: 100-continue

{
    "AddressId": null,
    "AffiliateId": "00000000-0000-0000-0000-000000000000",
    "BillingCurrency": null,
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "CustomerName": null,
    "HandlingTotal": 0.0,
    "InstanceId": "00000000-0000-0000-0000-000000000000",
    "Name": "default",
    "Owner": null,
    "OwnerOrg": null,
    "ProviderId": null,
    "ShippingTotal": 0.0,
    "Status": null,
    "SubTotal": 0.0,
    "TaxTotal": 0.0,
    "Total": 0.0
}
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/json; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 06:26:24 GMT
Content-Length: 1744

{
    "__MetaClass": "PurchaseOrder",
    "CreatorId": null,
    "ModifierId": null,
    "Created": "2016-06-02T06:26:24.767915Z",
    "Modified": "2016-06-02T06:26:25.0164952Z",
    "AdditionalDiscountPercent": null,
    "ExpirationDate": null,
    "ParentOrderGroupId": "0",
    "TrackingNumber": null,
    "Name": "",
    "AddressId": "",
    "InstanceId": "43c99c5f-a0d4-4cfc-8d1e-b57f0c7344ed",
    "OrderGroupId": "3023",
    "Status": "",
    "Total": "0",
    "ShippingTotal": "0",
    "OwnerOrg": "",
    "SubTotal": "0",
    "HandlingTotal": "0.0",
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "Owner": "",
    "ApplicationId": "201490ff-22cc-436a-bc37-750e7393a803",
    "BillingCurrency": "USD",
    "MarketId": "DEFAULT",
    "CustomerName": "",
    "TaxTotal": "0",
    "OrderForms": [{
        "__MetaClass": "OrderFormEx",
        "CreatorId": null,
        "ModifierId": null,
        "Created": "2016-06-02T06:26:24.8626887Z",
        "Modified": "2016-06-02T06:26:25.0164952Z",
        "Epi_CouponCodes": null,
        "RMANumber": "",
        "Total": "0",
        "HandlingTotal": "0",
        "OrderFormId": "3023",
        "ShippingTotal": "0",
        "DiscountAmount": "0",
        "Name": "default",
        "TaxTotal": "0",
        "OrderGroupId": "3023",
        "AuthorizedPaymentTotal": "0",
        "SubTotal": "0",
        "CapturedPaymentTotal": "0",
        "LineItems": [],
        "Discounts": [],
        "Shipments": [{
            "__MetaClass": "ShipmentEx",
            "CreatorId": null,
            "ModifierId": null,
            "Created": "2016-06-02T06:26:24.8737235Z",
            "Modified": "2016-06-02T06:26:25.0164952Z",
            "PrevStatus": "",
            "Epi_ShippingTax": "0",
            "OrderFormId": "3023",
            "ShippingMethodName": "",
            "OrderGroupId": "3023",
            "WarehouseCode": "",
            "LineItemIds": "",
            "Status": "",
            "ShipmentId": "3043",
            "SubTotal": "0.00",
            "ShipmentTotal": "0",
            "ShipmentTrackingNumber": "",
            "ShippingAddressId": "",
            "OperationKeys": "",
            "ShippingMethodId": "00000000-0000-0000-0000-000000000000",
            "ShippingDiscountAmount": "0",
            "Discounts": [],
            "OperationKeyMaps": ""
        }],
        "Payments": [],
        "Promotions": []
    }],
    "OrderAddresses": [],
    "OrderNotes": [],
    "ReturnOrderForms": []
}
```

### Put Order (update order)

Request:
```
PUT https://serviceapi.localtest.me/episerverapi/commerce/order/3023 HTTP/1.1
Authorization: Bearer 6iFJBw7DFPZWHOYmdOypnmzq2jxvwL_1KG6Tj3ZUAsLOZ_bjuKhiERqhlSMOZuV5esVSI4jNBOjEMzbprOZIbFNEbSwdWajxJPQiIVro3aKzn9ZHMKuEN80ZSPIgEJXVCxTCg8mpYrYb6o4sWhGKvSkjp76NndtcXpTlZ787mP6Lti2HKsxs4-WWd-rCmf7HUA2LCk6dIUR8k5PyhSDZ_vxRM8-uxjQl4h3acK4rPTjBfsR48omsz2RyljCuLQ7jvxwSzoAaoWOdD1ThOT0wn2M-LxQ83uPjLyOUH0e_8Pg
Content-Type: application/json; charset=utf-8
Host: serviceapi.localtest.me
Content-Length: 410
Expect: 100-continue
Connection: Keep-Alive

{
    "__MetaClass": "PurchaseOrder",
    "CreatorId": null,
    "ModifierId": null,
    "Created": "2016-06-02T06:26:24.767Z",
    "Modified": "2016-06-02T06:26:25.017Z",
    "AdditionalDiscountPercent": "0",
    "ExpirationDate": null,
    "ParentOrderGroupId": "0",
    "TrackingNumber": null,
    "Name": "",
    "AddressId": "",
    "InstanceId": "43c99c5f-a0d4-4cfc-8d1e-b57f0c7344ed",
    "OrderGroupId": "3023",
    "Status": "",
    "AffiliateId": "",
    "Total": "0.000000000",
    "ProviderId": "",
    "ShippingTotal": "0.000000000",
    "OwnerOrg": "",
    "SubTotal": "0.000000000",
    "SiteId": "",
    "HandlingTotal": "0.000000000",
    "CustomerId": "2a40754d-86d5-460b-a5a4-32bc87703567",
    "Owner": "",
    "ApplicationId": "201490ff-22cc-436a-bc37-750e7393a803",
    "BillingCurrency": "USD",
    "MarketId": "DEFAULT",
    "CustomerName": "",
    "TaxTotal": "0.000000000",
    "OrderForms": [{
        "__MetaClass": "OrderFormEx",
        "CreatorId": null,
        "ModifierId": null,
        "Created": "2016-06-02T06:26:24.863Z",
        "Modified": "2016-06-02T06:26:25.017Z",
        "Epi_CouponCodes": null,
        "RMANumber": "",
        "OrderFormId": "3023",
        "Name": "default",
        "ReturnAuthCode": "",
        "OrderGroupId": "3023",
        "BillingAddressId": "",
        "ReturnComment": "",
        "ReturnType": "",
        "Total": "0.000000000",
        "ProviderId": "",
        "ShippingTotal": "0.000000000",
        "OrigOrderFormId": "",
        "HandlingTotal": "0.000000000",
        "CapturedPaymentTotal": "0.000000000",
        "AuthorizedPaymentTotal": "0.000000000",
        "SubTotal": "0.000000000",
        "ExchangeOrderGroupId": "",
        "DiscountAmount": "0.000000000",
        "Status": "",
        "TaxTotal": "0.000000000",
        "LineItems": [],
        "Discounts": [],
        "Shipments": [{
            "__MetaClass": "ShipmentEx",
            "CreatorId": null,
            "ModifierId": null,
            "Created": "2016-06-02T06:26:24.873Z",
            "Modified": "2016-06-02T06:26:25.017Z",
            "PrevStatus": "",
            "Epi_ShippingTax": "0.000000000",
            "OrderFormId": "3023",
            "ShippingMethodName": "",
            "OrderGroupId": "3024",
            "WarehouseCode": "",
            "LineItemIds": "",
            "Status": "",
            "ShipmentId": "3043",
            "SubTotal": "0.000000000",
            "ShipmentTotal": "0.000000000",
            "ShipmentTrackingNumber": "",
            "ShippingAddressId": "",
            "OperationKeys": "",
            "ShippingMethodId": "00000000-0000-0000-0000-000000000000",
            "PickListId": "",
            "ShippingDiscountAmount": "0.000000000",
            "Discounts": [],
            "OperationKeyMaps": ""
        }],
        "Payments": [],
        "Promotions": []
    }],
    "OrderAddresses": [],
    "OrderNotes": [],
    "ReturnOrderForms": []
}
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 06:33:52 GMT
Content-Length: 0
```

### Delete Order

Request:
```
DELETE https://serviceapi.localtest.me/episerverapi/commerce/order/3023 HTTP/1.1
Authorization: Bearer 6iFJBw7DFPZWHOYmdOypnmzq2jxvwL_1KG6Tj3ZUAsLOZ_bjuKhiERqhlSMOZuV5esVSI4jNBOjEMzbprOZIbFNEbSwdWajxJPQiIVro3aKzn9ZHMKuEN80ZSPIgEJXVCxTCg8mpYrYb6o4sWhGKvSkjp76NndtcXpTlZ787mP6Lti2HKsxs4-WWd-rCmf7HUA2LCk6dIUR8k5PyhSDZ_vxRM8-uxjQl4h3acK4rPTjBfsR48omsz2RyljCuLQ7jvxwSzoAaoWOdD1ThOT0wn2M-LxQ83uPjLyOUH0e_8Pg
Host: serviceapi.localtest.me
Content-Length: 0
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 06:35:56 GMT
Content-Length: 0
```

## Customer API

### Get contacts

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/customer/contact HTTP/1.1
Authorization: Bearer TIECdL5R5gdWeSezekJy1cO4SggT_YDQzLdOJDf10IbKXV4WDIlhvxmkKykbB1KGaTusEeX3XQeNdNCBlHKTpklMPz72PSZnljgYOySw-Ze8Cv1graLYZM1n3PG6O68lEbpM5P-uC2br15CSsYOsieF4w10WmFJtloIj1gQlyRdHcfYMpCwIJztr_z9jsdu023nAlpHE0qrQOrRnDBSvUVzGcpBe82Dv1wEjLHt_WPWexwNt2kJy5yTgmZbYw6Dyb7woBZ69HYzNQYJTAmjUGYHz88gxa_hkdGka7NyIk4M
Host: serviceapi.localtest.me
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/json; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 08:00:16 GMT
Content-Length: 4440

[
{
    "PrimaryKeyId": "31ae3964-8a67-4e97-864f-04d97479c86f",
    "Addresses": [{
        "AddressId": "6bea5941-0553-438c-b913-547dab183e4a",
        "Modified": null,
        "Name": "New address",
        "FirstName": "Kennedy",
        "LastName": "Sutton",
        "CountryName": "United States",
        "CountryCode": "USA",
        "City": "Osi",
        "PostalCode": "12376",
        "Line1": "Consectetur s",
        "Line2": "Ea ut sed neque",
        "Region": "Alabama",
        "Email": "sinomyvyp@yahoo.com",
        "ShippingDefault": false,
        "BillingDefault": false,
        "DaytimePhoneNumber": "+386-50-8858495",
        "EveningPhoneNumber": null,
        "Organization": null
    }, {
        "AddressId": "a599a5f8-e99a-4fb1-ba17-913a438b673b",
        "Modified": null,
        "Name": "New address",
        "FirstName": "Kennedy",
        "LastName": "Sutton",
        "CountryName": "United States",
        "CountryCode": "USA",
        "City": "Osi",
        "PostalCode": "12376",
        "Line1": "Consectetur s",
        "Line2": "Ea ut sed neque",
        "Region": "Tosi",
        "Email": "sinomyvyp@yahoo.com",
        "ShippingDefault": false,
        "BillingDefault": false,
        "DaytimePhoneNumber": "+386-50-8858495",
        "EveningPhoneNumber": null,
        "Organization": null
    }],
    "FirstName": "Kennedy",
    "LastName": "Sutton",
    "Email": "sinomyvyp@yahoo.com",
    "RegistrationSource": "Checkout page"
}, {
    "PrimaryKeyId": "fe592383-60d3-4284-8025-727cdffd1616",
    "Addresses": [{
        "AddressId": "fcb09dea-7d7c-4ff6-9eaf-d920507cd25f",
        "Modified": null,
        "Name": "Default",
        "FirstName": "Sheila",
        "LastName": "Wagner",
        "CountryName": "United States",
        "CountryCode": "USA",
        "City": "Quae",
        "PostalCode": "85507",
        "Line1": "Necessitatibus officiis",
        "Line2": null,
        "Region": "Virgin Islands",
        "Email": "ziwiv@yahoo.com",
        "ShippingDefault": false,
        "BillingDefault": false,
        "DaytimePhoneNumber": "+739-21-7743477",
        "EveningPhoneNumber": null,
        "Organization": null
    }],
    "FirstName": "Sheila",
    "LastName": "Wagner",
    "Email": "ziwiv@yahoo.com",
    "RegistrationSource": "Registration page"
}
]
```

### Get contact by Contact ID

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/customer/contact/099e12f5-684c-4f34-a38b-cebfc8e41816 HTTP/1.1
Authorization: Bearer TIECdL5R5gdWeSezekJy1cO4SggT_YDQzLdOJDf10IbKXV4WDIlhvxmkKykbB1KGaTusEeX3XQeNdNCBlHKTpklMPz72PSZnljgYOySw-Ze8Cv1graLYZM1n3PG6O68lEbpM5P-uC2br15CSsYOsieF4w10WmFJtloIj1gQlyRdHcfYMpCwIJztr_z9jsdu023nAlpHE0qrQOrRnDBSvUVzGcpBe82Dv1wEjLHt_WPWexwNt2kJy5yTgmZbYw6Dyb7woBZ69HYzNQYJTAmjUGYHz88gxa_hkdGka7NyIk4M
Host: serviceapi.localtest.me
Connection: Keep-Alive
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/json; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Thu, 02 Jun 2016 08:08:31 GMT
Content-Length: 646

{
    "PrimaryKeyId": "099e12f5-684c-4f34-a38b-cebfc8e41816",
    "Addresses": [{
        "AddressId": "17eb395d-8d26-4db2-aed4-c52c1b0867d7",
        "Modified": null,
        "Name": "Shipping address",
        "FirstName": "Sam",
        "LastName": "Sample",
        "CountryName": null,
        "CountryCode": "US",
        "City": "New York",
        "PostalCode": "10012",
        "Line1": "379 West Broadway",
        "Line2": "Suite 248",
        "Region": "NY",
        "Email": "sam@sample.com",
        "ShippingDefault": false,
        "BillingDefault": false,
        "DaytimePhoneNumber": "(347) 261-7408",
        "EveningPhoneNumber": "(347) 261-7408",
        "Organization": null
    }],
    "FirstName": "Sam",
    "LastName": "Sample",
    "Email": "sam@sample.com",
    "RegistrationSource": "Geta.ServiceApi.Commerce integration tests"
}
```
