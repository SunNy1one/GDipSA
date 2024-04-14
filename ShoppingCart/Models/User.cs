namespace ShoppingCart.Models
{
    public class User
    {
        public string? userId { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? password { get; set; }
        public User(string userId, string username, string firstName, string lastName) { 
            this.userId = userId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        

    }

    public enum LoginStatus
    {
        Success, Failed
    }
}
