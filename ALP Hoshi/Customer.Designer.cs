namespace ALP_Hoshi
{
    partial class Customer
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
            this.label4 = new System.Windows.Forms.Label();
            this.label_hi = new System.Windows.Forms.Label();
            this.cb_search_MC = new System.Windows.Forms.ComboBox();
            this.dgv_mastercustomer_MC = new System.Windows.Forms.DataGridView();
            this.btn_clear_MC = new System.Windows.Forms.Button();
            this.btn_edit_MC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_search_MC = new System.Windows.Forms.TextBox();
            this.panel_search_MC = new System.Windows.Forms.Panel();
            this.pb_search_MC = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mastercustomer_MC)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_search_MC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MC)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_header.Controls.Add(this.pb_profil);
            this.panel_header.Controls.Add(this.label_nama);
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Location = new System.Drawing.Point(1, -1);
            this.panel_header.Margin = new System.Windows.Forms.Padding(2);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1127, 62);
            this.panel_header.TabIndex = 75;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_submenu_Paint);
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
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Master Data Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(43, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Search By:";
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(41, 98);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(132, 33);
            this.label_hi.TabIndex = 76;
            this.label_hi.Text = "Customer";
            // 
            // cb_search_MC
            // 
            this.cb_search_MC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_search_MC.FormattingEnabled = true;
            this.cb_search_MC.Items.AddRange(new object[] {
            "ID",
            "Instance",
            "Contact Person"});
            this.cb_search_MC.Location = new System.Drawing.Point(133, 156);
            this.cb_search_MC.Name = "cb_search_MC";
            this.cb_search_MC.Size = new System.Drawing.Size(217, 24);
            this.cb_search_MC.TabIndex = 78;
            this.cb_search_MC.SelectedIndexChanged += new System.EventHandler(this.cb_search_MC_SelectedIndexChanged);
            // 
            // dgv_mastercustomer_MC
            // 
            this.dgv_mastercustomer_MC.AllowUserToAddRows = false;
            this.dgv_mastercustomer_MC.AllowUserToDeleteRows = false;
            this.dgv_mastercustomer_MC.AllowUserToResizeColumns = false;
            this.dgv_mastercustomer_MC.AllowUserToResizeRows = false;
            this.dgv_mastercustomer_MC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_mastercustomer_MC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_mastercustomer_MC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mastercustomer_MC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_mastercustomer_MC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_mastercustomer_MC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_mastercustomer_MC.EnableHeadersVisualStyles = false;
            this.dgv_mastercustomer_MC.GridColor = System.Drawing.Color.White;
            this.dgv_mastercustomer_MC.Location = new System.Drawing.Point(3, 3);
            this.dgv_mastercustomer_MC.MultiSelect = false;
            this.dgv_mastercustomer_MC.Name = "dgv_mastercustomer_MC";
            this.dgv_mastercustomer_MC.ReadOnly = true;
            this.dgv_mastercustomer_MC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_mastercustomer_MC.RowHeadersVisible = false;
            this.dgv_mastercustomer_MC.RowHeadersWidth = 51;
            this.dgv_mastercustomer_MC.RowTemplate.Height = 24;
            this.dgv_mastercustomer_MC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mastercustomer_MC.Size = new System.Drawing.Size(1033, 642);
            this.dgv_mastercustomer_MC.TabIndex = 81;
            // 
            // btn_clear_MC
            // 
            this.btn_clear_MC.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_clear_MC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear_MC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_clear_MC.Location = new System.Drawing.Point(840, 170);
            this.btn_clear_MC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear_MC.Name = "btn_clear_MC";
            this.btn_clear_MC.Size = new System.Drawing.Size(120, 36);
            this.btn_clear_MC.TabIndex = 82;
            this.btn_clear_MC.Text = "Clear";
            this.btn_clear_MC.UseVisualStyleBackColor = false;
            this.btn_clear_MC.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_edit_MC
            // 
            this.btn_edit_MC.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_edit_MC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_MC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_edit_MC.Location = new System.Drawing.Point(966, 170);
            this.btn_edit_MC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit_MC.Name = "btn_edit_MC";
            this.btn_edit_MC.Size = new System.Drawing.Size(120, 36);
            this.btn_edit_MC.TabIndex = 83;
            this.btn_edit_MC.Text = "Edit";
            this.btn_edit_MC.UseVisualStyleBackColor = false;
            this.btn_edit_MC.Click += new System.EventHandler(this.btn_edit_MC_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_search_MC);
            this.panel1.Location = new System.Drawing.Point(355, 154);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 29);
            this.panel1.TabIndex = 259;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tb_search_MC
            // 
            this.tb_search_MC.BackColor = System.Drawing.Color.White;
            this.tb_search_MC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_MC.Location = new System.Drawing.Point(7, 7);
            this.tb_search_MC.Margin = new System.Windows.Forms.Padding(2);
            this.tb_search_MC.Name = "tb_search_MC";
            this.tb_search_MC.Size = new System.Drawing.Size(230, 15);
            this.tb_search_MC.TabIndex = 160;
            // 
            // panel_search_MC
            // 
            this.panel_search_MC.Controls.Add(this.pb_search_MC);
            this.panel_search_MC.Location = new System.Drawing.Point(603, 151);
            this.panel_search_MC.Margin = new System.Windows.Forms.Padding(2);
            this.panel_search_MC.Name = "panel_search_MC";
            this.panel_search_MC.Size = new System.Drawing.Size(33, 33);
            this.panel_search_MC.TabIndex = 260;
            this.panel_search_MC.Click += new System.EventHandler(this.panel_search_MC_Click);
            this.panel_search_MC.MouseEnter += new System.EventHandler(this.panel_search_MC_MouseEnter);
            this.panel_search_MC.MouseLeave += new System.EventHandler(this.panel_search_MC_MouseLeave);
            // 
            // pb_search_MC
            // 
            this.pb_search_MC.Image = global::ALP_Hoshi.Properties.Resources.Logo_Search___PPH;
            this.pb_search_MC.Location = new System.Drawing.Point(4, 4);
            this.pb_search_MC.Margin = new System.Windows.Forms.Padding(2);
            this.pb_search_MC.Name = "pb_search_MC";
            this.pb_search_MC.Size = new System.Drawing.Size(25, 25);
            this.pb_search_MC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_search_MC.TabIndex = 74;
            this.pb_search_MC.TabStop = false;
            this.pb_search_MC.Click += new System.EventHandler(this.panel_search_MC_Click);
            this.pb_search_MC.MouseEnter += new System.EventHandler(this.panel_search_MC_MouseEnter);
            this.pb_search_MC.MouseLeave += new System.EventHandler(this.panel_search_MC_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_mastercustomer_MC);
            this.panel2.Location = new System.Drawing.Point(47, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 648);
            this.panel2.TabIndex = 261;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_search_MC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_edit_MC);
            this.Controls.Add(this.btn_clear_MC);
            this.Controls.Add(this.cb_search_MC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_hi);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.Customer_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mastercustomer_MC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_search_MC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MC)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.ComboBox cb_search_MC;
        private System.Windows.Forms.DataGridView dgv_mastercustomer_MC;
        private System.Windows.Forms.Button btn_clear_MC;
        private System.Windows.Forms.Button btn_edit_MC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_search_MC;
        private System.Windows.Forms.Panel panel_search_MC;
        private System.Windows.Forms.PictureBox pb_search_MC;
        private System.Windows.Forms.Panel panel2;
    }
}