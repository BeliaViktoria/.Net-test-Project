INSERT INTO Users (Login, Password, FirstName, LastName, DateOfBirth, Gender)
VALUES 
  ('johndoe', 'password123', 'John', 'Doe', '1980-01-01', 'M'),
  ('janedoe', 'letmein321', 'Jane', 'Doe', '1985-05-20', 'F'),
  ('bobsmith', 'abc123', 'Bob', 'Smith', NULL, 'M'),
  ('sarahlee', 'test456', 'Sarah', 'Lee', '1992-12-10', 'F'),
  ('davidkim', 'qwerty789', 'David', 'Kim', '1975-08-15', 'M');

INSERT INTO Orders (UserID, OrderDate, OrderCost, ItemsDescription, ShippingAddress)
VALUES 
  (1, '2022-05-01 10:30:00', 100.00, 'Product 1', '123 Main St'),
  (1, '2022-05-03 14:00:00', 50.00, 'Product 2', '456 Elm St'),
  (2, '2022-05-05 09:45:00', 75.00, 'Product 3', '789 Oak St'),
  (3, '2022-05-07 11:00:00', 200.00, 'Product 4', '555 Maple St'),
  (4, '2022-05-10 16:30:00', 150.00, 'Product 5', '777 Pine St');