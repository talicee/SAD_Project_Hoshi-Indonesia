namespace ALP_Hoshi
{
    partial class SalesTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_sales = new System.Windows.Forms.DataGridView();
            this.label_hi = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.tb_SearchBy = new System.Windows.Forms.TextBox();
            this.btn_GenerateDeliveryNote = new System.Windows.Forms.Button();
            this.btn_GenerateInvoice = new System.Windows.Forms.Button();
            this.btn_EditOrder = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.cobox_SearchBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_NewOrder = new System.Windows.Forms.Button();
            this.panel_header = new System.Windows.Forms.Panel();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_receivable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).BeginInit();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receivable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_sales
            // 
            this.dgv_sales.AllowUserToAddRows = false;
            this.dgv_sales.AllowUserToDeleteRows = false;
            this.dgv_sales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_sales.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_sales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_sales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_sales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_sales.EnableHeadersVisualStyles = false;
            this.dgv_sales.GridColor = System.Drawing.Color.White;
            this.dgv_sales.Location = new System.Drawing.Point(7, 8);
            this.dgv_sales.MultiSelect = false;
            this.dgv_sales.Name = "dgv_sales";
            this.dgv_sales.ReadOnly = true;
            this.dgv_sales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_sales.RowHeadersVisible = false;
            this.dgv_sales.RowHeadersWidth = 51;
            this.dgv_sales.RowTemplate.Height = 24;
            this.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sales.Size = new System.Drawing.Size(1020, 310);
            this.dgv_sales.TabIndex = 145;
            this.dgv_sales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sales_CellClick);
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(37, 105);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(218, 33);
            this.label_hi.TabIndex = 143;
            this.label_hi.Text = "Sales Transaction";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.RosyBrown;
            this.btn_search.Location = new System.Drawing.Point(593, 433);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(32, 29);
            this.btn_search.TabIndex = 142;
            this.btn_search.Text = "🔍";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tb_SearchBy
            // 
            this.tb_SearchBy.BackColor = System.Drawing.Color.White;
            this.tb_SearchBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SearchBy.Location = new System.Drawing.Point(8, 6);
            this.tb_SearchBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_SearchBy.Name = "tb_SearchBy";
            this.tb_SearchBy.Size = new System.Drawing.Size(226, 15);
            this.tb_SearchBy.TabIndex = 141;
            // 
            // btn_GenerateDeliveryNote
            // 
            this.btn_GenerateDeliveryNote.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_GenerateDeliveryNote.Enabled = false;
            this.btn_GenerateDeliveryNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerateDeliveryNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GenerateDeliveryNote.Location = new System.Drawing.Point(45, 821);
            this.btn_GenerateDeliveryNote.Name = "btn_GenerateDeliveryNote";
            this.btn_GenerateDeliveryNote.Size = new System.Drawing.Size(187, 28);
            this.btn_GenerateDeliveryNote.TabIndex = 140;
            this.btn_GenerateDeliveryNote.Text = "Generate Delivery Note";
            this.btn_GenerateDeliveryNote.UseVisualStyleBackColor = false;
            this.btn_GenerateDeliveryNote.Click += new System.EventHandler(this.btn_GenerateDeliveryNote_Click);
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_GenerateInvoice.Enabled = false;
            this.btn_GenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerateInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(237, 821);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(165, 28);
            this.btn_GenerateInvoice.TabIndex = 139;
            this.btn_GenerateInvoice.Text = "Generate Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = false;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // btn_EditOrder
            // 
            this.btn_EditOrder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_EditOrder.Enabled = false;
            this.btn_EditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_EditOrder.Location = new System.Drawing.Point(858, 821);
            this.btn_EditOrder.Name = "btn_EditOrder";
            this.btn_EditOrder.Size = new System.Drawing.Size(103, 28);
            this.btn_EditOrder.TabIndex = 137;
            this.btn_EditOrder.Text = "Edit Order";
            this.btn_EditOrder.UseVisualStyleBackColor = false;
            this.btn_EditOrder.Click += new System.EventHandler(this.btn_EditOrder_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_delete.Enabled = false;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_delete.Location = new System.Drawing.Point(965, 821);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(103, 28);
            this.btn_delete.TabIndex = 136;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_clear.Location = new System.Drawing.Point(977, 438);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(103, 28);
            this.btn_clear.TabIndex = 135;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // cobox_SearchBy
            // 
            this.cobox_SearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobox_SearchBy.FormattingEnabled = true;
            this.cobox_SearchBy.Items.AddRange(new object[] {
            "Sales ID",
            "Customer"});
            this.cobox_SearchBy.Location = new System.Drawing.Point(122, 437);
            this.cobox_SearchBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cobox_SearchBy.Name = "cobox_SearchBy";
            this.cobox_SearchBy.Size = new System.Drawing.Size(212, 24);
            this.cobox_SearchBy.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 133;
            this.label4.Text = "Search by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 26);
            this.label3.TabIndex = 132;
            this.label3.Text = "Receivable Reminder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 27);
            this.label5.TabIndex = 131;
            // 
            // btn_NewOrder
            // 
            this.btn_NewOrder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_NewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_NewOrder.Location = new System.Drawing.Point(750, 821);
            this.btn_NewOrder.Name = "btn_NewOrder";
            this.btn_NewOrder.Size = new System.Drawing.Size(103, 28);
            this.btn_NewOrder.TabIndex = 138;
            this.btn_NewOrder.Text = "New Order";
            this.btn_NewOrder.UseVisualStyleBackColor = false;
            this.btn_NewOrder.Click += new System.EventHandler(this.btn_NewOrder_Click);
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_header.Controls.Add(this.pb_profil);
            this.panel_header.Controls.Add(this.label_nama);
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Location = new System.Drawing.Point(-1, -1);
            this.panel_header.Margin = new System.Windows.Forms.Padding(2);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1127, 62);
            this.panel_header.TabIndex = 146;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(988, 17);
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
            this.label_nama.Location = new System.Drawing.Point(1022, 22);
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
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Stock Report";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_SearchBy);
            this.panel3.Location = new System.Drawing.Point(345, 435);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 29);
            this.panel3.TabIndex = 289;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_sales);
            this.panel1.Location = new System.Drawing.Point(45, 476);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 328);
            this.panel1.TabIndex = 290;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_receivable);
            this.panel2.Location = new System.Drawing.Point(43, 195);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 223);
            this.panel2.TabIndex = 291;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgv_receivable
            // 
            this.dgv_receivable.AllowUserToAddRows = false;
            this.dgv_receivable.AllowUserToDeleteRows = false;
            this.dgv_receivable.AllowUserToResizeColumns = false;
            this.dgv_receivable.AllowUserToResizeRows = false;
            this.dgv_receivable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_receivable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_receivable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_receivable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_receivable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_receivable.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_receivable.EnableHeadersVisualStyles = false;
            this.dgv_receivable.GridColor = System.Drawing.Color.White;
            this.dgv_receivable.Location = new System.Drawing.Point(15, 10);
            this.dgv_receivable.MultiSelect = false;
            this.dgv_receivable.Name = "dgv_receivable";
            this.dgv_receivable.ReadOnly = true;
            this.dgv_receivable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_receivable.RowHeadersVisible = false;
            this.dgv_receivable.RowHeadersWidth = 51;
            this.dgv_receivable.RowTemplate.Height = 24;
            this.dgv_receivable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_receivable.Size = new System.Drawing.Size(1004, 202);
            this.dgv_receivable.TabIndex = 292;
            // 
            // SalesTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.label_hi);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_GenerateDeliveryNote);
            this.Controls.Add(this.btn_GenerateInvoice);
            this.Controls.Add(this.btn_EditOrder);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.cobox_SearchBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_NewOrder);
            this.Controls.Add(this.panel1);
            this.Name = "SalesTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesTransaction";
            this.Load += new System.EventHandler(this.SalesTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receivable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_sales;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tb_SearchBy;
        private System.Windows.Forms.Button btn_GenerateDeliveryNote;
        private System.Windows.Forms.Button btn_GenerateInvoice;
        private System.Windows.Forms.Button btn_EditOrder;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ComboBox cobox_SearchBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_NewOrder;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_receivable;
    }
}