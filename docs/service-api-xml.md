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

<ArrayOfPurchaseOrder xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<PurchaseOrder>
		<AddressId />
		<AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
		<BillingCurrency>USD</BillingCurrency>
		<CustomerId>1b240e62-8c0d-4c79-9f16-692f226c231c</CustomerId>
		<CustomerName>Mira</CustomerName>
		<HandlingTotal>0.000000000</HandlingTotal>
		<InstanceId>394bdc56-f838-4e3a-8c8e-3115d8ab6830</InstanceId>
		<MarketId />
		<Name>Default</Name>
		<OrderAddresses>
			<OrderAddress>
				<OrderGroupAddressId>0</OrderGroupAddressId>
				<Name>f457bada-57b4-4654-ad5c-1fad82f15beb</Name>
				<FirstName>Mira</FirstName>
				<LastName>Neal</LastName>
				<Organization />
				<Line1>Est ea et sint qui et</Line1>
				<Line2 />
				<City>Et tempora</City>
				<State>Indiana</State>
				<CountryCode>TUR</CountryCode>
				<CountryName>Turkey</CountryName>
				<PostalCode>85953</PostalCode>
				<RegionCode />
				<RegionName>Indiana</RegionName>
				<DaytimePhoneNumber />
				<EveningPhoneNumber />
				<FaxNumber />
				<Email>meziqydijo@yahoo.com</Email>
			</OrderAddress>
			<OrderAddress>
				<OrderGroupAddressId>0</OrderGroupAddressId>
				<Name>362519fa-cbe0-42f2-8fd3-0dd1a28ed86b</Name>
				<FirstName>Mira</FirstName>
				<LastName>Neal</LastName>
				<Organization />
				<Line1>Est ea et sint qui et</Line1>
				<Line2 />
				<City>Et tempora</City>
				<State>Indiana</State>
				<CountryCode>TUR</CountryCode>
				<CountryName>Turkey</CountryName>
				<PostalCode>85953</PostalCode>
				<RegionCode />
				<RegionName>Indiana</RegionName>
				<DaytimePhoneNumber />
				<EveningPhoneNumber />
				<FaxNumber />
				<Email>meziqydijo@yahoo.com</Email>
			</OrderAddress>
		</OrderAddresses>
		<OrderForms>
			<OrderForm>
				<Shipments>
					<Shipment>
						<Discounts />
						<ShipmentId>11</ShipmentId>
						<ShippingMethodId>1e4c1a0f-d6b9-448a-95fd-3ab0b9c53951</ShippingMethodId>
						<ShippingMethodName>Regular USD (4-7 days)(en)</ShippingMethodName>
						<ShippingTax>0.000000000</ShippingTax>
						<ShippingAddressId>362519fa-cbe0-42f2-8fd3-0dd1a28ed86b</ShippingAddressId>
						<ShipmentTrackingNumber />
						<ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
						<ShippingSubTotal>5.000000000</ShippingSubTotal>
						<ShippingTotal>5.000000000</ShippingTotal>
						<Status />
						<PrevStatus />
						<PickListId xsi:nil="true" />
						<SubTotal>22.870000000</SubTotal>
						<WarehouseCode />
						<LineItems>
							<LineItem>
								<LineItemId>2</LineItemId>
								<Code>SKU-39813617</Code>
								<PlacedPrice>30.500000000</PlacedPrice>
								<Quantity>1.000000000</Quantity>
								<LineItemDiscountAmount>7.63</LineItemDiscountAmount>
								<OrderLevelDiscountAmount>0.000000000</OrderLevelDiscountAmount>
							</LineItem>
						</LineItems>
					</Shipment>
				</Shipments>
				<LineItems>
					<LineItem>
						<LineItemId>2</LineItemId>
						<Code>SKU-39813617</Code>
						<PlacedPrice>30.500000000</PlacedPrice>
						<Quantity>1.000000000</Quantity>
						<LineItemDiscountAmount>7.63</LineItemDiscountAmount>
						<OrderLevelDiscountAmount>0.000000000</OrderLevelDiscountAmount>
					</LineItem>
				</LineItems>
				<Discounts />
				<ReturnComment />
				<ReturnType />
				<ReturnAuthCode />
				<OrderFormId>2</OrderFormId>
				<Name>Default</Name>
				<BillingAddressId>f457bada-57b4-4654-ad5c-1fad82f15beb</BillingAddressId>
				<ShippingTotal>5.000000000</ShippingTotal>
				<HandlingTotal>0.000000000</HandlingTotal>
				<TaxTotal>0.000000000</TaxTotal>
				<DiscountAmount>7.630000000</DiscountAmount>
				<SubTotal>22.870000000</SubTotal>
				<Total>27.870000000</Total>
				<Status />
				<RmaNumber />
				<AuthorizedPaymentTotal>27.870000000</AuthorizedPaymentTotal>
				<CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
			</OrderForm>
		</OrderForms>
		<OrderGroupId>2</OrderGroupId>
    <OrderNotes>
      <OrderNote>
        <OrderNoteId xsi:nil="true" />
        <Created>0001-01-01T00:00:00</Created>
        <CustomerId>00000000-0000-0000-0000-000000000000</CustomerId>
        <Detail>There are some details.</Detail>
        <Title>The note</Title>
        <LineItemId xsi:nil="true" />
      </OrderNote>
    </OrderNotes>
		<Owner />
		<OwnerOrg />
		<ProviderId>frontend</ProviderId>
		<ShippingTotal>5.000000000</ShippingTotal>
		<Status>InProgress</Status>
		<SubTotal>22.870000000</SubTotal>
		<TaxTotal>0.000000000</TaxTotal>
		<Total>27.870000000</Total>
		<Modified>2016-05-25T08:11:15.263Z</Modified>
		<Created>2016-05-25T08:11:15.19Z</Created>
	</PurchaseOrder>
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
	<AddressId />
	<AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
	<BillingCurrency>USD</BillingCurrency>
	<CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
	<CustomerName />
	<HandlingTotal>0.000000000</HandlingTotal>
	<InstanceId>fb3665e0-2ab7-4c6f-b723-38f7c9fa995e</InstanceId>
	<MarketId />
	<Name />
	<OrderAddresses />
	<OrderForms>
		<OrderForm>
			<Shipments>
				<Shipment>
					<Discounts />
					<ShipmentId>2120</ShipmentId>
					<ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId>
					<ShippingMethodName />
					<ShippingTax>0.000000000</ShippingTax>
					<ShippingAddressId />
					<ShipmentTrackingNumber />
					<ShippingDiscountAmount>0.000000000</ShippingDiscountAmount>
					<ShippingSubTotal>0.000000000</ShippingSubTotal>
					<ShippingTotal>0.000000000</ShippingTotal>
					<Status />
					<PrevStatus />
					<PickListId xsi:nil="true" />
					<SubTotal>0.000000000</SubTotal>
					<WarehouseCode />
					<LineItems />
				</Shipment>
			</Shipments>
			<LineItems />
			<Discounts />
			<ReturnComment />
			<ReturnType />
			<ReturnAuthCode />
			<OrderFormId>2117</OrderFormId>
			<Name>Default</Name>
			<BillingAddressId />
			<ShippingTotal>0.000000000</ShippingTotal>
			<HandlingTotal>0.000000000</HandlingTotal>
			<TaxTotal>0.000000000</TaxTotal>
			<DiscountAmount>0.000000000</DiscountAmount>
			<SubTotal>0.000000000</SubTotal>
			<Total>0.000000000</Total>
			<Status />
			<RmaNumber />
			<AuthorizedPaymentTotal>0.000000000</AuthorizedPaymentTotal>
			<CapturedPaymentTotal>0.000000000</CapturedPaymentTotal>
		</OrderForm>
	</OrderForms>
	<OrderGroupId>2111</OrderGroupId>
  <OrderNotes>
    <OrderNote>
      <OrderNoteId xsi:nil="true" />
      <Created>0001-01-01T00:00:00</Created>
      <CustomerId>00000000-0000-0000-0000-000000000000</CustomerId>
      <Detail>There are some details.</Detail>
      <Title>The note</Title>
      <LineItemId xsi:nil="true" />
    </OrderNote>
  </OrderNotes>
	<Owner />
	<OwnerOrg />
	<ProviderId />
	<ShippingTotal>0.000000000</ShippingTotal>
	<Status />
	<SubTotal>0.000000000</SubTotal>
	<TaxTotal>0.000000000</TaxTotal>
	<Total>0.000000000</Total>
	<Modified>2016-07-06T15:16:33.813Z</Modified>
	<Created>2016-07-06T15:16:33.773Z</Created>
