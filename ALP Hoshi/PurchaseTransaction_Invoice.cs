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
using MySql.Data.MySqlClient;

namespace ALP_Hoshi
{
    public partial class PurchaseTransaction_Invoice : Form
    {
        
        public PurchaseTransaction_Invoice()
        {
            InitializeComponent();
            
        }

        MySqlDataAdapter sqldataadapter;
        MySqlConnection sqlconnect;
        MySqlCommand sqlcommand;
        string query;

        DataTable dtGrand = new DataTable();

        private void PurchaseTransaction_Invoice_Load(object sender, EventArgs e)
        {
            tb_supplier_PTI.Text = GlobalData.supplierName;
            tb_invoicenumber_PTI.Text = GlobalData.supplierInvoice;
            tb_transdate_PTI.Text = GlobalData.transactionDate;
            tb_transid_PTI.Text = GlobalData.purchaseId;
            label_recipient_PTI.Text = GlobalData.supplierName;

            dgv_invoice_PTI.DataSource = GlobalData.detailinvoice;
            GrandTotal();
            dgv_invoice_PTI.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Buat warna header (dari sini kebawah udah fix sihh lek isa gausah diganti dah ku coba-coba)
            // tinggal km buat yang PT.... dibawah best regard itu align ke tengah, sama gran total yang jumlah e align ke kanan
            dgv_invoice_PTI.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_PTI.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_PTI.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_PTI.Columns[3].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_PTI.Columns[4].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_invoice_PTI.Columns[5].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            panel_header1_PTI.BackColor = ColorTranslator.FromHtml("#FFACAC");
            panel_header2_PTI.BackColor = ColorTranslator.FromHtml("#FFACAC");

            btn_save_PTI.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_ok_PTI.BackColor = ColorTranslator.FromHtml("#FF9090");

            dgv_invoice_PTI.Columns[0].Width = 80;
            dgv_invoice_PTI.Columns[1].Width = 154;
            dgv_invoice_PTI.Columns[2].Width = 263;
            dgv_invoice_PTI.Columns[3].Width = 150;
            dgv_invoice_PTI.Columns[4].Width = 150;
            dgv_invoice_PTI.Columns[5].Width = 175;
            dgv_invoice_PTI.RowTemplate.Height = 80;
            dgv_invoice_PTI.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_PTI.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_PTI.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_PTI.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_PTI.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice_PTI.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void GrandTotal()
        {
            query = $"SELECT `Purchase ID`, `Grand Total` AS \"Total\"\r\nFROM vPurchaseTrans\r\nWHERE `Purchase ID` = '{GlobalData.purchaseId}';";
            sqlconnect = DatabaseConnection.Connection;
            sqlcommand = new MySqlCommand(query, sqlconnect);
            sqldataadapter = new MySqlDataAdapter(sqlcommand);
            sqldataadapter.Fill(dtGrand);
            sqlconnect.Close();

            label_grandtotal_PTI.Text = dtGrand.Rows[0]["Total"].ToString();
        }

        private void panel_supplier_PTI_Paint(object sender, PaintEventArgs e)
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

        private void btn_save_PTI_Click(object sender, EventArgs e)
        {
            SavePanelAsPDF(panel_invoice_PTI, "Purchase Transaction_Invoice.pdf");
        }

        private void btn_ok_PTI_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
