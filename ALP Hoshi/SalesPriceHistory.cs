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
    public partial class SalesPriceHistory : Form
    {
        public SalesPriceHistory()
        {
            InitializeComponent();
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;
        DataTable MasterSalesPriceHistory = new DataTable();

        private void SalesPriceHistory_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_MasterSalesPriceHistory_SPH.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            dgv_MasterSalesPriceHistory_SPH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            tb_itemid_SPH.Text = "";
            corner(panel_search_SPH);

            panel_search_SPH.BackColor = ColorTranslator.FromHtml("#FFC4C4");
            panel_searchby_SPH.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            btn_clear_SPH.BackColor = ColorTranslator.FromHtml("#F25252");

            query = $"SELECT * FROM vSalesHistory;";
            SearchSalesPriceHistory();
            dgv_MasterSalesPriceHistory_SPH.ClearSelection();
            dgv_MasterSalesPriceHistory_SPH.DataBindingComplete += dgv_MasterSalesPriceHistory_SPH_DataBindingComplete;
        }
        private void dgv_MasterSalesPriceHistory_SPH_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_MasterSalesPriceHistory_SPH.ClearSelection();
        }

        public void corner(Panel panel1)
        {
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

        public void SearchSalesPriceHistory()
        {
            sqlconnect = DatabaseConnection.Connection;
            sqlconnect.Open();
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(MasterSalesPriceHistory);
            sqlconnect.Close();
            dgv_MasterSalesPriceHistory_SPH.DataSource = MasterSalesPriceHistory;
            dgv_MasterSalesPriceHistory_SPH.ClearSelection();
        }

        private void btn_clear_SPH_Click(object sender, EventArgs e)
        {
            MasterSalesPriceHistory.Clear();
            tb_itemid_SPH.Text = "";
            query = $"SELECT * FROM vSalesHistory;";
            SearchSalesPriceHistory();
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

        private void panel_searchby_SPH_Click(object sender, EventArgs e)
        {
            MasterSalesPriceHistory.Clear();
            if (tb_itemid_SPH.Text == "")
            {
                query = $"SELECT * FROM vSalesHistory;";
            }
            else
            {
                query = $"SELECT * FROM vSalesHistory WHERE `Item ID` LIKE '%{tb_itemid_SPH.Text}%';";
            }
            SearchSalesPriceHistory();
        }

        private void panel_searchby_SPH_MouseEnter(object sender, EventArgs e)
        {
            panel_searchby_SPH.BackColor = ColorTranslator.FromHtml("#EEAFAF");
            pb_search_SPH.Image = Properties.Resources.Logo_Search___PPH__E_;
        }

        private void panel_searchby_SPH_MouseLeave(object sender, EventArgs e)
        {
            panel_searchby_SPH.BackColor = ColorTranslator.FromHtml("#FFE6E6");
            pb_search_SPH.Image = Properties.Resources.Logo_Search___PPH;
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
    }
}
