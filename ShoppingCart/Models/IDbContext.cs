namespace ShoppingCart.Models
{
    public interface IDbContext
    {
        public User? Login(string username, string passhash);
    }
}
