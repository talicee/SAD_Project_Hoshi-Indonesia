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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class StockOpname_Edit : Form
    {
        private Menu mainForm;
        public StockOpname_Edit(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query_SOE;

        DataTable dtstockopname_SOE = new DataTable();
        DataTable itemid = new DataTable();
        

        private void StockOpname_Edit_Load(object sender, EventArgs e)
        {
            label_nama_SOE.Text = GlobalData.Nama;
            dgv_stockopname_SOE.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_stockopname_SOE.ClearSelection();
            MakeCircular(pb_profil_SOE);
            pb_profil_SOE.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_stockopname_SOE.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            btn_edit_SOE.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back_SOE.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_cancel_SOE.BackColor = ColorTranslator.FromHtml("#F25252");

            dgv_stockopname_SOE.ClearSelection();
            cb_itemid_SOE.Enabled = false;
            tb_systemstock_SOE.Enabled = false;
            tb_physicalstock_SOE.Enabled = false;
            dtp_date_SOE.Enabled = false;
            tb_information_SOE.Enabled = false;
            btn_edit_SOE.Enabled = false;
            btn_cancel_SOE.Enabled = false;

            itemid.Clear();
            itemid.Columns.Clear();

            query_SOE = $"SELECT * FROM vMasterItem;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SOE, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(itemid);
            sqlconnect.Close();
            cb_itemid_SOE.Items.Clear();

            for (int i = 0; i < itemid.Rows.Count; i++)
            {
                cb_itemid_SOE.Items.Add(itemid.Rows[i][0].ToString());
            }

            dtstockopname_SOE.Columns.Add("Stock Opname Date");
            dtstockopname_SOE.Columns.Add("Item ID");
            dtstockopname_SOE.Columns.Add("System Stock Quantity");
            dtstockopname_SOE.Columns.Add("Physical Stock Quantity");
            dtstockopname_SOE.Columns.Add("Information");
            dgv_stockopname_SOE.DataSource = dtstockopname_SOE;

            query_SOE = $"SELECT * FROM vStockOpnameEdit;";
            StockOpnameEdit();

            tb_stockopnamedate_SOE.Enabled = false;

            dgv_stockopname_SOE.ClearSelection();
            dgv_stockopname_SOE.CurrentCell = null;
            dgv_stockopname_SOE.DataBindingComplete += dgv_stockopname_SOE_DataBindingComplete;
        }
        private void dgv_stockopname_SOE_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_stockopname_SOE.ClearSelection();
        }


        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        public void StockOpnameEdit()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();
            sqlcommand = new MySqlCommand(query_SOE, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtstockopname_SOE);
            sqlconnect.Close();
            dgv_stockopname_SOE.DataSource = dtstockopname_SOE;
            dgv_stockopname_SOE.ClearSelection();
            dgv_stockopname_SOE.CurrentCell = null;
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

        private void panel_add_SOE_Paint(object sender, PaintEventArgs e)
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

        private void cb_itemid_SOE_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < itemid.Rows.Count; i++)
            {
                if (cb_itemid_SOE.Text == itemid.Rows[i][0].ToString())
                {
                    tb_systemstock_SOE.Text = itemid.Rows[i][7].ToString();
                }
            }
        }

        private void tb_information_SOE_TextChanged(object sender, EventArgs e)
        {
            if (tb_information_SOE.Text.Length > 200)
            {
                MessageBox.Show("Information Too Long!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

        private void tb_physicalstock_SOE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_edit_SOE_Click(object sender, EventArgs e)
        {
            if (tb_physicalstock_SOE.Text == "")
            {
                MessageBox.Show("Please Fill All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string date = dtp_date_SOE.Value.ToString("yyyy-MM-dd HH:mm:ss");
                
                dtstockopname_SOE = new DataTable();
                query_SOE = $"UPDATE STOCK_OPNAME " +
                    $"SET PHYSICAL_STOCK_STOCKOPNAME = '{tb_physicalstock_SOE.Text}', " +
                    $"INFORMATION_STOCKOPNAME = '{tb_information_SOE.Text}' " +
                    $"WHERE ID_STOCKOPNAME = '{saveidstockopname}'";
                sqlconnect.Open();
                sqlcommand = new MySqlCommand(query_SOE, sqlconnect);
                sqlcommand.ExecuteNonQuery();
                sqlconnect.Close();

                dtstockopname_SOE = new DataTable();
                query_SOE = "SELECT * FROM vStockOpnameEdit";
                sqlcommand = new MySqlCommand(query_SOE, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtstockopname_SOE);
                dgv_stockopname_SOE.DataSource = dtstockopname_SOE;

                MessageBox.Show("Successfully Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cb_itemid_SOE.SelectedIndex = -1;
                tb_systemstock_SOE.Text = "";
                tb_physicalstock_SOE.Text = "";
                dtp_date_SOE.Value = DateTime.Now;
                tb_information_SOE.Text = "";
                tb_stockopnamedate_SOE.Text = "";
            }
            dgv_stockopname_SOE.ClearSelection();
        }

        string saveidstockopname = "";
        public void idstockopnameedit()
        {
            query_SOE = "SELECT fIDEditStockOpname(@datestockopname, @itemid);";
            
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SOE, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@datestockopname", datestockopname); // ini biar bisa jalan kalau ada input harus kek gini
            sqlcommand.Parameters.AddWithValue("@itemid", itemidstockopname);

            try
            {
                // Koneksi ke database
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query_SOE, sqlconnect))
                    {
                        sqlcommand.Parameters.AddWithValue("@datestockopname", datestockopname); // ini biar bisa jalan kalau ada input harus kek gini
                        sqlcommand.Parameters.AddWithValue("@itemid", itemidstockopname);
                        object result = sqlcommand.ExecuteScalar();
                        saveidstockopname = result != null ? result.ToString() : "No data found";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                        {
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

        private void btn_cancel_SOE_Click(object sender, EventArgs e)
        {
            cb_itemid_SOE.SelectedIndex = -1;
            tb_systemstock_SOE.Text = "";
            tb_physicalstock_SOE.Text = "";
            tb_stockopnamedate_SOE.Text = "";
            dtp_date_SOE.Value = DateTime.Now;
            tb_information_SOE.Text = "";
        }
        string datestockopname = "";
        string itemidstockopname = "";
        private void dgv_stockopname_SOE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cb_itemid_SOE.Enabled = false;
            tb_systemstock_SOE.Enabled = false;
            tb_physicalstock_SOE.Enabled = true;
            dtp_date_SOE.Enabled = false;
            tb_information_SOE.Enabled = true;
            btn_edit_SOE.Enabled = true;
            btn_cancel_SOE.Enabled = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvrRegistGuest = dgv_stockopname_SOE.Rows[e.RowIndex];
                dtp_date_SOE.Value = DateTime.Parse(dgvrRegistGuest.Cells[0].Value.ToString());
                tb_stockopnamedate_SOE.Text = dgvrRegistGuest.Cells[0].Value.ToString();
                cb_itemid_SOE.Text = dgvrRegistGuest.Cells[1].Value.ToString();
                tb_systemstock_SOE.Text = dgvrRegistGuest.Cells[2].Value.ToString();
                tb_physicalstock_SOE.Text = dgvrRegistGuest.Cells[3].Value.ToString();
                tb_information_SOE.Text = dgvrRegistGuest.Cells[4].Value.ToString();

                datestockopname = dgvrRegistGuest.Cells[0].Value.ToString();
                itemidstockopname = dgvrRegistGuest.Cells[1].Value.ToString();
            }
            idstockopnameedit();
           
        }

        private void btn_back_SOE_Click(object sender, EventArgs e)
        {
            mainForm.backtostockopname();
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
