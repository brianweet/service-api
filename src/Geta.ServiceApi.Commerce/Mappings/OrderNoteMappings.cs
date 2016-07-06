using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class OrderNoteMappings
    {
        public static OrderNote ConvertToOrderNote(
            this Models.OrderNote orderNoteDto, OrderNote orderNote)
        {
            orderNote.CustomerId = orderNoteDto.CustomerId;
            orderNote.Detail = orderNoteDto.Detail;
            orderNote.Title = orderNoteDto.Title;
            orderNote.Type = orderNoteDto.Type;
            orderNote.LineItemId = orderNote.LineItemId;

            return orderNote;
        }
    }
}