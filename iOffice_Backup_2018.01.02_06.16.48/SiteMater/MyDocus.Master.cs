using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Text;
namespace iOffice.SiteMater
{
    public partial class MyDocus : System.Web.UI.MasterPage
    {
        protected Hashtable hasLanguege;
        static iOfficeDataContext db = new iOfficeDataContext();
        departDAL dal = new departDAL();
        userDAL dalUser = new userDAL();
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
           // 
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            LayNgonNgu(18);
            GanNgonNguyVaoControl();
                if (!IsPostBack)
                {
                    string pTuNgay = (string)Session["TuNgay"];
                    string pDenNgay = (string)Session["DenNgay"];
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
                    DataTable dtUs = dalUser.TimNhanVienTheoMa(macongty, manhanvien);
                    if (dtUs.Rows.Count > 0)
                    {
                        lblNhanVien.Text = dtUs.Rows[0]["USERNAME"].ToString();
                    }
                  
                   string chuadich=(string)Session["cChuaDich"];
                   string dadich=(string)Session["cDaDich"];
                   string dagui=(string)Session["cDaGui"];
                   string daky =(string)Session["cDaKy"];
                    string khongky=(string)Session["cKhongKy"];
                   string nhap=(string)Session["cNhap"];
                   string TraVe = (string)Session["checkTraVe"];
                   if (chuadich == null && dadich == null && dagui == null && daky == null && khongky == null && nhap == null)
                   {
                       checkDaGui.Checked = true;
                       checkNhap.Checked = true;
                       CheckNoOk.Checked = true;
                       checkNotYetTrans.Checked = true;
                       CheckOk.Checked = true;
                       CheckTranslated.Checked = true;
                       CheckTraVe.Checked = true;
                   }
                   else
                   {
                       if (chuadich == "True")
                       {
                           checkNotYetTrans.Checked = true;

                       }
                       else
                       {
                           checkNotYetTrans.Checked = false;
                       }
                       if (dadich == "True")
                       {
                           CheckTranslated.Checked = true;
                       }
                       else
                       {
                           CheckTranslated.Checked = false;
                       }
                       if (dagui == "True")
                       {
                           checkDaGui.Checked = true;
                       }
                       else
                       {
                           checkDaGui.Checked = false;
                       }
                       if (daky == "True")
                       {
                           CheckOk.Checked = true;
                       }
                       else
                       {
                           CheckOk.Checked = false;
                       }
                       if (khongky == "True")
                       {
                           CheckNoOk.Checked = true;
                       }
                       else
                       {
                           CheckNoOk.Checked = false;
                       }
                       if (nhap == "True")
                       {
                           checkNhap.Checked = true;
                       }
                       else
                       {
                           checkNhap.Checked = false;
                       }
                       if (TraVe == "True")
                       {
                           CheckTraVe.Checked = true;
                       }
                       else
                       {
                           CheckTraVe.Checked = false;
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
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            // Try to use parameterized inline query/sp to protect sql injection
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " dwbh FROM clzl where dwbh!='NULL' and dwbh  LIKE '" + prefixText + "%'", conn);
            SqlDataReader oReader;
            conn.Open();
            List<string> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["dwbh"].ToString());
            return CompletionSet.ToArray();
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] getcodePDNbyCreator(string prefixText, int count, string contextKey)
        {
            string gsbh = "LTY";
            //string userID = Session["user"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            // Try to use parameterized inline query/sp to protect sql injection
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " pdno FROM pdna where GSBH='"+gsbh+"' and pdno  LIKE '" + prefixText + "%'", conn);
            SqlDataReader oReader;
            conn.Open();
            List<string> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["pdno"].ToString());
            return CompletionSet.ToArray();
        }
        [WebMethod]
        public List<string> GetData(string DName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select pdno from pdna where pdno like '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", DName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["pdno"].ToString());
                    }
                    return result;
                }
            }
        }
      
        public void GanNgonNguyVaoControl()
        {
            //HyperChangePass.Text = hasLanguege["HyperLink8"].ToString();
            //HyperLinkForgotPass.Text = hasLanguege["HyperLink1"].ToString();
            //HyperChangeSig.Text = hasLanguege["HyperLink7"].ToString();
            LinkButton1.Text = hasLanguege["ide1"].ToString();
            btnTaoPhieu.Text = hasLanguege["btnTaoPhieu"].ToString();
            LinkNhap.Text ="A.1."+ hasLanguege["LinkNhap"].ToString();
            LinkPhieuChuaDich.Text ="A.2."+ hasLanguege["LinkPhieuChuaDich"].ToString();
            LinkPhieuDich.Text ="A.3."+ hasLanguege["LinkPhieuDich"].ToString();
            LinkPhieuDaKy.Text ="A.5."+ hasLanguege["LinkPhieuDaKy"].ToString();
            LinkNoOk.Text ="A.6."+ hasLanguege["LinkNoOk"].ToString();
            LinkDaGui.Text ="A.4."+ hasLanguege["LinkDaGui"].ToString();
            linkPhanhoi.Text = "A.7." + hasLanguege["linkPhanhoi"].ToString();
            //HyperLink1.Text = hasLanguege["HyperLinkFunction"].ToString();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void LinkNhap_Click(object sender, EventArgs e)
        {
            string macongty=(string)Session["congty"];
            string manhanvien=(string)Session["user"];
            if(macongty==null && manhanvien==null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            else
            {
                Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                if (nhanvien.isSep == true)
                {
                    Response.Redirect("Danhsachphieumoikhoitao.aspx");
                }
                else
                {
                    Response.Redirect("DanhsachphieumoikhoitaoNV.aspx");
                }
            }

        }

        protected void LinkPhieuChuaDich_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (macongty == null && manhanvien == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            else
            {
                Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                if (nhanvien.isSep == true)
                {
                    Response.Redirect("danhsachphieuchuadich.aspx");
                }
                else
                {
                    Response.Redirect("danhsachvanbanchuadichNV.aspx");
                }
            }
           
        }

        protected void LinkPhieuDich_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (macongty == null && manhanvien == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            else
            {
                Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                if (nhanvien.isSep == true)
                {
                    Response.Redirect("danhsachphieudadich.aspx");
                }
                else
                {
                    Response.Redirect("danhsachvanbandadichNV.aspx");
                }
            }
            
        }

        protected void LinkPhieuDaKy_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (macongty == null && manhanvien == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            else
            {
                Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                if (nhanvien.isSep == true)
                {
                    Response.Redirect("wf_Danhsachphieudaduocky.aspx");
                }
                else
                {
                    Response.Redirect("danhsachphieudaduyetNV.aspx");
                }
            }
            
        }

        protected void LinkNoOk_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (macongty == null && manhanvien == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            else
            {
                Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                if (nhanvien.isSep == true)
                {
                    Response.Redirect("danhsachphieubanguikhongduocduyet.aspx");
                }
                else
                {
                    Response.Redirect("danhsachvanbankhongduockyNV.aspx");
                }
            }
            
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
                    string maphieu=txtTimKiem.Text.Trim();
                    Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                  
                    if (nhanvien.isSep == true)
                    {
                        // Response.Redirect("MyDocusRe.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&cbKho=" + cbKho+"&FromDate="+FromDate+"&ToDate="+ToDate);
                         //Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&congty="+macongty+"&maphieu="+maphieu);
                        //Response.Redirect("http://"+alink+"/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&congty="+macongty+"&maphieu="+maphieu);
                        Response.Redirect("~/presentationLayer/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                    }
                    else
                    {
                        // Response.Redirect("MyDocusNV.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&cbKho=" + cbKho+"&FromDate="+FromDate+"&ToDate="+ToDate);
                       // Response.Redirect("http://localhost:3530/presentationLayer/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&congty="+macongty+"&maphieu="+maphieu);
                       // Response.Redirect("http://"+alink+"/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                        Response.Redirect("~/presentationLayer/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&congty=" + macongty + "&maphieu=" + maphieu);
                    }
                }
                else
                {
                    txtTimKiem.Text = "";
                }
            }
            else
            {
                string cbNhap = "";
                string cbChuaDich = "";
                string cbDaDich = "";
                string cbDaKy = "";
                string cbKhongKy = "";
                string cbDaGui = "";
                string TraVe="";
                string FromDate = txtFromDate.Text.Trim();
                string ToDate = txtToDate.Text.Trim();
                string sessttim = "tim";
                #region Set
                if (checkNhap.Checked == true)
                {
                    cbNhap = "True";

                }
                else
                {
                    cbNhap = "False";
                }
                if (checkNotYetTrans.Checked == true)
                {
                    cbChuaDich = "True";
                }
                else
                {
                    cbChuaDich = "False";
                }
                if (CheckTranslated.Checked == true)
                {
                    cbDaDich = "True";
                }
                else
                {
                    cbDaDich = "False";
                }
                if (CheckOk.Checked == true)
                {
                    cbDaKy = "True";
                }
                else
                {
                    cbDaKy = "False";
                }
                if (CheckNoOk.Checked == true)
                {
                    cbKhongKy = "True";
                }
                else
                {
                    cbKhongKy = "False";
                }
                if (checkDaGui.Checked == true)
                {
                    cbDaGui = "True";
                }
                else
                {
                    cbDaGui = "False";
                }
                if(CheckTraVe.Checked==true)
                {
                    TraVe="True";
                }
                else
                {
                    TraVe="False";
                }
                #endregion

                if (macongty == null && manhanvien == null)
                {
                   // Response.Redirect("http://"+linkWebPortal+"/");
                    Response.Redirect("Default.aspx");
                }
                else

                {
                    
                    Session["cChuaDich"] = cbChuaDich.ToString();
                    Session["cDaDich"] = cbDaDich.ToString();
                    Session["cDaGui"] = cbDaGui.ToString();
                    Session["cDaKy"] = cbDaKy.ToString();
                    Session["cKhongKy"] = cbKhongKy.ToString();
                    Session["cNhap"] = cbNhap.ToString();
                    Session["TuNgay"] = txtFromDate.Text.Trim();
                    Session["DenNgay"] = txtToDate.Text.Trim();
                    Session["ccheckTraVe"] = TraVe.ToString();
                    Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
                    if (nhanvien.isSep == true)
                    {
                        // Response.Redirect("MyDocusRe.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&cbKho=" + cbKho+"&FromDate="+FromDate+"&ToDate="+ToDate);
                         //Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate +"&cbDaGui="+cbDaGui+ "&sessttim="+sessttim);
                        //Response.Redirect("http://"+alink+"/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui + "&sessttim=" + sessttim+"&TraVe="+TraVe);
                        Response.Redirect("~/presentationLayer/ApproveUser/MyDocusRe.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui + "&sessttim=" + sessttim + "&TraVe=" + TraVe);
                    }
                    else
                    {
                        // Response.Redirect("MyDocusNV.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui+ "&sessttim="+sessttim);
                         //Response.Redirect("http://localhost:3530/presentationLayer/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui+ "&sessttim="+sessttim);
                       // Response.Redirect("http://"+alink+"/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui + "&sessttim=" + sessttim+"&TraVe="+TraVe);
                        Response.Redirect("~/presentationLayer/Users/MyDocusNV.aspx?UserID=" + manhanvien + "&cbNhap=" + cbNhap + "&cbChuaDich=" + cbChuaDich + "&cbDaDich=" + cbDaDich + "&cbDaKy=" + cbDaKy + "&cbKhongKy=" + cbKhongKy + "&FromDate=" + FromDate + "&ToDate=" + ToDate + "&cbDaGui=" + cbDaGui + "&sessttim=" + sessttim + "&TraVe=" + TraVe);
                    }

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
            //Response.Redirect("http://portal.footgear.com.vn/?biennho="+langue);
            //Response.Redirect("http://"+linkWebPortal+"/");
          //  Response.Redirect("Default");
            Response.Redirect("~/presentationLayer/Default.aspx");
        }

        protected void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("~/presentationLayer/Default.aspx");
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

        protected void linkHome_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string congty = Session["congty"].ToString();
            string languege = Session["languege"].ToString();
           // Response.Redirect("http://"+linkWebPortal+"/pageMain2.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
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

        protected void LinkDaGui_Click(object sender, EventArgs e)
        {
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("http://"+linkWebPortal+"/");
            }
            Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
            if (nhanvien != null)
            {
                if (nhanvien.isSep == true)
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("Danhsachvanbandagui.aspx");
                }
                else
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("DanhsachvanbandaguiNV.aspx");
                }
            }
        }

        protected void linkPhanhoi_Click(object sender, EventArgs e)
        {
            
            string macongty = (string)Session["congty"];
            string manhanvien = (string)Session["user"];
            if (manhanvien == null && macongty == null)
            {
                Response.Redirect("http://" + linkWebPortal + "/");
            }
            Busers2 nhanvien = UserBUS.TimNhanVienTheoMa(manhanvien, macongty);
            if (nhanvien != null)
            {
                if (nhanvien.isSep == true)
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("DanhSachPhieuChuaDuyetBiTraVeCB.aspx");
                }
                else
                {
                    Session["user"] = manhanvien;
                    Session["UserID"] = manhanvien;
                    Response.Redirect("DanhSachPhieuChuaDuyetBiTraVe.aspx");
                }
            }
        }

       
    }
}