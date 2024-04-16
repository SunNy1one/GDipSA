using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models.EF
{
    public class SoftwarePurchaseModel
    {
        public SoftwarePurchaseModel() 
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [ForeignKey("SoftwareId")]
        public virtual SoftwareModel software { get; set; }
    }
}
