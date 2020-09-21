using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class HoaDonDB
    {
        public HoaDonDB()
        {
        }

        public bool themDonHang(HoaDon hoadon)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(hoadon.Queryinsert(), provider.Connect);
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
        public bool themCTDH(string query)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(query, provider.Connect);
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
