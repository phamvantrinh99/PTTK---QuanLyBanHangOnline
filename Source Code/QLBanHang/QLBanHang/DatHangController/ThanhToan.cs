using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class ThanhToan
    {
        public ThanhToan()
        {

        }

        public ThanhToan(string matt, string mahd, string thuquy, string loaitt, string khxt, string the, string xacthuc, string tt)
        {
            this.MaThanhToan = matt;
            this.MaHoaDon = mahd;
            this.ThuQuy = thuquy;
            this.LoaiThanhToan = loaitt;
            this.KHXacThuc = khxt;
            this.ThongTinThe = the;
            this.ThuQuyXacThuc = xacthuc;
            this.TinhTrangThanhToan = tt;

        }

        private string MaThanhToan;
        private string MaHoaDon;
        private string ThuQuy;
        private string LoaiThanhToan;
        private string KHXacThuc;
        private string ThongTinThe;
        private string ThuQuyXacThuc;
        private string TinhTrangThanhToan;

        public string queryInsert()
        {
            return $"INSERT INTO [dbo].[THANHTOAN] VALUES ('{this.MaThanhToan}','{this.MaHoaDon}','{this.ThuQuy}', '{this.LoaiThanhToan}','{this.KHXacThuc}','{this.ThongTinThe}','{this.ThuQuyXacThuc}','{this.TinhTrangThanhToan}')";
        }

        public void themthongtinthanhtoan()
        {
            ThanhToanDB ttdb = new ThanhToanDB();
            ttdb.taothanhtoan(this.queryInsert());
        }


    }
}
