namespace ALP_Hoshi
{
    partial class PurchaseTransaction_Add_Edit
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
            this.tb_grandTotal = new System.Windows.Forms.Label();
            this.cb_top = new System.Windows.Forms.ComboBox();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.tb_pricepcs = new System.Windows.Forms.TextBox();
            this.listbox_item = new System.Windows.Forms.ListBox();
            this.btn_addedit = new System.Windows.Forms.Button();
            this.listbox_supplier = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_saveTransaction = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.datetime_duedate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.datetime_trans = new System.Windows.Forms.DateTimePicker();
            this.tb_totalPrice = new System.Windows.Forms.TextBox();
            this.dgv_detailpurchase = new System.Windows.Forms.DataGridView();
            this.tb_quantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_hi = new System.Windows.Forms.Label();
            this.tb_itemName = new System.Windows.Forms.TextBox();
            this.tb_itemID = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_deleteItem = new System.Windows.Forms.Button();
            this.tb_supplierInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.tb_city = new System.Windows.Forms.TextBox();
            this.tb_supplier = new System.Windows.Forms.TextBox();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.tb_supplierID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_PurchaseID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detailpurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.panel_header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_grandTotal
            // 
            this.tb_grandTotal.AutoSize = true;
            this.tb_grandTotal.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_grandTotal.Location = new System.Drawing.Point(10, 4);
            this.tb_grandTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tb_grandTotal.Name = "tb_grandTotal";
            this.tb_grandTotal.Size = new System.Drawing.Size(17, 20);
            this.tb_grandTotal.TabIndex = 244;
            this.tb_grandTotal.Text = "0";
            // 
            // cb_top
            // 
            this.cb_top.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_top.Enabled = false;
            this.cb_top.FormattingEnabled = true;
            this.cb_top.ItemHeight = 16;
            this.cb_top.Items.AddRange(new object[] {
            "30 Days",
            "Cash"});
            this.cb_top.Location = new System.Drawing.Point(806, 209);
            this.cb_top.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_top.Name = "cb_top";
            this.cb_top.Size = new System.Drawing.Size(255, 24);
            this.cb_top.TabIndex = 243;
            this.cb_top.TextChanged += new System.EventHandler(this.cb_top_TextChanged);
            // 
            // cb_status
            // 
            this.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.cb_status.Location = new System.Drawing.Point(808, 246);
            this.cb_status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(255, 24);
            this.cb_status.TabIndex = 242;
            // 
            // tb_pricepcs
            // 
            this.tb_pricepcs.BackColor = System.Drawing.Color.White;
            this.tb_pricepcs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pricepcs.Enabled = false;
            this.tb_pricepcs.Location = new System.Drawing.Point(6, 6);
            this.tb_pricepcs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_pricepcs.Name = "tb_pricepcs";
            this.tb_pricepcs.Size = new System.Drawing.Size(275, 15);
            this.tb_pricepcs.TabIndex = 213;
            this.tb_pricepcs.TextChanged += new System.EventHandler(this.tb_pricepcs_TextChanged);
            // 
            // listbox_item
            // 
            this.listbox_item.FormattingEnabled = true;
            this.listbox_item.ItemHeight = 16;
            this.listbox_item.Location = new System.Drawing.Point(164, 81);
            this.listbox_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listbox_item.Name = "listbox_item";
            this.listbox_item.Size = new System.Drawing.Size(275, 68);
            this.listbox_item.TabIndex = 214;
            this.listbox_item.Visible = false;
            this.listbox_item.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listbox_item_MouseClick);
            this.listbox_item.MouseLeave += new System.EventHandler(this.listbox_item_MouseLeave);
            // 
            // btn_addedit
            // 
            this.btn_addedit.BackColor = System.Drawing.Color.DarkGray;
            this.btn_addedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addedit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_addedit.Location = new System.Drawing.Point(809, 99);
            this.btn_addedit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addedit.Name = "btn_addedit";
            this.btn_addedit.Size = new System.Drawing.Size(107, 28);
            this.btn_addedit.TabIndex = 212;
            this.btn_addedit.Text = "Add/Edit Detail";
            this.btn_addedit.UseVisualStyleBackColor = false;
            this.btn_addedit.Click += new System.EventHandler(this.btn_addedit_Click);
            // 
            // listbox_supplier
            // 
            this.listbox_supplier.FormattingEnabled = true;
            this.listbox_supplier.ItemHeight = 16;
            this.listbox_supplier.Location = new System.Drawing.Point(195, 272);
            this.listbox_supplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listbox_supplier.Name = "listbox_supplier";
            this.listbox_supplier.Size = new System.Drawing.Size(278, 68);
            this.listbox_supplier.TabIndex = 241;
            this.listbox_supplier.Visible = false;
            this.listbox_supplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listbox_supplier_MouseClick);
            this.listbox_supplier.MouseLeave += new System.EventHandler(this.listbox_supplier_MouseLeave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(566, 53);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 20);
            this.label19.TabIndex = 207;
            this.label19.Text = "Total Price :";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.DimGray;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_back.Location = new System.Drawing.Point(967, 86);
            this.btn_back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(98, 28);
            this.btn_back.TabIndex = 240;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(566, 14);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 20);
            this.label18.TabIndex = 208;
            this.label18.Text = "Quantity :";
            // 
            // btn_saveTransaction
            // 
            this.btn_saveTransaction.BackColor = System.Drawing.Color.DarkGray;
            this.btn_saveTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveTransaction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_saveTransaction.Location = new System.Drawing.Point(898, 833);
            this.btn_saveTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_saveTransaction.Name = "btn_saveTransaction";
            this.btn_saveTransaction.Size = new System.Drawing.Size(184, 28);
            this.btn_saveTransaction.TabIndex = 239;
            this.btn_saveTransaction.Text = "Save New/Edited Transaction";
            this.btn_saveTransaction.UseVisualStyleBackColor = false;
            this.btn_saveTransaction.Click += new System.EventHandler(this.btn_saveTransaction_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 91);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 20);
            this.label15.TabIndex = 206;
            this.label15.Text = "Price / pcs :";
            // 
            // datetime_duedate
            // 
            this.datetime_duedate.Enabled = false;
            this.datetime_duedate.Location = new System.Drawing.Point(808, 176);
            this.datetime_duedate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datetime_duedate.Name = "datetime_duedate";
            this.datetime_duedate.Size = new System.Drawing.Size(255, 22);
            this.datetime_duedate.TabIndex = 238;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 52);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 210;
            this.label17.Text = "Item Name :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 14);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 20);
            this.label16.TabIndex = 209;
            this.label16.Text = "Item ID :";
            // 
            // datetime_trans
            // 
            this.datetime_trans.Location = new System.Drawing.Point(191, 176);
            this.datetime_trans.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datetime_trans.Name = "datetime_trans";
            this.datetime_trans.Size = new System.Drawing.Size(279, 22);
            this.datetime_trans.TabIndex = 237;
            this.datetime_trans.ValueChanged += new System.EventHandler(this.datetime_trans_ValueChanged);
            // 
            // tb_totalPrice
            // 
            this.tb_totalPrice.BackColor = System.Drawing.Color.White;
            this.tb_totalPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_totalPrice.Enabled = false;
            this.tb_totalPrice.Location = new System.Drawing.Point(7, 7);
            this.tb_totalPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_totalPrice.Name = "tb_totalPrice";
            this.tb_totalPrice.Size = new System.Drawing.Size(244, 15);
            this.tb_totalPrice.TabIndex = 205;
            this.tb_totalPrice.TextChanged += new System.EventHandler(this.tb_totalPrice_TextChanged);
            // 
            // dgv_detailpurchase
            // 
            this.dgv_detailpurchase.AllowUserToAddRows = false;
            this.dgv_detailpurchase.AllowUserToDeleteRows = false;
            this.dgv_detailpurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_detailpurchase.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_detailpurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detailpurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_detailpurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detailpurchase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_detailpurchase.EnableHeadersVisualStyles = false;
            this.dgv_detailpurchase.GridColor = System.Drawing.Color.White;
            this.dgv_detailpurchase.Location = new System.Drawing.Point(14, 10);
            this.dgv_detailpurchase.MultiSelect = false;
            this.dgv_detailpurchase.Name = "dgv_detailpurchase";
            this.dgv_detailpurchase.ReadOnly = true;
            this.dgv_detailpurchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_detailpurchase.RowHeadersVisible = false;
            this.dgv_detailpurchase.RowHeadersWidth = 51;
            this.dgv_detailpurchase.RowTemplate.Height = 24;
            this.dgv_detailpurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_detailpurchase.Size = new System.Drawing.Size(1024, 172);
            this.dgv_detailpurchase.TabIndex = 236;
            this.dgv_detailpurchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detailpurchase_CellClick);
            // 
            // tb_quantity
            // 
            this.tb_quantity.BackColor = System.Drawing.Color.White;
            this.tb_quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_quantity.Location = new System.Drawing.Point(7, 6);
            this.tb_quantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_quantity.MaxLength = 10;
            this.tb_quantity.Name = "tb_quantity";
            this.tb_quantity.Size = new System.Drawing.Size(244, 15);
            this.tb_quantity.TabIndex = 204;
            this.tb_quantity.TextChanged += new System.EventHandler(this.tb_quantity_TextChanged);
            this.tb_quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_quantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 362);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 235;
            this.label2.Text = "Detail Transaction";
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(26, 80);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(265, 33);
            this.label_hi.TabIndex = 234;
            this.label_hi.Text = "Purchase Transaction";
            // 
            // tb_itemName
            // 
            this.tb_itemName.BackColor = System.Drawing.Color.White;
            this.tb_itemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_itemName.Location = new System.Drawing.Point(5, 7);
            this.tb_itemName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_itemName.MaxLength = 50;
            this.tb_itemName.Name = "tb_itemName";
            this.tb_itemName.Size = new System.Drawing.Size(275, 15);
            this.tb_itemName.TabIndex = 211;
            this.tb_itemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_itemName_KeyPress);
            this.tb_itemName.Leave += new System.EventHandler(this.tb_itemName_Leave);
            // 
            // tb_itemID
            // 
            this.tb_itemID.BackColor = System.Drawing.Color.White;
            this.tb_itemID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_itemID.Enabled = false;
            this.tb_itemID.Location = new System.Drawing.Point(5, 6);
            this.tb_itemID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_itemID.Name = "tb_itemID";
            this.tb_itemID.Size = new System.Drawing.Size(275, 15);
            this.tb_itemID.TabIndex = 203;
            this.tb_itemID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_itemID_MouseClick);
            this.tb_itemID.TextChanged += new System.EventHandler(this.tb_itemID_TextChanged);
            this.tb_itemID.MouseLeave += new System.EventHandler(this.tb_itemID_MouseLeave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(674, 787);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 20);
            this.label20.TabIndex = 233;
            this.label20.Text = "Grand Total :";
            // 
            // btn_deleteItem
            // 
            this.btn_deleteItem.BackColor = System.Drawing.Color.DarkGray;
            this.btn_deleteItem.Enabled = false;
            this.btn_deleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deleteItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_deleteItem.Location = new System.Drawing.Point(930, 99);
            this.btn_deleteItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_deleteItem.Name = "btn_deleteItem";
            this.btn_deleteItem.Size = new System.Drawing.Size(103, 28);
            this.btn_deleteItem.TabIndex = 232;
            this.btn_deleteItem.Text = "Delete Detail";
            this.btn_deleteItem.UseVisualStyleBackColor = false;
            this.btn_deleteItem.Click += new System.EventHandler(this.btn_deleteItem_Click);
            // 
            // tb_supplierInvoiceNumber
            // 
            this.tb_supplierInvoiceNumber.BackColor = System.Drawing.Color.White;
            this.tb_supplierInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_supplierInvoiceNumber.Location = new System.Drawing.Point(7, 5);
            this.tb_supplierInvoiceNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_supplierInvoiceNumber.MaxLength = 30;
            this.tb_supplierInvoiceNumber.Name = "tb_supplierInvoiceNumber";
            this.tb_supplierInvoiceNumber.Size = new System.Drawing.Size(245, 15);
            this.tb_supplierInvoiceNumber.TabIndex = 231;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(580, 246);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 20);
            this.label14.TabIndex = 230;
            this.label14.Text = "Payment Status : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(580, 174);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(203, 20);
            this.label13.TabIndex = 229;
            this.label13.Text = "Due Date Purchase Payment : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(580, 209);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 228;
            this.label12.Text = "TOP : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(580, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 20);
            this.label10.TabIndex = 227;
            this.label10.Text = "Supplier Invoice Number :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 284);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 226;
            this.label9.Text = "Address : ";
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(997, 15);
            this.pb_profil.Margin = new System.Windows.Forms.Padding(2);
            this.pb_profil.Name = "pb_profil";
            this.pb_profil.Size = new System.Drawing.Size(30, 29);
            this.pb_profil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profil.TabIndex = 72;
            this.pb_profil.TabStop = false;
            // 
            // tb_city
            // 
            this.tb_city.BackColor = System.Drawing.Color.White;
            this.tb_city.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_city.Location = new System.Drawing.Point(5, 6);
            this.tb_city.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_city.Name = "tb_city";
            this.tb_city.Size = new System.Drawing.Size(277, 15);
            this.tb_city.TabIndex = 225;
            // 
            // tb_supplier
            // 
            this.tb_supplier.BackColor = System.Drawing.Color.White;
            this.tb_supplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_supplier.Location = new System.Drawing.Point(6, 6);
            this.tb_supplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_supplier.MaxLength = 50;
            this.tb_supplier.Name = "tb_supplier";
            this.tb_supplier.Size = new System.Drawing.Size(276, 15);
            this.tb_supplier.TabIndex = 224;
            this.tb_supplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_supplier_KeyPress);
            // 
            // tb_address
            // 
            this.tb_address.BackColor = System.Drawing.Color.White;
            this.tb_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_address.Location = new System.Drawing.Point(5, 6);
            this.tb_address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_address.MaxLength = 100;
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(863, 15);
            this.tb_address.TabIndex = 223;
            // 
            // tb_supplierID
            // 
            this.tb_supplierID.BackColor = System.Drawing.Color.White;
            this.tb_supplierID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_supplierID.Enabled = false;
            this.tb_supplierID.Location = new System.Drawing.Point(5, 6);
            this.tb_supplierID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_supplierID.Name = "tb_supplierID";
            this.tb_supplierID.Size = new System.Drawing.Size(277, 15);
            this.tb_supplierID.TabIndex = 222;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 324);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 221;
            this.label8.Text = "City : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 246);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 220;
            this.label7.Text = "Supplier : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 219;
            this.label6.Text = "Supplier ID : ";
            // 
            // tb_PurchaseID
            // 
            this.tb_PurchaseID.BackColor = System.Drawing.Color.White;
            this.tb_PurchaseID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_PurchaseID.Enabled = false;
            this.tb_PurchaseID.Location = new System.Drawing.Point(5, 6);
            this.tb_PurchaseID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_PurchaseID.Name = "tb_PurchaseID";
            this.tb_PurchaseID.Size = new System.Drawing.Size(277, 15);
            this.tb_PurchaseID.TabIndex = 218;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 217;
            this.label3.Text = "Transaction Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 216;
            this.label4.Text = "Purchase ID :";
            // 
            // label_nama
            // 
            this.label_nama.AutoSize = true;
            this.label_nama.BackColor = System.Drawing.Color.White;
            this.label_nama.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nama.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_nama.Location = new System.Drawing.Point(1031, 21);
            this.label_nama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nama.Name = "label_nama";
            this.label_nama.Size = new System.Drawing.Size(54, 20);
            this.label_nama.TabIndex = 30;
            this.label_nama.Text = "Owner";
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
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Purchase Transaction ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1119, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 215;
            this.label5.Text = "Owner";
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
            this.panel_header.TabIndex = 202;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_PurchaseID);
            this.panel1.Location = new System.Drawing.Point(191, 138);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 29);
            this.panel1.TabIndex = 245;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_supplier);
            this.panel2.Location = new System.Drawing.Point(191, 243);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 29);
            this.panel2.TabIndex = 246;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_supplierID);
            this.panel3.Location = new System.Drawing.Point(191, 205);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 29);
            this.panel3.TabIndex = 247;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tb_city);
            this.panel4.Location = new System.Drawing.Point(191, 322);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 29);
            this.panel4.TabIndex = 248;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_address);
            this.panel5.Location = new System.Drawing.Point(191, 282);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(875, 29);
            this.panel5.TabIndex = 249;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tb_supplierInvoiceNumber);
            this.panel6.Location = new System.Drawing.Point(808, 138);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(258, 29);
            this.panel6.TabIndex = 250;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tb_itemID);
            this.panel9.Location = new System.Drawing.Point(158, 14);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(287, 29);
            this.panel9.TabIndex = 246;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tb_itemName);
            this.panel10.Location = new System.Drawing.Point(158, 51);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(287, 29);
            this.panel10.TabIndex = 253;
            this.panel10.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tb_pricepcs);
            this.panel11.Location = new System.Drawing.Point(158, 89);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(287, 29);
            this.panel11.TabIndex = 254;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.tb_quantity);
            this.panel12.Location = new System.Drawing.Point(775, 9);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(258, 29);
            this.panel12.TabIndex = 247;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tb_totalPrice);
            this.panel13.Location = new System.Drawing.Point(775, 51);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(258, 29);
            this.panel13.TabIndex = 255;
            this.panel13.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel13);
            this.panel14.Controls.Add(this.panel12);
            this.panel14.Controls.Add(this.btn_deleteItem);
            this.panel14.Controls.Add(this.panel11);
            this.panel14.Controls.Add(this.label16);
            this.panel14.Controls.Add(this.panel10);
            this.panel14.Controls.Add(this.label17);
            this.panel14.Controls.Add(this.panel9);
            this.panel14.Controls.Add(this.label15);
            this.panel14.Controls.Add(this.label18);
            this.panel14.Controls.Add(this.label19);
            this.panel14.Controls.Add(this.btn_addedit);
            this.panel14.Controls.Add(this.listbox_item);
            this.panel14.Location = new System.Drawing.Point(31, 394);
            this.panel14.Margin = new System.Windows.Forms.Padding(2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1051, 157);
            this.panel14.TabIndex = 248;
            this.panel14.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.dgv_detailpurchase);
            this.panel15.Location = new System.Drawing.Point(31, 570);
            this.panel15.Margin = new System.Windows.Forms.Padding(2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1051, 194);
            this.panel15.TabIndex = 253;
            this.panel15.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tb_grandTotal);
            this.panel16.Location = new System.Drawing.Point(789, 784);
            this.panel16.Margin = new System.Windows.Forms.Padding(2);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(293, 29);
            this.panel16.TabIndex = 254;
            this.panel16.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // PurchaseTransaction_Add_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.cb_top);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.listbox_supplier);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_saveTransaction);
            this.Controls.Add(this.datetime_duedate);
            this.Controls.Add(this.datetime_trans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_hi);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel15);
            this.Name = "PurchaseTransaction_Add_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseTransaction_Add_Edit";
            this.Load += new System.EventHandler(this.PurchaseTransaction_Add_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detailpurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tb_grandTotal;
        private System.Windows.Forms.ComboBox cb_top;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.TextBox tb_pricepcs;
        private System.Windows.Forms.ListBox listbox_item;
        private System.Windows.Forms.Button btn_addedit;
        private System.Windows.Forms.ListBox listbox_supplier;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_saveTransaction;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker datetime_duedate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker datetime_trans;
        private System.Windows.Forms.TextBox tb_totalPrice;
        private System.Windows.Forms.DataGridView dgv_detailpurchase;
        private System.Windows.Forms.TextBox tb_quantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.TextBox tb_itemName;
        private System.Windows.Forms.TextBox tb_itemID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_deleteItem;
        private System.Windows.Forms.TextBox tb_supplierInvoiceNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.TextBox tb_city;
        private System.Windows.Forms.TextBox tb_supplier;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.TextBox tb_supplierID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_PurchaseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
    }
}