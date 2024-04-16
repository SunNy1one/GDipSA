using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models.EF
{
    public class PurchaseModel
    {
        public string Id { get; set; }

        public PurchaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime dateOfPurchase { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        public virtual ICollection<SoftwarePurchaseModel> softwarePurchases { get; set; }
    }
}
