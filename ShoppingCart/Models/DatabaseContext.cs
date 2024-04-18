using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace ShoppingCart.Models
{
    public class DatabaseContext : IDbContext
    {
        MySqlConnection con {  get; set; }
        public DatabaseContext() 
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=Password123!;database=shoppingcart");
        }
        // Auth Ops
        public User? Login(string username, string passhash)
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
                    sql = @"SELECT * From User WHERE UserID = @userId and HashedPass = @passhash";
                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.Add(new MySqlParameter("userId", userId));
                    cmd.Parameters.Add(new MySqlParameter("passhash", passhash));
                    reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        return new User((string)reader["UserID"], (string)reader["Username"], (string)reader["FirstName"], (string)reader["LastName"]);
                    } else
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        // Purchase Ops
        public List<Software> Search(string searchEntry)
        {
            List<Software> result = new List<Software>();
            try
            {
                con.Open();
                string sql = @"SELECT * FROM Software WHERE SoftwareName like '%" + searchEntry+"%' or Descr like '%" + searchEntry + "%'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    Software soft = new Software((string)reader["SoftwareId"], (string)reader["SoftwareName"], (string)reader["Descr"], Double.Parse(((decimal)reader["price"]).ToString()), (string)reader["ImageURL"]) ;
                    result.Add(soft);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public List<Software> GetAllSoftware()
        {
            return Search("");
        }

        // User Ops

        public List<Purchase> GetPastPurchase(string username)
        {
            List<Purchase> purchases = new List<Purchase>();
            List<Purchase.PurchaseUnit> units = new List<Purchase.PurchaseUnit>();
            try
            {
                con.Open();
                string sql = @"SELECT PurchaseId, DateOfPurchase FROM Purchase WHERE UserId = (Select UserId FROM User WHERE Username = @username)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Purchase purchase = new Purchase((string)reader["PurchaseId"], username, (DateTime)reader["DateOfPurchase"], new List<Purchase.PurchaseUnit>());
                    purchases.Add(purchase);
                }
                reader.Close();
                MySqlCommand cmdpu;
                MySqlDataReader readerpu;
                foreach (Purchase purchase in purchases)
                {
                    string sqlpu = @"SELECT s.SoftwareId, s.SoftwareName, s.Price, s.ImageURL, s.Descr, ps.ActivationCode FROM PurchaseSoftware ps inner join Software s on ps.SoftwareId = s.SoftwareId where ps.PurchaseId = @purchaseid";
                    cmdpu = new MySqlCommand(sqlpu, con);
                    cmdpu.Parameters.Add(new MySqlParameter("purchaseid", purchase.purchaseId));
                    readerpu = cmdpu.ExecuteReader();
                    while(readerpu.Read())
                    {
                        Purchase.PurchaseUnit unit = new Purchase.PurchaseUnit(purchase.purchaseId, (string)readerpu["SoftwareId"], (string)readerpu["ActivationCode"]);
                        purchase.purchaseUnits.Add(unit);
                    }
                    readerpu.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return purchases;
        }

        public List<PurchaseDTO> GetPastPurchase2(string username)
        {
            List<PurchaseDTO> purchases = new List<PurchaseDTO>();

            try
            {
                con.Open();
                string sql = @"select * from purchasesoftware a 
join software b on a.softwareid=b.softwareid 
join purchase c on c.purchaseid=a.purchaseid
where c.userId = (Select UserId FROM User where username = @username)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    PurchaseDTO tem = purchases.Where(p => p.softwareid == (string)reader["softwareid"]).FirstOrDefault();

                    if (tem != null)
                    {
                        tem.activationcodeList.Add((string)reader["activationcode"]);
                        tem.lastdateOfPurchase = Convert.ToDateTime(reader["dateofpurchase"]);
                    }
                    else
                    {
                        tem = new PurchaseDTO();
                        tem.softwareid = (string)reader["softwareid"];
                        tem.software = new Software((string)reader["softwareid"], (string)reader["softwarename"], (string)reader["descr"], Convert.ToDouble(reader["price"]), (string)reader["imageurl"]);
                        tem.activationcodeList.Add((string)reader["activationcode"]);
                        tem.lastdateOfPurchase = Convert.ToDateTime(reader["dateofpurchase"]);
                        purchases.Add(tem);
                    }
                }
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return purchases;
        }

        public List<Software> GetSoftwares(List<string> softwareStrings)
        {
            List<Software> softwares = new List<Software>();
            string ss = "";
            foreach (string s in softwareStrings)
            {
                ss = ss + ",'" + s + "'";
            }
            if(softwareStrings.Count > 0)
            {
                ss = ss.Substring(1);
            }
            
            try
            {
                con.Open();
                string sql = @"select * from software where softwareId in ("+ss+")";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    softwares.Add(new Software((string)reader["softwareId"], (string)reader["SoftwareName"], (string)reader["descr"], Double.Parse(((decimal)reader["price"]).ToString()), (string)reader["ImageUrl"]));
                }
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return softwares;
        }
    }


}
