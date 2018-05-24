using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
 using System.Configuration;
namespace iOffice.SiteMater
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected Hashtable hasLanguege;
        static iOfficeDataContext db = new iOfficeDataContext();
        departDAL dal = new departDAL();
        string  alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();
        userDAL dalUser = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            LayNgonNgu(18);
            GanNgonNguVaoControl();
            if (!IsPostBack)
            {
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
                CheckNoOk.Checked = true;
                CheckOk.Checked = true;
                checkWaitMe.Checked = true;



                DataTable dtUs = dalUser.TimNhanVienTheoMa(macongty, manhanvien);
                if (dtUs.Rows.Count > 0)
                {
                    lblNhanVien.Text = dtUs.Rows[0]["USERNAME"].ToString();
                }
                   
                    string cbOk=(string)Session["cbok"];
                    string cbwait=(string)Session["cbwait"];
                    string cbNoOk=(string)Session["cbnook"];
                    if (cbNoOk == null && cbOk == null && cbwait == null)
                    {
                        CheckNoOk.Checked = true;
                        CheckOk.Checked = true;
                        checkWaitMe.Checked = true;
                    }
                    else
                    {
                        if (cbwait == "true")
                        {
                            checkWaitMe.Checked = true;
                        }
                        else
                        {
                            checkWaitMe.Checked = false;
                        }
                        if (cbOk == "true")
                        {
                            CheckOk.Checked = true;
                        }
                        else
                        {
                            CheckOk.Checked = false;
                        }
                        if (cbNoOk == "true")
                        {
                            CheckNoOk.Checked = true;
                        }
                        else
                        {
                            CheckNoOk.Checked = false;
                        }
                    }
                
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
            catch (Exception)
            {
                
                throw;
            }
        }
        public void LayNgonNgu(int id)
        {
            try
            {
                string str = Session["languege"].ToString();
                Url = Request.Url.LocalPath.Substring(Url.LastIndexOf('/') + 1);
                hasLanguege = new Hashtable();
                hasLanguege = CateLanguegeDAO.LayNgonNgu(id, str);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void GanNgonNguVaoControl()
        {
            //HyperChangePass.Text = hasLanguege["HyperLink8"].ToString();
            //HyperLinkForgotPass.Text = hasLanguege["HyperLink1"].ToString();
            //HyperChangeSig.Text = hasLanguege["HyperLink7"].ToString();
            LinkButton1.Text = hasLanguege["ide1"].ToString();
            btnTaoPhieu.Text = hasLanguege["btnTaoPhieu"].ToString();
            LinkWaitMe.Text ="B.1. " + hasLanguege["LinkWaitMe"].ToString();
            LinkOK.Text ="B.2. "+ hasLanguege["LinkOK"].ToString();
            linkLinkNoOk.Text ="B.3. "+ hasLanguege["linkLinkNoOk"].ToString();
           
            //HyperLink1.Text = hasLanguege["HyperLinkFunction"].ToString();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string macongty = "LTY";
            Session["congty"] = macongty;
            string manhanvien = (string)Session["user"];
            if (txtTimKiem.Text.Trim() != "")
            {
                if (txtTimKiem.Text.Length == 9)
                {
                    string maphieu = txtTimKiem.Text.Trim();
                   // Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyCheckPDN.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                  //  Response.Redirect("http://"+alink+"/ApproveUser/MyCheckPDN.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                    Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                }
                else
                {
                    txtTimKiem.Text = "";
                }
            }
            else
            {
                string waitme = "";
                string okme = "";
                string nookme = "";
                string sessttim = "tim";

                if (checkWaitMe.Checked == true)
                {
                    waitme = "true";
                }
                else
                { waitme = "false"; }
                if (CheckOk.Checked == true)
                {
                    okme = "true";
                }
                else
                {
                    okme = "false";
                }
                if (CheckNoOk.Checked == true)
                {
                    nookme = "true";
                }
                else
                {
                    nookme = "false";
                }
                Session["cbok"] = okme.ToString();
                Session["cbwait"] = waitme.ToString();
                Session["cbnook"] = nookme.ToString();
                string ngaybatdau = txtFromDate.Text.Trim();
                string ngayketthuc = txtToDate.Text.Trim();
                Session["TuNgay1"] = txtFromDate.Text.Trim();
                Session["DenNgay1"] = txtDate.Text.Trim();
                // Response.Redirect("MyCheckPDN.aspx?waitme=" + waitme + "&okme=" + okme + "&nookme=" + nookme + "&ngaybatdau=" + ngaybatdau + "&ngayketthuc=" + ngayketthuc);

                // Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyCheckPDN.aspx?waitme=" + waitme + "&okme=" + okme + "&nookme=" + nookme + "&ngaybatdau=" + ngaybatdau + "&ngayketthuc=" + ngayketthuc + "&sessttim="+sessttim);
                //Response.Redirect("http://"+alink+"/ApproveUser/MyCheckPDN.aspx?waitme=" + waitme + "&okme=" + okme + "&nookme=" + nookme + "&ngaybatdau=" + ngaybatdau + "&ngayketthuc=" + ngayketthuc + "&sessttim=" + sessttim);
                Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx?waitme=" + waitme + "&okme=" + okme + "&nookme=" + nookme + "&ngaybatdau=" + ngaybatdau + "&ngayketthuc=" + ngayketthuc + "&sessttim=" + sessttim);
            }
        }

        protected void LinkWaitMe_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachVanBanDen.aspx");
        }

        protected void LinkKho_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachPhieuTrongKhoTheoNguoiDuyet.aspx");
        }

        protected void LinkOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachvanbandaky.aspx");
        }

        protected void LinkLinkNoOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachvanbankhongduyet.aspx");
        }

        protected void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            Session.Remove("maphieu");
            Session.Remove("ktmaphieu");
            Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
            if (nhanvien != null)
            {
                if (nhanvien.isSep == true)
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("MyCreatePDN1.aspx");
                }
                else
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("frmTaoMoi.aspx");
                }
            }
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

        protected void linkHome_Click(object sender, EventArgs e)
        {
            string UserID=Session["UserID"].ToString();
            string congty=Session["congty"].ToString();
             string languege = Session["languege"].ToString();
           // Response.Redirect("http://"+linkWebPortal+"/pageMain2.aspx"+"?UserID="+UserID+"&congty="+congty+"&languege="+languege);
             //Response.Redirect("http://localhost:12313/TheLogin/pageMain2.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
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
            }
        }

      
    }
}