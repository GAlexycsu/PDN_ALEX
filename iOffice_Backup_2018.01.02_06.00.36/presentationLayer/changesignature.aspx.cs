using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice
{
    public partial class changesignature : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        userDAL dal = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(20,strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                string IDUser = (string)Request["UserID"];
                string cty = (string)Request["congty"];
                string lang = (string)Request["languege"];
                if (IDUser != null && cty != null && lang != null)
                {
                    Session["UserID"] = IDUser;
                    Session["user"] = IDUser;
                    Session["congty"] = cty;
                    Session["languege"] = lang;
                }
                string UserID = (string)Session["UserID"];
                string user = (string)Session["UserID"];
                if (user == null || UserID == null)
                {
                    string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
                    string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();

                    Response.Redirect("http://" + linkWebPortal + "/");

                }
                
               
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                //Busers2 user = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
                DataTable dt = dal.TimNhanVienTheoMa(macongty, manguoidung);
                if (dt.Rows.Count>0)
                {
                    txtUserID.Text = dt.Rows[0]["USERID"].ToString().Trim();
                    txtUseName.Text = dt.Rows[0]["USERNAME"].ToString();
                    Image1.Width = 150;
                    Image1.Height = 150;
                    Image1.ImageUrl = "~/changeSignature.ashx?USERID=" + dt.Rows[0]["USERID"].ToString().Trim();
                }
            }
           
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnChange.Text = hasLanguege["btnChange"].ToString();
            btnCancel.Text = hasLanguege["btnTroLai"].ToString();
        }
        private void HienThi()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            //Busers2 user = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
           //var list = db.ExecuteQuery<Busers2>("select * from Busers2 where USERID='" + manguoidung + "' and GSBH='" + macongty + "'");
            DataTable dt = dal.TimNhanVienTheoMa(macongty, manguoidung);
            if (dt.Rows.Count > 0)
            {
                
                    txtUserID.Text = dt.Rows[0]["USERID"].ToString().Trim();
                    txtUseName.Text = dt.Rows[0]["USERNAME"].ToString();
                    Image1.Width = 150;
                    Image1.Height = 150;
                    Image1.ImageUrl = "~/changeSignature.ashx?USERID=" + dt.Rows[0]["USERID"].ToString().Trim();
                
                
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileName.Trim() != "")
            {
                string macongty = "LTY";
                Busers2 user = new Busers2();
                user.USERID = txtUserID.Text.Trim();
                user.GSBH = macongty;
                byte[] fileByte = FileUpload1.FileBytes;
                Binary binaryObj = new Binary(fileByte);
                user.signatue = binaryObj;
                UserDAO.CapNhatNguoiDung(user);
                Image1.Width = 150;
                Image1.Height = 150;
                Image1.ImageUrl = "~/changeSignature.ashx?USERID=" + txtUserID.Text;
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //string user = (string)Session["user"];

            //string cty = (string)Session["congty"];
            //if (user == null)
            //{
            //    Response.Redirect("http://portal.footgear.com.vn/");
            //}
            //else
            //{
            //    Busers2 nguoidung = UserDAO.TimNhanVienTheoMa(user, cty);
            //    if (nguoidung != null && nguoidung.Admin == true)
            //    {
            //        Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
            //    }
            //    else
            //    {
            //        if (nguoidung != null && nguoidung.isSep == true)
            //        {
            //            Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
            //        }
            //        else
            //        {
            //            if (nguoidung.BADEPID == "VTY0501D")
            //            {
            //                Response.Redirect("~/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx");
            //            }
            //            else
            //            {
            //                Response.Redirect("~/presentationLayer/Users/Home.aspx");
            //            }
            //        }
            //    }
            //}

            string UserID = Session["UserID"].ToString();
            string congty = Session["congty"].ToString();
            string languege = Session["languege"].ToString();
           // Response.Redirect("http://portal.footgear.com.vn/pageMain.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);

           // Response.Redirect("http://portal.footgear.com.vn/pageMain.aspx");
            Response.Redirect("~/presentationLayer/pageMain2.aspx");
        }
    }
}