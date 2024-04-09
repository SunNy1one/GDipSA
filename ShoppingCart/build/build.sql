# CREATE DATABASE ShoppingCart;
use ShoppingCart;

# CREATE TABLE User (UserID VARCHAR(10), Username VARCHAR(30), HashedPass VARCHAR(80), FirstName VARCHAR(50), LastName VARCHAR(50), PRIMARY KEY(UserID));
# DROP Table User;

# CREATE TABLE Software (SoftwareID VARCHAR(10), SoftwareName VARCHAR(50), Descr VARCHAR(200), Price DECIMAL(2), ImageURL VARCHAR(40), PRIMARY KEY(SoftwareID));
# DROP TABLE Software;

# CREATE TABLE Purchase (PurchaseID VARCHAR(10), UserId VARCHAR(10), DateOfPurchase DateTime, PRIMARY KEY (PurchaseID), FOREIGN KEY(UserID) REFERENCES User(UserID));
# DROP Table Purchase;

# CREATE TABLE PurchaseSoftware (PurchaseID VARCHAR(10), SoftwareID VARCHAR(10), ActivationCode VARCHAR(36), PRIMARY KEY(PurchaseID, SoftwareID), FOREIGN KEY(PurchaseID) REFERENCES Purchase(PurchaseID), FOREIGN KEY(SoftwareID) REFERENCES Software(SoftwareID));
# DROP Table PurchaseSoftware;

-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("1", "VanVan", "Vani", "B");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("2", "NamNam", "Poonam", "K");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("3", "Keke", "Kevin", "O");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("4", "SunSun", "Jiahao", "S");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("5", "YanYan", "Nan", "Y");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("6", "Xixi", "Haoxi", "D");
-- SELECT * FROM User;

-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("1", "Charts", "Data visual tools", 99.0, "/images/charts.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("2", "Paypal", "e-Payment tools", 99.0, "/images/paypal.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("3", "ML", "Data processing tool", 99.0, "/images/ml.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("4", "Analytics", "Data analytics processor", 99.0, "/images/analytics.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("5", "Logger", "Data logging tools", 99.0, "/images/logger.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("6", "Numerics", "Numeric tools", 99.0, "/images/numerics.jpg");
-- SELECT * FROM Software;

-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("1", "2", '2024-04-10');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("2", "3", '2024-03-20');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("3", "4", '2024-04-06');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("4", "2", '2024-03-30');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("5", "2", '2024-02-25');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("6", "2", '2024-03-25');
-- SELECT * FROM Purchase;

-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('1', '2', '43397e41-4c8a-4cbc-abb3-72215e6221db');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('2', '1', '82892cb3-f834-431f-af51-b07f35fbb9c7');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('3', '3', 'ab3ea2da-65c5-415d-9e78-ba4bd578364d');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('4', '4', '86942d95-a6b2-485b-9ecc-2eb58becee7a');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('5', '6', '4ce6f0d6-2581-4cdd-b995-15a83357ac1a');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode) VALUES ('6', '5', '38a41ced-4d8d-45c3-97e5-c6cf8c732c45');
-- SELECT * FROM PurchaseSoftware;