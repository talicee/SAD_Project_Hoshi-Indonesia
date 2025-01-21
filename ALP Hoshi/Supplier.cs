﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class Supplier : Form
    {
        private Menu mainForm;
        public Supplier(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        string sqlQuery;
        DataTable dtMasterSupplier = new DataTable();

        private void Supplier_Load(object sender, EventArgs e)
        {
            dgv_mastersupplier_MS.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            dgv_mastersupplier_MS.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            panel_search_MS.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            btn_edit_MS.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_clear_MS.BackColor = ColorTranslator.FromHtml("#F25252");
            tb_search_MS.Text = "";
            cb_search_MS.Text = "";
            SearchMasterSupplier();

            dgv_mastersupplier_MS.DataBindingComplete += dgv_mastersupplier_MS_DataBindingComplete;
        }

        private void dgv_mastersupplier_MS_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_mastersupplier_MS.ClearSelection();
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

        public void SearchMasterSupplier()
        {
            if (cb_search_MS.Text == "")
            {
                query = "select * from vMasterSupplier;";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtMasterSupplier);
                sqlconnect.Close();

                dgv_mastersupplier_MS.DataSource = dtMasterSupplier;
            }

            else
            {
                // ini jadi CALL
                query = "CALL pMasterSupplier(@search, @input);";
                string search = "";
                string input = "";
                if (cb_search_MS.Text == "ID")
                {
                    search = "ID";
                    input = tb_search_MS.Text;
                }
                else if (cb_search_MS.Text == "Company")
                {
                    search = "Company";
                    input = tb_search_MS.Text;
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
                            sqlcommand.Parameters.AddWithValue("@search", search);
                            sqlcommand.Parameters.AddWithValue("@input", input);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcommand))
                            {
                                adapter.Fill(dtMasterSupplier);
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
            dtMasterSupplier.Clear();
            SearchMasterSupplier();
            dgv_mastersupplier_MS.DataSource = dtMasterSupplier;
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

        private void btn_edit_MS_Click_1(object sender, EventArgs e)
        {
            mainForm.addeditsupplier();
        }

        private void btn_clear_MS_Click_1(object sender, EventArgs e)
        {
            tb_search_MS.Text = "";
            cb_search_MS.SelectedIndex = -1;
            dtMasterSupplier.Rows.Clear();
            dtMasterSupplier.Columns.Clear();

            query = "select * from vMasterSupplier;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterSupplier);
            sqlconnect.Close();

            dgv_mastersupplier_MS.DataSource = dtMasterSupplier;
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

        private void cb_search_MS_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_search_MS.Text = "";

            dtMasterSupplier.Rows.Clear();
            dtMasterSupplier.Columns.Clear();

            query = "select * from vMasterSupplier;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterSupplier);
            sqlconnect.Close();

            dgv_mastersupplier_MS.DataSource = dtMasterSupplier;
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
