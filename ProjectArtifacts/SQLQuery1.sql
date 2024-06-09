--DROP TABLE Shoppers
--DROP DATABASE CuisineCompanion;

 
 --DROP TABLE  Inventory_CookedDish
 --DROP TABLE Inventory
 --DROP TABLE CookedDish
CREATE TABLE Inventory(
	InventoryID INT NOT NULL IDENTITY(1,1),
	FoodName VARCHAR(50) NOT NULL,
	Price VARCHAR(50) NOT NULL,
	PurchaseDate DATETIME NOT NULL,
	QtyCounter INT DEFAULT 0,
	CONSTRAINT PK_Inventory PRIMARY KEY(InventoryID)
);

INSERT INTO Inventory(FoodName,Price,PurchaseDate)
VALUES 
('Seafood Mix','8','2024-05-31'),
('Beef','20','2024-05-15'),
('Onion','5','2024-05-22'),
('Egg','6','2024-05-30'),
('Chicken','8','2024-05-31')



 


CREATE TABLE CookedDish(
	DishID INT NOT NULL IDENTITY(1,1),
	Name  VARCHAR(50) NOT NULL,
	Comment VARCHAR(50) NOT NULL, 
	DateOfMade DATETIME NOT NULL,
	Rating INT ,
	CONSTRAINT PK_CookedDish PRIMARY KEY(DishID)
);

INSERT INTO CookedDish(Name,Comment,DateOfMade,Rating) 
VALUES
('Oyakodon','https://cookpad.com/recipe/7262886', '2024-06-02','3'),
('Sukiyaki','https://cookpad.com/recipe/7262886', '2024-06-01','5'),
('Okonomiyaki','https://cookpad.com/recipe/7262886', '2024-06-03','4');

CREATE TABLE Inventory_CookedDish(
	InventoryID INT NOT NULL ,
	DishID INT NOT NULL , 
	 
	FOREIGN KEY (InventoryID) REFERENCES Inventory(InventoryID),
	FOREIGN KEY (DishID) REFERENCES CookedDish(DishID)
);

INSERT INTO Inventory_CookedDish(InventoryID,DishID)
VALUES
('1','3'),
('2','2'),
('3','2'),
('4','3'),
('5','1');


SELECT * FROM Inventory;
SELECT * FROM CookedDish;
SELECT * FROM Inventory_CookedDish;

CREATE TRIGGER UpdateQtyCounterOnCookedDishInsert
ON Inventory_CookedDish
AFTER INSERT
AS
BEGIN
    UPDATE Inventory
    SET QtyCounter = QtyCounter + 1
    WHERE InventoryID IN (SELECT InventoryID FROM inserted);
END;
