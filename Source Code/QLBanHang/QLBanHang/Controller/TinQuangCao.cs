using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLBanHang.Controller
{
    class TinQuangCao
    {
        Database.TinQuangCaoDB TinQCCDB = new Database.TinQuangCaoDB();
        public DataTable LayBaiViet()
        {
           
            DataTable dt = new DataTable();
            dt = TinQCCDB.LayBaiViet();
            return dt;
        }

        public DataTable LayTinNhan()
        {
            DataTable dt = new DataTable();
            dt = TinQCCDB.LayTinNhan();
            return dt;
        }


        public bool ThemBaiViet(String MoTa, String NVDangTin, String TenQuangCao, String MaMatHang, String MaDoiTacQuangCao)
        {
            bool kqthembt = TinQCCDB.ThemBaiViet(MoTa, NVDangTin, TenQuangCao, MaMatHang, MaDoiTacQuangCao);
            return kqthembt;
        }
        public bool ThemTinNhan(String MoTa, String NVDangTin, String TenQuangCao, String MaMatHang, String KHNhanTin)
        {
            bool kqthemtn = TinQCCDB.ThemTinNhan(MoTa, NVDangTin, TenQuangCao, MaMatHang, KHNhanTin);
            return kqthemtn;
        }
    }
}
