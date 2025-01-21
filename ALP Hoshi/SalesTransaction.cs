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
    public partial class SalesTransaction : Form
    {
        private Menu mainForm;
        public SalesTransaction(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        string sqlQuery;
        DataTable dtReceivable = new DataTable();
        DataTable dtSales = new DataTable();

        private void SalesTransaction_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            DGVReceivable();
            DGVSales();
            dgv_receivable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_sales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_sales.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");
            dgv_receivable.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            btn_GenerateDeliveryNote.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_GenerateInvoice.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_NewOrder.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_EditOrder.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_delete.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            dgv_sales.DataBindingComplete += dgv_sales_DataBindingComplete;
            dgv_receivable.DataBindingComplete += dgv_receivable_DataBindingComplete;
        }
        private void dgv_receivable_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_receivable.ClearSelection();
        }
        private void dgv_sales_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_sales.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void btn_GenerateDeliveryNote_Click(object sender, EventArgs e)
        {
            DGVDeliveryNote();
            SalesTransaction_DeliveryNote stdn = new SalesTransaction_DeliveryNote();
            stdn.Show();
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {
            DGVInvoice();
            SalesTransaction_Invoice sti = new SalesTransaction_Invoice();
            sti.Show();
        }

        private void DGVReceivable()
        {
            dtReceivable.Clear();
            query = "select * from vReceivableReminder;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtReceivable);
            sqlconnect.Close();

            dgv_receivable.DataSource = dtReceivable;
        }

        private void DGVSales()
        {
            dtSales.Clear();
            query = "select * from vSalesTrans;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtSales);
            sqlconnect.Close();

            dgv_sales.DataSource = dtSales;
        }

        private void DGVDeliveryNote()
        {
            GlobalData.detaildeliverynote_sales.Rows.Clear();
            GlobalData.detaildeliverynote_sales.Columns.Clear();

            query = $"SELECT  `Item ID`, `Item Name`, \r\nCONCAT(`Quantity`, \" pcs\") as \"Quantity\"\r\nFROM vDetailSalesTrans\r\nWHERE `Detail Sales ID`IN (\r\n    SELECT ID_DETAIL_SALES \r\n    FROM DETAIL_SALES_TRANSACTION d\r\n    JOIN SALES_TRANSACTION p \r\n    ON p.ID_SALES = d.ID_SALES\r\n    WHERE p.ID_SALES = '{GlobalData.salesId}'\r\n);\r\n";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(GlobalData.detaildeliverynote_sales);
            sqlconnect.Close();

            GlobalData.detaildeliverynote_sales.Columns.Add("No.", typeof(int));

            int rowNumber = 1;
            foreach (DataRow row in GlobalData.detaildeliverynote_sales.Rows)
            {
                row["No."] = rowNumber;
                rowNumber++;
            }

            GlobalData.detaildeliverynote_sales.Columns["No."].SetOrdinal(0);
        }

        private void DGVInvoice()
        {
            GlobalData.detailinvoice_sales.Rows.Clear();
            GlobalData.detailinvoice_sales.Columns.Clear();

            query = $"SELECT  `Item ID`, `Item Name`, \r\nCONCAT(`Quantity`, \" pcs\") as \"Quantity\",\r\nREPLACE(FORMAT(`Price / pcs`, 0), ',', '.') AS \"Price / pcs\",\r\nREPLACE(FORMAT(`Total`, 0), ',', '.') AS \"Total\"\r\nFROM vDetailSalesTrans\r\nWHERE `Detail Sales ID`IN (\r\n    SELECT ID_DETAIL_SALES \r\n    FROM DETAIL_SALES_TRANSACTION d\r\n    JOIN SALES_TRANSACTION p \r\n    ON p.ID_SALES = d.ID_SALES\r\n    WHERE p.ID_SALES = '{GlobalData.salesId}'\r\n);";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(GlobalData.detailinvoice_sales);
            sqlconnect.Close();

            GlobalData.detailinvoice_sales.Columns.Add("No.", typeof(int));

            int rowNumber = 1;
            foreach (DataRow row in GlobalData.detailinvoice_sales.Rows)
            {
                row["No."] = rowNumber;
                rowNumber++;
            }

            GlobalData.detailinvoice_sales.Columns["No."].SetOrdinal(0);
        }

        public void SearchSales()
        {
            if (cobox_SearchBy.Text == "")
            {
                DGVSales();
            }

            else
            {
                query = "CALL pSalesTrans(@search, @input);";
                string search = "";
                string input = "";
                if (cobox_SearchBy.Text == "Sales ID")
                {
                    search = "Sales ID";
                    input = tb_SearchBy.Text;
                }
                else if (cobox_SearchBy.Text == "Customer")
                {
                    search = "Customer";
                    input = tb_SearchBy.Text;
                }
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@search", search);
                sqlcommand.Parameters.AddWithValue("@input", input);

                try
                {
                    using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                    {
                        sqlconnect.Open();
                        using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                        {
                            sqlcommand.Parameters.AddWithValue("@search", search);
                            sqlcommand.Parameters.AddWithValue("@input", input);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtSales);
                                sqlconnect.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dtSales.Clear();
            SearchSales();
            dgv_sales.DataSource = dtSales;
            dgv_sales.ClearSelection();
            btn_EditOrder.Enabled = false;
            btn_delete.Enabled = false;
            btn_GenerateDeliveryNote.Enabled = false;
            btn_GenerateInvoice.Enabled = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dtSales.Clear();
            tb_SearchBy.Text = "";
            cobox_SearchBy.SelectedIndex = -1;
            DGVSales();
            dgv_sales.DataSource = dtSales;
            dgv_sales.ClearSelection();
            btn_EditOrder.Enabled = false;
            btn_delete.Enabled = false;
            btn_GenerateDeliveryNote.Enabled = false;
            btn_GenerateInvoice.Enabled = false;
        }

        private void btn_NewOrder_Click(object sender, EventArgs e)
        {
            GlobalData.buttonSales = 0; //button Add

            mainForm.salesedit();
        }

        string salesId = "";

        private void btn_EditOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                    $"Edit Sales ID: {salesId}?",
                                    "Confirmation",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

            if (result == DialogResult.Yes)
            {
                GlobalData.buttonSales = 1; //button Edit

                mainForm.salesedit();
            }
        }

        private void dgv_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_EditOrder.Enabled = true;
            btn_delete.Enabled = true;
            btn_GenerateDeliveryNote.Enabled = true;
            btn_GenerateInvoice.Enabled = true;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_sales.Rows[e.RowIndex];

                GlobalData.salesId = row.Cells["Sales ID"].Value.ToString();
                GlobalData.transactionDateSales = row.Cells["Transaction Date"].Value.ToString();
                GlobalData.customerId = row.Cells["Customer ID"].Value.ToString();
                GlobalData.customerName = row.Cells["Customer"].Value.ToString();
                GlobalData.customerAddress = row.Cells["Address"].Value.ToString();
                GlobalData.customerCity = row.Cells["City"].Value.ToString();
                GlobalData.topCustomer = row.Cells["TOP"].Value.ToString();
                GlobalData.dueDatePaymentSales = row.Cells["Due Date"].Value.ToString();
                GlobalData.paymentStatusSales = row.Cells["Payment Status"].Value.ToString();
                GlobalData.grandTotalSales = row.Cells["Grand Total"].Value.ToString();


                salesId = row.Cells["Sales ID"].Value.ToString();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Delete Sales ID: {salesId}?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                sqlconnect = DatabaseConnection.Connection;
                sqlconnect.Open();

                string query = @"UPDATE SALES_TRANSACTION SET 
                            STATUS_DEL_SALES = 1
                            WHERE ID_SALES = @SalesID;";

                using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                {
                    command.Parameters.AddWithValue("@SalesID", salesId);
                    command.ExecuteNonQuery();
                }

                // Refresh the data in the DataGridView
                string selectQuery = "SELECT * FROM vSalesTrans;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtSales.Clear();
                        adapter.Fill(dtSales);
                    }
                }

                sqlconnect.Close();
                dgv_sales.DataSource = dtSales;
                MessageBox.Show("Delete Sales Transaction Success!");
                DGVSales();
                DGVReceivable();
                dgv_sales.ClearSelection();
                btn_EditOrder.Enabled = false;
                btn_delete.Enabled = false;
                btn_GenerateDeliveryNote.Enabled = false;
                btn_GenerateInvoice.Enabled = false;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
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
