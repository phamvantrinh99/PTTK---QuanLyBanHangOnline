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

namespace QLBanHang
{
    public partial class CT_DonTraHang : Form
    {
        public CT_DonTraHang()
        {
            InitializeComponent();
        }

        private void CT_DonTraHang_Load(object sender, EventArgs e)
        {

        }
        public CT_DonTraHang(string maPT)
        {
            InitializeComponent();
            DataProvider provider = new DataProvider();
            provider.getConnect();
            string strCmd = $"select * from DONTRAHANG where MaDonTraHang = '{maPT}'";
            SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
            provider.Connect.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtMaDonTra.Text = reader["MaDonTraHang"].ToString();
                    txtNgayTra.Text = reader["NgayLap"].ToString();
                    txtNVTra.Text = reader["NguoiLap"].ToString();
                    txtNCC.Text = reader["MaNCC"].ToString();
                    rtbLydoTra.Text = reader["LyDoTra"].ToString();
                }
            }
            try
            {
                cmd = new SqlCommand($"SELECT * FROM CT_DONTRAHANG  WHERE MaDonTraHang = '{maPT}'", provider.Connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin, Thử Lại !");
                }
                else
                {
                    dgvCTDonTra.DataSource = dt;
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
