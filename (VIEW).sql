/*==============================================================*/
/* VIEW FOR STOCK REMINDER (DASHBOARD)                          */
/*==============================================================*/
DROP VIEW IF EXISTS vStockReminder;
CREATE VIEW vStockReminder AS
	SELECT ID_ITEM, STOCK_ITEM
    FROM MASTER_ITEM
    WHERE STOCK_ITEM <= MINIMUM_STOCK_ITEM AND STATUS_DEL_ITEM = 0
    ORDER BY 2 DESC
    LIMIT 10;

SELECT * FROM vStockReminder;

/*==============================================================*/
/* VIEW FOR MASTER DATA CUSTOMER DGV                            */
/*==============================================================*/
DROP VIEW IF EXISTS vMasterCustomer;
CREATE VIEW vMasterCustomer AS
	SELECT 
    ID_CUSTOMER AS ID,
    INSTANCE_CUSTOMER AS "Instance",
    ADDRESS_CUSTOMER AS Address,
    CITY_CUSTOMER AS City,
    PHONE_NUMBER_CUSTOMER AS "Phone Number",
    EMAIL_CUSTOMER AS Email,
    CONTACT_PERSON_CUSTOMER AS "Contact Person",
    DATE_FORMAT(REGISTERED_DATE_CUSTOMER, '%d %M %Y') AS "Registered Date",
    TOP_CUSTOMER AS TOP
	FROM MASTER_CUSTOMER
	WHERE STATUS_DEL_CUSTOMER = 0;

SELECT * FROM vMasterCustomer;

/*==============================================================*/
/* VIEW FOR MASTER DATA SUPPLIER DGV                            */
/*==============================================================*/
DROP VIEW IF EXISTS vMasterSupplier;
CREATE VIEW vMasterSupplier AS
	SELECT 
	ID_SUPPLIER AS ID,
    COMPANY_SUPPLIER AS Company,
    ADDRESS_SUPPLIER AS Address,
    CITY_SUPPLIER AS City,
    PHONE_NUMBER_SUPPLIER AS "Phone Number",
    EMAIL_SUPPLIER AS "Email",
    CONTACT_PERSON_SUPPLIER AS "Contact Person",
    TOP_SUPPLIER AS "TOP"
	FROM MASTER_SUPPLIER
	WHERE STATUS_DEL_SUPPLIER = 0;

SELECT * FROM vMasterSupplier;

/*==============================================================*/
/* VIEW FOR MASTER DATA ITEM DGV                                */
/*==============================================================*/
DROP VIEW IF EXISTS vMasterItem;
CREATE VIEW vMasterItem AS
	SELECT 
    ID_ITEM AS ID,
    NAME_ITEM AS Name,
    COLOUR_ITEM AS Colour,
    SIZE_ITEM AS Size,
    CATEGORY_ITEM AS Category,
    SALES_PRICE_ITEM AS "Sales Price",
    PURCHASE_PRICE_ITEM AS "Purchase_Price",
    STOCK_ITEM AS Stock,
    MINIMUM_STOCK_ITEM AS "Minimum Stock"
	FROM MASTER_ITEM
	WHERE STATUS_DEL_ITEM = 0;
    
SELECT * FROM vMasterItem;

/*==============================================================*/
/* MASTER DATA ITEM BUAT ADMIN                                  */
/*==============================================================*/
DROP VIEW IF EXISTS vMasterItemAdmin;
CREATE VIEW vMasterItemAdmin AS
	SELECT 
		ID_ITEM AS ID,
		NAME_ITEM AS Name,
		COLOUR_ITEM AS Colour,
		SIZE_ITEM AS Size,
		CATEGORY_ITEM AS Category,
		SALES_PRICE_ITEM AS "Sales Price",
		STOCK_ITEM AS Stock,
		MINIMUM_STOCK_ITEM AS "Minimum Stock"
	FROM MASTER_ITEM
	WHERE STATUS_DEL_ITEM = 0;

