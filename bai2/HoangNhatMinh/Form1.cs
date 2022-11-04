using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoangNhatMinh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void btn_Add(object sender, EventArgs e)
        {
            nhanvien s = new nhanvien();
            s.manv = txtnv.Text;
            s.hoten = txthoten.Text;
            s.tuoi = txttuoi.Text;
            s.luong = txtluong.Text;
            s.xa = txtxa.Text;
            s.huyen = txthuyen.Text;
            s.tinh = txttinh.Text;
            s.dienthoai = txtsdt.Text;
            data.addNV(s);
            DisplayData();
            
        }
       

        private void btn_Exit(object sender, EventArgs e)
        {
            Close();
        }
        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetallNV();

        }

        private void btn_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btn_reset(object sender, EventArgs e)
        {
            txtnv.Clear();
            txthoten.Clear();
            txttuoi.Clear();
            txtluong.Clear();
            txtxa.Clear();
            txthuyen.Clear();
            txttinh.Clear();
            txtsdt.Clear();
            ActiveControl = txtnv;
        }

        private void GetANhanVien(object sender, DataGridViewCellEventArgs e)
        {
            nhanvien s = (nhanvien)dataGridView1.CurrentRow.DataBoundItem;
            txtnv.Text = s.manv;
            txthoten.Text = s.hoten;
            txttuoi.Text = s.tuoi;
            txtluong.Text = s.luong;
            txtxa.Text = s.xa;
            txthuyen.Text = s.huyen;
            txttinh.Text = s.tinh;
            txtsdt.Text = s.dienthoai;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            nhanvien s = new nhanvien();
            s.manv = txtnv.Text;
            s.hoten = txthoten.Text;
            s.tuoi = txttuoi.Text;
            s.luong = txtluong.Text;
            s.xa = txtxa.Text;
            s.huyen = txthuyen.Text;
            s.tinh = txttinh.Text;
            s.dienthoai = txtsdt.Text;
            bool kt = data.Update(s);
            if(!kt)
            {
                MessageBox.Show("ko cap nhat duoc nhan vien có ma nv: "+s.manv);
                return;
            }
            DisplayData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có muốn xóa ko","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            if(d== DialogResult.Yes)
            {
                bool kt = data.Delete(txtnv.Text);
                if(!kt)
                {
                    MessageBox.Show("Có lỗi khi xóa", "Thông báo");
                    return;
                }
                DisplayData();
            }    
        }

        private void btn_findbyid_Click(object sender, EventArgs e)
        {
            string id = txtnv.Text;
            List<nhanvien> li = new List<nhanvien>();
            nhanvien s = data.findid(id);
            if(s!=null)
            {
                li.Add(s);
                dataGridView1.DataSource = li;
                txtnv.Text = s.manv;
                txthoten.Text = s.hoten;
                txttuoi.Text = s.tuoi;
                txtluong.Text = s.luong;
                txtxa.Text = s.xa;
                txthuyen.Text = s.huyen;
                txttinh.Text = s.tinh;
                txtsdt.Text = s.dienthoai;
            }
            else
            {
                MessageBox.Show("Khong có mã sinh viên:" + id, "Thông Báo");
            }    
        }
        private void btn_findcity_Click(object sender, EventArgs e)
        {
            string city = txttinh.Text;
            dataGridView1.DataSource = data.FindbyCity(city);
            txttinh.Text = city;
        }
    }
}
