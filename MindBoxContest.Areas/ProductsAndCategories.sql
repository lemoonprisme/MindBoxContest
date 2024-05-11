CREATE TABLE Product
(
    Id INT IDENTITY
        CONSTRAINT  PK_Product_Id
        PRIMARY KEY,
    [Name] NVARCHAR(300)
);

CREATE TABLE Category
(
    Id INT IDENTITY
        CONSTRAINT  PK_Category_Id
        PRIMARY KEY,
    [Name] NVARCHAR(100)
);

CREATE TABLE ProductCategory
(
    ProductID INT
        CONSTRAINT FK_ProductCategoryXRef_Product_Id
            REFERENCES Product,
    CategoryID INT
        CONSTRAINT FK_ProductCategoryXRef_Category_Id
            REFERENCES Category,
    PRIMARY KEY (ProductID, CategoryID)
)

    INSERT INTO Product ([Name]) VALUES
(N'Кефир'),
(N'Огурцы'),
(N'Шифоньер'),
(N'Porsche 911'),
(N'Чашка')

INSERT INTO Category ([Name]) VALUES
(N'Молочная продукция'),
(N'Овощи'),
(N'Мебель'),
(N'Автомобиль'),
(N'Еда'),
(N'Спортивный автомобиль');

INSERT INTO ProductCategory(productid, categoryid) VALUES
    (1,1),
    (1,5),
    (2,2),
    (2,5),
    (3,3),
    (4,4),
    (4,6);

SELECT Product.name AS Product, C.Name AS Category 
FROM Product
    LEFT JOIN ProductCategory AS PC ON Product.Id = PC.ProductID
    FULL JOIN Category C ON C.Id = PC.CategoryID