/*==============================================================*/
/* VIEW FOR PURCHASE TRANSACTION DGV                            */
/*==============================================================*/
DROP VIEW IF EXISTS vPurchaseTrans;
CREATE VIEW vPurchaseTrans AS
	SELECT 
    ID_PURCHASE AS "Purchase ID",
    DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%d %M %Y') AS "Transaction Date",
	ID_SUPPLIER AS "Supplier ID",
    NAME_SUPPLIER AS Supplier,
    ADDRESS_SUPPLIER AS Address,
    CITY_SUPPLIER AS City,
    INVOICE_SUPPLIER_PURCHASE AS "Supplier Invoice",
    TOP_SUPPLIER AS TOP,
    DATE_FORMAT(DUE_DATE_PAYMENT_PURCHASE, '%d %M %Y') AS "Due Date",
    PAYMENT_STATUS_PURCHASE AS "Status",
    REPLACE(FORMAT(GRAND_TOTAL_PURCHASE,0),',','.') AS "Grand Total" 
	FROM PURCHASE_TRANSACTION
	WHERE STATUS_DEL_PURCHASE = 0;
SELECT * FROM vPurchaseTrans;    
SELECT * FROM vPurchaseTrans
WHERE RIGHT(`Transaction Date`,7) = '11/2024';

/*===================================================*/
/* DGV DETAIL PURCHASE                               */
/*===================================================*/
DROP VIEW IF EXISTS vDetailPurchaseTrans;
CREATE VIEW vDetailPurchaseTrans AS
	SELECT 
		ID_DETAIL_PURCHASE as `Detail Purchase ID`,
		ID_ITEM as `Item ID`,
		NAME_ITEM as `Item Name`,
		QUANTITY_DETAILPURCHASE as Quantity,
		PURCHASE_PRICE_ITEM as `Price / pcs`,
		TOTAL_PRICE_DETAILPURCHASE as Total
	FROM DETAIL_PURCHASE_TRANSACTION d
	JOIN PURCHASE_TRANSACTION p
	ON p.ID_PURCHASE = d.ID_PURCHASE
	WHERE STATUS_DEL_DETAILPURCHASE = 0;

/*==============================================================*/
/* VIEW FOR DEBT REMINDER DGV                                   */
/*==============================================================*/
DROP VIEW IF EXISTS vDebtReminder;
CREATE VIEW vDebtReminder AS
	SELECT ID_PURCHASE AS "Purchase ID",
    NAME_SUPPLIER AS "Supplier",
    DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%d/%m/%Y') AS "Transaction Date",
    DATE_FORMAT(DUE_DATE_PAYMENT_PURCHASE, '%d/%m/%Y') AS "Due Date",
    GRAND_TOTAL_PURCHASE AS "Grand Total" 
    FROM PURCHASE_TRANSACTION
    WHERE PAYMENT_STATUS_PURCHASE = "Unpaid" AND STATUS_DEL_PURCHASE = 0;

SELECT * FROM vDebtReminder;

/*==============================================================*/
/* VIEW FOR SALES TRANSACTION DGV                               */
/*==============================================================*/
DROP VIEW IF EXISTS vSalesTrans;
CREATE VIEW vSalesTrans AS
	SELECT 
    ID_SALES AS "Sales ID",
    DATE_FORMAT(TRANSACTION_DATE_SALES, '%d %M %Y') AS "Transaction Date",
    ID_CUSTOMER AS "Customer ID",
    NAME_CUSTOMER AS "Customer",
    ADDRESS_CUSTOMER AS "Address",
    CITY_CUSTOMER AS "City",
    TOP_CUSTOMER AS "TOP",
    DATE_FORMAT(DUE_DATE_PAYMENT_SALES, '%d %M %Y') AS "Due Date",
    PAYMENT_STATUS_SALES AS "Payment Status",
    REPLACE(FORMAT(GRAND_TOTAL_SALES,0),',','.') AS "Grand Total"
	FROM SALES_TRANSACTION
	WHERE STATUS_DEL_SALES = 0;
        
