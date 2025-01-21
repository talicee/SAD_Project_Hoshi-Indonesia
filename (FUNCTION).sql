/*================================================================*/
/* FUNCTION UNTUK MENGHITUNG TOTAL PROFIT PER MONTH/YEAR          */
/*================================================================*/
DROP FUNCTION IF EXISTS fProfit;
DELIMITER $$
CREATE FUNCTION fProfit(input VARCHAR(5))
RETURNS VARCHAR(25)
READS SQL DATA 
BEGIN
DECLARE totalSalesMonth,totalSalesYear, totalPurchaseMonth, totalPurchaseYear int;
	SET totalSalesMonth = (SELECT IF(SUM(GRAND_TOTAL_SALES) IS NULL, 0, SUM(GRAND_TOTAL_SALES))
						   FROM SALES_TRANSACTION
                           WHERE substring(ID_SALES, 5, 4) = 
						  (SELECT date_format(now(), '%y%m'))
						   AND PAYMENT_STATUS_SALES = 'Paid');
	SET totalSalesYear = (SELECT IF(SUM(GRAND_TOTAL_SALES) IS NULL, 0, SUM(GRAND_TOTAL_SALES))
						  FROM SALES_TRANSACTION
                          WHERE substring(ID_SALES, 5, 2) = 
						 (SELECT date_format(now(), '%y'))
                          AND PAYMENT_STATUS_SALES = 'Paid');
	SET totalPurchaseMonth = (SELECT IF(SUM(GRAND_TOTAL_PURCHASE) IS NULL, 0, SUM(GRAND_TOTAL_PURCHASE))
							  FROM PURCHASE_TRANSACTION
                              WHERE substring(ID_PURCHASE, 5, 4) = 
							 (SELECT date_format(now(), '%y%m')) 
							  AND PAYMENT_STATUS_PURCHASE = 'Paid');
	SET totalPurchaseYear = (SELECT IF(SUM(GRAND_TOTAL_PURCHASE) IS NULL, 0, SUM(GRAND_TOTAL_PURCHASE))
							 FROM PURCHASE_TRANSACTION
							 WHERE substring(ID_PURCHASE, 5, 2) = 
							(SELECT date_format(now(), '%y')) 
							 AND PAYMENT_STATUS_PURCHASE = 'Paid');
                             
    IF upper(input) = "MONTH" THEN 
       RETURN (totalSalesMonth - totalPurchaseMonth); 
    ELSEIF upper(input) = 'YEAR' THEN
        RETURN (totalSalesYear - totalPurchaseYear); 
    END IF;
END $$
DELIMITER ; 
SELECT fProfit('month'); 

