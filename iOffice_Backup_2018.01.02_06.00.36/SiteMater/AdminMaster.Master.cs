using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Management;
using System.Configuration;
using System.Data;
namespace iOffice.SiteMater
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        Hashtable hasLanguege;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();
        userDAL dal = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string macongty = (string)Session["congty"];
                string manhanvien = (string)Session["user"];
                if (manhanvien == null && macongty == null)
                {
                    Response.Redirect("http://"+linkWebPortal+"/");
                }
                DataTable dt = dal.TimNhanVienTheoMa(macongty, manhanvien);
                if (dt.Rows.Count > 0)
                {
                    lblNhanVien.Text = dt.Rows[0]["USERNAME"].ToString();
                }
               
                LayngonNgu(19);
                GanNgonNguVaoConTrol();
            }
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
            LinkQuyTrinh.Text ="1."+ hasLanguege["HyperLink4"].ToString();
            LinkNghiPhep.Text = "2." + hasLanguege["HyperLink2"].ToString();
            LinkNhanVien.Text ="3."+ hasLanguege["HyperLink22"].ToString();
            LinkDonVi.Text = "4." + hasLanguege["HyperLink3"].ToString();
            LinkLoaiPhieu.Text ="5."+ hasLanguege["HyperLink6"].ToString();
             
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
            Session.Remove("congty");
            Session.Remove("user");
            Session.Remove("UserID");
            //string langue = Session["languege"].ToString();
            //Response.Redirect("http://portal.footgear.com.vn/?biennho=" + langue);
            //Response.Redirect("http://"+linkWebPortal+"/");
            Response.Redirect("~/presentationLayer/Default.aspx");
        }

        protected void LinkNghiPhep_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmNghiPhep.aspx");
        }

        protected void LinkNhanVien_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAddUsers.aspx");
        }

        protected void LinkDonVi_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBoPhan.aspx");
        }

        protected void LinkQuyTrinh_Click(object sender, EventArgs e)
        {
            Response.Redirect("FQPDNFlow.aspx");  // 簽核流程

        }

        protected void LinkLoaiPhieu_Click(object sender, EventArgs e)
        {
            Response.Redirect("FDanhSachLoaiPhieu.aspx");  // 單據類別
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KiemTraPhieu.aspx");   // 檢查單據
            //Response.Redirect("WebForm123.aspx");
        }

        protected void dropDowLanguege_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Lange = dropDowLanguege.SelectedValue.ToString().Trim();
            if (Lange != "select")
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                string keyVN = "_VN";
                string keyTW = "_TW";
                string keyEN = "_EN";
                Response.Cookies["DropLang"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["DropLang"].Value = dropDowLanguege.SelectedValue;
                string[] url1 = url.Split('_');
                if (url1.Length > 1)
                {

                    string urlMain = url1[0];
                    //string[] lang1 = Lange.Split('_');
                    string langmain = url1[1];
                    string ABC = "";
                    Session["languege"] = Lange;
                    if (Lange == "lbl_VN")
                    {
                        ABC = (urlMain + keyVN).ToString();

                        Response.Redirect(ABC);


                    }
                    else
                    {
                        if (Lange == "lbl_TW")
                        {
                            ABC = (urlMain + keyTW).ToString();
                            Response.Redirect(ABC);
                        }
                        else
                        {
                            if (Lange == "lbl_EN")
                            {
                                ABC = (urlMain + keyEN).ToString();
                                Response.Redirect(ABC);
                            }
                            else
                            {
                                Response.Redirect(url);
                            }
                        }

                    }
                }
                else
                {
                    Session["languege"] = Lange;
                    Response.Redirect(url);
                }


                //string url = HttpContext.Current.Request.Url.AbsoluteUri;
                //Session["languege"] = Lange;
                //Response.Redirect(url);
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string congty = Session["congty"].ToString();
            string languege = Session["languege"].ToString();
            // Response.Redirect("http://"+linkWebPortal+"/pageMain2.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
        }
    }
}