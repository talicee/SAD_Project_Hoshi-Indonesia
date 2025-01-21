/*====================================================================*/
/* PROCEDURE FOR GRAPHIC DATA PURCHASE REPORT (PURCHASE REPORT)       */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pGrafikProfitPurchase;
DELIMITER $$
CREATE PROCEDURE pGrafikProfitPurchase(input VARCHAR(5), tanggal VARCHAR(4))
BEGIN
    IF input = "MONTH" THEN
        SELECT 
            CASE 
                WHEN DAY(TRANSACTION_DATE_PURCHASE) BETWEEN 1 AND 7 THEN 'Week 1'
                WHEN DAY(TRANSACTION_DATE_PURCHASE) BETWEEN 8 AND 14 THEN 'Week 2'
                WHEN DAY(TRANSACTION_DATE_PURCHASE) BETWEEN 15 AND 21 THEN 'Week 3'
                ELSE 'Week 4'
            END AS Week,
            SUM(GRAND_TOTAL_PURCHASE) AS TotalProfit
        FROM PURCHASE_TRANSACTION
        WHERE tanggal = DATE_FORMAT(CURRENT_DATE(), '%y-%m') AND PAYMENT_STATUS_PURCHASE = 'Paid'
        GROUP BY Week
        ORDER BY FIELD(Week, 'Week 1', 'Week 2', 'Week 3', 'Week 4');
    ELSEIF input = "YEAR" THEN
        SELECT 
            CONVERT(SUBSTRING(ID_PURCHASE, 7, 2), UNSIGNED INT) AS Month,
            SUM(GRAND_TOTAL_PURCHASE) AS TotalProfit
        FROM PURCHASE_TRANSACTION
        WHERE tanggal = SUBSTRING(ID_PURCHASE, 5, 2) AND PAYMENT_STATUS_PURCHASE = 'Paid'
        GROUP BY Month
        ORDER BY Month;
        ELSEIF input = "ALL" THEN
                SELECT
                        CONVERT(SUBSTRING(ID_PURCHASE, 5, 2), UNSIGNED INT) AS Month,
                        SUM(GRAND_TOTAL_PURCHASE) AS TotalProfit
                        FROM PURCHASE_TRANSACTION
            WHERE PAYMENT_STATUS_PURCHASE = 'Paid'
        GROUP BY Month
        ORDER BY Month;
    END IF;
END $$
DELIMITER ;
CALL pGrafikProfitPurchase('all', '24');

/*====================================================================*/
/* PROCEDURE FOR GRAPHIC DATA SALES REPORT (SALES REPORT)             */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pGrafikProfitSales;
DELIMITER $$
CREATE PROCEDURE pGrafikProfitSales(input VARCHAR(5), tanggal VARCHAR(4))
BEGIN
    IF input = "MONTH" THEN
        SELECT 
            CASE 
                WHEN DAY(TRANSACTION_DATE_SALES) BETWEEN 1 AND 7 THEN 'Week 1'
                WHEN DAY(TRANSACTION_DATE_SALES) BETWEEN 8 AND 14 THEN 'Week 2'
                WHEN DAY(TRANSACTION_DATE_SALES) BETWEEN 15 AND 21 THEN 'Week 3'
                ELSE 'Week 4'
            END AS Week,
            SUM(GRAND_TOTAL_SALES) AS TotalProfit
        FROM SALES_TRANSACTION
        WHERE tanggal = DATE_FORMAT(CURRENT_DATE(), '%y-%m') AND PAYMENT_STATUS_SALES = 'Paid'
        GROUP BY Week
        ORDER BY FIELD(Week, 'Week 1', 'Week 2', 'Week 3', 'Week 4');
    ELSEIF input = "YEAR" THEN
        SELECT 
            CONVERT(SUBSTRING(ID_SALES, 7, 2), UNSIGNED INT) AS Month,
            SUM(GRAND_TOTAL_SALES) AS TotalProfit
        FROM SALES_TRANSACTION
        WHERE tanggal = SUBSTRING(ID_SALES, 5, 2) AND PAYMENT_STATUS_SALES = 'Paid'
        GROUP BY Month
        ORDER BY Month;
        ELSEIF input = "ALL" THEN
                SELECT 
            CONVERT(SUBSTRING(ID_SALES, 5, 2), UNSIGNED INT) AS Month,
            SUM(GRAND_TOTAL_SALES) AS TotalProfit
        FROM SALES_TRANSACTION
        WHERE PAYMENT_STATUS_SALES = 'Paid'
        GROUP BY Month
        ORDER BY Month;
    END IF;
