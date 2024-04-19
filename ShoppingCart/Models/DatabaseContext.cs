using MySql.Data.MySqlClient;
using MySql.Data;
using System.Reflection.PortableExecutable;


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
inner join software b on a.softwareid=b.softwareid 
inner join purchase c on c.purchaseid=a.purchaseid
where c.userId = (Select UserId FROM User where username = @username)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    PurchaseDTO? tem = purchases.FirstOrDefault(p => p.softwareid == (string)reader["softwareid"] && p.lastdateOfPurchase == Convert.ToDateTime(reader["dateofpurchase"]), null);

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
                string sql = @"select * from software where softwareId in (" + ss + ")";
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

        public bool Checkout(PurchaseCart pc)
        {
            int totalInserted = 0;
            int result = 0;
            try
            {
                con.Open();
                keepConnection = true;
                string nextPurchaseId = GetNextPurchaseId();
                string userId = GetUserIdFromUsername(pc.username!);
                string sqlInsertPurchase = @"INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ('"+nextPurchaseId+"', '"+userId+"', '"+GetTodayString()+"')";
                MySqlCommand cmd = new MySqlCommand(sqlInsertPurchase, con);
                result += cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    foreach (var soft in pc.softwareList)
                    {
                        string actCode = Guid.NewGuid().ToString();
                        string sqlInsertPurchaseSoftware = @"INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('"+nextPurchaseId+"', '"+ soft.softwareId + "', '"+actCode+"', 'Completed')";
                        MySqlCommand cmdPurchaseSoftware = new MySqlCommand(sqlInsertPurchaseSoftware, con);
                        totalInserted += cmdPurchaseSoftware.ExecuteNonQuery();
                    }
                } else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                keepConnection = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                keepConnection = false;
                con.Close();
            }
            return result == 1 && totalInserted == pc.softwareList.Count;
        }

        private bool keepConnection = false;

        public string GetNextPurchaseId()
        {
            string nextPurchaseId = "";
            try
            {
                EnsureConIsOpen();
                string sql = @"select Count(*) as Total from purchase";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                nextPurchaseId = (Convert.ToInt64(cmd.ExecuteScalar()) + 1).ToString();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (!keepConnection)
                {
                    con.Close();
                }
            }
            return nextPurchaseId;
        }

        public string GetUserIdFromUsername(string username)
        {
            string userId = "";
            try
            {
                EnsureConIsOpen();
                string sql = @"select UserId from User where username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("username", username));
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    userId = (string)reader["UserId"];
                }
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (!keepConnection)
                {
                    con.Close();
                }
            }
            return userId;
        }

        public string GetTodayString()
        {
            DateTime today = DateTime.Today;
            string dayString = today.Day.ToString();
            string monthString = today.Month.ToString();
            string yearString = today.Year.ToString();
            if(dayString.Length == 1) {
                dayString = "0" + dayString;
            }
            if(monthString.Length == 1)
            {
                monthString = "0" + monthString;
            }
            return yearString + "-" + monthString + "-" + dayString;
        }

        private void EnsureConIsOpen()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                return;
            }
            con.Open();
        }
    }


}
