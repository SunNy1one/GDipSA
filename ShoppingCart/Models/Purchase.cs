namespace ShoppingCart.Models
{
    public class PurchaseCart
    {
        public string? userId { get; set; }

        public List<string> inCartSoftware = new List<string>();

    }
    public class Purchase
    {
        public string purchaseId { get; set; }

        public List<PurchaseUnit> purchaseUnits = new List<PurchaseUnit>();
        public string userId { get; set; }
        public DateTime dateOfPurchase {  get; set; }

        public PurchaseStatus status { get; set; } = PurchaseStatus.Pending;

        public Purchase(string id, string userId, DateTime dateOfPurchase, List<PurchaseUnit> units)
        {
            this.purchaseId = id;
            this.userId = userId;
            this.dateOfPurchase = dateOfPurchase;
            this.purchaseUnits = units;
        }

        public void CompletePurchase()
        {
            status = PurchaseStatus.Completed;
        }

        public string buildActivationCode() { 
            return Guid.NewGuid().ToString();
        }

        public class PurchaseUnit
        {
            public string purchaseId { get; set; }
            public Software software { get; set; }
            public string activationCode { get; set; }

            public PurchaseUnit(string purchaseId, Software software, string activationCode) 
            {
                this.purchaseId = purchaseId;
                this.software = software;
                this.activationCode = activationCode;
            } 
        }
    }

    public enum PurchaseStatus
    {
        Pending, Canceled, Completed
    }
}
