namespace ALP_Hoshi
{
    partial class PurchaseReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.dgv_PurchaseReport = new System.Windows.Forms.DataGridView();
            this.chart_PR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_header = new System.Windows.Forms.Panel();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label_nama = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_totalpurchase = new System.Windows.Forms.Panel();
            this.lb_totalpurchase = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.p_totalitempurchased = new System.Windows.Forms.Panel();
            this.lb_totalitempurchase = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.p_totalpurchasetransactions = new System.Windows.Forms.Panel();
            this.lb_totalpurchasetransactions = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_grandtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_garis = new System.Windows.Forms.Panel();
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PR)).BeginInit();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.p_totalpurchase.SuspendLayout();
            this.p_totalitempurchased.SuspendLayout();
            this.p_totalpurchasetransactions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_PurchaseReport
            // 
            this.dgv_PurchaseReport.AllowUserToAddRows = false;
            this.dgv_PurchaseReport.AllowUserToDeleteRows = false;
            this.dgv_PurchaseReport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_PurchaseReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PurchaseReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PurchaseReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PurchaseReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PurchaseReport.EnableHeadersVisualStyles = false;
            this.dgv_PurchaseReport.GridColor = System.Drawing.Color.White;
            this.dgv_PurchaseReport.Location = new System.Drawing.Point(3, 3);
            this.dgv_PurchaseReport.MultiSelect = false;
            this.dgv_PurchaseReport.Name = "dgv_PurchaseReport";
            this.dgv_PurchaseReport.ReadOnly = true;
            this.dgv_PurchaseReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_PurchaseReport.RowHeadersVisible = false;
            this.dgv_PurchaseReport.RowHeadersWidth = 51;
            this.dgv_PurchaseReport.RowTemplate.Height = 24;
            this.dgv_PurchaseReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PurchaseReport.Size = new System.Drawing.Size(1034, 274);
            this.dgv_PurchaseReport.TabIndex = 82;
            // 
            // chart_PR
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_PR.ChartAreas.Add(chartArea1);
            this.chart_PR.Location = new System.Drawing.Point(40, 531);
            this.chart_PR.Name = "chart_PR";
            this.chart_PR.Size = new System.Drawing.Size(1040, 374);
            this.chart_PR.TabIndex = 83;
            this.chart_PR.Text = "chart1";
            this.chart_PR.MouseEnter += new System.EventHandler(this.chart_PR_MouseEnter);
            this.chart_PR.MouseLeave += new System.EventHandler(this.chart_PR_MouseLeave);
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
            this.panel_header.TabIndex = 100;
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
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Purchase Report";
            // 
            // p_totalpurchase
            // 
            this.p_totalpurchase.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.p_totalpurchase.Controls.Add(this.lb_totalpurchase);
            this.p_totalpurchase.Controls.Add(this.label27);
            this.p_totalpurchase.Location = new System.Drawing.Point(404, 120);
            this.p_totalpurchase.Margin = new System.Windows.Forms.Padding(2);
            this.p_totalpurchase.Name = "p_totalpurchase";
            this.p_totalpurchase.Size = new System.Drawing.Size(321, 122);
            this.p_totalpurchase.TabIndex = 103;
            // 
            // lb_totalpurchase
            // 
            this.lb_totalpurchase.AutoSize = true;
            this.lb_totalpurchase.BackColor = System.Drawing.Color.Transparent;
            this.lb_totalpurchase.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalpurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_totalpurchase.Location = new System.Drawing.Point(19, 62);
            this.lb_totalpurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalpurchase.Name = "lb_totalpurchase";
            this.lb_totalpurchase.Size = new System.Drawing.Size(157, 27);
            this.lb_totalpurchase.TabIndex = 38;
            this.lb_totalpurchase.Text = "Rp 100.880.533";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(19, 17);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(103, 20);
            this.label27.TabIndex = 38;
            this.label27.Text = "Total Purchase";
            // 
            // p_totalitempurchased
            // 
            this.p_totalitempurchased.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.p_totalitempurchased.Controls.Add(this.lb_totalitempurchase);
            this.p_totalitempurchased.Controls.Add(this.label14);
            this.p_totalitempurchased.Location = new System.Drawing.Point(778, 120);
            this.p_totalitempurchased.Margin = new System.Windows.Forms.Padding(2);
            this.p_totalitempurchased.Name = "p_totalitempurchased";
            this.p_totalitempurchased.Size = new System.Drawing.Size(260, 122);
            this.p_totalitempurchased.TabIndex = 102;
            // 
            // lb_totalitempurchase
            // 
            this.lb_totalitempurchase.AutoSize = true;
            this.lb_totalitempurchase.BackColor = System.Drawing.Color.Transparent;
            this.lb_totalitempurchase.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalitempurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_totalitempurchase.Location = new System.Drawing.Point(17, 62);
            this.lb_totalitempurchase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalitempurchase.Name = "lb_totalitempurchase";
            this.lb_totalitempurchase.Size = new System.Drawing.Size(157, 27);
            this.lb_totalitempurchase.TabIndex = 38;
            this.lb_totalitempurchase.Text = "Rp 100.880.533";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(18, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 20);
            this.label14.TabIndex = 38;
            this.label14.Text = "Total Item Purchased";
            // 
            // p_totalpurchasetransactions
            // 
            this.p_totalpurchasetransactions.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.p_totalpurchasetransactions.Controls.Add(this.lb_totalpurchasetransactions);
            this.p_totalpurchasetransactions.Controls.Add(this.label10);
            this.p_totalpurchasetransactions.Location = new System.Drawing.Point(91, 120);
            this.p_totalpurchasetransactions.Margin = new System.Windows.Forms.Padding(2);
            this.p_totalpurchasetransactions.Name = "p_totalpurchasetransactions";
            this.p_totalpurchasetransactions.Size = new System.Drawing.Size(260, 122);
            this.p_totalpurchasetransactions.TabIndex = 101;
            // 
            // lb_totalpurchasetransactions
            // 
            this.lb_totalpurchasetransactions.AutoSize = true;
            this.lb_totalpurchasetransactions.BackColor = System.Drawing.Color.Transparent;
            this.lb_totalpurchasetransactions.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalpurchasetransactions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_totalpurchasetransactions.Location = new System.Drawing.Point(18, 62);
            this.lb_totalpurchasetransactions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalpurchasetransactions.Name = "lb_totalpurchasetransactions";
            this.lb_totalpurchasetransactions.Size = new System.Drawing.Size(157, 27);
            this.lb_totalpurchasetransactions.TabIndex = 38;
            this.lb_totalpurchasetransactions.Text = "Rp 100.880.533";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(19, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Total Purchase Transactions";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label_info);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lb_grandtotal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel_garis);
            this.panel1.Controls.Add(this.butt_downloadpdf);
            this.panel1.Controls.Add(this.butt_clear);
            this.panel1.Controls.Add(this.cb_year_monthly);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_month_monthly);
            this.panel1.Controls.Add(this.cb_year_yearly);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.rb_monthly);
            this.panel1.Controls.Add(this.rb_yearly);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.p_totalpurchase);
            this.panel1.Controls.Add(this.p_totalpurchasetransactions);
            this.panel1.Controls.Add(this.chart_PR);
            this.panel1.Controls.Add(this.p_totalitempurchased);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 791);
            this.panel1.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(36, 463);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 27);
            this.label7.TabIndex = 121;
            this.label7.Text = "Search By";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.Location = new System.Drawing.Point(393, 668);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(272, 42);
            this.label_info.TabIndex = 120;
            this.label_info.Text = "No Data Found";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(42, 1365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 14);
            this.panel3.TabIndex = 118;
            // 
            // lb_grandtotal
            // 
            this.lb_grandtotal.AutoSize = true;
            this.lb_grandtotal.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.lb_grandtotal.Location = new System.Drawing.Point(887, 1278);
            this.lb_grandtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_grandtotal.Name = "lb_grandtotal";
            this.lb_grandtotal.Size = new System.Drawing.Size(120, 27);
            this.lb_grandtotal.TabIndex = 119;
            this.lb_grandtotal.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(76, 1278);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 27);
            this.label6.TabIndex = 118;
            this.label6.Text = "Grand Total";
            // 
            // panel_garis
            // 
            this.panel_garis.Location = new System.Drawing.Point(42, 1255);
            this.panel_garis.Name = "panel_garis";
            this.panel_garis.Size = new System.Drawing.Size(1037, 3);
            this.panel_garis.TabIndex = 117;
            // 
            // butt_downloadpdf
            // 
            this.butt_downloadpdf.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.butt_downloadpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_downloadpdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_downloadpdf.Location = new System.Drawing.Point(891, 427);
            this.butt_downloadpdf.Name = "butt_downloadpdf";
            this.butt_downloadpdf.Size = new System.Drawing.Size(137, 36);
            this.butt_downloadpdf.TabIndex = 116;
            this.butt_downloadpdf.Text = "Download PDF";
            this.butt_downloadpdf.UseVisualStyleBackColor = false;
            this.butt_downloadpdf.Click += new System.EventHandler(this.butt_downloadpdf_Click);
            // 
            // butt_clear
            // 
            this.butt_clear.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.butt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butt_clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butt_clear.Location = new System.Drawing.Point(731, 427);
            this.butt_clear.Name = "butt_clear";
            this.butt_clear.Size = new System.Drawing.Size(137, 36);
            this.butt_clear.TabIndex = 115;
            this.butt_clear.Text = "Clear Search";
            this.butt_clear.UseVisualStyleBackColor = false;
            this.butt_clear.Click += new System.EventHandler(this.butt_clear_Click);
            // 
            // cb_year_monthly
            // 
            this.cb_year_monthly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_monthly.Enabled = false;
            this.cb_year_monthly.FormattingEnabled = true;
            this.cb_year_monthly.Location = new System.Drawing.Point(654, 370);
            this.cb_year_monthly.Name = "cb_year_monthly";
            this.cb_year_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_monthly.TabIndex = 114;
            this.cb_year_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            this.cb_year_monthly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_year_yearly_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 369);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 113;
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
            this.cb_month_monthly.Location = new System.Drawing.Point(305, 369);
            this.cb_month_monthly.Name = "cb_month_monthly";
            this.cb_month_monthly.Size = new System.Drawing.Size(187, 24);
            this.cb_month_monthly.TabIndex = 112;
            this.cb_month_monthly.SelectedIndexChanged += new System.EventHandler(this.cb_month_monthly_SelectedIndexChanged);
            this.cb_month_monthly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_year_yearly_KeyPress);
            // 
            // cb_year_yearly
            // 
            this.cb_year_yearly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year_yearly.Enabled = false;
            this.cb_year_yearly.FormattingEnabled = true;
            this.cb_year_yearly.Location = new System.Drawing.Point(305, 328);
            this.cb_year_yearly.Name = "cb_year_yearly";
            this.cb_year_yearly.Size = new System.Drawing.Size(187, 24);
            this.cb_year_yearly.TabIndex = 111;
            this.cb_year_yearly.SelectedIndexChanged += new System.EventHandler(this.cb_year_yearly_SelectedIndexChanged);
            this.cb_year_yearly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_year_yearly_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 370);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 110;
            this.label2.Text = "Month : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(193, 327);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 109;
            this.label11.Text = "Year : ";
            // 
            // rb_monthly
            // 
            this.rb_monthly.AutoSize = true;
            this.rb_monthly.Location = new System.Drawing.Point(76, 370);
            this.rb_monthly.Name = "rb_monthly";
            this.rb_monthly.Size = new System.Drawing.Size(74, 20);
            this.rb_monthly.TabIndex = 108;
            this.rb_monthly.TabStop = true;
            this.rb_monthly.Text = "Monthly";
            this.rb_monthly.UseVisualStyleBackColor = true;
            this.rb_monthly.CheckedChanged += new System.EventHandler(this.rb_monthly_CheckedChanged);
            // 
            // rb_yearly
            // 
            this.rb_yearly.AutoSize = true;
            this.rb_yearly.Location = new System.Drawing.Point(76, 328);
            this.rb_yearly.Name = "rb_yearly";
            this.rb_yearly.Size = new System.Drawing.Size(67, 20);
            this.rb_yearly.TabIndex = 107;
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
            this.label4.Location = new System.Drawing.Point(36, 274);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 27);
            this.label4.TabIndex = 106;
            this.label4.Text = "Search By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(40, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 40);
            this.label3.TabIndex = 105;
            this.label3.Text = "Purchase Report";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_PurchaseReport);
            this.panel2.Location = new System.Drawing.Point(40, 947);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 280);
            this.panel2.TabIndex = 122;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PurchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1176, 893);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_header);
            this.Name = "PurchaseReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseReport";
            this.Load += new System.EventHandler(this.PurchaseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PurchaseReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PR)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.p_totalpurchase.ResumeLayout(false);
            this.p_totalpurchase.PerformLayout();
            this.p_totalitempurchased.ResumeLayout(false);
            this.p_totalitempurchased.PerformLayout();
            this.p_totalpurchasetransactions.ResumeLayout(false);
            this.p_totalpurchasetransactions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_PurchaseReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PR;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p_totalpurchase;
        private System.Windows.Forms.Label lb_totalpurchase;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel p_totalitempurchased;
        private System.Windows.Forms.Label lb_totalitempurchase;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel p_totalpurchasetransactions;
        private System.Windows.Forms.Label lb_totalpurchasetransactions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_monthly;
        private System.Windows.Forms.RadioButton rb_yearly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butt_downloadpdf;
        private System.Windows.Forms.Button butt_clear;
        private System.Windows.Forms.ComboBox cb_year_monthly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_month_monthly;
        private System.Windows.Forms.ComboBox cb_year_yearly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_grandtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_garis;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
    }
}