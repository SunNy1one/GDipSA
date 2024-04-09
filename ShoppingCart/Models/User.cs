namespace ShoppingCart.Models
{
    public class User
    {
        public string? userId { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public User(string userId, string username, string firstName, string lastName) { 
            this.userId = userId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public static LoginStatus Login(string username, string passhash)
        {
            // TODO
            return LoginStatus.Success;
        }

    }

    public enum LoginStatus
    {
        Success, Failed
    }
}
