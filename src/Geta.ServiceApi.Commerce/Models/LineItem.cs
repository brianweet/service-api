namespace Geta.ServiceApi.Commerce.Models
{
    /// <summary>
    ///     Represents a line item in the system, the actual item that is bought.
    /// </summary>
    public class LineItem
    {
        /// <summary>Gets the identity of the line item.</summary>
        public int LineItemId { get; set; }

        /// <summary>
        /// Gets the code of the variation content the line item represent. This property works as the connection between the line item and the variation content.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets the price for one item that this line item represent. This property don't take any discounts in consideration.
        /// </summary>
        public decimal PlacedPrice { get; set; }

        /// <summary>
        /// Gets or sets the number of items this line item contains
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount amount set for this specific line item. This property are normally set by the promotion system.
        /// </summary>
        public decimal LineItemDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the discount amount not specifically set for this line item. This property will contain the total order level discount for the whole order divided by the number of line items the order contains.
        /// </summary>
        /// <value>The order level discount amount.</value>
        public decimal OrderLevelDiscountAmount { get; set; }
    }
}