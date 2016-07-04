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
        <Created>2016-06-10T13:29:34.1270000Z</Created>
        <Modified>2016-06-10T13:29:34.1630000Z</Modified>
        <AdditionalDiscountPercent>0</AdditionalDiscountPercent><ExpirationDate/>
        <ParentOrderGroupId>0</ParentOrderGroupId>
        <TrackingNumber>PO4034942</TrackingNumber>
        <OrderGroupId>4035</OrderGroupId><Owner/><OwnerOrg/><ProviderId/>
        <ShippingTotal>0.000000000</ShippingTotal><SiteId/>
        <Status>InProgress</Status>
        <SubTotal>500.000000000</SubTotal>
        <TaxTotal>0.000000000</TaxTotal>
        <Total>500.000000000</Total><AddressId/>
        <AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
        <ApplicationId>201490ff-22cc-436a-bc37-750e7393a803</ApplicationId>
        <BillingCurrency>USD</BillingCurrency>
        <CustomerId>c5840afe-b159-4fc8-8aab-ea4b475ef49a</CustomerId>
        <CustomerName>sisajusak@sample.com</CustomerName>
        <HandlingTotal>0.000000000</HandlingTotal>
        <InstanceId>9bff9123-8e80-47c6-85ad-e721e9d05376</InstanceId>
        <MarketId>DEFAULT</MarketId>
        <Name>Default</Name>
        <OrderForms>
            <OrderForm>
                <__MetaClass>OrderFormEx</__MetaClass><CreatorId/><ModifierId/>
                <Created>2016-06-10T13:28:58.8570000Z</Created>
                <Modified>2016-06-10T13:29:34.1630000Z</Modified><Epi_CouponCodes/><RMANumber/>
                <OrderFormId>4035</OrderFormId>
                <OrderGroupId>4035</OrderGroupId><OrigOrderFormId/><ProviderId/><ReturnAuthCode/><ReturnComment/><ReturnType/>
                <ShippingTotal>0.000000000</ShippingTotal><Status/>
                <SubTotal>500.000000000</SubTotal>
                <TaxTotal>0.000000000</TaxTotal>
                <Total>500.000000000</Total>
                <AuthorizedPaymentTotal>0.000000000</AuthorizedPaymentTotal>
                <BillingAddressId>b963f88a-9827-410b-a345-d30f8ba91803</BillingAddressId>
                <CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
                <DiscountAmount>0.000000000</DiscountAmount><ExchangeOrderGroupId/>
                <HandlingTotal>0.000000000</HandlingTotal>
                <Name>Default</Name>
                <LineItems>
                    <LineItem>
                        <__MetaClass>LineItemEx</__MetaClass><CreatorId/><ModifierId/>
                        <Created>2016-06-10T13:28:27.9870000Z</Created>
                        <Modified>2016-06-10T13:29:34.1630000Z</Modified>
                        <Epi_FreeQuantity>0</Epi_FreeQuantity>
                        <LineItemId>3022</LineItemId>
                        <LineItemOrdering>6/10/2016 1:28:27 PM</LineItemOrdering>
                        <ListPrice>500.000000000</ListPrice>
                        <MaxQuantity>100.000000000</MaxQuantity>
                        <MinQuantity>1.000000000</MinQuantity>
                        <OrderFormId>4035</OrderFormId>
                        <OrderGroupId>4035</OrderGroupId>
                        <OrderLevelDiscountAmount>0.000000000</OrderLevelDiscountAmount><OrigLineItemId/>
                        <ParentCatalogEntryId>EEI-739</ParentCatalogEntryId>
                        <PlacedPrice>500.000000000</PlacedPrice>
                        <PreorderQuantity>0.000000000</PreorderQuantity><ProviderId/>
                        <Quantity>1.000000000</Quantity>
                        <ReturnQuantity>0.000000000</ReturnQuantity><ReturnReason/><ShippingAddressId/>
                        <ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId><ShippingMethodName/><Status/>
                        <WarehouseCode>default</WarehouseCode>
                        <AllowBackordersAndPreorders>True</AllowBackordersAndPreorders>
                        <BackorderQuantity>0.000000000</BackorderQuantity>
                        <Catalog>LexMod</Catalog>
                        <CatalogEntryId>MOD-5333-BLK-BRN-SET</CatalogEntryId><CatalogNode/><ConfigurationId/>
                        <Description>Broad and luxurious, the Bethany Bedroom Set is an instant centerpiece for any modern bedroom. Complete with a gracefully tapered padded foam headboard and sturdy rubberwood legs, Bethany is a site to behold for both its class and
                            comfort. The Bethany que</Description>
                        <DisplayName>Bethany 2 Piece Queen Bedroom Set in Black Brown</DisplayName>
                        <ExtendedPrice>500.000000000</ExtendedPrice>
                        <InStockQuantity>1.000000000</InStockQuantity>
                        <InventoryStatus>1</InventoryStatus>
                        <IsInventoryAllocated>False</IsInventoryAllocated>
                        <LineItemDiscountAmount>0.000000000</LineItemDiscountAmount><Discounts/></LineItem>
                </LineItems>
                <Shipments>
                    <Shipment>
                        <__MetaClass>ShipmentEx</__MetaClass><CreatorId/><ModifierId/>
                        <Created>2016-06-10T13:29:28.1930000Z</Created>
                        <Modified>2016-06-10T13:29:34.1630000Z</Modified><PrevStatus/>
                        <ShipmentId>4056</ShipmentId>
                        <ShipmentTotal>0.000000000</ShipmentTotal><ShipmentTrackingNumber/>
                        <ShippingAddressId>18352f5d-99f2-4110-94c6-ed305d8c7542</ShippingAddressId>
                        <ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
                        <ShippingMethodId>dade7f46-646b-4a16-9226-4e574c8c79e6</ShippingMethodId>
                        <ShippingMethodName>In Store Pickup</ShippingMethodName><Status/>
                        <SubTotal>500.000000000</SubTotal><WarehouseCode/>
                        <Epi_ShippingTax>0.000000000</Epi_ShippingTax>
                        <LineItemIds>0:1.000000000</LineItemIds><OperationKeys/>
                        <OrderFormId>4035</OrderFormId>
                        <OrderGroupId>4035</OrderGroupId><PickListId/><Discounts/></Shipment>
                </Shipments>
                <Payments>
                    <Payment xsi:type="CreditCardPayment">
                        <__MetaClass>CreditCardPayment</__MetaClass><CreatorId/><ModifierId/>
                        <Created>2016-06-10T13:29:28.3700000Z</Created>
                        <Modified>2016-06-10T13:29:34.1630000Z</Modified>
                        <CardType>Generic</CardType>
                        <CreditCardNumber>4007000000027</CreditCardNumber>
                        <CreditCardSecurityCode>123</CreditCardSecurityCode>
                        <ExpirationMonth>6</ExpirationMonth>
                        <ExpirationYear>2016</ExpirationYear><ProviderPaymentId/><ProviderProfileId/>
                        <PaymentId>3022</PaymentId>
                        <PaymentMethodId>4b6e692f-d6fb-4552-9439-3a39d2251316</PaymentMethodId>
                        <PaymentMethodName>Authorize</PaymentMethodName>
                        <PaymentType>0</PaymentType><ProviderTransactionID/>
                        <Status>Processed</Status><TransactionID/>
                        <TransactionType>Authorization</TransactionType><ValidationCode/>
                        <Amount>500.000000000</Amount><AuthorizationCode/>
                        <BillingAddressId>b963f88a-9827-410b-a345-d30f8ba91803</BillingAddressId>
                        <CustomerName>Marvin Good</CustomerName>
                        <ImplementationClass>Mediachase.Commerce.Orders.CreditCardPayment, Mediachase.Commerce</ImplementationClass>
                        <OrderFormId>4035</OrderFormId>
                        <OrderGroupId>4035</OrderGroupId>
                    </Payment>
                </Payments><Discounts/><Promotions/></OrderForm>
        </OrderForms>
        <OrderAddresses>
            <OrderAddress>
                <__MetaClass>OrderGroupAddressEx</__MetaClass><CreatorId/><ModifierId/>
                <Created>2016-06-10T13:29:28.1800000Z</Created>
                <Modified>2016-06-10T13:29:34.1630000Z</Modified>
                <OrderGroupAddressId>3043</OrderGroupAddressId>
                <OrderGroupId>4035</OrderGroupId><Organization/>
                <PostalCode>99018</PostalCode><RegionCode/>
                <RegionName></RegionName>
                <State></State>
                <City>Sed</City>
                <CountryCode>USA</CountryCode><CountryName/>
                <DaytimePhoneNumber>+999-16-9931814</DaytimePhoneNumber>
                <Email>sisajusak@sample.com</Email><EveningPhoneNumber/><FaxNumber/>
                <FirstName>Marvin</FirstName>
                <LastName>Good</LastName>
                <Line1>Consectetur</Line1><Line2/>
                <Name>18352f5d-99f2-4110-94c6-ed305d8c7542</Name>
            </OrderAddress>
        </OrderAddresses><OrderNotes/><ReturnOrderForms/></PurchaseOrder>
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
