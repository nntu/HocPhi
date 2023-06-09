
using MathNet.Numerics.LinearAlgebra.Factorization;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QRCoder;
using QRNapasLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HocPhi.DataModel;

namespace HocPhi
{
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string datadir = "";
        private string tempfolder;
        private string qrfolder;
 
        private string temp_template_excel;
        List<TienNop> listtiennp;
        private Config _cf;

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
            // If directory doesn't exist create one
            if (!Directory.Exists(tempfolder))
            {
                Directory.CreateDirectory(tempfolder);
            }

            if (!Directory.Exists(qrfolder))
            {
                Directory.CreateDirectory(qrfolder);
            }

            //string databaseName = "data.db3";

            //DatabaseHandler dbh = new DatabaseHandler(Path.Combine(datadir, databaseName));

        }

        private void lb_Template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var timestamp = DateTime.Now.ToFileTime();
            FileInfo fi = new FileInfo(@"template_2023.xlsx");
            temp_template_excel = string.Format("{0}\\template_2023_{1}.xlsx", tempfolder, timestamp);
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
                        if (curRow.GetCell(1) != null)
                        {
                            DataFormatter formatter = new DataFormatter();

                            //Stt	TenTK_Nop	Tai_khoan_nop	ma_hs	Hoten_HocSinh	Lop	LoaiPhi	So_tien


                            var TenTK_Nop = curRow.GetCell(1) == null ? "" : formatter.FormatCellValue(curRow.GetCell(1)).Trim();
                            var Tai_khoan_nop = curRow.GetCell(2) == null ? "" : formatter.FormatCellValue(curRow.GetCell(2)).Trim();
                            var ma_hs = curRow.GetCell(3) == null ? "" : formatter.FormatCellValue(curRow.GetCell(3)).Trim();

                            var Hoten_HocSinh = curRow.GetCell(4) == null ? "" : formatter.FormatCellValue(curRow.GetCell(4)).Trim();

                            var Lop = curRow.GetCell(5) == null ? "" : formatter.FormatCellValue(curRow.GetCell(5)).Trim();

                            var LoaiPhi = curRow.GetCell(6) == null ? "" : formatter.FormatCellValue(curRow.GetCell(6)).Trim();
                            var Sotien_ex = curRow.GetCell(7) == null ? "" : formatter.FormatCellValue(curRow.GetCell(7)).Trim();


                            var sotien = 0;
                            if (Sotien_ex == "")
                            {
                                sotien = 0;
                            }
                            else
                            {
                                sotien = Convert.ToInt32(StringEx.RemoveNonNumeric(Sotien_ex));


                            }
                            var Noi_Dung = curRow.GetCell(9) == null ? "" : formatter.FormatCellValue(curRow.GetCell(9)).Trim();

                            ds.Add(new TienNop()
                            {
                                TenTK_Nop = TenTK_Nop.Trim(),
                                Tai_khoan_nop = Tai_khoan_nop.Trim(),
                                ma_hs = ma_hs,
                                Stt = i,
                                Hoten_HocSinh = Hoten_HocSinh,
                                Lop = Lop,
                                LoaiPhi = LoaiPhi.ToUpper(),
                                So_tien = sotien,
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
                qrfolder = $"{qrfolder}\\{DateTime.Now.ToString("ddMMyyyy_hhmmss")}";

                if (!Directory.Exists(qrfolder))
                {
                    Directory.CreateDirectory(qrfolder);
                }

                await Task.Run(() => CreateQR(progress, ls, qrfolder));

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Visible = false;


         
               

                OpenExplorer(qrfolder);
            }

            

        }

        private void CreateQR(IProgress<int> progress, List<TienNop> ds,string qrfolder) {
            var j = 1;
            foreach (var i in ds)
            {

                var tknhan = i.TenTK_Nop; 
                var hotenhs = StringEx.RemoveVietnameseTone(i.Hoten_HocSinh).ToUpper();
                var noidung = string.Format("{0}_{1}_{2} TTT {3}", i.ma_hs, hotenhs, i.Lop, i.LoaiPhi);
                var vietqr = Generator.Generator_QRNapas("BIDV", tknhan, i.So_tien, noidung);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(vietqr, QRCodeGenerator.ECCLevel.Q);
                Bitmap qrCodeImage;
                ArtQRCode qrCode = new ArtQRCode(qrCodeData);
                qrCodeImage = qrCode.GetGraphic(40, bt_mauQr.BackColor, Color.White, Color.White, (Bitmap)Bitmap.FromFile("logobidv.png"));

                var imagePath_lite = string.Format("{0}\\{1}_{2}_{3}_{4}.png", qrfolder, i.ma_hs, hotenhs, i.Lop, i.LoaiPhi);
                qrCodeImage.Save(imagePath_lite, ImageFormat.Png);



                j++;
            }

        }

        private void bt_mauQr_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bt_mauQr.BackColor = colorDialog1.Color;
            };
        }
    }
}