SELECT * FROM vSalesTrans;
SELECT* FROM vPurchaseTrans WHERE RIGHT(`Transaction Date`, 4) = '2023';
SELECT * FROM vPurchaseTrans WHERE RIGHT(`Transaction Date`, 7) = '{a + '/' + cb_year_monthly.Text}';
SELECT RIGHT(`Transaction Date`, 4) FROM vPurchaseTrans;
SELECT `Transaction Date` FROM vPurchaseTrans;
/*=================================================*/
/* DGV DETAIL SALES                                */
/*=================================================*/
DROP VIEW IF EXISTS vDetailSalesTrans;
CREATE VIEW vDetailSalesTrans AS
	SELECT 
		ID_DETAIL_SALES as `Detail Sales ID`,
		ID_ITEM as `Item ID`,
		NAME_ITEM as `Item Name`,
		QUANTITY_DETAILSALES as `Quantity`,
		SALES_PRICE_ITEM as `Price / pcs`,
		TOTAL_PRICE_DETAILSALES as `Total`
	FROM DETAIL_SALES_TRANSACTION d
	JOIN SALES_TRANSACTION s
	ON s.ID_SALES = d.ID_SALES
	WHERE STATUS_DEL_DETAILSALES = 0;

/*==============================================================*/
/* VIEW FOR RECEIVABLE REMINDER DGV                             */
/*==============================================================*/
DROP VIEW IF EXISTS vReceivableReminder;
CREATE VIEW vReceivableReminder AS
	SELECT ID_SALES AS "Sales ID",
    NAME_CUSTOMER AS "Customer",
    DATE_FORMAT(TRANSACTION_DATE_SALES, '%d/%m/%Y') AS "Transaction Date",
    DATE_FORMAT(DUE_DATE_PAYMENT_SALES, '%d/%m/%Y') AS "Due Date",
    GRAND_TOTAL_SALES AS "Grand Total" 
    FROM SALES_TRANSACTION
    WHERE PAYMENT_STATUS_SALES = "Unpaid" AND STATUS_DEL_SALES = 0;
    
SELECT * FROM vReceivableReminder;

/*=====================================================*/
/* VIEW FOR ACCOUNT DGV                                */
/*=====================================================*/
DROP VIEW IF EXISTS vAccount;
CREATE VIEW vAccount AS
	SELECT 
    USERNAME_ACCOUNT AS 'Username', 
    PASSWORD_ACCOUNT AS 'Password', 
    Dashboard, 
    Customer,
    Supplier, 
    Item,
    Purchase_Transaction, 
    Sales_Transaction, 
    Stock_Opname, 
    Purchase_Price, 
    Sales_Price, 
    Purchase_Report, 
    Sales_Report, 
    Profit_Report, 
    Stock_Report,
    Account, 
    Sign_Out
FROM ACCOUNT
WHERE STATUS_DEL_ACCOUNT = 0;

/*==============================================================*/
/* VIEW FOR STOCK OPNAME DGV                                    */
/*==============================================================*/
DROP VIEW IF EXISTS vStockOpnameEdit;
CREATE VIEW vStockOpnameEdit AS
	SELECT DATE_FORMAT(DATE_STOCKOPNAME, '%d %M %Y') AS "Stock Opname Date",
    ID_ITEM AS "Item ID",
    SYSTEM_STOCK_ITEM AS "System Stock Quantity",
    PHYSICAL_STOCK_STOCKOPNAME AS "Physical Stock Quantity",
    INFORMATION_STOCKOPNAME AS "Information"
    FROM STOCK_OPNAME 
    WHERE DATE(DATE_STOCKOPNAME) = (
    SELECT DATE(MAX(DATE_STOCKOPNAME)) 
    FROM STOCK_OPNAME)
	ORDER BY DATE_FORMAT(DATE_STOCKOPNAME, '%Y-%m-%d %H:%i:%s') ASC;
