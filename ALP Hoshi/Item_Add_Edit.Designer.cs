namespace ALP_Hoshi
{
    partial class Item_Add_Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label_nama = new System.Windows.Forms.Label();
            this.dgv_masteritem = new System.Windows.Forms.DataGridView();
            this.label_hi = new System.Windows.Forms.Label();
            this.btn_cancel_ie = new System.Windows.Forms.Button();
            this.btn_delete_ie = new System.Windows.Forms.Button();
            this.btn_add_ie = new System.Windows.Forms.Button();
            this.btn_edit_ie = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_size = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tb_purchaseprice = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_colour = new System.Windows.Forms.TextBox();
            this.lb_purchase = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_salesprice = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tb_itemid = new System.Windows.Forms.TextBox();
            this.lb_sales = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_masteritem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Master Data Customer";
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_header.Controls.Add(this.pb_profil);
            this.panel_header.Controls.Add(this.label_nama);
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Margin = new System.Windows.Forms.Padding(2);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1127, 62);
            this.panel_header.TabIndex = 188;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(998, 16);
            this.pb_profil.Margin = new System.Windows.Forms.Padding(2);
            this.pb_profil.Name = "pb_profil";
            this.pb_profil.Size = new System.Drawing.Size(30, 29);
            this.pb_profil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profil.TabIndex = 72;
            this.pb_profil.TabStop = false;
            // 
            // label_nama
            // 
            this.label_nama.AutoSize = true;
            this.label_nama.BackColor = System.Drawing.Color.White;
            this.label_nama.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nama.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_nama.Location = new System.Drawing.Point(1032, 21);
            this.label_nama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nama.Name = "label_nama";
            this.label_nama.Size = new System.Drawing.Size(54, 20);
            this.label_nama.TabIndex = 30;
            this.label_nama.Text = "Owner";
            // 
            // dgv_masteritem
            // 
            this.dgv_masteritem.AllowUserToAddRows = false;
            this.dgv_masteritem.AllowUserToDeleteRows = false;
            this.dgv_masteritem.AllowUserToResizeColumns = false;
            this.dgv_masteritem.AllowUserToResizeRows = false;
            this.dgv_masteritem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_masteritem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_masteritem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_masteritem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_masteritem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_masteritem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_masteritem.EnableHeadersVisualStyles = false;
            this.dgv_masteritem.GridColor = System.Drawing.Color.White;
            this.dgv_masteritem.Location = new System.Drawing.Point(3, 3);
            this.dgv_masteritem.MultiSelect = false;
            this.dgv_masteritem.Name = "dgv_masteritem";
            this.dgv_masteritem.ReadOnly = true;
            this.dgv_masteritem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_masteritem.RowHeadersVisible = false;
            this.dgv_masteritem.RowHeadersWidth = 51;
            this.dgv_masteritem.RowTemplate.Height = 24;
            this.dgv_masteritem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_masteritem.Size = new System.Drawing.Size(1035, 451);
            this.dgv_masteritem.TabIndex = 187;
            this.dgv_masteritem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_masteritem_CellClick);
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(26, 84);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(70, 33);
            this.label_hi.TabIndex = 168;
            this.label_hi.Text = "Item";
            // 
            // btn_cancel_ie
            // 
            this.btn_cancel_ie.BackColor = System.Drawing.Color.Silver;
            this.btn_cancel_ie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel_ie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancel_ie.Location = new System.Drawing.Point(753, 342);
            this.btn_cancel_ie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cancel_ie.Name = "btn_cancel_ie";
            this.btn_cancel_ie.Size = new System.Drawing.Size(120, 36);
            this.btn_cancel_ie.TabIndex = 309;
            this.btn_cancel_ie.Text = "Cancel";
            this.btn_cancel_ie.UseVisualStyleBackColor = false;
            this.btn_cancel_ie.Click += new System.EventHandler(this.btn_cancel_ie_Click);
            // 
            // btn_delete_ie
            // 
            this.btn_delete_ie.BackColor = System.Drawing.Color.Silver;
            this.btn_delete_ie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_ie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_delete_ie.Location = new System.Drawing.Point(627, 342);
            this.btn_delete_ie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete_ie.Name = "btn_delete_ie";
            this.btn_delete_ie.Size = new System.Drawing.Size(120, 36);
            this.btn_delete_ie.TabIndex = 307;
            this.btn_delete_ie.Text = "Delete";
            this.btn_delete_ie.UseVisualStyleBackColor = false;
            this.btn_delete_ie.Click += new System.EventHandler(this.btn_delete_ie_Click);
            // 
            // btn_add_ie
            // 
            this.btn_add_ie.BackColor = System.Drawing.Color.Silver;
            this.btn_add_ie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_ie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_add_ie.Location = new System.Drawing.Point(376, 342);
            this.btn_add_ie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_ie.Name = "btn_add_ie";
            this.btn_add_ie.Size = new System.Drawing.Size(120, 36);
            this.btn_add_ie.TabIndex = 306;
            this.btn_add_ie.Text = "Add";
            this.btn_add_ie.UseVisualStyleBackColor = false;
            this.btn_add_ie.Click += new System.EventHandler(this.btn_add_ie_Click);
            // 
            // btn_edit_ie
            // 
            this.btn_edit_ie.BackColor = System.Drawing.Color.Silver;
            this.btn_edit_ie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_ie.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_edit_ie.Location = new System.Drawing.Point(501, 342);
            this.btn_edit_ie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit_ie.Name = "btn_edit_ie";
            this.btn_edit_ie.Size = new System.Drawing.Size(120, 36);
            this.btn_edit_ie.TabIndex = 308;
            this.btn_edit_ie.Text = "Edit";
            this.btn_edit_ie.UseVisualStyleBackColor = false;
            this.btn_edit_ie.Click += new System.EventHandler(this.btn_edit_ie_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_size);
            this.panel1.Location = new System.Drawing.Point(186, 296);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 29);
            this.panel1.TabIndex = 298;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_size
            // 
            this.tb_size.BackColor = System.Drawing.Color.White;
            this.tb_size.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_size.Location = new System.Drawing.Point(5, 7);
            this.tb_size.Margin = new System.Windows.Forms.Padding(2);
            this.tb_size.MaxLength = 18;
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(233, 15);
            this.tb_size.TabIndex = 160;
            this.tb_size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_size_KeyPress);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tb_purchaseprice);
            this.panel4.Location = new System.Drawing.Point(628, 249);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 29);
            this.panel4.TabIndex = 305;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_purchaseprice
            // 
            this.tb_purchaseprice.BackColor = System.Drawing.Color.White;
            this.tb_purchaseprice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_purchaseprice.Location = new System.Drawing.Point(5, 7);
            this.tb_purchaseprice.Margin = new System.Windows.Forms.Padding(2);
            this.tb_purchaseprice.MaxLength = 15;
            this.tb_purchaseprice.Name = "tb_purchaseprice";
            this.tb_purchaseprice.Size = new System.Drawing.Size(233, 15);
            this.tb_purchaseprice.TabIndex = 160;
            this.tb_purchaseprice.TextChanged += new System.EventHandler(this.tb_purchaseprice_TextChanged);
            this.tb_purchaseprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_purchaseprice_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_colour);
            this.panel2.Location = new System.Drawing.Point(186, 249);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 29);
            this.panel2.TabIndex = 297;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_colour
            // 
            this.tb_colour.BackColor = System.Drawing.Color.White;
            this.tb_colour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_colour.Location = new System.Drawing.Point(5, 7);
            this.tb_colour.Margin = new System.Windows.Forms.Padding(2);
            this.tb_colour.MaxLength = 10;
            this.tb_colour.Name = "tb_colour";
            this.tb_colour.Size = new System.Drawing.Size(233, 15);
            this.tb_colour.TabIndex = 160;
            // 
            // lb_purchase
            // 
            this.lb_purchase.AutoSize = true;
            this.lb_purchase.BackColor = System.Drawing.Color.White;
            this.lb_purchase.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_purchase.ForeColor = System.Drawing.Color.Black;
            this.lb_purchase.Location = new System.Drawing.Point(482, 253);
            this.lb_purchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_purchase.Name = "lb_purchase";
            this.lb_purchase.Size = new System.Drawing.Size(111, 20);
            this.lb_purchase.TabIndex = 303;
            this.lb_purchase.Text = "Purchase Price :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(40, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 295;
            this.label7.Text = "Colour :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(40, 300);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 296;
            this.label8.Text = "Size :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_salesprice);
            this.panel5.Location = new System.Drawing.Point(628, 203);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(245, 29);
            this.panel5.TabIndex = 302;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_salesprice
            // 
            this.tb_salesprice.BackColor = System.Drawing.Color.White;
            this.tb_salesprice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_salesprice.Location = new System.Drawing.Point(5, 7);
            this.tb_salesprice.Margin = new System.Windows.Forms.Padding(2);
            this.tb_salesprice.MaxLength = 15;
            this.tb_salesprice.Name = "tb_salesprice";
            this.tb_salesprice.Size = new System.Drawing.Size(233, 15);
            this.tb_salesprice.TabIndex = 160;
            this.tb_salesprice.TextChanged += new System.EventHandler(this.tb_salesprice_TextChanged);
            this.tb_salesprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_salesprice_KeyPress);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tb_name);
            this.panel7.Location = new System.Drawing.Point(186, 203);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(245, 29);
            this.panel7.TabIndex = 294;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_name
            // 
            this.tb_name.BackColor = System.Drawing.Color.White;
            this.tb_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_name.Location = new System.Drawing.Point(5, 7);
            this.tb_name.Margin = new System.Windows.Forms.Padding(2);
            this.tb_name.MaxLength = 50;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(233, 15);
            this.tb_name.TabIndex = 160;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(482, 160);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 20);
            this.label16.TabIndex = 299;
            this.label16.Text = "Category :";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tb_itemid);
            this.panel6.Location = new System.Drawing.Point(186, 156);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(245, 29);
            this.panel6.TabIndex = 293;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // tb_itemid
            // 
            this.tb_itemid.BackColor = System.Drawing.Color.White;
            this.tb_itemid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_itemid.Location = new System.Drawing.Point(5, 7);
            this.tb_itemid.Margin = new System.Windows.Forms.Padding(2);
            this.tb_itemid.Name = "tb_itemid";
            this.tb_itemid.Size = new System.Drawing.Size(233, 15);
            this.tb_itemid.TabIndex = 160;
            this.tb_itemid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_itemid_KeyPress);
            // 
            // lb_sales
            // 
            this.lb_sales.AutoSize = true;
            this.lb_sales.BackColor = System.Drawing.Color.White;
            this.lb_sales.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sales.ForeColor = System.Drawing.Color.Black;
            this.lb_sales.Location = new System.Drawing.Point(482, 207);
            this.lb_sales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sales.Name = "lb_sales";
            this.lb_sales.Size = new System.Drawing.Size(85, 20);
            this.lb_sales.TabIndex = 300;
            this.lb_sales.Text = "Sales Price :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(40, 160);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 291;
            this.label11.Text = "Item ID :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(40, 207);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 292;
            this.label12.Text = "Name :";
            // 
            // cb_category
            // 
            this.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_category.FormattingEnabled = true;
            this.cb_category.Items.AddRange(new object[] {
            "Container",
            "Pallet"});
            this.cb_category.Location = new System.Drawing.Point(628, 159);
            this.cb_category.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(245, 24);
            this.cb_category.TabIndex = 290;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Silver;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_back.Location = new System.Drawing.Point(965, 120);
            this.btn_back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(120, 36);
            this.btn_back.TabIndex = 310;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ALP_Hoshi.Properties.Resources.Logo_Item___Master_Item;
            this.pictureBox1.Location = new System.Drawing.Point(929, 210);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 311;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_masteritem);
            this.panel3.Location = new System.Drawing.Point(44, 395);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1041, 457);
            this.panel3.TabIndex = 312;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Item_Add_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_cancel_ie);
            this.Controls.Add(this.btn_delete_ie);
            this.Controls.Add(this.btn_add_ie);
            this.Controls.Add(this.btn_edit_ie);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lb_purchase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lb_sales);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.label_hi);
            this.Name = "Item_Add_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_Add_Edit";
            this.Load += new System.EventHandler(this.Item_Add_Edit_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_masteritem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.DataGridView dgv_masteritem;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Button btn_cancel_ie;
        private System.Windows.Forms.Button btn_delete_ie;
        private System.Windows.Forms.Button btn_add_ie;
        private System.Windows.Forms.Button btn_edit_ie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_size;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tb_purchaseprice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_colour;
        private System.Windows.Forms.Label lb_purchase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_salesprice;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tb_itemid;
        private System.Windows.Forms.Label lb_sales;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
    }
}