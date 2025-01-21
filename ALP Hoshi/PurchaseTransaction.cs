using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
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

namespace ALP_Hoshi
{
    public partial class PurchaseTransaction : Form
    {
        private Menu mainForm;
        public PurchaseTransaction(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtDebtReminder = new DataTable();
        DataTable dtPurchase = new DataTable();

        private void PurchaseTransaction_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_purchase.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");
            dgv_debt.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_debt.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_purchase.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            btn_NewOrder.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_EditOrder.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_GenerateDeliveryNote.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_GenerateInvoice.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_delete.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            DGVDebt();
            DGVPurchase();
            dgv_purchase.ClearSelection();
            dgv_debt.ClearSelection();

            dgv_debt.DataBindingComplete += dgv_debt_DataBindingComplete;
            dgv_purchase.DataBindingComplete += dgv_purchase_DataBindingComplete;
        }
        private void dgv_debt_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_debt.ClearSelection();
        }
        private void dgv_purchase_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_purchase.ClearSelection();
        }
        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void DGVDebt()
        {
            dtDebtReminder.Clear();
            query = "select * from vDebtReminder;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtDebtReminder);
            sqlconnect.Close();

            dgv_debt.DataSource = dtDebtReminder;
        }

        private void DGVPurchase()
        {
            dtPurchase.Clear();
            query = "select * from vPurchaseTrans;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtPurchase);
            sqlconnect.Close();

            dgv_purchase.DataSource = dtPurchase;
        }
        private void DGVDeliveryNote()
        {
            GlobalData.detaildeliverynote.Clear();

            query = $"SELECT  `Item ID`, `Item Name`, \r\nCONCAT(`Quantity`, \" pcs\") as \"Quantity\"\r\nFROM vDetailPurchaseTrans\r\nWHERE `Detail Purchase ID`IN (\r\n    SELECT ID_DETAIL_PURCHASE \r\n    FROM DETAIL_PURCHASE_TRANSACTION d\r\n    JOIN PURCHASE_TRANSACTION p \r\n    ON p.ID_PURCHASE = d.ID_PURCHASE\r\n    WHERE p.ID_PURCHASE = '{GlobalData.purchaseId}'\r\n);";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(GlobalData.detaildeliverynote);
            sqlconnect.Close();

            GlobalData.detaildeliverynote.Columns.Add("No.", typeof(int));

            int rowNumber = 1;
            foreach (DataRow row in GlobalData.detaildeliverynote.Rows)
            {
                row["No."] = rowNumber;
                rowNumber++;
            }

            GlobalData.detaildeliverynote.Columns["No."].SetOrdinal(0);
        }
        private void DGVInvoice()
        {
            GlobalData.detailinvoice.Rows.Clear();
            GlobalData.detailinvoice.Columns.Clear();

            query = $"SELECT  `Item ID`, `Item Name`, \r\nCONCAT(`Quantity`, \" pcs\") as \"Quantity\",\r\nREPLACE(FORMAT(`Price / pcs`, 0), ',', '.') AS \"Price / pcs\",\r\nREPLACE(FORMAT(`Total`, 0), ',', '.') AS \"Total\"\r\nFROM vDetailPurchaseTrans\r\nWHERE `Detail Purchase ID`IN (\r\n    SELECT ID_DETAIL_PURCHASE \r\n    FROM DETAIL_PURCHASE_TRANSACTION d\r\n    JOIN PURCHASE_TRANSACTION p \r\n    ON p.ID_PURCHASE = d.ID_PURCHASE\r\n    WHERE p.ID_PURCHASE = '{GlobalData.purchaseId}'\r\n);";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(GlobalData.detailinvoice);
            sqlconnect.Close();

            GlobalData.detailinvoice.Columns.Add("No.", typeof(int));

            int rowNumber = 1;
            foreach (DataRow row in GlobalData.detailinvoice.Rows)
            {
                row["No."] = rowNumber;
                rowNumber++;
            }

            GlobalData.detailinvoice.Columns["No."].SetOrdinal(0);
        }


        public void SearchPurchase()
        {
            if (cobox_SearchBy.Text == "")
            {
                DGVPurchase();
            }

            else
            {
                query = "CALL pPurchaseTrans(@search, @input);";
                string search = "";
                string input = "";
                if (cobox_SearchBy.Text == "Purchase ID")
                {
                    search = "Purchase ID";
                    input = tb_SearchBy.Text;
                }
                else if (cobox_SearchBy.Text == "Supplier")
                {
                    search = "Supplier";
                    input = tb_SearchBy.Text;
                }
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@search", search);
                sqlcommand.Parameters.AddWithValue("@input", input);

                try
                {
                    // Koneksi ke database
                    using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                    {
                        sqlconnect.Open();
                        using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                        {
                            sqlcommand.Parameters.AddWithValue("@search", search);
                            sqlcommand.Parameters.AddWithValue("@input", input);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtPurchase);
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

        private void panel_search_MS_Click(object sender, EventArgs e)
        {
            dtPurchase.Clear();
            SearchPurchase();
            dgv_purchase.DataSource = dtPurchase;
            dgv_purchase.ClearSelection();
            btn_EditOrder.Enabled = false;
            btn_delete.Enabled = false;
            btn_GenerateDeliveryNote.Enabled = false;
            btn_GenerateInvoice.Enabled = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dtPurchase.Clear();
            tb_SearchBy.Text = "";
            cobox_SearchBy.Text = "";
            DGVPurchase();
            dgv_purchase.DataSource = dtPurchase;
            dgv_purchase.ClearSelection();
            btn_EditOrder.Enabled = false;
            btn_delete.Enabled = false;
            btn_GenerateDeliveryNote.Enabled = false;
            btn_GenerateInvoice.Enabled = false;
        }

        private void btn_NewOrder_Click(object sender, EventArgs e)
        {
            GlobalData.buttonPurchase = 0;
            mainForm.purchaseaddedit();
        }

        private void btn_EditOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                                    $"Edit Purchase ID: {purchaseId}?",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question
                                                );

            if (result == DialogResult.Yes)
            {
                GlobalData.buttonPurchase = 1; //button Edit
                mainForm.purchaseaddedit();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Delete Purchase ID: {purchaseId}?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                sqlconnect = DatabaseConnection.Connection;
                sqlconnect.Open();
                try
                {
                    string query = @"UPDATE PURCHASE_TRANSACTION SET 
                            STATUS_DEL_PURCHASE = 1
                            WHERE ID_PURCHASE = @PurchaseID;";

                    using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                    {
                        command.Parameters.AddWithValue("@PurchaseID", purchaseId);
                        command.ExecuteNonQuery();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               

                // Refresh the data in the DataGridView
                string selectQuery = "SELECT * FROM vPurchaseTrans;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtPurchase.Clear();
                        adapter.Fill(dtPurchase);
                    }
                }

                sqlconnect.Close();
                dgv_purchase.DataSource = dtPurchase;
                MessageBox.Show("Delete Purchase Transaction Success!");
                DGVPurchase();
                DGVDebt();
                dgv_purchase.ClearSelection();
                btn_EditOrder.Enabled = false;
                btn_delete.Enabled = false;
                btn_GenerateDeliveryNote.Enabled = false;
                btn_GenerateInvoice.Enabled = false;
            }
        }
        string purchaseId = "";
        private void dgv_purchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_EditOrder.Enabled = true;
            btn_GenerateDeliveryNote.Enabled = true;
            btn_GenerateInvoice.Enabled = true;
            btn_delete.Enabled = true;


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_purchase.Rows[e.RowIndex];

                GlobalData.purchaseId = row.Cells["Purchase ID"].Value.ToString();
                GlobalData.transactionDate = row.Cells[1].Value.ToString();
                GlobalData.supplierId = row.Cells["Supplier ID"].Value.ToString();
                GlobalData.supplierName = row.Cells["Supplier"].Value.ToString();
                GlobalData.supplierAddress = row.Cells["Address"].Value.ToString();
                GlobalData.supplierCity = row.Cells["City"].Value.ToString();
                GlobalData.supplierInvoice = row.Cells["Supplier Invoice"].Value.ToString();
                GlobalData.top = row.Cells["TOP"].Value.ToString();
                GlobalData.dueDate = row.Cells[8].Value.ToString();
                GlobalData.paymentStatus = row.Cells["Status"].Value.ToString();
                GlobalData.grandTotal = row.Cells["Grand Total"].Value.ToString();

                purchaseId = row.Cells["Purchase ID"].Value.ToString();
            }
        }

        private void btn_GenerateDeliveryNote_Click(object sender, EventArgs e)
        {
            DGVDeliveryNote();
            PurchaseTransaction_DeliveryNote p = new PurchaseTransaction_DeliveryNote();
            p.Show();
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {
            DGVInvoice();
            PurchaseTransaction_Invoice p = new PurchaseTransaction_Invoice();
            p.Show();
        }

        private void panel_search_MS_Paint(object sender, PaintEventArgs e)
        {
            dtPurchase.Clear();
            SearchPurchase();
            dgv_purchase.DataSource = dtPurchase;
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