SELECT * FROM vStockOpnameEdit;

SELECT DATE(DATE_STOCKOPNAME) FROM STOCK_OPNAME;

DROP VIEW IF EXISTS vStockOpname;
CREATE VIEW vStockOpname AS
	SELECT DATE_FORMAT(DATE_STOCKOPNAME, '%d %M %Y') AS "Stock Opname Date",
    m.ID_ITEM AS "Item ID",
    SYSTEM_STOCK_ITEM AS "System Stock Quantity",
    PHYSICAL_STOCK_STOCKOPNAME AS "Physical Stock Quantity",
    INFORMATION_STOCKOPNAME AS "Information"
    FROM STOCK_OPNAME s
    JOIN MASTER_ITEM m
    ON m.ID_ITEM = s.ID_ITEM
    WHERE STATUS_DEL_STOCKOPNAME = 0
    ORDER BY DATE_FORMAT(s.DATE_STOCKOPNAME, '%Y-%m-%d %H:%i:%s') ASC;

SELECT * FROM vStockOpname;
SELECT * FROM STOCK_OPNAME;

UPDATE STOCK_OPNAME 
SET PHYSICAL_STOCK_STOCKOPNAME = 2, INFORMATION_STOCKOPNAME = 'GATAU APA'
WHERE ID_STOCKOPNAME = '115';
SELECT ID_ITEM FROM MASTER_ITEM;
SELECT ID_ITEM 
FROM
MASTER_ITEM;
/*==============================================================*/
/* VIEW FOR PURCHASE PRICE HISTORY DGV                          */
/*==============================================================*/
DROP VIEW IF EXISTS vPurchaseHistory;
CREATE VIEW vPurchaseHistory AS
	SELECT DATE_FORMAT(DATE_PURCHASEPRICEHISTORY,'%d %M %Y') AS "Purchase Price History Date",
    ID_ITEM AS "Item ID",
    PREVIOUS_PURCHASE_PRICE_ITEM AS "Previous Price",
    NEW_PURCHASE_PRICE_PURCHASEPRICEHISTORY AS "New Price"
    FROM PURCHASE_PRICE_HISTORY
    WHERE STATUS_DEL_PURCHASEPRICEHISTORY = 0;

SELECT * FROM vPurchaseHistory WHERE `Item ID` LIKE '%HI002R%';

/*==============================================================*/
/* VIEW FOR PURCHASE SALES HISTORY DGV                          */
/*==============================================================*/
DROP VIEW IF EXISTS vSalesHistory;
CREATE VIEW vSalesHistory AS
	SELECT DATE_FORMAT(DATE_SALESPRICEHISTORY,'%d %M %Y') AS "Sales Price History Date",
    ID_ITEM AS "Item ID",
    PREVIOUS_SALES_PRICE_ITEM AS "Previous Price",
    NEW_PURCHASE_PRICE_SALESPRICEHISTORY AS "New Price"
    FROM SALES_PRICE_HISTORY
    WHERE STATUS_DEL_SALESPRICEHISTORY = 0;
SELECT * FROM ACCOUNT;
SELECT * FROM vSalesHistory;

/*==============================================================*/
/* VIEW FOR SALES REPORT DGV                                    */
/*==============================================================*/
DROP VIEW IF EXISTS vSalesReport;
CREATE VIEW vSalesReport AS
	SELECT ID_SALES AS "Sales ID" , 
    NAME_CUSTOMER AS "Customer Name",
    TRANSACTION_DATE_SALES AS "Transaction Date",
    GRAND_TOTAL_SALES AS "Grand Total",
    PAYMENT_STATUS_SALES AS "Status"
    FROM SALES_TRANSACTION
    WHERE STATUS_DEL_SALES = 0;

