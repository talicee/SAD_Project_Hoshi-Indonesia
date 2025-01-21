using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALP_Hoshi
{
    internal class Nama
    {

    }

    public static class GlobalData
    {
        public static string Nama = "Owner";
        // 0 -> ADD
        // 1 -> EDIT
        public static int buttonPurchase = 0;

        public static int buttonSales = 0;

        //PURCHASE
        public static string purchaseId;
        public static string transactionDate;
        public static string supplierId;
        public static string supplierName;
        public static string supplierAddress;
        public static string supplierCity;
        public static string supplierInvoice;
        public static string top;
        public static string dueDate;
        public static string paymentStatus;
        public static string grandTotal;

        public static DataTable detaildeliverynote = new DataTable();
        public static DataTable detailinvoice = new DataTable();


        //SALES
        public static string salesId;
        public static string transactionDateSales;
        public static string customerId;
        public static string customerName;
        public static string customerAddress;
        public static string customerCity;
        public static string topCustomer;
        public static string dueDatePaymentSales;
        public static string paymentStatusSales;
        public static string grandTotalSales;

        public static DataTable detaildeliverynote_sales = new DataTable();
        public static DataTable detailinvoice_sales = new DataTable();
    }
}
