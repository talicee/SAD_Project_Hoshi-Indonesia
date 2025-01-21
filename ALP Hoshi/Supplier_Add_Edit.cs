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
    public partial class Supplier_Add_Edit : Form
    {
        private Menu mainForm;
        public Supplier_Add_Edit(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterSupplier = new DataTable();

        private void Supplier_Add_Edit_Load(object sender, EventArgs e)
        {
            dgv_mastersupplier.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_mastersupplier.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            btn_add_se.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_edit_se.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_delete_se.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_cancel_se.BackColor = ColorTranslator.FromHtml("#F25252");
            dgv_mastersupplier.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");

            TotalSupplier();
            TotalActiveSupplier();
            DGVSupplier();
            GenerateIDSupplier();
            btn_edit_se.Enabled = false;
            btn_delete_se.Enabled = false;
            dgv_mastersupplier.DataBindingComplete += dgv_mastersupplier_MS_DataBindingComplete;
        }

        private void dgv_mastersupplier_MS_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_mastersupplier.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void DGVSupplier()
        {
            dtMasterSupplier.Clear();
            query = "select * from vMasterSupplier;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterSupplier);
            sqlconnect.Close();

            dgv_mastersupplier.DataSource = dtMasterSupplier;
        }

        private void InsertNewSupplier()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                 INSERT INTO MASTER_SUPPLIER (
                     ID_SUPPLIER,
                     COMPANY_SUPPLIER,
                     ADDRESS_SUPPLIER,
                     CITY_SUPPLIER,
                     PHONE_NUMBER_SUPPLIER,
                     EMAIL_SUPPLIER,
                     CONTACT_PERSON_SUPPLIER,
                     TOP_SUPPLIER,
                     STATUS_DEL_SUPPLIER
                 ) VALUES (
                     @SupplierID, 
                     @Company, 
                     @Address, 
                     @City, 
                     @PhoneNumber, 
                     @Email, 
                     @ContactPerson, 
                     @Top, 
                     @Status
                 );";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@SupplierID", tb_supplier.Text);
                command.Parameters.AddWithValue("@Company", tb_company.Text);
                command.Parameters.AddWithValue("@Address", tb_address_se.Text);
                command.Parameters.AddWithValue("@City", tb_city_se.Text);
                command.Parameters.AddWithValue("@PhoneNumber", tb_phone_se.Text);
                command.Parameters.AddWithValue("@Email", tb_email_se.Text);
                command.Parameters.AddWithValue("@ContactPerson", tb_cp_se.Text);
                command.Parameters.AddWithValue("@Top", cb_top_se.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@Status", 0);
                command.ExecuteNonQuery();
            }

            string selectQuery = "SELECT * FROM vMasterSupplier;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterSupplier.Clear();
                    adapter.Fill(dtMasterSupplier);
                }
            }

            sqlconnect.Close();
            dgv_mastersupplier.DataSource = dtMasterSupplier;

            tb_address_se.Text = "";
            tb_city_se.Text = "";
            tb_company.Text = "";
            tb_cp_se.Text = "";
            tb_email_se.Text = "";
            tb_phone_se.Text = "";
            cb_top_se.SelectedIndex = -1;
        }

        private void UpdateSupplier()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                            UPDATE MASTER_SUPPLIER
                            SET 
                                COMPANY_SUPPLIER = @Company, 
                                ADDRESS_SUPPLIER = @Address, 
                                CITY_SUPPLIER = @City, 
                                PHONE_NUMBER_SUPPLIER = @PhoneNumber, 
                                EMAIL_SUPPLIER = @Email, 
                                CONTACT_PERSON_SUPPLIER = @ContactPerson,
                                TOP_SUPPLIER = @Top, 
                                STATUS_DEL_SUPPLIER = @Status
                            WHERE ID_SUPPLIER = @SupplierID;";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@SupplierID", tb_supplier.Text);
                command.Parameters.AddWithValue("@Company", tb_company.Text);
                command.Parameters.AddWithValue("@Address", tb_address_se.Text);
                command.Parameters.AddWithValue("@City", tb_city_se.Text);
                command.Parameters.AddWithValue("@PhoneNumber", tb_phone_se.Text);
                command.Parameters.AddWithValue("@Email", tb_email_se.Text);
                command.Parameters.AddWithValue("@ContactPerson", tb_cp_se.Text);
                command.Parameters.AddWithValue("@Top", cb_top_se.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@Status", 0);
                command.ExecuteNonQuery();
            }


            string selectQuery = "SELECT * FROM vMasterSupplier;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterSupplier.Clear();
                    adapter.Fill(dtMasterSupplier);
                }
            }

            sqlconnect.Close();
            dgv_mastersupplier.DataSource = dtMasterSupplier;

            tb_address_se.Text = "";
            tb_city_se.Text = "";
            tb_company.Text = "";
            tb_cp_se.Text = "";
            tb_email_se.Text = "";
            tb_phone_se.Text = "";
            cb_top_se.SelectedIndex = -1;
        }

        //function id supplier 
        public void GenerateIDSupplier()
        {
            query = "SELECT fGenerateIDSupplier();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                tb_supplier.Text = null;
                tb_supplier.Text = result != null ? result.ToString() : "No data found";
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

        // fuction total supplier
        public void TotalSupplier()
        {
            query = "SELECT fTotalSupplier();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                lb_totalsupplier.Text = result != null ? result.ToString() : "No data found";
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

        // fuction total active supplier
        public void TotalActiveSupplier()
        {

            query = "SELECT fTotalActiveSupplier();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                lb_totalactivesupplier.Text = result != null ? result.ToString() : "No data found";
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

        private void btn_add_se_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_address_se.Text) || string.IsNullOrEmpty(tb_city_se.Text) ||
                string.IsNullOrEmpty(tb_cp_se.Text) || string.IsNullOrEmpty(tb_supplier.Text) ||
                string.IsNullOrEmpty(tb_email_se.Text) || string.IsNullOrEmpty(tb_phone_se.Text) ||
                string.IsNullOrEmpty(cb_top_se.Text))
            {
                MessageBox.Show("Please fill all the fields.");
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
                    GenerateIDSupplier();
                    MessageBox.Show($"Successfully Inserted Data ID Customer: {tb_supplier.Text}");
                    InsertNewSupplier();
                    TotalSupplier();
                    TotalActiveSupplier();
                    GenerateIDSupplier();
                    dgv_mastersupplier.ClearSelection();
                }
            }
        }

        private void dgv_mastersupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_mastersupplier.Rows[e.RowIndex];

                string id = row.Cells["ID"].Value.ToString();
                string company = row.Cells["Company"].Value.ToString();
                string address = row.Cells["Address"].Value.ToString();
                string city = row.Cells["City"].Value.ToString();
                string phoneNum = row.Cells["Phone Number"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string contactPerson = row.Cells["Contact Person"].Value.ToString();
                string top = row.Cells["TOP"].Value.ToString();

                tb_supplier.Text = id;
                tb_company.Text = company;
                tb_address_se.Text = address;
                tb_city_se.Text = city;
                tb_phone_se.Text = phoneNum;
                tb_email_se.Text = email;
                tb_cp_se.Text = contactPerson;
                cb_top_se.Text = top;

                btn_add_se.Enabled = false;
                btn_edit_se.Enabled = true;
                btn_delete_se.Enabled = true;
                btn_cancel_se.Enabled = true;
            }
        }

        private void btn_delete_se_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Delete Supplier ID : {tb_supplier.Text}?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string supplierId = tb_supplier.Text;
                sqlconnect = DatabaseConnection.Connection;
                sqlconnect.Open();

                string query = @"UPDATE MASTER_SUPPLIER SET 
                            STATUS_DEL_SUPPLIER = 1
                            WHERE ID_SUPPLIER = @SupplierID;";

                using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierId);
                    command.ExecuteNonQuery();
                }

                // Refresh the data in the DataGridView
                string selectQuery = "SELECT * FROM vMasterSupplier;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtMasterSupplier.Clear();
                        adapter.Fill(dtMasterSupplier);
                    }
                }

                sqlconnect.Close();
                dgv_mastersupplier.DataSource = dtMasterSupplier;
                MessageBox.Show("Delete Supplier Success!");


                tb_address_se.Text = "";
                tb_city_se.Text = "";
                tb_company.Text = "";
                tb_cp_se.Text = "";
                tb_email_se.Text = "";
                tb_phone_se.Text = "";
                cb_top_se.SelectedIndex = -1;

                btn_add_se.Enabled = true;
                btn_edit_se.Enabled = false;
                btn_delete_se.Enabled = false;

                TotalActiveSupplier();
                TotalSupplier();
                GenerateIDSupplier();
                dgv_mastersupplier.ClearSelection();
            }
        }

        private void btn_edit_se_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_address_se.Text) || string.IsNullOrEmpty(tb_city_se.Text) ||
                string.IsNullOrEmpty(tb_cp_se.Text) || string.IsNullOrEmpty(tb_supplier.Text) ||
                string.IsNullOrEmpty(tb_email_se.Text) || string.IsNullOrEmpty(tb_phone_se.Text) ||
                string.IsNullOrEmpty(cb_top_se.Text))
            {
                MessageBox.Show("Please fill all the fields.");
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
                    MessageBox.Show($"Successfully Updated Data ID Customer: {tb_supplier.Text}");
                    UpdateSupplier();
                    GenerateIDSupplier();
                    btn_add_se.Enabled = true;
                    btn_edit_se.Enabled = false;
                    btn_delete_se.Enabled = false;
                    dgv_mastersupplier.ClearSelection();
                }
            }
        }

        private void tb_phone_se_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
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

        private void btn_cancel_se_Click(object sender, EventArgs e)
        {
            tb_address_se.Text = "";
            tb_city_se.Text = "";
            tb_company.Text = "";
            tb_cp_se.Text = "";
            tb_email_se.Text = "";
            tb_phone_se.Text = "";
            btn_add_se.Enabled = true;
            btn_edit_se.Enabled = false;
            btn_delete_se.Enabled = false;
            cb_top_se.SelectedIndex = -1;
            GenerateIDSupplier();
            dgv_mastersupplier.ClearSelection();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.backtosupplier();
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
    }
}
