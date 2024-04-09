namespace ShoppingCart.Models
{
    public class Data
    {
        public List<User> users = new List<User>()
        {
            new User("1", "VanVan", "Vani", "B"),
            new User("2", "NamNam", "Poonam", "K"),
            new User("3", "Keke", "Kevin", "O"),
            new User("4", "SunSun", "Jiahao", "S"),
            new User("5", "YanYan", "Nan", "Y"),
            new User("6", "Xixi", "Haoxi", "D")
        };

        public List<Software> softwares = new List<Software>()
        {
            new Software("1", "Charts", "Data visual tools", 99.0, "/images/charts.jpg"),
            new Software("2", "Paypal", "e-Payment tools", 99.0, "/images/paypal.jpg"),
            new Software("3", "ML", "Data processing tool", 99.0, "/images/ml.jpg"),
            new Software("4", "Analytics", "Data analytics processor", 99.0, "/images/analytics.jpg"),
            new Software("5", "Logger", "Data logging tools", 99.0, "/images/logger.jpg"),
            new Software("6", "Numerics", "Numeric tools", 99.0, "/images/numerics.jpg")
        };

        public List<Purchase> purchases = new List<Purchase>()
        {
            new Purchase("1", "2", new DateTime(2024, 4, 10), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("1", "2", Guid.NewGuid().ToString())
            }),
            new Purchase("2", "3", new DateTime(2024, 3, 20), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("2", "1", Guid.NewGuid().ToString())
            }),
            new Purchase("3", "4", new DateTime(2024, 4, 6), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("3", "3", Guid.NewGuid().ToString())
            }),
            new Purchase("4", "2", new DateTime(2024, 3, 30), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("4", "4", Guid.NewGuid().ToString())
            }),
            new Purchase("5", "2", new DateTime(2024, 2, 25), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("5", "6", Guid.NewGuid().ToString())
            }),
            new Purchase("6", "2", new DateTime(2024, 3, 25), new List<Purchase.PurchaseUnit>{
                new Purchase.PurchaseUnit("6", "5", Guid.NewGuid().ToString())
            }),
        };
    }
}
