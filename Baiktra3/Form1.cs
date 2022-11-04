using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baiktra3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form1_Load_1(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            khachhang s = new khachhang();
            if (txtmakh.Text == "" || cbxchinhanh.SelectedIndex < 0 || txthoten.Text == "" || txtdiachi.Text == "" || txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn không được để trống các ô", "Thông báo");
                return;
            }    
            
            s.makhachhang = txtmakh.Text;
            s.chinhanh=cbxchinhanh.SelectedItem.ToString();
            s.hoten = txthoten.Text;
            s.diachi = txtdiachi.Text;
            s.sodienthoai = txtsodienthoai.Text;
            bool check = data.addKH(s);
            if (!check)
            {
                MessageBox.Show("Đã tồn tại mã khách hàng " + txtmakh.Text);
                return;
            }    
            DisplayData();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetallKH();
        }

        private void GetAKhachHang(object sender, DataGridViewCellEventArgs e)
        {
            khachhang s = (khachhang)dataGridView1.CurrentRow.DataBoundItem;
            txtmakh.Text = s.makhachhang;
            cbxchinhanh.Text = s.chinhanh;
            txthoten.Text = s.hoten;
            txtdiachi.Text = s.diachi;
            txtsodienthoai.Text = s.sodienthoai;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            khachhang s = new khachhang();
            if (txtmakh.Text == "" || cbxchinhanh.SelectedIndex < 0 || txthoten.Text == "" || txtdiachi.Text == "" || txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn không được để trống các ô", "Thông báo");
                return;
            }
            s.makhachhang = txtmakh.Text;
            s.chinhanh = cbxchinhanh.SelectedItem.ToString();
            s.hoten = txthoten.Text;
            s.diachi = txtdiachi.Text;
            s.sodienthoai = txtsodienthoai.Text;
            bool check = data.updateKH(s);
            if (!check)
            {
                MessageBox.Show("Mã khách hàng " + txtmakh.Text + " không tồn tại");
                return;
            }    
            DisplayData();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn không được để trống mã khách hàng", "Thông báo");
                return;
            }
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes)
            {
                bool check = data.deleteKH(txtmakh.Text);
                if (!check)
                {
                    MessageBox.Show("Mã khách hàng " + txtmakh.Text + " không tồn tại");
                    return;
                }
                DisplayData();
            }    
        }
    }
}
