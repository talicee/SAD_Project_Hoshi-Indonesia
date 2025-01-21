/*====================================================================*/
/* TRIGGER FOR UPDATE STOCK IN ADD PURCHASE TRANSACTION               */
/*====================================================================*/
DROP TRIGGER IF EXISTS tUpdateStockPurchaseTransactionAdd;
DELIMITER ~~
CREATE TRIGGER tUpdateStockPurchaseTransactionAdd
AFTER INSERT 
ON STOCK_OPNAME FOR EACH ROW
BEGIN
    UPDATE MASTER_ITEM
    SET STOCK_ITEM = NEW.PHYSICAL_STOCK_STOCKOPNAME
    WHERE ID_ITEM = NEW.ID_ITEM;
END ~~
DELIMITER ;

/*====================================================================*/
/* TRIGGER FOR UPDATE STOCK IN EDIT PURCHASE TRANSACTION               */
/*====================================================================*/
DROP TRIGGER IF EXISTS tUpdateStockPurchaseTransactionEdit;
DELIMITER $$
CREATE TRIGGER tPurchaseEdit
BEFORE UPDATE ON DETAIL_PURCHASE_TRANSACTION 
FOR EACH ROW
BEGIN
	DECLARE stock_master INT;
    DECLARE stock_berkurang INT;
    DECLARE stock_bertambah INT;

	SELECT STOCK_ITEM INTO stock_master
	FROM MASTER_ITEM
	WHERE ID_ITEM = NEW.ID_ITEM;
    
	IF NEW.QUANTITY_DETAILPURCHASE > OLD.QUANTITY_DETAILPURCHASE THEN
      SET stock_bertambah = NEW.QUANTITY_DETAILPURCHASE - OLD.QUANTITY_DETAILPURCHASE;
		UPDATE MASTER_ITEM
		SET STOCK_ITEM = STOCK_ITEM + stock_bertambah
		WHERE ID_ITEM = NEW.ID_ITEM;
        
	ELSEIF NEW.QUANTITY_DETAILPURCHASE < OLD.QUANTITY_DETAILPURCHASE THEN
      SET stock_berkurang = OLD.QUANTITY_DETAILPURCHASE - NEW.QUANTITY_DETAILPURCHASE;
      IF (stock_master - stock_berkurang < 0) THEN
		SIGNAL SQLSTATE '45000' 
           SET MESSAGE_TEXT = 'Insufficient stock', MYSQL_ERRNO = 1001;
           -- SET MESSAGE_TEXT = CONCAT('Insufficient stock for ', NEW.ID_ITEM, '. Available: ', stock_master), MYSQL_ERRNO = 1001;
	  ELSE
		  UPDATE MASTER_ITEM
		  SET STOCK_ITEM = STOCK_ITEM - stock_berkurang
		  WHERE ID_ITEM = NEW.ID_ITEM;
	  END IF;
	END IF;
END $$
DELIMITER ;

UPDATE DETAIL_PURCHASE_TRANSACTION
SET QUANTITY_DETAILPURCHASE = 50
WHERE ID_DETAIL_PURCHASE = 1 AND ID_ITEM = "HI001R";
  
/*SELECT ID_ITEM, STOCK_ITEM FROM MASTER_ITEM
WHERE ID_ITEM = "HI001R";
SELECT ID_DETAIL_PURCHASE, ID_ITEM, QUANTITY_DETAILPURCHASE FROM DETAIL_PURCHASE_TRANSACTION
WHERE ID_DETAIL_PURCHASE = 1;*/

/*====================================================================*/
/* TRIGGER FOR UPDATE STOCK IN ADD SALES TRANSACTION                  */
/*====================================================================*/
DROP TRIGGER IF EXISTS tUpdateStockSalesTransaction;
DELIMITER $$
CREATE TRIGGER tUpdateStockSalesTransaction
BEFORE INSERT ON DETAIL_SALES_TRANSACTION
FOR EACH ROW
BEGIN
    UPDATE MASTER_ITEM
    SET STOCK_ITEM = STOCK_ITEM - NEW.QUANTITY_DETAILSALES
    WHERE ID_ITEM = NEW.ID_ITEM;
END $$
DELIMITER ;

