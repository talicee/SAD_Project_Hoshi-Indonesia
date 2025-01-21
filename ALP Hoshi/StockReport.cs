using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ALP_Hoshi
{
    public partial class StockReport : Form
    {
        public StockReport()
        {
            InitializeComponent();
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query;
        string tglawal = "";
        string tglakhir = "";
        string input = "";
        string date = "";
        string[] month;
        string info = "";
        DataTable dtStockReport = new DataTable();

        int yearnow = DateTime.Now.Year;

        int tanggal;
        string monthly = "";
        string tahun = "";

        private void StockReport_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_StockReport.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_StockReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;

            butt_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            butt_downloadpdf.BackColor = ColorTranslator.FromHtml("#F25252");

            for (int i = 2023; i <= yearnow; i++)
            {
                cb_year_monthly.Items.Add(i.ToString());
                cb_year_yearly.Items.Add(i.ToString());
            }

            month = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            dgv_StockReport.DataBindingComplete += dgv_StockReport_DataBindingComplete;
        }
        private void dgv_StockReport_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_StockReport.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void cb_year_yearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_year_yearly.Text != "")
            {
                input = cb_year_yearly.Text;
                tahun = cb_year_yearly.Text;
                int tahundepan = Convert.ToInt32(tahun) + 1;
                string nextyear = tahundepan.ToString();
                dtStockReport.Clear();
                dtStockReport.Columns.Clear();

                query = $"call pStockReport('{tahun}-01-01','{nextyear}-01-01', '{info}');";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtStockReport);
                sqlconnect.Close();

                dgv_StockReport.DataSource = dtStockReport;

                butt_clear.Enabled = true;
                butt_downloadpdf.Enabled = true;
            }
        }

        private void cb_month_monthly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_month_monthly.Text != "" && cb_year_monthly.Text != "")
            {
                string a = "";
                string b = "";
                string thn = cb_year_monthly.Text;
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
                        cek = cek + 1;
                        if (cek > 12)
                        {
                            cek = cek - 12;
                            thn = (Convert.ToInt32(cb_year_monthly.Text) + 1).ToString();
                        }
                        if (cek < 10)
                        {
                            b = '0' + cek.ToString();
                        }
                        else
                        {
                            b = cek.ToString();
                        }
                        break;
                    }
                }
                input = cb_year_monthly.Text + a;
                tglawal = $"{cb_year_monthly.Text}-{a}-01";
                tglakhir = $"{thn}-{b}-01";
                tanggal = Convert.ToInt32(input);
                monthly = cb_month_monthly.Text;
                tahun = cb_year_monthly.Text;

                dtStockReport.Clear();
                dtStockReport.Columns.Clear();
                query = $"call pStockReport('{tglawal}','{tglakhir}','{info}');";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtStockReport);
                sqlconnect.Close();

                dgv_StockReport.DataSource = dtStockReport;

                butt_clear.Enabled = true;
                butt_downloadpdf.Enabled = true;
            }
        }

        private void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_yearly.Checked == true)
            {
                cb_year_yearly.Enabled = true;
                info = "year";
            }
            else
            {
                cb_year_yearly.Enabled = false;
                cb_year_yearly.SelectedIndex = -1;
                dtStockReport.Clear();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
            }
        }

        private void rb_monthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_monthly.Checked == true)
            {
                cb_year_monthly.Enabled = true;
                cb_month_monthly.Enabled = true;
                info = "month";
            }
            else
            {
                cb_year_monthly.Enabled = false;
                cb_month_monthly.Enabled = false;
                cb_year_monthly.SelectedIndex = -1;
                cb_month_monthly.SelectedIndex = -1;
                dtStockReport.Clear();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
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
            dtStockReport.Clear();
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;
        }

        private void butt_downloadpdf_Click(object sender, EventArgs e)
        {
            string namafile = "";
            if (cb_month_monthly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Stock Report {monthly} {tahun}.pdf";
            }
            else if (cb_year_yearly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Stock Report {tahun}.pdf";
            }

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
                        var title = new Paragraph("Stock Report ", font)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Paragraph("\n"));

                        var infoFont = FontFactory.GetFont("Arial", 8);
                        pdfDoc.Add(new Paragraph("    Periode Transaksi: ", infoFont));
                        pdfDoc.Add(new Paragraph($"    {date}", infoFont));
                        pdfDoc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(dtStockReport.Columns.Count)
                        {
                            WidthPercentage = 100,
                            TotalWidth = 500f
                        };

                        foreach (DataColumn column in dtStockReport.Columns)
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

                        foreach (DataRow row in dtStockReport.Rows)
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
