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
    public partial class Item : Form
    {
        private Menu mainForm;
        public Item(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterItem = new DataTable();

        private void Item_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;

            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_MasterItem.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            btn_edit.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            dgv_MasterItem.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");

            tb_SearchBy.Text = "";
            TotalItem();
            LowStock();
            OutofStock();

            if (GlobalData.Nama != "Owner") //buat admin
            {
                SearchMasterItemAdmin();
            }

            else if (GlobalData.Nama == "Owner") //buat owner
            {
                SearchMasterItem();
            }

            dgv_MasterItem.DataBindingComplete += dgv_MasterItem_MS_DataBindingComplete;
        }

        private void dgv_MasterItem_MS_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_MasterItem.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        public void SearchMasterItem()
        {
            if (tb_SearchBy.Text == "")
            {
                query = "select * from vMasterItem;";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtMasterItem);
                sqlconnect.Close();

                dgv_MasterItem.DataSource = dtMasterItem;
            }

            else
            {
                query = "SELECT * FROM vMasterItem WHERE ID LIKE @input;";
                string input = tb_SearchBy.Text;
                // gausah di sql.open 
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@input", input);

                try
                {
                    using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                    {
                        sqlconnect.Open();
                        using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                        {
                            sqlcommand.Parameters.AddWithValue("@input", $"%{input}%");

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtMasterItem);
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

        public void SearchMasterItemAdmin()
        {
            if (tb_SearchBy.Text == "")
            {
                dtMasterItem.Clear();
                query = "select * from vMasterItemAdmin;";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtMasterItem);
                sqlconnect.Close();

                dgv_MasterItem.DataSource = dtMasterItem;
            }

            else
            {
                query = "select * from vMasterItemAdmin WHERE ID LIKE @input;";
                string input = tb_SearchBy.Text;
                // gausah di sql.open 
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@input", input);

                try
                {
                    using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                    {
                        sqlconnect.Open();
                        using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                        {
                            sqlcommand.Parameters.AddWithValue("@input", $"%{input}%");

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtMasterItem);
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

        public void TotalItem()
        {
            string query = "SELECT fTotalItem();";

            try
            {
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                    {
                        object result = sqlcommand.ExecuteScalar();
                        lb_totalitem.Text = result != null ? result.ToString() : "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LowStock()
        {
            string query = "SELECT fItemLow();";
            try
            {
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                    {
                        object result = sqlcommand.ExecuteScalar();
                        lb_lowstock.Text = result != null ? result.ToString() : "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void OutofStock()
        {
            string query = "SELECT fItemOutOfStock();";
            try
            {
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                    {
                        object result = sqlcommand.ExecuteScalar();
                        lb_outofstock.Text = result != null ? result.ToString() : "No data found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_searchcustomer_Click(object sender, EventArgs e)
        {
            dtMasterItem.Clear();
            if (GlobalData.Nama != "owner") //buat admin
            {
                SearchMasterItemAdmin();
            }

            else if (GlobalData.Nama == "owner") //buat owner
            {
                SearchMasterItem();
            }
            dgv_MasterItem.DataSource = dtMasterItem;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dtMasterItem.Clear();
            tb_SearchBy.Text = "";
            if (GlobalData.Nama != "owner") //buat admin
            {
                SearchMasterItemAdmin();
            }

            else if (GlobalData.Nama == "owner") //buat owner
            {
                SearchMasterItem();
            }
            dgv_MasterItem.DataSource = dtMasterItem;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            mainForm.addedititem();
        }

        private void panel_search_MS_Click(object sender, EventArgs e)
        {
            dtMasterItem.Clear();
            if (GlobalData.Nama != "owner") //buat admin
            {
                SearchMasterItemAdmin();
            }

            else if (GlobalData.Nama == "owner") //buat owner
            {
                SearchMasterItem();
            }
            dgv_MasterItem.DataSource = dtMasterItem;
        }

        private void panel_search_MS_MouseEnter(object sender, EventArgs e)
        {
            panel_search_MS.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            pb_search_MS.Image = Properties.Resources.Logo_Search___PPH__E_;
        }

        private void panel_search_MS_MouseLeave(object sender, EventArgs e)
        {
            panel_search_MS.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            pb_search_MS.Image = Properties.Resources.Logo_Search___PPH;
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = ColorTranslator.FromHtml("#FFC7C7");

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

        private void panel4_Paint(object sender, PaintEventArgs e)
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
