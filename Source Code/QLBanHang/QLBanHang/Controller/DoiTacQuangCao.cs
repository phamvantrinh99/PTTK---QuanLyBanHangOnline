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
    class DoiTacQuangCao
    {
        Database.DoiTacQuangCaoDB DTQCDB = new Database.DoiTacQuangCaoDB();
        public DataTable LayDSDoiTac()
        {
            DataTable dt = new DataTable();
            dt = DTQCDB.LayDSDoiTac();
            return dt;
        }
        public DataTable LayDSDoiTacHetHan()
        {
            DataTable dt = new DataTable();
            dt = DTQCDB.LayDSDoiTacHetHan();
            return dt;
        }
        public bool GiaHanHopDong(String MaDoiTac, DateTime NgayGiaHan)
        {
            bool kqgh = DTQCDB.UpdateHopDong(MaDoiTac, NgayGiaHan);
            return kqgh;
        }
    }
}
