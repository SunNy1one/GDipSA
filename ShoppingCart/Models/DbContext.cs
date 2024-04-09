using MySql.Data.MySqlClient;

namespace ShoppingCart.Models
{
    public class DbContext
    {
        MySqlConnection con {  get; set; }
        public DbContext() 
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=Password123!;database=northwind");
        }

        // Purchase Ops

        // User Ops
    }
}
