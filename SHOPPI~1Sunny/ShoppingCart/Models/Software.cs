namespace ShoppingCart.Models
{
    public class Software
    {
        public string softwareId { get; set; }
        public string softwareName { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public string imageUrl { get; set; }

        public Software(string id, string name, string desc, double price, string imageUrl)
        {
            this.softwareId = id;
            this.softwareName = name;
            this.description = desc;
            this.price = price;
            this.imageUrl = imageUrl;
        }
    }
}