/*================================================================*/
/* FUNCTION UNTUK MENGHITUNG JUMLAH SALES PER MONTH/YEAR          */
/*================================================================*/
DROP FUNCTION IF EXISTS fTotalSales;
DELIMITER $$
CREATE FUNCTION fTotalSales(input VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF upper(input) = "MONTH" THEN 
		RETURN (SELECT ifnull(count(ID_SALES), 0)
				FROM SALES_TRANSACTION
				WHERE substring(ID_SALES, 5, 4) = date_format(now(), '%y%m')
				); 
    ELSEIF upper(input) = 'YEAR' THEN
        RETURN (SELECT ifnull(count(ID_SALES), 0)
			    FROM SALES_TRANSACTION
			    WHERE substring(ID_SALES, 5, 2) = date_format(now(), '%y')
                ); 
    END IF;
END $$
DELIMITER ; 
SELECT fTotalSales('month'); 

/*================================================================*/
/* FUNCTION UNTUK MENGHITUNG JUMLAH PURCHASE PER MONTH/YEAR       */
/*================================================================*/
DROP FUNCTION IF EXISTS fTotalPurchase;
DELIMITER $$
CREATE FUNCTION fTotalPurchase(input VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF upper(input) = "MONTH" THEN 
        RETURN (SELECT ifnull(count(ID_PURCHASE), 0)
			    FROM PURCHASE_TRANSACTION
			    WHERE substring(ID_PURCHASE, 5, 4) = date_format(now(), '%y%m')
				); 
    ELSEIF upper(input) = 'YEAR' THEN
        RETURN (SELECT ifnull(count(ID_PURCHASE), 0)
			    FROM PURCHASE_TRANSACTION
			    WHERE substring(ID_PURCHASE, 5, 2) = date_format(now(), '%y')
				); 
    END IF;
END $$
DELIMITER ; 
SELECT fTotalPurchase('year'); 

/*================================================================*/
/* FUNCTION UNTUK MENGHITUNG JUMLAH ITEM TERJUAL PER MONTH/YEAR   */
/*================================================================*/
DROP FUNCTION IF EXISTS fTotalItemSold;
DELIMITER $$
CREATE FUNCTION fTotalItemSold(input VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF upper(input) = "MONTH" THEN 
        RETURN (SELECT sum(QUANTITY_DETAILSALES)
		 	    FROM DETAIL_SALES_TRANSACTION
			    WHERE substring(ID_SALES, 5, 4) = date_format(now(), '%y%m')
                ); 
    ELSEIF upper(input) = 'YEAR' THEN
        RETURN (SELECT sum(QUANTITY_DETAILSALES)
			    FROM DETAIL_SALES_TRANSACTION
			    WHERE substring(ID_SALES, 5, 2) = date_format(now(), '%y')
                ); 
    END IF;
END $$
DELIMITER ; 
SELECT fTotalItemSold('year'); 

/*==============================================================*/
/* FUNCTION FOR GENERATE ID CUSTOMER                            */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdCustomer;
DELIMITER $$
CREATE FUNCTION fGenerateIdCustomer()
RETURNS VARCHAR(5) 
READS SQL DATA
BEGIN
	DECLARE nextidcustomer INT;
    DECLARE idcustomer VARCHAR(5);
    
    SELECT CONVERT(IFNULL(SUBSTRING(ID_CUSTOMER,2,4),0), UNSIGNED) + 1 INTO nextidcustomer
	FROM MASTER_CUSTOMER
	ORDER BY 1 DESC
	LIMIT 1;
    
    SET idcustomer = CONCAT('C', lpad(nextidcustomer,4,'0'));
    RETURN idcustomer;
END $$
DELIMITER ;
SELECT fGenerateIdCustomer();

/*==============================================================*/
/* FUNCTION FOR GENERATE ID SUPPLIER                            */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdSupplier;
DELIMITER $$
CREATE FUNCTION fGenerateIdSupplier()
RETURNS VARCHAR(4) 
READS SQL DATA
BEGIN
	DECLARE nextidsupplier INT;
    DECLARE idsupplier VARCHAR(5);
    
    SELECT CONVERT(IFNULL(SUBSTRING(ID_SUPPLIER,3,2),0), UNSIGNED) + 1 INTO nextidsupplier
	FROM MASTER_SUPPLIER
	ORDER BY 1 DESC
	LIMIT 1;
    
    SET idsupplier = CONCAT('SP', lpad(nextidsupplier,2,'0'));
    RETURN idsupplier;
END $$
DELIMITER ;
SELECT fGenerateIdSupplier();

/*==============================================================*/
/* FUNCTION FOR GENERATE ID PURCHASE                            */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdPurchase;
DELIMITER $$
CREATE FUNCTION fGenerateIdPurchase(purchasedate VARCHAR(6))
RETURNS VARCHAR(11)
READS SQL DATA
BEGIN
	DECLARE idpurchase VARCHAR(11);
	
	SELECT CONVERT(IFNULL(SUBSTRING(ID_PURCHASE,9,3),0), UNSIGNED) + 1 INTO idpurchase
    FROM PURCHASE_TRANSACTION 
	WHERE SUBSTRING(ID_PURCHASE,3,6) = purchasedate
	ORDER BY 1 DESC
	LIMIT 1;
    
    IF idpurchase IS NULL THEN
		RETURN CONCAT('PT', purchasedate, '001');
	ELSE
		RETURN CONCAT('PT', purchasedate, LPAD(idpurchase,3,'0'));
    END IF;
END $$
DELIMITER ;
SELECT fGenerateIdPurchase('202412');

/*==============================================================*/
/* FUNCTION FOR GENERATE ID SALES                            */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdSales;
DELIMITER $$
CREATE FUNCTION fGenerateIdSales(salesdate VARCHAR(6))
RETURNS VARCHAR(11)
READS SQL DATA
BEGIN
	DECLARE idsales VARCHAR(11);
	
	SELECT CONVERT(IFNULL(SUBSTRING(ID_SALES,9,3),0), UNSIGNED) + 1 INTO idsales
    FROM SALES_TRANSACTION 
	WHERE SUBSTRING(ID_SALES,3,6) = salesdate
	ORDER BY 1 DESC
	LIMIT 1;
    
    IF idsales IS NULL THEN
		RETURN CONCAT('ST', salesdate, '001');
	ELSE
		RETURN CONCAT('ST', salesdate, LPAD(idsales,3,'0'));
    END IF;
END $$
DELIMITER ;
SELECT fGenerateIdSales('202309');

/*==============================================================*/
/* FUNCTION FOR GENERATE ID PURCHASE PRICE HISTORY              */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdPurchasePriceHistory;
DELIMITER $$
CREATE FUNCTION fGenerateIdPurchasePriceHistory(purchasepricehistorydate VARCHAR(4))
RETURNS VARCHAR(9)
READS SQL DATA
BEGIN
	DECLARE idpurchasepricehistory VARCHAR(9);
	
	SELECT CONVERT(IFNULL(SUBSTRING(ID_PURCHASEPRICEHISTORY,7,3),0), UNSIGNED) + 1 INTO idpurchasepricehistory
    FROM PURCHASE_PRICE_HISTORY 
	WHERE SUBSTRING(ID_PURCHASEPRICEHISTORY,3,4) = purchasepricehistorydate
	ORDER BY 1 DESC
	LIMIT 1;
    
    IF idpurchasepricehistory IS NULL THEN
		RETURN CONCAT('PH', purchasepricehistorydate, '001');
	ELSE
		RETURN CONCAT('PH', purchasepricehistorydate, LPAD(idpurchasepricehistory,3,'0'));
    END IF;
END $$
DELIMITER ;
SELECT fGenerateIdPurchasePriceHistory('2023');

/*==============================================================*/
/* FUNCTION FOR GENERATE ID SALES PRICE HISTORY                 */
/*==============================================================*/
DROP FUNCTION IF EXISTS fGenerateIdSalesPriceHistory;
DELIMITER $$
CREATE FUNCTION fGenerateIdSalesPriceHistory(salespricehistorydate VARCHAR(4))
RETURNS VARCHAR(9)
READS SQL DATA
BEGIN
	DECLARE idsalespricehistory VARCHAR(9);
	
	SELECT CONVERT(IFNULL(SUBSTRING(ID_SALESPRICEHISTORY,7,3),0), UNSIGNED) + 1 INTO idsalespricehistory
    FROM SALES_PRICE_HISTORY 
	WHERE SUBSTRING(ID_SALESPRICEHISTORY,3,4) = salespricehistorydate
	ORDER BY 1 DESC
	LIMIT 1;
    
    IF idsalespricehistory IS NULL THEN
		RETURN CONCAT('SH', salespricehistorydate, '001');
	ELSE
		RETURN CONCAT('SH', salespricehistorydate, LPAD(idsalespricehistory,3,'0'));
    END IF;
END $$
DELIMITER ;
SELECT fGenerateIdSalesPriceHistory('2024');

/*==============================================================*/
/* FUNCTION FOR CHECK STOCK (SALES TRANSACTION)                 */
/*==============================================================*/
DROP FUNCTION IF EXISTS fCekStock;
DELIMITER $$
CREATE FUNCTION fCekStock(idbarang VARCHAR(10), qty INT)
RETURNS VARCHAR(50)
READS SQL DATA 
BEGIN
    IF (SELECT IF(qty < STOCK_ITEM, 'Stock Cukup','Stock Kurang') FROM MASTER_ITEM WHERE ID_ITEM = idbarang) = 'Stock Kurang' THEN
    RETURN CONCAT('Stock ', idbarang, ' kurang'); 
    END IF;
END $$
DELIMITER ; 
SELECT fCekStock('HI001R', 10); 

/*==============================================================*/
/* FUNCTION FOR TOTAL ITEM (MASTER ITEM)                        */
/*==============================================================*/
DROP FUNCTION IF EXISTS fTotalItem;
DELIMITER $$
CREATE FUNCTION fTotalItem()
RETURNS VARCHAR(20)
READS SQL DATA 
BEGIN
	RETURN CONCAT((SELECT count(ID_ITEM) 
			FROM MASTER_ITEM
			WHERE STATUS_DEL_ITEM = 0
			), ' Item');
END $$
DELIMITER ; 
SELECT fTotalItem();

/*==============================================================*/
/* FUNCTION FOR TOTAL ITEM LOW STOCK                            */
/*==============================================================*/
DROP FUNCTION IF EXISTS fItemLow;
DELIMITER $$
CREATE FUNCTION fItemLow()
RETURNS VARCHAR(20)
READS SQL DATA 
BEGIN
    RETURN CONCAT((SELECT COUNT(ID_ITEM)
			FROM MASTER_ITEM
			WHERE STOCK_ITEM <= MINIMUM_STOCK_ITEM AND STOCK_ITEM != 0 AND STATUS_DEL_ITEM = 0
			), ' Item');
END $$
DELIMITER ; 
SELECT fItemLow();

/*==============================================================*/
/* FUNCTION FOR TOTAL ITEM OUT OF STOCK (MASTER ITEM)           */
/*==============================================================*/
DROP FUNCTION IF EXISTS fItemOutOfStock;
DELIMITER $$
CREATE FUNCTION fItemOutOfStock()
RETURNS VARCHAR(20)
READS SQL DATA 
BEGIN
        RETURN CONCAT((SELECT count(ID_ITEM)
				FROM MASTER_ITEM
				WHERE STOCK_ITEM = 0 AND STATUS_DEL_ITEM = 0
                 ), ' Item');
END $$
DELIMITER ; 
SELECT fItemOutOfStock();

/*============================================================================*/
/* FUNCTION FOR TOTAL PURCHASE TRANSACTION PER MONTH / YEAR (PURCHASE REPORT) */
/*============================================================================*/
DROP FUNCTION IF EXISTS fTotalPurchaseTransReport;
DELIMITER $$
CREATE FUNCTION fTotalPurchaseTransReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT IFNULL(COUNT(ID_PURCHASE), 0)
		  	    FROM PURCHASE_TRANSACTION
		 	    WHERE SUBSTRING(ID_PURCHASE, 5, 4) = input); 
    ELSEIF upper(tanggal) = 'YEAR' THEN
        RETURN (SELECT ifnull(count(ID_PURCHASE), 0)
			    FROM PURCHASE_TRANSACTION
			    WHERE substring(ID_PURCHASE, 5, 2) = input); 
	ELSEIF upper(tanggal) = 'ALL' THEN
			RETURN (SELECT ifnull(count(ID_PURCHASE), 0)
					FROM PURCHASE_TRANSACTION);
    END IF;
END $$
DELIMITER ; 
SELECT fTotalPurchaseTransReport('23', 'year'); 

/*================================================================*/
/* FUNCTION FOR TOTAL PURCHASE PER MONTH / YEAR (PURCHASE REPORT) */
/*================================================================*/
DROP FUNCTION IF EXISTS fTotalPurchaseReport;
DELIMITER $$
CREATE FUNCTION fTotalPurchaseReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS VARCHAR(25)
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0), 2))
			    FROM PURCHASE_TRANSACTION
			    WHERE SUBSTRING(ID_PURCHASE, 5, 4) = input AND PAYMENT_STATUS_PURCHASE = 'Paid'); 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0), 2))
		 	    FROM PURCHASE_TRANSACTION
			    WHERE SUBSTRING(ID_PURCHASE, 5, 2) = input AND PAYMENT_STATUS_PURCHASE = 'Paid'); 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
			RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_PURCHASE), 0), 2))
					FROM PURCHASE_TRANSACTION WHERE PAYMENT_STATUS_PURCHASE = 'Paid');
    END IF;
