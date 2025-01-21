using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class Dashboard : Form
    {
        private Menu mainForm;
        public Dashboard(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable dtduedatesales = new DataTable();
        DataTable dtduedatepurchase = new DataTable();
        DataTable dtminimumstock = new DataTable();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // aku manggil dari class daripada tak method 1 1 mending tak class soalnya di pake di smua form
            label_hi_D.Text = "Hi " + GlobalData.Nama + " !";
            label_nama_D.Text = GlobalData.Nama;

            dgv_duedatepurchase_D.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_duedatesales_D.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_minimumstockreminder_D.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            MakeCircular(pb_profil_D);

            // ini untuk rounded corner methodnya ada dibawah
            corner(p_profit);
            corner(p_totalsales);
            corner(p_totalpurchase);
            corner(p_itemsold);


            // ini untuk warnain bu=iar bs sama persis kek yg figmamu
            //percentprofit_D.BackColor = ColorTranslator.FromHtml("#FB6669");
            //percentpurchase.BackColor = ColorTranslator.FromHtml("#FB6669");
            //percentsales_D.BackColor = ColorTranslator.FromHtml("#FB6669");
            //percentsold.BackColor = ColorTranslator.FromHtml("#FB6669");

            pan_addnewitem.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            pan_createpurchase.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            pan_createsales.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            panel_viewprofit_D.BackColor = ColorTranslator.FromHtml("#FFE0E0");

            
            pb_profit.Image = Properties.Resources.Logo_Dashboard___Profit;
            pb_totalsales.Image = Properties.Resources.Logo_Dashboard___Sales_and_Purchase;
            pb_totalpurchase.Image = Properties.Resources.Logo_Dashboard___Sales_and_Purchase;
            pb_totalitemsold.Image = Properties.Resources.Logo_Dashboard___Total_Items_Sold;

            pb_reminder.Image = Properties.Resources.Logo_Dashboard__Reminder__NEW_;
            pb_profil_D.Image = Properties.Resources.Logo___Profile__NEW_;

            pb_quickaction.Image = Properties.Resources.Logo_Dashboard___Quick_Action;
            pb_topitem.Image = Properties.Resources.Logo_Dashboard___Top_Items_Sales;

            cb_date.Text = "Monthly";


            // manggil semua function n procedure biar jalan diawal
            ItemSold();
            TotalPurchase();
            TotalSales();
            Profit();
            topitemsales();

            // Due Date Sales ============================================================================
            query = $"SELECT * FROM vDueDateSales;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtduedatesales);
            sqlconnect.Close();
            dgv_duedatesales_D.DataSource = dtduedatesales;
            dgv_duedatesales_D.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatesales_D.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatesales_D.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatesales_D.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatesales_D.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatesales_D.BackgroundColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatesales_D.GridColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatesales_D.RowTemplate.Height = 30;

            // Due Date Purchase ============================================================================
            query = $"SELECT * FROM vDueDatePurchase;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtduedatepurchase);
            sqlconnect.Close();
            dgv_duedatepurchase_D.DataSource = dtduedatepurchase;
            dgv_duedatepurchase_D.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatepurchase_D.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatepurchase_D.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_duedatepurchase_D.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatepurchase_D.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatepurchase_D.GridColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatepurchase_D.BackgroundColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_duedatepurchase_D.RowTemplate.Height = 30;

            // Minimum Stock Reminder ============================================================================
            query = $"SELECT * FROM vStockReminder;";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtminimumstock);
            sqlconnect.Close();
            dgv_minimumstockreminder_D.DataSource = dtminimumstock;
            dgv_minimumstockreminder_D.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_minimumstockreminder_D.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_minimumstockreminder_D.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_minimumstockreminder_D.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_minimumstockreminder_D.GridColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_minimumstockreminder_D.BackgroundColor = ColorTranslator.FromHtml("#FFF7F7");
            dgv_minimumstockreminder_D.RowTemplate.Height = 34;

            int a = Convert.ToInt32(label_profit_D.Text);
            int b = Convert.ToInt32(lb_itemsold.Text);
            int c = Convert.ToInt32(lb_totalpurchase.Text);
            int d = Convert.ToInt32(lb_totalsales.Text);

            label_profit_D.Text = a.ToString("N0").Replace(",", ".");
            lb_itemsold.Text = b.ToString("N0").Replace(",", ".");
            lb_totalpurchase.Text = c.ToString("N0").Replace(",", ".");
            lb_totalsales.Text = d.ToString("N0").Replace(",", ".");
        }

        private void p_duedate_sales_Paint(object sender, PaintEventArgs e)
        {
            // ini buat bordernya kan warnanya beda beda jadi ada banyak method ginian
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = ColorTranslator.FromHtml("#FF8686");

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        public void corner(Panel panel1)
        {
            // ini buat rounded corner kalau mau ubah lengkungannya seberap ubah aja ini int cornerRadius semakin gede smakin nglngkung
            int cornerRadius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            panel1.Region = new Region(path);
        }

        private void p_profit_Paint(object sender, PaintEventArgs e)
        {
            // ini juga buat border tapi bedanya yang ini bordernya nglngkung yang tadi itu kotak

            Panel panel = sender as Panel;

            int cornerRadius = 20; 
            int borderWidth = 1;   
            Color borderColor = ColorTranslator.FromHtml("#FFC7C7");

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius - 1, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void panel_home_page_Paint(object sender, PaintEventArgs e)
        {
            // kok kenapa ga disamain sm yg diatas? krn ini beda warna abis figma kalian banyak warna tiap border beda warna :)
            Panel panel = sender as Panel;

            int cornerRadius = 20;
            int borderWidth = 2;
            Color borderColor = ColorTranslator.FromHtml("#FFB1B1");

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(panel.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(panel.Width - cornerRadius - 1, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, panel.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        public void ItemSold()
        {
            // ini method buat manggil function masukin ke label berdasarkan pilihan bulan or taun

            query = "SELECT fTotalItemSold(@input);";
            string input = "";
            if (cb_date.Text == "Yearly")
            {
                input = "YEAR";
            }
            else if (cb_date.Text == "Monthly")
            {
                input = "MONTH";
            }
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@input", input); // ini biar bisa jalan kalau ada input harus kek gini
            object result = sqlcommand.ExecuteScalar();
            lb_itemsold.Text = result != null ? result.ToString() : "No data found";
        }
        // dibawah ini smua sama function semua
        public void TotalPurchase()
        {
            query = "SELECT fTotalPurchase(@input);";
            string input = "";
            if (cb_date.Text == "Yearly")
            {
                input = "YEAR";
            }
            else if (cb_date.Text == "Monthly")
            {
                input = "MONTH";
            }
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@input", input);
            object result = sqlcommand.ExecuteScalar();
            lb_totalpurchase.Text = result != null ? result.ToString() : "No data found";
        }

        public void TotalSales()
        {
            query = "SELECT fTotalSales(@input);";
            string input = "";
            if (cb_date.Text == "Yearly")
            {
                input = "YEAR";
            }
            else if (cb_date.Text == "Monthly")
            {
                input = "MONTH";
            }
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@input", input);
            object result = sqlcommand.ExecuteScalar();
            lb_totalsales.Text = result != null ? result.ToString() : "No data found";
        }

        public void Profit()
        {
            query = "SELECT fProfit(@input);";
            string input = "";
            if (cb_date.Text == "Yearly")
            {
                input = "YEAR";
            }
            else if (cb_date.Text == "Monthly")
            {
                input = "MONTH";
            }
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@input", input);
            object result = sqlcommand.ExecuteScalar();
            label_profit_D.Text = result != null ? result.ToString() : "No data found";
        }

        private void cb_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            // biar kalo ganti bulan or taun ikut brubah semua sesuai functionnya dan inputnya berdasarkan ini combobox
            ItemSold();
            TotalPurchase();
            TotalSales();
            Profit();
            topitemsales();
        }

        int itemYOffset = 0; // buat integer buat dipakek dibawah
        int itemXOffset = 0;
        private void tabel(string que, Panel panel, Label namalabel, string header1, string header2, string header3)
        {
            query = que;
            sqlconnect = DatabaseConnection.Connection;

            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.CommandType = CommandType.Text;
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            DataTable data = new DataTable();
            sqldataadapter.Fill(data);
            sqlconnect.Close();

            // ini biar bisa aku ambil label yang mau aku mulai buat nulis pertama kali coba liat di designnya
            // ada titik titik itu awal mulai dri situ tp itu visible karna aku buat label abru
            itemYOffset = namalabel.Location.Y;
            itemXOffset = namalabel.Location.X;

            // ini buat headernya kek judul judul di tiab tabelmu itu
            Label headerpertama = new Label
            {
                Text = header1,
                Location = new Point(itemXOffset, itemYOffset),
                AutoSize = true
            };
            Label headerkedua = new Label
            {
                Text = header2,
                Location = new Point(itemXOffset + 70, itemYOffset),
                AutoSize = true
            };
            Label headerketiga = new Label
            {
                Text = header3,
                Location = new Point(itemXOffset + 160, itemYOffset),
                AutoSize = true
            };

            // ini untuk masukin kedalam control panelnya biar bs muncul
            // dalam control itu sgala hal yanga da di dalam panelmu ntah textbox
            // panel dalam panel, label, button itu semua di sebut control panel kalo ada didalam panelnya
            panel.Controls.Add(headerpertama);
            panel.Controls.Add(headerkedua);
            panel.Controls.Add(headerketiga);

            // ini aku kasih jarak antara headernya sama isi datanya
            itemYOffset += 40;

            // nah tadi kan queryku masukin ke dalam data table kan nah ini aku for buat masukin ke tabelmu
            // caranya sama kek header tadi mwehehehe itu koordinat set sndiri coba coba aja yg mnurutmu pas
            foreach (DataRow row in data.Rows)
            {
                Label duedate = new Label
                {
                    Text = $"{row[0]}",
                    Location = new Point(itemXOffset, itemYOffset),
                    AutoSize = true
                };
                Label ID = new Label
                {
                    Text = $"{row[1]}",
                    Location = new Point(itemXOffset + 70, itemYOffset),
                    AutoSize = true
                };
                Label Orang = new Label
                {
                    Text = $"{row[2]}",
                    Location = new Point(itemXOffset + 160, itemYOffset),
                    AutoSize = true
                };
                panel.Controls.Add(duedate);
                panel.Controls.Add(ID);
                panel.Controls.Add(Orang);

                // jarak tiap data yang vertikal
                itemYOffset += 27;
            }
        }

        // ini sama aja kek diatas kenapa ga disamain karn aini bisa milih taun or bulan jadi beda mwehehehehe
        private void topitemsales()
        {
            // ini buat apa? nah jadi karna ini bisa ganti ganti otomatis ini label labelnya bakal aku hapus semuanya dan
            // generate lagi ulang label baru nah tapi kan tulisan judul sama gambar gaboleh di hapus kan
            // makanya aku foreach semua control dalam panel ini aku hapus yang selain judul sama gambarnya :)
            foreach (Control control in panel_topitem.Controls.Cast<Control>().ToList())
            {
                if (control != label_topitemsales && control != pb_topitem)
                {
                    panel_topitem.Controls.Remove(control);
                }
            }

            query = "CALL pTopItemSales(@input)";
            string input = "";
            if (cb_date.Text == "Yearly")
            {
                input = "YEARLY";
            }
            else if (cb_date.Text == "Monthly")
            {
                input = "MONTHLY";
            }
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.Parameters.AddWithValue("@input", input);
            sqlcommand.CommandType = CommandType.Text;
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            DataTable topitem = new DataTable();
            sqldataadapter.Fill(topitem);
            sqlconnect.Close();

            itemYOffset = patokan_topitem.Location.Y;
            itemXOffset = patokan_topitem.Location.X;

            Label headerpertama = new Label
            {
                Text = "No",
                Location = new Point(itemXOffset, itemYOffset),
                AutoSize = true
            };
            Label headerkedua = new Label
            {
                Text = "Item Name",
                Location = new Point(itemXOffset + 70, itemYOffset),
                AutoSize = true
            };
            Label headerketiga = new Label
            {
                Text = "Quantity",
                Location = new Point(itemXOffset + 160, itemYOffset),
                AutoSize = true
            };

            panel_topitem.Controls.Add(headerpertama);
            panel_topitem.Controls.Add(headerkedua);
            panel_topitem.Controls.Add(headerketiga);

            itemYOffset += 40;
            int nomor = 0;
            foreach (DataRow row in topitem.Rows)
            {
                nomor++;
                Label no = new Label
                {
                    Text = $"{nomor.ToString()}",
                    Location = new Point(itemXOffset, itemYOffset),
                    AutoSize = true
                };
                Label Itemname = new Label
                {
                    Text = $"{row[0]}",
                    Location = new Point(itemXOffset + 70, itemYOffset),
                    AutoSize = true
                };
                Label qty = new Label
                {
                    Text = $"{row[1]}",
                    Location = new Point(itemXOffset + 160, itemYOffset),
                    AutoSize = true
                };
                panel_topitem.Controls.Add(no);
                panel_topitem.Controls.Add(Itemname);
                panel_topitem.Controls.Add(qty);

                itemYOffset += 27;
            }
        }
        // ini juga sama kok ga pake yang diatas? iya soalnya ini cuma 2 kolom yang lain 3 kolom jadi ga bisa di samain
        private void tabelstock(string que, Panel panel, Label namalabel, string header1, string header2)
        {
            query = que;
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.CommandType = CommandType.Text;
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            DataTable data = new DataTable();
            sqldataadapter.Fill(data);
            sqlconnect.Close();

            itemYOffset = namalabel.Location.Y;
            itemXOffset = namalabel.Location.X;
            Label headerpertama = new Label
            {
                Text = header1,
                Location = new Point(itemXOffset, itemYOffset),
                AutoSize = true
            };
            Label headerkedua = new Label
            {
                Text = header2,
                Location = new Point(itemXOffset + 70, itemYOffset),
                AutoSize = true
            };

            panel.Controls.Add(headerpertama);
            panel.Controls.Add(headerkedua);

            itemYOffset += 40;

            foreach (DataRow row in data.Rows)
            {
                Label duedate = new Label
                {
                    Text = $"{row[0]}",
                    Location = new Point(itemXOffset, itemYOffset),
                    AutoSize = true
                };
                Label ID = new Label
                {
                    Text = $"{row[1]}",
                    Location = new Point(itemXOffset + 70, itemYOffset),
                    AutoSize = true
                };
                panel.Controls.Add(duedate);
                panel.Controls.Add(ID);

                itemYOffset += 30;
            }
        }

        //buat garis tepi yang abu abu itu biar ada garis aja :v
        private void panel_submenu_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 2;
            Color borderColor = Color.WhiteSmoke;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        // buat profil biar bisa nglingkar
        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel_viewprofit_D_Click(object sender, EventArgs e)
        {
            mainForm.viewprofitreport();
        }

        private void panel_viewprofit_D_MouseEnter(object sender, EventArgs e)
        {
            panel_viewprofit_D.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            label_viewreport_D.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void panel_viewprofit_D_MouseLeave(object sender, EventArgs e)
        {
            panel_viewprofit_D.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_viewreport_D.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 1;
            Color borderColor = ColorTranslator.FromHtml("#FF8686");

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void pan_addnewitem_Click(object sender, EventArgs e)
        {
            mainForm.additem();
        }

        private void pan_createsales_Click(object sender, EventArgs e)
        {
            mainForm.addsales();
        }

        private void pan_createpurchase_Click(object sender, EventArgs e)
        {
            mainForm.addpurchase();
        }

        private void pan_createpurchase_MouseEnter(object sender, EventArgs e)
        {
            pan_createpurchase.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            label_createpur.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void pan_createpurchase_MouseLeave(object sender, EventArgs e)
        {
            pan_createpurchase.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_createpur.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void pan_createsales_MouseEnter(object sender, EventArgs e)
        {
            pan_createsales.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            label_createsales.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void pan_createsales_MouseLeave(object sender, EventArgs e)
        {
            pan_createsales.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_createsales.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }

        private void pan_addnewitem_MouseEnter(object sender, EventArgs e)
        {
            pan_addnewitem.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            label_additem.BackColor = ColorTranslator.FromHtml("#EEAFAF");
        }

        private void pan_addnewitem_MouseLeave(object sender, EventArgs e)
        {
            pan_addnewitem.BackColor = ColorTranslator.FromHtml("#FFE0E0");
            label_additem.BackColor = ColorTranslator.FromHtml("#FFE0E0");
        }
    }
}
