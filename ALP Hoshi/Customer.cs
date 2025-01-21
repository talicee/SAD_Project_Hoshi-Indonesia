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
    public partial class Customer : Form
    {
        private Menu mainForm;
        public Customer(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        
        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterCustomer = new DataTable();

        private void Customer_Load(object sender, EventArgs e)
        {
            // aku manggil dari class daripada tak method 1 1 mending tak class soalnya di pake di smua form
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            dgv_mastercustomer_MC.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_mastercustomer_MC.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            panel_search_MC.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            btn_edit_MC.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_clear_MC.BackColor = ColorTranslator.FromHtml("#F25252");
            cb_search_MC.Text = "";
            tb_search_MC.Text = "";
            SearchMasterCustomer();
            dgv_mastercustomer_MC.DataBindingComplete += dgv_mastercustomer_MC_DataBindingComplete;
        }

        private void dgv_mastercustomer_MC_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_mastercustomer_MC.ClearSelection();
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

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void panel_submenu_Paint(object sender, PaintEventArgs e)
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
      
        public void SearchMasterCustomer()
        {
            if (cb_search_MC.Text == "")
            {
                query = "select * from vMasterCustomer;";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtMasterCustomer);
                sqlconnect.Close();

                dgv_mastercustomer_MC.DataSource = dtMasterCustomer;
            }

            else
            {
                // ini jadi CALL
                query = "CALL pMasterCustomer(@search, @input);";
                string search = "";
                string input = "";
                if (cb_search_MC.Text == "ID")
                {
                    search = "ID";
                    input = tb_search_MC.Text;
                }
                else if (cb_search_MC.Text == "Instance")
                {
                    search = "Instance";
                    input = tb_search_MC.Text;
                }
                else if (cb_search_MC.Text == "Contact Person")
                {
                    //ini di sqlnya procedurenya kuganti jadi CP
                    search = "Customer";
                    input = tb_search_MC.Text;
                }
                // gausah di sql.open 
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqlcommand.Parameters.AddWithValue("@search", search); // ini biar bisa jalan kalau ada input harus kek gini
                sqlcommand.Parameters.AddWithValue("@input", input);

                try
                {
                    // Koneksi ke database
                    using (MySqlConnection sqlconnect = DatabaseConnection.Connection)
                    {
                        sqlconnect.Open();
                        using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                        {
                            sqlcommand.Parameters.Clear();

                            sqlcommand.Parameters.AddWithValue("@search", search);
                            sqlcommand.Parameters.AddWithValue("@input", input);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtMasterCustomer);
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tb_search_MC.Text = "";
            cb_search_MC.SelectedIndex = -1;
            dtMasterCustomer.Rows.Clear();
            dtMasterCustomer.Columns.Clear();

            query = "select * from vMasterCustomer;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterCustomer);
            sqlconnect.Close();

            dgv_mastercustomer_MC.DataSource = dtMasterCustomer;
        }

        private void btn_edit_MC_Click(object sender, EventArgs e)
        {
            mainForm.addeditcustomer();
        }

        private void cb_search_MC_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_search_MC.Text = "";

            dtMasterCustomer.Rows.Clear();
            dtMasterCustomer.Columns.Clear();

            query = "select * from vMasterCustomer;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterCustomer);
            sqlconnect.Close();

            dgv_mastercustomer_MC.DataSource = dtMasterCustomer;
        }

        private void panel_search_MC_Click(object sender, EventArgs e)
        {
            dtMasterCustomer.Clear();
            SearchMasterCustomer();
            dgv_mastercustomer_MC.DataSource = dtMasterCustomer;
        }

        private void panel_search_MC_MouseEnter(object sender, EventArgs e)
        {
            panel_search_MC.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            pb_search_MC.Image = Properties.Resources.Logo_Search___PPH__E_;
        }

        private void panel_search_MC_MouseLeave(object sender, EventArgs e)
        {
            panel_search_MC.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            pb_search_MC.Image = Properties.Resources.Logo_Search___PPH;
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
