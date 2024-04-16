namespace ShoppingCart.Models
{
    public interface IDbContext
    {
        public string? Login(string username, string passhash);
    }
}