END $$
DELIMITER ;
CALL pGrafikProfitSales('year', '24');

/*====================================================================*/
/* PROCEDURE FOR REMINDER DUE DATE SALES TRANSACTION (DASHBOARD)      */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pDueDateSales;
delimiter $$ 
CREATE PROCEDURE pDueDateSales()
BEGIN
	SELECT DATE_FORMAT(DUE_DATE_PAYMENT_SALES, '%d-%m-%Y') AS "Due Date Sales", ID_SALES AS "ID Sales", 
    IF(LENGTH(NAME_CUSTOMER) > 25, CONCAT(LEFT(NAME_CUSTOMER,25), '..'), NAME_CUSTOMER) as "Customer"
	FROM SALES_TRANSACTION
	WHERE PAYMENT_STATUS_SALES = "Unpaid" AND STATUS_DEL_SALES = 0
	ORDER BY 1
	LIMIT 4;
END $$
delimiter ;
CALL pDueDateSales();

/*====================================================================*/
/* PROCEDURE FOR REMINDER DUE DATE PURCHASE TRANSACTION (DASHBOARD)   */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pDueDatePurchase;
delimiter $$ 
CREATE PROCEDURE pDueDatePurchase()
BEGIN
	SELECT DATE_FORMAT(DUE_DATE_PAYMENT_PURCHASE,'%d-%m-%Y') AS "Due Date Purchase", 
    ID_PURCHASE AS "ID Purchase", 
    IF(LENGTH(NAME_SUPPLIER) > 25, CONCAT(LEFT(NAME_SUPPLIER,25), '..'), NAME_SUPPLIER) AS "Supplier"
        FROM PURCHASE_TRANSACTION
        WHERE PAYMENT_STATUS_PURCHASE = "Unpaid" AND STATUS_DEL_PURCHASE = 0
        ORDER BY 1
        LIMIT 4;
END $$
delimiter ;
CALL pDueDatePurchase();

/*====================================================================*/
/* PROCEDURE FOR 3 TOP ITEM SALES (DASHBOARD)                         */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pTopItemSales;
delimiter $$ 
CREATE PROCEDURE pTopItemSales(input VARCHAR(7))
BEGIN
	IF input = 'MONTHLY' THEN
			SELECT ID_ITEM AS "ID Item", 
			SUM(QUANTITY_DETAILSALES) AS "Total Quantity"
			FROM DETAIL_SALES_TRANSACTION D
			JOIN SALES_TRANSACTION S
			ON D.ID_SALES = S.ID_SALES
			WHERE DATE_FORMAT(TRANSACTION_DATE_SALES,'%m%Y') = DATE_FORMAT(CURRENT_DATE(),'%m%Y')
            AND STATUS_DEL_DETAILSALES = 0 AND STATUS_DEL_SALES = 0
			GROUP BY 1
			ORDER BY 2 DESC
			LIMIT 4;
	ELSEIF input = 'YEARLY' THEN
			SELECT ID_ITEM AS "ID Item", 
			SUM(QUANTITY_DETAILSALES) AS "Total Quantity"
			FROM DETAIL_SALES_TRANSACTION D
			JOIN SALES_TRANSACTION S
			ON D.ID_SALES = S.ID_SALES
			WHERE DATE_FORMAT(TRANSACTION_DATE_SALES,'%Y') = DATE_FORMAT(CURRENT_DATE(),'%Y')
            AND STATUS_DEL_DETAILSALES = 0 AND STATUS_DEL_SALES = 0
			GROUP BY 1
			ORDER BY 2 desc
			LIMIT 4;        
	END IF;
END $$
delimiter ;
CALL pTopItemSales('monthly');

/*====================================================================*/
/* PROCEDURE FOR SORT MASTER DATA CUSTOMER IN DGV                     */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pMasterCustomer;
delimiter $$ 
CREATE PROCEDURE pMasterCustomer(in search VARCHAR(15), in input VARCHAR(50))
BEGIN 
	IF search = "ID" THEN
		SELECT * FROM vMasterCustomer
		WHERE ID LIKE CONCAT('%', input, '%');
	ELSEIF search = "Instance" THEN
		SELECT * FROM vMasterCustomer
		WHERE `Instance` LIKE CONCAT('%', input, '%');
	ELSEIF search = "Customer" THEN
		SELECT * FROM vMasterCustomer
		WHERE `Contact Person` LIKE CONCAT('%', input, '%');   
	ELSE
		SELECT 'Invalid search parameter' AS Message;
	END IF;
