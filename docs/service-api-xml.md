# Service API (XML)

## Order API

### Search orders by modified from date

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/order/0/100/search/?modifiedFrom=2016-06-06%2013:29:53&status=InProgress&status=OnHold HTTP/1.1
Host: serviceapi.localtest.me
Connection: keep-alive
Accept: text/xml
Authorization: Bearer TVAjPbenWwYJ59_c-X1kXUqnRbVp9EJGQ2mQwE7JfcycIAkgx-Ajl45_Go2iOddIWmlysvH9fQMNh-mxFNNZ9HguaMg6WJw9h8newA4BZ7wJ2NwpwTJVurPRomJegDFXbJY4gzP_TKI3QMoXcq1QefcyDO1SwX7letntB90f4HEwNm1lhPT8IDgUbj3UsO1g1rU3tBOGfOlbzSpw13_82Q_7h7aoO62_bMrT6fwfCMra41ZcoQlwtvVfXyk_pt2eL7pMwJZU3egUkxNdkhME1rZ-VcnvlACUwtnLzUnTy1T8z3Snepab8l7V7DgGBPCA
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 5353
Content-Type: text/xml; charset=utf-8
Expires: -1
Vary: Accept-Encoding
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 13:32:31 GMT

<ArrayOfPurchaseOrder xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <PurchaseOrder xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <__MetaClass>PurchaseOrder</__MetaClass><CreatorId/><ModifierId/>
        <Created>2016-06-07T13:07:05.7730000Z</Created>
        <Modified>2016-06-07T13:20:14.4630000Z</Modified>
        <AdditionalDiscountPercent>0</AdditionalDiscountPercent><ExpirationDate/>
        <ParentOrderGroupId>0</ParentOrderGroupId><TrackingNumber/>
        <OrderGroupId>4</OrderGroupId><Owner/><OwnerOrg/><ProviderId/>
        <ShippingTotal>0.000000000</ShippingTotal><SiteId/>
        <Status>InProgress</Status>
        <SubTotal>0.000000000</SubTotal>
        <TaxTotal>0.000000000</TaxTotal>
        <Total>0.000000000</Total><AddressId/><AffiliateId/>
        <ApplicationId>201490ff-22cc-436a-bc37-750e7393a803</ApplicationId>
        <BillingCurrency>USD</BillingCurrency>
        <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId><CustomerName/>
        <HandlingTotal>0.000000000</HandlingTotal>
        <InstanceId>cd64c67b-e600-4dc4-8cda-060013efb251</InstanceId>
        <MarketId>DEFAULT</MarketId><Name/>
        <OrderForms>
            <OrderForm>
                <__MetaClass>OrderFormEx</__MetaClass><CreatorId/><ModifierId/>
                <Created>2016-06-07T13:07:05.7730000Z</Created>
                <Modified>2016-06-07T13:20:14.4630000Z</Modified><Epi_CouponCodes/><RMANumber/>
                <OrderFormId>4</OrderFormId>
                <OrderGroupId>4</OrderGroupId><OrigOrderFormId/><ProviderId/><ReturnAuthCode/><ReturnComment/><ReturnType/>
                <ShippingTotal>0.000000000</ShippingTotal><Status/>
                <SubTotal>0.000000000</SubTotal>
                <TaxTotal>0.000000000</TaxTotal>
                <Total>0.000000000</Total>
                <AuthorizedPaymentTotal>0.000000000</AuthorizedPaymentTotal><BillingAddressId/>
                <CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
                <DiscountAmount>0.000000000</DiscountAmount><ExchangeOrderGroupId/>
                <HandlingTotal>0.000000000</HandlingTotal>
                <Name>default</Name><LineItems/>
                <Shipments>
                    <Shipment>
                        <__MetaClass>ShipmentEx</__MetaClass><CreatorId/><ModifierId/>
                        <Created>2016-06-07T13:07:05.7730000Z</Created>
                        <Modified>2016-06-07T13:20:14.4630000Z</Modified><PrevStatus/>
                        <ShipmentId>9</ShipmentId>
                        <ShipmentTotal>0.000000000</ShipmentTotal><ShipmentTrackingNumber/><ShippingAddressId/>
                        <ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
                        <ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId><ShippingMethodName/><Status/>
                        <SubTotal>0.000000000</SubTotal><WarehouseCode/>
                        <Epi_ShippingTax>0.000000000</Epi_ShippingTax><LineItemIds/><OperationKeys/>
                        <OrderFormId>4</OrderFormId>
                        <OrderGroupId>4</OrderGroupId><PickListId/><Discounts/></Shipment>
                </Shipments><Payments/><Discounts/><Promotions/></OrderForm>
        </OrderForms><OrderAddresses/><OrderNotes/><ReturnOrderForms/></PurchaseOrder>
    <PurchaseOrder xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <__MetaClass>PurchaseOrder</__MetaClass><CreatorId/><ModifierId/>
        <Created>2016-06-07T13:04:50.8700000Z</Created>
        <Modified>2016-06-07T13:04:51.2400000Z</Modified>
        <AdditionalDiscountPercent>0</AdditionalDiscountPercent><ExpirationDate/>
        <ParentOrderGroupId>0</ParentOrderGroupId><TrackingNumber/>
        <OrderGroupId>3</OrderGroupId><Owner/><OwnerOrg/><ProviderId/>
        <ShippingTotal>0.000000000</ShippingTotal><SiteId/>
        <Status>OnHold</Status>
        <SubTotal>0.000000000</SubTotal>
        <TaxTotal>0.000000000</TaxTotal>
        <Total>0.000000000</Total><AddressId/><AffiliateId/>
        <ApplicationId>201490ff-22cc-436a-bc37-750e7393a803</ApplicationId>
        <BillingCurrency>USD</BillingCurrency>
        <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId><CustomerName/>
        <HandlingTotal>0.000000000</HandlingTotal>
        <InstanceId>0989912b-33c2-4c26-ace8-8b0583495162</InstanceId>
        <MarketId>DEFAULT</MarketId><Name/>
        <OrderForms>
            <OrderForm>
                <__MetaClass>OrderFormEx</__MetaClass><CreatorId/><ModifierId/>
                <Created>2016-06-07T13:04:51.0070000Z</Created>
                <Modified>2016-06-07T13:04:51.2400000Z</Modified><Epi_CouponCodes/><RMANumber/>
                <OrderFormId>3</OrderFormId>
                <OrderGroupId>3</OrderGroupId><OrigOrderFormId/><ProviderId/><ReturnAuthCode/><ReturnComment/><ReturnType/>
                <ShippingTotal>0.000000000</ShippingTotal><Status/>
                <SubTotal>0.000000000</SubTotal>
                <TaxTotal>0.000000000</TaxTotal>
                <Total>0.000000000</Total>
                <AuthorizedPaymentTotal>0.000000000</AuthorizedPaymentTotal><BillingAddressId/>
                <CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
                <DiscountAmount>0.000000000</DiscountAmount><ExchangeOrderGroupId/>
                <HandlingTotal>0.000000000</HandlingTotal>
                <Name>default</Name><LineItems/>
                <Shipments>
                    <Shipment>
                        <__MetaClass>ShipmentEx</__MetaClass><CreatorId/><ModifierId/>
                        <Created>2016-06-07T13:04:51.0230000Z</Created>
                        <Modified>2016-06-07T13:04:51.2400000Z</Modified><PrevStatus/>
                        <ShipmentId>8</ShipmentId>
                        <ShipmentTotal>0.000000000</ShipmentTotal><ShipmentTrackingNumber/><ShippingAddressId/>
                        <ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
                        <ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId><ShippingMethodName/><Status/>
                        <SubTotal>0.000000000</SubTotal><WarehouseCode/>
                        <Epi_ShippingTax>0.000000000</Epi_ShippingTax><LineItemIds/><OperationKeys/>
                        <OrderFormId>3</OrderFormId>
                        <OrderGroupId>3</OrderGroupId><PickListId/><Discounts/></Shipment>
                </Shipments><Payments/><Discounts/><Promotions/></OrderForm>
        </OrderForms><OrderAddresses/><OrderNotes/><ReturnOrderForms/></PurchaseOrder>
