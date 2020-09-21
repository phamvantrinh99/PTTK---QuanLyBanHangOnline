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
    class DoiTacQuangCaoDB
    {
        public DataTable LayDSDoiTac()
        {
            DataTable dtret = new DataTable();
            Provider provider = new Provider();
            provider.getConnect();
            try
            {
                string sql;
                sql = "SELECT * FROM DOITACQUANGCAO;";

                SqlCommand cmd = new SqlCommand(sql, provider.Connect);
                provider.Connect.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);

                da.Dispose();
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Rỗng, Thử Lại");
                }
                else
                {
                    dtret = dt;//dtgv_DSHD.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.disConnect();
            }
            return dtret;
        }
        public DataTable LayDSDoiTacHetHan()
        {
            DataTable dtret = new DataTable();
            Provider provider = new Provider();
            provider.getConnect();
            try
            {
                string sql;
                sql = "SELECT * FROM DOITACQUANGCAO where ThoiHan <= GETDATE();";

                SqlCommand cmd = new SqlCommand(sql, provider.Connect);
                provider.Connect.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);

                da.Dispose();
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Rỗng, Thử Lại");
                }
                else
                {
                    dtret = dt;//dtgv_DSHD.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.disConnect();
            }
            return dtret;
        }

        public bool UpdateHopDong(String MaDoiTac, DateTime NgayGiaHan)
        {
            Provider provider = new Provider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE DOITACQUANGCAO set ThoiHan ='" + NgayGiaHan + "' where MaDTQC =  '" + MaDoiTac + "'", provider.Connect);

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
