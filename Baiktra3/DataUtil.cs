using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace Baiktra3
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil()
        {
            filename = "danhsachkhachhang.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement danhsachkhachhang = doc.CreateElement("danhsachkhachhang");
                doc.AppendChild(danhsachkhachhang);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public bool addKH(khachhang s)
        {
            XmlNode khfind = root.SelectSingleNode("khachhang[@makh='" + s.makhachhang + "']");
            if (khfind == null)
            {
                XmlElement st = doc.CreateElement("khachhang");
                st.SetAttribute("makh", s.makhachhang);
                st.SetAttribute("chinhanh", s.chinhanh);
                XmlElement hoten = doc.CreateElement("hoten");
                hoten.InnerText = s.hoten;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = s.diachi;
                XmlElement dienthoai = doc.CreateElement("sodt");
                dienthoai.InnerText = s.sodienthoai;

                st.AppendChild(hoten);
                st.AppendChild(diachi);
                st.AppendChild(dienthoai);
                root.AppendChild(st);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool updateKH (khachhang s)
        {
            XmlNode khfind = root.SelectSingleNode("khachhang[@makh='" + s.makhachhang + "']");
            if (khfind != null)
            {
                XmlElement st = doc.CreateElement("khachhang");
                st.SetAttribute("makh", s.makhachhang);
                st.SetAttribute("chinhanh", s.chinhanh);
                XmlElement hoten = doc.CreateElement("hoten");
                hoten.InnerText = s.hoten;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = s.diachi;
                XmlElement dienthoai = doc.CreateElement("sodt");
                dienthoai.InnerText = s.sodienthoai;

                st.AppendChild(hoten);
                st.AppendChild(diachi);
                st.AppendChild(dienthoai);
                root.ReplaceChild(st, khfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool deleteKH(string makh)
        {
            XmlNode khfind = root.SelectSingleNode("khachhang[@makh='" + makh + "']");
            if (khfind != null)
            {
                root.RemoveChild(khfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public List<khachhang> GetallKH()
        {
            XmlNodeList nodes = root.SelectNodes("khachhang");
            List<khachhang> li = new List<khachhang>();
            foreach (XmlNode item in nodes)
            {
                khachhang s = new khachhang();
                s.makhachhang = item.Attributes[0].InnerText;
                s.chinhanh = item.Attributes[1].InnerText;
                s.hoten = item.SelectSingleNode("hoten").InnerText;
                s.diachi = item.SelectSingleNode("diachi").InnerText;
                s.sodienthoai = item.SelectSingleNode("sodt").InnerText;
                li.Add(s);
            }
            return li;
        }
    }
}
