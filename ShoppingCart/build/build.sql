# CREATE DATABASE ShoppingCart;
# use ShoppingCart;

# CREATE TABLE User (UserID VARCHAR(10), Username VARCHAR(30), HashedPass VARCHAR(80), FirstName VARCHAR(50), LastName VARCHAR(50), PRIMARY KEY(UserID));
# DROP Table User;

# CREATE TABLE Software (SoftwareID VARCHAR(10), SoftwareName VARCHAR(50), Descr VARCHAR(200), Price DECIMAL(2), ImageURL VARCHAR(40), PRIMARY KEY(SoftwareID));
# DROP TABLE Software;

# CREATE TABLE Purchase (PurchaseID VARCHAR(10), UserId VARCHAR(10), DateOfPurchase DateTime, PRIMARY KEY (PurchaseID), FOREIGN KEY(UserID) REFERENCES User(UserID));
# DROP Table Purchase;

# CREATE TABLE PurchaseSoftware (PurchaseID VARCHAR(10), SoftwareID VARCHAR(10), ActivationCode VARCHAR(36), PurchaseStatus VARCHAR(12), PRIMARY KEY(PurchaseID, SoftwareID, ActivationCode), FOREIGN KEY(PurchaseID) REFERENCES Purchase(PurchaseID), FOREIGN KEY(SoftwareID) REFERENCES Software(SoftwareID));
# DROP Table PurchaseSoftware;
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("1", "VanVan", "Vani", "B");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("2", "NamNam", "Poonam", "K");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("3", "Keke", "Kevin", "O");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("4", "SunSun", "Jiahao", "S");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("5", "YanYan", "Nan", "Y");
-- INSERT INTO User (UserID, Username, FirstName, LastName) VALUES ("6", "Xixi", "Haoxi", "D");

-- SELECT * FROM User;
-- Set sql_safe_updates = 0;
-- UPDATE User set HashedPass = 'Password123!';
-- Set sql_safe_updates = 1;

-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("1", "Charts", "Data visual tools", 59.0, "/images/charts.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("2", "Paypal", "E-Payment tools", 29.0, "/images/paypal.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("3", "ML", "Build machine learning models", 49.0, "/images/ml.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("4", "Analytics", "Data processing ", 40.0, "/images/analytics.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("5", "DataRecorder", "Tools for recording data", 69.0, "/images/recorder.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("6", "Numerics", "Numerical processing tools", 99.0, "/images/numerics.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("7", "Recommender", "Show what other softwares users buy when they buy some software", 79.0, "/images/recoomender.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("8", "Statistics Compiler", "Build statistical models", 99.0, "/images/statcompiler.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("9", "BizIntel", "Business Intelligence tools", 90.0, "/images/bizintel.jpg");
-- INSERT INTO Software (SoftwareID, SoftwareName, Descr, Price, ImageURL) VALUES ("10", "Time Series", "Use time series methods for financial products", 69.0, "/images/timeseries.jpg");
-- SELECT * from Software;

-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("1", "2", '2024-04-10');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("2", "3", '2024-03-20');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("3", "4", '2024-04-06');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("4", "1", '2024-03-30');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("5", "6", '2024-02-25');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("6", "5", '2024-03-25');
-- INSERT INTO Purchase (PurchaseId, UserId, DateOfPurchase) VALUES ("7", "3", '2024-03-25');
-- SELECT * FROM Purchase;

-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('1', '2', '61633e3a-1457-49b1-a281-18b0921617c1', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('1', '4', '6d6ffc20-4b4a-44fa-97c2-a250b4d80d33', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('2', '1', '0b6cd842-493f-4d4c-bc96-a840c30d58b4', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('2', '1', 'i8bc73fe-b1f4-4736-8c4a-e7e3fc53276c', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('2', '2', '68cdb3b0-8d08-4864-9a54-c711aff51dea', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('2', '7', 'f74c3ff9-d743-4165-9800-406bf02404d0', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('3', '3', 'a55f3bfd-2502-4187-b301-ad34d5db72e3', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('4', '4', '86942d95-a6b2-485b-9ecc-2eb58becee7a', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('4', '7', 'a5675379-925d-40ff-a327-268ebb2bf657', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('5', '6', 'be11de79-5c3c-4e77-8a1c-f087838ba12a', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('7', '7', '45e82447-3f05-420c-b94a-94834a4ef242', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('6', '5', 'b2ee51d2-ecf5-4eb6-87a4-067fc744030b', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('7', '9', 'bf278667-4c49-4886-bbd8-dbe36807b37b', 'Completed');
-- INSERT INTO PurchaseSoftware (PurchaseId, SoftwareId, ActivationCode, PurchaseStatus) VALUES ('7', '10', 'c8bc73fe-b1f4-4736-8c4a-e7e3fc53276c', 'Completed');
-- SELECT * FROM PurchaseSoftware;
