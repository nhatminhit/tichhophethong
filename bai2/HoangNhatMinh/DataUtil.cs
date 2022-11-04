using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace HoangNhatMinh
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            filename = "Congty.xml";
            doc = new XmlDocument();
            if(!File.Exists(filename))
            {
                XmlElement congty = doc.CreateElement("congty");
                doc.AppendChild(congty);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public  void addNV(nhanvien s)
        {
            XmlElement st = doc.CreateElement("nhanvien");
            st.SetAttribute("manv", s.manv);
            XmlElement hoten = doc.CreateElement("hoten");
            hoten.InnerText = s.hoten;
            XmlElement tuoi = doc.CreateElement("tuoi");
            tuoi.InnerText = s.tuoi;
            XmlElement luong = doc.CreateElement("luong");
            luong.InnerText = s.luong;
            XmlElement diachi = doc.CreateElement("diachi");
            XmlElement xa = doc.CreateElement("xa");
            xa.InnerText = s.xa;
            XmlElement huyen = doc.CreateElement("huyen");
            huyen.InnerText = s.huyen;
            XmlElement tinh = doc.CreateElement("tinh");
            tinh.InnerText = s.tinh;
            XmlElement dienthoai = doc.CreateElement("dienthoai");
            dienthoai.InnerText = s.dienthoai;

            st.AppendChild(hoten);
            st.AppendChild(tuoi);
            st.AppendChild(luong);
            st.AppendChild(diachi);
            st.AppendChild(dienthoai);
            diachi.AppendChild(xa);
            diachi.AppendChild(huyen);
            diachi.AppendChild(tinh);
            root.AppendChild(st);
            doc.Save(filename);
        }
        public List<nhanvien> GetallNV()
        {
            XmlNodeList nodes = root.SelectNodes("nhanvien");
            List<nhanvien> li = new List<nhanvien>();
            foreach (XmlNode item in nodes)
            {
                nhanvien s = new nhanvien();
                s.manv = item.Attributes[0].InnerText;
                s.hoten = item.SelectSingleNode("hoten").InnerText;
                s.tuoi = item.SelectSingleNode("tuoi").InnerText;
                s.luong = item.SelectSingleNode("luong").InnerText;
                s.xa = item.SelectSingleNode("diachi/xa").InnerText;
                s.huyen = item.SelectSingleNode("diachi/huyen").InnerText;
                s.tinh = item.SelectSingleNode("diachi/tinh").InnerText;
                s.dienthoai = item.SelectSingleNode("dienthoai").InnerText;
                li.Add(s);
            }
            return li;
        }
        public bool Update(nhanvien s)
        {
            XmlNode stfind = root.SelectSingleNode("nhanvien[@manv='"+s.manv+"']");
            if(stfind != null)
            {
                XmlElement st = doc.CreateElement("nhanvien");
                st.SetAttribute("manv", s.manv);
                XmlElement hoten = doc.CreateElement("hoten");
                hoten.InnerText = s.hoten;
                XmlElement tuoi = doc.CreateElement("tuoi");
                tuoi.InnerText = s.tuoi;
                XmlElement luong = doc.CreateElement("luong");
                luong.InnerText = s.luong;
                XmlElement diachi = doc.CreateElement("diachi");
                XmlElement xa = doc.CreateElement("xa");
                xa.InnerText = s.xa;
                XmlElement huyen = doc.CreateElement("huyen");
                huyen.InnerText = s.huyen;
                XmlElement tinh = doc.CreateElement("tinh");
                tinh.InnerText = s.tinh;
                XmlElement dienthoai = doc.CreateElement("dienthoai");
                dienthoai.InnerText = s.dienthoai;

                st.AppendChild(hoten);
                st.AppendChild(tuoi);
                st.AppendChild(luong);
                st.AppendChild(diachi);
                st.AppendChild(dienthoai);
                diachi.AppendChild(xa);
                diachi.AppendChild(huyen);
                diachi.AppendChild(tinh);
                root.ReplaceChild(st,stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool Delete(string manv)
        {
            XmlNode stfind = root.SelectSingleNode("nhanvien[@manv='" + manv + "']");
            if(stfind!=null)
            {
                root.RemoveChild(stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public nhanvien findid(string manv)
        {
            XmlNode stfind = root.SelectSingleNode("nhanvien[@manv='" + manv + "']");
            nhanvien s = null;
            if(stfind!=null)
            {
                s = new nhanvien();
                s.manv = stfind.Attributes[0].InnerText;
                s.hoten = stfind.SelectSingleNode("hoten").InnerText;
                s.tuoi = stfind.SelectSingleNode("tuoi").InnerText;
                s.luong = stfind.SelectSingleNode("luong").InnerText;
                s.xa = stfind.SelectSingleNode("diachi/xa").InnerText;
                s.huyen = stfind.SelectSingleNode("diachi/huyen").InnerText;
                s.tinh = stfind.SelectSingleNode("diachi/tinh").InnerText;
                s.dienthoai = stfind.SelectSingleNode("dienthoai").InnerText;
            }    
            return s;
        }
        public List<nhanvien>FindbyCity (string tinh)
        {
            XmlNodeList nhanviens = root.SelectNodes("nhanvien[diachi/tinh='" + tinh + "']");
            List<nhanvien> li = new List<nhanvien>();
            foreach  (XmlNode item in nhanviens )
            {
                nhanvien s = new nhanvien();
                s.manv = item.Attributes[0].InnerText;
                s.hoten = item.SelectSingleNode("hoten").InnerText;
                s.tuoi = item.SelectSingleNode("tuoi").InnerText;
                s.luong = item.SelectSingleNode("luong").InnerText;
                s.xa = item.SelectSingleNode("diachi/xa").InnerText;
                s.huyen = item.SelectSingleNode("diachi/huyen").InnerText;
                s.tinh = item.SelectSingleNode("diachi/tinh").InnerText;
                s.dienthoai = item.SelectSingleNode("dienthoai").InnerText;
                li.Add(s);
            }
            return li;
        }
    }
}