END $$
DELIMITER ; 
SELECT fTotalPurchaseReport('', 'all'); 

/*====================================================================*/
/* FUNCTION FOR TOTAL PURCHASE ITEM PER MONTH / YEAR (PURCHASE REPORT)*/
/*====================================================================*/
DROP FUNCTION IF EXISTS fTotalItemSoldPurchaseReport;
DELIMITER $$
CREATE FUNCTION fTotalItemSoldPurchaseReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0)
			    FROM DETAIL_PURCHASE_TRANSACTION
			    WHERE SUBSTRING(ID_PURCHASE, 5, 4) = input); 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0)
			    FROM DETAIL_PURCHASE_TRANSACTION
			    WHERE SUBSTRING(ID_PURCHASE, 5, 2) = input); 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
			RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILPURCHASE), 0)
					FROM DETAIL_PURCHASE_TRANSACTION);
    END IF;
END $$
DELIMITER ; 
SELECT fTotalItemSoldPurchaseReport('23', 'year'); 

/*============================================================================*/
/* FUNCTION FOR TOTAL SALES TRANSACTION PER MONTH / YEAR (SALES REPORT)       */
/*============================================================================*/
DROP FUNCTION IF EXISTS fTotalSalesTransReport;
DELIMITER $$
CREATE FUNCTION fTotalSalesTransReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT IFNULL(COUNT(ID_SALES), 0)
		  	    FROM SALES_TRANSACTION
		 	    WHERE SUBSTRING(ID_SALES, 5, 4) = input); 
    ELSEIF upper(tanggal) = 'YEAR' THEN
        RETURN (SELECT ifnull(count(ID_SALES), 0)
			    FROM SALES_TRANSACTION
			    WHERE substring(ID_SALES, 5, 2) = input); 
	ELSEIF upper(tanggal) = 'ALL' THEN
			RETURN (SELECT ifnull(count(ID_SALES), 0)
					FROM SALES_TRANSACTION);
    END IF;