END $$
delimiter ;

CALL pMasterCustomer('ID', '01');
CALL pMasterCustomer('Instance', 'Prima');
CALL pMasterCustomer('Customer', 'Andi');
CALL pMasterCustomer('C', 'A');

/*====================================================================*/
/* PROCEDURE FOR SORT MASTER DATA SUPPLIER IN DGV                     */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pMasterSupplier;
delimiter $$ 
CREATE PROCEDURE pMasterSupplier(in search VARCHAR(15), in input VARCHAR(50))
BEGIN
	IF search = "ID" THEN
		SELECT * FROM vMasterSupplier
		WHERE ID LIKE CONCAT('%', input, '%');
	ELSEIF search = "Company" THEN
		SELECT * FROM vMasterSupplier
		WHERE Company LIKE CONCAT('%', input, '%');
	ELSE
		SELECT 'Invalid search parameter' AS Message;
	END IF;
END $$
delimiter ;

CALL pMasterSupplier('ID', 'SP01');
CALL pMasterSupplier('Company', 'Jaya');
CALL pMasterSupplier('C', 'A');

/*====================================================================*/
/* PROCEDURE FOR SORT PURCHASE TRANSACTION IN DGV                     */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pPurchaseTrans;
delimiter $$ 
CREATE PROCEDURE pPurchaseTrans(in search VARCHAR(15), in input VARCHAR(50))
BEGIN
	IF search = "Purchase ID" THEN
		SELECT * FROM vPurchaseTrans
		WHERE `Purchase ID` LIKE CONCAT('%', input, '%');
	ELSEIF search = "Supplier" THEN
		SELECT * FROM vPurchaseTrans
		WHERE Supplier LIKE CONCAT('%', input, '%');
	ELSE
		SELECT 'Invalid search parameter' AS Message;
	END IF;
END $$
delimiter ;

/*====================================================================*/
/* PROCEDURE FOR SORT SALES TRANSACTION IN DGV                        */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pSalesTrans;
delimiter $$ 
CREATE PROCEDURE pSalesTrans(in search VARCHAR(15), in input VARCHAR(50))
BEGIN
	IF search = "Sales ID" then
		SELECT * FROM vSalesTrans
		WHERE `Sales ID` LIKE CONCAT('%', input, '%');
	ELSEIF search = "Customer" THEN
		SELECT * FROM vSalesTrans
		WHERE Customer LIKE CONCAT('%', input, '%');
	ELSE
		SELECT 'Invalid search parameter' AS Message;
	END IF;
END $$
delimiter ;

CALL pSalesTrans("Sales ID", "ST202310001");
CALL pSalesTrans("Customer", "Teknologi");

/*====================================================================*/
/* PROCEDURE FOR SORT SALES REPORT IN DGV                             */             -- (GATAU DPT DRMNA)
/*====================================================================*/
DROP PROCEDURE IF EXISTS pDGVSalesReport;
delimiter $$ 
CREATE PROCEDURE pDGVSalesReport(in input VARCHAR(4), in tanggal VARCHAR(5))
BEGIN
	 IF UPPER(tanggal) = "MONTH" THEN 
        SELECT `Sales ID`, `Customer Name`, `Transaction Date`, `Grand Total` 
        FROM vSalesReport
		WHERE SUBSTRING(`Sales ID`, 5, 4) = input AND `Status` = 'Paid'; 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        SELECT `Sales ID`, `Customer Name`, `Transaction Date`, `Grand Total` 
        FROM vSalesReport
		WHERE SUBSTRING(`Sales ID`, 5, 2) = input AND `Status` = 'Paid'; 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
		SELECT `Sales ID`, `Customer Name`, `Transaction Date`, `Grand Total` 
        FROM vSalesReport
		WHERE `Status` = 'Paid';
    END IF;
END $$
delimiter ;

CALL pDGVSalesReport('', 'all');
CALL pDGVSalesReport('24', 'year');
SELECT fTotalSalesReport('', 'all');
SELECT fTotalSalesReport('24', 'year');

