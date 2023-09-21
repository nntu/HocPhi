using DevExpress.XtraReports.UI;
using Fluid;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.StyledXmlParser.Css.Media;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using QRCoder;
using QRNapasLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;

namespace HocPhi
{
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string tempfolder;
        private string qrfolder;
        private string fontDir = "fonts";
        private string temp_template_excel;
        private string htmlfolder = "";
        private Config _cf;
        private string KetxuatFilefolder;
        private string thumucpdf;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var tenfile = string.Format("TongHop_{0:dd_MM_yyyy_hhmmss}.pdf", DateTime.Now);
            tb_tenfilepdf.Text = tenfile;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " " + version.ToString();
            _cf = Config.Load();

            // màu xanh bidv
            var xanhbidv = Color.FromArgb(0, 107, 104);
            int i_xanhbidv = (xanhbidv.B << 16) | (xanhbidv.G << 8) | xanhbidv.R;

            //vàng bidv
            var vangbidv = Color.FromArgb(255, 198, 47);
            int i_vangbidv = (vangbidv.B << 16) | (vangbidv.G << 8) | vangbidv.R;

            colorDialog1.CustomColors = new int[] { i_xanhbidv, i_vangbidv };

            //load mau sac da luu truoc do
            bt_mauQr.BackColor = ColorTranslator.FromHtml(_cf.MauQR);

            tempfolder = AppDomain.CurrentDomain.BaseDirectory + "temp";

            KetxuatFilefolder = Directory.GetCurrentDirectory() + @"\ketxuat";

            // If directory doesn't exist create one
            if (!Directory.Exists(tempfolder))
            {
                Directory.CreateDirectory(tempfolder);
            }
            if (!Directory.Exists(KetxuatFilefolder))
            {
                Directory.CreateDirectory(KetxuatFilefolder);
            }

