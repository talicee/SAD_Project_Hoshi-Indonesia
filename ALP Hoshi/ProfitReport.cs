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
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text.pdf.draw;
using System.Drawing.Imaging;
using System.Security.Policy;

namespace ALP_Hoshi
{
    public partial class ProfitReport : Form
    {
        private Menu mainForm;
        public ProfitReport(Menu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;

        string query;
        string input = "";
        string[] month;

        DataTable dtSalesReport = new DataTable();
        DataTable dtPurchaseReport = new DataTable();

        int grandtotal = 0;
        int yearnow = DateTime.Now.Year;

        int tanggal;
        string monthly = "";
        string tahun = "";

        private void ProfitReport_Load(object sender, EventArgs e)
        {
            label_nama.Text = GlobalData.Nama;
            dgv_SalesReport.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_PurchaseReport.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE0E0");
            dgv_SalesReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_PurchaseReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MakeCircular(pb_profil);
            pb_profil.Image = Properties.Resources.Logo___Profile__NEW_;
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;

            panel_garis.BackColor = ColorTranslator.FromHtml("#F57B7B");
            butt_clear.BackColor = ColorTranslator.FromHtml("#F25252");
            butt_downloadpdf.BackColor = ColorTranslator.FromHtml("#F25252");

            lb_sales.ForeColor = ColorTranslator.FromHtml("#F25252");
            lb_purchase.ForeColor = ColorTranslator.FromHtml("#F25252");

            for (int i = 2023; i <= yearnow; i++)
            {
                cb_year_monthly.Items.Add(i.ToString());
                cb_year_yearly.Items.Add(i.ToString());
            }

            month = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            lb_totalpurchase.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            lb_totalprofitloss.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            dgv_SalesReport.DataBindingComplete += dgv_SalesReportDataBindingComplete;
            dgv_PurchaseReport.DataBindingComplete += dgv_PurchaseReport_DataBindingComplete;
        }
        private void dgv_PurchaseReport_DataBindingComplete(object sender, EventArgs e)
        {
            dgv_PurchaseReport.ClearSelection();
        }
        private void dgv_SalesReportDataBindingComplete(object sender, EventArgs e)
        {
            dgv_SalesReport.ClearSelection();
        }

        private void MakeCircular(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        private void cb_month_monthly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_month_monthly.Text != "" && cb_year_monthly.Text != "")
            {
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

                dtSalesReport.Clear();
                dtPurchaseReport.Clear();

                int sales = 0;
                int purchase = 0;

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
                    sales = sales + result;
                }

                lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", sales);

                query = $"SELECT* FROM vPurchaseTrans WHERE SUBSTRING(`Transaction Date`, 4) = '{cb_month_monthly.Text + ' ' + cb_year_monthly.Text}';";
                sqlconnect = DatabaseConnection.Connection;
                sqlcommand = new MySqlCommand(query, sqlconnect);
                sqldataadapter = new MySqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(dtPurchaseReport);
                sqlconnect.Close();

                dgv_PurchaseReport.DataSource = dtPurchaseReport;

                for (int i = 0; i < dtPurchaseReport.Rows.Count; i++)
                {
                    string harga = dtPurchaseReport.Rows[i][10].ToString();
                    int result = Convert.ToInt32(harga.Replace(".", "").Trim());
                    purchase = purchase + result;
                }

                if (dtPurchaseReport.Rows.Count < 1 && dtSalesReport.Rows.Count < 1)
                {
                    butt_downloadpdf.Enabled = false;
                }
                else
                {
                    butt_downloadpdf.Enabled = true;
                }

                if (dtPurchaseReport.Rows.Count < 1)
                {
                    label_infopurchase.Visible = true;
                }
                else
                {
                    label_infopurchase.Visible = false;
                }

                if(dtSalesReport.Rows.Count < 1)
                {
                    label_infosales.Visible = true;
                }
                else
                {
                    label_infosales.Visible = false;
                }

                grandtotal = sales - purchase;
                lb_totalpurchase.Text = lb_totalpurchase.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", purchase);
                lb_totalprofitloss.Text = lb_totalprofitloss.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                butt_clear.Enabled = true;
            }
        }

