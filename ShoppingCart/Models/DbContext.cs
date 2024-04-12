using MySql.Data.MySqlClient;

namespace ShoppingCart.Models
{
    public class DbContext : IDbContext
    {
        MySqlConnection con {  get; set; }
        public DbContext() 
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=Password123!;database=shoppingcart");
        }
        // Auth Ops
        public LoginStatus Login(string username, string passhash)
        {
            try
            {
                con.Open();
                string sql = @"SELECT UserID FROM User WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string userId = (string)reader["UserId"];
                    reader.Close();
                    sql = @"SELECT 1 From User WHERE UserID = @userId and HashedPass = @passhash";
                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("userId", userId));
                    cmd.Parameters.Add(new MySqlParameter("passhash", passhash));
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    if(reader2.Read())
                    {
                        return LoginStatus.Success;
                    } else
                    {
                        return LoginStatus.Failed;
                    }
                } else
                {
                    return LoginStatus.Failed;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return LoginStatus.Failed;
            }
            finally
            {
                con.Close();
            }
        }

        // Purchase Ops

        // User Ops
    }
}
