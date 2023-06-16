using System.Collections.Generic;
using System.Windows.Documents;

namespace HocPhi
{
    public class LoaiChi
    {

        public string Loai { get; set; }
        public string Chu_Thich { get; set; }
    }


    public class TienNop
    {

        public int Stt { get; set; }
        public string Phong_GD { get; set; }
        public string TenTK_Nop { get; set; }
        public string Tai_khoan_nop { get; set; }
        public string ma_hs { get; set; }
        public string Hoten_HocSinh { get; set; }
        public string Lop { get; set; }

        public string NoiDung { get; set; }
        public int Tong_So_Tien { get; set; }
        public Dictionary<string, int> LoaiThu { get; set; }
    }

    public class QRTieuMuc
    {
        public int STT { get; set; }
        public string Muc { get; set; }
        public string QRcode { get; set; }
        public int sotien { get; set; }
    }
}
