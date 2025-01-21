using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class PurchaseTransaction_Add_Edit : Form
    {
        private Menu mainForm;
        public PurchaseTransaction_Add_Edit(Menu mainForm)
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

        DataTable dtSupplier = new DataTable();
        DataTable dtItem = new DataTable();
        DataTable dtDetail = new DataTable(); //buat edit
        DataTable dtDetailAdd = new DataTable(); //buat add      

        private List<string> listsupplier = new List<string>();
        private List<string> listitem = new List<string>();
        private List<string> listdelete = new List<string>();

        private void PurchaseTransaction_Add_Edit_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_detailpurchase.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");
            SupplierList();
            ItemList();
            listbox_item.BringToFront();

            btn_addedit.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_deleteItem.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_saveTransaction.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back.BackColor = ColorTranslator.FromHtml("#FF9090");

            if (GlobalData.buttonPurchase == 0) // status ADD
            {
                btn_addedit.Text = "Add Detail";
                btn_saveTransaction.Text = "Save New Transaction";
                DigitTerakhir();
                datetime_duedate.Value = datetime_trans.Value.AddMonths(1);

                DateTime selectedDate = datetime_trans.Value;
                tanggal = selectedDate.ToString("yyyyMM");

                IDPurchase();

                dtDetailAdd.Columns.Add("Detail Purchase ID", typeof(string));
                dtDetailAdd.Columns.Add("Item ID", typeof(string));
                dtDetailAdd.Columns.Add("Item Name", typeof(string));
                dtDetailAdd.Columns.Add("Price / pcs", typeof(string));
                dtDetailAdd.Columns.Add("Quantity", typeof(string));
                dtDetailAdd.Columns.Add("Total", typeof(string));

                dgv_detailpurchase.DataSource = dtDetailAdd;
                dgv_detailpurchase.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            else if (GlobalData.buttonPurchase == 1) // status EDIT
            {
                tb_quantity.Enabled = false;
                tb_pricepcs.Enabled = false;
                tb_itemName.Enabled = false;

                btn_addedit.Text = "Edit Detail";
                btn_saveTransaction.Text = "Save Edited Transaction";

                tb_PurchaseID.Text = GlobalData.purchaseId;
                tb_address.Text = GlobalData.supplierAddress;
                tb_city.Text = GlobalData.supplierCity;
                string grand = GlobalData.grandTotal;

                tb_grandTotal.Text = long.Parse(grand.Replace(".","")).ToString("N0").Replace(",",".");
                tb_supplierID.Text = GlobalData.supplierId;
                tb_supplier.Text = GlobalData.supplierName;
                tb_supplierInvoiceNumber.Text = GlobalData.supplierInvoice;
                cb_top.Text = GlobalData.top;
                cb_status.Text = GlobalData.paymentStatus;

                string duedate = GlobalData.dueDate;
                string transdate = GlobalData.transactionDate;

                DateTime duedateparsed = DateTime.ParseExact(duedate, "dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                datetime_duedate.Value = duedateparsed;

                DateTime transdateparsed = DateTime.ParseExact(transdate, "dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                datetime_trans.Value = transdateparsed;

                DGVDetail();
                dgv_detailpurchase.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv_detailpurchase.DataBindingComplete += dgv_detailpurchase_DataBindingComplete;
        }
        private void dgv_detailpurchase_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_detailpurchase.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
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

            if (GlobalData.buttonPurchase == 0) //kalo status add
            {
                DateTime selectedDate = datetime_trans.Value;
                tanggal = selectedDate.ToString("yyyyMM");

                IDPurchase();
            }
        }

        private void SupplierList()
        {
            dtSupplier.Clear();
            listsupplier.Clear();
            query = "select ID, Company, Address, City, TOP from vMasterSupplier;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtSupplier);
            sqlconnect.Close();

            foreach (DataRow row in dtSupplier.Rows)
            {
                listsupplier.Add(row["Company"].ToString());
            }
        }

        private void ItemList()
        {
            dtItem.Clear();
            listitem.Clear();
            query = "select ID, Name, `Purchase_Price` from vMasterItem;";
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
            dtItem.Clear();
            listitem.Clear();
            query = $"SELECT `Detail Purchase ID`, `Item ID`, `Item Name`,  REPLACE(FORMAT(`Quantity`,0),',','.') AS `Quantity`, " +
                $"REPLACE(FORMAT(`Price / pcs`,0),',','.') AS `Price / pcs`,REPLACE(FORMAT(`Total`,0),',','.') AS `Total`" +
                $"FROM vDetailPurchaseTrans\r\nWHERE `Detail Purchase ID`IN (\r\n    SELECT ID_DETAIL_PURCHASE \r\n    FROM DETAIL_PURCHASE_TRANSACTION d\r\n    JOIN PURCHASE_TRANSACTION p \r\n    ON p.ID_PURCHASE = d.ID_PURCHASE\r\n    WHERE p.ID_PURCHASE = '{GlobalData.purchaseId}'\r\n);";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtDetail);
            sqlconnect.Close();

            dgv_detailpurchase.DataSource = dtDetail;
        }

        public void DigitTerakhir()
        {
            query = "SELECT fDigitTerakhirDetailPurchase();";
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

        public void IDPurchase()
        {
            query = "SELECT fGenerateIdPurchase(@tanggal);";
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
                tb_PurchaseID.Text = result != null ? result.ToString() : "No data found";
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

        private void AddTransaction()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    INSERT INTO PURCHASE_TRANSACTION (
                        ID_PURCHASE,
                        TRANSACTION_DATE_PURCHASE,
                        ID_SUPPLIER,
                        NAME_SUPPLIER,
                        ADDRESS_SUPPLIER,
                        CITY_SUPPLIER,
                        INVOICE_SUPPLIER_PURCHASE,
                        TOP_SUPPLIER,
                        DUE_DATE_PAYMENT_PURCHASE,
                        PAYMENT_STATUS_PURCHASE,
                        GRAND_TOTAL_PURCHASE,
                        STATUS_DEL_PURCHASE
                    ) VALUES (
                        @PurchaseID,
                        @TransactionDate,
                        @SupplierID,
                        @SupplierName,
                        @SupplierAddress,
                        @SupplierCity,
                        @Invoice,
                        @Top,
                        @DueDatePayment,
                        @PaymentStatus,
                        @GrandTotal,
                        @Status
                    );";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@PurchaseID", tb_PurchaseID.Text);
                command.Parameters.AddWithValue("@TransactionDate", datetime_trans.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@SupplierID", tb_supplierID.Text);
                command.Parameters.AddWithValue("@SupplierName", tb_supplier.Text);
                command.Parameters.AddWithValue("@SupplierAddress", tb_address.Text);
                command.Parameters.AddWithValue("@SupplierCity", tb_city.Text);
                command.Parameters.AddWithValue("@Invoice", tb_supplierInvoiceNumber.Text);
                command.Parameters.AddWithValue("@Top", cb_top.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@DueDatePayment", datetime_duedate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@PaymentStatus", cb_status.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@GrandTotal", Convert.ToInt32(tb_grandTotal.Text.Replace(".","")));
                command.Parameters.AddWithValue("@Status", 0);

                command.ExecuteNonQuery();
            }
            sqlconnect.Close();

            tb_supplierID.Text = "";
            tb_supplier.Text = "";
            tb_address.Text = "";
            tb_city.Text = "";
            tb_supplierInvoiceNumber.Text = "";
            cb_top.Text = "";
            cb_status.Text = "";
            tb_grandTotal.Text = "";
        }

        private void AddDetails()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                        INSERT INTO DETAIL_PURCHASE_TRANSACTION (
                        ID_PURCHASE,
                        ID_ITEM,
                        NAME_ITEM,
                        PURCHASE_PRICE_ITEM,
                        QUANTITY_DETAILPURCHASE,
                        TOTAL_PRICE_DETAILPURCHASE
                    ) VALUES (
                        @ID_PURCHASE,
                        @ID_ITEM,
                        @NAME_ITEM,
                        @PURCHASE_PRICE_ITEM,
                        @QUANTITY_DETAILPURCHASE,
                        @TOTAL_PRICE_DETAILPURCHASE
                    );";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (DataGridViewRow row in dgv_detailpurchase.Rows)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_PURCHASE", tb_PurchaseID.Text);
                    command.Parameters.AddWithValue("@ID_ITEM", row.Cells["Item ID"].Value);
                    command.Parameters.AddWithValue("@NAME_ITEM", row.Cells["Item Name"].Value);
                    command.Parameters.AddWithValue("@PURCHASE_PRICE_ITEM", row.Cells["Price / pcs"].Value.ToString().Replace(".",""));
                    command.Parameters.AddWithValue("@QUANTITY_DETAILPURCHASE", row.Cells["Quantity"].Value.ToString().Replace(".", ""));
                    command.Parameters.AddWithValue("@TOTAL_PRICE_DETAILPURCHASE", row.Cells["Total"].Value.ToString().Replace(".", ""));

                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_PurchaseID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDPurchase();
        }

        private void EditTransaction()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    UPDATE PURCHASE_TRANSACTION
                    SET 
                        TRANSACTION_DATE_PURCHASE = @TransactionDate,
                        ID_SUPPLIER = @SupplierID,
                        NAME_SUPPLIER = @SupplierName,
                        ADDRESS_SUPPLIER = @SupplierAddress,
                        CITY_SUPPLIER = @SupplierCity,
                        INVOICE_SUPPLIER_PURCHASE = @Invoice,
                        TOP_SUPPLIER = @Top,
                        DUE_DATE_PAYMENT_PURCHASE = @DueDatePayment,
                        PAYMENT_STATUS_PURCHASE = @PaymentStatus,
                        GRAND_TOTAL_PURCHASE = @GrandTotal,
                        STATUS_DEL_PURCHASE = @Status
                    WHERE 
                        ID_PURCHASE = @PurchaseID;
                ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@PurchaseID", tb_PurchaseID.Text);
                command.Parameters.AddWithValue("@TransactionDate", datetime_trans.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@SupplierID", tb_supplierID.Text);
                command.Parameters.AddWithValue("@SupplierName", tb_supplier.Text);
                command.Parameters.AddWithValue("@SupplierAddress", tb_address.Text);
                command.Parameters.AddWithValue("@SupplierCity", tb_city.Text);
                command.Parameters.AddWithValue("@Invoice", tb_supplierInvoiceNumber.Text);
                command.Parameters.AddWithValue("@Top", cb_top.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@DueDatePayment", datetime_duedate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@PaymentStatus", cb_status.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@GrandTotal", Convert.ToInt32(tb_grandTotal.Text.Replace(".","")));
                command.Parameters.AddWithValue("@Status", 0);

                command.ExecuteNonQuery();
            }
            sqlconnect.Close();

            tb_supplierID.Text = "";
            tb_supplier.Text = "";
            tb_address.Text = "";
            tb_city.Text = "";
            tb_supplierInvoiceNumber.Text = "";
            cb_top.Text = "";
            cb_status.Text = "";
            tb_grandTotal.Text = "";
        }

        private void EditDetails()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                        UPDATE DETAIL_PURCHASE_TRANSACTION
                        SET 
                            NAME_ITEM = @NAME_ITEM,
                            PURCHASE_PRICE_ITEM = @PURCHASE_PRICE_ITEM,
                            QUANTITY_DETAILPURCHASE = @QUANTITY_DETAILPURCHASE,
                            TOTAL_PRICE_DETAILPURCHASE = @TOTAL_PRICE_DETAILPURCHASE
                        WHERE 
                            ID_PURCHASE = @ID_PURCHASE AND
                            ID_ITEM = @ID_ITEM;
                    ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (DataGridViewRow row in dgv_detailpurchase.Rows)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_PURCHASE", tb_PurchaseID.Text);
                    command.Parameters.AddWithValue("@ID_ITEM", row.Cells["Item ID"].Value);
                    command.Parameters.AddWithValue("@NAME_ITEM", row.Cells["Item Name"].Value);
                    command.Parameters.AddWithValue("@PURCHASE_PRICE_ITEM", row.Cells["Price / pcs"].Value);
                    command.Parameters.AddWithValue("@QUANTITY_DETAILPURCHASE", row.Cells["Quantity"].Value);
                    command.Parameters.AddWithValue("@TOTAL_PRICE_DETAILPURCHASE", row.Cells["Total"].Value);

                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_PurchaseID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDPurchase();
        }

        private void DeleteDetails()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                        UPDATE DETAIL_PURCHASE_TRANSACTION
                        SET 
                            STATUS_DEL_DETAILPURCHASE = 1
                        WHERE 
                            ID_DETAIL_PURCHASE = @ID_PURCHASE;
                    ";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                foreach (string idItem in listdelete)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID_PURCHASE", idItem);
                    command.ExecuteNonQuery();
                }
            }
            sqlconnect.Close();

            tb_PurchaseID.Text = "";
            tb_itemID.Text = "";
            tb_itemName.Text = "";
            tb_quantity.Text = "";
            tb_pricepcs.Text = "";
            tb_totalPrice.Text = "";
            tb_grandTotal.Text = "";
            IDPurchase();
        }

        private void CalculateTotal()
        {
            if (string.IsNullOrWhiteSpace(tb_pricepcs.Text) ||
                string.IsNullOrWhiteSpace(tb_quantity.Text) ||
                tb_quantity.Text == "0")
            {
                return;
            }

            try
            {
                int price = int.Parse(tb_pricepcs.Text.Replace(".",""));
                int quantity = int.Parse(tb_quantity.Text.Replace(".", ""));

                int total = price * quantity;

                tb_totalPrice.Text = total.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.", "Invalid Input");
            }
        }

        private void tb_itemID_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                if (dtItem.Rows[i]["ID"].ToString() == tb_itemID.Text)
                {
                    tb_pricepcs.Text = dtItem.Rows[i]["Purchase_Price"].ToString();
                }
            }
        }

        private void tb_supplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            listbox_supplier.Visible = true;
            string query = tb_supplier.Text.ToLower();
            var filtered = listsupplier
                .Where(item => item.ToLower().Contains(query))
                .ToList();

            listbox_supplier.DataSource = filtered;
            listbox_supplier.Visible = filtered.Any();
        }

        private void listbox_supplier_MouseClick(object sender, MouseEventArgs e)
        {
            tb_supplier.Text = listbox_supplier.SelectedItem.ToString();

            for (int i = 0; i < dtSupplier.Rows.Count; i++)
            {
                if (dtSupplier.Rows[i]["Company"].ToString() == tb_supplier.Text)
                {
                    tb_supplierID.Text = dtSupplier.Rows[i]["ID"].ToString();
                    tb_address.Text = dtSupplier.Rows[i]["Address"].ToString();
                    tb_city.Text = dtSupplier.Rows[i]["City"].ToString();
                    cb_top.Text = dtSupplier.Rows[i]["TOP"].ToString();
                    break;
                }
            }

            listbox_supplier.Visible = false;
        }

        private void listbox_supplier_MouseLeave(object sender, EventArgs e)
        {
            listbox_supplier.Visible = false;
        }

        private void tb_itemID_MouseClick(object sender, MouseEventArgs e)
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

        private void tb_itemID_MouseLeave(object sender, EventArgs e)
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

        private void dgv_detailpurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_deleteItem.Enabled = true;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GlobalData.buttonPurchase == 0)
                {
                    tb_itemID.Text = "";
                    tb_itemName.Text = "";
                    tb_pricepcs.Text = "";
                    tb_quantity.Text = "";
                    tb_totalPrice.Text = "";
                }
                else if (GlobalData.buttonPurchase == 1)
                {
                    tb_itemName.Enabled = false;
                    tb_pricepcs.Enabled = true;
                    tb_quantity.Enabled = true;

                    DataGridViewRow row = dgv_detailpurchase.Rows[e.RowIndex];

                    tb_itemID.Text = row.Cells["Item ID"].Value.ToString();
                    tb_itemName.Text = row.Cells["Item Name"].Value.ToString();
                    tb_pricepcs.Text = row.Cells["Price / pcs"].Value.ToString();
                    tb_quantity.Text = row.Cells["Quantity"].Value.ToString();
                    tb_totalPrice.Text = row.Cells["Total"].Value.ToString();

                    detailid = row.Cells["Detail Purchase ID"].Value.ToString();
                }
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
                if (GlobalData.buttonPurchase == 0)
                {
                    bool salah = false;

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        if (dtItem.Rows[i]["Name"].ToString().Equals(tb_itemName.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            salah = true;
                            break;
                        }
                    }

                    if (!salah)
                    {
                        MessageBox.Show("Check your spelling in Item Name!", "Typo");
                    }

                    else if (salah == true)
                    {
                        bool itemExists = false;

                        foreach (DataRow row in dtDetailAdd.Rows)
                        {
                            if (row["Item ID"].ToString() == tb_itemID.Text)
                            {
                                int existingQuantity = Convert.ToInt32(row["Quantity"].ToString().Replace(".", ""));
                                int newQuantity = existingQuantity + Convert.ToInt32(tb_quantity.Text.Replace(".", ""));
                                row["Quantity"] = newQuantity.ToString("N0").Replace(",", ".");

                                int pricePerPcs = Convert.ToInt32(row["Price / pcs"].ToString().Replace(".", ""));
                                row["Total"] = (pricePerPcs * newQuantity).ToString("N0").Replace(",", ".");

                                itemExists = true;
                                MessageBox.Show($"Added Quantity Item: {tb_itemName.Text}");
                                dgv_detailpurchase.ClearSelection();
                                btn_deleteItem.Enabled = false;
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

                                int newid = Convert.ToInt32(digit);
                                newid++;
                                digit = newid.ToString();

                                dgv_detailpurchase.ClearSelection();
                                btn_deleteItem.Enabled = false;
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
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".", ""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",", ".");
                    }
                }

                else if (GlobalData.buttonPurchase == 1)
                {
                    char simulatedChar = ' ';
                    KeyPressEventArgs keyPressEventArgs = new KeyPressEventArgs(simulatedChar);

                    tb_itemName_KeyPress(tb_itemName, keyPressEventArgs);

                    char simulated = '\b';
                    KeyPressEventArgs key = new KeyPressEventArgs(simulated);

                    tb_itemName_KeyPress(tb_itemName, key);

                    listbox_item.Visible = false;

                    bool salah = false;

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        if (dtItem.Rows[i]["Name"].ToString().Trim().Equals(tb_itemName.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            salah = true;
                            break;
                        }
                    }

                    if (!salah)
                    {
                        MessageBox.Show("Check your spelling in Item Name!", "Typo");
                    }

                    else if (salah == true)
                    {
                        for (int i = 0; i < dtDetail.Rows.Count; i++)
                        {
                            if (dtDetail.Rows[i]["Detail Purchase ID"].ToString() == detailid)
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
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".", ""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",", ".");

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
                textBox.Text = value.ToString("N0").Replace(",", ".");
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
            if (tb_PurchaseID.Text == "" || tb_supplierID.Text == "" ||
    tb_supplier.Text == "" || tb_address.Text == "" || tb_city.Text == "" ||
    tb_supplierInvoiceNumber.Text == "" || cb_top.Text == "" || cb_status.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
            }

            else if (dgv_detailpurchase.Rows.Count == 0)
            {
                MessageBox.Show("You haven't inserted any detail purchases !");
            }

            else if (dgv_detailpurchase.Rows.Count > 10)
            {
                MessageBox.Show("Maximum only 10 detail purchases allowed! Please delete a detail purchase and try again!");
            }

            else
            {
                bool salah = false;

                for (int i = 0; i < dtSupplier.Rows.Count; i++)
                {
                    if (dtSupplier.Rows[i]["Company"].ToString().Equals(tb_supplier.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        salah = true;
                        break;
                    }
                }

                if (!salah)
                {
                    MessageBox.Show("Check your spelling in Supplier Name!", "Typo");
                }

                else if (salah == true)
                {

                    if (GlobalData.buttonPurchase == 0)
                    {
                        DialogResult result = MessageBox.Show(
                       $"Save New Transaction: {tb_PurchaseID.Text} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                         );

                        if (result == DialogResult.Yes)
                        {
                            AddTransaction();
                            AddDetails();
                            MessageBox.Show("Success!");
                            dtDetailAdd.Clear();
                            mainForm.purchase();
                        }

                    }

                    else if (GlobalData.buttonPurchase == 1)
                    {
                        DialogResult result = MessageBox.Show(
                       $"Save Edited Transaction: {tb_PurchaseID.Text} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                         );

                        if (result == DialogResult.Yes)
                        {
                            EditTransaction();
                            EditDetails();

                            if (listdelete.Count > 0)
                            {
                                DeleteDetails();
                            }

                            MessageBox.Show("Success!");
                            dtDetail.Clear();
                            mainForm.purchase();
                        }
                    }
                }
            }
        }

        private void btn_deleteItem_Click(object sender, EventArgs e)
        {
            if (GlobalData.buttonPurchase == 0)
            {
                if (dgv_detailpurchase.SelectedRows.Count > 0)
                {
                    string detailPurchaseID = dgv_detailpurchase.SelectedRows[0].Cells["Detail Purchase ID"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                       $"Delete Detail ID: {detailPurchaseID} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

                    if (result == DialogResult.Yes)
                    {
                        DataRow[] rowsToDelete = dtDetailAdd.Select($"[Detail Purchase ID] = '{detailPurchaseID}'");

                        if (rowsToDelete.Length > 0)
                        {
                            rowsToDelete[0].Delete();
                        }

                        dtDetailAdd.AcceptChanges();

                        dgv_detailpurchase.DataSource = null;
                        dgv_detailpurchase.DataSource = dtDetailAdd;

                        int grandtotal = 0;
                        foreach (DataRow row in dtDetailAdd.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"].ToString().Replace(".",""));
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString("N0").Replace(",",".");
                        dgv_detailpurchase.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgv_detailpurchase.ClearSelection();
                        btn_deleteItem.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }

            if (GlobalData.buttonPurchase == 1)
            {
                if (dgv_detailpurchase.SelectedRows.Count > 0)
                {
                    string detailPurchaseID = dgv_detailpurchase.SelectedRows[0].Cells["Detail Purchase ID"].Value.ToString();


                    DialogResult result = MessageBox.Show(
                       $"Delete Detail ID: {detailPurchaseID} ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

                    if (result == DialogResult.Yes)
                    {
                        DataRow[] rowsToDelete = dtDetail.Select($"[Detail Purchase ID] = '{detailPurchaseID}'");

                        if (rowsToDelete.Length > 0)
                        {
                            rowsToDelete[0].Delete();
                        }

                        dtDetail.AcceptChanges();

                        dgv_detailpurchase.DataSource = null;
                        dgv_detailpurchase.DataSource = dtDetail;

                        int grandtotal = 0;
                        foreach (DataRow row in dtDetail.Rows)
                        {
                            if (row["Total"] != DBNull.Value)
                            {
                                grandtotal += Convert.ToInt32(row["Total"]);
                            }
                        }

                        tb_grandTotal.Text = grandtotal.ToString();
                        dgv_detailpurchase.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        int newid = Convert.ToInt32(digit);
                        newid--;
                        digit = newid.ToString();

                        listdelete.Add(detailPurchaseID);
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

        private void tb_totalPrice_TextChanged(object sender, EventArgs e)
        {
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

        private void cb_top_TextChanged(object sender, EventArgs e)
        {
            if (cb_top.Text == "Cash")
            {
                datetime_duedate.Value = datetime_trans.Value;
            }
            else if (cb_top.Text == "30 Days")
            {
                datetime_duedate.Value = datetime_trans.Value.AddMonths(1);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.purchase();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
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
