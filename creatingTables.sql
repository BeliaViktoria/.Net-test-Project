CREATE TABLE Users
(
	UserID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Login VARCHAR(20) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	DateOfBirth DATE CHECK(DateOfBirth IS NULL OR DateOfBirth <= GETDATE()),
	Gender VARCHAR(1) CHECK(Gender IN ('M', 'F'))
)

CREATE TABLE Orders 
(
	OrderID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID) 
		ON DELETE NO ACTION 
		ON UPDATE CASCADE,
	OrderDate DATETIME NOT NULL DEFAULT GETDATE() CHECK(OrderDate <= GETDATE()),
	OrderCost MONEY NOT NULL,
	ItemsDescription VARCHAR(1000),
	ShippingAddress VARCHAR(1000) NOT NULL
);