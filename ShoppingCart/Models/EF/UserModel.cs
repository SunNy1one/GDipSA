using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models.EF
{
    public class UserModel
    {
        public UserModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        
        [Required]
        public string username { get; set; }
        public string firstName {  get; set; }
        public string lastName { get; set; }
        [Required]
        public string? password { get; set; }

        public virtual ICollection<PurchaseModel> pastPurchases { get; set; }

    }
}
