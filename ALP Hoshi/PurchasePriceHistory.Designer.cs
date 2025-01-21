namespace ALP_Hoshi
{
    partial class PurchasePriceHistory
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_clear_PPH = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_hi = new System.Windows.Forms.Label();
            this.panel_search_PPH = new System.Windows.Forms.Panel();
            this.panel_searchby_PPH = new System.Windows.Forms.Panel();
            this.pb_search_PPH = new System.Windows.Forms.PictureBox();
            this.panel_itemid_PPH = new System.Windows.Forms.Panel();
            this.tb_itemid_PPH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_MasterPurchasePriceHistory_PPH = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.panel_search_PPH.SuspendLayout();
            this.panel_searchby_PPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_PPH)).BeginInit();
            this.panel_itemid_PPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MasterPurchasePriceHistory_PPH)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel_header.TabIndex = 77;
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
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Purchase Price History";
            // 
            // btn_clear_PPH
            // 
            this.btn_clear_PPH.AutoSize = true;
            this.btn_clear_PPH.BackColor = System.Drawing.Color.Gray;
            this.btn_clear_PPH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear_PPH.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_clear_PPH.Location = new System.Drawing.Point(966, 222);
            this.btn_clear_PPH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear_PPH.Name = "btn_clear_PPH";
            this.btn_clear_PPH.Size = new System.Drawing.Size(120, 36);
            this.btn_clear_PPH.TabIndex = 95;
            this.btn_clear_PPH.Text = "Clear";
            this.btn_clear_PPH.UseVisualStyleBackColor = false;
            this.btn_clear_PPH.Click += new System.EventHandler(this.btn_clear_PPH_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 91;
            this.label4.Text = "Item ID:";
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(40, 86);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(333, 40);
            this.label_hi.TabIndex = 90;
            this.label_hi.Text = "Purchase Price History";
            // 
            // panel_search_PPH
            // 
            this.panel_search_PPH.Controls.Add(this.panel_searchby_PPH);
            this.panel_search_PPH.Controls.Add(this.panel_itemid_PPH);
            this.panel_search_PPH.Controls.Add(this.label2);
            this.panel_search_PPH.Controls.Add(this.label4);
            this.panel_search_PPH.Location = new System.Drawing.Point(46, 147);
            this.panel_search_PPH.Name = "panel_search_PPH";
            this.panel_search_PPH.Size = new System.Drawing.Size(500, 111);
            this.panel_search_PPH.TabIndex = 98;
            // 
            // panel_searchby_PPH
            // 
            this.panel_searchby_PPH.Controls.Add(this.pb_search_PPH);
            this.panel_searchby_PPH.Location = new System.Drawing.Point(374, 61);
            this.panel_searchby_PPH.Margin = new System.Windows.Forms.Padding(2);
            this.panel_searchby_PPH.Name = "panel_searchby_PPH";
            this.panel_searchby_PPH.Size = new System.Drawing.Size(33, 33);
            this.panel_searchby_PPH.TabIndex = 100;
            this.panel_searchby_PPH.Click += new System.EventHandler(this.panel_searchby_PPH_Click);
            this.panel_searchby_PPH.MouseEnter += new System.EventHandler(this.panel_searchby_PPH_MouseEnter);
            this.panel_searchby_PPH.MouseLeave += new System.EventHandler(this.panel_searchby_PPH_MouseLeave);
            // 
            // pb_search_PPH
            // 
            this.pb_search_PPH.Image = global::ALP_Hoshi.Properties.Resources.Logo_Search___PPH;
            this.pb_search_PPH.Location = new System.Drawing.Point(4, 4);
            this.pb_search_PPH.Margin = new System.Windows.Forms.Padding(2);
            this.pb_search_PPH.Name = "pb_search_PPH";
            this.pb_search_PPH.Size = new System.Drawing.Size(25, 25);
            this.pb_search_PPH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_search_PPH.TabIndex = 74;
            this.pb_search_PPH.TabStop = false;
            this.pb_search_PPH.Click += new System.EventHandler(this.panel_searchby_PPH_Click);
            this.pb_search_PPH.MouseEnter += new System.EventHandler(this.panel_searchby_PPH_MouseEnter);
            this.pb_search_PPH.MouseLeave += new System.EventHandler(this.panel_searchby_PPH_MouseLeave);
            // 
            // panel_itemid_PPH
            // 
            this.panel_itemid_PPH.BackColor = System.Drawing.Color.Transparent;
            this.panel_itemid_PPH.Controls.Add(this.tb_itemid_PPH);
            this.panel_itemid_PPH.Location = new System.Drawing.Point(93, 61);
            this.panel_itemid_PPH.Name = "panel_itemid_PPH";
            this.panel_itemid_PPH.Size = new System.Drawing.Size(276, 33);
            this.panel_itemid_PPH.TabIndex = 116;
            this.panel_itemid_PPH.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_itemid_PPH_Paint);
            // 
            // tb_itemid_PPH
            // 
            this.tb_itemid_PPH.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_itemid_PPH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_itemid_PPH.Location = new System.Drawing.Point(8, 9);
            this.tb_itemid_PPH.Name = "tb_itemid_PPH";
            this.tb_itemid_PPH.Size = new System.Drawing.Size(259, 15);
            this.tb_itemid_PPH.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 27);
            this.label2.TabIndex = 99;
            this.label2.Text = "Search Item Price";
            // 
            // dgv_MasterPurchasePriceHistory_PPH
            // 
            this.dgv_MasterPurchasePriceHistory_PPH.AllowUserToAddRows = false;
            this.dgv_MasterPurchasePriceHistory_PPH.AllowUserToDeleteRows = false;
            this.dgv_MasterPurchasePriceHistory_PPH.AllowUserToResizeColumns = false;
            this.dgv_MasterPurchasePriceHistory_PPH.AllowUserToResizeRows = false;
            this.dgv_MasterPurchasePriceHistory_PPH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MasterPurchasePriceHistory_PPH.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_MasterPurchasePriceHistory_PPH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MasterPurchasePriceHistory_PPH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_MasterPurchasePriceHistory_PPH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MasterPurchasePriceHistory_PPH.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_MasterPurchasePriceHistory_PPH.EnableHeadersVisualStyles = false;
            this.dgv_MasterPurchasePriceHistory_PPH.GridColor = System.Drawing.Color.White;
            this.dgv_MasterPurchasePriceHistory_PPH.Location = new System.Drawing.Point(3, 3);
            this.dgv_MasterPurchasePriceHistory_PPH.MultiSelect = false;
            this.dgv_MasterPurchasePriceHistory_PPH.Name = "dgv_MasterPurchasePriceHistory_PPH";
            this.dgv_MasterPurchasePriceHistory_PPH.ReadOnly = true;
            this.dgv_MasterPurchasePriceHistory_PPH.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_MasterPurchasePriceHistory_PPH.RowHeadersVisible = false;
            this.dgv_MasterPurchasePriceHistory_PPH.RowHeadersWidth = 51;
            this.dgv_MasterPurchasePriceHistory_PPH.RowTemplate.Height = 24;
            this.dgv_MasterPurchasePriceHistory_PPH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MasterPurchasePriceHistory_PPH.Size = new System.Drawing.Size(1033, 574);
            this.dgv_MasterPurchasePriceHistory_PPH.TabIndex = 99;
            this.dgv_MasterPurchasePriceHistory_PPH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MasterPurchasePriceHistory_PPH_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_MasterPurchasePriceHistory_PPH);
            this.panel1.Location = new System.Drawing.Point(47, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 580);
            this.panel1.TabIndex = 100;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PurchasePriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel_search_PPH);
            this.Controls.Add(this.btn_clear_PPH);
            this.Controls.Add(this.label_hi);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.panel1);
            this.Name = "PurchasePriceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchasePriceHistory";
            this.Load += new System.EventHandler(this.PurchasePriceHistory_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.panel_search_PPH.ResumeLayout(false);
            this.panel_search_PPH.PerformLayout();
            this.panel_searchby_PPH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_PPH)).EndInit();
            this.panel_itemid_PPH.ResumeLayout(false);
            this.panel_itemid_PPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MasterPurchasePriceHistory_PPH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_clear_PPH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Panel panel_search_PPH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_itemid_PPH;
        private System.Windows.Forms.TextBox tb_itemid_PPH;
        private System.Windows.Forms.DataGridView dgv_MasterPurchasePriceHistory_PPH;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel_searchby_PPH;
        private System.Windows.Forms.PictureBox pb_search_PPH;
        private System.Windows.Forms.Panel panel1;
    }
}