/*====================================================================*/
/* PROCEDURE FOR SORT PURCHASE REPORT IN DGV                          */				-- (GATAU DPT DRMNA)
/*====================================================================*/
DROP PROCEDURE IF EXISTS pDGVPurchaseReport;
delimiter $$ 
CREATE PROCEDURE pDGVPurchaseReport(in input VARCHAR(4), in tanggal VARCHAR(5))
BEGIN
	IF UPPER(tanggal) = "MONTH" THEN 
        SELECT `Purchase ID`, `Supplier Name`, `Transaction Date`, `Grand Total` 
        FROM vPurchaseReport
		WHERE SUBSTRING(`Purchase ID`, 5, 4) = input; 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        SELECT `Purchase ID`, `Supplier Name`, `Transaction Date`, `Grand Total` 
        FROM vPurchaseReport
		WHERE SUBSTRING(`Purchase ID`, 5, 2) = input; 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
		SELECT `Purchase ID`, `Supplier Name`, `Transaction Date`, `Grand Total` 
        FROM vPurchaseReport;
    END IF;
END $$
delimiter ;

CALL pDGVPurchaseReport('24', 'year');
SELECT fTotalPurchaseReport('23', 'year'); 
CALL pDGVPurchaseReport('', 'all');
SELECT fTotalPurchaseReport('', 'all'); 
  


/*====================================================================*/
/* PROCEDURE FOR CHART PURCHASE				                          */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pChartPurchase;
DELIMITER $$ 
CREATE PROCEDURE pChartPurchase(IN input VARCHAR(6), IN tgl VARCHAR(5))
BEGIN
    IF tgl = 'month' THEN
        SELECT nomor, IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0) AS total_purchase
        FROM (
            SELECT 'Week 1' AS nomor, 1 AS start_day, 7 AS end_day
            UNION ALL SELECT 'Week 2', 8, 14
            UNION ALL SELECT 'Week 3', 15, 21
            UNION ALL SELECT 'Week 4', 22, 31
        ) weeks
        LEFT JOIN PURCHASE_TRANSACTION pt
            ON DAY(pt.TRANSACTION_DATE_PURCHASE) BETWEEN weeks.start_day AND weeks.end_day
            AND DATE_FORMAT(pt.TRANSACTION_DATE_PURCHASE, '%Y%m') = input
            AND pt.PAYMENT_STATUS_PURCHASE = 'Paid'
        GROUP BY nomor
        ORDER BY nomor;
    ELSEIF tgl = 'year' THEN
        SELECT bulan, IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0) AS total_purchase
        FROM (
            SELECT 'Januari' AS bulan, 1 AS urut
            UNION ALL SELECT 'Februari', 2
            UNION ALL SELECT 'Maret', 3
            UNION ALL SELECT 'April', 4
            UNION ALL SELECT 'May', 5
            UNION ALL SELECT 'June', 6
            UNION ALL SELECT 'July', 7
            UNION ALL SELECT 'August', 8
            UNION ALL SELECT 'September', 9
            UNION ALL SELECT 'October', 10
            UNION ALL SELECT 'November', 11
            UNION ALL SELECT 'December', 12
        ) months
        LEFT JOIN PURCHASE_TRANSACTION pt
            ON MONTH(pt.TRANSACTION_DATE_PURCHASE) = months.urut
            AND DATE_FORMAT(pt.TRANSACTION_DATE_PURCHASE, '%Y') = input
            AND pt.PAYMENT_STATUS_PURCHASE = 'Paid'
        GROUP BY bulan, urut
        ORDER BY urut;
    END IF;
END $$
DELIMITER ;

