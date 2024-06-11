	  SELECT 
	            q.NextCourseID,
	            q.NextInstructorID,
	            q.NextTerm,
	            q.PrevCourseID,
	            q.PrevInstructorID,
	            q.PrevTerm,
	            q.RowNumber,

            (SELECT TOP(1) InventoryID  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstCourseID,
            (SELECT TOP(1) DishID  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstInstructorID,
            (SELECT TOP(1) QuantityRequired  FROM Inventory_CookedDish ORDER BY InventoryID ASC)AS FirstTerm,
            (SELECT TOP(1) InventoryID  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastCourseID,
            (SELECT TOP(1) DishID  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastInstructorID,
            (SELECT TOP(1) QuantityRequired  FROM Inventory_CookedDish ORDER BY InventoryID DESC)AS LastTerm
			FROM
			(
			SELECT InventoryID,DishID,QuantityRequired ,
            LEAD(InventoryID) OVER(ORDER BY InventoryID) AS NextCourseID,
            LEAD(DishID) OVER(ORDER BY InventoryID) AS NextInstructorID,
            LEAD(QuantityRequired) OVER(ORDER BY InventoryID) AS NextTerm,
            LAG(InventoryID) OVER(ORDER BY InventoryID) AS PrevCourseID,
            LAG(DishID) OVER(ORDER BY InventoryID) AS PrevInstructorID,
            LAG(QuantityRequired) OVER(ORDER BY InventoryID) AS PrevTerm,
            ROW_NUMBER() OVER(ORDER BY InventoryID) AS RowNumber 
			FROM Inventory_CookedDish ) AS q