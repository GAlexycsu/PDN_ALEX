using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;

namespace iOffice.presentationLayer.Users
{
    public partial class MyDocusNV : LanguegeBus
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string User = (string)Request["UserID"];
                string languege = (string)Request["languege"];
                if (User != null && languege != null)
                {
                    Session["user"] = User;
                    Session["UserID"] = User;
                    Session["languege"] = languege;
                }
                if (Session["user"] == null)
                {
                    Response.Redirect("http://portal.footgear.com.vn/");
                }
              
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(5, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoGridView();
                string UserID = (string)Session["UserID"];
                txtUserID.Text = UserID;
                string macongty = "LTY";
                Session["congty"] = macongty;

                string sNhap = (string)Session["checkNhap"];
                string sChuaDich = (string)Session["checkChuaDich"];
                string sDaDich = (string)Session["checkDaDich"];
                string sDaGui = (string)Session["checkDaGui"];
                string sDaKy = (string)Session["checkDaKy"];
                string sKhongKy = (string)Session["checkKhongKy"];
                string sFromDate = (string)Session["FromDate"];
                string sToDate = (string)Session["ToDate"];
                string sessionTim = (string)Request["sessttim"];
                string tkMaphieu = (string)Request["maphieu"];
                string sTraVe = (string)Session["checkTraVe"];

                if (tkMaphieu != null)
                {
                    Session["maphieu"] = tkMaphieu;
                }
                string maphieutk = (string)Session["maphieu"];
                if (maphieutk != null)
                {
                    string ngonngu = (string)Session["languege"];
                    if (sNhap != null && sChuaDich != null && sDaDich != null && sDaGui != null && sDaKy != null && sKhongKy != null && sTraVe != null && sFromDate != null && sToDate != null)
                    {
                        DateTime pTuNgay = DateTime.Parse(sFromDate);
                        DateTime pDenNgay = DateTime.Parse(sToDate);
                        int pNhap = int.Parse(sNhap);
                        int pChuaDich = int.Parse(sChuaDich);
                        int pDaDich = int.Parse(sDaDich);
                        int pDaGui = int.Parse(sDaGui);
                        int pDaKy = int.Parse(sDaKy);
                        int pKhongKy = int.Parse(sKhongKy);
                        int pTraVe = int.Parse(sTraVe);

                        if (ngonngu != null && ngonngu == "lbl_VN")
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                        else if (ngonngu != null && ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                        else
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                        Session["checkNhap"] = pNhap.ToString();
                        Session["checkChuaDich"] = pChuaDich.ToString();
                        Session["checkDaDich"] = pDaDich.ToString();
                        Session["checkDaGui"] = pDaGui.ToString();
                        Session["checkDaKy"] = pDaKy.ToString();
                        Session["checkKhongKy"] = pKhongKy.ToString();
                        Session["FromDate"] = sFromDate.ToString();
                        Session["ToDate"] = sToDate.ToString();
                        Session["sessttim"] = "thoat";
                        Session["checkTraVe"] = pTraVe.ToString();
                    }
                    else
                    {
                        if (ngonngu != null && ngonngu == "lbl_VN")
                        {
                            DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuVN(maphieutk, macongty, UserID);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                        else if (ngonngu != null && ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuTW(maphieutk, macongty, UserID);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();


                        }
                        else
                        {
                            DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuEN(maphieutk, macongty, UserID);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                    }
                    Session.Remove("maphieu");
                }
                else
                {
                    if (sessionTim != null)
                    {
                        Session["sessttim"] = sessionTim;
                    }
                    string ttim = (string)Session["sessttim"];
                    if (sNhap != null && sChuaDich != null && sDaDich != null && sDaGui != null && sDaKy != null && sKhongKy != null && ttim == "thoat")
                    {
                        Session["ktTroVe"] = "trove";
                        DateTime TuNgay = DateTime.Parse(sFromDate);
                        DateTime DenNgay = DateTime.Parse(sToDate);
                        int pNhap = int.Parse(sNhap);
                        int pChuaDich = int.Parse(sChuaDich);
                        int pDaDich = int.Parse(sDaDich);
                        int pDaGui = int.Parse(sDaGui);
                        int pDaKy = int.Parse(sDaKy);
                        int pKhongKy = int.Parse(sKhongKy);
                        int pTraVe = int.Parse(sTraVe);
                        string ngonngu = (string)Session["languege"];
                        if (ngonngu != null && ngonngu == "lbl_VN")
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, TuNgay, DenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }
                        else if (ngonngu != null && ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, TuNgay, DenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();


                        }
                        else
                        {
                            DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, UserID, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, TuNgay, DenNgay);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                        }

                    }
                    else
                    {
                        string cbNhap = (string)Request["cbNhap"];
                        string cbChuaDich = (string)Request["cbChuaDich"];
                        string cbDaDich = (string)Request["cbDaDich"];
                        string cbDaKy = (string)Request["cbDaKy"];
                        string cbKhongKy = (string)Request["cbKhongKy"];
                        string cbDaGui = (string)Request["cbDaGui"];
                        string cbTraVe = (string)Request["TraVe"];
                        string FromDate = (string)Request["FromDate"];
                        string ToDate = (string)Request["ToDate"];

                        //  Session["ktTroVe"] = "trove";

                        DateTime pTuNgay, pDenNgay;
                        if (FromDate == null)
                        {
                            pTuNgay = DateTime.Today;
                        }
                        else
                        {
                            pTuNgay = DateTime.Parse(FromDate);
                        }
                        if (ToDate == null)
                        {
                            pDenNgay = DateTime.Today;
                        }
                        else
                        {
                            pDenNgay = DateTime.Parse(ToDate);
                        }
                        int checkNhap; int checkChuaDich, checkDaDich, checkDaKy, checkKhongKy;
                        int checkDaGui, checkTraVe;
                        if (cbNhap == null && cbDaDich == null && cbDaKy == null && cbKhongKy == null)
                        {
                            //DateTime tungay = DateTime.Today;
                            //DateTime denngay = DateTime.Today;

                            //string pNgonNgu = (string)Session["ngonngu"];
                            //if (pNgonNgu != null && pNgonNgu == "lbl_VN")
                            //{
                            //    DataTable dt1 = dal.QryPhieuDaKyDaDich(macongty, UserID, tungay, denngay);
                            //    if (dt1.Rows.Count > 0)
                            //    {

                            //        GridView1.DataSource = dt1;
                            //        GridView1.DataBind();
                            //    }
                            //    else
                            //    {

                            //        DataTable dtPhieu = dal.QryPhieuDaDich(macongty, UserID);
                            //        if (dtPhieu.Rows.Count > 0)
                            //        {

                            //            GridView1.DataSource = dtPhieu;
                            //            GridView1.DataBind();
                            //        }

                            //    }
                            //}
                            //else if (pNgonNgu != null && pNgonNgu == "lbl_TW")
                            //{
                            //    DataTable dt2 = dal.QryPhieuDaKyDaDichTW(macongty, UserID, tungay, denngay);
                            //    if (dt2.Rows.Count > 0)
                            //    {

                            //        GridView1.DataSource = dt2;
                            //        GridView1.DataBind();
                            //    }
                            //    else
                            //    {

                            //        DataTable dtPhieu = dal.QryPhieuDaDichTW(macongty, UserID);
                            //        if (dtPhieu.Rows.Count > 0)
                            //        {

                            //            GridView1.DataSource = dtPhieu;
                            //            GridView1.DataBind();
                            //        }

                            //    }
                            //}
                            //else
                            //{
                            //    DataTable dt1 = dal.QryPhieuDaKyDaDichEN(macongty, UserID, tungay, denngay);
                            //    if (dt1.Rows.Count > 0)
                            //    {

                            //        GridView1.DataSource = dt1;
                            //        GridView1.DataBind();
                            //    }
                            //    else
                            //    {
                            //        DataTable dtPhieu = dal.QryPhieuDaDichEN(macongty, UserID);
                            //        if (dtPhieu.Rows.Count > 0)
                            //        {

                            //            GridView1.DataSource = dtPhieu;
                            //            GridView1.DataBind();
                            //        }

                            //    }
                            //}
                        }
                        else
                        {

                            #region Set
                            if (cbNhap == "True")
                            {
                                checkNhap = 5;
                            }
                            else
                            {
                                checkNhap = 9;
                            }
                            if (cbChuaDich == "True")
                            {
                                checkChuaDich = 3;
                            }
                            else
                            {
                                checkChuaDich = 9;
                            }
                            if (cbDaDich == "True")
                            {
                                checkDaDich = 6;
                            }
                            else
                            {
                                checkDaDich = 9;
                            }
                            if (cbDaKy == "True")
                            {
                                checkDaKy = 8;
                            }
                            else
                            {
                                checkDaKy = 9;
                            }
                            if (cbKhongKy == "True")
                            {
                                checkKhongKy = 2;
                            }
                            else
                            {
                                checkKhongKy = 9;
                            }
                            if (cbDaGui == "True")
                            {
                                checkDaGui = 4;
                            }
                            else
                            {
                                checkDaGui = 9;
                            }
                            if (cbTraVe == "True")
                            {
                                checkTraVe = 12;
                            }
                            else
                            {
                                checkTraVe = 9;
                            }
                            #endregion
                            string ngonngu = (string)Session["languege"];
                            if (ngonngu != null && ngonngu == "lbl_VN")
                            {
                                DataTable dt = dal.QryPhieuTheoNguoiTao1(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui, checkTraVe, FromDate, ToDate);
                                //public DataTable QryPhieuTheoNguoiTao1(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6, int Yn4, string FromDate, string ToDate)
                                if (dt.Rows.Count > 0)
                                {

                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    Session["ktTroVe"] = "trove";
                                }

                            }
                            else if (ngonngu != null && ngonngu == "lbl_TW")
                            {
                                DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui, checkTraVe, pTuNgay, pDenNgay);
                                if (dt.Rows.Count > 0)
                                {

                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    Session["ktTroVe"] = "trove";
                                }


                            }
                            else
                            {
                                DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui, checkTraVe, pTuNgay, pDenNgay);
                                if (dt.Rows.Count > 0)
                                {

                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    Session["ktTroVe"] = "trove";
                                }

                            }
                            Session["checkNhap"] = checkNhap.ToString();
                            Session["checkChuaDich"] = checkChuaDich.ToString();
                            Session["checkDaDich"] = checkDaDich.ToString();
                            Session["checkDaGui"] = checkDaGui.ToString();
                            Session["checkDaKy"] = checkDaKy.ToString();
                            Session["checkKhongKy"] = checkKhongKy.ToString();
                            Session["FromDate"] = FromDate.ToString();
                            Session["ToDate"] = ToDate.ToString();
                            Session["sessttim"] = "thoat";
                            Session["checkTraVe"] = checkTraVe.ToString();
                        }
                    }

                }
            }
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[11].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();

            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[11].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[11].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSoPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            DataTable dt = dal.LayTrangThaiTheoBangPDNA(macongty, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                //lblTrangThai.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            pdna timmaphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), UserID, macongty, false);
            if (timmaphieu != null)
            {
                if (timmaphieu.Abtype == "PDN2")
                {
                    if (timmaphieu.YN == 5)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmSuaphieumuahangNV.aspx");
                    }
                    else if (timmaphieu.YN == 6)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmChitietphieumuahangdichNV.aspx");
                    }
                    else if (timmaphieu.YN == 3)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timmaphieu.YN == 2)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timmaphieu.YN == 1)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("phieumuahangNV.aspx");
                    }

                }
                else
                {
                    if (timmaphieu.YN == 5)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("chitietphieuchuadichNV.aspx");

                    }
                    else if (timmaphieu.YN == 6)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("chitietphieudadichNV.aspx");
                    }
                    else if (timmaphieu.YN == 3)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timmaphieu.YN == 2)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timmaphieu.YN == 1)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                }
            }
        }

        

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            pdna timmaphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), UserID, macongty, false);
            if (timmaphieu != null)
            {
                if (timmaphieu.Abtype == "PDN2")
                {
                    if (timmaphieu.YN == 5)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmSuaphieumuahangNV.aspx");
                    }
                    else if (timmaphieu.YN == 6)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmChitietphieumuahangdichNV.aspx");
                    }
                    else if (timmaphieu.YN == 3)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timmaphieu.YN == 2)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timmaphieu.YN == 1)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timmaphieu.YN == 4)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("chitietphieugui2NV.aspx");
                    }
                    else if (timmaphieu.YN == 12)
                    {
                        Session["MaPhieu"] = lblMaPhieu.Text.Trim();
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("ChiTietPhieuBiHuy2.aspx");
                    }

                }
                else
                {
                    if (timmaphieu.YN == 5)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                       // Response.Redirect("chitietphieuchuadichNV.aspx");
                        Server.Transfer("chitietphieuchuadichNV.aspx");

                    }
                    else if (timmaphieu.YN == 6)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                       // Response.Redirect("chitietphieudadichNV.aspx");
                        Server.Transfer("chitietphieudadichNV.aspx");
                    }
                    else if (timmaphieu.YN == 3)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                       // Response.Redirect("FrmView.aspx");
                        Server.Transfer("FrmView.aspx");
                    }
                    else if (timmaphieu.YN == 2)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timmaphieu.YN == 1)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timmaphieu.YN == 4)
                    {
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        //Response.Redirect("chitietphieugui1NV.aspx");
                        Server.Transfer("chitietphieugui1NV.aspx");

                    }
                    else if (timmaphieu.YN == 12)
                    {
                        Session["MaPhieu"] = lblMaPhieu.Text.Trim();
                        Session["maphieu"] = lblMaPhieu.Text.Trim();
                        Session["loaiphieu"] = timmaphieu.Abtype;
                        Response.Redirect("ChiTietPhieuHuy1.aspx");
                       
                    }
                }
            }
        }

       

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));

                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";

                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Detail";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

           
                
            
        }
    }
}