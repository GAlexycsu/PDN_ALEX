using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
namespace iOffice
{
    public partial class WebLang : System.Web.UI.Page
    {
        LangDAO dal = new LangDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (txtID.Text.Trim() != "")
            {
                dt=dal.DanhSachDaNgonNguTheoID(int.Parse(txtID.Text.Trim()));
            }
            else
            {
                dt= dal.DanhSachDaNgonNgu();
            }
            if (dt.Rows.Count > 0)
            {
               // string server = "D:\\AttactFilePDN\\" + filename;
                string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                string pathServer = pathA + @"\XMLFileLang.xml";
                XmlDocument myXML = new XmlDocument();
                myXML.Load(pathServer);
                foreach (DataRow dr in dt.Rows)
                {
                    string lblID = dr["lblID"].ToString();
                    string lblVN = dr["lbl_VN"].ToString();
                    string lbl_EN = dr["lbl_EN"].ToString();
                    string lbl_TW = dr["lbl_TW"].ToString();
                    string ScreenID = dr["ScreenID"].ToString();
                    XmlElement parentElement = myXML.CreateElement("LangID");
                    XmlElement ID = myXML.CreateElement("lblID");
                    ID.InnerText = lblID.ToString().Trim();
                    XmlElement VN = myXML.CreateElement("lbl_VN");
                    VN.InnerText = lblVN.ToString().Trim();
                    XmlElement EN = myXML.CreateElement("lbl_EN");
                    EN.InnerText = EN.ToString().Trim();
                    XmlElement TW = myXML.CreateElement("lbl_TW");
                    TW.InnerText = lbl_TW.ToString().Trim();
                    XmlElement Screen = myXML.CreateElement("ScreenID");
                    Screen.InnerText = ScreenID.ToString().Trim();
                    parentElement.AppendChild(ID);
                    parentElement.AppendChild(VN);
                    parentElement.AppendChild(EN);
                    parentElement.AppendChild(TW);
                    parentElement.AppendChild(Screen);
                    myXML.DocumentElement.AppendChild(parentElement);
                    myXML.Save(pathServer);
                }
            }
        }
    }
}