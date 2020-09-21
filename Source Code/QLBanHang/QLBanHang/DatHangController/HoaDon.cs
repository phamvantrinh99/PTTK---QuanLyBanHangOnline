using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class HoaDon
    {
        private string MaHoaDon;
        private string MaKhachHang;
        private string KHXacNhan;
        private string MaNVBanHang;
        private int TongTien;
        public HoaDon()
        {

        }
        public HoaDon(string MaHd, string Makh, string xacnhan, string nv, int tongtien)
        {
            MaHoaDon = MaHd;
            MaKhachHang = Makh;
            KHXacNhan = xacnhan;
            MaNVBanHang = nv;
            TongTien = tongtien;
        }
        public string Queryinsert()
        {
            return $"INSERT INTO [dbo].[HOADON] VALUES ('{this.MaHoaDon}','{this.MaKhachHang}','{this.KHXacNhan}', '{this.MaNVBanHang}', '{this.TongTien}')";
        }

        public string queryInsertCTHD(string MaMatHang, int SoLuong, int ThanhTien)
        {
            int d = (int)System.DateTime.Now.DayOfWeek;
            string CT_HOADON = $"CT{d}-{DateTime.Now.ToString("HHmmss")}"; ;
            
            return $"INSERT INTO [dbo].[CT_HOADON] VALUES ('{CT_HOADON}','{this.MaHoaDon}','{MaMatHang}', '{SoLuong}', '{ThanhTien}', '0')";
        }

        public string getMaHoaDon()
        {
            return this.MaHoaDon;
        }

        public int getTongTien()
        {
            return this.TongTien;
        }

        public void taoDonHang()
        {
            HoaDonDB hoadondb = new HoaDonDB();
            hoadondb.themDonHang(this);
        }

        public void taoCTDH(string MaMatHang, int SoLuong, int ThanhTien)
        {
            HoaDonDB hoadondb = new HoaDonDB();
            hoadondb.themCTDH(this.queryInsertCTHD(MaMatHang, SoLuong, ThanhTien));
        }
        
        
    }
}
