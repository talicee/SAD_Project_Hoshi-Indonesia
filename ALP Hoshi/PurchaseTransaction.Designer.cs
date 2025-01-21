namespace ALP_Hoshi
{
    partial class PurchaseTransaction
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
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label_hi = new System.Windows.Forms.Label();
            this.btn_GenerateDeliveryNote = new System.Windows.Forms.Button();
            this.btn_GenerateInvoice = new System.Windows.Forms.Button();
            this.btn_NewOrder = new System.Windows.Forms.Button();
            this.btn_EditOrder = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.cobox_SearchBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_SearchBy = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_debt = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_purchase = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.panel_header.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_debt)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_purchase)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(997, 14);
            this.pb_profil.Margin = new System.Windows.Forms.Padding(2);
            this.pb_profil.Name = "pb_profil";
            this.pb_profil.Size = new System.Drawing.Size(30, 29);
            this.pb_profil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profil.TabIndex = 72;
            this.pb_profil.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.DarkGray;
            this.btn_delete.Enabled = false;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_delete.Location = new System.Drawing.Point(959, 817);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(120, 36);
            this.btn_delete.TabIndex = 130;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(25, 93);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(265, 33);
            this.label_hi.TabIndex = 127;
            this.label_hi.Text = "Purchase Transaction";
            // 
            // btn_GenerateDeliveryNote
            // 
            this.btn_GenerateDeliveryNote.BackColor = System.Drawing.Color.DarkGray;
            this.btn_GenerateDeliveryNote.Enabled = false;
            this.btn_GenerateDeliveryNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerateDeliveryNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GenerateDeliveryNote.Location = new System.Drawing.Point(41, 817);
            this.btn_GenerateDeliveryNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GenerateDeliveryNote.Name = "btn_GenerateDeliveryNote";
            this.btn_GenerateDeliveryNote.Size = new System.Drawing.Size(200, 36);
            this.btn_GenerateDeliveryNote.TabIndex = 124;
            this.btn_GenerateDeliveryNote.Text = "Generate Delivery Note";
            this.btn_GenerateDeliveryNote.UseVisualStyleBackColor = false;
            this.btn_GenerateDeliveryNote.Click += new System.EventHandler(this.btn_GenerateDeliveryNote_Click);
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.BackColor = System.Drawing.Color.DarkGray;
            this.btn_GenerateInvoice.Enabled = false;
            this.btn_GenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerateInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(248, 817);
            this.btn_GenerateInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(200, 36);
            this.btn_GenerateInvoice.TabIndex = 123;
            this.btn_GenerateInvoice.Text = "Generate Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = false;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // btn_NewOrder
            // 
            this.btn_NewOrder.BackColor = System.Drawing.Color.DarkGray;
            this.btn_NewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_NewOrder.Location = new System.Drawing.Point(707, 817);
            this.btn_NewOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_NewOrder.Name = "btn_NewOrder";
            this.btn_NewOrder.Size = new System.Drawing.Size(120, 36);
            this.btn_NewOrder.TabIndex = 122;
            this.btn_NewOrder.Text = "New Order";
            this.btn_NewOrder.UseVisualStyleBackColor = false;
            this.btn_NewOrder.Click += new System.EventHandler(this.btn_NewOrder_Click);
            // 
            // btn_EditOrder
            // 
            this.btn_EditOrder.BackColor = System.Drawing.Color.DarkGray;
            this.btn_EditOrder.Enabled = false;
            this.btn_EditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_EditOrder.Location = new System.Drawing.Point(833, 817);
            this.btn_EditOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_EditOrder.Name = "btn_EditOrder";
            this.btn_EditOrder.Size = new System.Drawing.Size(120, 36);
            this.btn_EditOrder.TabIndex = 121;
            this.btn_EditOrder.Text = "Edit Order";
            this.btn_EditOrder.UseVisualStyleBackColor = false;
            this.btn_EditOrder.Click += new System.EventHandler(this.btn_EditOrder_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.DarkGray;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_clear.Location = new System.Drawing.Point(959, 428);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(120, 36);
            this.btn_clear.TabIndex = 120;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // cobox_SearchBy
            // 
            this.cobox_SearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobox_SearchBy.FormattingEnabled = true;
            this.cobox_SearchBy.Items.AddRange(new object[] {
            "Purchase ID",
            "Supplier"});
            this.cobox_SearchBy.Location = new System.Drawing.Point(120, 436);
            this.cobox_SearchBy.Margin = new System.Windows.Forms.Padding(4);
            this.cobox_SearchBy.Name = "cobox_SearchBy";
            this.cobox_SearchBy.Size = new System.Drawing.Size(212, 24);
            this.cobox_SearchBy.TabIndex = 119;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 26);
            this.label3.TabIndex = 117;
            this.label3.Text = "Debt Reminder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 27);
            this.label2.TabIndex = 116;
            // 
            // label_nama
            // 
            this.label_nama.AutoSize = true;
            this.label_nama.BackColor = System.Drawing.Color.White;
            this.label_nama.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nama.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_nama.Location = new System.Drawing.Point(1031, 20);
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
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Purchase Transaction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 436);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "Search by";
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
            this.panel_header.TabIndex = 115;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_SearchBy);
            this.panel3.Location = new System.Drawing.Point(337, 434);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 29);
            this.panel3.TabIndex = 288;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tb_SearchBy
            // 
            this.tb_SearchBy.BackColor = System.Drawing.Color.White;
            this.tb_SearchBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SearchBy.Location = new System.Drawing.Point(7, 7);
            this.tb_SearchBy.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SearchBy.Name = "tb_SearchBy";
            this.tb_SearchBy.Size = new System.Drawing.Size(230, 15);
            this.tb_SearchBy.TabIndex = 160;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.RosyBrown;
            this.btn_search.Location = new System.Drawing.Point(587, 434);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(32, 29);
            this.btn_search.TabIndex = 143;
            this.btn_search.Text = "🔍";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.panel_search_MS_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_debt);
            this.panel2.Location = new System.Drawing.Point(43, 195);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 223);
            this.panel2.TabIndex = 293;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dgv_debt
            // 
            this.dgv_debt.AllowUserToAddRows = false;
            this.dgv_debt.AllowUserToDeleteRows = false;
            this.dgv_debt.AllowUserToResizeColumns = false;
            this.dgv_debt.AllowUserToResizeRows = false;
            this.dgv_debt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_debt.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_debt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_debt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_debt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_debt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_debt.EnableHeadersVisualStyles = false;
            this.dgv_debt.GridColor = System.Drawing.Color.White;
            this.dgv_debt.Location = new System.Drawing.Point(15, 10);
            this.dgv_debt.MultiSelect = false;
            this.dgv_debt.Name = "dgv_debt";
            this.dgv_debt.ReadOnly = true;
            this.dgv_debt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_debt.RowHeadersVisible = false;
            this.dgv_debt.RowHeadersWidth = 51;
            this.dgv_debt.RowTemplate.Height = 24;
            this.dgv_debt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_debt.Size = new System.Drawing.Size(1004, 202);
            this.dgv_debt.TabIndex = 292;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_purchase);
            this.panel1.Location = new System.Drawing.Point(43, 476);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 328);
            this.panel1.TabIndex = 292;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgv_purchase
            // 
            this.dgv_purchase.AllowUserToAddRows = false;
            this.dgv_purchase.AllowUserToDeleteRows = false;
            this.dgv_purchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_purchase.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_purchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_purchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_purchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_purchase.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_purchase.EnableHeadersVisualStyles = false;
            this.dgv_purchase.GridColor = System.Drawing.Color.White;
            this.dgv_purchase.Location = new System.Drawing.Point(7, 8);
            this.dgv_purchase.MultiSelect = false;
            this.dgv_purchase.Name = "dgv_purchase";
            this.dgv_purchase.ReadOnly = true;
            this.dgv_purchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_purchase.RowHeadersVisible = false;
            this.dgv_purchase.RowHeadersWidth = 51;
            this.dgv_purchase.RowTemplate.Height = 24;
            this.dgv_purchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_purchase.Size = new System.Drawing.Size(1020, 310);
            this.dgv_purchase.TabIndex = 145;
            this.dgv_purchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_purchase_CellClick);
            // 
            // PurchaseTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label_hi);
            this.Controls.Add(this.btn_GenerateDeliveryNote);
            this.Controls.Add(this.btn_GenerateInvoice);
            this.Controls.Add(this.btn_NewOrder);
            this.Controls.Add(this.btn_EditOrder);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.cobox_SearchBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel_header);
            this.Name = "PurchaseTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseTransaction";
            this.Load += new System.EventHandler(this.PurchaseTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_debt)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_purchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Button btn_GenerateDeliveryNote;
        private System.Windows.Forms.Button btn_GenerateInvoice;
        private System.Windows.Forms.Button btn_NewOrder;
        private System.Windows.Forms.Button btn_EditOrder;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ComboBox cobox_SearchBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tb_SearchBy;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_debt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_purchase;
    }
}