SELECT * FROM vSalesReport;

/*==============================================================*/
/* VIEW FOR PURCHASE REPORT DGV                                 */
/*==============================================================*/
DROP VIEW IF EXISTS vPurchaseReport;
CREATE VIEW vPurchaseReport AS
	SELECT ID_PURCHASE AS "Purchase ID" , 
    NAME_SUPPLIER AS "Supplier Name",
    DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%d.%m.%Y') AS "Transaction Date",
    CONCAT('Rp ', FORMAT(GRAND_TOTAL_PURCHASE,0)) AS "Grand Total",
    PAYMENT_STATUS_PURCHASE AS "Status"
    FROM PURCHASE_TRANSACTION
    WHERE STATUS_DEL_PURCHASE = 0;

SELECT * FROM vPurchaseReport;

/*==============================================================*/
/* VIEW FOR MASTER DATA ITEM DGV (Stock Opname)                 */
/*==============================================================*/
DROP VIEW IF EXISTS vMasterItemSO;
CREATE VIEW vMasterItemSO AS
	SELECT 
    ID_ITEM AS ID,
    NAME_ITEM AS Name,
    COLOUR_ITEM AS Colour,
    SIZE_ITEM AS Size,
    CATEGORY_ITEM AS Category,
    SALES_PRICE_ITEM AS "Sales Price",
    PURCHASE_PRICE_ITEM AS "Purchase_Price",
    STOCK_ITEM AS Stock,
    MINIMUM_STOCK_ITEM AS "Minimum Stock"
	FROM MASTER_ITEM
	WHERE STATUS_DEL_ITEM = 0;
    
SELECT * FROM vMasterItemSO;

SELECT * FROM vMasterItem;
select ID, Name, `Purchase_Price` from vMasterItem;
/*==============================================================*/
/* SELECT" TAMBAHAN                                             */
/*==============================================================*/

-- DGV DETAIL PURCHASE TRANS
SELECT * 
FROM vDetailPurchaseTrans
WHERE `Detail Purchase ID`IN (
    SELECT ID_DETAIL_PURCHASE
    FROM DETAIL_PURCHASE_TRANSACTION d
    JOIN PURCHASE_TRANSACTION p 
    ON p.ID_PURCHASE = d.ID_PURCHASE
    WHERE p.ID_PURCHASE = 'PT202411001'
);

-- INVOICE PURCHASE
SELECT  `Item ID`, `Item Name`, 
CONCAT(`Quantity`, " pcs") as "Quantity",
CONCAT("Rp. ", REPLACE(FORMAT(`Price / pcs`, 0), ',', '.')) AS "Price / pcs",
CONCAT("Rp. ", REPLACE(FORMAT(`Total`, 0), ',', '.')) AS "Total"
FROM vDetailPurchaseTrans
WHERE `Detail Purchase ID`IN (
    SELECT ID_DETAIL_PURCHASE 
    FROM DETAIL_PURCHASE_TRANSACTION d
    JOIN PURCHASE_TRANSACTION p 
    ON p.ID_PURCHASE = d.ID_PURCHASE
    WHERE p.ID_PURCHASE = 'PT202310001'
);

-- DELIVERY NOTE PURCHASE
SELECT  `Item ID`, `Item Name`, 
CONCAT(`Quantity`, " pcs") as "Quantity"
FROM vDetailPurchaseTrans
WHERE `Detail Purchase ID`IN (
    SELECT ID_DETAIL_PURCHASE 
    FROM DETAIL_PURCHASE_TRANSACTION d
    JOIN PURCHASE_TRANSACTION p 
    ON p.ID_PURCHASE = d.ID_PURCHASE
    WHERE p.ID_PURCHASE = 'PT202310001'
);

