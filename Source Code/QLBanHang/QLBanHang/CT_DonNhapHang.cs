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
    public partial class CT_DonNhapHang : Form
    {
        public CT_DonNhapHang()
        {
            InitializeComponent();
        }

        private void CT_DonNhapHang_Load(object sender, EventArgs e)
        {

        }
        public CT_DonNhapHang(string maPN)
        {
            InitializeComponent();
            DataProvider provider = new DataProvider();
            provider.getConnect();
            string strCmd = $"select * from DONNHAPHANG where MaDonNhapHang = '{maPN}'";
            SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
            provider.Connect.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtMaDonNhap.Text = reader["MaDonNhapHang"].ToString();
                    txtNgayNhap.Text = reader["NgayNhap"].ToString();
                    txtNVNhap.Text = reader["NVNhapHang"].ToString();
                    txtNVQuanLy.Text = reader["NVQuanLy"].ToString();
                    txtNCC.Text = reader["MaNCC"].ToString();
                    rtbLydoNhap.Text = reader["LyDoNhap"].ToString();
                }
            }
            try
            {
                cmd = new SqlCommand($"SELECT * FROM CT_DONNHAPHANG  WHERE MaDonNhapHang = '{maPN}'", provider.Connect);
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
                    dgvCTDonNhap.DataSource = dt;
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
    }
}
