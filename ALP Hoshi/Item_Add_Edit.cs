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
    public partial class Item_Add_Edit : Form
    {
        private Menu mainForm;
        public Item_Add_Edit(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtMasterItem = new DataTable();

        private void Item_Add_Edit_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_masteritem.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            btn_add_ie.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_edit_ie.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_back.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_delete_ie.BackColor = ColorTranslator.FromHtml("#F25252");
            btn_cancel_ie.BackColor = ColorTranslator.FromHtml("#F25252");
            dgv_masteritem.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFC7C7");
            dtMasterItem.Columns.Clear();
            dgv_masteritem.Columns.Clear();

            if (GlobalData.Nama == "Owner") //buat owner
            {
                DGVItem();
            }
            else
            {
                tb_purchaseprice.Visible = false;
                lb_purchase.Visible = false;
                panel4.Visible = false;

                tb_salesprice.Enabled = false;
                DGVItemAdmin();
            }

            btn_edit_ie.Enabled = false;
            btn_delete_ie.Enabled = false;

            dgv_masteritem.DataBindingComplete += dgv_masteritem_MS_DataBindingComplete;
        }

        private void dgv_masteritem_MS_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_masteritem.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void DGVItem()
        {
            dtMasterItem.Clear();
            query = "select * from vMasterItem;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterItem);
            sqlconnect.Close();

            dgv_masteritem.DataSource = dtMasterItem;
        }

        private void DGVItemAdmin()
        {
            dtMasterItem.Clear();
            query = "select * from vMasterItemAdmin;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtMasterItem);
            sqlconnect.Close();

            dgv_masteritem.DataSource = dtMasterItem;
        }


        private void InsertNewItem()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    INSERT INTO MASTER_ITEM (
                        ID_ITEM ,
                        NAME_ITEM,
                        COLOUR_ITEM,
                        SIZE_ITEM ,
                        CATEGORY_ITEM ,
                        SALES_PRICE_ITEM ,
                        PURCHASE_PRICE_ITEM ,
                        STOCK_ITEM ,
                        MINIMUM_STOCK_ITEM ,
                        STATUS_DEL_ITEM 
                    ) VALUES (
                        @ID_ITEM, 
                        @NAME_ITEM, 
                        @COLOUR_ITEM, 
                        @SIZE_ITEM, 
                        @CATEGORY_ITEM, 
                        @SALES_PRICE_ITEM, 
                        @PURCHASE_PRICE_ITEM, 
                        @STOCK_ITEM, 
                        @MINIMUM_STOCK_ITEM, 
                        @STATUS_DEL_ITEM
                    );";


            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@ID_ITEM", tb_itemid.Text);
                command.Parameters.AddWithValue("@NAME_ITEM", tb_name.Text);
                command.Parameters.AddWithValue("@COLOUR_ITEM", tb_colour.Text);
                command.Parameters.AddWithValue("@SIZE_ITEM", tb_size.Text);
                command.Parameters.AddWithValue("@CATEGORY_ITEM", cb_category.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@SALES_PRICE_ITEM", int.Parse(tb_salesprice.Text.Replace(".", "")));
                command.Parameters.AddWithValue("@PURCHASE_PRICE_ITEM", int.Parse(tb_purchaseprice.Text.Replace(".", "")));
                command.Parameters.AddWithValue("@STOCK_ITEM", 0);
                command.Parameters.AddWithValue("@MINIMUM_STOCK_ITEM", 10);
                command.Parameters.AddWithValue("@STATUS_DEL_ITEM", 0);
                command.ExecuteNonQuery();

            }

            string selectQuery = "SELECT * FROM vMasterItem;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterItem.Clear();
                    adapter.Fill(dtMasterItem);
                }
            }

            sqlconnect.Close();
            dgv_masteritem.DataSource = dtMasterItem;
            MessageBox.Show("Add Item Success!");

            tb_itemid.Text = "";
            tb_colour.Text = "";
            tb_name.Text = "";
            tb_purchaseprice.Text = "";
            tb_salesprice.Text = "";
            tb_size.Text = "";
            cb_category.SelectedIndex = -1;
            btn_edit_ie.Enabled = false;
            btn_delete_ie.Enabled = false;
            dgv_masteritem.ClearSelection();
        }

        private void InsertNewItemAdmin()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    INSERT INTO MASTER_ITEM (
                        ID_ITEM ,
                        NAME_ITEM,
                        COLOUR_ITEM,
                        SIZE_ITEM ,
                        CATEGORY_ITEM ,
                        SALES_PRICE_ITEM ,
                        PURCHASE_PRICE_ITEM ,
                        STOCK_ITEM ,
                        MINIMUM_STOCK_ITEM ,
                        STATUS_DEL_ITEM 
                    ) VALUES (
                        @ID_ITEM, 
                        @NAME_ITEM, 
                        @COLOUR_ITEM, 
                        @SIZE_ITEM, 
                        @CATEGORY_ITEM, 
                        @SALES_PRICE_ITEM, 
                        @PURCHASE_PRICE_ITEM, 
                        @STOCK_ITEM, 
                        @MINIMUM_STOCK_ITEM, 
                        @STATUS_DEL_ITEM
                    );";


            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@ID_ITEM", tb_itemid.Text);
                command.Parameters.AddWithValue("@NAME_ITEM", tb_name.Text);
                command.Parameters.AddWithValue("@COLOUR_ITEM", tb_colour.Text);
                command.Parameters.AddWithValue("@SIZE_ITEM", tb_size.Text);
                command.Parameters.AddWithValue("@CATEGORY_ITEM", cb_category.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@SALES_PRICE_ITEM", 0);
                command.Parameters.AddWithValue("@PURCHASE_PRICE_ITEM", 0);
                command.Parameters.AddWithValue("@STOCK_ITEM", 0);
                command.Parameters.AddWithValue("@MINIMUM_STOCK_ITEM", 10);
                command.Parameters.AddWithValue("@STATUS_DEL_ITEM", 0);
                command.ExecuteNonQuery();

            }

            string selectQuery = "SELECT * FROM vMasterItemAdmin;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterItem.Clear();
                    adapter.Fill(dtMasterItem);
                }
            }

            sqlconnect.Close();
            dgv_masteritem.DataSource = dtMasterItem;
            MessageBox.Show("Add Item Success!");

            tb_itemid.Text = "";
            tb_colour.Text = "";
            tb_name.Text = "";
            tb_purchaseprice.Text = "";
            tb_salesprice.Text = "";
            tb_size.Text = "";
            cb_category.SelectedIndex = -1;
            btn_edit_ie.Enabled = false;
            btn_delete_ie.Enabled = false;
            dgv_masteritem.ClearSelection();
        }

        private void UpdateItem()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    UPDATE MASTER_ITEM
                    SET 
                        NAME_ITEM = @NameItem,
                        COLOUR_ITEM = @ColourItem,
                        SIZE_ITEM = @SizeItem,
                        CATEGORY_ITEM = @CategoryItem,
                        SALES_PRICE_ITEM = @SalesPriceItem,
                        PURCHASE_PRICE_ITEM = @PurchasePriceItem
                    WHERE ID_ITEM = @ItemID;";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@ItemID", tb_itemid.Text);
                command.Parameters.AddWithValue("@NameItem", tb_name.Text);
                command.Parameters.AddWithValue("@ColourItem", tb_colour.Text);
                command.Parameters.AddWithValue("@SizeItem", tb_size.Text);
                command.Parameters.AddWithValue("@CategoryItem", cb_category.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@SalesPriceItem", int.Parse(tb_salesprice.Text.Replace(".", "")));
                command.Parameters.AddWithValue("@PurchasePriceItem", int.Parse(tb_purchaseprice.Text.Replace(".", "")));
                command.ExecuteNonQuery();
            }

            string selectQuery = "SELECT * FROM vMasterItem;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterItem.Clear();
                    adapter.Fill(dtMasterItem);
                }
            }

            sqlconnect.Close();
            dgv_masteritem.DataSource = dtMasterItem;
            MessageBox.Show("Edit item Success!");

            tb_itemid.Text = "";
            tb_colour.Text = "";
            tb_name.Text = "";
            tb_purchaseprice.Text = "";
            tb_salesprice.Text = "";
            tb_size.Text = "";
            cb_category.SelectedIndex = -1;
            tb_itemid.Enabled = true;
            btn_add_ie.Enabled = true;
            btn_edit_ie.Enabled = false;
            btn_delete_ie.Enabled = false;
            dgv_masteritem.ClearSelection();
        }

        private void UpdateItemAdmin()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();

            string query = @"
                    UPDATE MASTER_ITEM
                    SET 
                        NAME_ITEM = @NameItem,
                        COLOUR_ITEM = @ColourItem,
                        SIZE_ITEM = @SizeItem,
                        CATEGORY_ITEM = @CategoryItem,
                        SALES_PRICE_ITEM = @SalesPriceItem
                    WHERE ID_ITEM = @ItemID;";

            using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@ItemID", tb_itemid.Text);
                command.Parameters.AddWithValue("@NameItem", tb_name.Text);
                command.Parameters.AddWithValue("@ColourItem", tb_colour.Text);
                command.Parameters.AddWithValue("@SizeItem", tb_size.Text);
                command.Parameters.AddWithValue("@CategoryItem", cb_category.SelectedItem?.ToString());
                command.Parameters.AddWithValue("@SalesPriceItem", int.Parse(tb_salesprice.Text.Replace(".", "")));
                command.ExecuteNonQuery();
            }

            string selectQuery = "SELECT * FROM vMasterItemAdmin;";
            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                {
                    dtMasterItem.Clear();
                    adapter.Fill(dtMasterItem);
                }
            }

            sqlconnect.Close();
            dgv_masteritem.DataSource = dtMasterItem;
            MessageBox.Show("Edit item Success!");

            tb_itemid.Text = "";
            tb_colour.Text = "";
            tb_name.Text = "";
            tb_purchaseprice.Text = "";
            tb_salesprice.Text = "";
            tb_size.Text = "";
            cb_category.SelectedIndex = -1;
            tb_itemid.Enabled = true;
            btn_add_ie.Enabled = true;
            btn_edit_ie.Enabled = false;
            btn_delete_ie.Enabled = false;
            dgv_masteritem.ClearSelection();
        }

        private void btn_add_ie_Click(object sender, EventArgs e)
        {
            if (GlobalData.Nama != "Owner") //buat admin
            {
                if (string.IsNullOrEmpty(tb_itemid.Text) || string.IsNullOrEmpty(tb_colour.Text) ||
                string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_size.Text) ||
                string.IsNullOrEmpty(cb_category.Text))
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

                        MessageBox.Show($"Inserted Data ID Item: {tb_itemid.Text}");
                        InsertNewItemAdmin();
                        dgv_masteritem.ClearSelection();
                    }
                }
            }

            else if (GlobalData.Nama == "Owner") //buat owner
            {
                //int purchaseprice = Convert.ToInt32(tb_purchaseprice.Text);
                //int salesprice = Convert.ToInt32(tb_salesprice.Text);

                if (string.IsNullOrEmpty(tb_itemid.Text) || string.IsNullOrEmpty(tb_colour.Text) ||
                string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_size.Text) ||
                string.IsNullOrEmpty(cb_category.Text) || string.IsNullOrEmpty(tb_salesprice.Text) ||
                string.IsNullOrEmpty(tb_purchaseprice.Text))
                {
                    MessageBox.Show("Please fill all the fields.");
                }

                else if (Convert.ToInt32(tb_purchaseprice.Text.Replace(".","")) >= Convert.ToInt32(tb_salesprice.Text.Replace(".","")))
                {
                    MessageBox.Show("Sales Price cannot be lower than Purchase Price! ");
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

                        MessageBox.Show($"Inserted Data ID Item: {tb_itemid.Text}");
                        InsertNewItem();
                    }
                }
            }
        }

        private void btn_edit_ie_Click(object sender, EventArgs e)
        {
            if (GlobalData.Nama != "Owner") //buat admin
            {
                if (string.IsNullOrEmpty(tb_itemid.Text) || string.IsNullOrEmpty(tb_colour.Text) ||
                string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_size.Text) ||
                string.IsNullOrEmpty(cb_category.Text) || string.IsNullOrEmpty(tb_salesprice.Text))
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

                        MessageBox.Show($"Updated Data ID Item: {tb_itemid.Text}");
                        UpdateItemAdmin();
                        dgv_masteritem.ClearSelection();
                    }
                }
            }

            else if (GlobalData.Nama == "Owner") //buat owner
            {
                int purchaseprice = int.Parse(tb_purchaseprice.Text.Replace(".",""));
                int salesprice = int.Parse(tb_salesprice.Text.Replace(".", ""));

                if (string.IsNullOrEmpty(tb_itemid.Text) || string.IsNullOrEmpty(tb_colour.Text) ||
                string.IsNullOrEmpty(tb_name.Text) || string.IsNullOrEmpty(tb_size.Text) ||
                string.IsNullOrEmpty(cb_category.Text) || string.IsNullOrEmpty(tb_salesprice.Text) ||
                string.IsNullOrEmpty(tb_purchaseprice.Text))
                {
                    MessageBox.Show("Please fill all the fields.");
                }

                else if (purchaseprice >= salesprice)
                {
                    MessageBox.Show("Sales Price cannot be lower than Purchase Price! ");
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

                        MessageBox.Show($"Updated Data ID Item: {tb_itemid.Text}");
                        UpdateItem();
                    }
                }
            }
        }

        private void btn_delete_ie_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string itemId = tb_itemid.Text;
                sqlconnect = DatabaseConnection.Connection;
                sqlconnect.Open();

                string query = @"UPDATE MASTER_ITEM SET 
                            STATUS_DEL_ITEM = 1
                            WHERE ID_ITEM = @ItemID;";

                using (MySqlCommand command = new MySqlCommand(query, sqlconnect))
                {
                    command.Parameters.AddWithValue("@ItemID", itemId);
                    command.ExecuteNonQuery();
                }

                // Refresh the data in the DataGridView
                string selectQuery = "SELECT * FROM vMasterItem;";
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, sqlconnect))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        dtMasterItem.Clear();
                        adapter.Fill(dtMasterItem);
                    }
                }

                sqlconnect.Close();
                dgv_masteritem.DataSource = dtMasterItem;
                MessageBox.Show("Delete Item Success!");

                tb_itemid.Text = "";
                tb_colour.Text = "";
                tb_name.Text = "";
                tb_purchaseprice.Text = "";
                tb_salesprice.Text = "";
                tb_size.Text = "";
                cb_category.SelectedIndex = -1;
                tb_itemid.Enabled = true;
                btn_add_ie.Enabled = true;
                btn_edit_ie.Enabled = false;
                btn_delete_ie.Enabled = false;
                dgv_masteritem.ClearSelection();
            }
        }

        private void btn_cancel_ie_Click(object sender, EventArgs e)
        {
            tb_itemid.Text = "";
            tb_colour.Text = "";
            tb_name.Text = "";
            tb_purchaseprice.Text = "";
            tb_salesprice.Text = "";
            tb_size.Text = "";
            cb_category.SelectedIndex = -1;
            tb_itemid.Enabled = true;
            btn_add_ie.Enabled = true;
            btn_delete_ie.Enabled= false;
            btn_edit_ie.Enabled = false;
            dgv_masteritem.ClearSelection();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            mainForm.backtoitem();
        }

        private void dgv_masteritem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalData.Nama != "Owner" && e.RowIndex >= 0 && e.ColumnIndex >= 0) //buat admin
            {
                DataGridViewRow row = dgv_masteritem.Rows[e.RowIndex];

                string id = row.Cells["ID"].Value.ToString();
                string name = row.Cells["Name"].Value.ToString();
                string colour = row.Cells["Colour"].Value.ToString();
                string size = row.Cells["Size"].Value.ToString();
                string category = row.Cells["Category"].Value.ToString();
                string salesPrice = row.Cells["Sales Price"].Value.ToString().Replace(".", "");

                tb_itemid.Text = id;
                tb_name.Text = name;
                tb_colour.Text = colour;
                tb_size.Text = size;
                cb_category.Text = category;
                tb_salesprice.Text = salesPrice;

                btn_add_ie.Enabled = false;
                btn_edit_ie.Enabled = true;
                btn_delete_ie.Enabled = true;
                tb_itemid.Enabled = false;
            }

            else if (GlobalData.Nama == "Owner") //buat owner
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    DataGridViewRow row = dgv_masteritem.Rows[e.RowIndex];

                    string id = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    string colour = row.Cells[2].Value.ToString();
                    string size = row.Cells[3].Value.ToString();
                    string category = row.Cells[4].Value.ToString();
                    string salesPrice = row.Cells[5].Value.ToString().Replace(".", "");
                    string purchasePrice = row.Cells[6].Value.ToString().Replace(".", "");

                    tb_itemid.Text = id;
                    tb_name.Text = name;
                    tb_colour.Text = colour;
                    tb_size.Text = size;
                    cb_category.Text = category;
                    tb_salesprice.Text = salesPrice;
                    tb_purchaseprice.Text = purchasePrice;

                    btn_add_ie.Enabled = false;
                    btn_edit_ie.Enabled = true;
                    btn_delete_ie.Enabled = true;
                    tb_itemid.Enabled = false;
                }
            }
        }

        private void tb_itemid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_itemid.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_salesprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_purchaseprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                // Dapatkan teks saat ini dari TextBox
                string currentText = tb_size.Text;
                // Dapatkan posisi kursor saat ini
                int cursorPosition = tb_size.SelectionStart;

                // Pastikan ada karakter sebelum spasi dan posisi kursor tidak di awal
                if (cursorPosition > 0 && char.IsDigit(currentText[cursorPosition - 1]))
                {
                    // Batalkan input spasi default
                    e.Handled = true;

                    // Sisipkan " × " pada posisi kursor
                    tb_size.Text = currentText.Insert(cursorPosition, " × ");
                    // Pindahkan kursor ke posisi setelah " × "
                    tb_size.SelectionStart = cursorPosition + 3;
                }
            }
        }

        private void tb_salesprice_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (string.IsNullOrEmpty(textBox.Text)) return;

            int cursorPosition = textBox.SelectionStart;
            string unformatted = textBox.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(unformatted, out decimal value))
            {
                textBox.Text = value.ToString("N0").Replace(",",".");
                textBox.SelectionStart = textBox.Text.Length;
            }
            else
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
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

        private void tb_purchaseprice_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (string.IsNullOrEmpty(textBox.Text)) return;

            int cursorPosition = textBox.SelectionStart;
            string unformatted = textBox.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(unformatted, out decimal value))
            {
                textBox.Text = value.ToString("N0").Replace(",", ".");
                textBox.SelectionStart = textBox.Text.Length;
            }
            else
            {
                textBox.Text = "0";
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