-- DGV DETAIL SALES TRANS
SELECT * 
FROM vDetailSalesTrans
WHERE `Detail Sales ID`IN (
    SELECT ID_DETAIL_SALES
    FROM DETAIL_SALES_TRANSACTION d
    JOIN SALES_TRANSACTION p 
    ON p.ID_SALES = d.ID_SALES
    WHERE p.ID_SALES = 'ST202501003'
);

-- DELIVERY NOTE SALES
SELECT  `Item ID`, `Item Name`, 
CONCAT(`Quantity`, " pcs") as "Quantity"
FROM vDetailSalesTrans
WHERE `Detail Sales ID`IN (
    SELECT ID_DETAIL_SALES 
    FROM DETAIL_SALES_TRANSACTION d
    JOIN SALES_TRANSACTION p 
    ON p.ID_SALES = d.ID_SALES
    WHERE p.ID_SALES = 'ST202501003'
);

-- INVOICE SALES
SELECT  `Item ID`, `Item Name`, 
CONCAT(`Quantity`, " pcs") as "Quantity",
CONCAT("Rp. ", REPLACE(FORMAT(`Price / pcs`, 0), ',', '.')) AS "Price / pcs",
CONCAT("Rp. ", REPLACE(FORMAT(`Total`, 0), ',', '.')) AS "Total"
FROM vDetailSalesTrans
WHERE `Detail Sales ID`IN (
    SELECT ID_DETAIL_SALES 
    FROM DETAIL_SALES_TRANSACTION d
    JOIN SALES_TRANSACTION p 
    ON p.ID_SALES = d.ID_SALES
    WHERE p.ID_SALES = 'ST202501003'
);

-- GRAND TOTAL SALES INVOICE
SELECT `Sales ID`, `Grand Total` AS "Total"
FROM vSalesTrans
WHERE `Sales ID` = 'ST202411003';
SELECT * FROM vSalesTrans;
-- GRAND TOTAL PURCHASE INVOICE
SELECT `Purchase ID`, `Grand Total` AS "Total"
FROM vPurchaseTrans
WHERE `Purchase ID` = 'PT202310002';


-- ACCOUNT 
DROP TABLE IF EXISTS ACCOUNT;
CREATE TABLE ACCOUNT (
    USERNAME_ACCOUNT VARCHAR(20) PRIMARY KEY,
    PASSWORD_ACCOUNT VARCHAR(20) NOT NULL,
    STATUS_DEL_ACCOUNT BOOLEAN NOT NULL DEFAULT 0,
    Dashboard BOOLEAN NOT NULL DEFAULT 1,
    Customer BOOLEAN NOT NULL DEFAULT 1,
    Supplier BOOLEAN NOT NULL DEFAULT 1,
    Item BOOLEAN NOT NULL DEFAULT 1,
    Purchase_Transaction BOOLEAN NOT NULL DEFAULT 1,
    Sales_Transaction BOOLEAN NOT NULL DEFAULT 1,
    Stock_Opname BOOLEAN NOT NULL DEFAULT 1,
    Purchase_Price BOOLEAN NOT NULL DEFAULT 1,
    Sales_Price BOOLEAN NOT NULL DEFAULT 1,
    Purchase_Report BOOLEAN NOT NULL DEFAULT 1,
    Sales_Report BOOLEAN NOT NULL DEFAULT 1,
    Profit_Report BOOLEAN NOT NULL DEFAULT 1,
    Stock_Report  BOOLEAN NOT NULL DEFAULT 1,
    Account BOOLEAN NOT NULL DEFAULT 1,
    Sign_Out BOOLEAN NOT NULL DEFAULT 1
);

INSERT INTO ACCOUNT (USERNAME_ACCOUNT, PASSWORD_ACCOUNT, Dashboard, Customer, Supplier, Item, 
                     Purchase_Transaction, Sales_Transaction, Stock_Opname, Purchase_Price, 
                     Sales_Price, Purchase_Report, Sales_Report, Profit_Report, Stock_Report, Account, Sign_Out)
VALUES 
('admin', '654321', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
('owner', '123456', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);