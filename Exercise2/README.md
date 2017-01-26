Задание № 2
===========
Ответ:  
Код SQL запрроса:

    SELECT ProductId, COUNT(*) FROM 
    (
        SELECT Sales.ProductId, Sales.CustomerId, Sales.DateCreated FROM 
        (
            (SELECT CustomerId, MIN(DateCreated) AS FirstDate FROM Sales GROUP BY CustomerID) AS FirstSales 
            INNER JOIN Sales ON Sales.CustomerId=FirstSales.CustomerId AND Sales.DateCreated=FirstSales.FirstDate
        )
    )
    GROUP BY ProductId ORDER BY COUNT(*) DESC

P.S. Так же приложен вариант [консольного приложения](https://github.com/olejeek/TestForJob/blob/master/Exercise2/Exercise2/Program.cs) для
 обращения к базе данных MS Access с использованием этого запроса.
