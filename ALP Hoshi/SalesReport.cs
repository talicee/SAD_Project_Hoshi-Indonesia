using iTextSharp.text;
using iTextSharp.text.pdf;
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
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ALP_Hoshi
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        DataTable purchase_SR = new DataTable();
        System.Windows.Forms.DataVisualization.Charting.Series series;
        string query;
        string input = "";
        string date = "";
        string[] month;
        DataTable dtSalesReport = new DataTable();
        int grandtotal = 0;

        int yearnow = DateTime.Now.Year;

        private void SalesReport_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_SalesReport.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_SalesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;
            panel_garis.BackColor = ColorTranslator.FromHtml("#F57B7B");
            butt_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            butt_downloadpdf.BackColor = ColorTranslator.FromHtml("#F25252");

            month = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            for (int i = 2023; i <= yearnow; i++)
            {
                cb_year_monthly.Items.Add(i.ToString());
                cb_year_yearly.Items.Add(i.ToString());
            }

            corner(p_totalitempurchased);
            corner(p_totalpurchase);
            corner(p_totalpurchasetransactions);

            p_totalpurchasetransactions.BackColor = ColorTranslator.FromHtml("#FFB1B1");
            p_totalpurchase.BackColor = ColorTranslator.FromHtml("#FFB1B1");
            p_totalitempurchased.BackColor = ColorTranslator.FromHtml("#FFB1B1");

            Legend legend = new Legend("");
            chart_SR.Legends.Add(legend);

            series = new System.Windows.Forms.DataVisualization.Charting.Series("This Year")
            {
                Name = "This Year",
                Color = Color.Black
            };


            sales(purchase_SR, series);
            chart_SR.Series.Add(series);
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.LabelForeColor = Color.Black;
            chart(chart_SR);

            lb_grandtotal.Text = lb_grandtotal.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp {0:N0}", grandtotal);

            date = "ALL";
            header();
            dgv_SalesReport.DataBindingComplete += dgv_SalesReport_DataBindingComplete;
        }
        private void dgv_SalesReport_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_SalesReport.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
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

        private void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_yearly.Checked == true)
            {
                cb_year_yearly.Enabled = true;
            }
            else
            {
                cb_year_yearly.Enabled = false;
                cb_year_yearly.SelectedIndex = -1;
                input = "";
                date = "";
                sales(purchase_SR, series);
                dtSalesReport.Clear();
                date = "ALL";
                header();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
                grandtotal = 0;
                lb_grandtotal.Text = lb_grandtotal.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp {0:N0}", grandtotal);
            }
        }

        private void rb_monthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_monthly.Checked == true)
            {
                cb_year_monthly.Enabled = true;
                cb_month_monthly.Enabled = true;
            }
            else
            {
                cb_year_monthly.Enabled = false;
                cb_month_monthly.Enabled = false;
                cb_year_monthly.SelectedIndex = -1;
                cb_month_monthly.SelectedIndex = -1;
                input = "";
                date = "";
                sales(purchase_SR, series);
                dtSalesReport.Clear();
                date = "ALL";
                header();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
                grandtotal = 0;
                lb_grandtotal.Text = lb_grandtotal.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "Rp {0:N0}", grandtotal);
            }
        }
        private void chart(Chart chart1)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.LineWidth = 1;
            chart1.ChartAreas[0].AxisY.LineWidth = 1;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0 k";
            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Inter", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Inter", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.White;
        }

        public void sales(DataTable purchase_total, System.Windows.Forms.DataVisualization.Charting.Series series)
        {
            purchase_SR.Clear();
            sqlconnect = new MySqlConnection(
                        $"server=sub1.sift-uc.id;" +
            $"uid=subsift2_user_a2;" +
            $"pwd=3,^i*9vREN2(;" +
            $"database=subsift2_db_a2");
            query = "CALL pChartSales(@input,@date);";
            sqlconnect.Open();

            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Parameters.AddWithValue("@input", input);
            sqlcommand.Parameters.AddWithValue("@date", date);

            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(purchase_SR);
            sqlconnect.Close();

            if (purchase_SR.Rows.Count < 1)
            {
                chart_SR.Visible = false;
                label_info.Visible = true;
            }
            else
            {
                bool tes = false;
                for (int i = 0; i < purchase_SR.Rows.Count; i++)
                {
                    if (purchase_SR.Rows[i][1].ToString() != "0")
                    {
                        tes = true;
                        break;
                    }
                }

                if (tes == true)
                {
                    chart_SR.Visible = true;
                    label_info.Visible = false;
                }
                else
                {
                    chart_SR.Visible = false;
                    label_info.Visible = true;
                }
            }

            if (series != null)
            {
                series.Points.Clear();

                if (date == "month")
                {
                    series.LegendText = "This Month";
                    string[] week = { "Week 1", "Week 2", "Week 3", "Week 4" };
                    for (int i = 0; i < purchase_SR.Rows.Count; i++)
                    {
                        if (int.TryParse(purchase_SR.Rows[i][1]?.ToString(), out int harga))
                        {
                            harga /= 1000;
                            series.Points.AddXY(week[i], harga);
                        }
                        else
                        {
                            Console.WriteLine($"Baris {i} memiliki data tidak valid: {purchase_SR.Rows[i][1]}");
                        }
                    }
                    series.LegendText = $"{monthly} {tahun}";
                }
                else if (date == "year")
                {
                    string[] mo = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                    for (int i = 0; i < purchase_SR.Rows.Count; i++)
                    {
                        if (int.TryParse(purchase_SR.Rows[i][1]?.ToString(), out int harga))
                        {
                            harga /= 1000;
                            series.Points.AddXY(mo[i], harga);
                        }
                        else
                        {
                            Console.WriteLine($"Baris {i} memiliki data tidak valid: {purchase_SR.Rows[i][1]}");
                        }
                    }
                    series.LegendText = tahun;
                }

                series.Font = new System.Drawing.Font("Inter", 9, System.Drawing.FontStyle.Regular);
            }
        }

        int tanggal;
        string monthly = "";
        string tahun = "";

        private void cb_month_monthly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_month_monthly.Text != "" && cb_year_monthly.Text != "")
            {
                butt_downloadpdf.Enabled = true;
                string a = "";
                for (int i = 0; i < month.Length; i++)
                {
                    if (month[i] == cb_month_monthly.Text)
                    {
                        int cek = i + 1;
                        if (cek < 10)
                        {
                            a = '0' + cek.ToString();
                        }
                        else
                        {
                            a = cek.ToString();
                        }
                        break;
                    }
                }
                input = cb_year_monthly.Text + a;
                tanggal = Convert.ToInt32(input);
                monthly = cb_month_monthly.Text;
                tahun = cb_year_monthly.Text;
                date = "month";
                purchase_SR.Clear();
                sales(purchase_SR, series);
                header();
                dtSalesReport.Clear();
                query = $"SELECT* FROM vSalesTrans WHERE SUBSTRING(`Transaction Date`, 4) = '{cb_month_monthly.Text + ' ' + cb_year_monthly.Text}';";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtSalesReport);
                sqlconnect.Close();

                dgv_SalesReport.DataSource = dtSalesReport;

                grandtotal = 0;
                for (int i = 0; i < dtSalesReport.Rows.Count; i++)
                {
                    string harga = dtSalesReport.Rows[i][9].ToString();
                    int result = Convert.ToInt32(harga.Replace(".", "").Trim());
                    grandtotal = grandtotal + result;
                }

                lb_grandtotal.Text = lb_grandtotal.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                butt_clear.Enabled = true;
            }
        }

        private void cb_year_yearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            butt_downloadpdf.Enabled = true;
            input = cb_year_yearly.Text;
            date = "year";
            tahun = cb_year_yearly.Text;
            sales(purchase_SR, series);
            header();
            dtSalesReport.Clear();
            query = $"SELECT* FROM vSalesTrans WHERE RIGHT(`Transaction Date`, 4) = '{input}';";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtSalesReport);
            sqlconnect.Close();

            dgv_SalesReport.DataSource = dtSalesReport;

            grandtotal = 0;
            for (int i = 0; i < dtSalesReport.Rows.Count; i++)
            {
                string harga = dtSalesReport.Rows[i][9].ToString();
                int result = Convert.ToInt32(harga.Replace(".", "").Trim());
                grandtotal = grandtotal + result;
            }

            lb_grandtotal.Text = lb_grandtotal.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);

            butt_clear.Enabled = true;
        }

        private void chart_SR_MouseEnter(object sender, EventArgs e)
        {
            foreach (var series in chart_SR.Series)
            {
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "#,##0 k";
                series.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Bold);

                foreach (var point in series.Points)
                {
                    if (point.YValues[0] == 0)
                    {
                        point.Label = "0 k";
                    }
                }
            }
        }

        private void chart_SR_MouseLeave(object sender, EventArgs e)
        {
            foreach (var series in chart_SR.Series)
            {
                series.IsValueShownAsLabel = false;
                foreach (var point in series.Points)
                {
                    if (point.YValues[0] == 0)
                    {
                        point.Label = "";
                    }
                }
            }
        }

        private void butt_clear_Click(object sender, EventArgs e)
        {
            rb_monthly.Checked = false;
            rb_yearly.Checked = false;
            cb_year_monthly.Enabled = false;
            cb_year_monthly.Enabled = false;
            cb_month_monthly.Enabled = false;
            cb_year_monthly.SelectedIndex = -1;
            cb_month_monthly.SelectedIndex = -1;
            cb_year_yearly.SelectedIndex = -1;
            input = "";
            date = "";
            sales(purchase_SR, series);
            dtSalesReport.Clear();
            date = "ALL";
            header();
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;
            grandtotal = 0;
            lb_grandtotal.Text = grandtotal.ToString();
        }

        public void header()
        {
            sqlconnect = new MySqlConnection(
                        $"server=sub1.sift-uc.id;" +
                        $"uid=subsift2_user_a2;" +
                        $"pwd=3,^i*9vREN2(;" +
                        $"database=subsift2_db_a2");
            query = "CALL pHeaderSalesReport(@input,@date);";

            sqlconnect.Open();

            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Parameters.AddWithValue("@input", date);
            sqlcommand.Parameters.AddWithValue("@date", input);

            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable();
            sqldataadapter.Fill(dt);
            sqlconnect.Close();

            lb_totalpurchasetransactions.Text = dt.Rows[0][0].ToString();
            lb_totalpurchase.Text = dt.Rows[0][1].ToString();
            lb_totalitempurchase.Text = dt.Rows[0][2].ToString();
        }

        private void butt_downloadpdf_Click(object sender, EventArgs e)
        {
            string namafile = "";
            if (cb_month_monthly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Sales Report {monthly} {tahun}.pdf";
            }
            else if (cb_year_yearly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Sales Report {tahun}.pdf";
            }
            // 2. Pilih lokasi penyimpanan file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = namafile
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        // Konfigurasi dokumen PDF
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        PdfPTable headerTable = new PdfPTable(2)
                        {
                            WidthPercentage = 100
                        };
                        float[] headerWidths = { 15f, 85f };
                        headerTable.SetWidths(headerWidths);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            Properties.Resources.Logo___Hoshi.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            logo.ScaleToFit(50f, 50f);
                            PdfPCell logoCell = new PdfPCell(logo)
                            {
                                Border = PdfPCell.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                VerticalAlignment = Element.ALIGN_MIDDLE
                            };
                            headerTable.AddCell(logoCell);
                        }

                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD);
                        PdfPCell titleCell = new PdfPCell(new Phrase("Hoshi Indonesia", titleFont))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        headerTable.AddCell(titleCell);

                        pdfDoc.Add(headerTable);
                        pdfDoc.Add(new Paragraph("\n")); 
                        string date = "";
                        if (cb_month_monthly.Text != "")
                        {
                            DateTime today = DateTime.Now;
                            string datenow = today.ToString("d MMMM yyyy");
                            if (today.ToString("yyyy") == tahun && today.ToString("MMMM") == monthly)
                            {
                                date = $"1 {monthly} {tahun} - {datenow}";
                            }
                            else
                            {
                                date = $"1 {monthly} {tahun} - 31 {monthly} {tahun}";
                            }
                        }
                        else if (cb_year_yearly.Text != "")
                        {
                            DateTime today = DateTime.Now;
                            string datenow = today.ToString("d MMMM yyyy");
                            if (today.ToString("yyyy") == tahun)
                            {
                                date = $"1 January {tahun} - {datenow}";
                            }
                            else
                            {
                                date = $"1 January {tahun} - 31 December {tahun}";
                            }
                        }

                        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD);
                        var title = new Paragraph("Sales Report ", font)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Paragraph("\n"));

                        var infoFont = FontFactory.GetFont("Arial", 8);
                        var totalFont = FontFactory.GetFont("Arial", 9, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#FF6F6F")));
                        pdfDoc.Add(new Paragraph("    Periode Transaksi: ", infoFont));
                        pdfDoc.Add(new Paragraph($"    {date}", infoFont));
                        pdfDoc.Add(new Paragraph("\n"));
                        pdfDoc.Add(new Paragraph("    Total Transaksi:", infoFont));
                        pdfDoc.Add(new Paragraph($"    Rp {lb_grandtotal.Text}", totalFont));
                        pdfDoc.Add(new Paragraph("\n"));

                        if (dtSalesReport.Rows.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(dtSalesReport.Columns.Count)
                            {
                                WidthPercentage = 100,
                                TotalWidth = 500f
                            };

                            foreach (DataColumn column in dtSalesReport.Columns)
                            {
                                iTextSharp.text.Font cellFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7f, iTextSharp.text.Font.NORMAL);

                                Phrase phrase = new Phrase(column?.ToString() ?? "", cellFont);
                                PdfPCell cell = new PdfPCell(phrase)
                                {
                                    BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#FF9C9C")),
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    BorderColor = new BaseColor(ColorTranslator.FromHtml("#E3E3E3"))
                                };
                                table.AddCell(cell);
                            }

                            foreach (DataRow row in dtSalesReport.Rows)
                            {
                                foreach (var cellValue in row.ItemArray)
                                {
                                    iTextSharp.text.Font cellFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7f, iTextSharp.text.Font.NORMAL);

                                    Phrase phrase = new Phrase(cellValue?.ToString() ?? "", cellFont);
                                    PdfPCell cell = new PdfPCell(phrase)
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        VerticalAlignment = Element.ALIGN_MIDDLE,
                                        Padding = 2f,  
                                        BorderColor = new BaseColor(ColorTranslator.FromHtml("#E3E3E3"))
                                    };
                                    table.AddCell(cell);
                                }
                            }
                            pdfDoc.Add(table);
                        }
                        else
                        {
                            pdfDoc.Add(new Paragraph("\n"));
                            pdfDoc.Add(new Paragraph("\n"));
                            pdfDoc.Add(new Paragraph("\n"));
                            var info = new Paragraph("No Sales Transaction", titleFont)
                            {
                                Alignment = Element.ALIGN_CENTER
                            };
                            pdfDoc.Add(info);
                        }
                        pdfDoc.Close();
                        stream.Close();

                        MessageBox.Show("PDF berhasil dibuat di: " + filePath, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
