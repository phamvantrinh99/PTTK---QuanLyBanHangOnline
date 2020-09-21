using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBanHang
{
    public partial class DataProvider
    {
        SqlConnection con { get; set; }

        public SqlConnection Connect
        {
            set { con = value; }
            get { return con; }
        }   

        public void getConnect()
        {
            //string datasource = @"DESKTOP-1CCTQEA";
            //string database = "BANHANGTRUCTUYEN";
            //string username = "sa";
            //string password = "123456";

            //string constring = @"Data Source=" + datasource + ";Initial Catalog="
            //           + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=BANHANGTRUCTUYEN;Integrated Security=True";


            try
            {
                if (con == null)
                {
                    con = new SqlConnection(constring);
                }

                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }

                //con.Open();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void disConnect()
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}