        private void cb_year_yearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            input = cb_year_yearly.Text;
            tahun = cb_year_yearly.Text;
            dtSalesReport.Clear();
            dtSalesReport.Clear();
            dtPurchaseReport.Clear();

            int sales = 0;
            int purchase = 0;

            query = $"SELECT* FROM vSalesTrans WHERE RIGHT (`Transaction Date`, 4) = '{input}';";
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
                sales = sales + result;
            }

            lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", sales);

            query = $"SELECT* FROM vPurchaseTrans WHERE RIGHT(`Transaction Date`, 4) = '{input}';";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtPurchaseReport);
            sqlconnect.Close();

            dgv_PurchaseReport.DataSource = dtPurchaseReport;

            for (int i = 0; i < dtPurchaseReport.Rows.Count; i++)
            {
                string harga = dtPurchaseReport.Rows[i][10].ToString();
                int result = Convert.ToInt32(harga.Replace(".", "").Trim());
                purchase = purchase + result;
            }

            if(dtPurchaseReport.Rows.Count < 1 && dtSalesReport.Rows.Count < 1)
            {
                butt_downloadpdf.Enabled = false;
            }
            else
            {
                butt_downloadpdf.Enabled = true;
            }

            if (dtPurchaseReport.Rows.Count < 1)
            {
                label_infopurchase.Visible = true;
            }
            else
            {
                label_infopurchase.Visible = false;
            }

            if (dtSalesReport.Rows.Count < 1)
            {
                label_infosales.Visible = true;
            }
            else
            {
                label_infosales.Visible = false;
            }

            grandtotal = sales - purchase;
            lb_totalpurchase.Text = lb_totalpurchase.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", purchase);
            lb_totalprofitloss.Text = lb_totalprofitloss.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);

            butt_clear.Enabled = true;
            butt_downloadpdf.Enabled = true;
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
                dtSalesReport.Clear();
                dtPurchaseReport.Clear();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
                label_infopurchase.Visible = true;
                label_infosales.Visible = true;
                grandtotal = 0;
                lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                lb_totalpurchase.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                lb_totalprofitloss.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            }
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
                dtSalesReport.Clear();
                dtPurchaseReport.Clear();
                butt_clear.Enabled = false;
                butt_downloadpdf.Enabled = false;
                label_infopurchase.Visible = true;
                label_infosales.Visible = true;
                grandtotal = 0;
                lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                lb_totalpurchase.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
                lb_totalprofitloss.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            }
        }

        private void butt_downloadpdf_Click(object sender, EventArgs e)
        {
            string namafile = "";
            if (cb_month_monthly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Profit & Loss Report {monthly} {tahun}.pdf";
            }
            else if (cb_year_yearly.Text != "")
            {
                namafile = $"Hoshi Indonesia - Profit & Loss Report {tahun}.pdf";
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
                    // Membuka stream file
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        // Konfigurasi dokumen PDF
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // 1. Tambahkan header dengan logo dan nama
                        PdfPTable headerTable = new PdfPTable(2)
                        {
                            WidthPercentage = 100
                        };
                        float[] headerWidths = { 15f, 85f };
                        headerTable.SetWidths(headerWidths);

                        // Tambahkan logo dari Resources
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Mengubah resource logo menjadi stream
                            Properties.Resources.Logo___Hoshi.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            logo.ScaleToFit(50f, 50f); // Ukuran logo
                            PdfPCell logoCell = new PdfPCell(logo)
                            {
                                Border = PdfPCell.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                VerticalAlignment = Element.ALIGN_MIDDLE
                            };
                            headerTable.AddCell(logoCell);
                        }

                        // Tambahkan nama "Hoshi Indonesia"
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD);
                        PdfPCell titleCell = new PdfPCell(new Phrase("Hoshi Indonesia", titleFont))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        headerTable.AddCell(titleCell);

                        pdfDoc.Add(headerTable);
                        pdfDoc.Add(new Paragraph("\n")); // Spasi setelah header
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

                        // Menambahkan tulisan Sales Report
                        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD);
                        var title = new Paragraph("Profit & Loss Report ", font)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Paragraph("\n"));

                        // 2. Tambahkan informasi periode transaksi
                        var infoFont = FontFactory.GetFont("Arial", 8);
                        var totalFont = FontFactory.GetFont("Arial", 9, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#FF6F6F")));
                        pdfDoc.Add(new Paragraph("    Periode Transaksi: ", infoFont));
                        pdfDoc.Add(new Paragraph($"    {date}", infoFont));
                        pdfDoc.Add(new Paragraph("\n"));

                        BaseColor backColor = new BaseColor(ColorTranslator.FromHtml("#FFFFFF"));

                        PdfPTable headerTotal = new PdfPTable(5)
                        {
                            WidthPercentage = 100
                        };

                        headerTotal.SetWidths(new float[] { 0.8f, 0.2f, 0.8f, 0.2f, 0.8f });

                        PdfPCell CreatePanelCell(string headerText, string valueText)
                        {
                            PdfPTable panelTable = new PdfPTable(1);
                            panelTable.WidthPercentage = 100;

                            PdfPCell headerCell = new PdfPCell(new Phrase(headerText, infoFont))
                            {
                                Border = PdfPCell.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                BackgroundColor = backColor,
                                Padding = 3
                            };
                            panelTable.AddCell(headerCell);

                            PdfPCell valueCell = new PdfPCell(new Phrase(valueText, totalFont))
                            {
                                Border = PdfPCell.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                BackgroundColor = backColor,
                                Padding = 8
                            };
                            panelTable.AddCell(valueCell);

                            PdfPCell outerCell = new PdfPCell(panelTable)
                            {
                                Border = PdfPCell.BOX,
                                Padding = 1
                            };

                            return outerCell;
                        }

                        headerTotal.AddCell(CreatePanelCell("  Total Profit", $"Rp {lb_totalprofitloss.Text}"));

                        headerTotal.AddCell(new PdfPCell(new Phrase(""))
                        {
                            Border = PdfPCell.NO_BORDER
                        });

                        headerTotal.AddCell(CreatePanelCell("  Total Sales", $"Rp {lb_totalsales.Text}"));

                        headerTotal.AddCell(new PdfPCell(new Phrase(""))
                        {
                            Border = PdfPCell.NO_BORDER
                        });

                        headerTotal.AddCell(CreatePanelCell("  Total Purchase", $"Rp {lb_totalpurchase.Text}"));

                        pdfDoc.Add(headerTotal);

                        pdfDoc.Add(new Paragraph("\n"));
                        pdfDoc.Add(new Paragraph("    Sales Transaction", infoFont));
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

                        pdfDoc.Add(new Paragraph("\n"));
                        pdfDoc.Add(new Paragraph("    Purchase Transaction", infoFont));
                        pdfDoc.Add(new Paragraph("\n"));
                        if (dtPurchaseReport.Rows.Count > 0)
                        {
                            PdfPTable table = new PdfPTable(dtPurchaseReport.Columns.Count)
                            {
                                WidthPercentage = 100,
                                TotalWidth = 500f
                            };

                            foreach (DataColumn column in dtPurchaseReport.Columns)
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

                            foreach (DataRow row in dtPurchaseReport.Rows)
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
                            var info = new Paragraph("No Purchase Transaction", titleFont)
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
            dtSalesReport.Clear();
            dtPurchaseReport.Clear();
            butt_clear.Enabled = false;
            butt_downloadpdf.Enabled = false;
            grandtotal = 0;
            lb_totalsales.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            lb_totalpurchase.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
            lb_totalprofitloss.Text = lb_totalsales.Text = string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:N0}", grandtotal);
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
    }
}
