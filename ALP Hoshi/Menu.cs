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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterCustomer = new DataTable();
        private void Menu_Load(object sender, EventArgs e)
        {
            corner(panel_home_page);
            corner(panel_master_data);
            corner(panel_transaction);
            corner(panel_stock);
            corner(panel_price_history);
            corner(panel_reports);
            corner(panel_about);

            panel_dashboard.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_customer.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_supplier.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_item.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_purchasetransaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_salestransaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_stockopname.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_purchaseprice.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_salesprice.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_purchasereport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_salesreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_stockreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_profitreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_account.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_signout.BackColor = ColorTranslator.FromHtml("#FFE0E0");

            panel_home_page.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_master_data.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_transaction.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_stock.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_price_history.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_reports.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            panel_about.BackColor = ColorTranslator.FromHtml("#FFF7F7");

            lb_dashboard.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_customer.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_supplier.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_item.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_transaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_transaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_stock_opname.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_price.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_price.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_stock_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_profit_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_account.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sign_out.BackColor = ColorTranslator.FromHtml("#FFE0E0");

            lb_home_page.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_master_data.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_transaction.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_stock.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_price_history.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_reports.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            lb_about.BackColor = ColorTranslator.FromHtml("#FFF7F7");

            pb_home_page.Image = Properties.Resources.Logo_Submenu___Home_Page;
            pb_master_data.Image = Properties.Resources.Logo_Submenu___Master_Data;
            pb_transaction.Image = Properties.Resources.Logo_Submenu___Transaction;
            pb_stock.Image = Properties.Resources.Logo_Submenu___Stock;
            pb_price_history.Image = Properties.Resources.Logo_Submenu___Price_History;
            pb_reports.Image = Properties.Resources.Logo_Submenu___Reports;
            pb_about.Image = Properties.Resources.Logo_Submenu___About__NEW_;

            pb_logo.Image = Properties.Resources.Logo___Hoshi;
            openChildForm(new Dashboard(this));
            SetPanelVisibility(GlobalData.Nama);

            int[] jarakgede = {63,113,88,63,89,135,0};

            List<Panel> panelshomepage = new List<Panel>();
            List<Panel> panelsmasterdata = new List<Panel>();
            List<Panel> panelstransaction = new List<Panel>();
            List<Panel> panelsstock = new List<Panel>();
            List<Panel> panelspricehistory = new List<Panel>();
            List<Panel> panelsreport = new List<Panel>();
            List<Panel> panelsabout = new List<Panel>();

            List<List<Panel>> allPanelGroups = new List<List<Panel>>();
            List<Panel> main = new List<Panel>();

            allPanelGroups.Add(panelshomepage);
            allPanelGroups.Add(panelsmasterdata);
            allPanelGroups.Add(panelstransaction);
            allPanelGroups.Add(panelsstock);
            allPanelGroups.Add(panelspricehistory);
            allPanelGroups.Add(panelsreport);
            allPanelGroups.Add(panelsabout);

            main.Add(panel_home_page);
            main.Add(panel_master_data);
            main.Add(panel_transaction);
            main.Add(panel_stock);
            main.Add(panel_price_history);
            main.Add(panel_reports);
            main.Add(panel_about);
            for (int i = 3; i < dtMasterCustomer.Columns.Count; i++)
            {
                string columnName = dtMasterCustomer.Columns[i].ColumnName.ToUpper();
                int value = Convert.ToInt32(dtMasterCustomer.Rows[0][i]); // Assuming the value is stored as int

                if (value == 1) // Add panel to the respective list only if the value is 1
                {
                    if (columnName == "DASHBOARD")
                    {
                        panelshomepage.Add(panel_dashboard); // Add dashboard panel
                    }
                    else if (columnName == "CUSTOMER")
                    {
                        panelsmasterdata.Add(panel_customer); // Add customer panel
                    }
                    else if (columnName == "SUPPLIER")
                    {
                        panelsmasterdata.Add(panel_supplier); // Add supplier panel
                    }
                    else if (columnName == "ITEM")
                    {
                        panelsmasterdata.Add(panel_item); // Add item panel
                    }
                    else if (columnName == "PURCHASE_TRANSACTION")
                    {
                        panelstransaction.Add(panel_purchasetransaction); // Add purchase transaction panel
                    }
                    else if (columnName == "SALES_TRANSACTION")
                    {
                        panelstransaction.Add(panel_salestransaction); // Add sales transaction panel
                    }
                    else if (columnName == "STOCK_OPNAME")
                    {
                        panelsstock.Add(panel_stockopname); // Add stock opname panel
                    }
                    else if (columnName == "PURCHASE_PRICE")
                    {
                        panelspricehistory.Add(panel_purchaseprice); // Add purchase price panel
                    }
                    else if (columnName == "SALES_PRICE")
                    {
                        panelspricehistory.Add(panel_salesprice); // Add sales price panel
                    }
                    else if (columnName == "PURCHASE_REPORT")
                    {
                        panelsreport.Add(panel_purchasereport); // Add purchase report panel
                    }
                    else if (columnName == "SALES_REPORT")
                    {
                        panelsreport.Add(panel_salesreport); // Add sales report panel
                    }
                    else if (columnName == "STOCK_REPORT")
                    {
                        panelsreport.Add(panel_stockreport); // Add stock report panel
                    }
                    else if (columnName == "PROFIT_REPORT")
                    {
                        panelsreport.Add(panel_profitreport); // Add profit report panel
                    }
                    else if (columnName == "ACCOUNT")
                    {
                        panelsabout.Add(panel_account); // Add account panel
                    }
                    else if (columnName == "SIGN_OUT")
                    {
                        panelsabout.Add(panel_signout); // Add sign-out panel
                    }
                }
            }

            int xgede = 13;
            int ygede = 72;

            int xkecil = 29;
            int ykecil = 30;

            int beda = 24;

            for (int i = 0; i < allPanelGroups.Count; i++)
            {
                int b = 0;
                bool cek = false;
                if (allPanelGroups[i].Count == 0)
                {
                    main[i].Visible = false;
                    cek = true;
                }

                if(cek == false)
                {
                    Panel mainPanel = main[i];
                    mainPanel.Location = new Point(xgede, ygede);
                    mainPanel.Visible = true;
                    ygede += jarakgede[i];

                    for (int j = 0; j < allPanelGroups[i].Count; j++)
                    {
                        Panel subPanel = allPanelGroups[i][j];
                        subPanel.Location = new Point(xkecil, ykecil + (beda * b));
                        b++;
                    }
                }
            }
        }

        private Form activeForm = null; // Tracks the currently active child form
        private void openChildForm(Form childForm) // Opens a child form inside a panel
        {
            if (activeForm != null)
                activeForm.Close(); // Closes the currently active child form (if any)

            activeForm = childForm; // Sets the new child form as the active form
            childForm.TopLevel = false; // Makes the child form a non-top-level control
            childForm.FormBorderStyle = FormBorderStyle.None; // Removes the border from the child form
            childForm.Dock = DockStyle.Fill; // Fills the entire panel with the child form
            panelChildForm.Controls.Add(childForm); // Adds the child form to the panel
            panelChildForm.Tag = childForm; // Stores the child form in the panel's Tag property
            childForm.BringToFront(); // Brings the child form to the front
            childForm.Show(); // Displays the child form
        }

        public void corner(Panel panel1)
        {
            // ini buat rounded corner kalau mau ubah lengkungannya seberap ubah aja ini int cornerRadius semakin gede smakin nglngkung
            int cornerRadius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            panel1.Region = new Region(path);
        }

        private void panel_home_page_Paint_1(object sender, PaintEventArgs e)
        {
            // kok kenapa ga disamain sm yg diatas? krn ini beda warna abis figma kalian banyak warna tiap border beda warna :)
            Panel panel = sender as Panel;

            int cornerRadius = 20;
            int borderWidth = 2;
            Color borderColor = ColorTranslator.FromHtml("#FFB1B1");

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius - 1, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void SetPanelVisibility(string username)
        {

            try
            {
                query = $"select * from ACCOUNT WHERE USERNAME_ACCOUNT = '{username}';";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtMasterCustomer);
                sqlconnect.Close();
                using (MySqlConnection conn = DatabaseConnection.Connection)
                {
                    conn.Open();

                    string query = "SELECT * FROM ACCOUNT WHERE USERNAME_ACCOUNT = @Username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Set panel visibility based on database fields
                            panel_dashboard.Visible = Convert.ToBoolean(reader["Dashboard"]);
                            panel_customer.Visible = Convert.ToBoolean(reader["Customer"]);
                            panel_supplier.Visible = Convert.ToBoolean(reader["Supplier"]);
                            panel_item.Visible = Convert.ToBoolean(reader["Item"]);
                            panel_purchasetransaction.Visible = Convert.ToBoolean(reader["Purchase_Transaction"]);
                            panel_salestransaction.Visible = Convert.ToBoolean(reader["Sales_Transaction"]);
                            panel_stockopname.Visible = Convert.ToBoolean(reader["Stock_Opname"]);
                            panel_purchaseprice.Visible = Convert.ToBoolean(reader["Purchase_Price"]);
                            panel_salesprice.Visible = Convert.ToBoolean(reader["Sales_Price"]);
                            panel_purchasereport.Visible = Convert.ToBoolean(reader["Purchase_Report"]);
                            panel_salesreport.Visible = Convert.ToBoolean(reader["Sales_Report"]);
                            panel_profitreport.Visible = Convert.ToBoolean(reader["Profit_Report"]);
                            panel_stockreport.Visible = Convert.ToBoolean(reader["Stock_Report"]);
                            panel_account.Visible = Convert.ToBoolean(reader["Account"]);
                            panel_signout.Visible = Convert.ToBoolean(reader["Sign_Out"]);
                        }
                        else
                        {
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel_master_data.Visible = panel_customer.Visible || panel_supplier.Visible || panel_item.Visible;
            panel_transaction.Visible = panel_purchasetransaction.Visible || panel_salestransaction.Visible;
            panel_stock.Visible = panel_stockopname.Visible;
            panel_price_history.Visible = panel_purchaseprice.Visible || panel_salesprice.Visible;
            panel_reports.Visible = panel_purchasereport.Visible || panel_salesreport.Visible || panel_profitreport.Visible || panel_stockreport.Visible;
        }

        private void panel_submenu_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = Color.WhiteSmoke;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void panel_signout_Click(object sender, EventArgs e)
        {
            Sign_In s = new Sign_In();
            s.Show();
            this.Close();
        }

        private void panel_dashboard_MouseEnter(object sender, EventArgs e)
        {
            panel_dashboard.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_dashboard.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_dashboard_MouseLeave(object sender, EventArgs e)
        {
            panel_dashboard.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_dashboard.BackColor = ColorTranslator.FromHtml("#FFE0E0");

        }

        private void panel_customer_MouseEnter(object sender, EventArgs e)
        {
            panel_customer.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_customer.BackColor = ColorTranslator.FromHtml("#EEAFAF");

        }

        private void panel_customer_MouseLeave(object sender, EventArgs e)
        {
            panel_customer.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_customer.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_supplier_MouseEnter(object sender, EventArgs e)
        {
            panel_supplier.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_supplier.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_supplier_MouseLeave(object sender, EventArgs e)
        {
            panel_supplier.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_supplier.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_item_MouseEnter(object sender, EventArgs e)
        {
            panel_item.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_item.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_item_MouseLeave(object sender, EventArgs e)
        {
            panel_item.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_item.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_purchasetransaction_MouseEnter(object sender, EventArgs e)
        {
            panel_purchasetransaction.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_purchase_transaction.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_purchasetransaction_MouseLeave(object sender, EventArgs e)
        {
            panel_purchasetransaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_transaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_salestransaction_MouseEnter(object sender, EventArgs e)
        {
            panel_salestransaction.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_sales_transaction.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_salestransaction_MouseLeave(object sender, EventArgs e)
        {
            panel_salestransaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_transaction.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_stockopname_MouseEnter(object sender, EventArgs e)
        {
            panel_stockopname.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_stock_opname.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_stockopname_MouseLeave(object sender, EventArgs e)
        {
            panel_stockopname.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_stock_opname.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_purchaseprice_MouseEnter(object sender, EventArgs e)
        {
            panel_purchaseprice.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_purchase_price.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_purchaseprice_MouseLeave(object sender, EventArgs e)
        {
            panel_purchaseprice.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_price.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_salesprice_MouseEnter(object sender, EventArgs e)
        {
            panel_salesprice.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_sales_price.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_salesprice_MouseLeave(object sender, EventArgs e)
        {
            panel_salesprice.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_price.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_purchasereport_MouseEnter(object sender, EventArgs e)
        {
            panel_purchasereport.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_purchase_report.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_purchasereport_MouseLeave(object sender, EventArgs e)
        {
            panel_purchasereport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_purchase_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_salesreport_MouseEnter(object sender, EventArgs e)
        {
            panel_salesreport.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_sales_report.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_salesreport_MouseLeave(object sender, EventArgs e)
        {
            panel_salesreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sales_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_profitreport_MouseEnter(object sender, EventArgs e)
        {
            panel_profitreport.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_profit_report.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_profitreport_MouseLeave(object sender, EventArgs e)
        {
            panel_profitreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_profit_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_stockreport_MouseEnter(object sender, EventArgs e)
        {
            panel_stockreport.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_stock_report.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_stockreport_MouseLeave(object sender, EventArgs e)
        {
            panel_stockreport.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_stock_report.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_account_MouseEnter(object sender, EventArgs e)
        {
            panel_account.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_account.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_account_MouseLeave(object sender, EventArgs e)
        {
            panel_account.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_account.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_signout_MouseEnter(object sender, EventArgs e)
        {
            panel_signout.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            lb_sign_out.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_signout_MouseLeave(object sender, EventArgs e)
        {
            panel_signout.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            lb_sign_out.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel_dashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard(this));
        }

        private void panel_customer_Click(object sender, EventArgs e)
        {
            openChildForm(new Customer(this));
        }

        private void panel_supplier_Click(object sender, EventArgs e)
        {
            openChildForm(new Supplier(this));
        }

        private void panel_item_Click(object sender, EventArgs e)
        {
            openChildForm(new Item(this));
        }

        private void panel_stockopname_Click(object sender, EventArgs e)
        {
            openChildForm(new StockOpname(this));
        }

        public void editstockopname()
        {
            openChildForm(new StockOpname_Edit(this));
        }

        public void backtostockopname()
        {
            openChildForm(new StockOpname(this));
        }

        public void addstockopname()
        {
            openChildForm(new StockOpname_Add(this));
        }

        private void panel_purchaseprice_Click(object sender, EventArgs e)
        {
            openChildForm(new PurchasePriceHistory());
        }

        private void panel_salesprice_Click(object sender, EventArgs e)
        {
            openChildForm(new SalesPriceHistory());
        }

        private void panel_purchasereport_Click(object sender, EventArgs e)
        {
            openChildForm(new PurchaseReport());
        }

        private void panel_salesreport_Click(object sender, EventArgs e)
        {
            openChildForm(new SalesReport());
        }

        private void panel_profitreport_Click(object sender, EventArgs e)
        {
            openChildForm(new ProfitReport(this));
        }

        private void panel_stockreport_Click(object sender, EventArgs e)
        {
            openChildForm(new StockReport());
        }

        private void panel_account_Click(object sender, EventArgs e)
        {
            openChildForm(new Account());
        }

        public void viewprofitreport()
        {
            openChildForm(new ProfitReport(this));
        }

        public void addeditcustomer()
        {
            openChildForm(new Customer_Add_Edit(this));
        }

        public void backtocustomer()
        {
            openChildForm(new Customer(this));
        }

        public void addeditsupplier()
        {
            openChildForm(new Supplier_Add_Edit(this));
        }

        public void backtosupplier()
        {
            openChildForm(new Supplier(this));
        }

        public void addedititem()
        {
            openChildForm(new Item_Add_Edit(this));
        }

        public void backtoitem()
        {
            openChildForm(new Item(this));
        }

        public void purchaseaddedit()
        {
            openChildForm(new PurchaseTransaction_Add_Edit(this));
        }

        public void backtopurchase()
        {
            openChildForm(new PurchaseTransaction(this));
        }

        private void panel_purchasetransaction_Click(object sender, EventArgs e)
        {
            openChildForm(new PurchaseTransaction(this));
        }

        public void salesedit()
        {
            openChildForm(new SalesTransaction_Add_Edit(this));
        }

        private void panel_salestransaction_Click(object sender, EventArgs e)
        {
            openChildForm(new SalesTransaction(this));
        }

        public void sales()
        {
            openChildForm(new SalesTransaction(this));
        }
        public void purchase()
        {
            openChildForm(new PurchaseTransaction(this));
        }
        public void additem()
        {
            openChildForm(new Item_Add_Edit(this));
        }
        public void addsales()
        {
            openChildForm(new SalesTransaction_Add_Edit(this));
        }
        public void addpurchase()
        {
            openChildForm(new PurchaseTransaction_Add_Edit(this));
        }
        public void hah(string hih)
        {
            if(hih == "in")
            {
                panelChildForm.Width = panelChildForm.Width + 200;
            }
            else if(hih == "out")
            {
                panelChildForm.Width = panelChildForm.Width - 200;
                this.Width = this.Width - 200;
            }
        }
    }
}
