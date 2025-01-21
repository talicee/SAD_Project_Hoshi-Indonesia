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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ALP_Hoshi
{
    public partial class StockOpname_Add : Form
    {
        private Menu mainForm;
        public StockOpname_Add(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query_SOA;
        
        DataTable dtstockopname_SOA = new DataTable();
        DataTable itemid = new DataTable();
        DataTable dtstockopname = new DataTable();
        private void StockOpname_Add_Load(object sender, EventArgs e)
        {
            label_nama_SOA.Text = GlobalData.Nama;
            dgv_stockopname_SOA.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            MakeCircular(pb_profil_SOA);
            pb_profil_SOA.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_stockopname_SOA.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            timer_date_SOA.Start();
            btn_add_SOA.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_cancel_SOA.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_saveSO_SOA.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_cancelSO_SOA.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_back_SOA.BackColor = ColorTranslator.FromHtml("#FF9090");

            itemid.Clear();
            itemid.Columns.Clear();
            cb_itemid_SOA.Enabled = true;

            query_SOA = $"SELECT * FROM vMasterItem;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query_SOA, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(itemid);
            sqlconnect.Close();
            cb_itemid_SOA.Items.Clear();

            for (int i = 0; i < itemid.Rows.Count; i++)
            {
                cb_itemid_SOA.Items.Add(itemid.Rows[i][0].ToString());
            }

            dtstockopname_SOA.Columns.Add("Stock Opname Date");
            dtstockopname_SOA.Columns.Add("Item ID");
            dtstockopname_SOA.Columns.Add("System Stock Quantity");
            dtstockopname_SOA.Columns.Add("Physical Stock Quantity");
            dtstockopname_SOA.Columns.Add("Information");
            dgv_stockopname_SOA.DataSource = dtstockopname_SOA;

            tb_systemstock_SOA.Enabled = false;
            tb_stockopnamedate_SOA.Enabled = false;
            string date = DateTime.Today.ToString("dddd, dd MMMM yyyy");
            tb_stockopnamedate_SOA.Text = date;
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void timer_date_SOA_Tick(object sender, EventArgs e)
        {
            //time = DateTime.Now.ToString("HH:mm:ss");
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

        private void panel_add_SOA_Paint(object sender, PaintEventArgs e)
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

        private void cb_itemid_SOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < itemid.Rows.Count; i++)
            {
                if (cb_itemid_SOA.Text == itemid.Rows[i][0].ToString())
                {
                    tb_systemstock_SOA.Text = itemid.Rows[i][7].ToString();
                }
            }
        }

        private void tb_information_SOA_TextChanged(object sender, EventArgs e)
        {
            if (tb_information_SOA.Text.Length > 300)
            {
                MessageBox.Show("Information Too Long!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

        private void tb_physicalstock_SOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }

        private void btn_add_SOA_Click(object sender, EventArgs e)
        {
            if (cb_itemid_SOA.Text == "" || tb_systemstock_SOA.Text == "" || tb_physicalstock_SOA.Text == "")
            {
                MessageBox.Show("Please Fill All Fields!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string datetime = dtp_date_SOA.Value.ToString("yyyy-MM-dd HH:mm:ss");
                dtstockopname_SOA.Rows.Add(datetime, cb_itemid_SOA.Text, tb_systemstock_SOA.Text, tb_physicalstock_SOA.Text, tb_information_SOA.Text);
                cb_itemid_SOA.Items.Remove(cb_itemid_SOA.Text);
                MessageBox.Show("Successfully Add New Stock Opname!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_itemid_SOA.SelectedIndex = -1;
                tb_systemstock_SOA.Text = "";
                tb_physicalstock_SOA.Text = "";
                dtp_date_SOA.Value = DateTime.Now;
                tb_information_SOA.Text = "";
            }
            dgv_stockopname_SOA.ClearSelection();
        }

        private void btn_cancel_SOA_Click(object sender, EventArgs e)
        {
            cb_itemid_SOA.SelectedIndex = -1;
            tb_systemstock_SOA.Text = "";
            tb_physicalstock_SOA.Text = "";
            dtp_date_SOA.Value = DateTime.Now;
            tb_information_SOA.Text = "";
        }

        private void btn_saveSO_SOA_Click(object sender, EventArgs e)
        {
            if (dtstockopname_SOA.Rows.Count == 0)
            {
                MessageBox.Show("No Stock Opname Has Been Saved!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do You Want To Save This Stock Opname?", "Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dtstockopname_SOA.Rows.Count; i++)
                    {
                        string sql = $"INSERT INTO STOCK_OPNAME " +
                            $"(DATE_STOCKOPNAME, ID_ITEM, SYSTEM_STOCK_ITEM, PHYSICAL_STOCK_STOCKOPNAME, " +
                            $"INFORMATION_STOCKOPNAME, STATUS_DEL_STOCKOPNAME) VALUES " +
                            $"('{dtstockopname_SOA.Rows[i][0]}', '{dtstockopname_SOA.Rows[i][1]}', '{dtstockopname_SOA.Rows[i][2]}', '{dtstockopname_SOA.Rows[i][3]}', " +
                            $"'{dtstockopname_SOA.Rows[i][4]}', 0);";
                        sqlcommand = new MySqlCommand(sql, sqlconnect);
                        sqlconnect.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlconnect.Close();
                    }
                    MessageBox.Show("Stock Opname Has Been Saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.backtostockopname();
                }
                else
                {
                    MessageBox.Show("Stock Opname Was Not Saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void btn_cancelSO_SOA_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You Have Unsaved Changes. Are You Sure You Want To Cancel?", "Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Stock Opname Has Been Canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainForm.backtostockopname();
            }
            else
            {
                MessageBox.Show("Stock Opname Was Not Canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_back_SOA_Click(object sender, EventArgs e)
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
