using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;

namespace ALP_Hoshi
{
    public partial class SalesTransaction_Invoice : Form
    {
        public SalesTransaction_Invoice()
        {
            InitializeComponent();
        }

        DataTable invoice_STI = new DataTable();
        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;

        DataTable dtGrand = new DataTable();
        private void SalesTransaction_Invoice_Load(object sender, EventArgs e)
        {
            //// Nyoba-nyoba aja ntr dihapus
            //invoice_STI.Columns.Add("No.");
            //invoice_STI.Columns.Add("Item ID");
            //invoice_STI.Columns.Add("Item Name");
            //invoice_STI.Columns.Add("Quantity");
            //invoice_STI.Columns.Add("Price / pcs");
            //invoice_STI.Columns.Add("Total");

            //invoice_STI.Rows.Add("1", "HI001R", "Plastic Container Type HI001 Red", "10 pcs", "13451", "3052420000");
            //invoice_STI.Rows.Add("2", "HI001R", "Plastic Container Type HI001 Red", "80 pcs", "`516237654", "3014540000");
            //invoice_STI.Rows.Add("3", "HI001R", "Plastic Container Type HI001 Red", "230 pcs", "156273", "12312313300000");
            //invoice_STI.Rows.Add("4", "HI001R", "Plastic Container Type HI001 Red", "15 pcs", "2134", "300023895743300");
            //invoice_STI.Rows.Add("5", "HI001R", "Plastic Container Type HI001 Red", "1034 pcs", "1253647", "1333030031200");
            //invoice_STI.Rows.Add("6", "HI001R", "Plastic Container Type HI001 Red", "1042 pcs", "87654", "14709300000");
            //invoice_STI.Rows.Add("7", "HI001R", "Plastic Container Type HI001 Red", "123 pcs", "15236", "986543300000");
            //invoice_STI.Rows.Add("8", "HI001R", "Plastic Container Type HI001 Red", "123 pcs", "1542", "4300000");
            //invoice_STI.Rows.Add("9", "HI001R", "Plastic Container Type HI001 Red", "5212 pcs", "154", "54321234300000");
            //invoice_STI.Rows.Add("10", "HI001R", "Plastic Container Type HI001 Red", "1 pcs", "16524", "345210");
            //dgv_invoice_STI.DataSource = invoice_STI;

            //// Buat warna header (dari sini kebawah udah fix sihh lek isa gausah diganti dah ku coba-coba)
            //// tinggal km buat yang PT.... dibawah best regard itu align ke tengah, sama gran total yang jumlah e align ke kanan
            //dgv_invoice_STI.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //dgv_invoice_STI.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //dgv_invoice_STI.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //dgv_invoice_STI.Columns[3].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //dgv_invoice_STI.Columns[4].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //dgv_invoice_STI.Columns[5].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //panel_header1_STI.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            //panel_header2_STI.BackColor = ColorTranslator.FromHtml("#FFACAC");
            //panel_header3_STI.BackColor = ColorTranslator.FromHtml("#FFACAC");

            //btn_save_STI.BackColor = ColorTranslator.FromHtml("#FF9090");
            //btn_ok_STI.BackColor = ColorTranslator.FromHtml("#FF9090");

            //dgv_invoice_STI.Columns[0].Width = 80;
            //dgv_invoice_STI.Columns[1].Width = 154;
            //dgv_invoice_STI.Columns[2].Width = 263;
            //dgv_invoice_STI.Columns[3].Width = 150;
            //dgv_invoice_STI.Columns[4].Width = 150;
            //dgv_invoice_STI.Columns[5].Width = 175;
            //dgv_invoice_STI.RowTemplate.Height = 80;
            //dgv_invoice_STI.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_invoice_STI.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_invoice_STI.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_invoice_STI.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_invoice_STI.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_invoice_STI.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            tb_transid_STI.Text = GlobalData.salesId;
            tb_transdate_STI.Text = GlobalData.transactionDateSales;
            tb_customer_STI.Text = GlobalData.customerName;
            tb_top_STI.Text = GlobalData.topCustomer;
            tb_duedate_STI.Text = GlobalData.dueDatePaymentSales;
            tb_status_STI.Text = GlobalData.paymentStatusSales;
            label_grandtotal_STI.Text = GlobalData.grandTotalSales;

            dgv_invoice_STI.DataSource = GlobalData.detailinvoice_sales;

            GrandTotal();

            dgv_invoice_STI.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Buat warna header (dari sini kebawah udah fix sihh lek isa gausah diganti dah ku coba-coba)
            // tinggal km buat yang PT.... dibawah best regard itu align ke tengah, sama gran total yang jumlah e align ke kanan
            dgv_invoice_STI.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_STI.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_STI.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_STI.Columns[3].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_STI.Columns[4].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_STI.Columns[5].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            panel_header1_STI.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            panel_header2_STI.BackColor = ColorTranslator.FromHtml("#FFACAC");
            panel_header3_STI.BackColor = ColorTranslator.FromHtml("#FFACAC");

            btn_save_STI.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_ok_STI.BackColor = ColorTranslator.FromHtml("#FF9090");

            dgv_invoice_STI.Columns[0].Width = 80;
            dgv_invoice_STI.Columns[1].Width = 154;
            dgv_invoice_STI.Columns[2].Width = 263;
            dgv_invoice_STI.Columns[3].Width = 150;
            dgv_invoice_STI.Columns[4].Width = 150;
            dgv_invoice_STI.Columns[5].Width = 175;
            dgv_invoice_STI.RowTemplate.Height = 80;
            dgv_invoice_STI.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_STI.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_STI.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_STI.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_STI.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_STI.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void GrandTotal()
        {
            query = $"SELECT `Sales ID`, REPLACE(`Grand Total`,'.','') FROM vSalesTrans WHERE `Sales ID` = '{GlobalData.salesId}';";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtGrand);
            sqlconnect.Close();

            int a = Convert.ToInt32(dtGrand.Rows[0][1]);
            label_grandtotal_STI.Text = a.ToString("N0").Replace(",",".");
            //MessageBox.Show(label_grandtotal_STI.Text);
        }

        private void panel_transid_STI_Paint(object sender, PaintEventArgs e)
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

        private void SavePanelAsPDF(Panel panel, string fileName)
        {
            try
            {
                // 1. Tangkap isi panel sebagai gambar
                Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
                panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));

                // 2. Pilih lokasi penyimpanan file PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = fileName
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // 3. Buat ukuran kertas kustom (15 cm x 25 cm)
                    iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(708.661f, 425.197f);

                    // 4. Buat dokumen PDF dengan ukuran kustom
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        Document pdfDoc = new Document(pageSize, 20f, 20f, 20f, 20f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // 5. Konversi gambar panel ke iTextSharp Image
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitmap.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image panelImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            panelImage.Alignment = Element.ALIGN_CENTER;

                            // Menyesuaikan ukuran gambar agar sesuai dengan halaman PDF
                            panelImage.ScaleToFit(pageSize.Width - 40f, pageSize.Height - 40f);

                            // 6. Tambahkan gambar ke dokumen PDF
                            pdfDoc.Add(panelImage);
                        }

                        pdfDoc.Close();
                    }

                    MessageBox.Show("PDF berhasil dibuat di: " + filePath, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalesTransaction_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalData.detailinvoice_sales.Clear();
            GlobalData.detailinvoice_sales.Columns.Remove("No.");
        }

        private void btn_save_STI_Click(object sender, EventArgs e)
        {
            SavePanelAsPDF(panel_invoice_STI, "Sales Transaction_Invoice.pdf");
        }

        private void btn_ok_STI_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