</ArrayOfPurchaseOrder>
```

### Get order by Order ID

Request:
```
GET https://serviceapi.localtest.me/episerverapi/commerce/order/4 HTTP/1.1
Host: serviceapi.localtest.me
Connection: keep-alive
Accept: text/xml
Authorization: Bearer TVAjPbenWwYJ59_c-X1kXUqnRbVp9EJGQ2mQwE7JfcycIAkgx-Ajl45_Go2iOddIWmlysvH9fQMNh-mxFNNZ9HguaMg6WJw9h8newA4BZ7wJ2NwpwTJVurPRomJegDFXbJY4gzP_TKI3QMoXcq1QefcyDO1SwX7letntB90f4HEwNm1lhPT8IDgUbj3UsO1g1rU3tBOGfOlbzSpw13_82Q_7h7aoO62_bMrT6fwfCMra41ZcoQlwtvVfXyk_pt2eL7pMwJZU3egUkxNdkhME1rZ-VcnvlACUwtnLzUnTy1T8z3Snepab8l7V7DgGBPCA
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 2613
Content-Type: text/xml; charset=utf-8
Expires: -1
Vary: Accept-Encoding
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 13:24:13 GMT

<PurchaseOrder xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <__MetaClass>PurchaseOrder</__MetaClass><CreatorId/><ModifierId/>
    <Created>2016-06-07T13:07:05.7730000Z</Created>
    <Modified>2016-06-07T13:20:14.4630000Z</Modified>
    <AdditionalDiscountPercent>0</AdditionalDiscountPercent><ExpirationDate/>
    <ParentOrderGroupId>0</ParentOrderGroupId><TrackingNumber/>
    <OrderGroupId>4</OrderGroupId><Owner/><OwnerOrg/><ProviderId/>
    <ShippingTotal>0.000000000</ShippingTotal><SiteId/>
    <Status>InProgress</Status>
    <SubTotal>0.000000000</SubTotal>
    <TaxTotal>0.000000000</TaxTotal>
    <Total>0.000000000</Total><AddressId/><AffiliateId/>
    <ApplicationId>201490ff-22cc-436a-bc37-750e7393a803</ApplicationId>
    <BillingCurrency>USD</BillingCurrency>
    <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId><CustomerName/>
    <HandlingTotal>0.000000000</HandlingTotal>
    <InstanceId>cd64c67b-e600-4dc4-8cda-060013efb251</InstanceId>
    <MarketId>DEFAULT</MarketId><Name/>
    <OrderForms>
        <OrderForm>
            <__MetaClass>OrderFormEx</__MetaClass><CreatorId/><ModifierId/>
            <Created>2016-06-07T13:07:05.7730000Z</Created>
            <Modified>2016-06-07T13:20:14.4630000Z</Modified><Epi_CouponCodes/><RMANumber/>
            <OrderFormId>4</OrderFormId>
            <OrderGroupId>4</OrderGroupId><OrigOrderFormId/><ProviderId/><ReturnAuthCode/><ReturnComment/><ReturnType/>
            <ShippingTotal>0.000000000</ShippingTotal><Status/>
            <SubTotal>0.000000000</SubTotal>
            <TaxTotal>0.000000000</TaxTotal>
            <Total>0.000000000</Total>
            <AuthorizedPaymentTotal>0.000000000</AuthorizedPaymentTotal><BillingAddressId/>
            <CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
            <DiscountAmount>0.000000000</DiscountAmount><ExchangeOrderGroupId/>
            <HandlingTotal>0.000000000</HandlingTotal>
            <Name>default</Name><LineItems/>
            <Shipments>
                <Shipment>
                    <__MetaClass>ShipmentEx</__MetaClass><CreatorId/><ModifierId/>
                    <Created>2016-06-07T13:07:05.7730000Z</Created>
                    <Modified>2016-06-07T13:20:14.4630000Z</Modified><PrevStatus/>
                    <ShipmentId>9</ShipmentId>
                    <ShipmentTotal>0.000000000</ShipmentTotal><ShipmentTrackingNumber/><ShippingAddressId/>
                    <ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
                    <ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId><ShippingMethodName/><Status/>
                    <SubTotal>0.000000000</SubTotal><WarehouseCode/>
                    <Epi_ShippingTax>0.000000000</Epi_ShippingTax><LineItemIds/><OperationKeys/>
                    <OrderFormId>4</OrderFormId>
                    <OrderGroupId>4</OrderGroupId><PickListId/><Discounts/></Shipment>
            </Shipments><Payments/><Discounts/><Promotions/></OrderForm>
    </OrderForms><OrderAddresses/><OrderNotes/><ReturnOrderForms/></PurchaseOrder>