            TemplateOptions.Default.MemberAccessStrategy = new UnsafeMemberAccessStrategy();
            winFormHtmlEditor1.ToolbarItemOverrider.SaveButtonClicked += ToolbarItemOverrider_SaveButtonClicked;
        }

        private void ToolbarItemOverrider_SaveButtonClicked(object sender, EventArgs e)
        {
            var html = winFormHtmlEditor1.BodyHtml;
            var filehtml = Directory.GetCurrentDirectory() + @"\Templates\MainReport.html";
            File.WriteAllText(filehtml, html, Encoding.UTF8);
            MessageBox.Show("Đã cập nhật xong mẫu");
        }

        private void lb_Template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var timestamp = DateTime.Now.ToString("ddMMyyyy_hhmmss");
            FileInfo fi = new FileInfo(@"Template_thuhp2023.xlsx");
            temp_template_excel = string.Format("{0}\\Template_thuhp2023_{1}.xlsx", tempfolder, timestamp);
            fi.CopyTo(temp_template_excel, true);
            Process process = new Process();
            process.StartInfo.FileName = temp_template_excel;
            process.Start();
        }

        private async void bt_CreateQR_LoadFile_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;

            toolStripProgressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                toolStripProgressBar1.Value = percent;
            });

            openFileDialog1.FileName = temp_template_excel;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//
             //

                IWorkbook workbook;

                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                workbook = new XSSFWorkbook(fs);

                //First sheet
                ISheet sheet = workbook.GetSheetAt(0);
                toolStripProgressBar1.Maximum = sheet.LastRowNum;
                var res = await Task.Run(() => LoadThongTinExcel(progress, sheet, (int)nud_so_cot_bd.Value, (int)nud_so_loai.Value));

                dataGridView1.DataSource = res;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="sheet"></param>
        /// <param name="So_cot_BD">Số cột bắt đầu</param>
        /// <param name="so_loai">Số loại</param>
        /// <returns></returns>
        private List<TienNop> LoadThongTinExcel(IProgress<int> progress, ISheet sheet, int So_cot_BD, int so_loai)
        {
            try
            {
                List<TienNop> ds = new List<TienNop>();
                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum; // This may not be valid row count.
                                                     // If first row is table head, i starts from 1
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    var phonggd = sheet.GetRow(2).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    var tentruong = sheet.GetRow(3).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    var TenTK_Nop = sheet.GetRow(10).GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    var Tai_khoan_nop = sheet.GetRow(11).GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    var Thong_bao = sheet.GetRow(6).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    var Ky_nop = sheet.GetRow(7).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();

                    for (int i = 13; i <= rowCount; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        // Works for consecutive data. Use continue otherwise
                        if (curRow == null)
                        {
                            // Valid row count
                            rowCount = i - 1;
                            break;
                        }
                        // Get data from the 4th column (4th cell of each row)
                        // curRow.GetCell(1).SetCellType(CellType.String);
                        // curRow.GetCell(1).SetCellType(CellType.String);
                        if (curRow.GetCell(0) != null)
                        {
                            DataFormatter formatter = new DataFormatter();

                            var ma_hs = curRow.GetCell(0) == null ? "" : formatter.FormatCellValue(curRow.GetCell(0)).Trim();
                            var Lop = curRow.GetCell(1) == null ? "" : formatter.FormatCellValue(curRow.GetCell(1)).Trim();
                            var Hoten_HocSinh = curRow.GetCell(2) == null ? "" : formatter.FormatCellValue(curRow.GetCell(2)).Trim();

                            List<LoaiThu> loaithu = new List<LoaiThu>();
                            var noidung = "";
                            var dsmaloai = "";
                            var tongsotien = 0;
                            int aa = 1;
                            for (var ii = So_cot_BD; ii <= so_loai + So_cot_BD - 1; ii++)
                            {
                                var cell = curRow.GetCell(ii, MissingCellPolicy.RETURN_BLANK_AS_NULL);

                                if (cell != null)
                                {
                                    var ma_loai = sheet.GetRow(11).GetCell(ii, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                                    var loai_thu = sheet.GetRow(12).GetCell(ii, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();

                                    var sotien = 0;
                                    // TODO: you can add more cell types capatibility, e. g. formula
                                    switch (cell.CellType)
                                    {
                                        case NPOI.SS.UserModel.CellType.Numeric:
                                            sotien = (int)cell.NumericCellValue;
                                            //dataGridView1[j, i].Value = sh.GetRow(i).GetCell(j).NumericCellValue;

                                            break;

                                        case NPOI.SS.UserModel.CellType.String:
                                            sotien = Convert.ToInt32(cell.StringCellValue);

                                            break;
                                    }

                                    loaithu.Add(new LoaiThu()
                                    {
                                        maloai = ma_loai,
                                        Loai = loai_thu,
                                        So_Tien = sotien
                                    });
                                    if (sotien != 0)
                                    {
                                        noidung = noidung == "" ? loai_thu : noidung + "," + loai_thu;
                                    }
                                    //dsmaloai = dsmaloai == "" ? ma_loai : dsmaloai + "," + ma_loai;
                                    tongsotien = tongsotien + sotien;
                                }
                            }
                            aa++;

                            ds.Add(new TienNop()
                            {
                                TenTK_Nop = TenTK_Nop.Trim(),
                                Tai_khoan_nop = Tai_khoan_nop.Trim(),
                                ma_hs = ma_hs,
                                Stt = i,
                                Hoten_HocSinh = Hoten_HocSinh,
                                Lop = Lop,
                                LoaiThu = loaithu,
                                Tong_So_Tien = tongsotien,
                                NoiDung = noidung,
                                Phong_GD = phonggd,
                                Thong_bao = Thong_bao,
                                Ky_nop = Ky_nop.Trim(),
                                TenTruong = tentruong
                            });
                        }
                        if (progress != null) progress.Report(i);
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex.Message);
                return null;
            }
        }

        public static void OpenExplorer(string dir)
        {
            var result = MessageBox.Show($"Xuất file thành công \n File Lưu tại {dir} \n Bạn Có muốn mở file", @"OpenFile", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = dir,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 1)
            {
                MessageBox.Show("Chưa Nhập Danh sách Tài khoản");
            }
            else
            {
                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel1.Text = "Chuan bị tạo file";
                toolStripProgressBar1.Value = 0;
                var progress = new Progress<int>(percent =>
                {
                    toolStripProgressBar1.Value = percent;
                });

                var ls = (List<TienNop>)dataGridView1.DataSource;
                toolStripProgressBar1.Maximum = ls.Count();

                thumucpdf = $"{KetxuatFilefolder}\\{DateTime.Now:ddMMyyyy_hhmmss}";
                if (!Directory.Exists(thumucpdf))
                {
                    Directory.CreateDirectory(thumucpdf);
                }

                htmlfolder = $"{thumucpdf}\\html";

                if (!Directory.Exists(htmlfolder))
                {
                    Directory.CreateDirectory(htmlfolder);
                }
                qrfolder = $"{htmlfolder}\\Qrcode";

                if (!Directory.Exists(qrfolder))
                {
                    Directory.CreateDirectory(qrfolder);
                }

                await Task.Run(() => CreateQR_v2(progress, ls, KetxuatFilefolder, rb_export1file.Checked, tb_tenfilepdf.Text));

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Visible = false;
                OpenExplorer(KetxuatFilefolder);
            }
        }

        private void CreateQR_v2(IProgress<int> progress, List<TienNop> ds, string ketxuatFilefolder, bool xuat1file, string tenfile)
        {
            List<string> listfile = new List<string>();
            var j = 1;
            foreach (var i in ds)
            {
                toolStripStatusLabel1.Text = i.Hoten_HocSinh;
                // lấy thông tin học sinh
                var hotenhs = StringEx.RemoveVietnameseTone(i.Hoten_HocSinh).ToUpper();
                var file_pdf = string.Format("{0}_{1}_{2}_{3}.pdf", i.ma_hs, hotenhs, i.Lop, DateTime.Now.ToString("ddMMyyyy_hhmmss"));
                var noidung_full = StringEx.RemoveVietnameseTone(string.Format("{0}00 {2} {3} TT {4}", i.ma_hs, i.dsmaloai, i.Lop, hotenhs, i.NoiDung)).ToUpper();

                if (noidung_full.Length >= 160)
                {
                    noidung_full = noidung_full.Substring(0, 160);
                }
                var vietqr_full = Generator.Generator_QRNapas("BIDV", i.Tai_khoan_nop, i.Tong_So_Tien, noidung_full);

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr_full, QRCodeGenerator.ECCLevel.Q);
                Bitmap qrCodeImage;
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));

                var widthEmus = (int)(qrCodeImage.Width * 650);
                var heightEmus = (int)(qrCodeImage.Height * 650);

                var imagePath_full = $@"{qrfolder}\{ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper()}";
                qrCodeImage.Save(imagePath_full, ImageFormat.Png);

                // load tempalte
                var fileName = "templates\\MainReport.html";
                var data = File.ReadAllText(fileName);

                var parser = new FluidParser();
                var context = new Fluid.TemplateContext();

                // lay thong tin tiên nop
                context.SetValue("tienNop", i);

                //thong tin qrcode full

                context.SetValue("qrcode_full", "qrcode/" + Path.GetFileName(imagePath_full));

                List<QRTieuMuc> qrtieumuc = new List<QRTieuMuc>();

                var a = 1;
                foreach (var j2 in i.LoaiThu)
                {
                    var tknhan = i.Tai_khoan_nop;
                    string noidung = StringEx.RemoveVietnameseTone(string.Format("{0}{1} {2} {3} TT {4}", i.ma_hs, j2.maloai, i.Lop, hotenhs, j2.Loai)).ToUpper();
                    var vietqr = Generator.Generator_QRNapas("BIDV", tknhan, j2.So_Tien, noidung);
                    qrGenerator = new QRCodeGenerator();
                    qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                    qrCode = new QRCode(qrCodeData);
                    qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));
                    string imagePath_lite = $@"{qrfolder}\{ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, j2.Loai))).ToUpper()}";

                    qrCodeImage.Save(imagePath_lite, ImageFormat.Png);
                    qrtieumuc.Add(new QRTieuMuc()
                    {
                        STT = a,
                        Muc = j2.Loai,
                        sotien = j2.So_Tien,
                        QRcode = "qrcode/" + Path.GetFileName(imagePath_lite),
                    });

                    a++;
                }
                context.SetValue("tieumuc", qrtieumuc);

                var template = parser.Parse(data);

                var result = template.Render(context);
                string html_scr = $@"{htmlfolder}\{ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.html", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper()}";

                using (var sw = new StreamWriter(File.Open(html_scr, FileMode.OpenOrCreate), Encoding.UTF8)) // UTF-8 encoding
                {
                    sw.WriteLine(result);
                }

                string[] listfontfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\" + fontDir, "*.*");

                using (FileStream pdfDest = File.Open(thumucpdf + "\\" + file_pdf, FileMode.Create))
                {
                    ConverterProperties converterProperties = new ConverterProperties();
                    FontProvider fontProvider = new FontProvider("Roboto");
                    MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
                    converterProperties.SetMediaDeviceDescription(mediaDeviceDescription);

                    foreach (var fontfile in listfontfiles)
                    {
                        fontProvider.AddFont(fontfile);
                    }
                    converterProperties.SetBaseUri(htmlfolder);
                    converterProperties.SetFontProvider(fontProvider);
                    HtmlConverter.ConvertToPdf(result, pdfDest, converterProperties);
                }
                listfile.Add(thumucpdf + "\\" + file_pdf);

                Thread.Sleep(1);
                if (progress != null)
                    progress.Report(j); j++;
            }

            if (xuat1file)
            {
                toolStripStatusLabel1.Text = "Chuẩn bị nhập file:";
                PdfDocument pdf = new PdfDocument(new PdfWriter(thumucpdf + "\\" + tenfile));
                PdfMerger merger = new PdfMerger(pdf);
                j = 1;
                foreach (var i in listfile)
                {
                    PdfDocument firstSourcePdf = new PdfDocument(new PdfReader(i));
                    merger.Merge(firstSourcePdf, 1, firstSourcePdf.GetNumberOfPages());
                    firstSourcePdf.Close();
                    Thread.Sleep(1);
                    if (progress != null)
                        progress.Report(j); j++;
                }
                iText.Layout.Document doc = new iText.Layout.Document(pdf);
                int numberOfPages = pdf.GetNumberOfPages();

                for (int i = 1; i <= numberOfPages; i++)
                {
                    PdfPage page = pdf.GetPage(i);
                    var pageSize = page.GetPageSize();
                    float pageX = pageSize.GetRight() - doc.GetRightMargin() - 40;
                    float pageY = pageSize.GetBottom() + 30;
                    // Write aligned text to the specified by parameters point
                    doc.ShowTextAligned(new Paragraph("Trang " + i + " / " + numberOfPages),
                            pageX, pageY, i, iText.Layout.Properties.TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                }

                pdf.Close();
            }
        }

        //        private void CreateQR(IProgress<int> progress, List<TienNop> ds, string ketxuatFilefolder, bool xuat1file, string tenfile)
        //{
        //    List<string> listfile = new List<string>();
        //    var j = 1;
        //    foreach (var i in ds)
        //    {
        //        // lấy thông tin học sinh
        //        var hotenhs = StringEx.RemoveVietnameseTone(i.Hoten_HocSinh).ToUpper();
        //        var file_pdf = string.Format("{0}_{1}_{2}_{3}.pdf", i.ma_hs, hotenhs, i.Lop, DateTime.Now.ToString("ddMMyyyy_hhmmss"));
        //        var noidung_full = StringEx.RemoveVietnameseTone(string.Format("{0}00 {2} {3} TT {4}", i.ma_hs, i.dsmaloai, i.Lop, hotenhs, i.NoiDung)).ToUpper();

        //        var vietqr_full = Generator.Generator_QRNapas("BIDV", i.Tai_khoan_nop, i.Tong_So_Tien, noidung_full);

        //        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //        QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr_full, QRCodeGenerator.ECCLevel.Q);
        //        Bitmap qrCodeImage;
        //        QRCode qrCode = new QRCode(qrCodeData);
        //        qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));

        //        var widthEmus = (int)(qrCodeImage.Width * 650);
        //        var heightEmus = (int)(qrCodeImage.Height * 650);

        //        var imagePath_full = KetxuatFilefolder + "\\qrcode\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper();
        //        qrCodeImage.Save(imagePath_full, ImageFormat.Png);

        //        // load tempalte
        //        var fileName = "templates\\MainReport.tpl";
        //        var data = File.ReadAllText(fileName);

        //        var parser = new FluidParser();
        //        var context = new Fluid.TemplateContext();

        //        // lay thong tin tiên nop
        //        context.SetValue("tienNop", i);

        //        //thong tin qrcode full
        //        var bytes = File.ReadAllBytes(imagePath_full);
        //        var b64String = Convert.ToBase64String(bytes);
        //        var dataUrl = "data:image/png;base64," + b64String;
        //        context.SetValue("qrcode_full", dataUrl);

        //        List<QRTieuMuc> qrtieumuc = new List<QRTieuMuc>();

        //        var a = 1;
        //        foreach (var j2 in i.LoaiThu)
        //        {
        //            var tknhan = i.Tai_khoan_nop;
        //            string noidung = StringEx.RemoveVietnameseTone(string.Format("{0}{1} {2} {3} TT {4}", i.ma_hs, j2.maloai, i.Lop, hotenhs, j2.Loai)).ToUpper();
        //            var vietqr = Generator.Generator_QRNapas("BIDV", tknhan, j2.So_Tien, noidung);
        //            qrGenerator = new QRCodeGenerator();
        //            qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
        //            qrCode = new QRCode(qrCodeData);
        //            qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));
        //            string imagePath_lite = $@"{KetxuatFilefolder}\qrcode\{ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, j2.Loai))).ToUpper()}";
        //            qrCodeImage.Save(imagePath_lite, ImageFormat.Png);
        //            qrtieumuc.Add(new QRTieuMuc()
        //            {
        //                STT = a,
        //                Muc = j2.Loai,
        //                sotien = j2.So_Tien,
        //                QRcode = "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes(imagePath_lite)),
        //            });

        //            a++;
        //        }
        //        context.SetValue("tieumuc", qrtieumuc);

        //        var template = parser.Parse(data);

        //        var result = template.Render(context);
        //        string html_scr = $@"{KetxuatFilefolder}\html\{ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.html", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper()}";

        //        using (var sw = new StreamWriter(File.Open(html_scr, FileMode.OpenOrCreate), Encoding.UTF8)) // UTF-8 encoding
        //        {
        //            sw.WriteLine(result);
        //        }

        //        string[] listfontfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\" + fontDir, "*.*");

        //        using (FileStream pdfDest = File.Open(KetxuatFilefolder + "\\" + file_pdf, FileMode.Create))
        //        {
        //            ConverterProperties converterProperties = new ConverterProperties();
        //            FontProvider fontProvider = new FontProvider("Roboto");
        //            MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
        //            converterProperties.SetMediaDeviceDescription(mediaDeviceDescription);

        //            foreach (var fontfile in listfontfiles)
        //            {
        //                fontProvider.AddFont(fontfile);
        //            }

        //            converterProperties.SetFontProvider(fontProvider);
        //            HtmlConverter.ConvertToPdf(result, pdfDest, converterProperties);
        //        }
        //        listfile.Add(KetxuatFilefolder + "\\" + file_pdf);
        //        toolStripStatusLabel1.Text = i.Hoten_HocSinh;
        //        Thread.Sleep(1);
        //        if (progress != null)
        //            progress.Report(j); j++;
        //    }

        //    if (xuat1file)
        //    {
        //        toolStripStatusLabel1.Text = "Chuẩn bị nhập file:";
        //        PdfDocument pdf = new PdfDocument(new PdfWriter(KetxuatFilefolder + "\\" + tenfile));
        //        PdfMerger merger = new PdfMerger(pdf);
        //        j = 1;
        //        foreach (var i in listfile)
        //        {
        //            PdfDocument firstSourcePdf = new PdfDocument(new PdfReader(i));
        //            merger.Merge(firstSourcePdf, 1, firstSourcePdf.GetNumberOfPages());
        //            firstSourcePdf.Close();
        //            Thread.Sleep(1);
        //            if (progress != null)
        //                progress.Report(j); j++;
        //        }
        //                iText.Layout.Document doc = new iText.Layout.Document(pdf);
        //        int numberOfPages = pdf.GetNumberOfPages();

        //        for (int i = 1; i <= numberOfPages; i++)
        //        {
        //            PdfPage page = pdf.GetPage(i);
        //            var pageSize = page.GetPageSize();
        //            float pageX = pageSize.GetRight() - doc.GetRightMargin() - 40;
        //            float pageY = pageSize.GetBottom() + 30;
        //            // Write aligned text to the specified by parameters point
        //            doc.ShowTextAligned(new Paragraph("Trang " + i + " / " + numberOfPages),
        //                    pageX, pageY, i, iText.Layout.Properties.TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
        //        }

        //        pdf.Close();

        //    }

        //}

        public string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        private void bt_mauQr_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bt_mauQr.BackColor = colorDialog1.Color;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void rb_ExportALLfile_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    // Only one radio button will be checked
                    groupBox4.Enabled = false;
                }
            }
        }

        private void rb_export1file_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    // Only one radio button will be checked
                    groupBox4.Enabled = true;
                    var tenfile = string.Format("TongHop_{0:dd_MM_yyyy_hhmmss}.pdf", DateTime.Now);
                    tb_tenfilepdf.Text = tenfile;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var ls = (List<TienNop>)dataGridView1.DataSource;
            TaoBanIn taoBanIn = new TaoBanIn();
            taoBanIn.DataSource = ls;
            taoBanIn.CreateDocument();
            taoBanIn.ShowPreviewDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tb_edittemplates_Enter(object sender, EventArgs e)
        {
            var html = Directory.GetCurrentDirectory() + @"\Templates\MainReport.html";
            string text = System.IO.File.ReadAllText(html);
            winFormHtmlEditor1.BodyHtml = text;
        }
    }
}