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
    public partial class Customer_Add_Edit : Form
    {
        private Menu mainForm;
        public Customer_Add_Edit(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterCustomer = new DataTable();

        private void Customer_Add_Edit_Load(object sender, EventArgs e)
        {
            dgv_mastercustomer_MCA.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_nama_MCA.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dtp_registered_MCA.Value = DateTime.Today;
            dgv_mastercustomer_MCA.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            string date = DateTime.Today.ToString("dd MMMM yyyy");
            tb_registered_MCA.Text = date;
            btn_add_MCA.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_edit_MCA.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back_MCA.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_delete_MCA.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_cancel_MC.BackColor = ColorTranslator.FromHtml("#F25252");
            dgv_mastercustomer_MCA.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");

            TotalCustomer();
            TotalActiveCustomer();
            DGVCustomer();
            GenerateIDCustomer();
            btn_edit_MCA.Enabled = false;
            btn_delete_MCA.Enabled = false;

            dgv_mastercustomer_MCA.DataBindingComplete += dgv_mastercustomer_MCA_DataBindingComplete;
        }

        private void dgv_mastercustomer_MCA_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_mastercustomer_MCA.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void DGVCustomer()
        {
            dtMasterCustomer.Clear();
            query = "select * from vMasterCustomer;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterCustomer);
            sqlconnect.Close();

            dgv_mastercustomer_MCA.DataSource = dtMasterCustomer;
        }

        private void InsertNewCustomer()
        {
            string instance = "";
            if (radiobtn_company.Checked == true)
            {
                instance = tb_instance_MCA.Text;
            }
            else if (radiobtn_personal.Checked == true)
            {
                instance = "Personal";
            }

            string datetime = dtp_registered_MCA.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"INSERT INTO MASTER_CUSTOMER (ID_CUSTOMER, INSTANCE_CUSTOMER, ADDRESS_CUSTOMER, CITY_CUSTOMER,PHONE_NUMBER_CUSTOMER, EMAIL_CUSTOMER, CONTACT_PERSON_CUSTOMER, " +
                         $"REGISTERED_DATE_CUSTOMER, TOP_CUSTOMER, STATUS_DEL_CUSTOMER) VALUES " +
                         $"('{tb_customer_MCA.Text}', '{instance}', '{tb_address_MCA.Text}', '{tb_city_MCA.Text}', " +
                         $"'{tb_phone_MCA.Text}', '{tb_email_MCA.Text}', '{tb_cp_MCA.Text}', " +
                         $"'{datetime}', '{cb_top_MCA.Text}', 0);";
            sqlcommand = new MySqlCommand(sql, sqlconnect);
            sqlconnect.Open();
            sqlcommand.ExecuteNonQuery();
            string selectQuery = "SELECT * FROM vMasterCustomer;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterCustomer.Clear();
                    adapter.Fill(dtMasterCustomer);
                }
            }
            sqlconnect.Close();
            dgv_mastercustomer_MCA.DataSource = dtMasterCustomer;

            tb_address_MCA.Text = "";
            tb_city_MCA.Text = "";
            tb_cp_MCA.Text = "";
            tb_email_MCA.Text = "";
            tb_instance_MCA.Text = "";
            tb_phone_MCA.Text = "";
            cb_top_MCA.Text = "";
            radiobtn_company.Checked = false;
            radiobtn_personal.Checked = false;

        }

        private void UpdateCustomer()
        {
            string instance = "";
            if (radiobtn_company.Checked == true)
            {
                instance = tb_instance_MCA.Text;
            }
            else if (radiobtn_personal.Checked == true)
            {
                instance = "Personal";
            }

            // =====================================================================================================
            string datetime = dtp_registered_MCA.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"UPDATE MASTER_CUSTOMER SET " +
                         $"INSTANCE_CUSTOMER = '{instance}', ADDRESS_CUSTOMER = '{tb_address_MCA.Text}', CITY_CUSTOMER = '{tb_city_MCA.Text}', " +
                         $"PHONE_NUMBER_CUSTOMER = '{tb_phone_MCA.Text}', EMAIL_CUSTOMER = '{tb_email_MCA.Text}', CONTACT_PERSON_CUSTOMER = '{tb_cp_MCA.Text}', " +
                         $"REGISTERED_DATE_CUSTOMER = '{datetime}', TOP_CUSTOMER = '{cb_top_MCA.Text}', STATUS_DEL_CUSTOMER = 0 " +
                         $"WHERE ID_CUSTOMER = '{tb_customer_MCA.Text}'";
            sqlcommand = new MySqlCommand(sql, sqlconnect);
            sqlconnect.Open();
            sqlcommand.ExecuteNonQuery();
            string selectQuery = "SELECT * FROM vMasterCustomer;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterCustomer.Clear();
                    adapter.Fill(dtMasterCustomer);
                }
            }
            sqlconnect.Close();
            dgv_mastercustomer_MCA.DataSource = dtMasterCustomer;
            // ======================================================================================================

            tb_address_MCA.Text = "";
            tb_city_MCA.Text = "";
            tb_cp_MCA.Text = "";
            tb_email_MCA.Text = "";
            tb_instance_MCA.Text = "";
            tb_phone_MCA.Text = "";
            cb_top_MCA.SelectedIndex = -1;
            radiobtn_company.Checked = false;
            radiobtn_personal.Checked = false;

        }

        //function id customer 
        string aidi = "";
        public void GenerateIDCustomer()
        {
            query = "SELECT fGenerateIdCustomer();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                tb_customer_MCA.Text = null;
                tb_customer_MCA.Text = result != null ? result.ToString() : "No data found";
                aidi = tb_customer_MCA.Text;
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

        // fuction total customer
        public void TotalCustomer()
        {
            query = "SELECT fTotalCustomer();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                lb_totalcustomer_MCA.Text = result != null ? result.ToString() : "No data found";
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

        // fuction total active customer
        public void TotalActiveCustomer()
        {

            query = "SELECT fTotalActiveCustomer();";
            sqlconnect = DatabaseConnection.Connection;

            if (sqlconnect.State == System.Data.ConnectionState.Closed)
            {
                sqlconnect.Open();
            }

            try
            {
                sqlcommand = new MySqlCommand(query, sqlconnect);
                object result = sqlcommand.ExecuteScalar();
                lb_totalactivecustomer_MCA.Text = result != null ? result.ToString() : "No data found";
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

        private void btn_add_MCA_Click(object sender, EventArgs e)
        {
            if (tb_address_MCA.Text == "" || tb_city_MCA.Text == "" || tb_cp_MCA.Text == "" || tb_customer_MCA.Text == "" ||
                tb_email_MCA.Text == "" || tb_phone_MCA.Text == "" || cb_top_MCA.Text == "")
            {
                MessageBox.Show("Please Fill All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!radiobtn_company.Checked && !radiobtn_personal.Checked)
            {
                MessageBox.Show("Please select an instance type (Personal or Company).");
            }
            else if (radiobtn_company.Checked && string.IsNullOrEmpty(tb_instance_MCA.Text))
            {
                MessageBox.Show("Please enter the instance field.");
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
                    MessageBox.Show("Successfully Add New Stock Opname!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsertNewCustomer();
                    GenerateIDCustomer();
                    TotalCustomer();
                    TotalActiveCustomer();
                    dgv_mastercustomer_MCA.ClearSelection();
                }
            }
        }

        private void btn_edit_MCA_Click(object sender, EventArgs e)
        {
            if (tb_address_MCA.Text == "" || tb_city_MCA.Text == "" || tb_cp_MCA.Text == "" || tb_customer_MCA.Text == "" ||
                tb_email_MCA.Text == "" || tb_phone_MCA.Text == "" || cb_top_MCA.Text == "")
            {
                MessageBox.Show("Please Fill All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!radiobtn_company.Checked && !radiobtn_personal.Checked)
            {
                MessageBox.Show("Please select an instance type (Personal or Company).");
            }
            else if (radiobtn_company.Checked && string.IsNullOrEmpty(tb_instance_MCA.Text))
            {
                MessageBox.Show("Please enter the instance field.");
            }
            else
            {
                DialogResult result = MessageBox.Show(
               "Are you sure?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
                );
                btn_add_MCA.Enabled = true;
                btn_edit_MCA.Enabled = false;
                btn_delete_MCA.Enabled = false;
                dgv_mastercustomer_MCA.ClearSelection();
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"Succesfully Updated Data ID Customer: {tb_customer_MCA.Text}");
                    UpdateCustomer();
                }
                GenerateIDCustomer();
            }
        }

        private void btn_delete_MCA_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               $"Delete Customer ID: {tb_customer_MCA.Text}?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                string customerId = tb_customer_MCA.Text;
                sqlconnect = DatabaseConnection.Connection;
                sqlconnect.Open();

                string query = @"UPDATE MASTER_CUSTOMER SET 
                            STATUS_DEL_CUSTOMER = 1
                            WHERE ID_CUSTOMER = @CustomerID;";

                using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.ExecuteNonQuery();
                }

                // Refresh the data in the DataGridView
                string selectQuery = "SELECT * FROM vMasterCustomer;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtMasterCustomer.Clear();
                        adapter.Fill(dtMasterCustomer);
                    }
                }

                sqlconnect.Close();
                dgv_mastercustomer_MCA.DataSource = dtMasterCustomer;
                MessageBox.Show("Delete Customer Success!");

                tb_customer_MCA.Text = "";
                tb_address_MCA.Text = "";
                tb_city_MCA.Text = "";
                tb_phone_MCA.Text = "";
                tb_email_MCA.Text = "";
                tb_cp_MCA.Text = "";
                tb_instance_MCA.Text = "";
                cb_top_MCA.Text = "";
                radiobtn_company.Checked = false;
                radiobtn_personal.Checked = false;
                btn_add_MCA.Enabled = true;
                btn_edit_MCA.Enabled = false;
                btn_delete_MCA.Enabled = false;
                dgv_mastercustomer_MCA.ClearSelection();
                TotalActiveCustomer();
                TotalCustomer();
                GenerateIDCustomer();
            }
        }

        private void dgv_mastercustomer_MCA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_add_MCA.Enabled = false;
            btn_edit_MCA.Enabled = true;
            btn_delete_MCA.Enabled = true;
            btn_cancel_MC.Enabled = true;
            //radiobtn_personal.Checked = false;
            //radiobtn_company.Checked = false;
            if (e.RowIndex >= 0)
            {

                DataGridViewRow dgvrRegistGuest = dgv_mastercustomer_MCA.Rows[e.RowIndex];
                if (dgvrRegistGuest.Cells[1].Value.ToString() == "Personal")
                {
                    radiobtn_personal.Checked = true;
                    radiobtn_company.Checked = false;
                    tb_instance_MCA.Text = "";
                }
                else
                {
                    radiobtn_company.Checked = true;
                    tb_instance_MCA.Text = dgvrRegistGuest.Cells[1].Value.ToString();
                    radiobtn_personal.Checked = false;
                }

                tb_customer_MCA.Text = dgvrRegistGuest.Cells[0].Value.ToString();
                tb_address_MCA.Text = dgvrRegistGuest.Cells[2].Value.ToString();
                tb_city_MCA.Text = dgvrRegistGuest.Cells[3].Value.ToString();
                tb_phone_MCA.Text = dgvrRegistGuest.Cells[4].Value.ToString();
                tb_email_MCA.Text = dgvrRegistGuest.Cells[5].Value.ToString();
                tb_cp_MCA.Text = dgvrRegistGuest.Cells[6].Value.ToString();
                dtp_registered_MCA.Value = DateTime.Parse(dgvrRegistGuest.Cells[7].Value.ToString());
                tb_registered_MCA.Text = dgvrRegistGuest.Cells[7].Value.ToString();
                cb_top_MCA.Text = dgvrRegistGuest.Cells[8].Value.ToString();

            }
        }

        private void tb_phone_MCA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radiobtn_personal_CheckedChanged(object sender, EventArgs e)
        {
            tb_instance_MCA.Enabled = !radiobtn_personal.Checked;
            tb_instance_MCA.Text = "";
        }

        private void btn_back_MCA_Click(object sender, EventArgs e)
        {
            mainForm.backtocustomer();
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

        private void btn_cancel_MC_Click(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("dd MMMM yyyy");
            tb_registered_MCA.Text = date;
            tb_address_MCA.Text = "";
            tb_city_MCA.Text = "";
            tb_cp_MCA.Text = "";
            tb_email_MCA.Text = "";
            tb_instance_MCA.Text = "";
            tb_phone_MCA.Text = "";
            cb_top_MCA.SelectedIndex = -1;
            tb_customer_MCA.Text = aidi;
            radiobtn_company.Checked = false;
            radiobtn_personal.Checked = false;
            btn_add_MCA.Enabled = true;
            btn_edit_MCA.Enabled = false;
            btn_delete_MCA.Enabled = false;
            dgv_mastercustomer_MCA.ClearSelection();
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

        private void panel11_Paint(object sender, PaintEventArgs e)
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