```

### Post Order (add new order)

Request:
```
POST https://serviceapi.localtest.me/episerverapi/commerce/order HTTP/1.1
Host: serviceapi.localtest.me
Connection: keep-alive
Content-Length: 638
Accept: text/xml
Authorization: Bearer TVAjPbenWwYJ59_c-X1kXUqnRbVp9EJGQ2mQwE7JfcycIAkgx-Ajl45_Go2iOddIWmlysvH9fQMNh-mxFNNZ9HguaMg6WJw9h8newA4BZ7wJ2NwpwTJVurPRomJegDFXbJY4gzP_TKI3QMoXcq1QefcyDO1SwX7letntB90f4HEwNm1lhPT8IDgUbj3UsO1g1rU3tBOGfOlbzSpw13_82Q_7h7aoO62_bMrT6fwfCMra41ZcoQlwtvVfXyk_pt2eL7pMwJZU3egUkxNdkhME1rZ-VcnvlACUwtnLzUnTy1T8z3Snepab8l7V7DgGBPCA
Content-Type: text/xml

<?xml version="1.0" encoding="UTF-8" ?>
<OrderGroup  xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<AddressId />
	<AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
	<BillingCurrency />
	<CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
	<CustomerName />
	<HandlingTotal>0</HandlingTotal>
	<InstanceId>00000000-0000-0000-0000-000000000000</InstanceId>
	<Name>default</Name>
	<Owner />
	<OwnerOrg />
	<ProviderId />
	<ShippingTotal>0</ShippingTotal>
	<Status />
	<SubTotal>0</SubTotal>
	<TaxTotal>0</TaxTotal>
	<Total>0</Total>