END $$
DELIMITER ; 
SELECT fTotalSalesTransReport('23', 'year'); 

/*================================================================*/
/* FUNCTION FOR TOTAL SALES PER MONTH / YEAR (SALES REPORT)       */
/*================================================================*/
DROP FUNCTION IF EXISTS fTotalSalesReport;
DELIMITER $$
CREATE FUNCTION fTotalSalesReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS VARCHAR(25)
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES), 0), 2))
			    FROM SALES_TRANSACTION
			    WHERE SUBSTRING(ID_SALES, 5, 4) = input AND PAYMENT_STATUS_SALES = 'Paid'); 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES), 0), 2))
		 	    FROM SALES_TRANSACTION
			    WHERE SUBSTRING(ID_SALES, 5, 2) = input AND PAYMENT_STATUS_SALES = 'Paid'); 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
			RETURN (SELECT CONCAT('Rp ', FORMAT(IFNULL(SUM(GRAND_TOTAL_SALES), 0), 2))
					FROM SALES_TRANSACTION WHERE PAYMENT_STATUS_SALES = 'Paid');
    END IF;
END $$
DELIMITER ; 
SELECT fTotalSalesReport('', 'all'); 

/*====================================================================*/
/* FUNCTION FOR TOTAL SALES ITEM PER MONTH / YEAR (SALES REPORT)      */
/*====================================================================*/
DROP FUNCTION IF EXISTS fTotalItemSoldSalesReport;
DELIMITER $$
CREATE FUNCTION fTotalItemSoldSalesReport(input VARCHAR(4), tanggal VARCHAR(5))
RETURNS INT
READS SQL DATA 
BEGIN
    IF UPPER(tanggal) = "MONTH" THEN 
        RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILSALES), 0)
			    FROM DETAIL_SALES_TRANSACTION
			    WHERE SUBSTRING(ID_SALES, 5, 4) = input); 
    ELSEIF UPPER(tanggal) = 'YEAR' THEN
        RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILSALES), 0)
			    FROM DETAIL_SALES_TRANSACTION
			    WHERE SUBSTRING(ID_SALES, 5, 2) = input); 
	ELSEIF UPPER(tanggal) = 'ALL' THEN
			RETURN (SELECT IFNULL(SUM(QUANTITY_DETAILSALES), 0)
					FROM DETAIL_SALES_TRANSACTION);
    END IF;
