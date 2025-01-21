namespace ALP_Hoshi
{
    partial class Supplier
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
            this.dgv_mastersupplier_MS = new System.Windows.Forms.DataGridView();
            this.cb_search_MS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_hi = new System.Windows.Forms.Label();
            this.panel_search_MS = new System.Windows.Forms.Panel();
            this.pb_search_MS = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_search_MS = new System.Windows.Forms.TextBox();
            this.btn_edit_MS = new System.Windows.Forms.Button();
            this.btn_clear_MS = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mastersupplier_MS)).BeginInit();
            this.panel_search_MS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_header.Controls.Add(this.pb_profil);
            this.panel_header.Controls.Add(this.label_nama);
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1127, 62);
            this.panel_header.TabIndex = 100;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(998, 16);
            this.pb_profil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Master Data Supplier";
            // 
            // dgv_mastersupplier_MS
            // 
            this.dgv_mastersupplier_MS.AllowUserToAddRows = false;
            this.dgv_mastersupplier_MS.AllowUserToDeleteRows = false;
            this.dgv_mastersupplier_MS.AllowUserToResizeColumns = false;
            this.dgv_mastersupplier_MS.AllowUserToResizeRows = false;
            this.dgv_mastersupplier_MS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_mastersupplier_MS.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_mastersupplier_MS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mastersupplier_MS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_mastersupplier_MS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_mastersupplier_MS.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_mastersupplier_MS.EnableHeadersVisualStyles = false;
            this.dgv_mastersupplier_MS.GridColor = System.Drawing.Color.White;
            this.dgv_mastersupplier_MS.Location = new System.Drawing.Point(3, 3);
            this.dgv_mastersupplier_MS.MultiSelect = false;
            this.dgv_mastersupplier_MS.Name = "dgv_mastersupplier_MS";
            this.dgv_mastersupplier_MS.ReadOnly = true;
            this.dgv_mastersupplier_MS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_mastersupplier_MS.RowHeadersVisible = false;
            this.dgv_mastersupplier_MS.RowHeadersWidth = 51;
            this.dgv_mastersupplier_MS.RowTemplate.Height = 24;
            this.dgv_mastersupplier_MS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mastersupplier_MS.Size = new System.Drawing.Size(1033, 618);
            this.dgv_mastersupplier_MS.TabIndex = 99;
            // 
            // cb_search_MS
            // 
            this.cb_search_MS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_search_MS.FormattingEnabled = true;
            this.cb_search_MS.Items.AddRange(new object[] {
            "ID",
            "Company"});
            this.cb_search_MS.Location = new System.Drawing.Point(134, 162);
            this.cb_search_MS.Name = "cb_search_MS";
            this.cb_search_MS.Size = new System.Drawing.Size(217, 24);
            this.cb_search_MS.TabIndex = 94;
            this.cb_search_MS.SelectedIndexChanged += new System.EventHandler(this.cb_search_MS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(44, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 93;
            this.label4.Text = "Search By:";
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(41, 102);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(113, 33);
            this.label_hi.TabIndex = 92;
            this.label_hi.Text = "Supplier";
            // 
            // panel_search_MS
            // 
            this.panel_search_MS.Controls.Add(this.pb_search_MS);
            this.panel_search_MS.Location = new System.Drawing.Point(604, 157);
            this.panel_search_MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_search_MS.Name = "panel_search_MS";
            this.panel_search_MS.Size = new System.Drawing.Size(33, 33);
            this.panel_search_MS.TabIndex = 262;
            this.panel_search_MS.Click += new System.EventHandler(this.panel_search_MS_Click);
            this.panel_search_MS.MouseEnter += new System.EventHandler(this.panel_search_MS_MouseEnter);
            this.panel_search_MS.MouseLeave += new System.EventHandler(this.panel_search_MS_MouseLeave);
            // 
            // pb_search_MS
            // 
            this.pb_search_MS.Image = global::ALP_Hoshi.Properties.Resources.Logo_Search___PPH;
            this.pb_search_MS.Location = new System.Drawing.Point(4, 4);
            this.pb_search_MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pb_search_MS.Name = "pb_search_MS";
            this.pb_search_MS.Size = new System.Drawing.Size(25, 25);
            this.pb_search_MS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_search_MS.TabIndex = 74;
            this.pb_search_MS.TabStop = false;
            this.pb_search_MS.Click += new System.EventHandler(this.panel_search_MS_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_search_MS);
            this.panel1.Location = new System.Drawing.Point(356, 160);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 29);
            this.panel1.TabIndex = 261;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tb_search_MS
            // 
            this.tb_search_MS.BackColor = System.Drawing.Color.White;
            this.tb_search_MS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_search_MS.Location = new System.Drawing.Point(7, 7);
            this.tb_search_MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_search_MS.Name = "tb_search_MS";
            this.tb_search_MS.Size = new System.Drawing.Size(230, 15);
            this.tb_search_MS.TabIndex = 160;
            // 
            // btn_edit_MS
            // 
            this.btn_edit_MS.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_edit_MS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit_MS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_edit_MS.Location = new System.Drawing.Point(967, 176);
            this.btn_edit_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit_MS.Name = "btn_edit_MS";
            this.btn_edit_MS.Size = new System.Drawing.Size(120, 36);
            this.btn_edit_MS.TabIndex = 264;
            this.btn_edit_MS.Text = "Edit";
            this.btn_edit_MS.UseVisualStyleBackColor = false;
            this.btn_edit_MS.Click += new System.EventHandler(this.btn_edit_MS_Click_1);
            // 
            // btn_clear_MS
            // 
            this.btn_clear_MS.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_clear_MS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear_MS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_clear_MS.Location = new System.Drawing.Point(841, 176);
            this.btn_clear_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear_MS.Name = "btn_clear_MS";
            this.btn_clear_MS.Size = new System.Drawing.Size(120, 36);
            this.btn_clear_MS.TabIndex = 263;
            this.btn_clear_MS.Text = "Clear";
            this.btn_clear_MS.UseVisualStyleBackColor = false;
            this.btn_clear_MS.Click += new System.EventHandler(this.btn_clear_MS_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_mastersupplier_MS);
            this.panel2.Location = new System.Drawing.Point(47, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 624);
            this.panel2.TabIndex = 265;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_edit_MS);
            this.Controls.Add(this.btn_clear_MS);
            this.Controls.Add(this.panel_search_MS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.cb_search_MS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_hi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Supplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.Supplier_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mastersupplier_MS)).EndInit();
            this.panel_search_MS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_mastersupplier_MS;
        private System.Windows.Forms.ComboBox cb_search_MS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Panel panel_search_MS;
        private System.Windows.Forms.PictureBox pb_search_MS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_search_MS;
        private System.Windows.Forms.Button btn_edit_MS;
        private System.Windows.Forms.Button btn_clear_MS;
        private System.Windows.Forms.Panel panel2;
    }
}