</OrderGroup>
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 2402
Content-Type: text/xml; charset=utf-8
Expires: -1
Vary: Accept-Encoding
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 13:07:05 GMT

<PurchaseOrder xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <__MetaClass>PurchaseOrder</__MetaClass><CreatorId/><ModifierId/>
    <Created>2016-06-07T13:07:05.7722253Z</Created>
    <Modified>2016-06-07T13:07:05.8018136Z</Modified><AdditionalDiscountPercent/><ExpirationDate/>
    <ParentOrderGroupId>0</ParentOrderGroupId><TrackingNumber/>
    <OrderGroupId>4</OrderGroupId><Owner/><OwnerOrg/><ProviderId/>
    <ShippingTotal>0</ShippingTotal><SiteId/><Status/>
    <SubTotal>0</SubTotal>
    <TaxTotal>0</TaxTotal>
    <Total>0</Total><AddressId/><AffiliateId/>
    <ApplicationId>201490ff-22cc-436a-bc37-750e7393a803</ApplicationId>
    <BillingCurrency>USD</BillingCurrency>
    <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId><CustomerName/>
    <HandlingTotal>0</HandlingTotal>
    <InstanceId>cd64c67b-e600-4dc4-8cda-060013efb251</InstanceId>
    <MarketId>DEFAULT</MarketId><Name/>
    <OrderForms>
        <OrderForm>
            <__MetaClass>OrderFormEx</__MetaClass><CreatorId/><ModifierId/>
            <Created>2016-06-07T13:07:05.7722253Z</Created>
            <Modified>2016-06-07T13:07:05.8018136Z</Modified><Epi_CouponCodes/><RMANumber/>
            <OrderFormId>4</OrderFormId>
            <OrderGroupId>4</OrderGroupId><OrigOrderFormId/><ProviderId/><ReturnAuthCode/><ReturnComment/><ReturnType/>
            <ShippingTotal>0</ShippingTotal><Status/>
            <SubTotal>0</SubTotal>
            <TaxTotal>0</TaxTotal>
            <Total>0</Total>
            <AuthorizedPaymentTotal>0</AuthorizedPaymentTotal><BillingAddressId/>
            <CapturedPaymentTotal>0</CapturedPaymentTotal>
            <DiscountAmount>0</DiscountAmount><ExchangeOrderGroupId/>
            <HandlingTotal>0</HandlingTotal>
            <Name>default</Name><LineItems/>
            <Shipments>
                <Shipment>
                    <__MetaClass>ShipmentEx</__MetaClass><CreatorId/><ModifierId/>
                    <Created>2016-06-07T13:07:05.7722253Z</Created>
                    <Modified>2016-06-07T13:07:05.8018136Z</Modified><PrevStatus/>
                    <ShipmentId>9</ShipmentId>
                    <ShipmentTotal>0</ShipmentTotal><ShipmentTrackingNumber/><ShippingAddressId/>
                    <ShippingDiscountAmount>0</ShippingDiscountAmount>
                    <ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId><ShippingMethodName/><Status/>
                    <SubTotal>0.00</SubTotal><WarehouseCode/>
                    <Epi_ShippingTax>0</Epi_ShippingTax><LineItemIds/><OperationKeys/>
                    <OrderFormId>4</OrderFormId>
                    <OrderGroupId>4</OrderGroupId><PickListId/><Discounts/></Shipment>
            </Shipments><Payments/><Discounts/><Promotions/></OrderForm>
    </OrderForms><OrderAddresses/><OrderNotes/><ReturnOrderForms/></PurchaseOrder>
