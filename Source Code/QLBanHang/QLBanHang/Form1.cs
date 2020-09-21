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
    public partial class Form1 : Form
    {
        string maPN = "";
        string maPT = "";

        Controller.TinQuangCao TinQCConTrol = new Controller.TinQuangCao();
        control control = new control();
        public Form1()
        {
            tongsoluong = 0;
            tongtien = 0;
            InitializeComponent();

            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MaNhanVien FROM NHANVIEN", provider.Connect);
                provider.Connect.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                cbMaNV.DataSource = dt;
                cbMaNV.DisplayMember = "MaNhanVien";
                da.Dispose();
                //if (dt.Rows.Count <= 0)
                //{
                //    MessageBox.Show("Không tìm thấy thông tin, Thử Lại !");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.disConnect();
            }
            HienThi();
        }
        private int tongsoluong;
        private int tongtien;

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void btnHienThiSP_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM HANGHOA", provider.Connect);
                provider.Connect.Open();
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
                    dgvHangHoa.DataSource = dt;
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

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            int soluong = 0;
            int dongia = 0;
            List<string> mahanghoa = new List<string>();
            foreach (DataGridViewRow c in dgvHangHoa.Rows)
            {
                try
                {
                    if (c.Cells[0].Value.ToString() == "True")
                    {
                        soluong = Int32.Parse(c.Cells[1].Value.ToString());
                        dongia = Int32.Parse(c.Cells[5].Value.ToString());
                        this.tongsoluong += soluong;
                        this.tongtien += soluong * dongia;
                        mahanghoa.Add(c.Cells[2].Value.ToString() + ","+ soluong + "," + soluong * dongia);
                    }
                }
                catch
                {

                }
                
            }
            int d = (int)System.DateTime.Now.DayOfWeek;
            string madonhang = $"DH{d}-{DateTime.Now.ToString("HHmmss")}";
            string maphieugiao = $"PG{d}-{DateTime.Now.ToString("HHmmss")}";
            HoaDon hoadon = new HoaDon(madonhang, txtMaKH.Text,"Xac Nhan",cbMaNV.Text, this.tongtien);
            PhieuGiao phieugiao = new PhieuGiao(maphieugiao, madonhang, cbMaNV.Text, txtDiaChi.Text);
            
            XacNhan xacnhan = new XacNhan(hoadon, phieugiao, this.tongsoluong, txtMaKH.Text, mahanghoa);
            xacnhan.Owner = this;
            xacnhan.Show();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1trung.Rows[e.RowIndex];
            textBox1trung.Text = row.Cells[2].Value.ToString();
            textBox2trung.Text = row.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2trung.Rows[e.RowIndex];
            textBox1trung.Text = row.Cells[2].Value.ToString();
            textBox2trung.Text = row.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2trung.Text == "")
            {
                MessageBox.Show("Hãy chọn Comment cần xoá");
            }
            else
            {
                control.XoaComment(textBox2trung.Text);
                dataGridView1trung.DataSource = control.tk_comment(true);
                dataGridView2trung.DataSource = control.tk_comment(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1trung.Text == "")
            {
                MessageBox.Show("Hãy chọn Người cần khoá comment");
            }
            else
            {
                control.KhoaComment(textBox1trung.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1trung.Text == "")
            {
                MessageBox.Show("Hãy chọn Người cần khoá comment");
            }
            else
            {
                control.PhanThuong(textBox1trung.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox4trung.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Mã hoá đơn");
            }
            else
            {
                DataProvider provider = new DataProvider();
                provider.getConnect();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUTRA WHERE MaHoaDon='"+ textBox4trung.Text+ "'", provider.Connect);
                    provider.Connect.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    da.Dispose();
                    if (dt.Rows.Count <= 0)
                    {
                        label12.Text = "0";
                        dataGridView2.DataSource = null;
                        int d = (int)System.DateTime.Now.DayOfWeek;
                        string maPT = $"PT{d}-{DateTime.Now.ToString("HHmmss")}";
                        label10.Text = maPT;
                    }
                    else
                    {
                        label12.Text = "1";
                        label10.Text = dt.Rows[0]["MaPhieuTra"].ToString().Trim();
                        dataGridView2.DataSource = control.DS_TraHang(dt.Rows[0]["MaPhieuTra"].ToString().Trim());
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
                dataGridView3trung.DataSource = control.TimCTHocDon(textBox4trung.Text);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView3trung.Rows[e.RowIndex];
            int dongia = Int32.Parse(row.Cells[4].Value.ToString()) / Int32.Parse(row.Cells[3].Value.ToString());
            KHtrahang form = new KHtrahang(textBox4trung.Text, row.Cells[2].Value.ToString() , dongia,label10.Text,label12.Text);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1trung.DataSource = control.tk_comment(true);
            dataGridView2trung.DataSource = control.tk_comment(false);
            //dataGridView1.DataSource;
            dtgv_DSBaiViet.DataSource = TinQCConTrol.LayBaiViet();
            dgv_dsTinNhan.DataSource = TinQCConTrol.LayTinNhan();
        }
        public void HienThi()
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();

            // Hien thi ma mat hang trong combobox
            string strCmd = "select MaMatHang from HANGHOA";
            SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);

            provider.Connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbHangHoa.DataSource = dt;
            cbHangHoa.DisplayMember = "MaMatHang";
            cbHangHoa.ValueMember = "MaMatHang";
            cbHangHoa.Enabled = true;
            cmd.ExecuteNonQuery();
            // Hien thi ma nhan vien
            strCmd = " Select MaNhanVien from NHANVIEN where ChucVu = 'BAN HANG'";
            cmd = new SqlCommand(strCmd, provider.Connect);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            cbNhanVienNhap.DataSource = dt;
            cbNhanVienNhap.DisplayMember = "MaNhanVien";
            cbNhanVienNhap.ValueMember = "MaNhanVien";
            cbNhanVienNhap.Enabled = true;

            cbNhanVienTra.DataSource = dt;
            cbNhanVienTra.DisplayMember = "MaNhanVien";
            cbNhanVienTra.ValueMember = "MaNhanVien";
            cbNhanVienTra.Enabled = true;
            cmd.ExecuteNonQuery();

            // Hien thi NCC
            strCmd = " Select MaNCC from NHACUNGCAP";
            cmd = new SqlCommand(strCmd, provider.Connect);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            cbNCCNhap.DataSource = dt;
            cbNCCNhap.DisplayMember = "MaNCC";
            cbNCCNhap.ValueMember = "MaNCC";
            cbNCCNhap.Enabled = true;

            cbNCCTra.DataSource = dt;
            cbNCCTra.DisplayMember = "MaNCC";
            cbNCCTra.ValueMember = "MaNCC";
            cbNCCTra.Enabled = true;
            cmd.ExecuteNonQuery();

            // Hien thi hang hoa
            strCmd = " Select MaMatHang, TenMatHang from HANGHOA";
            cmd = new SqlCommand(strCmd, provider.Connect);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("Số Lượng", typeof(int));

            dgvHangHoaNhap.DataSource = dt;
            dgvHangHoaTra.DataSource = dt;

            provider.disConnect();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            

        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            // Tao Ma Don nhap hang
            string timenow = DateTime.Now.ToString();
            timenow = timenow.Replace(" ", "");
            timenow = timenow.Replace("/", "");
            timenow = timenow.Replace(":", "");

            lbMaPhieuNhap.Text = "PN" + timenow;

            // So luong hang nhap

            int SoLuong = 0;
            for (int i = 0; i < dgvHangHoaNhap.RowCount - 1; i++)
            {
                if (dgvHangHoaNhap.Rows[i].Cells["Số Lượng"].Value.ToString() != "")
                    SoLuong += Int32.Parse(dgvHangHoaNhap.Rows[i].Cells["Số Lượng"].Value.ToString());
            }
            // Xu li Tao don nhap hang
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {

                string strCmd = $"insert into DONNHAPHANG values ('{lbMaPhieuNhap.Text}','{dtpNgayLapNhap.Value.ToString()}','{rtbLyDoNhap.Text}','{cbNhanVienNhap.Text}','{cbNhanVienNhap.Text}','{cbNCCNhap.Text}',{SoLuong})";
                SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
                provider.Connect.Open();
                cmd.ExecuteNonQuery();

                // Tao CT_DONNHAPHANG
                string MaCT = "";
                string MaMatHang = "";
                int SL = 0;
                for (int i = 0; i < dgvHangHoaNhap.RowCount - 1; i++)
                {
                    if (dgvHangHoaNhap.Rows[i].Cells["Số Lượng"].Value.ToString() != "")
                    {
                        MaCT = DateTime.Now.ToString();
                        MaCT = MaCT.Replace(" ", "");
                        MaCT = MaCT.Replace("/", "");
                        MaCT = MaCT.Replace(":", "");
                        MaCT = "CTPN" + MaCT + i.ToString();

                        MaMatHang = dgvHangHoaNhap.Rows[i].Cells["MaMatHang"].Value.ToString();
                        SL = Int32.Parse(dgvHangHoaNhap.Rows[i].Cells["Số Lượng"].Value.ToString());
                        // MessageBox.Show(MaCT);
                        string strCmd2 = $"insert into CT_DONNHAPHANG values ('{MaCT}','{MaMatHang}',{SL},'{lbMaPhieuNhap.Text}')";
                        SqlCommand cmd2 = new SqlCommand(strCmd2, provider.Connect);
                        cmd2.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Tạo Phiếu nhập thành công");

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

        private void button4_Click_4(object sender, EventArgs e)
        {
            
        }
        private void bt_KThopDong_Click(object sender, EventArgs e)
        {
            //this.Close();
            KTHopDongQC_Form kthd = new KTHopDongQC_Form();
            kthd.Show();
        }

        private void bt_ThemBV_Click(object sender, EventArgs e)
        {
            ThemBaiViet_Form thembv = new ThemBaiViet_Form();
            thembv.Show();
        }

        private void bt_ThemTinNhan_Click(object sender, EventArgs e)
        {
            ThemTinNhan themtn = new ThemTinNhan();
            themtn.Show();
        }
        private void btnShowPhieuTra_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                string strCmd = "select * from DONTRAHANG";
                SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
                provider.Connect.Open();
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
                    dgvDonTraHang.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.Connect.Close();
            }
        }

        private void button11712841_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe1712841_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();

            string MaMatHang = "";
            string TenMatHang = "";
            int SLBan = 0;
            int SLTra = 0;
            int SLTon = 0;
            string strCmd = $"select MaMatHang, TenMatHang, SoLuongTon from HANGHOA where MaMatHang = '{cbHangHoa.Text}'";
            SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
            provider.Connect.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MaMatHang = reader["MaMatHang"].ToString();
                    TenMatHang = reader["TenMatHang"].ToString();
                    SLTon = Int32.Parse(reader["SoLuongTon"].ToString());
                }
            }

            string strCmd2 = $"select sum(SoLuong) as Tong from  CT_HOADON  where  MaMatHang = '{cbHangHoa.Text}'";
            cmd = new SqlCommand(strCmd2, provider.Connect);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader["Tong"].ToString() != "")
                        SLBan = Int32.Parse(reader["Tong"].ToString());
                    else SLBan = 0;
                }
            }

            string strCmd3 = $"select sum(SoLuongTra) as Tong from CT_PHIEUTRA where MaMatHang = '{cbHangHoa.Text}'";
            cmd = new SqlCommand(strCmd3, provider.Connect);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader["Tong"].ToString() != "")
                        SLTra = Int32.Parse(reader["Tong"].ToString());
                    else SLTra = 0;
                }
            }
            provider.disConnect();

            dgvThongKe1712841.ColumnCount = 5;
            dgvThongKe1712841.Columns[0].Name = "Mã Mặt Hàng";
            dgvThongKe1712841.Columns[1].Name = "Tên Mặt Hàng";
            dgvThongKe1712841.Columns[2].Name = "Số Lượng Bán";
            dgvThongKe1712841.Columns[3].Name = "Số Lượng Trả";
            dgvThongKe1712841.Columns[4].Name = "Số Lượng Tồn";

            string[] row0 = { MaMatHang, TenMatHang, SLBan.ToString(), SLTra.ToString(), SLTon.ToString() };

            // assign data for data grid view
            dgvThongKe1712841.Rows[0].Cells["Mã Mặt Hàng"].Value = MaMatHang;
            dgvThongKe1712841.Rows[0].Cells["Tên Mặt Hàng"].Value = TenMatHang;
            dgvThongKe1712841.Rows[0].Cells["Số Lượng Bán"].Value = SLBan.ToString();
            dgvThongKe1712841.Rows[0].Cells["Số Lượng Trả"].Value = SLTra.ToString();
            dgvThongKe1712841.Rows[0].Cells["Số Lượng Tồn"].Value = SLTon.ToString();

           // dgvThongKe1712841.Rows.Add(row0);
        }

        private void btnShowPhieuNhap_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {
                string strCmd = "select * from DONNHAPHANG";
                SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
                provider.Connect.Open();
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
                    dgvDonNhapHang.DataSource = dt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.Connect.Close();
            }
        }

        private void btnThemPhieuTra_Click(object sender, EventArgs e)
        {
            // Tao Ma Don tra hang
            string timenow = DateTime.Now.ToString();
            timenow = timenow.Replace(" ", "");
            timenow = timenow.Replace("/", "");
            timenow = timenow.Replace(":", "");

            lbMaPhieuTra.Text = "PT" + timenow;

            // Xu li Tao don nhap hang
            DataProvider provider = new DataProvider();
            provider.getConnect();
            try
            {

                string strCmd = $"insert into DONTRAHANG values ('{lbMaPhieuTra.Text}','{dtpNgayLapTra.Value.ToString()}','{cbNhanVienTra.Text}','{cbNCCTra.Text}','{rtbLyDoTra.Text}')";


                SqlCommand cmd = new SqlCommand(strCmd, provider.Connect);
                provider.Connect.Open();
                cmd.ExecuteNonQuery();

                // Tao CT_DONTRAHANG
                string MaCT = "";
                string MaMatHang = "";
                int SL = 0;
                for (int i = 0; i < dgvHangHoaNhap.RowCount - 1; i++)
                {
                    if (dgvHangHoaNhap.Rows[i].Cells["Số Lượng"].Value.ToString() != "")
                    {
                        MaCT = DateTime.Now.ToString();
                        MaCT = MaCT.Replace(" ", "");
                        MaCT = MaCT.Replace("/", "");
                        MaCT = MaCT.Replace(":", "");
                        MaCT = "CTPT" + MaCT + i.ToString();

                        MaMatHang = dgvHangHoaTra.Rows[i].Cells["MaMatHang"].Value.ToString();
                        SL = Int32.Parse(dgvHangHoaTra.Rows[i].Cells["Số Lượng"].Value.ToString());
                        // MessageBox.Show(MaCT);
                        string strCmd2 = $"insert into CT_DONTRAHANG values ('{MaCT}','{lbMaPhieuTra.Text}','{MaMatHang}',{SL})";
                        SqlCommand cmd2 = new SqlCommand(strCmd2, provider.Connect);
                        cmd2.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Tạo Phiếu trả thành công");

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                provider.Connect.Close();
            }
        }

        private void refresh_bt_Click(object sender, EventArgs e)
        {
            dtgv_DSBaiViet.DataSource = TinQCConTrol.LayBaiViet();
        }

        private void refresh_2_Click(object sender, EventArgs e)
        {
            dgv_dsTinNhan.DataSource = TinQCConTrol.LayTinNhan();
        }

        private void dgvDonNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maPN = dgvDonNhapHang.Rows[e.RowIndex].Cells["MaDonNhapHang"].Value.ToString();
            CT_DonNhapHang chitiet = new CT_DonNhapHang(maPN);
            chitiet.Show();
        }

        private void dataGridView3trung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDonTraHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maPT = dgvDonTraHang.Rows[e.RowIndex].Cells["MaDonTraHang"].Value.ToString();
            CT_DonTraHang chitiet = new CT_DonTraHang(maPT);
            chitiet.Show();
        }
    }
}