END $$
DELIMITER ; 

SELECT fTotalItemSoldSalesReport('23', 'year'); 
/*==============================================================================*/
/* FUNCTION FOR CHECK STOCK OPNAME DATE (STOCK OPNAME)  */
/*==============================================================================*/
DROP FUNCTION IF EXISTS fCheckStockDateAdd;
DELIMITER $$
CREATE FUNCTION fCheckStockDateAdd()
RETURNS VARCHAR(15)
READS SQL DATA
BEGIN
    DECLARE laststockopname VARCHAR(20);
    DECLARE todaydate VARCHAR(20);
    
    SELECT SUBSTRING(DATE_STOCKOPNAME,1,10) INTO laststockopname FROM STOCK_OPNAME ORDER BY 1 DESC LIMIT 1;
    SELECT SUBSTRING(NOW(),1,10) INTO todaydate;
    IF(laststockopname = todaydate) THEN
		RETURN "NOT ALLOWED";
	ELSE
		RETURN "ALLOWED";
	END IF;
END $$
DELIMITER ;

SELECT fCheckStockDateAdd();

/*==============================================================================*/
/* FUNCTION FOR CHECK LAST TRANSACTION DATE BEFORE STOCK OPNAME (STOCK OPNAME)  */
/*==============================================================================*/
DROP FUNCTION IF EXISTS fCheckStockDate;
DELIMITER $$
CREATE FUNCTION fCheckStockDate()
RETURNS VARCHAR(15)
READS SQL DATA
BEGIN
	DECLARE lastpurchasedate TIMESTAMP;
    DECLARE lastsalesdate TIMESTAMP;
    DECLARE laststockopname TIMESTAMP;
    
    SELECT TRANSACTION_DATE_PURCHASE INTO lastpurchasedate FROM PURCHASE_TRANSACTION ORDER BY 1 DESC LIMIT 1;
    SELECT TRANSACTION_DATE_SALES INTO lastsalesdate FROM SALES_TRANSACTION ORDER BY 1 DESC LIMIT 1;
    SELECT DATE_STOCKOPNAME INTO laststockopname FROM STOCK_OPNAME ORDER BY 1 DESC LIMIT 1;
    
    IF(lastpurchasedate >= laststockopname) OR (lastsalesdate >= laststockopname) THEN
		RETURN "NOT ALLOWED";
	ELSE
		RETURN "ALLOWED";
	END IF;
