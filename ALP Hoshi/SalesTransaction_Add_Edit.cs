using iTextSharp.text;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ALP_Hoshi
{
    public partial class SalesTransaction_Add_Edit : Form
    {
        private Menu mainForm;
        public SalesTransaction_Add_Edit(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query;
        string tanggal;
        string digit;
        string detailid;

        DataTable dtCustomer = new DataTable();
        DataTable dtItem = new DataTable();
        DataTable dtDetail = new DataTable(); //buat edit
        DataTable dtDetailAdd = new DataTable(); //buat add      

        private List<string> listcustomer = new List<string>();
        private List<string> listitem = new List<string>();
        private List<string> listdelete = new List<string>();

        List<string> nama = new List<string>();
        List<string> jumlah = new List<string>();
        private void SalesTransaction_Add_Edit_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_detailsales.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");
            CustomerList();
            ItemList();
            listbox_item.BringToFront();

            btn_addedit.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_deleteItem.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_saveTransaction.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back.BackColor = ColorTranslator.FromHtml("#FF9090");


            if (GlobalData.buttonSales == 0) // status ADD
            {
                btn_addedit.Text = "Add Detail";
                btn_saveTransaction.Text = "Save New Transaction";
                DigitTerakhirSales();
                datetime_duedate.Value = datetime_trans.Value;

                DateTime selectedDate = datetime_trans.Value;
                tanggal = selectedDate.ToString("yyyyMM");

                IDSales();

                dtDetailAdd.Columns.Add("Detail Sales ID", typeof(string));
                dtDetailAdd.Columns.Add("Item ID", typeof(string));
                dtDetailAdd.Columns.Add("Item Name", typeof(string));
                dtDetailAdd.Columns.Add("Price / pcs", typeof(string));
                dtDetailAdd.Columns.Add("Quantity", typeof(string));
                dtDetailAdd.Columns.Add("Total", typeof(string));

                dgv_detailsales.DataSource = dtDetailAdd;
                dgv_detailsales.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            else if (GlobalData.buttonSales == 1) // status EDIT
            {
                tb_quantity.Enabled = false;
                tb_pricepcs.Enabled = false;
                tb_itemName.Enabled = false;

                btn_addedit.Text = "Edit Detail";
                btn_saveTransaction.Text = "Save Edited Transaction";

                tb_SalesID.Text = GlobalData.salesId;
                tb_address.Text = GlobalData.customerAddress;
                tb_city.Text = GlobalData.customerCity;
                string grand = GlobalData.grandTotalSales;

                tb_grandTotal.Text = grand;
                tb_customerID.Text = GlobalData.customerId;
                tb_customer.Text = GlobalData.customerName;
                cb_top.Text = GlobalData.topCustomer;
                cb_status.Text = GlobalData.paymentStatusSales;

                string duedate = GlobalData.dueDatePaymentSales;
                string transdate = GlobalData.transactionDateSales;

                DateTime duedateparsed = DateTime.ParseExact(duedate, "dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                datetime_duedate.Value = duedateparsed;

                DateTime transdateparsed = DateTime.ParseExact(transdate, "dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                datetime_trans.Value = transdateparsed;

                DGVDetail();
                dgv_detailsales.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv_detailsales.DataBindingComplete += dgv_detailsales_DataBindingComplete;
        }
        private void dgv_detailsales_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_detailsales.ClearSelection();
        }


        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.sales();
        }

        private void datetime_trans_ValueChanged(object sender, EventArgs e)
        {
            if (cb_top.Text == "Cash")
            {
                datetime_duedate.Value = datetime_trans.Value;
            }
            else if (cb_top.Text == "30 Days")
            {
                datetime_duedate.Value = datetime_trans.Value.AddMonths(1);
            }

            if (GlobalData.buttonSales == 0) //kalo status add
            {
                DateTime selectedDate = datetime_trans.Value;
                tanggal = selectedDate.ToString("yyyyMM");

                IDSales();
            }
        }

        private void CustomerList()
        {
            dtCustomer.Clear();
            listcustomer.Clear();
            query = "select ID, Instance, Address, City, TOP from vMasterCustomer;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtCustomer);
            sqlconnect.Close();

            foreach (DataRow row in dtCustomer.Rows)
            {
                listcustomer.Add(row["Instance"].ToString());
            }
        }

        private void ItemList()
        {
            dtItem.Clear();
            listitem.Clear();
            query = "select ID, Name, `Sales Price`, Stock from vMasterItem;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtItem);
            sqlconnect.Close();

            foreach (DataRow row in dtItem.Rows)
            {
                listitem.Add(row["Name"].ToString());
            }
        }

        private void DGVDetail()
        {
            query = $"SELECT `Detail Sales ID`, `Item ID`, `Item Name`,  REPLACE(FORMAT(`Quantity`,0),',','.') AS `Quantity`, " +
                $"REPLACE(FORMAT(`Price / pcs`,0),',','.') AS `Price / pcs`,REPLACE(FORMAT(`Total`,0),',','.') AS `Total`" +
                $"FROM vDetailSalesTrans\r\nWHERE `Detail Sales ID`IN (\r\n    SELECT ID_DETAIL_SALES\r\n    FROM DETAIL_SALES_TRANSACTION d\r\n    JOIN SALES_TRANSACTION p \r\n    ON p.ID_SALES = d.ID_SALES\r\n    WHERE p.ID_SALES = '{GlobalData.salesId}'\r\n);";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtDetail);
            sqlconnect.Close();

            dgv_detailsales.DataSource = dtDetail;
        }

        public void DigitTerakhirSales()
        {
            query = "SELECT fDigitTerakhirDetailSales();";
            sqlconnect = DatabaseConnection.Connection;
            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                digit = result != null ? result.ToString() : "No data found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlconnect.Close();
            }
        }

        public void IDSales()
        {
            query = "SELECT fGenerateIdSales(@tanggal);";
            sqlconnect = DatabaseConnection.Connection;
            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@tanggal", tanggal);
                object result = sqlcommand.ExecuteScalar();
                tb_SalesID.Text = result != null ? result.ToString() : "No data found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlconnect.Close();
            }
        }

        private void AddTransactionSales()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                INSERT INTO SALES_TRANSACTION (
                    ID_SALES,
                    TRANSACTION_DATE_SALES,
                    ID_CUSTOMER,
                    NAME_CUSTOMER,
                    ADDRESS_CUSTOMER,
                    CITY_CUSTOMER,
                    TOP_CUSTOMER,
                    DUE_DATE_PAYMENT_SALES,
                    PAYMENT_STATUS_SALES,
                    GRAND_TOTAL_SALES,
                    STATUS_DEL_SALES
                ) VALUES (
                    @SalesID,
                    @TransactionDate,
                    @CustomerID,
                    @CustomerName,
                    @CustomerAddress,
                    @CustomerCity,
                    @Top,
                    @DueDatePayment,
                    @PaymentStatus,
                    @GrandTotal,
                    @Status
                );";
            string a = tb_grandTotal.Text;
            MessageBox.Show(a);
            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@SalesID", tb_SalesID.Text);
                command.Parameters.AddWithValue("@TransactionDate", datetime_trans.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@CustomerID", tb_customerID.Text);
                command.Parameters.AddWithValue("@CustomerName", tb_customer.Text);
                command.Parameters.AddWithValue("@CustomerAddress", tb_address.Text);
                command.Parameters.AddWithValue("@CustomerCity", tb_city.Text);
                command.Parameters.AddWithValue("@Top", cb_top.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@DueDatePayment", datetime_duedate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@PaymentStatus", cb_status.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@GrandTotal", Convert.ToInt32(a.Replace(".","").Replace(",","")));
                command.Parameters.AddWithValue("@Status", 0);

                command.ExecuteNonQuery();
            }

            sqlconnect.Close();

            tb_customer.Text = "";
            tb_address.Text = "";
            tb_customerID.Text = "";
            tb_city.Text = "";
            cb_top.Text = "";
            cb_status.Text = "";
            tb_grandTotal.Text = "";
        }

        private void AddDetailsSales()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                INSERT INTO DETAIL_SALES_TRANSACTION (
                    ID_SALES,
                    ID_ITEM,
                    NAME_ITEM,
                    SALES_PRICE_ITEM,
                    QUANTITY_DETAILSALES,
                    TOTAL_PRICE_DETAILSALES,
                    STATUS_DEL_DETAILSALES
                ) VALUES (
                    @ID_SALES,
                    @ID_ITEM,
                    @NAME_ITEM,
                    @SALES_PRICE_ITEM,
                    @QUANTITY_DETAILSALES,
                    @TOTAL_PRICE_DETAILSALES,
                    @STATUS_DEL_DETAILSALES
                );";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (DataGridViewRow row in dgv_detailsales.Rows)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_SALES", tb_SalesID.Text);
                    command.Parameters.AddWithValue("@ID_ITEM", row.Cells["Item ID"].Value?.ToString());
                    command.Parameters.AddWithValue("@NAME_ITEM", row.Cells["Item Name"].Value?.ToString());
                    command.Parameters.AddWithValue("@SALES_PRICE_ITEM", Convert.ToInt32(row.Cells["Price / pcs"].Value.ToString().Replace(".", "").Replace(",", "")));
                    command.Parameters.AddWithValue("@QUANTITY_DETAILSALES", Convert.ToInt32(row.Cells["Quantity"].Value.ToString().Replace(".","").Replace(",","")));
                    command.Parameters.AddWithValue("@TOTAL_PRICE_DETAILSALES", Convert.ToInt32(row.Cells["Total"].Value.ToString().Replace(".", "").Replace(",", "")));
                    command.Parameters.AddWithValue("@STATUS_DEL_DETAILSALES", 0);
                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_SalesID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDSales();
        }

        private void EditTransactionSales()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                UPDATE SALES_TRANSACTION
                SET 
                    TRANSACTION_DATE_SALES = @TransactionDate,
                    ID_CUSTOMER = @CustomerID,
                    NAME_CUSTOMER = @CustomerName,
                    ADDRESS_CUSTOMER = @CustomerAddress,
                    CITY_CUSTOMER = @CustomerCity,
                    TOP_CUSTOMER = @Top,
                    DUE_DATE_PAYMENT_SALES = @DueDatePayment,
                    PAYMENT_STATUS_SALES = @PaymentStatus,
                    GRAND_TOTAL_SALES = @GrandTotal,
                    STATUS_DEL_SALES = @Status
                WHERE 
                    ID_SALES = @SalesID;
            ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@SalesID", tb_SalesID.Text);
                command.Parameters.AddWithValue("@TransactionDate", datetime_trans.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@CustomerID", tb_customerID.Text);
                command.Parameters.AddWithValue("@CustomerName", tb_customer.Text);
                command.Parameters.AddWithValue("@CustomerAddress", tb_address.Text);
                command.Parameters.AddWithValue("@CustomerCity", tb_city.Text);
                command.Parameters.AddWithValue("@Top", cb_top.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@DueDatePayment", datetime_duedate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@PaymentStatus", cb_status.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@GrandTotal", Convert.ToInt32(tb_grandTotal.Text.Replace(".", "")));
                command.Parameters.AddWithValue("@Status", 0);

                command.ExecuteNonQuery();
            }

            sqlconnect.Close();

            tb_customerID.Text = "";
            tb_customer.Text = "";
            tb_address.Text = "";
            tb_city.Text = "";
            cb_top.Text = "";
            cb_status.Text = "";
            tb_grandTotal.Text = "";
        }

        private void EditDetailsSales()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                 UPDATE DETAIL_SALES_TRANSACTION
                 SET 
                     NAME_ITEM = @NAME_ITEM,
                     SALES_PRICE_ITEM = @SALES_PRICE_ITEM,
                     QUANTITY_DETAILSALES = @QUANTITY_DETAILSALES,
                     TOTAL_PRICE_DETAILSALES = @TOTAL_PRICE_DETAILSALES
                 WHERE 
                     ID_SALES = @ID_SALES AND
                     ID_ITEM = @ID_ITEM;
             ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (DataGridViewRow row in dgv_detailsales.Rows)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_SALES", tb_SalesID.Text);
                    command.Parameters.AddWithValue("@ID_ITEM", row.Cells["Item ID"].Value?.ToString());
                    command.Parameters.AddWithValue("@NAME_ITEM", row.Cells["Item Name"].Value?.ToString());
                    command.Parameters.AddWithValue("@SALES_PRICE_ITEM", Convert.ToInt32(row.Cells["Price / pcs"].Value.ToString().Replace(".","")));
                    command.Parameters.AddWithValue("@QUANTITY_DETAILSALES", Convert.ToInt32(row.Cells["Quantity"].Value.ToString().Replace(".", "")));
                    command.Parameters.AddWithValue("@TOTAL_PRICE_DETAILSALES", Convert.ToInt32(row.Cells["Total"].Value.ToString().Replace(".", "")));

                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_SalesID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDSales();
        }

        private void DeleteDetails()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                UPDATE DETAIL_SALES_TRANSACTION
                SET 
                    STATUS_DEL_DETAILSALES = 1
                WHERE 
                    ID_DETAIL_SALES = @ID_SALES;
            ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (string idItem in listdelete)
                {
                    MessageBox.Show(idItem);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_SALES", idItem);
                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_SalesID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDSales();
        }

        private void tb_itemID_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                if (dtItem.Rows[i]["ID"].ToString() == tb_itemID.Text)
                {
                    tb_pricepcs.Text = dtItem.Rows[i]["Sales Price"].ToString();
                }
            }
        }

        private void tb_customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            listbox_customer.Visible = true;
            string query = tb_customer.Text.ToLower();
            var filtered = listcustomer
                .Where(item => item.ToLower().Contains(query))
                .ToList();

            listbox_customer.DataSource = filtered;
            listbox_customer.Visible = filtered.Any();
        }

        private void listbox_customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            listbox_customer.Visible = true;
            string query = tb_customer.Text.ToLower();
            var filtered = listcustomer
                .Where(item => item.ToLower().Contains(query))
                .ToList();

            listbox_customer.DataSource = filtered;
            listbox_customer.Visible = filtered.Any();
        }

        private void listbox_customer_MouseClick(object sender, MouseEventArgs e)
        {
            tb_customer.Text = listbox_customer.SelectedItem.ToString();

            for (int i = 0; i < dtCustomer.Rows.Count; i++)
            {
                if (dtCustomer.Rows[i]["Instance"].ToString() == tb_customer.Text)
                {
                    tb_customerID.Text = dtCustomer.Rows[i]["ID"].ToString();
                    tb_address.Text = dtCustomer.Rows[i]["Address"].ToString();
                    tb_city.Text = dtCustomer.Rows[i]["City"].ToString();
                    cb_top.Text = dtCustomer.Rows[i]["TOP"].ToString();
                    break;
                }
            }

            listbox_customer.Visible = false;
        }

        private void listbox_customer_MouseLeave(object sender, EventArgs e)
        {
            listbox_customer.Visible = false;
        }

        private void tb_itemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listitem.Count == 0)
            {
                ItemList();
            }

            listbox_item.Visible = true;
            string query = tb_itemName.Text.ToLower();

            var filtered = listitem
                .Where(item => item.ToLower().Contains(query))
                .ToList();

            listbox_item.DataSource = filtered;
            listbox_item.Visible = filtered.Any();
        }

        private void listbox_item_MouseClick(object sender, MouseEventArgs e)
        {
            tb_itemName.Text = listbox_item.SelectedItem.ToString();

            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                if (dtItem.Rows[i]["Name"].ToString() == tb_itemName.Text)
                {
                    tb_itemID.Text = dtItem.Rows[i]["ID"].ToString();
                }
            }

            listbox_item.Visible = false;
        }

        private void listbox_item_MouseLeave(object sender, EventArgs e)
        {
            listbox_item.Visible = false;
        }

        private void tb_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv_detailsales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_deleteItem.Enabled = true;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GlobalData.buttonSales == 0)
                {
                    tb_itemID.Text = "";
                    tb_itemName.Text = "";
                    tb_pricepcs.Text = "";
                    tb_quantity.Text = "";
                    tb_totalPrice.Text = "";
                }
                else if (GlobalData.buttonSales == 1)
                {
                    tb_quantity.Enabled = true;
                    tb_pricepcs.Enabled = true;
                    tb_itemName.Enabled = false;

                    DataGridViewRow row = dgv_detailsales.Rows[e.RowIndex];

                    tb_itemID.Text = row.Cells["Item ID"].Value.ToString();
                    tb_itemName.Text = row.Cells["Item Name"].Value.ToString();
                    tb_pricepcs.Text = row.Cells["Price / pcs"].Value.ToString();
                    tb_quantity.Text = row.Cells["Quantity"].Value.ToString();
                    tb_totalPrice.Text = row.Cells["Total"].Value.ToString();
                    
                    if(nama.Count > 0)
                    {
                        bool a = false;
                        for (int i = 0; i < nama.Count; i++)
                        {
                            if (nama[i] == tb_itemName.Text)
                            {
                                a = true; break;
                            }
                            
                        }
                        if (a == false)
                        {
                            for (int j = 0; j < dtItem.Rows.Count; j++)
                            {
                                if (dtItem.Rows[j][1].ToString() == tb_itemName.Text)
                                {
                                    nama.Add(tb_itemName.Text);
                                    int aa = Convert.ToInt32(dtItem.Rows[j][3].ToString()) + Convert.ToInt32(tb_quantity.Text);
                                    jumlah.Add(aa.ToString());
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtItem.Rows.Count; i++)
                        {
                            if (dtItem.Rows[i][1].ToString() == tb_itemName.Text)
                            {
                                nama.Add(tb_itemName.Text);
                                int a = Convert.ToInt32(dtItem.Rows[i][3].ToString()) + Convert.ToInt32(tb_quantity.Text);
                                jumlah.Add(a.ToString());
                                break;
                            }
                        }
                    }

                    detailid = row.Cells["Detail Sales ID"].Value.ToString();
                }
            }
        }

        private void CalculateTotal()
        {
            if (string.IsNullOrWhiteSpace(tb_pricepcs.Text.Replace(".","")) ||
                string.IsNullOrWhiteSpace(tb_quantity.Text.Replace(".", "")) ||
                tb_quantity.Text == "0")
            {
                return;
            }

            try
            {
                int price = int.Parse(tb_pricepcs.Text.Replace(".", ""));
                int quantity = int.Parse(tb_quantity.Text.Replace(".", ""));

                int total = price * quantity;

                tb_totalPrice.Text = total.ToString("N0").Replace(",", ".");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input");
            }
        }

        private void btn_addedit_Click(object sender, EventArgs e)
        {
            if (tb_itemID.Text == "" || tb_totalPrice.Text == "" ||
                tb_itemName.Text == "" || tb_quantity.Text == "" || tb_pricepcs.Text == "")
            {
                MessageBox.Show("Please fill all the fields!");
            }

            else
            {
                btn_deleteItem.Enabled = false;

                if (GlobalData.buttonSales == 0)
                {
                    int haha = 0;
                    bool salah = false;
                    bool stock = false;
                    int quantity = Convert.ToInt32(tb_quantity.Text.Replace(".",""));

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        if (dtItem.Rows[i]["Name"].ToString().Equals(tb_itemName.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            salah = true;

                            int stockitem = Convert.ToInt32(dtItem.Rows[i]["Stock"]);
                            if (stockitem >= quantity)
                            {
                                haha = stockitem;
                                stock = true;
                            }
                            else
                            {
                                MessageBox.Show($"Not enough stock! Available stock: {stockitem}", "Error");
                            }
                            break;
                        }
                    }

                    if (!salah)
                    {
                        MessageBox.Show("Check your spelling in Item Name!", "Typo");
                    }

                    //insert
                    else if (salah == true && stock == true)
                    {
                        bool itemExists = false;

                        foreach (DataRow row in dtDetailAdd.Rows)
                        {
                            if (row["Item ID"].ToString() == tb_itemID.Text)
                            {
                                itemExists = true;
                                int existingQuantity = Convert.ToInt32(row["Quantity"]);
                                int newQuantity = existingQuantity + Convert.ToInt32(tb_quantity.Text.Replace(".",""));
                                if(newQuantity < haha)
                                {
                                    row["Quantity"] = newQuantity;

                                    int pricePerPcs = Convert.ToInt32(row["Price / pcs"].ToString().Replace(".","")) ;
                                    row["Total"] = (pricePerPcs * newQuantity).ToString("N0").Replace(",",".");


                                    MessageBox.Show($"Added Quantity Item: {tb_itemName.Text}");
                                    dgv_detailsales.ClearSelection();
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough stock! Available stock: {haha}", "Error");
                                }
                                break;
                            }
                        }

                        if (!itemExists)
                        {
                            if(dtDetailAdd.Rows.Count + 1 > 10)
                            {
                                MessageBox.Show("Item Must Not Be More Than 10");
                            }
                            else
                            {
                                dtDetailAdd.Rows.Add(digit, tb_itemID.Text, tb_itemName.Text, tb_pricepcs.Text,
                                    tb_quantity.Text, tb_totalPrice.Text);

                                MessageBox.Show($"Added Detail ID: {digit} !", "Success");
                                dgv_detailsales.ClearSelection();
                                int newid = Convert.ToInt32(digit);
                                newid++;
                                digit = newid.ToString();
                            }

                        }

                        tb_itemID.Text = "";
                        tb_itemName.Text = "";
                        tb_pricepcs.Text = "";
                        tb_quantity.Text = "";
                        tb_totalPrice.Text = "";

                        int grandtotal = 0;

                        foreach (DataRow row in dtDetailAdd.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".",""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",",".");
                    }
                }

                else if (GlobalData.buttonSales == 1)
                {
                    char simulatedChar = ' ';
                    KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(simulatedChar);

                    tb_itemName_KeyPress(tb_itemName, keyPressEventArgs);

                    char simulated = '\b';
                    KeyPressEventArgs key = new KeyPressEventArgs(simulated);

                    tb_itemName_KeyPress(tb_itemName, key);

                    listbox_item.Visible = false;

                    bool salah = false;
                    bool stock = false;
                    int quantity = Convert.ToInt32(tb_quantity.Text.Replace(".",""));
                    for (int i = 0; i < nama.Count; i++)
                    {
                        if (nama[i].Equals(tb_itemName.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            salah = true;

                            int stockitem = Convert.ToInt32(jumlah[i]);
                            if (stockitem >= quantity)
                            {
                                stock = true;
                            }
                            else
                            {
                                MessageBox.Show($"Not enough stock! Available stock: {stockitem}", "Error");
                            }
                            break;
                        }
                    }

                    if (!salah)
                    {
                        MessageBox.Show("Check your spelling in Item Name!", "Typo");
                    }

                    else if (salah == true && stock == true)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            if (dtDetail.Rows[i]["Detail Sales ID"].ToString() == detailid)
                            {
                                dtDetail.Rows[i]["Item ID"] = tb_itemID.Text;
                                dtDetail.Rows[i]["Item Name"] = tb_itemName.Text;
                                dtDetail.Rows[i]["Quantity"] = tb_quantity.Text;
                                dtDetail.Rows[i]["Price / pcs"] = tb_pricepcs.Text;
                                dtDetail.Rows[i]["Total"] = tb_totalPrice.Text;
                                break;
                            }
                        }

                        MessageBox.Show($"Edited Detail ID: {detailid} !", "Success");
                        dgv_detailsales.ClearSelection();
                        tb_itemID.Text = "";
                        tb_itemName.Text = "";
                        tb_pricepcs.Text = "";
                        tb_quantity.Text = "";
                        tb_totalPrice.Text = "";

                        int grandtotal = 0;

                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".",""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",",".");

                        tb_quantity.Enabled = false;
                        tb_pricepcs.Enabled = false;
                        tb_itemName.Enabled = false;
                    }
                }
            }
        }

        private void tb_pricepcs_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();

            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text)) return;

            int cursorPosition = textBox.SelectionStart;
            string unformatted = textBox.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(unformatted, out decimal value))
            {
                textBox.Text = value.ToString("N0").Replace(",",".");
                textBox.SelectionStart = textBox.Text.Length;
            }
            else
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void tb_quantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();

            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text)) return;

            int cursorPosition = textBox.SelectionStart;
            string unformatted = textBox.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(unformatted, out decimal value))
            {
                textBox.Text = value.ToString("N0").Replace(",", ".");
                textBox.SelectionStart = textBox.Text.Length;
            }
            else
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void btn_saveTransaction_Click(object sender, EventArgs e)
        {
            if (tb_SalesID.Text == "" || tb_customerID.Text == "" ||
                tb_customer.Text == "" || tb_address.Text == "" || tb_city.Text == "" ||
                 cb_top.Text == "" || cb_status.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
            }

            else if (dgv_detailsales.Rows.Count == 0)
            {
                MessageBox.Show("You haven't inserted any detail sales !");
            }

            else if (dgv_detailsales.Rows.Count > 10)
            {
                MessageBox.Show("Maximum only 10 detail sales allowed! Please delete a detail sales and try again!");
            }

            else
            {
                bool salah = false;

                for (int i = 0; i < dtCustomer.Rows.Count; i++)
                {
                    if (dtCustomer.Rows[i]["Instance"].ToString().Equals(tb_customer.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        salah = true;
                        break;
                    }
                }

                if (!salah)
                {
                    MessageBox.Show("Check your spelling in Customer Name!", "Typo");
                }

                else if (salah == true)
                {

                    if (GlobalData.buttonSales == 0)
                    {
                        DialogResult result = MessageBox.Show(
                       $"Save New Transaction: {tb_SalesID.Text} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                         );

                        if (result == DialogResult.Yes)
                        {
                            AddTransactionSales();
                            AddDetailsSales();
                            MessageBox.Show("Success!");
                            mainForm.sales();
                        }

                    }

                    else if (GlobalData.buttonSales == 1)
                    {
                        DialogResult result = MessageBox.Show(
                       $"Save Edited Transaction: {tb_SalesID.Text} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                         );
                    
                        if (result == DialogResult.Yes)
                        {
                            EditTransactionSales();
                            EditDetailsSales();

                            if (listdelete.Count > 0)
                            {
                                MessageBox.Show("AAA");
                                DeleteDetails();
                            }

                            MessageBox.Show("Success!");
                            mainForm.sales();

                        }
                    }
                }
            }
        }

        private void btn_deleteItem_Click(object sender, EventArgs e)
        {
            if (GlobalData.buttonSales == 0)
            {
                if (dgv_detailsales.SelectedRows.Count > 0)
                {
                    string detailSalesID = dgv_detailsales.SelectedRows[0].Cells["Detail Sales ID"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                       $"Delete Detail ID: {detailSalesID} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

                    if (result == DialogResult.Yes)
                    {
                        DataRow[] rowsToDelete = dtDetailAdd.Select($"[Detail Sales ID] = '{detailSalesID}'");

                        if (rowsToDelete.Length > 0)
                        {
                            rowsToDelete[0].Delete();
                        }

                        dtDetailAdd.AcceptChanges();

                        dgv_detailsales.DataSource = null;
                        dgv_detailsales.DataSource = dtDetailAdd;

                        int grandtotal = 0;
                        foreach (DataRow row in dtDetailAdd.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".",""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",",".");
                        dgv_detailsales.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv_detailsales.ClearSelection();
                        btn_deleteItem.Enabled = false;

                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }

            if (GlobalData.buttonSales == 1)
            {
                if (dgv_detailsales.SelectedRows.Count > 0)
                {
                    string detailSalesID = dgv_detailsales.SelectedRows[0].Cells["Detail Sales ID"].Value.ToString();


                    DialogResult result = MessageBox.Show(
                       $"Delete Detail ID: {detailSalesID} ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

                    if (result == DialogResult.Yes)
                    {
                        DataRow[] rowsToDelete = dtDetail.Select($"[Detail Sales ID] = '{detailSalesID}'");

                        if (rowsToDelete.Length > 0)
                        {
                            rowsToDelete[0].Delete();
                        }
                        dtDetail.AcceptChanges();

                        dgv_detailsales.DataSource = null;
                        dgv_detailsales.DataSource = dtDetail;

                        int grandtotal = 0;
                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".",""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",",".");
                        dgv_detailsales.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        int newid = Convert.ToInt32(digit);
                        newid--;
                        digit = newid.ToString();

                        listdelete.Add(detailSalesID);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
        }

        private void tb_itemName_Leave(object sender, EventArgs e)
        {
            tb_itemName.Text = tb_itemName.Text.Trim();
        }

        private void cb_top_TextChanged(object sender, EventArgs e)
        {
            if(cb_top.Text == "Cash")
            {
                datetime_duedate.Value = datetime_trans.Value;
            }
            else if(cb_top.Text == "30 Days")
            {
                datetime_duedate.Value = datetime_trans.Value.AddMonths(1);
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = ColorTranslator.FromHtml("#FF9A9A");

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void panel_header_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 2;
            Color borderColor = Color.WhiteSmoke;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }
    }
}