</PurchaseOrder>
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

<?xml version="1.0" encoding="utf-16"?>
<OrderGroup xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
  <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
  <HandlingTotal>0</HandlingTotal>
  <InstanceId>00000000-0000-0000-0000-000000000000</InstanceId>
  <MarketId />
  <Name>default</Name>
  <OrderAddresses>
    <OrderAddress>
      <OrderGroupAddressId>0</OrderGroupAddressId>
      <Name>f457bada-57b4-4654-ad5c-1fad82f15beb</Name>
      <FirstName>Mira</FirstName>
      <LastName>Neal</LastName>
      <Organization />
      <Line1>Est ea et sint qui et</Line1>
      <Line2 />
      <City>Et tempora</City>
      <State>Indiana</State>
      <CountryCode>TUR</CountryCode>
      <CountryName>Turkey</CountryName>
      <PostalCode>85953</PostalCode>
      <RegionCode />
      <RegionName>Indiana</RegionName>
      <DaytimePhoneNumber />
      <EveningPhoneNumber />
      <FaxNumber />
      <Email>meziqydijo@yahoo.com</Email>
    </OrderAddress>
  </OrderAddresses>
  <OrderForms>
		<OrderForm>
			<ReturnComment />
			<ReturnType />
			<ReturnAuthCode />
			<OrderFormId>2118</OrderFormId>
			<Name>Default</Name>
			<BillingAddressId />
			<ShippingTotal>0</ShippingTotal>
			<HandlingTotal>0</HandlingTotal>
			<TaxTotal>0</TaxTotal>
			<DiscountAmount>0</DiscountAmount>
			<SubTotal>0</SubTotal>
			<Total>0</Total>
			<Status />
			<RmaNumber />
			<AuthorizedPaymentTotal>0</AuthorizedPaymentTotal>
			<CapturedPaymentTotal>0</CapturedPaymentTotal>
		</OrderForm>
	</OrderForms>
  <OrderGroupId>0</OrderGroupId>
  <OrderNotes>
    <OrderNote>
      <OrderNoteId xsi:nil="true" />
      <Created>0001-01-01T00:00:00</Created>
      <CustomerId>00000000-0000-0000-0000-000000000000</CustomerId>
      <Detail>There are some details.</Detail>
      <Title>The note</Title>
      <LineItemId xsi:nil="true" />
    </OrderNote>
  </OrderNotes>
  <ShippingTotal>0</ShippingTotal>
  <SubTotal>0</SubTotal>
  <TaxTotal>0</TaxTotal>
  <Total>0</Total>
  <Modified>0001-01-01T00:00:00</Modified>
  <Created>0001-01-01T00:00:00</Created>
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
	<AddressId />
	<AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
	<BillingCurrency>USD</BillingCurrency>
	<CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
	<CustomerName />
	<HandlingTotal>0.0</HandlingTotal>
	<InstanceId>316cc65c-820a-405c-bab4-2bd93c0e220a</InstanceId>
	<MarketId />
	<Name />
  <OrderAddresses>
    <OrderAddress>
      <OrderGroupAddressId>0</OrderGroupAddressId>
      <Name>f457bada-57b4-4654-ad5c-1fad82f15beb</Name>
      <FirstName>Mira</FirstName>
      <LastName>Neal</LastName>
      <Organization />
      <Line1>Est ea et sint qui et</Line1>
      <Line2 />
      <City>Et tempora</City>
      <State>Indiana</State>
      <CountryCode>TUR</CountryCode>
      <CountryName>Turkey</CountryName>
      <PostalCode>85953</PostalCode>
      <RegionCode />
      <RegionName>Indiana</RegionName>
      <DaytimePhoneNumber />
      <EveningPhoneNumber />
      <FaxNumber />
      <Email>meziqydijo@yahoo.com</Email>
    </OrderAddress>
  </OrderAddresses>
	<OrderForms>
		<OrderForm>
			<Shipments>
				<Shipment>
					<Discounts />
					<ShipmentId>2121</ShipmentId>
					<ShippingMethodId>00000000-0000-0000-0000-000000000000</ShippingMethodId>
					<ShippingMethodName />
					<ShippingTax>0</ShippingTax>
					<ShippingAddressId />
					<ShipmentTrackingNumber />
					<ShippingDiscountAmount>0</ShippingDiscountAmount>
					<ShippingSubTotal>0</ShippingSubTotal>
					<ShippingTotal>0</ShippingTotal>
					<Status />
					<PrevStatus />
					<PickListId xsi:nil="true" />
					<SubTotal>0.00</SubTotal>
					<WarehouseCode />
					<LineItems />
				</Shipment>
			</Shipments>
			<LineItems />
			<Discounts />
			<ReturnComment />
			<ReturnType />
			<ReturnAuthCode />
			<OrderFormId>2118</OrderFormId>
			<Name>Default</Name>
			<BillingAddressId />
			<ShippingTotal>0</ShippingTotal>
			<HandlingTotal>0</HandlingTotal>
			<TaxTotal>0</TaxTotal>
			<DiscountAmount>0</DiscountAmount>
			<SubTotal>0</SubTotal>
			<Total>0</Total>
			<Status />
			<RmaNumber />
			<AuthorizedPaymentTotal>0</AuthorizedPaymentTotal>
			<CapturedPaymentTotal>0</CapturedPaymentTotal>
		</OrderForm>
	</OrderForms>
	<OrderGroupId>2112</OrderGroupId>
  <OrderNotes>
    <OrderNote>
      <OrderNoteId xsi:nil="true" />
      <Created>0001-01-01T00:00:00</Created>
      <CustomerId>00000000-0000-0000-0000-000000000000</CustomerId>
      <Detail>There are some details.</Detail>
      <Title>The note</Title>
      <LineItemId xsi:nil="true" />
    </OrderNote>
  </OrderNotes>
	<Owner />
	<OwnerOrg />
	<ProviderId />
	<ShippingTotal>0</ShippingTotal>
	<Status />
	<SubTotal>0</SubTotal>
	<TaxTotal>0</TaxTotal>
	<Total>0</Total>
	<Modified>2016-07-06T15:19:12.099191Z</Modified>
	<Created>2016-07-06T15:19:12.0685319Z</Created>
