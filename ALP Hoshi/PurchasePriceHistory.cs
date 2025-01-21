using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_Hoshi
{
    public partial class PurchasePriceHistory : Form
    {
        public PurchasePriceHistory()
        {
            InitializeComponent();
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable MasterPurchasePriceHistory = new DataTable();

        private void PurchasePriceHistory_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_MasterPurchasePriceHistory_PPH.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_MasterPurchasePriceHistory_PPH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;

            tb_itemid_PPH.Text = "";
            corner(panel_search_PPH);

            panel_search_PPH.BackColor = ColorTranslator.FromHtml("#FFC4C4");
            panel_searchby_PPH.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            btn_clear_PPH.BackColor = ColorTranslator.FromHtml("#F25252");

            query = $"SELECT * FROM vPurchaseHistory;";
            SearchPurchasePriceHistory();
            dgv_MasterPurchasePriceHistory_PPH.ClearSelection();

            dgv_MasterPurchasePriceHistory_PPH.DataBindingComplete += dgv_MasterPurchasePriceHistory_PPH_DataBindingComplete;
        }
        private void dgv_MasterPurchasePriceHistory_PPH_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_MasterPurchasePriceHistory_PPH.ClearSelection();
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

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        public void SearchPurchasePriceHistory()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(MasterPurchasePriceHistory);
            sqlconnect.Close();
            dgv_MasterPurchasePriceHistory_PPH.DataSource = MasterPurchasePriceHistory;
            dgv_MasterPurchasePriceHistory_PPH.ClearSelection();
        }

        private void btn_clear_PPH_Click(object sender, EventArgs e)
        {
            
        }

        private void panel_itemid_PPH_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int borderWidth = 7;
            Color borderColor = ColorTranslator.FromHtml("#FFFFFF");

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void panel_header_Paint(object sender, PaintEventArgs e)
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

        private void panel_searchby_PPH_Click(object sender, EventArgs e)
        {
            MasterPurchasePriceHistory.Clear();
            if (tb_itemid_PPH.Text == "")
            {
                query = $"SELECT * FROM vPurchaseHistory;";
            }
            else
            {
                query = $"SELECT * FROM vPurchaseHistory WHERE `Item ID` LIKE '%{tb_itemid_PPH.Text}%';";
            }
            SearchPurchasePriceHistory();
        }

        private void panel_searchby_PPH_MouseEnter(object sender, EventArgs e)
        {
            panel_searchby_PPH.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            pb_search_PPH.Image = Properties.Resources.Logo_Search___PPH__E_;
        }

        private void panel_searchby_PPH_MouseLeave(object sender, EventArgs e)
        {
            panel_searchby_PPH.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            pb_search_PPH.Image = Properties.Resources.Logo_Search___PPH;
        }

        private void panel_clear_PPH_Click(object sender, EventArgs e)
        {
            MasterPurchasePriceHistory.Clear();
            tb_itemid_PPH.Text = "";
            query = $"SELECT * FROM vPurchaseHistory;";
            SearchPurchasePriceHistory();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void dgv_MasterPurchasePriceHistory_PPH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
