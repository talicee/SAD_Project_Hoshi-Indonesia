namespace ALP_Hoshi
{
    partial class StockReport
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rb_yearly = new System.Windows.Forms.RadioButton();
            this.rb_monthly = new System.Windows.Forms.RadioButton();
            this.dgv_StockReport = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_year_yearly = new System.Windows.Forms.ComboBox();
            this.butt_downloadpdf = new System.Windows.Forms.Button();
            this.cb_month_monthly = new System.Windows.Forms.ComboBox();
            this.butt_clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_year_monthly = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockReport)).BeginInit();
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
            this.panel_header.TabIndex = 137;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 40);
            this.label3.TabIndex = 150;
            this.label3.Text = "Stock Report";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(46, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 27);
            this.label4.TabIndex = 138;
            this.label4.Text = "Search By";
            // 
            // rb_yearly
            // 
            this.rb_yearly.AutoSize = true;
            this.rb_yearly.Location = new System.Drawing.Point(86, 212);
            this.rb_yearly.Name = "rb_yearly";
            this.rb_yearly.Size = new System.Drawing.Size(67, 20);
            this.rb_yearly.TabIndex = 139;
            this.rb_yearly.TabStop = true;
            this.rb_yearly.Text = "Yearly";
            this.rb_yearly.UseVisualStyleBackColor = true;
            this.rb_yearly.CheckedChanged += new System.EventHandler(this.rb_yearly_CheckedChanged);
            // 
            // rb_monthly
            // 
            this.rb_monthly.AutoSize = true;
            this.rb_monthly.Location = new System.Drawing.Point(86, 254);
            this.rb_monthly.Name = "rb_monthly";
            this.rb_monthly.Size = new System.Drawing.Size(74, 20);
            this.rb_monthly.TabIndex = 140;
            this.rb_monthly.TabStop = true;
            this.rb_monthly.Text = "Monthly";
            this.rb_monthly.UseVisualStyleBackColor = true;
            this.rb_monthly.CheckedChanged += new System.EventHandler(this.rb_monthly_CheckedChanged);
            // 
            // dgv_StockReport
            // 
            this.dgv_StockReport.AllowUserToAddRows = false;
            this.dgv_StockReport.AllowUserToDeleteRows = false;
            this.dgv_StockReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_StockReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_StockReport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_StockReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_StockReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_StockReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_StockReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_StockReport.EnableHeadersVisualStyles = false;
            this.dgv_StockReport.GridColor = System.Drawing.Color.White;
            this.dgv_StockReport.Location = new System.Drawing.Point(4, 3);
            this.dgv_StockReport.MultiSelect = false;
            this.dgv_StockReport.Name = "dgv_StockReport";
            this.dgv_StockReport.ReadOnly = true;
            this.dgv_StockReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_StockReport.RowHeadersVisible = false;
            this.dgv_StockReport.RowHeadersWidth = 51;
            this.dgv_StockReport.RowTemplate.Height = 24;
            this.dgv_StockReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_StockReport.Size = new System.Drawing.Size(1032, 423);
            this.dgv_StockReport.TabIndex = 151;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(203, 211);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 141;
            this.label11.Text = "Year : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 142;
            this.label2.Text = "Month : ";
            // 
            // cb_year_yearly
            // 
            this.cb_year_yearly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_yearly.Enabled = false;
            this.cb_year_yearly.FormattingEnabled = true;
            this.cb_year_yearly.Location = new System.Drawing.Point(315, 212);
            this.cb_year_yearly.Name = "cb_year_yearly";
            this.cb_year_yearly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_yearly.TabIndex = 143;
            this.cb_year_yearly.SelectedIndexChanged += new System.EventHandler(this.cb_year_yearly_SelectedIndexChanged);
            // 
            // butt_downloadpdf
            // 
            this.butt_downloadpdf.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.butt_downloadpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_downloadpdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_downloadpdf.Location = new System.Drawing.Point(901, 311);
            this.butt_downloadpdf.Name = "butt_downloadpdf";
            this.butt_downloadpdf.Size = new System.Drawing.Size(137, 36);
            this.butt_downloadpdf.TabIndex = 148;
            this.butt_downloadpdf.Text = "Download PDF";
            this.butt_downloadpdf.UseVisualStyleBackColor = false;
            this.butt_downloadpdf.Click += new System.EventHandler(this.butt_downloadpdf_Click);
            // 
            // cb_month_monthly
            // 
            this.cb_month_monthly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_month_monthly.Enabled = false;
            this.cb_month_monthly.FormattingEnabled = true;
            this.cb_month_monthly.Items.AddRange(new object[] {
            "January",
            "February",
            "Maret",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cb_month_monthly.Location = new System.Drawing.Point(315, 253);
            this.cb_month_monthly.Name = "cb_month_monthly";
            this.cb_month_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_month_monthly.TabIndex = 144;
            this.cb_month_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            // 
            // butt_clear
            // 
            this.butt_clear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.butt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_clear.Location = new System.Drawing.Point(741, 311);
            this.butt_clear.Name = "butt_clear";
            this.butt_clear.Size = new System.Drawing.Size(137, 36);
            this.butt_clear.TabIndex = 147;
            this.butt_clear.Text = "Clear Search";
            this.butt_clear.UseVisualStyleBackColor = false;
            this.butt_clear.Click += new System.EventHandler(this.butt_clear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(552, 253);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "Year : ";
            // 
            // cb_year_monthly
            // 
            this.cb_year_monthly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_monthly.Enabled = false;
            this.cb_year_monthly.FormattingEnabled = true;
            this.cb_year_monthly.Location = new System.Drawing.Point(664, 254);
            this.cb_year_monthly.Name = "cb_year_monthly";
            this.cb_year_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_monthly.TabIndex = 146;
            this.cb_year_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_StockReport);
            this.panel1.Location = new System.Drawing.Point(47, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 429);
            this.panel1.TabIndex = 152;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // StockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rb_yearly);
            this.Controls.Add(this.rb_monthly);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_year_yearly);
            this.Controls.Add(this.butt_downloadpdf);
            this.Controls.Add(this.cb_month_monthly);
            this.Controls.Add(this.butt_clear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_year_monthly);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockReport";
            this.Load += new System.EventHandler(this.StockReport_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_yearly;
        private System.Windows.Forms.RadioButton rb_monthly;
        private System.Windows.Forms.DataGridView dgv_StockReport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_year_yearly;
        private System.Windows.Forms.Button butt_downloadpdf;
        private System.Windows.Forms.ComboBox cb_month_monthly;
        private System.Windows.Forms.Button butt_clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_year_monthly;
        private System.Windows.Forms.Panel panel1;
    }
}