END $$
DELIMITER ;

SELECT fCheckStockDate();

SELECT TRANSACTION_DATE_PURCHASE FROM PURCHASE_TRANSACTION ORDER BY 1 DESC LIMIT 1;
SELECT TRANSACTION_DATE_SALES FROM SALES_TRANSACTION ORDER BY 1 DESC LIMIT 1;

SELECT DATE_STOCKOPNAME FROM STOCK_OPNAME ORDER BY 1 DESC LIMIT 1;

SELECT ID_STOCKOPNAME FROM STOCK_OPNAME WHERE DATE_FORMAT(DATE_STOCKOPNAME, '%d %M %Y') = '29 December 2024' AND ID_ITEM = 'HI001B';
/*==============================================================*/
/* FUNCTION FOR ID STOCK OPNAME WHEN EDIT (EDIT STOCK OPNAME)   */
/*==============================================================*/
DROP FUNCTION IF EXISTS fIDEditStockOpname;
DELIMITER $$
CREATE FUNCTION fIDEditStockOpname(datestockopname VARCHAR(25), itemid VARCHAR(10))
RETURNS INT
READS SQL DATA
BEGIN
	DECLARE idstockopname INT;
    
	SELECT ID_STOCKOPNAME AS `ID SO` INTO idstockopname
    FROM STOCK_OPNAME 
    WHERE DATE_FORMAT(DATE_STOCKOPNAME, '%d %M %Y') = datestockopname AND ID_ITEM = itemid;
    
    RETURN idstockopname;
END $$
DELIMITER ;
SELECT fIDEditStockOpname('29 December 2024', 'HI001B');

/*====================================================================*/
/* 				FUNCTION UNTUK MENGETAHUI JUMLAH ITEM  		          */
/* 			   AWAL DAN AKHIR BULAN BERDASARKAN TANGGAL				  */
/*====================================================================*/
DROP FUNCTION IF EXISTS fStock;
DELIMITER $$
CREATE FUNCTION fStock(ID VARCHAR(10), input VARCHAR(10))
RETURNS varchar(8)
READS SQL DATA 
BEGIN
		RETURN(SELECT 
		STOCK_ITEM + (b.`sales` - d.`purchase` + e.`StockOpname`) AS `Stock di awal bulan`
		FROM
		MASTER_ITEM mi
		LEFT JOIN
			(
				SELECT a.`id` AS `ID`, SUM(a.`total`) AS `purchase`
				FROM(
				SELECT 
					mi.ID_ITEM AS `id`, 
					IF(pt.TRANSACTION_DATE_PURCHASE IS NULL , '0',(dpt.QUANTITY_DETAILPURCHASE)) as `total`
				FROM MASTER_ITEM mi
				LEFT JOIN DETAIL_PURCHASE_TRANSACTION dpt ON dpt.ID_ITEM = mi.ID_ITEM
				LEFT JOIN PURCHASE_TRANSACTION pt ON pt.ID_PURCHASE = dpt.ID_PURCHASE
					AND pt.TRANSACTION_DATE_PURCHASE >= input) as a
				GROUP BY 1
			) d ON d.`ID` = mi.ID_ITEM
		LEFT JOIN
			(
				SELECT c.`id` AS `ID`, SUM(c.`total`) AS `sales`
				FROM(
				SELECT 
					mi.ID_ITEM AS `id`, 
					IF(st.TRANSACTION_DATE_SALES IS NULL , '0',(dst.QUANTITY_DETAILSALES)) as `total`
				FROM MASTER_ITEM mi
				LEFT JOIN DETAIL_SALES_TRANSACTION dst ON dst.ID_ITEM = mi.ID_ITEM
				LEFT JOIN SALES_TRANSACTION st ON st.ID_SALES = dst.ID_SALES
						AND st.TRANSACTION_DATE_SALES >= input) as c
				GROUP BY 1
			) b ON b.`ID` = mi.ID_ITEM
		LEFT JOIN
			(
				SELECT p.`ID` AS `ID`, SUM(p.`stock_difference`) AS `StockOpname`
					FROM(
						SELECT hi.ID_ITEM AS `ID`, 
						IF(DATE_STOCKOPNAME IS NULL, '0',(CAST(SYSTEM_STOCK_ITEM AS SIGNED) - CAST(PHYSICAL_STOCK_STOCKOPNAME AS SIGNED))) AS `stock_difference`
						FROM MASTER_ITEM hi
						LEFT JOIN STOCK_OPNAME so ON so.ID_ITEM = hi.ID_ITEM
						AND DATE_STOCKOPNAME >= input) as p
						GROUP BY 1
			) e ON e.`ID` = mi.ID_ITEM
		WHERE ID_ITEM = ID
		GROUP BY 1);
