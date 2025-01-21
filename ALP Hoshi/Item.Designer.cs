namespace ALP_Hoshi
{
    partial class Item
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pb_profil = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.label_nama = new System.Windows.Forms.Label();
            this.dgv_MasterItem = new System.Windows.Forms.DataGridView();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lb_outofstock = new System.Windows.Forms.Label();
            this.lb_lowstock = new System.Windows.Forms.Label();
            this.lb_totalitem = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_hi = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_SearchBy = new System.Windows.Forms.TextBox();
            this.panel_search_MS = new System.Windows.Forms.Panel();
            this.pb_search_MS = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).BeginInit();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MasterItem)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_search_MS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MS)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_profil
            // 
            this.pb_profil.Location = new System.Drawing.Point(998, 17);
            this.pb_profil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pb_profil.Name = "pb_profil";
            this.pb_profil.Size = new System.Drawing.Size(30, 29);
            this.pb_profil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profil.TabIndex = 72;
            this.pb_profil.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Master Data Item";
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
            this.panel_header.TabIndex = 116;
            this.panel_header.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_header_Paint);
            // 
            // label_nama
            // 
            this.label_nama.AutoSize = true;
            this.label_nama.BackColor = System.Drawing.Color.White;
            this.label_nama.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nama.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_nama.Location = new System.Drawing.Point(1032, 22);
            this.label_nama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nama.Name = "label_nama";
            this.label_nama.Size = new System.Drawing.Size(54, 20);
            this.label_nama.TabIndex = 30;
            this.label_nama.Text = "Owner";
            // 
            // dgv_MasterItem
            // 
            this.dgv_MasterItem.AllowUserToAddRows = false;
            this.dgv_MasterItem.AllowUserToDeleteRows = false;
            this.dgv_MasterItem.AllowUserToResizeColumns = false;
            this.dgv_MasterItem.AllowUserToResizeRows = false;
            this.dgv_MasterItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MasterItem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_MasterItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MasterItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_MasterItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MasterItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_MasterItem.EnableHeadersVisualStyles = false;
            this.dgv_MasterItem.GridColor = System.Drawing.Color.White;
            this.dgv_MasterItem.Location = new System.Drawing.Point(3, 3);
            this.dgv_MasterItem.MultiSelect = false;
            this.dgv_MasterItem.Name = "dgv_MasterItem";
            this.dgv_MasterItem.ReadOnly = true;
            this.dgv_MasterItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_MasterItem.RowHeadersVisible = false;
            this.dgv_MasterItem.RowHeadersWidth = 51;
            this.dgv_MasterItem.RowTemplate.Height = 24;
            this.dgv_MasterItem.Size = new System.Drawing.Size(1033, 506);
            this.dgv_MasterItem.TabIndex = 115;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(977, 298);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(120, 36);
            this.btn_edit.TabIndex = 114;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // lb_outofstock
            // 
            this.lb_outofstock.AutoSize = true;
            this.lb_outofstock.BackColor = System.Drawing.Color.White;
            this.lb_outofstock.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_outofstock.Location = new System.Drawing.Point(18, 21);
            this.lb_outofstock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_outofstock.Name = "lb_outofstock";
            this.lb_outofstock.Size = new System.Drawing.Size(29, 33);
            this.lb_outofstock.TabIndex = 110;
            this.lb_outofstock.Text = "2";
            // 
            // lb_lowstock
            // 
            this.lb_lowstock.AutoSize = true;
            this.lb_lowstock.BackColor = System.Drawing.Color.White;
            this.lb_lowstock.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lowstock.Location = new System.Drawing.Point(18, 21);
            this.lb_lowstock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_lowstock.Name = "lb_lowstock";
            this.lb_lowstock.Size = new System.Drawing.Size(29, 33);
            this.lb_lowstock.TabIndex = 108;
            this.lb_lowstock.Text = "6";
            // 
            // lb_totalitem
            // 
            this.lb_totalitem.AutoSize = true;
            this.lb_totalitem.BackColor = System.Drawing.Color.White;
            this.lb_totalitem.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalitem.Location = new System.Drawing.Point(18, 21);
            this.lb_totalitem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_totalitem.Name = "lb_totalitem";
            this.lb_totalitem.Size = new System.Drawing.Size(43, 33);
            this.lb_totalitem.TabIndex = 106;
            this.lb_totalitem.Text = "42";
            this.lb_totalitem.UseMnemonic = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(851, 298);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(120, 36);
            this.btn_clear.TabIndex = 105;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 302);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 102;
            this.label4.Text = "Item ID: ";
            // 
            // label_hi
            // 
            this.label_hi.AutoSize = true;
            this.label_hi.BackColor = System.Drawing.Color.White;
            this.label_hi.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hi.Location = new System.Drawing.Point(41, 102);
            this.label_hi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_hi.Name = "label_hi";
            this.label_hi.Size = new System.Drawing.Size(70, 33);
            this.label_hi.TabIndex = 101;
            this.label_hi.Text = "Item";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label13);
            this.panel9.Controls.Add(this.lb_totalitem);
            this.panel9.Location = new System.Drawing.Point(160, 153);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(256, 117);
            this.panel9.TabIndex = 270;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(20, 81);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 250;
            this.label13.Text = "Total Item";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lb_lowstock);
            this.panel1.Location = new System.Drawing.Point(435, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 117);
            this.panel1.TabIndex = 271;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 250;
            this.label2.Text = "Low Stock Item";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lb_outofstock);
            this.panel2.Location = new System.Drawing.Point(711, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 117);
            this.panel2.TabIndex = 272;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 250;
            this.label3.Text = "Out of Stock Item";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_SearchBy);
            this.panel3.Location = new System.Drawing.Point(130, 298);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 29);
            this.panel3.TabIndex = 273;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // tb_SearchBy
            // 
            this.tb_SearchBy.BackColor = System.Drawing.Color.White;
            this.tb_SearchBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SearchBy.Location = new System.Drawing.Point(7, 7);
            this.tb_SearchBy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_SearchBy.Name = "tb_SearchBy";
            this.tb_SearchBy.Size = new System.Drawing.Size(230, 15);
            this.tb_SearchBy.TabIndex = 160;
            // 
            // panel_search_MS
            // 
            this.panel_search_MS.Controls.Add(this.pb_search_MS);
            this.panel_search_MS.Location = new System.Drawing.Point(378, 296);
            this.panel_search_MS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_search_MS.Name = "panel_search_MS";
            this.panel_search_MS.Size = new System.Drawing.Size(33, 33);
            this.panel_search_MS.TabIndex = 274;
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
            this.pb_search_MS.MouseEnter += new System.EventHandler(this.panel_search_MS_MouseEnter);
            this.pb_search_MS.MouseLeave += new System.EventHandler(this.panel_search_MS_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_MasterItem);
            this.panel4.Location = new System.Drawing.Point(57, 344);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1039, 512);
            this.panel4.TabIndex = 275;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1127, 893);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel_search_MS);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_hi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_profil)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MasterItem)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_search_MS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_search_MS)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_profil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label_nama;
        private System.Windows.Forms.DataGridView dgv_MasterItem;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label lb_outofstock;
        private System.Windows.Forms.Label lb_lowstock;
        private System.Windows.Forms.Label lb_totalitem;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_hi;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tb_SearchBy;
        private System.Windows.Forms.Panel panel_search_MS;
        private System.Windows.Forms.PictureBox pb_search_MS;
        private System.Windows.Forms.Panel panel4;
    }
}