using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombobox();
        }
        public void LoadData()
        {
            string link = "http://localhost/demo/api/sanpham";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arrSanPham = data as SanPham[];
            dataGridView1.DataSource = arrSanPham;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string madm = txtMaDM.Text;
            string link = "http://localhost/demo/api/sanpham?madm=" + madm;
            HttpWebRequest req = HttpWebRequest.CreateHttp(link);
            WebResponse response = req.GetResponse(); 
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(SanPham[]));
            object data =json.ReadObject(response.GetResponseStream());
            SanPham[] arrSP = data as SanPham[];
            dataGridView1.DataSource =arrSP;
        }
        public void LoadCombobox()
        {
            string link = "http://localhost/demo/api/danhmuc";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] dsDM = data as DanhMuc[];
            cboDanhMuc.DataSource= dsDM;
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.DisplayMember = "TenDM";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string poststring = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txtmasp.Text, txttensp.Text, txtdongia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost/demo/api/sanpham" + poststring;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytearr = Encoding.UTF8.GetBytes(poststring);
            request.ContentLength = bytearr.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytearr, 0, bytearr.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if(kq)
            {
                LoadData();
                MessageBox.Show("Them moi thanh cong "+ txttensp.Text);
            }
            else
            {
                MessageBox.Show("Them khong thanh cong "+ txttensp.Text);
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string putstring = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}", txtmasp.Text, txttensp.Text, txtdongia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost/demo/api/sanpham" + putstring;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytearr = Encoding.UTF8.GetBytes(putstring);
            request.ContentLength = bytearr.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytearr, 0, bytearr.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadData();
                MessageBox.Show("Sua thanh cong");
            }
            else
            {
                MessageBox.Show("Sua khong thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string deletestring = string.Format("?ma={0}", txtmasp.Text);
            string link = "http://localhost/demo/api/sanpham" + deletestring;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytearr = Encoding.UTF8.GetBytes(deletestring);
            request.ContentLength = bytearr.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytearr, 0, bytearr.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadData();
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txtmasp.Text=Convert.ToString(row.Cells[0].Value);
            txttensp.Text = Convert.ToString(row.Cells[1].Value);
            txtdongia.Text = Convert.ToString(row.Cells[2].Value);  
        }
    }
}