END $$
DELIMITER ; 

SELECT fStock('HI244Y', '2024-11-01');
SELECT fStockSales('HI244B', '2024-11-01', '2024-12-01');

/*====================================================================*/
/* FUNCTION UNTUK JUMLAH PEMASUKAN ITEM DI BULAN ITU                  */
/*====================================================================*/
DROP FUNCTION IF EXISTS fStockPurchase;
DELIMITER $$
CREATE FUNCTION fStockPurchase(ID VARCHAR(10), input VARCHAR(10), inputlast VARCHAR(10))
RETURNS varchar(8)
READS SQL DATA 
BEGIN
		RETURN (SELECT 
		d.`purchase`
		FROM
		MASTER_ITEM mi
		LEFT JOIN
			(
				SELECT a.`id` AS `ID`, SUM(a.`total`) AS `purchase`
				FROM(
				SELECT 
					mi.ID_ITEM AS `id`, 
					IF(pt.TRANSACTION_DATE_PURCHASE IS NULL , '0',(dpt.QUANTITY_DETAILPURCHASE)) as `total`
				FROM MASTER_ITEM mi
				LEFT JOIN DETAIL_PURCHASE_TRANSACTION dpt ON dpt.ID_ITEM = mi.ID_ITEM
				LEFT JOIN PURCHASE_TRANSACTION pt ON pt.ID_PURCHASE = dpt.ID_PURCHASE
					AND pt.TRANSACTION_DATE_PURCHASE >= input AND pt.TRANSACTION_DATE_PURCHASE < inputlast) as a
				GROUP BY 1
			) d ON d.`ID` = mi.ID_ITEM
		WHERE ID_ITEM = ID
		GROUP BY 1);
END $$
DELIMITER ; 

/*====================================================================*/
/* FUNCTION UNTUK JUMLAH PENGELUARAN ITEM DI BULAN ITU                */
/*====================================================================*/
DROP FUNCTION IF EXISTS fStockSales;
DELIMITER $$
CREATE FUNCTION fStockSales(ID VARCHAR(10), input VARCHAR(10), inputlast VARCHAR(10))
RETURNS varchar(8)
READS SQL DATA 
BEGIN
		RETURN (SELECT 
		b.`sales`
		FROM
		MASTER_ITEM mi
		LEFT JOIN
			(
				SELECT c.`id` AS `ID`, SUM(c.`total`) AS `sales`
				FROM(
				SELECT 
					mi.ID_ITEM AS `id`, 
					IF(st.TRANSACTION_DATE_SALES IS NULL , '0',(dst.QUANTITY_DETAILSALES)) as `total`
				FROM MASTER_ITEM mi
				LEFT JOIN DETAIL_SALES_TRANSACTION dst ON dst.ID_ITEM = mi.ID_ITEM
				LEFT JOIN SALES_TRANSACTION st ON st.ID_SALES = dst.ID_SALES
						AND st.TRANSACTION_DATE_SALES >= input AND st.TRANSACTION_DATE_SALES < inputlast) as c
				GROUP BY 1
			) b ON b.`ID` = mi.ID_ITEM
		WHERE ID_ITEM = ID
		GROUP BY 1);
END $$
DELIMITER ; 

