namespace ShoppingCart.Models.EF
{
    public class SoftwareModel
    {
        public SoftwareModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string softwareName {  get; set; }
        public string softwareDescription { get; set; }
        public double price { get; set; }
        public string imageUrl {  get; set; }
    }
}
