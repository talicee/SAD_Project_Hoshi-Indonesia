using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class StockOpname : Form
    {
        private Menu mainForm;

        public StockOpname(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query_SO;

        DataTable dtstockopname_SO = new DataTable();
        DataTable search = new DataTable();


        private void StockOpname_Load(object sender, EventArgs e)
        {
            label_nama_SO.Text = GlobalData.Nama;
            dgv_stockopname_SO.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            MakeCircular(pb_profil_SO);
            pb_profil_SO.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_stockopname_SO.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            query_SO = $"SELECT * FROM vStockOpname;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SO, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtstockopname_SO);
            sqlconnect.Close();

            dgv_stockopname_SO.DataSource = dtstockopname_SO;

            btn_clear_SO.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_edit_SO.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_add_SO.BackColor = ColorTranslator.FromHtml("#FF9090");

            query_SO = $"SELECT `Stock Opname Date` FROM vStockOpname GROUP BY 1;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SO, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(search);
            sqlconnect.Close();

            cb_searchby_SO.Items.Clear();

            for (int i = 0; i < search.Rows.Count; i++)
            {
                cb_searchby_SO.Items.Add(search.Rows[i][0].ToString());
            }
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void butt_clear_Click(object sender, EventArgs e)
        {
            cb_searchby_SO.SelectedIndex = -1;
            dtstockopname_SO.Rows.Clear();
            dtstockopname_SO.Columns.Clear();

            query_SO = $"SELECT * FROM vStockOpname;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SO, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtstockopname_SO);
            sqlconnect.Close();

            dgv_stockopname_SO.DataSource = dtstockopname_SO;
        }

        string allowedstock = "";
        public void checkdate()
        {
            string query = "SELECT fCheckStockDate();";
            try
            {
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                    {
                        object result = sqlcommand.ExecuteScalar();
                        if (result != null)
                        {
                            label1.Text = $"Result: {result.ToString()}";
                            allowedstock = result.ToString();
                        }
                        else
                        {
                            label1.Text = "No data found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butt_edit_Click(object sender, EventArgs e)
        {
            checkdate();
            if (allowedstock.ToString() == "ALLOWED")
            {
                mainForm.editstockopname();
            }
            else
            {
                MessageBox.Show("Not Allowed To Edit Stock Opname! Transactions Have Been Made Afterward.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string allowedadd = "";
        public void checkdateadd()
        {
            string query = "SELECT fCheckStockDateAdd();";
            try
            {
                using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                {
                    sqlconnect.Open();
                    using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                    {
                        object result = sqlcommand.ExecuteScalar();
                        if (result != null)
                        {
                            label1.Text = $"Result: {result.ToString()}";
                            allowedadd = result.ToString();
                        }
                        else
                        {
                            label2.Text = "No data found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void butt_add_Click(object sender, EventArgs e)
        {
            checkdateadd();
            if (allowedadd.ToString() == "ALLOWED")
            {
                mainForm.addstockopname();
            }
            else
            {
                MessageBox.Show("Not Allowed To Add Stock Opname Again Today!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cb_searchby_SO_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtstockopname_SO.Clear();

            query_SO = $"SELECT * FROM vStockOpname WHERE `Stock Opname Date` = '{cb_searchby_SO.Text}';";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SO, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtstockopname_SO);
            sqlconnect.Close();

            dgv_stockopname_SO.DataSource = dtstockopname_SO;
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
