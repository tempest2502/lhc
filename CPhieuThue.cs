using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public enum KieuLoaiPhong { A, B, C, D }
    class CPhieuThue
    {
        public string MaPT { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public string TenKH { get; set; }
        public KieuLoaiPhong LoaiPhong { get; set; }
        public int SoNgayThue { get => (NgayKT - NgayBD).Days + 1; }
        public int TienThue
        {
            get
            {
                int tienthue = 0;
                switch (LoaiPhong)
                {
                    case KieuLoaiPhong.A: tienthue = 250;break;
                    case KieuLoaiPhong.B: tienthue = 400;break;
                    case KieuLoaiPhong.C: tienthue = 600;break;
                    case KieuLoaiPhong.D: tienthue = 900;break;
                }
                return SoNgayThue * tienthue;
            }

        }

        public CPhieuThue(string maPT, DateTime ngayBD, DateTime ngayKT, string tenKH, KieuLoaiPhong loaiPhong)
        {
            MaPT = maPT;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
            TenKH = tenKH;
            LoaiPhong = loaiPhong;
        }

        public CPhieuThue() : this("", DateTime.Today, DateTime.Today, "", KieuLoaiPhong.A)
        {
        }
        public CPhieuThue(CPhieuThue pt) : this(pt.MaPT, pt.NgayBD, pt.NgayKT, pt.TenKH, pt.LoaiPhong)
        {
        }
    }
}
