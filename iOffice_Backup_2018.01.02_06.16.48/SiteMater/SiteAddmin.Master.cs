using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.BUS;
using System.Collections;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.SiteMater
{
    public partial class SiteAddmin : System.Web.UI.MasterPage
    {
        protected Hashtable hasLanguege;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                string ngonngu = Session["languege"].ToString();
                string congty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                Busers2 nguoidung = UserDAO.TimNhanVienTheoMa(manguoidung, congty);
                lblTen.Text = nguoidung.USERNAME;
                if (ngonngu == "lbl_VN")
                {
                    lblXinChao.Text = "Xin chào: ";
                }
                else if (ngonngu == "lbl_TW")
                {
                    lblXinChao.Text = "你好: ";
                }
                else if (ngonngu == "lbl_EN")
                {
                    lblXinChao.Text = "Hello: ";
                }
            }
            else
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
            }
            LayngonNgu(19);
            GanNgonNguVaoConTrol();
        }
        string Url = "";
        public void LayDuLieuNgonNgu()
        {

            try
            {
                Url = Request.Url.LocalPath;
                hasLanguege = new System.Collections.Hashtable();
                hasLanguege = CateLanguegeDAO.LayNgonNgu(CateLanguegeDAO.LayMaManHinh(Url.Substring(Url.LastIndexOf('/') + 1)), Session["languege"].ToString());


            }

            catch (Exception )
            {
                throw;
            }
        }
        public void LayngonNgu(int id)
        {
            try
            {
                string str = Session["languege"].ToString();
                Url = Request.Url.LocalPath.Substring(Url.LastIndexOf('/') + 1);
                hasLanguege = new System.Collections.Hashtable();
                hasLanguege = CateLanguegeDAO.LayNgonNgu(id, Session["languege"].ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void GanNgonNguVaoConTrol()
        {
            HyperLink1.Text = hasLanguege["HyperLink112"].ToString();
            HyperLink22.Text = hasLanguege["HyperLink22"].ToString();
            HyperLink2.Text = hasLanguege["HyperLink2"].ToString();
            HyperLink3.Text = hasLanguege["HyperLink3"].ToString();
            HyperLink4.Text = hasLanguege["HyperLink4"].ToString();
            HyperLink5.Text = hasLanguege["HyperLink5"].ToString();
            //HyperLink6.Text = hasLanguege["HyperLink66"].ToString();
            ida.Text = hasLanguege["ida2"].ToString();
            // idb1.Text = hasLanguege["idb"].ToString();
           // idc.Text = hasLanguege["idc2"].ToString();
            // idd.Text = hasLanguege["idd"].ToString();
            ide.Text = hasLanguege["ide2"].ToString();
            //HyperLink2.Text = hasLanguege["HyperLink2"].ToString();
            HyperLink6.Text = hasLanguege["HyperLink6"].ToString();
        }
    }
}