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

namespace QLBanHang.Database
{
    class TinQuangCaoDB
    {
        public DataTable LayBaiViet()
        {
            Provider provider = new Provider();
            provider.getConnect();
            DataTable dtre = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAQUANGCAO, MOTA, N.TENNHANVIEN, TENQUANGCAO, H.TENMATHANG FROM TINQUANGCAO T,NHANVIEN N, HANGHOA H  WHERE T.LOAIQUANGCAO = 1 AND T.NVDANGTIN = N.MANHANVIEN AND H.MAMATHANG = T.MAMATHANG; ", provider.Connect);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                
              
                    da.Fill(dt);

                    da.Dispose();
                    dtre = dt;//dtgv_DSbaidang.DataSource = dt;
                

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.disConnect();
            }
            return dtre;
        }
        public bool ThemBaiViet(String MoTa, String NVDangTin, String TenQuangCao, String MaMatHang, String MaDoiTacQuangCao)
        {
            String MaQuangCao = "'QC' + REVERSE(SUBSTRING(REVERSE('00' + CONVERT(varchar(10), Cast(SUBSTRING((SELECT top 1 MaQuangCao from TINQUANGCAO order by MaQuangCao DESC), 3, 3) as int) + 1)), 1, 3))";
            String LoaiQuangCao = "1";
            String KHNhanTin = "NULL";

            Provider provider = new Provider();
            provider.getConnect();
            try
            {
                //string sqlMaQuangCao = "'QC' + REVERSE(SUBSTRING(REVERSE('00' + CONVERT(varchar(10), Cast(SUBSTRING((SELECT top 1 MaQuangCao from TINQUANGCAO order by MaQuangCao DESC), 3, 3) as int) + 1)), 1, 3))";
                SqlCommand cmd = new SqlCommand("INSERT INTO TINQUANGCAO(MaQuangCao,MoTa,NVDangTin,TenQuangCao,MaMatHang, LoaiQuangCao, MaDoiTacQuangCao, KHNhanTin) VALUES(" + MaQuangCao + ",'" + MoTa + "', '" + NVDangTin + "', '" + TenQuangCao + "', '" + MaMatHang + "','" + LoaiQuangCao + "', '" + MaDoiTacQuangCao + "', " + KHNhanTin + ") ", provider.Connect);

                provider.Connect.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                provider.disConnect();
            }
        }
        public DataTable LayTinNhan()
        {
            Provider provider = new Provider();
            provider.getConnect();
            DataTable dtre = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAQUANGCAO, MOTA, N.TENNHANVIEN, TENQUANGCAO, H.TENMATHANG,KH.TenKhachHang  FROM TINQUANGCAO T, NHANVIEN N, HANGHOA H, KHACHHANG KH WHERE T.LOAIQUANGCAO = 2 AND T.NVDANGTIN = N.MANHANVIEN AND H.MAMATHANG = T.MAMATHANG and KH.MaKhachHang = T.KHNhanTin; ", provider.Connect);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                
             
                    da.Fill(dt);

                    da.Dispose();
                    dtre = dt; //dgv_dsTinNhan.DataSource = dt;
                

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.disConnect();
            }
            return dtre;
        }
        public bool ThemTinNhan(String MoTa, String NVDangTin, String TenQuangCao, String MaMatHang, String MaKH)
        {
            String MaQuangCao = "'QC' + REVERSE(SUBSTRING(REVERSE('00' + CONVERT(varchar(10), Cast(SUBSTRING((SELECT top 1 MaQuangCao from TINQUANGCAO order by MaQuangCao DESC), 3, 3) as int) + 1)), 1, 3))";
            String LoaiQuangCao = "2";


            Provider provider = new Provider();
            provider.getConnect();
            try
            {
                //string sqlMaQuangCao = "'QC' + REVERSE(SUBSTRING(REVERSE('00' + CONVERT(varchar(10), Cast(SUBSTRING((SELECT top 1 MaQuangCao from TINQUANGCAO order by MaQuangCao DESC), 3, 3) as int) + 1)), 1, 3))";
                SqlCommand cmd = new SqlCommand("INSERT INTO TINQUANGCAO(MaQuangCao,MoTa,NVDangTin,TenQuangCao,MaMatHang, LoaiQuangCao, MaDoiTacQuangCao, KHNhanTin) VALUES(" + MaQuangCao + ", '" + MoTa + "', '" + NVDangTin + "', '" + TenQuangCao + "', '" + MaMatHang + "', '" + LoaiQuangCao + "', NULL, '" + MaKH + "') ", provider.Connect);

                provider.Connect.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {

                provider.disConnect();
            }
        }
    }
}
