using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class KHtrahang : Form
    {
        control control = new control();
        private string MaHoaDon;
        private string MaSanPham;
        private int DonGia;
        private string MaPhieuTra;
        private string ktth;
        public KHtrahang()
        {
            InitializeComponent();
        }
        public KHtrahang(string ma, string sp, int gia, string pt,string kt)
        {
            InitializeComponent();
            MaHoaDon = ma;
            MaSanPham = sp;
            DonGia = gia;
            MaPhieuTra = pt;
            ktth = kt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ktth == "0")
            {
                control.insert_phieutra(MaPhieuTra, MaHoaDon);
            }
            control.insert_CTphieutra(MaPhieuTra, MaSanPham, Int32.Parse(textBox1.Text), Int32.Parse(textBox1.Text) * DonGia, textBox2.Text);
            
            this.Close();
        }
        
    }
}