```

### Put Order (update order)

Request:
```
PUT https://serviceapi.localtest.me/episerverapi/commerce/order/4 HTTP/1.1
Host: serviceapi.localtest.me
Connection: keep-alive
Content-Length: 655
Accept: text/xml
Authorization: Bearer TVAjPbenWwYJ59_c-X1kXUqnRbVp9EJGQ2mQwE7JfcycIAkgx-Ajl45_Go2iOddIWmlysvH9fQMNh-mxFNNZ9HguaMg6WJw9h8newA4BZ7wJ2NwpwTJVurPRomJegDFXbJY4gzP_TKI3QMoXcq1QefcyDO1SwX7letntB90f4HEwNm1lhPT8IDgUbj3UsO1g1rU3tBOGfOlbzSpw13_82Q_7h7aoO62_bMrT6fwfCMra41ZcoQlwtvVfXyk_pt2eL7pMwJZU3egUkxNdkhME1rZ-VcnvlACUwtnLzUnTy1T8z3Snepab8l7V7DgGBPCA
User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36
Content-Type: text/xml

<?xml version="1.0" encoding="UTF-8" ?>
<OrderGroup  xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<AddressId />
	<AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
	<BillingCurrency />
	<CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
	<CustomerName />
	<HandlingTotal>0</HandlingTotal>
	<InstanceId>00000000-0000-0000-0000-000000000000</InstanceId>
	<Name>default</Name>
	<Owner />
	<OwnerOrg />
	<ProviderId />
	<ShippingTotal>0</ShippingTotal>
	<Status>InProgress</Status>
	<SubTotal>0</SubTotal>
	<TaxTotal>0</TaxTotal>
	<Total>0</Total>
</OrderGroup>
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 0
Expires: -1
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 13:20:14 GMT
```

### Delete Order

Request:
```
DELETE https://serviceapi.localtest.me/episerverapi/commerce/order/4 HTTP/1.1
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
Host: serviceapi.localtest.me
Connection: keep-alive
Accept: text/xml
Authorization: Bearer M5yxrX_EOdoelubuivnid3_CqOiOgYjiPC0pCBSQ33YoF-xYHqI8MWkp4XNpR9jgKQsDgd-7LQp42cLCwFLLGt3Sx7VUnqn4fOIgIIJZm_9zlGCcd-8NODWrGYIinnPN2QGTnGSUTvDICRbuaKdfZAHg8sc_EOqK6AxlKkvi8sOOckmh-WrWQDEhRkNbD7J5E0LFNb45a9WELYXEaAY_NSv-k5p312Uvf2F0oDSIpYS7lBd2uFYrjA0s82BerjsmbHiWl-0DQEu7yZTbZDcHobpqUQRvjLN0XhmWfnYmpqQbYrKd_C3ONhuYygidTw6v
```

Response:
```
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Length: 2235
Content-Type: text/xml; charset=utf-8
Expires: -1
Vary: Accept-Encoding
Server: Microsoft-IIS/8.0
X-UA-Compatible: IE=Edge,chrome=1
Date: Tue, 07 Jun 2016 15:01:50 GMT

<ArrayOfContact xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Contact>
        <PrimaryKeyId>f0e41fa1-dd76-4db9-adc1-4585ecc303ac</PrimaryKeyId>
        <Addresses>
            <Address>
                <AddressId>43706922-6c84-419f-ba1f-6ee989b5aa75</AddressId><Modified xsi:nil="true"/>
                <Name>Default</Name>
                <FirstName>Joe</FirstName>
                <LastName>Moore</LastName>
                <CountryName>United States</CountryName>
                <CountryCode>USA</CountryCode>
                <City>Concord</City>
                <PostalCode>l4k 3e7</PostalCode>
                <Line1>201 drumlin circle</Line1>
                <Line2>suite 1</Line2>
                <Region>Armed Forces Canada</Region>
                <Email>support@magicinfosys.com</Email>
                <ShippingDefault>false</ShippingDefault>
                <BillingDefault>false</BillingDefault>
                <DaytimePhoneNumber>905 738 9650</DaytimePhoneNumber>
            </Address>
        </Addresses>
        <FirstName>Joe</FirstName>
        <LastName>Moore</LastName>
        <Email>support@magicinfosys.com</Email>
        <RegistrationSource>Registration page</RegistrationSource>
    </Contact>
</ArrayOfContact>
```
