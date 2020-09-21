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
    public partial class KTHopDongQC_Form : Form
    {
        public KTHopDongQC_Form()
        {
            InitializeComponent();
        }
        Controller.DoiTacQuangCao DTQCControl = new Controller.DoiTacQuangCao();
        private void bt_XemHD_Click(object sender, EventArgs e)
        {
            if (cb_HDHetHan.Checked == false)
            {
                dtgv_DSHD.DataSource = DTQCControl.LayDSDoiTac();
            }
            else
            {
                dtgv_DSHD.DataSource = DTQCControl.LayDSDoiTacHetHan();
            }
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void KTHopDongQC_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bANHANGTRUCTUYENDataSet.DOITACQUANGCAO' table. You can move, or remove it, as needed.
            Provider provider = new Provider();
            provider.getConnect();

            string strCmd = "";
            SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
            provider.Connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            //
            strCmd = " Select MaDTQC from DOITACQUANGCAO";
            cmd = new SqlCommand(strCmd, provider.Connect);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            cbb_MaDoiTac.DataSource = dt;
            cbb_MaDoiTac.DisplayMember = "MaDTQC";
            cbb_MaDoiTac.ValueMember = "MaDTQC";
            cbb_MaDoiTac.Enabled = true;

        }

        private void bt_GiaHanHD_Click(object sender, EventArgs e)
        {
            string MaDT = cbb_MaDoiTac.Text;
            DateTime NgayGiaHan = dtp_NgayGiaHan.Value;
            bool kqgh = DTQCControl.GiaHanHopDong(MaDT, NgayGiaHan);
            if (kqgh == true)
            {
                MessageBox.Show("Gia hạn thành công.");
                this.bt_XemHD_Click(sender, e);
            }
            else MessageBox.Show("Gia hạn thất bại.");
        }
    }
}
