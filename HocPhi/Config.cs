using System.Collections.Generic;

namespace HocPhi
{
    public class Config : Config<Config>
    {
        public int so_loai { get; set; }
        public int cot_bat_dau { get; set; }
        public string MauQR { get; set; }
        public int[] CustomColors { get; set; }      

    }
}