CALL pChartPurchase('202411','month');
/*====================================================================*/
/* PROCEDURE HEADER PURCHASE REPORT 		                          */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pHeaderPurchaseReport;
DELIMITER ~~
CREATE PROCEDURE pHeaderPurchaseReport(input VARCHAR(5), tgl VARCHAR(6))
BEGIN
	DECLARE Transactions, Purchase, Item VARCHAR(100);
    IF input = 'ALL' THEN 
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_PURCHASE),0),',','.') FROM PURCHASE_TRANSACTION);
        SET Purchase = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0),0), ',', '.') FROM PURCHASE_TRANSACTION);
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0),0), ',', '.')
					FROM PURCHASE_TRANSACTION pt
					LEFT JOIN DETAIL_PURCHASE_TRANSACTION dpt ON dpt.ID_PURCHASE = pt.ID_PURCHASE);
	ELSEIF input = 'MONTH' THEN
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_PURCHASE),0),',','.') FROM PURCHASE_TRANSACTION 
							WHERE DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%Y%m') = tgl);
        SET Purchase = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0),0), ',', '.') FROM PURCHASE_TRANSACTION
						WHERE DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%Y%m') = tgl);
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0),0), ',', '.')
					FROM PURCHASE_TRANSACTION pt
					LEFT JOIN DETAIL_PURCHASE_TRANSACTION dpt ON dpt.ID_PURCHASE = pt.ID_PURCHASE
					WHERE DATE_FORMAT(pt.TRANSACTION_DATE_PURCHASE, '%Y%m') = tgl);
	ELSEIF input = 'YEAR' THEN
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_PURCHASE),0),',','.') FROM PURCHASE_TRANSACTION
							WHERE DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%Y') = tgl);
        SET Purchase = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0),0), ',', '.') FROM PURCHASE_TRANSACTION 
						WHERE DATE_FORMAT(TRANSACTION_DATE_PURCHASE, '%Y') = tgl);
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0),0), ',', '.')
					FROM PURCHASE_TRANSACTION pt
					LEFT JOIN DETAIL_PURCHASE_TRANSACTION dpt ON dpt.ID_PURCHASE = pt.ID_PURCHASE
					WHERE DATE_FORMAT(pt.TRANSACTION_DATE_PURCHASE, '%Y') = tgl);
    END IF;
    
    SELECT Transactions, Purchase, Item;
END ~~
DELIMITER ;
call pHeaderPurchaseReport('year', '2024');

/*====================================================================*/
/* PROCEDURE FOR CHART SALES				                          */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pChartSales;
DELIMITER $$ 
CREATE PROCEDURE pChartSales(IN input VARCHAR(6), IN tgl VARCHAR(5))
BEGIN
    IF tgl = 'month' THEN
        SELECT nomor, IFNULL(SUM(GRAND_TOTAL_SALES), 0) AS total_sales
        FROM (
            SELECT 'Week 1' AS nomor, 1 AS start_day, 7 AS end_day
            UNION ALL SELECT 'Week 2', 8, 14
            UNION ALL SELECT 'Week 3', 15, 21
            UNION ALL SELECT 'Week 4', 22, 31
        ) weeks
        LEFT JOIN SALES_TRANSACTION st
            ON DAY(st.TRANSACTION_DATE_SALES) BETWEEN weeks.start_day AND weeks.end_day
            AND DATE_FORMAT(st.TRANSACTION_DATE_SALES, '%Y%m') = input
            AND st.PAYMENT_STATUS_SALES = 'Paid'
        GROUP BY nomor
        ORDER BY nomor;
    ELSEIF tgl = 'year' THEN
        SELECT bulan, IFNULL(SUM(GRAND_TOTAL_SALES), 0) AS total_sales
        FROM (
            SELECT 'Januari' AS bulan, 1 AS urut
            UNION ALL SELECT 'Februari', 2
            UNION ALL SELECT 'Maret', 3
            UNION ALL SELECT 'April', 4
            UNION ALL SELECT 'May', 5
            UNION ALL SELECT 'June', 6
            UNION ALL SELECT 'July', 7
            UNION ALL SELECT 'August', 8
            UNION ALL SELECT 'September', 9
            UNION ALL SELECT 'October', 10
            UNION ALL SELECT 'November', 11
            UNION ALL SELECT 'December', 12
        ) months
        LEFT JOIN SALES_TRANSACTION st
            ON MONTH(st.TRANSACTION_DATE_SALES) = months.urut
            AND DATE_FORMAT(st.TRANSACTION_DATE_SALES, '%Y') = input
            AND st.PAYMENT_STATUS_SALES = 'Paid'
        GROUP BY bulan, urut
        ORDER BY urut;
    END IF;
END $$
DELIMITER ;

CALL pChartSales('2024','year');

