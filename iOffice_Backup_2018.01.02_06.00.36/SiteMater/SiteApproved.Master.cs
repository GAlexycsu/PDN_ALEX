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
    public partial class SiteApproved : System.Web.UI.MasterPage
    {
        protected Hashtable hasLanguege;
        static iOfficeDataContext db = new iOfficeDataContext();
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
            LayngonNgu(18);
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

            catch (Exception ex)
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
            //HyperLink11.Text = hasLanguege["HyperLink11"].ToString();
            HyperLink11.Text = hasLanguege["HyperLink11"].ToString();
            
            HyperLink22.Text = hasLanguege["HyperLink22"].ToString();
            HyperLink6.Text = hasLanguege["HyperLink6"].ToString();
            HyperLink1.Text = hasLanguege["HyperLink1"].ToString();
            HyperLink2.Text ="11."+ hasLanguege["HyperLink2"].ToString();
            HyperLink21.Text ="8." +hasLanguege["HyperLink21"].ToString();
            HyperLink3.Text = hasLanguege["HyperLink3"].ToString();
            HyperLink4.Text = hasLanguege["HyperLink4"].ToString();
            HyperLink5.Text = hasLanguege["HyperLink5"].ToString();
            HyperLink7.Text = hasLanguege["HyperLink7"].ToString();
            HyperLink8.Text = hasLanguege["HyperLink8"].ToString();
            ida1.Text = hasLanguege["ida1"].ToString();
           // idb1.Text = hasLanguege["idb"].ToString();
            idc1.Text = hasLanguege["idc1"].ToString();
           // idd.Text = hasLanguege["idd"].ToString();
            ide1.Text = hasLanguege["ide1"].ToString();
            HyperLink9.Text = hasLanguege["HyperLink9"].ToString();
            HyperLink10.Text = hasLanguege["HyperLink10"].ToString();
            HyperLink12.Text ="9."+ hasLanguege["HyperLink12"].ToString();
            HyperLink13.Text = "10." + hasLanguege["HyperLink13"].ToString();
        }
    }
}