/*====================================================================*/
/* TRIGGER FOR UPDATE STOCK IN EDIT SALES TRANSACTION                 */
/*====================================================================*/
DROP TRIGGER IF EXISTS tUpdateStockSalesTransactionEdit;
DELIMITER $$
CREATE TRIGGER tUpdateStockSalesTransactionEdit
BEFORE UPDATE ON DETAIL_SALES_TRANSACTION
FOR EACH ROW
BEGIN
	DECLARE stock_master INT;
    DECLARE stock_berkurang INT;
    DECLARE stock_bertambah INT;

	SELECT STOCK_ITEM INTO stock_master
	FROM MASTER_ITEM
	WHERE ID_ITEM = NEW.ID_ITEM;
    
	IF NEW.QUANTITY_DETAILSALES > OLD.QUANTITY_DETAILSALES THEN
      SET stock_berkurang = NEW.QUANTITY_DETAILSALES - OLD.QUANTITY_DETAILSALES;
      IF (stock_master - stock_berkurang < 0) THEN
		SIGNAL SQLSTATE '45000' 
           SET MESSAGE_TEXT = 'Insufficient stock', MYSQL_ERRNO = 1001;
           -- SET MESSAGE_TEXT = CONCAT('Insufficient stock for ', NEW.ID_ITEM, '. Available: ', stock_master), MYSQL_ERRNO = 1001;
	  ELSE
		UPDATE MASTER_ITEM
		SET STOCK_ITEM = STOCK_ITEM - stock_berkurang
		WHERE ID_ITEM = NEW.ID_ITEM;
      END IF;
	ELSEIF NEW.QUANTITY_DETAILSALES < OLD.QUANTITY_DETAILSALES THEN
      set stock_bertambah = OLD.QUANTITY_DETAILSALES - NEW.QUANTITY_DETAILSALES;
	  UPDATE MASTER_ITEM
	  SET STOCK_ITEM = STOCK_ITEM + stock_bertambah
	  WHERE ID_ITEM = NEW.ID_ITEM;
    END IF;
END $$
DELIMITER ;

UPDATE DETAIL_SALES_TRANSACTION
SET QUANTITY_DETAILSALES = 10
WHERE ID_DETAIL_SALES = 1 AND ID_ITEM = "HI001R";
  
/*SELECT ID_ITEM, STOCK_ITEM FROM MASTER_ITEM
WHERE ID_ITEM = "HI001R";
SELECT ID_DETAIL_SALES, ID_ITEM, QUANTITY_DETAILSALES FROM DETAIL_SALES_TRANSACTION
WHERE ID_DETAIL_SALES = 1;*/

/*====================================================================*/
/* TRIGGER FOR INSERT NEW SUPPLIER                                    */
/*====================================================================*/
DROP TRIGGER IF EXISTS tInsertNewSupplier;
DELIMITER $$
CREATE TRIGGER tInsertNewSupplier
BEFORE INSERT ON MASTER_SUPPLIER
FOR EACH ROW
BEGIN
	SET NEW.ID_SUPPLIER = fGenerateIdSupplier();
    SET NEW.STATUS_DEL_SUPPLIER = 0;
END $$
DELIMITER ;
/*INSERT INTO MASTER_SUPPLIER (COMPANY_SUPPLIER, ADDRESS_SUPPLIER, CITY_SUPPLIER, PHONE_NUMBER_SUPPLIER, EMAIL_SUPPLIER, 
							 CONTACT_PERSON_SUPPLIER, TOP_SUPPLIER) VALUES
('PT. Monotaro Plastik Indonesia', 'JL. Jenderal Sudirman No. 10, Jakarta Pusat', 'Jakarta', '081246454232', 
'marketing@monotaroindonesia.com', 'Ibu Alya', '30 Days');*/

/*====================================================================*/
/* TRIGGER FOR INSERT NEW CUSTOMER                                    */
/*====================================================================*/     
DROP TRIGGER IF EXISTS tInsertNewCustomer;
DELIMITER $$
CREATE TRIGGER tInsertNewCustomer
BEFORE INSERT ON MASTER_CUSTOMER
FOR EACH ROW
BEGIN
	SET NEW.ID_CUSTOMER = fGenerateIdCustomer();
    SET NEW.REGISTERED_DATE_CUSTOMER = now();
    SET NEW.STATUS_DEL_CUSTOMER = '0';
END $$
DELIMITER ;
/*INSERT INTO MASTER_CUSTOMER (INSTANCE_CUSTOMER, ADDRESS_CUSTOMER, CITY_CUSTOMER, PHONE_NUMBER_CUSTOMER, 
							 EMAIL_CUSTOMER, CONTACT_PERSON_CUSTOMER, TOP_CUSTOMER) VALUES
('PT. Prima Indo', 'Jl. Boulevard Raya No. 22, Jakarta Selatan', 'Jakarta', '081234567890', 'ayu01@primaindo.com', 'Ayu Wulandari', 'Cash');*/

/*====================================================================*/
/* TRIGGER FOR INSERT NEW ITEM                                        */
/*====================================================================*/
SELECT * FROM MASTER_ITEM;
DROP TRIGGER IF EXISTS tInsertNewItem;
DELIMITER $$
CREATE TRIGGER tInsertNewItem
BEFORE INSERT ON MASTER_ITEM
FOR EACH ROW
BEGIN
	SET NEW.STOCK_ITEM = 0;
    SET NEW.MINIMUM_STOCK_ITEM = 10;
    SET NEW.STATUS_DEL_ITEM = 0;
