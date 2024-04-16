using ShoppingCart.Models.EF;

namespace ShoppingCart.Models
{
    public class Data
    {
        private readonly MyDbContext mydb;

        public Data(MyDbContext db)
        {
            this.mydb = db;
        }

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

        public void Load()
        {
            // Add Users
            UserModel u1 = new UserModel
            {
                username = "VanVan",
                firstName = "Vani",
                lastName = "B",
                password = "Password123!"
            };
            UserModel u2 = new UserModel
            {
                username = "NamNam",
                firstName = "Poonam",
                lastName = "K",
                password = "Password123!"
            };
            UserModel u3 = new UserModel
            {
                username = "Keke",
                firstName = "Kevin",
                lastName = "O",
                password = "Password123!"
            };
            UserModel u4 = new UserModel
            {
                username = "SunSun",
                firstName = "Jiahao",
                lastName = "S",
                password = "Password123!"
            };
            UserModel u5 = new UserModel
            {
                username = "YanYan",
                firstName = "Nan",
                lastName = "Y",
                password = "Password123!"
            };
            UserModel u6 = new UserModel
            {
                username = "Xixi",
                firstName = "Haoxi",
                lastName = "D",
                password = "Password123!"
            };
            
            mydb.users.Add(u1);
            mydb.users.Add(u2);
            mydb.users.Add(u3);
            mydb.users.Add(u4);
            mydb.users.Add(u5);
            mydb.users.Add(u6);

            // Add Software
            SoftwareModel s1 = new SoftwareModel
            {
                softwareName = "Charts",
                softwareDescription = "Data visual tools",
                price = 59.0,
                imageUrl = "/images/charts.png"
            };
            SoftwareModel s2 = new SoftwareModel
            {
                softwareName = "Paypal",
                softwareDescription = "E-Payment tools",
                price = 29.0,
                imageUrl = "/images/paypal.jpg"
            };
            SoftwareModel s3 = new SoftwareModel
            {
                softwareName = "ML",
                softwareDescription = "Build machine learning models",
                price = 49.0,
                imageUrl = "/images/ml.jpg"
            };
            SoftwareModel s4 = new SoftwareModel
            {
                softwareName = "Analytics",
                softwareDescription = "Data processing",
                price = 40.0,
                imageUrl = "/images/analytics.jpg"
            };
            SoftwareModel s5 = new SoftwareModel
            {
                softwareName = "DataRecorder",
                softwareDescription = "Tools for recording data",
                price = 69.0,
                imageUrl = "/images/recorder.jpg"
            };
            SoftwareModel s6 = new SoftwareModel
            {
                softwareName = "Numerics",
                softwareDescription = "Numerical processing tools",
                price = 99.0,
                imageUrl = "/images/numerics.jpg"
            };
            SoftwareModel s7 = new SoftwareModel
            {
                softwareName = "Recommender",
                softwareDescription = "Show what other softwares users buy when they buy some software",
                price = 79.0,
                imageUrl = "/images/recoomender.jpg"
            };
            SoftwareModel s8 = new SoftwareModel
            {
                softwareName = "Statistics Compiler",
                softwareDescription = "Build statistical models",
                price = 99.0,
                imageUrl = "/images/statcompiler.jpg"
            };
            SoftwareModel s9 = new SoftwareModel
            {
                softwareName = "BizIntel",
                softwareDescription = "Business Intelligence tools",
                price = 90.0,
                imageUrl = "/images/bizintel.jpg"
            };
            SoftwareModel s10 = new SoftwareModel
            {
                softwareName = "Time Series",
                softwareDescription = "Use time series methods for financial products",
                price = 69.0,
                imageUrl = "/images/timeseries.jpg"
            };
            mydb.softwares.Add(s1);
            mydb.softwares.Add(s2);
            mydb.softwares.Add(s3);
            mydb.softwares.Add(s4);
            mydb.softwares.Add(s5);
            mydb.softwares.Add(s6);
            mydb.softwares.Add(s7);
            mydb.softwares.Add(s8);
            mydb.softwares.Add(s9);
            mydb.softwares.Add(s10);

            // Add Purchase
            PurchaseModel p1 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 4, 10),
                User = u2,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s2
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s4
                    },
                }
            };
            PurchaseModel p2 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 3, 20),
                User = u3,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s1
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s1
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s2
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s7
                    },
                }
            };
            PurchaseModel p3 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 4, 6),
                User = u4,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s3
                    }
                }
            };
            PurchaseModel p4 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 3, 30),
                User = u1,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s4
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s7
                    }
                }
            };
            PurchaseModel p5 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 2, 25),
                User = u6,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s6
                    }
                }
            };
            PurchaseModel p6 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 3, 25),
                User = u6,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s5
                    }
                }
            };
            PurchaseModel p7 = new PurchaseModel
            {
                dateOfPurchase = new DateTime(2024, 3, 25),
                User = u3,
                softwarePurchases = new List<SoftwarePurchaseModel>
                {
                    new SoftwarePurchaseModel
                    {
                        software = s7
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s9
                    },
                    new SoftwarePurchaseModel
                    {
                        software = s10
                    }
                }
            };

            mydb.purchases.Add(p1);
            mydb.purchases.Add(p2); 
            mydb.purchases.Add(p3);
            mydb.purchases.Add(p4);
            mydb.purchases.Add(p5);
            mydb.purchases.Add(p6);
            mydb.purchases.Add(p7);

            mydb.SaveChanges();
        }
    }
}
