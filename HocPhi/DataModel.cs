namespace HocPhi
{
    public class DataModel
    {
        public class LoaiChi
        {

            public string Loai { get; set; }
            public string Chu_Thich { get; set; }
        }


        public class TienNop
        {
            public int Stt { get; set; }
            public string TenTK_Nop { get; set; }
            public string Tai_khoan_nop { get; set; }
            public string ma_hs { get; set; }
            public string Hoten_HocSinh { get; set; }
            public string Lop { get; set; }


            public string Loai_Thu { get; set; }
            public int So_Tien { get; set; }

        }


    }
}
