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
    public partial class MyDocusRe : LanguegeBus
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            if (!Page.IsPostBack)
            {
                string UserID = (string)Request["UserID"];
                string languege = (string)Request["languege"];
                if (UserID != null && languege != null)
                {
                    Session["languege"] = languege;
                    Session["UserID"] = UserID;
                    Session["user"] = UserID;
                }
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                
                string manguoidung = Session["user"].ToString();
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
                string GSBH = "LTY";
                if (GSBH != null)
                {
                    Session["congty"] = GSBH;
                }
                string macongty = (string)Session["congty"];
                if (macongty != null)
                {
                    Session["congty"] = macongty;
                }
               string sNhap=(string)Session["checkNhap"] ;
              string sChuaDich= (string)Session["checkChuaDich"];
                string sDaDich=(string)Session["checkDaDich"]; 
                string sDaGui=(string)Session["checkDaGui"]; 
                string sDaKy=(string)Session["checkDaKy"];
                string sKhongKy=(string)Session["checkKhongKy"];
                string sTraVe = (string)Session["checkTraVe"];
                string sFromDate=(string)Session["FromDate"];
               string sToDate=(string)Session["ToDate"];
               string sessionTim = (string)Request["sessttim"];
               string tkMaphieu = (string)Request["maphieu"];
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
                           DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);
                           
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                           
                       }
                       else if (ngonngu != null && ngonngu == "lbl_TW")
                       {
                           DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);
                          
                               
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                           

                       }
                       else
                       {
                           DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui, pTraVe, pTuNgay, pDenNgay);
                            
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
                           DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuVN(maphieutk, macongty, manguoidung);
                           
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                          
                       }
                       else if (ngonngu != null && ngonngu == "lbl_TW")
                       {
                           DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuTW(maphieutk, macongty, manguoidung);
                          
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                          

                       }
                       else
                       {
                           DataTable dt = dal.TimKiemPhieuTheoDKMaPhieuEN(maphieutk, macongty, manguoidung);
                           
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
                           DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui,pTraVe, TuNgay, DenNgay);
                          
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                           
                       }
                       else if (ngonngu != null && ngonngu == "lbl_TW")
                       {
                           DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui,pTraVe, TuNgay, DenNgay);
                          
                               GridView1.DataSource = dt;
                               GridView1.DataBind();
                           

                       }
                       else
                       {
                           DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, manguoidung, pKhongKy, pChuaDich, pDaKy, pNhap, pDaDich, pDaGui,pTraVe, TuNgay, DenNgay);
                          
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
                       string cbDagui = (string)Request["cbDaGui"];
                       string cbTraVe=(string)Request["TraVe"];
                       string FromDate = (string)Request["FromDate"];
                       string ToDate = (string)Request["ToDate"];

                       if (cbNhap == null && cbChuaDich == null)
                       {
                           //DateTime PTungay = DateTime.Today;
                           //DateTime PDenNgay = DateTime.Today;

                           //string pNgonNgu = (string)Session["ngonngu"];
                           //if (pNgonNgu == null)
                           //{
                           //    if (pNgonNgu == "lbl_VN")
                           //    {
                           //        DataTable dt1 = dal.QryPhieuDaKyDaDich(GSBH, manguoidung, PTungay, PDenNgay);
                                  
                           //            GridView1.DataSource = dt1;
                           //            GridView1.DataBind();
                                  
                                  
                           //    }
                           //    else if (pNgonNgu == "lbl_TW")
                           //    {
                           //        DataTable dt2 = dal.QryPhieuDaKyDaDichTW(GSBH, manguoidung, PTungay, PDenNgay);
                                   
                           //            GridView1.DataSource = dt2;
                           //            GridView1.DataBind();
                                  
                           //    }
                           //    else
                           //    {
                           //        DataTable dt1 = dal.QryPhieuDaKyDaDichEN(GSBH, manguoidung, PTungay, PDenNgay);
                                   
                           //            GridView1.DataSource = dt1;
                           //            GridView1.DataBind();
                                  
                           //    }
                           //}
                       }
                       else
                       {
                           DateTime pTuNgay = DateTime.Parse(FromDate);
                           DateTime pDenNgay = DateTime.Parse(ToDate);
                           int checkNhap, checkChuaDich, checkDaDich, checkDaKy, checkKhongKy;
                           int checkDaGui,checkTraVe;
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
                           if (cbDagui == "True")
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
                               DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, manguoidung, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui,checkTraVe, pTuNgay, pDenNgay);
                              
                                   GridView1.DataSource = dt;
                                   GridView1.DataBind();
                               
                           }
                           else if (ngonngu != null && ngonngu == "lbl_TW")
                           {
                               DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, manguoidung, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui,checkTraVe, pTuNgay, pDenNgay);
                              
                                   GridView1.DataSource = dt;
                                   GridView1.DataBind();
                              

                           }
                           else
                           {
                               DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, manguoidung, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich, checkDaGui,checkTraVe, pTuNgay, pDenNgay);
                              
                                   GridView1.DataSource = dt;
                                   GridView1.DataBind();
                               
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
                GridView1.Columns[11].HeaderText=hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();

            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[11].HeaderText=hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                   GridView1.Columns[11].HeaderText=hasLanguege["NameABC"].ToString();
                GridView1.Columns[13].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            string cbNhap = (string)Request["cbNhap"];
            string cbChuaDich = (string)Request["cbChuaDich"];
            string cbDaDich = (string)Request["cbDaDich"];
            string cbDaKy = (string)Request["cbDaKy"];
            string cbKhongKy = (string)Request["cbKhongKy"];
            string cbDaGui = (string)Request["cbDaGui"];
            string cbTraVe = (string)Request["TraVe"];
            string FromDate = (string)Request["FromDate"];
            string ToDate = (string)Request["ToDate"];
            DateTime pTuNgay = DateTime.Parse(FromDate);
            DateTime pDenNgay = DateTime.Parse(ToDate);
            int checkNhap , checkChuaDich , checkDaDich , checkDaKy , checkKhongKy ;
            int checkDaGui, checkTraVe;
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
                checkDaKy = 1;
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
                DataTable dt = dal.QryPhieuTheoNguoiTao(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich,checkDaGui,checkTraVe, pTuNgay, pDenNgay);
                
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
               
            }
            else if (ngonngu != null && ngonngu == "lbl_TW")
            {
                DataTable dt = dal.QryPhieuTheoNguoiTaoTW(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich,checkDaGui,checkTraVe, pTuNgay, pDenNgay);
                
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
               

            }
            else
            {
                DataTable dt = dal.QryPhieuTheoNguoiTaoEN(macongty, UserID, checkKhongKy, checkChuaDich, checkDaKy, checkNhap, checkDaDich,checkDaGui,checkTraVe, pTuNgay, pDenNgay);
               
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                
            }

        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            HienThiDanhSach();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSoPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            DataTable dt = dal.LayTrangThaiTheoBangPDNA(macongty, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                //lblTrangThai1.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            Label lblMaloaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            pdna timphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), UserID, macongty, false);
            Session["maphieu"] = timphieu.pdno;
            Session["loaiphieu"] = lblMaloaiPhieu.Text.Trim();
            if (timphieu != null)
            {
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahang.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmChitietphieumuahangdich.aspx");
                    }
                    else if (timphieu.YN == 4)
                    {
                        
                        Response.Redirect("chitietphieugui2.aspx");
                    }
                    else if (timphieu.YN == 12)
                    {
                        Session["MaPhieu"] = lblMaPhieu.Text.Trim();
                        Response.Redirect("ChiTietPhieuBiHuyCB2.aspx");
                    }

                }
                else
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadich.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadich.aspx");
                    }
                    else if (timphieu.YN == 4)
                    {

                        Response.Redirect("chitietphieugui1.aspx");
                    }
                    else if (timphieu.YN == 12)
                    {
                        Session["MaPhieu"] = lblMaPhieu.Text.Trim();
                        Response.Redirect("ChiTietPhieuHuyCB1.aspx");
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
                    //LinkButton lbtn1 = ((LinkButton)e.Row.Cells[1].Controls[0]);
                    Label lbtn2 = ((Label)e.Row.FindControl("lblDeTails"));
                    if (ngonngu == "lbl_VN")
                    {
                        //  lbtn1.Text = "Trạng Thái";
                        lbtn2.Text = "Chi Tiết";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        //lbtn1.Text = "状态";
                        lbtn2.Text = "详情";

                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        //lbtn1.Text = "Status";
                        lbtn2.Text = "Details";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        
    }
