using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class PhieuGiao
    {
        public PhieuGiao()
        {

        }

        public PhieuGiao(string mpg, string mahd, string manv, string diachi)
        {
            this.MaPhieuGiao = mpg;
            this.MaHoaDon = mahd;
            this.MaNVGiaoHang = manv;
            this.DiaChi = diachi;
        }

        public string queryInsert()
        {
            return $"INSERT INTO [dbo].[PHIEUGIAO] VALUES ('{this.MaPhieuGiao}','{this.MaHoaDon}','{this.MaNVGiaoHang}', '{this.DiaChi}')";
        }

        public void themphieugiao()
        {
            PhieuGiaoDB pgdb = new PhieuGiaoDB();
            pgdb.taoDonHang(this);
        }

        private string MaPhieuGiao;
        private string MaHoaDon;
        private string MaNVGiaoHang;
        private string DiaChi;
    }
}
