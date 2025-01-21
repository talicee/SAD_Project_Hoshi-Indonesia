using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class Account : Form
    {
        //private Menu mainForm;
        public Account()
        {
            InitializeComponent();
            //this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtAccount = new DataTable();
        DataTable dtstatusCheck = new DataTable();

        private void Account_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_account.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            DGVAccount();
            dgv_account.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dtstatusCheck.Columns.Add("Dashboard", typeof(bool));
            dtstatusCheck.Columns.Add("Customer", typeof(bool));
            dtstatusCheck.Columns.Add("Supplier", typeof(bool));
            dtstatusCheck.Columns.Add("Item", typeof(bool));

            dtstatusCheck.Columns.Add("Purchase Transaction", typeof(bool));
            dtstatusCheck.Columns.Add("Sales Transaction", typeof(bool));
            dtstatusCheck.Columns.Add("Stock Opname", typeof(bool));
            dtstatusCheck.Columns.Add("Purchase Price", typeof(bool));
            dtstatusCheck.Columns.Add("Sales Price", typeof(bool));
            dtstatusCheck.Columns.Add("Purchase Report", typeof(bool));
            dtstatusCheck.Columns.Add("Sales Report", typeof(bool));
            dtstatusCheck.Columns.Add("Profit Report", typeof(bool));
            dtstatusCheck.Columns.Add("Stock Report", typeof(bool));
            dtstatusCheck.Columns.Add("Account", typeof(bool));
            dtstatusCheck.Columns.Add("Sign Out", typeof(bool));


            dtstatusCheck.Rows.Add(
                Enumerable.Repeat(true, dtstatusCheck.Columns.Count)
                          .Cast<object>()
                          .ToArray());
            dgv_account.DataBindingComplete += dgv_account_DataBindingComplete;
        }
        private void dgv_account_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_account.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void DGVAccount()
        {
            dtAccount.Clear();
            query = "select * from vAccount;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtAccount);
            sqlconnect.Close();

            dgv_account.DataSource = dtAccount;
        }

        private void UpdateUserAccess(DataTable dtstatusCheck)
        {
            SyncStatusCheck();
            string username = tb_username.Text;
            string password = tb_password.Text;
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlconnect.Open();

            foreach (DataRow row in dtstatusCheck.Rows)
            {
                query = @"UPDATE ACCOUNT SET 
            PASSWORD_ACCOUNT = @Password,
            Dashboard = @Dashboard, 
            Customer = @Customer, 
            Supplier = @Supplier, 
            Item = @Item, 
            Purchase_Transaction = @Purchase_Transaction, 
            Sales_Transaction = @Sales_Transaction, 
            Stock_Opname = @Stock_Opname, 
            Purchase_Price = @Purchase_Price, 
            Sales_Price = @Sales_Price, 
            Purchase_Report = @Purchase_Report, 
            Sales_Report = @Sales_Report, 
            Profit_Report = @Profit_Report, 
            Stock_Report = @Stock_Report,
            Account = @Account, 
            Sign_Out = @Sign_Out

            WHERE USERNAME_ACCOUNT = @Username";

                using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Dashboard", dtstatusCheck.Rows[0]["Dashboard"]);
                    command.Parameters.AddWithValue("@Customer", dtstatusCheck.Rows[0]["Customer"]);
                    command.Parameters.AddWithValue("@Supplier", dtstatusCheck.Rows[0]["Supplier"]);
                    command.Parameters.AddWithValue("@Item", dtstatusCheck.Rows[0]["Item"]);
                    command.Parameters.AddWithValue("@Purchase_Transaction", dtstatusCheck.Rows[0]["Purchase Transaction"]);
                    command.Parameters.AddWithValue("@Sales_Transaction", dtstatusCheck.Rows[0]["Sales Transaction"]);
                    command.Parameters.AddWithValue("@Stock_Opname", dtstatusCheck.Rows[0]["Stock Opname"]);
                    command.Parameters.AddWithValue("@Purchase_Price", dtstatusCheck.Rows[0]["Purchase Price"]);
                    command.Parameters.AddWithValue("@Sales_Price", dtstatusCheck.Rows[0]["Sales Price"]);
                    command.Parameters.AddWithValue("@Purchase_Report", dtstatusCheck.Rows[0]["Purchase Report"]);
                    command.Parameters.AddWithValue("@Sales_Report", dtstatusCheck.Rows[0]["Sales Report"]);
                    command.Parameters.AddWithValue("@Profit_Report", dtstatusCheck.Rows[0]["Profit Report"]);
                    command.Parameters.AddWithValue("@Stock_Report", dtstatusCheck.Rows[0]["Stock Report"]);
                    command.Parameters.AddWithValue("@Account", dtstatusCheck.Rows[0]["Account"]);
                    command.Parameters.AddWithValue("@Sign_Out", dtstatusCheck.Rows[0]["Sign Out"]);
                    command.Parameters.AddWithValue("@Username", username);

                    command.ExecuteNonQuery();
                }
            }

            string selectQuery = "SELECT * FROM vAccount;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtAccount.Clear();
                    adapter.Fill(dtAccount);
                }
            }

            sqlconnect.Close();
            dgv_account.DataSource = dtAccount;
            MessageBox.Show("Edit User Success!");

        }

        private void InsertNewUser()
        {
            SyncStatusCheck();
            string username = tb_username.Text;
            string password = tb_password.Text;

            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    INSERT INTO ACCOUNT (
                        USERNAME_ACCOUNT, 
                        PASSWORD_ACCOUNT, 
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
                    )
                    VALUES (
                        @Username, 
                        @Password, 
                        @Dashboard, 
                        @Customer, 
                        @Supplier, 
                        @Item, 
                        @Purchase_Transaction, 
                        @Sales_Transaction, 
                        @Stock_Opname, 
                        @Purchase_Price, 
                        @Sales_Price, 
                        @Purchase_Report, 
                        @Sales_Report, 
                        @Profit_Report,
                        @Stock_Report,
                        @Account, 
                        @Sign_Out
                    );";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                command.Parameters.AddWithValue("@Dashboard", dtstatusCheck.Rows[0]["Dashboard"]);
                command.Parameters.AddWithValue("@Customer", dtstatusCheck.Rows[0]["Customer"]);
                command.Parameters.AddWithValue("@Supplier", dtstatusCheck.Rows[0]["Supplier"]);
                command.Parameters.AddWithValue("@Item", dtstatusCheck.Rows[0]["Item"]);
                command.Parameters.AddWithValue("@Purchase_Transaction", dtstatusCheck.Rows[0]["Purchase Transaction"]);
                command.Parameters.AddWithValue("@Sales_Transaction", dtstatusCheck.Rows[0]["Sales Transaction"]);
                command.Parameters.AddWithValue("@Stock_Opname", dtstatusCheck.Rows[0]["Stock Opname"]);
                command.Parameters.AddWithValue("@Purchase_Price", dtstatusCheck.Rows[0]["Purchase Price"]);
                command.Parameters.AddWithValue("@Sales_Price", dtstatusCheck.Rows[0]["Sales Price"]);
                command.Parameters.AddWithValue("@Purchase_Report", dtstatusCheck.Rows[0]["Purchase Report"]);
                command.Parameters.AddWithValue("@Sales_Report", dtstatusCheck.Rows[0]["Sales Report"]);
                command.Parameters.AddWithValue("@Profit_Report", dtstatusCheck.Rows[0]["Profit Report"]);
                command.Parameters.AddWithValue("@Stock_Report", dtstatusCheck.Rows[0]["Stock Report"]);
                command.Parameters.AddWithValue("@Account", dtstatusCheck.Rows[0]["Account"]);
                command.Parameters.AddWithValue("@Sign_Out", dtstatusCheck.Rows[0]["Sign Out"]);


                command.ExecuteNonQuery();
            }

            string selectQuery = "SELECT * FROM vAccount;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtAccount.Clear();
                    adapter.Fill(dtAccount);
                }
            }

            sqlconnect.Close();
            dgv_account.DataSource = dtAccount;
            MessageBox.Show("Add User Success!");

        }

        private void SyncStatusCheck()
        {
            dtstatusCheck.Rows[0]["Dashboard"] = check_dashboard.Checked;
            dtstatusCheck.Rows[0]["Customer"] = check_customer.Checked;
            dtstatusCheck.Rows[0]["Supplier"] = check_supplier.Checked;
            dtstatusCheck.Rows[0]["Item"] = check_item.Checked;
            dtstatusCheck.Rows[0]["Purchase Transaction"] = check_purchasetrans.Checked;
            dtstatusCheck.Rows[0]["Sales Transaction"] = check_salestrans.Checked;
            dtstatusCheck.Rows[0]["Stock Opname"] = check_stock.Checked;
            dtstatusCheck.Rows[0]["Purchase Price"] = check_purchaseprice.Checked;
            dtstatusCheck.Rows[0]["Sales Price"] = check_salesprice.Checked;
            dtstatusCheck.Rows[0]["Purchase Report"] = check_purchasereport.Checked;
            dtstatusCheck.Rows[0]["Sales Report"] = check_salesreport.Checked;
            dtstatusCheck.Rows[0]["Profit Report"] = check_profitreport.Checked;
            dtstatusCheck.Rows[0]["Stock Report"] = check_stockreport.Checked;
            dtstatusCheck.Rows[0]["Account"] = check_account.Checked;
            dtstatusCheck.Rows[0]["Sign Out"] = check_signout.Checked;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == null || tb_password.Text == null)
            {
                MessageBox.Show("Please fill in the fields.");
            }

            else
            {
                DialogResult result = MessageBox.Show(
               "Are you sure?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool userExists = false;

                    foreach (DataRow row in dtAccount.Rows)
                    {
                        string username = row["Username"].ToString();
                        if (username == tb_username.Text)
                        {
                            userExists = true;
                            UpdateUserAccess(dtstatusCheck);
                            break;
                        }
                    }

                    if (userExists == false)
                    {
                        InsertNewUser();
                    }

                    check_dashboard.Checked = false;
                    check_customer.Checked = false;
                    check_supplier.Checked = false;
                    check_item.Checked = false;
                    check_purchasetrans.Checked = false;
                    check_salestrans.Checked = false;
                    check_stock.Checked = false;
                    check_purchaseprice.Checked = false;
                    check_salesprice.Checked = false;
                    check_purchasereport.Checked = false;
                    check_salesreport.Checked = false;
                    check_profitreport.Checked = false;
                    check_stockreport.Checked = false;
                    check_account.Checked = false;
                    check_signout.Checked = false;

                    tb_password.Text = null;
                    tb_username.Text = null;
                }

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"Delete Account: '{tb_username.Text}'?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string username = tb_username.Text;
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlconnect.Open();

                foreach (DataRow row in dtstatusCheck.Rows)
                {
                    query = @"UPDATE ACCOUNT SET 
                   
                    STATUS_DEL_ACCOUNT = 1
                    WHERE USERNAME_ACCOUNT = @Username";

                    using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        command.ExecuteNonQuery();
                    }
                }

                string selectQuery = "SELECT * FROM vAccount;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtAccount.Clear();
                        adapter.Fill(dtAccount);
                    }
                }

                sqlconnect.Close();
                dgv_account.DataSource = dtAccount;
                MessageBox.Show("Delete User Success!");
            }
        }

        private void dgv_account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_account.Rows[e.RowIndex];

                string username = row.Cells["Username"].Value.ToString();
                string password = row.Cells["Password"].Value.ToString();

                tb_username.Text = username;
                tb_password.Text = password;

            }

            using (MySqlConnection conn = DatabaseConnection.Connection)
            {
                conn.Open();
                string username = tb_username.Text;

                string query = "SELECT * FROM ACCOUNT WHERE USERNAME_ACCOUNT = @Username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        check_dashboard.Checked = Convert.ToBoolean(reader["Dashboard"]);
                        check_customer.Checked = Convert.ToBoolean(reader["Customer"]);
                        check_supplier.Checked = Convert.ToBoolean(reader["Supplier"]);
                        check_item.Checked = Convert.ToBoolean(reader["Item"]);
                        check_purchasetrans.Checked = Convert.ToBoolean(reader["Purchase_Transaction"]);
                        check_salestrans.Checked = Convert.ToBoolean(reader["Sales_Transaction"]);
                        check_stock.Checked = Convert.ToBoolean(reader["Stock_Opname"]);
                        check_purchaseprice.Checked = Convert.ToBoolean(reader["Purchase_Price"]);
                        check_salesprice.Checked = Convert.ToBoolean(reader["Sales_Price"]);
                        check_purchasereport.Checked = Convert.ToBoolean(reader["Purchase_Report"]);
                        check_salesreport.Checked = Convert.ToBoolean(reader["Sales_Report"]);
                        check_profitreport.Checked = Convert.ToBoolean(reader["Profit_Report"]);
                        check_stockreport.Checked = Convert.ToBoolean(reader["Stock_Report"]);
                        check_account.Checked = Convert.ToBoolean(reader["Account"]);
                        check_signout.Checked = Convert.ToBoolean(reader["Sign_Out"]);
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = ColorTranslator.FromHtml("#FF8686");

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }
    }
}
