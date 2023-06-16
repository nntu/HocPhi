using Fluid;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Layout.Font;
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
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
 

namespace HocPhi
{
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        private string tempfolder;
        private string qrfolder;
        private string fontDir = "fonts";
        private string temp_template_excel;
     
        private Config _cf;
        private string KetxuatFilefolder;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            qrfolder = Directory.GetCurrentDirectory() + @"\qrcode";
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
            if (!Directory.Exists(qrfolder))
            {
                Directory.CreateDirectory(qrfolder);
            }

            TemplateOptions.Default.MemberAccessStrategy = new UnsafeMemberAccessStrategy();

        }

        private void lb_Template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var timestamp = DateTime.Now.ToString("ddMMyyyy_hhmmss");
            FileInfo fi = new FileInfo(@"Template_2023.xlsx");
            temp_template_excel = string.Format("{0}\\Template_2023_{1}.xlsx", tempfolder, timestamp);
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
                var res = await Task.Run(() => LoadThongTinExcel(progress, sheet));

                dataGridView1.DataSource = res;
            }
        }
        private List<TienNop> LoadThongTinExcel(IProgress<int> progress, ISheet sheet)
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

                    for (int i = 1; i <= rowCount; i++)
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

                            //Stt	TenTK_Nop	Tai_khoan_nop	ma_hs	Hoten_HocSinh	Lop	LoaiPhi	So_tien
                            var phonggd = curRow.GetCell(0) == null ? "" : formatter.FormatCellValue(curRow.GetCell(0)).Trim();

                            var TenTK_Nop = curRow.GetCell(1) == null ? "" : formatter.FormatCellValue(curRow.GetCell(1)).Trim();
                            var Tai_khoan_nop = curRow.GetCell(2) == null ? "" : formatter.FormatCellValue(curRow.GetCell(2)).Trim();
                            var ma_hs = curRow.GetCell(4) == null ? "" : formatter.FormatCellValue(curRow.GetCell(4)).Trim();

                            var Hoten_HocSinh = curRow.GetCell(6) == null ? "" : formatter.FormatCellValue(curRow.GetCell(6)).Trim();
                            var Lop = curRow.GetCell(5) == null ? "" : formatter.FormatCellValue(curRow.GetCell(5)).Trim();

                            //Loai_thu_1 	So_tien_thu_1	Loai_thu_2	So_tien_thu_2	Loai_thu_3	So_tien_thu_3 	Loai_thu_4	So_tien_thu_4 	Loai_thu_5	So_tien_thu_5 	Loai_thu_6	So_tien_thu_6 	Loai_thu_7	So_tien_thu_7 	Loai_thu_8	So_tien_thu_8	Loai_thu_9	So_tien_thu_9	Loai_thu_10	So_tien_thu_10

                            Dictionary<string, int> loaithu = new Dictionary<string, int>();
                            var tongsotien = 0;
                            var noidung = "";
                            for (var ii = 7; ii <= 25; ii++)
                            {
                                if (ii % 2 != 0)
                                {
                                    if (curRow.GetCell(ii) != null)
                                    {

                                        var loai_thu = formatter.FormatCellValue(curRow.GetCell(ii)).Trim();
                                        if (loai_thu != "")
                                        {
                                            var So_tien_ex = formatter.FormatCellValue(curRow.GetCell(ii + 1)).Trim();
                                            var sotien = 0;
                                            if (So_tien_ex != "") { sotien = Convert.ToInt32(So_tien_ex); }
                                            
                                            loaithu[loai_thu] = sotien;
                                            tongsotien += sotien;
                                            noidung = noidung + "," + loai_thu;


                                        }
                                    }
                                }
                            }
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
                                NoiDung = noidung, Phong_GD = phonggd
                            });
                        }

                        if (progress != null) progress.Report(i);
                    }
                    //   _db.SetThongTinCB(dsttcb);
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


                               


                KetxuatFilefolder = $"{KetxuatFilefolder}\\{DateTime.Now.ToString("ddMMyyyy_hhmmss")}";
                if (!Directory.Exists(KetxuatFilefolder))
                {
                    Directory.CreateDirectory(KetxuatFilefolder);
                }
                qrfolder = $"{KetxuatFilefolder}\\Qrcode";

                if (!Directory.Exists(qrfolder))
                {
                    Directory.CreateDirectory(qrfolder);
                }

                var html = $"{KetxuatFilefolder}\\html";

                if (!Directory.Exists(html))
                {
                    Directory.CreateDirectory(html);
                }



                await Task.Run(() => CreateQR(progress, ls, KetxuatFilefolder));
               

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Visible = false;
                OpenExplorer(KetxuatFilefolder);
            }



        }

        private void CreateQR(Progress<int> progress, List<TienNop> ds, string ketxuatFilefolder)
        {
            var j = 1;
            foreach (var i in ds)
            {
                // lấy thông tin học sinh
                var hotenhs = StringEx.RemoveVietnameseTone(i.Hoten_HocSinh).ToUpper();
                var file_pdf = string.Format("{0}_{1}_{2}_{3}.pdf", i.ma_hs, hotenhs, i.Lop, DateTime.Now.ToString("ddMMyyyy_hhmmss"));
                var noidung_full = StringEx.RemoveVietnameseTone(string.Format("{0} {1} {2} TTT {3}", i.ma_hs, hotenhs, i.Lop, i.NoiDung)).ToUpper();


                var vietqr_full = Generator.Generator_QRNapas("BIDV", i.Tai_khoan_nop, i.Tong_So_Tien, noidung_full);

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr_full, QRCodeGenerator.ECCLevel.Q);
                Bitmap qrCodeImage;
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));

                var widthEmus = (int)(qrCodeImage.Width * 650);
                var heightEmus = (int)(qrCodeImage.Height * 650);

                var imagePath_full = KetxuatFilefolder + "\\qrcode\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper();
                qrCodeImage.Save(imagePath_full, ImageFormat.Png);

                // load tempalte
                var fileName = "templates\\Report.tpl";
                var data = File.ReadAllText(fileName);

                var parser = new FluidParser();
                var context = new Fluid.TemplateContext();
                
                // lay thong tin tiên nop
                context.SetValue("tienNop", i);

                //thong tin qrcode full
                var bytes = File.ReadAllBytes(imagePath_full);
                var b64String = Convert.ToBase64String(bytes);
                var dataUrl = "data:image/png;base64," + b64String;
                context.SetValue("qrcode_full", dataUrl);

                List<QRTieuMuc> qrtieumuc = new List<QRTieuMuc>();

                var a = 1;
                foreach (KeyValuePair<string, int> j2 in i.LoaiThu)
                {

                    

                    var tknhan = i.Tai_khoan_nop;
                    string noidung = StringEx.RemoveVietnameseTone(string.Format("{0} {1} {2} TTT {3}", i.ma_hs, hotenhs, i.Lop, j2.Key)).ToUpper();
                    var vietqr = Generator.Generator_QRNapas("BIDV", tknhan, j2.Value, noidung);
                    qrGenerator = new QRCodeGenerator();
                    qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                    qrCode = new QRCode(qrCodeData);
                    qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));
                    var imagePath_lite = KetxuatFilefolder + "\\qrcode\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, j2.Key))).ToUpper();
                    qrCodeImage.Save(imagePath_lite, ImageFormat.Png);
                    qrtieumuc.Add(new QRTieuMuc() {
                        STT = a,
                    Muc = j2.Key,
                    sotien = j2.Value,
                    QRcode = "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes(imagePath_lite)),

                });
                  
                    a++;
                }
                context.SetValue("tieumuc", qrtieumuc);









                var template = parser.Parse(data);

                var result = template.Render(context);
                var html_scr = KetxuatFilefolder + "\\html\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.html", i.ma_hs, hotenhs, i.Lop, "full"))).ToUpper();

                using (var sw = new StreamWriter(File.Open(html_scr, FileMode.OpenOrCreate), Encoding.UTF8)) // UTF-8 encoding
                {
                    sw.WriteLine(result);
                }




                using (FileStream pdfDest = File.Open(KetxuatFilefolder + "\\" +file_pdf, FileMode.Create))
                {
                    ConverterProperties converterProperties = new ConverterProperties();
                    FontProvider fontProvider = new DefaultFontProvider();

                    fontProvider.AddDirectory(fontDir);

                    converterProperties.SetFontProvider(fontProvider);
                    HtmlConverter.ConvertToPdf(result, pdfDest, converterProperties);
                }


            }
        }

            public string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

       


        private void CreateQR_WordFile(IProgress<int> progress, List<TienNop> ds, string KetxuatFilefolder)
        {
          

            var j = 1;
            foreach (var i in ds)
            {
                // lấy thông tin học sinh
                var hotenhs = StringEx.RemoveVietnameseTone(i.Hoten_HocSinh).ToUpper();
                var filename = string.Format("{0}_{1}_{2}_{3}.docx", i.ma_hs, hotenhs, i.Lop, DateTime.Now.ToString("ddMMyyyy_hhmmss"));
               
                // đọc file mẫu thông báo
                XWPFDocument doc;
                using (Stream fileStream = File.OpenRead("THONG_BAO.docx"))
                {
                    doc = new XWPFDocument(fileStream);
                    fileStream.Close();
                }

                foreach (var para in doc.Paragraphs)
                {
                    para.ReplaceText("{hoten}", i.Hoten_HocSinh);
                    para.ReplaceText("{lop}", i.Lop);
                    para.ReplaceText("{mahs}", i.ma_hs);    
                }

                var noidung_full = StringEx.RemoveVietnameseTone(string.Format("{0} {1} {2} TTT {3}", i.ma_hs, hotenhs, i.Lop, i.NoiDung)).ToUpper();
                                
                //lấy thông tin bảng đầu tiên
                var tb1 = doc.Tables[0];

                var c2 = tb1.GetRow(0).GetCell(1);
                XWPFParagraph p2= c2.AddParagraph();
                XWPFRun r2 = p2.CreateRun();
                r2.SetText(i.Tong_So_Tien.ToString("#,##0"));
               
                c2 = tb1.GetRow(1).GetCell(1);
                p2 = c2.AddParagraph();
                r2 = p2.CreateRun();
                r2.SetText(noidung_full);

                XWPFTableCell c1 = tb1.GetRow(0).GetCell(2);
                XWPFParagraph p1 = c1.AddParagraph();   //don't use doc.CreateParagraph
                XWPFRun r1 = p1.CreateRun();
                var vietqr_full = Generator.Generator_QRNapas("BIDV", i.Tai_khoan_nop, i.Tong_So_Tien, noidung_full);

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr_full, QRCodeGenerator.ECCLevel.Q);
                Bitmap qrCodeImage;
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White,  (Bitmap)Bitmap.FromFile("logobidv.png"));

                var widthEmus = (int)(qrCodeImage.Width * 650);
                var heightEmus = (int)(qrCodeImage.Height * 650);

                var imagePath_full = KetxuatFilefolder + "\\qrcode\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop,"full"))).ToUpper();
                qrCodeImage.Save(imagePath_full, ImageFormat.Png);
                using (FileStream picData = new FileStream(imagePath_full, FileMode.Open, FileAccess.Read))
                {
                    r1.AddPicture(picData, (int)NPOI.SS.UserModel.PictureType.PNG, "image1", widthEmus, heightEmus);
                }

                var tb2 = doc.Tables[1];

                var a = 1;
                foreach (KeyValuePair<string, int> j2 in i.LoaiThu)
                {

                    XWPFTableRow tableRowTwo = tb2.CreateRow();
                    tableRowTwo.GetCell(0).SetText(a.ToString());
                    tableRowTwo.GetCell(1).SetText(j2.Key); 
                    tableRowTwo.GetCell(2).SetText(j2.Value.ToString("#,##0"));

                    var tknhan = i.Tai_khoan_nop;

                    string noidung = StringEx.RemoveVietnameseTone(string.Format("{0} {1} {2} TTT {3}", i.ma_hs, hotenhs, i.Lop, j2.Key)).ToUpper();

                    var vietqr = Generator.Generator_QRNapas("BIDV", tknhan, j2.Value, noidung);

                     qrGenerator = new QRCodeGenerator();
                     qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                    
                     qrCode = new QRCode(qrCodeData);
                    qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White,   (Bitmap)Bitmap.FromFile("logobidv.png"));

                    var imagePath_lite = KetxuatFilefolder + "\\qrcode\\" + ReplaceInvalidChars(StringEx.RemoveVietnameseTone(string.Format("{0}_{1}_{2}_{3}.png", i.ma_hs, hotenhs, i.Lop, j2.Key))).ToUpper();

                    qrCodeImage.Save(imagePath_lite, ImageFormat.Png);
                    var tb3 = tableRowTwo.GetCell(3);
                    p1 = tb3.AddParagraph();   //don't use doc.CreateParagraph
                    r1 = p1.CreateRun();
                    using (FileStream picData = new FileStream(imagePath_lite, FileMode.Open, FileAccess.Read))
                    {
                        r1.AddPicture(picData, (int)NPOI.SS.UserModel.PictureType.PNG, "image1", widthEmus/2, heightEmus/2);
                    }

                    a++;
                }

                using (FileStream fileStreamNew = File.Create(KetxuatFilefolder + "\\"+ filename))
                {
                    doc.Write(fileStreamNew);
                    fileStreamNew.Close();
                }
                toolStripStatusLabel1.Text = i.Hoten_HocSinh;
                Thread.Sleep(1);
                if (progress != null)
                    progress.Report(j); j++;
            }
           
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
    }
}
