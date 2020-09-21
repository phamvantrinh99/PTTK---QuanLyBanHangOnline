using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLBanHang
{
    class control
    {

        public DataTable tk_comment(Boolean loai)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            String sql;
            if (loai == true)
            {
                sql = "select * from comment where rate >=3";
            }
            else
            {
                sql = "select * from comment where rate <=2";
            }

            SqlCommand cmd = new SqlCommand(sql, provider.Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            da.Dispose();
            provider.Connect.Close();
            return dt;
        }

        public void XoaComment(String Macomment)
        {
            String sql = "DELETE FROM comment WHERE MaComment = '" + Macomment + "'";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xoá");
                provider.Connect.Close();

            }
        }
        public void KhoaComment(String MaKH)
        {
            String sql = "update KHACHHANG set KhoaComment=1 where  MaKhachHang='" + MaKH + "'";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Khoá Thành công");
                provider.Connect.Close();

            }
        }
        public void PhanThuong(String MaKH)
        {
            String sql = "update KHACHHANG set DiemThuong+=1000 where  MaKhachHang='" + MaKH + "'";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thưởng Thành công");
                provider.Connect.Close();
            }
        }

        public DataTable TimCTHocDon(String MaHoaDon)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            String sql = "select * from CT_HOADON where MaHoaDon = '" + MaHoaDon + "'";
            SqlCommand cmd = new SqlCommand(sql, provider.Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            provider.Connect.Close();
            return dt;
        }
        public void KH_TraHang(String MaCTHD)
        {
            String sql = "update CT_HOADON set TT_TraHang = 1 where  MaCTHD='" + MaCTHD + "'";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Trả hàng thành công");
                provider.Connect.Close();
            }
        }
        public DataTable DS_TraHang(String MaPhieuTra)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            String sql = "select * from CT_PHIEUTRA where MaPhieuTra ='" + MaPhieuTra + "'";
            SqlCommand cmd = new SqlCommand(sql, provider.Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            provider.Connect.Close();
            return dt;
        }
        public void insert_phieutra(String MaPhieuTra, String MaHoaDon)
        {
            String sql = "INSERT INTO PHIEUTRA VALUES ('" + MaPhieuTra + "','" + MaHoaDon + "')";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Trả hàng thành công");
                provider.Connect.Close();

            }
        }
        public void insert_CTphieutra(String MaPhieuTra, String MaSP,int soluong,int gia,string lydo)
        {
            int d = (int)System.DateTime.Now.DayOfWeek;
            string maCTPT = $"CT{d}-{DateTime.Now.ToString("HHmmss")}";
            String sql = "INSERT INTO CT_PHIEUTRA VALUES ('"+ maCTPT + "','" + MaPhieuTra + "','" + MaSP + "'," + soluong + "," + gia + ",'" + lydo + "')";
            DataProvider provider = new DataProvider();
            provider.getConnect();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = provider.Connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                provider.Connect.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Trả hàng thành công");
                provider.Connect.Close();

            }
        }
    }
}
