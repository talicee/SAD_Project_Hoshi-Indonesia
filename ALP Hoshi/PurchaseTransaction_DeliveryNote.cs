using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ALP_Hoshi
{
    public partial class PurchaseTransaction_DeliveryNote : Form
    {
        
        public PurchaseTransaction_DeliveryNote()
        {
            InitializeComponent();
            
        }

        DataTable deliverynote = new DataTable();

        private void PurchaseTransaction_DeliveryNote_Load(object sender, EventArgs e)
        {
            tb_supplier_PTDN.Text = GlobalData.supplierName;
            label_bestregard_PTDN.Text = GlobalData.supplierName;
            tb_dnnumber_PTDN.Text = GlobalData.supplierInvoice;
            tb_address_PTDN.Text = GlobalData.supplierAddress;
            tb_city_PTDN.Text = GlobalData.supplierCity;
            tb_transid_PTDN.Text = GlobalData.purchaseId;
            tb_transdate_PTDN.Text = GlobalData.transactionDate;

            dgv_deliverynote_PTDN.DataSource = GlobalData.detaildeliverynote;
            dgv_deliverynote_PTDN.DataSource = GlobalData.detaildeliverynote;
            dgv_deliverynote_PTDN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Buat warna header (dari sini kebawah udah fix sihh lek isa gausah diganti dah ku coba-coba)
            // tinggal km buat yang PT.... dibawah best regard itu align ke tengah, sama gran total yang jumlah e align ke kanan

            dgv_deliverynote_PTDN.Columns[0].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_deliverynote_PTDN.Columns[1].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_deliverynote_PTDN.Columns[2].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            dgv_deliverynote_PTDN.Columns[3].HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#FFD8D8");

            panel_header1_PTDN.BackColor = ColorTranslator.FromHtml("#FFACAC");
            panel_header2_PTDN.BackColor = ColorTranslator.FromHtml("#FFACAC");
            panel_header3_PTDN.BackColor = ColorTranslator.FromHtml("#FFD8D8");
            btn_save_PTDN.BackColor = ColorTranslator.FromHtml("#FF9090");
            btn_ok_PTDN.BackColor = ColorTranslator.FromHtml("#FF9090");

            dgv_deliverynote_PTDN.Columns[0].Width = 50;
            dgv_deliverynote_PTDN.Columns[1].Width = 272;
            dgv_deliverynote_PTDN.Columns[2].Width = 400;
            dgv_deliverynote_PTDN.Columns[3].Width = 250;
            dgv_deliverynote_PTDN.RowTemplate.Height = 80;
            dgv_deliverynote_PTDN.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_deliverynote_PTDN.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_deliverynote_PTDN.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_deliverynote_PTDN.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void panel_supplier_PTDN_Paint_1(object sender, PaintEventArgs e)
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

        private void btn_save_PTDN_Click(object sender, EventArgs e)
        {
            SavePanelAsPDF(panel_deliverynote_PTDN, "Purchase Transaction_Delivery Note.pdf");
        }

        private void btn_ok_PTDN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseTransaction_DeliveryNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalData.detaildeliverynote.Clear();
            GlobalData.detaildeliverynote.Columns.Remove("No.");
        }

        private void panel_deliverynote_PTDN_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
