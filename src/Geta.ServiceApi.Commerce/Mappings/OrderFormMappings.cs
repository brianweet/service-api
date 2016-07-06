using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class OrderFormMappings
    {
        public static OrderForm ConvertToOrderForm(
            this Models.OrderForm orderFormDto, OrderForm orderForm)
        {
            orderForm.ReturnComment = orderFormDto.ReturnComment;
            orderForm.ReturnType = orderFormDto.ReturnType;
            orderForm.ReturnAuthCode = orderFormDto.ReturnAuthCode;
            orderForm.Name = orderFormDto.Name;
            orderForm.BillingAddressId = orderFormDto.BillingAddressId;
            orderForm.ShippingTotal = orderFormDto.ShippingTotal;
            orderForm.HandlingTotal = orderFormDto.HandlingTotal;
            orderForm.TaxTotal = orderFormDto.TaxTotal;
            orderForm.DiscountAmount = orderFormDto.DiscountAmount;
            orderForm.SubTotal = orderFormDto.SubTotal;
            orderForm.Total = orderFormDto.Total;
            orderForm.Status = orderFormDto.Status;
            orderForm.RMANumber = orderFormDto.RmaNumber;
            orderForm.AuthorizedPaymentTotal = orderFormDto.AuthorizedPaymentTotal;
            orderForm.CapturedPaymentTotal = orderFormDto.CapturedPaymentTotal;

            return orderForm;
        }
    }
}