</PurchaseOrder>
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

<?xml version="1.0" encoding="utf-16"?>
<OrderGroup xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <AffiliateId>00000000-0000-0000-0000-000000000000</AffiliateId>
  <CustomerId>2a40754d-86d5-460b-a5a4-32bc87703567</CustomerId>
  <HandlingTotal>0</HandlingTotal>
  <InstanceId>00000000-0000-0000-0000-000000000000</InstanceId>
  <MarketId />
  <Name>default</Name>
  <OrderAddresses>
    <OrderAddress>
      <OrderGroupAddressId>0</OrderGroupAddressId>
      <Name>f457bada-57b4-4654-ad5c-1fad82f15beb</Name>
      <FirstName>Mira</FirstName>
      <LastName>Neal</LastName>
      <Organization />
      <Line1>Est ea et sint qui et</Line1>
      <Line2 />
      <City>Et tempora</City>
      <State>Indiana</State>
      <CountryCode>TUR</CountryCode>
      <CountryName>Turkey</CountryName>
      <PostalCode>85953</PostalCode>
      <RegionCode />
      <RegionName>Indiana</RegionName>
      <DaytimePhoneNumber />
      <EveningPhoneNumber />
      <FaxNumber />
      <Email>meziqydijo@yahoo.com</Email>
    </OrderAddress>
  </OrderAddresses>
  <OrderForms>
		<OrderForm>
			<ReturnComment />
			<ReturnType />
			<ReturnAuthCode />
			<OrderFormId>2118</OrderFormId>
			<Name>Default</Name>
			<BillingAddressId />
			<ShippingTotal>0</ShippingTotal>
			<HandlingTotal>0</HandlingTotal>
			<TaxTotal>0</TaxTotal>
			<DiscountAmount>0</DiscountAmount>
			<SubTotal>0</SubTotal>
			<Total>0</Total>
			<Status />
			<RmaNumber />
			<AuthorizedPaymentTotal>0</AuthorizedPaymentTotal>
			<CapturedPaymentTotal>0</CapturedPaymentTotal>
		</OrderForm>
	</OrderForms>
  <OrderGroupId>0</OrderGroupId>
  <OrderNotes>
    <OrderNote>
      <OrderNoteId xsi:nil="true" />
      <Created>0001-01-01T00:00:00</Created>
      <CustomerId>00000000-0000-0000-0000-000000000000</CustomerId>
      <Detail>There are some details.</Detail>
      <Title>The note</Title>
      <LineItemId xsi:nil="true" />
    </OrderNote>
  </OrderNotes>
  <ShippingTotal>0</ShippingTotal>
  <SubTotal>0</SubTotal>
  <TaxTotal>0</TaxTotal>
  <Total>0</Total>
  <Modified>0001-01-01T00:00:00</Modified>
  <Created>0001-01-01T00:00:00</Created>
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
