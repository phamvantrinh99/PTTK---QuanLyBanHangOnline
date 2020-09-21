using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    public partial class PhieuGiaoDB
    {
        public PhieuGiaoDB()
        {
        }

        public bool taoDonHang(PhieuGiao phieuGiao)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(phieuGiao.queryInsert(), provider.Connect);
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
