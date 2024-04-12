namespace ShoppingCart.Models
{
    public interface IDbContext
    {
        public LoginStatus Login(string username, string passhash);
    }
}
