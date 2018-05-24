using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace iOffice.SiteMater
{
    public partial class MyDocusND : System.Web.UI.MasterPage
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        Hashtable hastable;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();
        departDAL dal = new departDAL();
        userDAL dalUser = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
                string pTuNgay = (string)Session["TuNgay1"];
                string pDenNgay = (string)Session["DenNgay1"];
                if (pTuNgay != null && pDenNgay != null)
                {
                    txtFromDate.Text = DateTime.Parse(pTuNgay).ToString("yyyy/MM/dd");
                    txtToDate.Text = DateTime.Parse(pDenNgay).ToString("yyyy/MM/dd");
                }
                else
                {
                    DataTable dt = dal.GetDate();
                    string date = dt.Rows[0]["NgayThang"].ToString();
                    DateTime a = DateTime.Parse(date.ToString());
                    txtFromDate.Text = a.ToString("yyyy/MM/dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                }
                string macongty = (string)Session["congty"];
                string manhanvien = (string)Session["user"];
                if (manhanvien == null && macongty == null)
                {
                    Response.Redirect("http://"+linkWebPortal+"/");
                }
                else
                {
                    DataTable dtUs = dalUser.TimNhanVienTheoMa(macongty, manhanvien);
                    if (dtUs.Rows.Count > 0)
                    {
                        lblNhanVien.Text = dtUs.Rows[0]["USERNAME"].ToString();
                    }
                    LayNgonNgu(18);
                    GanNgonNguVaoConTrol();
                }
            }
        }
        string Url = "";
        public void LayDuLieuNgonNgu()
        {
            try
            {
                Url = Request.Url.LocalPath;
                hastable = new Hashtable();
                hastable = CateLanguegeDAO.LayNgonNgu(CateLanguegeDAO.LayMaManHinh(Url.Substring(Url.LastIndexOf('/') + 1)), Session["languege"].ToString());

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void LayNgonNgu(int id)
        {
            string ngonngu = Session["languege"].ToString();
            Url = Request.Url.LocalPath.Substring(Url.LastIndexOf('/') + 1);
            hastable = new Hashtable();
            hastable = CateLanguegeDAO.LayNgonNgu(id, ngonngu);

        }
        public void GanNgonNguVaoConTrol()
        {
            //HyperChangePass.Text = hastable["HyperLink8"].ToString();
            //HyperLinkForgotPass.Text = hastable["HyperLink1"].ToString();
            //HyperChangeSig.Text = hastable["HyperLink7"].ToString();
            LinkButton1.Text = hastable["ide1"].ToString();
           // btnTaoPhieu.Text = hastable["btnTaoPhieu"].ToString();
            //LinkNhap.Text = hastable["LinkNhap"].ToString();
            LinkPhieuChuaDich.Text = hastable["LinkPhieuChuaDich"].ToString();
            LinkPhieuDich.Text = hastable["LinkPhieuDich"].ToString();
            //LinkPhieuDaKy.Text = hastable["LinkPhieuDaKy"].ToString();
            //LinkNoOk.Text = hastable["LinkNoOk"].ToString();
            
            //HyperLink1.Text = hastable["HyperLink1"].ToString();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("maphieu");
            Session.Remove("ktmaphieu");
            Session.Remove("congty");
            Session.Remove("user");
            Session.Remove("UserID");
            //string langue = Session["languege"].ToString();
            //Response.Redirect("http://portal.footgear.com.vn/?biennho=" + langue);
            //Response.Redirect("http://"+linkWebPortal+"/");
            Response.Redirect("~/presentationLayer/Default.aspx");
        }

        protected void LinkNhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDanhsachphieumoikhoitaoND.aspx");
        }

        protected void LinkPhieuChuaDich_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieuchuadichND.aspx");
        }

        protected void LinkPhieuDich_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieudadichND.aspx");
        }

        protected void LinkPhieuDaKy_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDanhsachphieudaduyetND.aspx");
        }

        protected void LinkNoOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDanhsachphieukhongduockyND.aspx");
        }

        protected void LinkKho_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDanhsachphieucattrongkhoND.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string macongty = "LTY";
            Session["congty"] = macongty;
            string manhanvien = (string)Session["user"];
             string languege = (string)Request["languege"];
            string cbChuaDich = "";
            string cbDaDich = "";
            if (checkNotYetTrans.Checked == true)
            {
                cbChuaDich = "true";
            }
            else
            {
                cbChuaDich = "false";
            }
            if (CheckTranslated.Checked == true)
            {
                cbDaDich = "true";
            }
            else
            {
                cbDaDich = "false";
            }
            string FromDate = txtFromDate.Text.Trim();
            string ToDate = txtToDate.Text.Trim();
            Session["TuNgay2"] = txtFromDate.Text.Trim();
            Session["DenNgay2"] = txtDate.Text.Trim();
           // Response.Redirect("http://localhost:3530/presentationLayer/NguoiDich/MyDocusND.aspx?UserID=" + manhanvien + "&congty="+macongty+"&languege="+languege+"&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&FromDate=" + FromDate + "&ToDate=" + ToDate);
            //  Response.Redirect("http://"+alink+"/NguoiDich/MyDocusND.aspx?UserID=" + manhanvien + "&congty="+macongty+"&languege="+languege+ "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&FromDate=" + FromDate + "&ToDate=" + ToDate);
            Response.Redirect("~/presentationLayer/NguoiDich/MyDocusND.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&languege=" + languege + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&FromDate=" + FromDate + "&ToDate=" + ToDate);
        }

        protected void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/presentationLayer/NguoiDich/frmTaoPhieuND.aspx");
            Response.Redirect("frmTaoPhieuND.aspx");
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string congty = Session["congty"].ToString();
            string languege = Session["languege"].ToString();
            //Response.Redirect("http://"+linkWebPortal+"/pageMain2.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
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
    }
}