/*====================================================================*/
/* PROCEDURE HEADER SALES REPORT 		                          */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pHeaderSalesReport;
DELIMITER ~~
CREATE PROCEDURE pHeaderSalesReport(input VARCHAR(5), tgl VARCHAR(6))
BEGIN
	DECLARE Transactions, Sales, Item VARCHAR(100);
    IF input = 'ALL' THEN
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_SALES),0),',','.') FROM SALES_TRANSACTION
							WHERE PAYMENT_STATUS_SALES = 'Paid');
        SET Sales = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES),0),0),',','.') FROM SALES_TRANSACTION
						WHERE PAYMENT_STATUS_SALES = 'Paid');
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILSALES),0),0),',','.')
					FROM SALES_TRANSACTION st
					LEFT JOIN DETAIL_SALES_TRANSACTION dst ON dst.ID_SALES = st.ID_SALES
					WHERE PAYMENT_STATUS_SALES = 'Paid');
	ELSEIF input = 'MONTH' THEN
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_SALES),0),',','.') FROM SALES_TRANSACTION
							WHERE PAYMENT_STATUS_SALES = 'Paid' AND DATE_FORMAT(TRANSACTION_DATE_SALES, '%Y%m') = tgl);
        SET Sales = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES),0),0),',','.') FROM SALES_TRANSACTION
						WHERE PAYMENT_STATUS_SALES = 'Paid' AND DATE_FORMAT(TRANSACTION_DATE_SALES, '%Y%m') = tgl);
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILSALES),0),0),',','.')
					FROM SALES_TRANSACTION st
					LEFT JOIN DETAIL_SALES_TRANSACTION dst ON dst.ID_SALES = st.ID_SALES
					WHERE PAYMENT_STATUS_SALES = 'Paid' AND DATE_FORMAT(st.TRANSACTION_DATE_SALES, '%Y%m') = tgl);
	ELSEIF input = 'YEAR' THEN
		SET Transactions = (SELECT REPLACE(FORMAT(COUNT(ID_SALES),0),',','.') FROM SALES_TRANSACTION
							WHERE PAYMENT_STATUS_SALES = 'Paid' AND DATE_FORMAT(TRANSACTION_DATE_SALES, '%Y') = tgl);
        SET Sales = (SELECT REPLACE(FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES),0),0),',','.') FROM SALES_TRANSACTION
						WHERE PAYMENT_STATUS_SALES = 'Paid' AND DATE_FORMAT(TRANSACTION_DATE_SALES, '%Y') = tgl);
        SET Item = (SELECT REPLACE(FORMAT(IFNULL(SUM(QUANTITY_DETAILSALES),0),0),',','.')
					FROM SALES_TRANSACTION st
					LEFT JOIN DETAIL_SALES_TRANSACTION dst ON dst.ID_SALES = st.ID_SALES
					WHERE DATE_FORMAT(st.TRANSACTION_DATE_SALES, '%Y') = tgl);
    END IF;
    
    SELECT Transactions, Sales, Item;
END ~~
DELIMITER ;
CALL pHeaderSalesReport('month','202410');

/*====================================================================*/
/* PROCEDURE STOCK REPORT					                          */
/*====================================================================*/
DROP PROCEDURE IF EXISTS pStockReport;
DELIMITER ~~
CREATE PROCEDURE pStockReport(tglawal VARCHAR(10), tglakhir VARCHAR(10), info VARCHAR(5))
BEGIN
	IF info = 'month' THEN
		SELECT ID_ITEM AS `Item ID`, 
			NAME_ITEM AS `Item Name`, 
			fStock(ID_ITEM, tglawal) AS `Stock Awal Bulan`, 
			fStockPurchase(ID_ITEM, tglawal, tglakhir) `Pemasukan`,
			fStockSales(ID_ITEM, tglawal, tglakhir) AS `Pengeluaran`,
			fStockStockOpname(ID_ITEM, tglawal, tglakhir) AS `Stock Opname`,
			fStock(ID_ITEM, tglakhir) AS `Stock Akhir Bulan`
		FROM MASTER_ITEM;
	ELSEIF info = 'year' THEN
		SELECT ID_ITEM AS `Item ID`, 
			NAME_ITEM AS `Item Name`, 
			fStock(ID_ITEM, tglawal) AS `Early Year Stock`, 
			fStockPurchase(ID_ITEM, tglawal, tglakhir) `Amount Of Stock In`,
			fStockSales(ID_ITEM, tglawal, tglakhir) AS `Amount Of Stock Out`,
			fStockStockOpname(ID_ITEM, tglawal, tglakhir) AS `Stock Opname`,
			fStock(ID_ITEM, tglakhir) AS `End Of Year Stock`
		FROM MASTER_ITEM;
	END IF;
END ~~
DELIMITER ;
-- Cara inputnya kek dibawah ini batas tgl awal bulan n tanggal awal bulan setelahnya
CALL pStockReport('2024-11-01','2024-12-01', 'year');