/*=========================================================================================*/
/* FUNCTION UNTUK JUMLAH STOCK OPNAME DI BULAN ITU (- berarti pengurangan + penambahan)    */
/*=========================================================================================*/
DROP FUNCTION IF EXISTS fStockStockOpname;
DELIMITER $$
CREATE FUNCTION fStockStockOpname(ID VARCHAR(10), input VARCHAR(10), inputlast VARCHAR(10))
RETURNS varchar(8)
READS SQL DATA 
BEGIN
		RETURN (SELECT 
		b.`StockOpname`
		FROM
		MASTER_ITEM mi
		LEFT JOIN
			(
				SELECT p.`ID` AS `ID`, SUM(p.`stock_difference`) AS `StockOpname`
					FROM(
						SELECT hi.ID_ITEM AS `ID`, 
						IF(DATE_STOCKOPNAME IS NULL, '0',(CAST(PHYSICAL_STOCK_STOCKOPNAME AS SIGNED) - CAST(SYSTEM_STOCK_ITEM AS SIGNED))) AS `stock_difference`
						FROM MASTER_ITEM hi
						LEFT JOIN STOCK_OPNAME so ON so.ID_ITEM = hi.ID_ITEM
						AND DATE_STOCKOPNAME >= input AND DATE_STOCKOPNAME < inputlast) as p
					GROUP BY 1
			) b ON b.`ID` = mi.ID_ITEM
		WHERE ID_ITEM = ID
		GROUP BY 1);
END $$
DELIMITER ; 

/*==============================================================*/
/* FUNCTION FOR TOTAL ACTIVE CUSTOMER                           */
/*==============================================================*/                          
DROP FUNCTION IF EXISTS fTotalActiveCustomer;
DELIMITER $$
CREATE FUNCTION fTotalActiveCustomer()
RETURNS INT 
READS SQL DATA
BEGIN
	declare jmlcust int;
    
    select count(ID_CUSTOMER) into jmlcust
	from MASTER_CUSTOMER
	where STATUS_DEL_CUSTOMER = 0;
    
    RETURN jmlcust;
END $$
DELIMITER ;
SELECT fTotalActiveCustomer();

/*========================================================*/
/* FUNCTION FOR TOTAL CUSTOMER                            */
/*========================================================*/                           	    
DROP FUNCTION IF EXISTS fTotalCustomer;
DELIMITER $$
CREATE FUNCTION fTotalCustomer()
RETURNS INT 
READS SQL DATA
BEGIN
	declare jmlcust int;
    
    select count(ID_CUSTOMER) into jmlcust
	from MASTER_CUSTOMER;
    
    RETURN jmlcust;
END $$
DELIMITER ;
SELECT fTotalCustomer();

/*============================================*/
/* FUNCTION FOR TOTAL SUPPLIER                */
/*============================================*/                            	    
DROP FUNCTION IF EXISTS fTotalSupplier;
DELIMITER $$
CREATE FUNCTION fTotalSupplier()
RETURNS INT 
READS SQL DATA
BEGIN
	declare jmlsup int;
    
    select count(ID_SUPPLIER) into jmlsup
	from MASTER_SUPPLIER;
    
    RETURN jmlsup;
END $$
DELIMITER ;
SELECT fTotalSupplier();

/*============================================*/
/* FUNCTION FOR TOTAL ACTIVE SUPPLIER         */
/*============================================*/                  
DROP FUNCTION IF EXISTS fTotalActiveSupplier;
DELIMITER $$
CREATE FUNCTION fTotalActiveSupplier()
RETURNS INT 
READS SQL DATA
BEGIN
	declare jmlsup int;
    
    select count(ID_SUPPLIER) into jmlsup
	from MASTER_SUPPLIER
    where STATUS_DEL_SUPPLIER = 0;
    
    RETURN jmlsup;
END $$
DELIMITER ;
SELECT fTotalActiveSupplier();

/*=====================================================*/
/* FUNCTION FOR DIGIT TERAKHIR DETAIL PURCHASE         */
/*=====================================================*/   
DROP FUNCTION IF EXISTS fDigitTerakhirDetailPurchase;
DELIMITER $$
CREATE FUNCTION fDigitTerakhirDetailPurchase()
RETURNS INT 
READS SQL DATA
BEGIN
	declare digit int;
    
    select max(ID_DETAIL_PURCHASE) into digit
    from DETAIL_PURCHASE_TRANSACTION;
    
    RETURN digit;
END $$
DELIMITER ;

SELECT fDigitTerakhirDetailPurchase();

/*=====================================================*/
/* FUNCTION FOR DIGIT TERAKHIR DETAIL SALES            */
/*=====================================================*/                   
DROP FUNCTION IF EXISTS fDigitTerakhirDetailSales;
DELIMITER $$
CREATE FUNCTION fDigitTerakhirDetailSales()
RETURNS INT 
READS SQL DATA
BEGIN
	declare digit int;

    select max(ID_DETAIL_SALES) into digit
    from DETAIL_SALES_TRANSACTION;
    
    RETURN digit;
END $$
DELIMITER ;

SELECT fDigitTerakhirDetailSales();