END $$
DELIMITER ;
/*INSERT INTO MASTER_ITEM (ID_ITEM, NAME_ITEM, COLOUR_ITEM, SIZE_ITEM, CATEGORY_ITEM, SALES_PRICE_ITEM, PURCHASE_PRICE_ITEM) VALUES
('HI001RY', 'Plastic Container Type HI001 Red', 'Red', '620 × 430 × 95', 'Container', 30000, 25000);*/

/*====================================================================*/
/* TRIGGER FOR INSERT NEW PURCHASE TRANSACTION                        */
/*====================================================================*/
DROP TRIGGER IF EXISTS tInsertNewPurchaseTransaction;
DELIMITER $$
CREATE TRIGGER tInsertNewPurchaseTransaction
BEFORE INSERT ON PURCHASE_TRANSACTION
FOR EACH ROW
BEGIN
    SET NEW.ID_PURCHASE = fGenerateIdPurchase(DATE_FORMAT(CURRENT_DATE, '%Y%m'));
	SET NEW.TRANSACTION_DATE_PURCHASE = now();
    SET NEW.STATUS_DEL_PURCHASE = 0;
END $$
DELIMITER ;
/*INSERT INTO PURCHASE_TRANSACTION (ID_SUPPLIER, NAME_SUPPLIER, ADDRESS_SUPPLIER, CITY_SUPPLIER, INVOICE_SUPPLIER_PURCHASE,
								  TOP_SUPPLIER, DUE_DATE_PAYMENT_PURCHASE, PAYMENT_STATUS_PURCHASE, GRAND_TOTAL_PURCHASE) VALUES
('SP02', 'PT. Monotaro Plastik Indonesia', 'JL. Jenderal Sudirman No. 10, Jakarta Pusat', 'Jakarta', 'INV-A001', 
'30 Days', '2023-10-31', 'Paid', 4850000);*/

/*====================================================================*/
/* TRIGGER FOR INSERT NEW SALES TRANSACTION                           */
/*====================================================================*/
DROP TRIGGER IF EXISTS tInsertNewSalesTransaction;
DELIMITER $$
CREATE TRIGGER tInsertNewSalesTransaction
BEFORE INSERT ON SALES_TRANSACTION
FOR EACH ROW
BEGIN
    SET NEW.ID_SALES = fGenerateIdSales(DATE_FORMAT(CURRENT_DATE, '%Y%m'));
	SET NEW.TRANSACTION_DATE_SALES = now();
    SET NEW.STATUS_DEL_SALES = 0;
END $$
DELIMITER ;
/*INSERT INTO SALES_TRANSACTION (ID_CUSTOMER, NAME_CUSTOMER, ADDRESS_CUSTOMER, CITY_CUSTOMER, TOP_CUSTOMER, DUE_DATE_PAYMENT_SALES,
							   PAYMENT_STATUS_SALES, GRAND_TOTAL_SALES) VALUES
('C0001', 'PT. Prima Indo', 'Jl. Boulevard Raya No. 22, Jakarta Selatan', 
'Jakarta', 'Cash', '2023-10-10', 'Paid', 2800000);*/

/*=======================================================================================*/
/* TRIGGER FOR STOCK OPNAME ADD, AUTOUPDATE STOCK IN MASTER ITEM BASED ON PHYSICAL STOCK */
/*=======================================================================================*/
DROP TRIGGER IF EXISTS tUpdateStokAdd;
DELIMITER $$
CREATE TRIGGER tUpdateStokAdd
AFTER INSERT ON STOCK_OPNAME FOR EACH ROW
BEGIN
        UPDATE MASTER_ITEM
                SET STOCK_ITEM = NEW.PHYSICAL_STOCK_STOCKOPNAME
        WHERE ID_ITEM = NEW.ID_ITEM;
 END $$
DELIMITER ;

/*========================================================================================*/
/* TRIGGER FOR STOCK OPNAME EDIT, AUTOUPDATE STOCK IN MASTER ITEM BASED ON PHYSICAL STOCK */
/*========================================================================================*/
DROP TRIGGER IF EXISTS tUpdateStokEdit;
DELIMITER $$
CREATE TRIGGER tUpdateStokEdit
BEFORE UPDATE ON STOCK_OPNAME FOR EACH ROW
BEGIN
        UPDATE MASTER_ITEM
                SET STOCK_ITEM = NEW.PHYSICAL_STOCK_STOCKOPNAME
        WHERE ID_ITEM = NEW.ID_ITEM;
 END $$
DELIMITER ;