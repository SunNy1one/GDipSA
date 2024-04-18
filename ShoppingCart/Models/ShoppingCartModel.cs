namespace ShoppingCart.Models
{
    public class ShoppingcartModel
    {
        public string ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

        public string ImagePath { get; set; }
        public string ItemName { get; set; }

        public ShoppingcartModel(string itemId, decimal quantity, decimal unitPrice, decimal total, string imagePath, string itemName)
        {
            this.ItemId = itemId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Total = total;
            this.ImagePath = imagePath;
            this.ItemName = itemName;
        }
    }
}