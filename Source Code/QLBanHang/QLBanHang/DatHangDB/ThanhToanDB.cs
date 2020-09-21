using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class ThanhToanDB
    {
        public ThanhToanDB()
        {

        }

        public bool taothanhtoan(string query)
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
