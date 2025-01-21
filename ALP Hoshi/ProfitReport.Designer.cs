namespace ALP_Hoshi
{
    partial class ProfitReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lb_sales = new System.Windows.Forms.Label();
            this.butt_downloadpdf = new System.Windows.Forms.Button();
            this.butt_clear = new System.Windows.Forms.Button();
            this.cb_year_monthly = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_month_monthly = new System.Windows.Forms.ComboBox();
            this.cb_year_yearly = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rb_monthly = new System.Windows.Forms.RadioButton();
            this.rb_yearly = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_totalsales = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_SalesReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_infosales = new System.Windows.Forms.Label();
            this.label_infopurchase = new System.Windows.Forms.Label();
            this.lb_totalprofitloss = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_totalpurchase = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_garis = new System.Windows.Forms.Panel();
            this.dgv_PurchaseReport = new System.Windows.Forms.DataGridView();
            this.lb_purchase = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesReport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_sales
            // 
            this.lb_sales.AutoSize = true;
            this.lb_sales.BackColor = System.Drawing.Color.White;
            this.lb_sales.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_sales.Location = new System.Drawing.Point(46, 284);
            this.lb_sales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sales.Name = "lb_sales";
            this.lb_sales.Size = new System.Drawing.Size(60, 27);
            this.lb_sales.TabIndex = 134;
            this.lb_sales.Text = "Sales";
            // 
            // butt_downloadpdf
            // 
            this.butt_downloadpdf.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.butt_downloadpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_downloadpdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_downloadpdf.Location = new System.Drawing.Point(901, 253);
            this.butt_downloadpdf.Name = "butt_downloadpdf";
            this.butt_downloadpdf.Size = new System.Drawing.Size(137, 36);
            this.butt_downloadpdf.TabIndex = 133;
            this.butt_downloadpdf.Text = "Download PDF";
            this.butt_downloadpdf.UseVisualStyleBackColor = false;
            this.butt_downloadpdf.Click += new System.EventHandler(this.butt_downloadpdf_Click);
            // 
            // butt_clear
            // 
            this.butt_clear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.butt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_clear.Location = new System.Drawing.Point(741, 253);
            this.butt_clear.Name = "butt_clear";
            this.butt_clear.Size = new System.Drawing.Size(137, 36);
            this.butt_clear.TabIndex = 132;
            this.butt_clear.Text = "Clear Search";
            this.butt_clear.UseVisualStyleBackColor = false;
            this.butt_clear.Click += new System.EventHandler(this.butt_clear_Click);
            // 
            // cb_year_monthly
            // 
            this.cb_year_monthly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_monthly.Enabled = false;
            this.cb_year_monthly.FormattingEnabled = true;
            this.cb_year_monthly.Location = new System.Drawing.Point(664, 196);
            this.cb_year_monthly.Name = "cb_year_monthly";
            this.cb_year_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_monthly.TabIndex = 131;
            this.cb_year_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(552, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 130;
            this.label5.Text = "Year : ";
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
            this.cb_month_monthly.Location = new System.Drawing.Point(315, 195);
            this.cb_month_monthly.Name = "cb_month_monthly";
            this.cb_month_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_month_monthly.TabIndex = 129;
            this.cb_month_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            // 
            // cb_year_yearly
            // 
            this.cb_year_yearly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_yearly.Enabled = false;
            this.cb_year_yearly.FormattingEnabled = true;
            this.cb_year_yearly.Location = new System.Drawing.Point(315, 154);
            this.cb_year_yearly.Name = "cb_year_yearly";
            this.cb_year_yearly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_yearly.TabIndex = 128;
            this.cb_year_yearly.SelectedIndexChanged += new System.EventHandler(this.cb_year_yearly_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 127;
            this.label2.Text = "Month : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(203, 153);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 126;
            this.label11.Text = "Year : ";
            // 
            // rb_monthly
            // 
            this.rb_monthly.AutoSize = true;
            this.rb_monthly.Location = new System.Drawing.Point(86, 196);
            this.rb_monthly.Name = "rb_monthly";
            this.rb_monthly.Size = new System.Drawing.Size(74, 20);
            this.rb_monthly.TabIndex = 125;
            this.rb_monthly.TabStop = true;
            this.rb_monthly.Text = "Monthly";
            this.rb_monthly.UseVisualStyleBackColor = true;
            this.rb_monthly.CheckedChanged += new System.EventHandler(this.rb_monthly_CheckedChanged);
            // 
            // rb_yearly
            // 
            this.rb_yearly.AutoSize = true;
            this.rb_yearly.Location = new System.Drawing.Point(86, 154);
            this.rb_yearly.Name = "rb_yearly";
            this.rb_yearly.Size = new System.Drawing.Size(67, 20);
            this.rb_yearly.TabIndex = 124;
            this.rb_yearly.TabStop = true;
            this.rb_yearly.Text = "Yearly";
            this.rb_yearly.UseVisualStyleBackColor = true;
            this.rb_yearly.CheckedChanged += new System.EventHandler(this.rb_yearly_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(46, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 27);
            this.label4.TabIndex = 123;
            this.label4.Text = "Search By";
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
            this.panel_header.TabIndex = 122;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(988, 17);
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
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Profit Report";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(40, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 40);
            this.label3.TabIndex = 135;
            this.label3.Text = "Profit Report";
            // 
            // lb_totalsales
            // 
            this.lb_totalsales.AutoSize = true;
            this.lb_totalsales.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_totalsales.Location = new System.Drawing.Point(804, 616);
            this.lb_totalsales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalsales.Name = "lb_totalsales";
            this.lb_totalsales.Size = new System.Drawing.Size(120, 27);
            this.lb_totalsales.TabIndex = 139;
            this.lb_totalsales.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(83, 616);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 27);
            this.label6.TabIndex = 138;
            this.label6.Text = "Total Sales";
            // 
            // dgv_SalesReport
            // 
            this.dgv_SalesReport.AllowUserToAddRows = false;
            this.dgv_SalesReport.AllowUserToDeleteRows = false;
            this.dgv_SalesReport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_SalesReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_SalesReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SalesReport.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_SalesReport.EnableHeadersVisualStyles = false;
            this.dgv_SalesReport.GridColor = System.Drawing.Color.White;
            this.dgv_SalesReport.Location = new System.Drawing.Point(4, 3);
            this.dgv_SalesReport.MultiSelect = false;
            this.dgv_SalesReport.Name = "dgv_SalesReport";
            this.dgv_SalesReport.ReadOnly = true;
            this.dgv_SalesReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_SalesReport.RowHeadersVisible = false;
            this.dgv_SalesReport.RowHeadersWidth = 51;
            this.dgv_SalesReport.RowTemplate.Height = 24;
            this.dgv_SalesReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SalesReport.Size = new System.Drawing.Size(1033, 274);
            this.dgv_SalesReport.TabIndex = 136;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label_infopurchase);
            this.panel1.Controls.Add(this.lb_totalprofitloss);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lb_totalpurchase);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel_garis);
            this.panel1.Controls.Add(this.lb_purchase);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lb_totalsales);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rb_yearly);
            this.panel1.Controls.Add(this.rb_monthly);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lb_sales);
            this.panel1.Controls.Add(this.cb_year_yearly);
            this.panel1.Controls.Add(this.butt_downloadpdf);
            this.panel1.Controls.Add(this.cb_month_monthly);
            this.panel1.Controls.Add(this.butt_clear);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_year_monthly);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(1, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 790);
            this.panel1.TabIndex = 73;
            // 
            // label_infosales
            // 
            this.label_infosales.AutoSize = true;
            this.label_infosales.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_infosales.Location = new System.Drawing.Point(359, 120);
            this.label_infosales.Name = "label_infosales";
            this.label_infosales.Size = new System.Drawing.Size(291, 42);
            this.label_infosales.TabIndex = 148;
            this.label_infosales.Text = "No Transactions";
            // 
            // label_infopurchase
            // 
            this.label_infopurchase.AutoSize = true;
            this.label_infopurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_infopurchase.Location = new System.Drawing.Point(411, 827);
            this.label_infopurchase.Name = "label_infopurchase";
            this.label_infopurchase.Size = new System.Drawing.Size(291, 42);
            this.label_infopurchase.TabIndex = 121;
            this.label_infopurchase.Text = "No Transactions";
            // 
            // lb_totalprofitloss
            // 
            this.lb_totalprofitloss.AutoSize = true;
            this.lb_totalprofitloss.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_totalprofitloss.Location = new System.Drawing.Point(804, 1105);
            this.lb_totalprofitloss.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalprofitloss.Name = "lb_totalprofitloss";
            this.lb_totalprofitloss.Size = new System.Drawing.Size(120, 27);
            this.lb_totalprofitloss.TabIndex = 147;
            this.lb_totalprofitloss.Text = "Grand Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(83, 1105);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 27);
            this.label13.TabIndex = 146;
            this.label13.Text = "Profit/Loss";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(109, 1192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 33);
            this.panel3.TabIndex = 145;
            // 
            // lb_totalpurchase
            // 
            this.lb_totalpurchase.AutoSize = true;
            this.lb_totalpurchase.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_totalpurchase.Location = new System.Drawing.Point(804, 1011);
            this.lb_totalpurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalpurchase.Name = "lb_totalpurchase";
            this.lb_totalpurchase.Size = new System.Drawing.Size(120, 27);
            this.lb_totalpurchase.TabIndex = 144;
            this.lb_totalpurchase.Text = "Grand Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(83, 1011);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 27);
            this.label9.TabIndex = 143;
            this.label9.Text = "Total Purchase";
            // 
            // panel_garis
            // 
            this.panel_garis.Location = new System.Drawing.Point(49, 1063);
            this.panel_garis.Name = "panel_garis";
            this.panel_garis.Size = new System.Drawing.Size(1037, 3);
            this.panel_garis.TabIndex = 142;
            // 
            // dgv_PurchaseReport
            // 
            this.dgv_PurchaseReport.AllowUserToAddRows = false;
            this.dgv_PurchaseReport.AllowUserToDeleteRows = false;
            this.dgv_PurchaseReport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_PurchaseReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PurchaseReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_PurchaseReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PurchaseReport.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_PurchaseReport.EnableHeadersVisualStyles = false;
            this.dgv_PurchaseReport.GridColor = System.Drawing.Color.White;
            this.dgv_PurchaseReport.Location = new System.Drawing.Point(4, 3);
            this.dgv_PurchaseReport.MultiSelect = false;
            this.dgv_PurchaseReport.Name = "dgv_PurchaseReport";
            this.dgv_PurchaseReport.ReadOnly = true;
            this.dgv_PurchaseReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_PurchaseReport.RowHeadersVisible = false;
            this.dgv_PurchaseReport.RowHeadersWidth = 51;
            this.dgv_PurchaseReport.RowTemplate.Height = 24;
            this.dgv_PurchaseReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PurchaseReport.Size = new System.Drawing.Size(1033, 274);
            this.dgv_PurchaseReport.TabIndex = 141;
            // 
            // lb_purchase
            // 
            this.lb_purchase.AutoSize = true;
            this.lb_purchase.BackColor = System.Drawing.Color.White;
            this.lb_purchase.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_purchase.Location = new System.Drawing.Point(46, 679);
            this.lb_purchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_purchase.Name = "lb_purchase";
            this.lb_purchase.Size = new System.Drawing.Size(98, 27);
            this.lb_purchase.TabIndex = 140;
            this.lb_purchase.Text = "Purchase";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_infosales);
            this.panel2.Controls.Add(this.dgv_SalesReport);
            this.panel2.Location = new System.Drawing.Point(47, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 280);
            this.panel2.TabIndex = 149;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_PurchaseReport);
            this.panel5.Location = new System.Drawing.Point(47, 718);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1040, 280);
            this.panel5.TabIndex = 151;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ProfitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProfitReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfitReport";
            this.Load += new System.EventHandler(this.ProfitReport_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_sales;
        private System.Windows.Forms.Button butt_downloadpdf;
        private System.Windows.Forms.Button butt_clear;
        private System.Windows.Forms.ComboBox cb_year_monthly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_month_monthly;
        private System.Windows.Forms.ComboBox cb_year_yearly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rb_monthly;
        private System.Windows.Forms.RadioButton rb_yearly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_totalsales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_SalesReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_totalpurchase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel_garis;
        private System.Windows.Forms.DataGridView dgv_PurchaseReport;
        private System.Windows.Forms.Label lb_purchase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_totalprofitloss;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_infopurchase;
        private System.Windows.Forms.Label label_infosales;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
    }
}