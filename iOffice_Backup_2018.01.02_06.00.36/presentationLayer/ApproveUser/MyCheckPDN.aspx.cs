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
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class MyCheckPDN : LanguegeBus
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
           
            if (!IsPostBack)
            {
                string UserID1 = (string)Request["UserID"];
                string languege = (string)Request["languege"];
                
                string gsbh = "LTY";
                if (UserID1 != null && languege != null)
                {
                    Session["UserID"] = UserID1;
                    Session["user"] = UserID1;
                    Session["languege"] = languege;
                }
                Session["congty"] = gsbh;
                string UserID = (string)Session["UserID"];
                //string UserID = (string)Request["UserID"];
                if (Session["UserID"] == null)
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
               
                string waitme = (string)Request["waitme"];
                string okme = (string)Request["okme"];
                string nookme = (string)Request["nookme"];
               
                string ngaybatdau = (string)Request["ngaybatdau"];
                string ngayketthuc = (string)Request["ngayketthuc"];
                string ngongu = (string)Session["languege"];
                string sDaKy=(string)Session["checkYn1"]; 
                string sKhongKy=(string)Session["checkYn2"]; 
                string sChoKy=(string)Session["checkYn4"]; 
                string sNgayBatDau=(string)Session["ngaybatdau"]; 
                string sNgayKetThuc=(string)Session["ngayketthu"]; 
                string sessionTim = (string)Request["sessttim"];
                string tkMaphieu = (string)Request["maphieu"];
                if (tkMaphieu != null)
                {
                    Session["maphieu"] = tkMaphieu;
                }
                string maphieutk = (string)Session["maphieu"];
                if (maphieutk != null)
                {
                    if (sDaKy != null && sKhongKy != null && sChoKy != null && sNgayBatDau != null && sNgayKetThuc != null)
                    {
                        int pDaKy = int.Parse(sDaKy);
                        int pKhongKy = int.Parse(sKhongKy);
                        int pChoKy = int.Parse(sChoKy);
                        DateTime TuNgay = DateTime.Parse(sNgayBatDau);
                        DateTime DenNgay = DateTime.Parse(sNgayKetThuc);
                        if (ngongu != null && ngongu == "lbl_VN")
                        {
                            //DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<AbconTKVN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKien(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                               
                                GridView2.DataSource = listds;
                                GridView2.DataBind();

                            }
                            else
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyet(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                                
                            }
                        }
                        else if (ngongu != null && ngongu == "lbl_TW")
                        {
                            // DataTable dt = dal.QryPhieuPDNTheoNguoiDuyetTW(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<abconTKTW> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienTW(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                               
                                GridView2.DataSource = listds;
                                GridView2.DataBind();
                            }
                            else
                            {
                                List<Abcon3> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetTW(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               
                            }
                        }
                        else
                        {
                            // DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<AbconTKEN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienEN(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                               
                                GridView2.DataSource = listds;
                                GridView2.DataBind();

                            }
                            else
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetEN(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                    
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               
                            }
                        }
                    }
                    else
                    {
                        if (ngongu == "lbl_VN")
                        {
                            DataTable dt = dal.TimKiemPhieuTheoMaPhieuVaNguoiDuyetVN(maphieutk, gsbh, UserID);
                            if (dt.Rows.Count > 0)
                            {
                               
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                            }
                        }
                        else
                        {
                            if (ngongu == "lbl_TW")
                            {
                                DataTable dt = dal.TimKiemPhieuTheoMaPhieuVaNguoiDuyetTW(maphieutk, gsbh, UserID);
                                if (dt.Rows.Count > 0)
                                {
                                   
                                    GridView2.DataSource = dt;
                                    GridView2.DataBind();
                                }
                            }
                            else
                            {
                                DataTable dt = dal.TimKiemPhieuTheoMaPhieuVaNguoiDuyetEN(maphieutk, gsbh, UserID);
                                if (dt.Rows.Count > 0)
                                {
                                   
                                    GridView2.DataSource = dt;
                                    GridView2.DataBind();
                                }
                            }
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
                    if (sDaKy != null && sKhongKy != null && sChoKy != null && sNgayBatDau != null && sNgayKetThuc != null && ttim == "thoat")
                    {
                        int pDaKy = int.Parse(sDaKy);
                        int pKhongKy = int.Parse(sKhongKy);
                        int pChoKy = int.Parse(sChoKy);
                        DateTime TuNgay = DateTime.Parse(sNgayBatDau);
                        DateTime DenNgay = DateTime.Parse(sNgayKetThuc);
                        if (ngongu != null && ngongu == "lbl_VN")
                        {
                            //DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<AbconTKVN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKien(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                              
                                GridView2.DataSource = listds;
                                GridView2.DataBind();

                            }
                            else
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyet(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               
                            }
                        }
                        else if (ngongu != null && ngongu == "lbl_TW")
                        {
                            // DataTable dt = dal.QryPhieuPDNTheoNguoiDuyetTW(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<abconTKTW> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienTW(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                               
                                GridView2.DataSource = listds;
                                GridView2.DataBind();
                            }
                            else
                            {
                                List<Abcon3> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetTW(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                                
                            }
                        }
                        else
                        {
                            // DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, TuNgay, DenNgay, sDaKy, sKhongKy, sChoKy);
                            List<AbconTKEN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienEN(UserID, gsbh, TuNgay, DenNgay, pDaKy, pKhongKy, pChoKy);
                            if (listds.Count > 0)
                            {
                                
                                GridView2.DataSource = listds;
                                GridView2.DataBind();

                            }
                            else
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetEN(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               
                            }
                        }
                    }
                    else
                    {
                        if (waitme == null && okme == null && nookme == null)
                        {
                            if (ngongu != null && ngongu == "lbl_VN")
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyet(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                    
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               

                            }
                            else if (ngongu != null && ngongu == "lbl_TW")
                            {
                                List<Abcon3> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetTW(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                  
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                               
                            }
                            else
                            {
                                List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetEN(UserID, gsbh);
                                if (list.Count > 0)
                                {
                                   
                                    GridView2.DataSource = list;
                                    GridView2.DataBind();
                                }
                                
                            }
                        }
                        else
                        {
                            HienThiDanhSach();
                        }
                    }
                }
            }
        }
        public void HienThiDanhSach()
        {
            string waitme = (string)Request["waitme"];
            string okme = (string)Request["okme"];
            string nookme = (string)Request["nookme"];
            
            //string UserID = (string)Request["UserID"];
            string UserID = (string)Session["UserID"];
            string ngaybatdau = (string)Request["ngaybatdau"];
            string ngayketthuc = (string)Request["ngayketthuc"];
            //string languege=(string)Request["languege"];
            string ngongu = (string)Session["languege"];
            string gsbh = "LTY";
            //Session["UserID"] = UserID;
            //Session["congty"] = gsbh;
            //Session["languege"] = languege;
            string checkYn1 = "", checkYn2 = "", checkYn4 = "";
           
            #region chu thich
            if (waitme == "false" && okme == "false" && nookme == "false" )
            {
                checkYn1 = "1";
                checkYn2 = "2";
                checkYn4 = "4";

            }
            else
            {
                if (waitme == "true" && okme == "true" && nookme == "true")
                {
                    checkYn1 = "1";
                    checkYn2 = "2";
                    checkYn4 = "4";

                }
                else
                {
                    if (okme != null && okme == "true")
                    {
                        checkYn1 = "1";
                    }
                    else
                    {
                        checkYn1 = "9";
                    }
                    if (nookme != null && nookme == "true")
                    {
                        checkYn2 = "2";
                    }
                    else
                    {
                        checkYn2 = "9";
                    }
                    if (waitme != null && waitme == "true")
                    {
                        checkYn4 = "4";
                    }
                    else
                    {
                        checkYn4 = "9";
                    }

                }
            }
#endregion
            DateTime pTuNgay = DateTime.Parse(ngaybatdau);
            DateTime pDenNgay = DateTime.Parse(ngayketthuc);
            int yn1 = int.Parse(checkYn1);
            int yn2 = int.Parse(checkYn2);
            int yn4 = int.Parse(checkYn4);
            if (ngongu != null && ngongu == "lbl_VN")
            {
                //DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, pTuNgay, pDenNgay, checkYn1, checkYn2, checkYn4);
                List<AbconTKVN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKien(UserID, gsbh, pTuNgay, pDenNgay, yn1, yn2, yn4);
                if (listds.Count > 0)
                {
                   
                    GridView2.DataSource = listds;
                    GridView2.DataBind();

                }
                //else
                //{
                //    List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyet(UserID, gsbh);
                //    if (list.Count > 0)
                //    {
                //        DivGrid2.Visible = true;
                //        DivGrid1.Visible = false;
                //        GridView2.DataSource = list;
                //        GridView2.DataBind();
                //    }
                //    else
                //    {
                //        DivGrid1.Visible = false;
                //        DivGrid2.Visible = false;
                //    }
                //}
            }
            else if (ngongu != null && ngongu == "lbl_TW")
            {
                //DataTable dt = dal.QryPhieuPDNTheoNguoiDuyetTW(UserID, gsbh, pTuNgay, pDenNgay, checkYn1, checkYn2, checkYn4);
                List<abconTKTW> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienTW(UserID, gsbh, pTuNgay, pDenNgay, yn1, yn2, yn4);
                if (listds.Count > 0)
                {
                   
                    GridView2.DataSource = listds;
                    GridView2.DataBind();
                }
                //else
                //{
                //    List<Abcon3> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetTW(UserID, gsbh);
                //    if (list.Count > 0)
                //    {
                //        DivGrid1.Visible = true;
                //        DivGrid2.Visible = false;
                //        GridView1.DataSource = list;
                //        GridView1.DataBind();
                //    }
                //    else
                //    {
                //        DivGrid1.Visible = false;
                //        DivGrid2.Visible = false;
                //    }
                //}
            }
            else
            {
               // DataTable dt = dal.QryPhieuPDNTheoNguoiDuyet(UserID, gsbh, pTuNgay, pDenNgay, checkYn1, checkYn2, checkYn4);
                List<AbconTKEN> listds = AbconDAO.TimKiemDanhSachPhieuTheoDieuKienEN(UserID, gsbh, pTuNgay, pDenNgay, yn1, yn2, yn4);
                if (listds.Count > 0)
                {
                   
                    GridView2.DataSource = listds;
                    GridView2.DataBind();

                }
                //else
                //{
                //    List<Abcon2> list = AbconDAO.QryPhieuChoDuyetTheoNguoiDuyetEN(UserID, gsbh);
                //    if (list.Count > 0)
                //    {
                //        DivGrid2.Visible = true;
                //        DivGrid1.Visible = false;
                //        GridView2.DataSource = list;
                //        GridView2.DataBind();
                //    }
                //    else
                //    {
                //        DivGrid1.Visible = false;
                //        DivGrid2.Visible = false;
                //    }
                //}
            }
            Session["checkYn1"] = checkYn1.ToString();
            Session["checkYn2"] = checkYn2.ToString();
            Session["checkYn4"] = checkYn4.ToString();
            Session["ngaybatdau"] = ngaybatdau.ToString();
            Session["ngayketthu"] = ngayketthuc.ToString();
            Session["sessttim"] = "thoat";
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                //GridView2.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                //GridView1.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView2.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }


        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        //lbtn1.Text = "Details";
                        lbtn2.Text = "Details";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string gsbh = "LTY";
            //string UserID = "22343";
            string UserID = Session["UserID"].ToString();
            Label lblPDNO = (Label)GridView2.Rows[e.RowIndex].FindControl("lblpdno");
            DataTable dt = dal.LayTrangThaiCuaPhieuChoDuyet(lblPDNO.Text, UserID, gsbh);
            if (dt.Rows.Count > 0)
            {
                //lblTrangThai2.Text = dt.Rows[0]["YnName"].ToString();
            }

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            string macongty = Session["congty"].ToString();
            string maNV = Session["UserID"].ToString();
            Label lblMaPhieu = (Label)row.FindControl("lblpdno");
            Session["maphieu"] = lblMaPhieu.Text.Trim();
            Abcon timphieu = AbconDAO.TimMaPhieuTheoNguoiDuyet(lblMaPhieu.Text.Trim(), maNV, macongty);
            if (timphieu != null)
            {
                if (timphieu.abtype == "PDN2")
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("chitietphieumuahang.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                }
                else
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("frmDetails.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("frmDetails2D.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("frmDetails2D.aspx");
                    }
                }
            }

        }

       
       
    }
}