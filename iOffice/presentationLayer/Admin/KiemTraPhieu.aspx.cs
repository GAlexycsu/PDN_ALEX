using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class KiemTraPhieu : LanguegeBus
    {
        userDAL dalUser = new userDAL();
        dalPDN dal = new dalPDN();
        departDAL dalD = new departDAL();
      
        public override void GanNgonNguVaoGridView()
        {

           
                GridView1.Columns[1].HeaderText = hasLanguege["lblNguoiTao"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
                GridView1.Columns[10].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[12].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[14].HeaderText = hasLanguege["lblAuditor"].ToString();

            
        }
        public void HienThiDanhSach()
        {
            string ngonngu = Session["languege"].ToString();
            string congty = "LTY";
            string checkOk;
            string checkNoOk;
            int YnDuyet;
            int YnKhongDuyet;
            if (cbOk.Checked == true)
            {
                YnDuyet = 8;
                checkOk = "ok";
                Session["checkOk"] = checkOk;
            }
            else
            {
                YnDuyet = 9;
            }
            if (cbNoOk.Checked == true)
            {
                checkNoOk = "nook";
                Session["checkNoOk"] = checkNoOk;
                YnKhongDuyet = 2;
            }
            else
            {
                YnKhongDuyet = 9;
            }
            string fromdate = txtFromDate.Text.Trim();
            string todate = txtToDate.Text.Trim();
            if (txtTimKiem.Text.Trim() == "")
            {
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                    if (dt.Rows.Count > 0)
                    {
                        divGrid1.Visible = true;
                       
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["UserIDTK"] = "All";
                        btnReject.Visible = true;
                        btnExportExcel.Visible = true;
                    }
                }
                else
                {
                    if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUserTW(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                            
                            
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = "All";
                            btnReject.Visible = true;
                            btnExportExcel.Visible = true;
                        }
                    }
                    else
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                            
                           
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = "All";
                            btnReject.Visible = true;
                            btnExportExcel.Visible = true;
                        }
                    }
                }
            }
            else
            {
                string UserIDTK = txtTimKiem.Text.Trim();
                DataTable dtUser = dalUser.TimNhanVienTheoMa(congty, UserIDTK);
                if (dtUser.Rows.Count > 0)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                           
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = UserIDTK;
                            btnReject.Visible = true;
                            btnExportExcel.Visible = true;
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUserTW(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                              
                              
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid1.Visible = true;
                                
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                    }
                    Session["fromdate"] = fromdate;
                    Session["todate"] = todate;
                    Session["YnDuyet"] = YnDuyet.ToString();
                    Session["YnKhongDuyet"] = YnKhongDuyet.ToString();

                }
                else
                {
                    lblThongBao.Text = "UserID incorect, please try again!";
                }
            }
        }
  
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string congty = "LTY";
            string ngonngu = Session["languege"].ToString();
            string fromdate = (string)Session["fromdate"];
            string todate = (string)Session["todate"];
            string ynD = (string)Session["YnDuyet"];
            string ynNoOK = (string)Session["YnKhongDuyet"];
            string UserIDTK = (string)Session["UserIDTK"];
            if (fromdate != null && todate != null && ynD != null && ynNoOK != null && UserIDTK != null)
            {
                int YnDuyet = int.Parse(ynD);
                int YnKhongDuyet = int.Parse(ynNoOK);
                if (UserIDTK.Trim() == "All")
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                           
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = "All";
                            btnReject.Visible = true;
                            btnExportExcel.Visible = true;
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUserTW(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = "All";
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = "All";
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                            
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = UserIDTK;
                            btnReject.Visible = true;
                            btnExportExcel.Visible = true;
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUserTW(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                              
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                                btnReject.Visible = true;
                                btnExportExcel.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
           
            
                this.GridView1.AllowPaging = false;
                this.GridView1.AllowSorting = false;
                this.GridView1.EditIndex = -1;
                this.GridView1.Columns[0].Visible = false;
                this.GridView1.Columns[6].Visible = false;
                this.GridView1.Columns[8].Visible = false;
                this.GridView1.Columns[11].Visible = false;
                this.GridView1.Columns[14].Visible = false;
                // Let's bind data to GridView
                this.HienThiDanhSach();

                // Let's output HTML of GridView
                Response.Clear();
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("content-disposition",
                        "attachment;filename=MyList.xls");
                Response.Charset = "";
                StringWriter swriter = new StringWriter();
                HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
                GridView1.RenderControl(hwriter);
                Response.Write(swriter.ToString());
                Response.End();
           
           
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = (string)Session["user"];
            if (UserID == null)
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
          
             if (!IsPostBack)
             {
                 btnReject.Attributes["Onclick"] = "return confirm('Are you sure?')";
                 string checkOk = (string)Session["checkOk"];
                 string checkNoOK = (string)Session["checkNoOk"];
                 if (checkOk == null && checkNoOK == null)
                 {
                     cbOk.Checked = true;
                     cbNoOk.Checked = true;
                 }
                 else
                 {
                     if (checkNoOK == "nook")
                     {
                         cbNoOk.Checked = true;
                     }
                     else
                     {
                         cbNoOk.Checked = false;
                     }
                     if (checkOk == "ok")
                     {
                         cbOk.Checked = true;
                     }
                     else
                     {
                         cbOk.Checked = false;
                     }
                 }
                 DataTable dt = dalD.GetDate();
                 string date = dt.Rows[0]["NgayThang"].ToString();
                 DateTime a = DateTime.Parse(date.ToString());
                 txtFromDate.Text = a.ToString("yyyy/MM/dd");
                 txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                
                 btnExportExcel.Visible = false;
                 btnReject.Visible = false;
                 GanNgonNguVaoGridView();
             }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {

                CheckBox chec = (CheckBox)row.FindControl("checkChon");
                Label lblYn = (Label)row.FindControl("lblYn");
                int Yn = int.Parse(lblYn.Text.ToString().Trim());
                if (Yn == 8)
                {
                    chec.Enabled = false;
                }
                else
                {
                    chec.Enabled = true;
                }
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
           
            string macongty="LTY";
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chec = (CheckBox)row.FindControl("checkChon");
                if (chec.Checked == true)
                {
                    Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
                    string maphieu = lblMaPhieu.Text.Trim();
                    PDNSheetFlowBUS.XoaPDNSheetFlowBiHuy(maphieu, macongty);

                    AbconDAO.XoaPhieuBiHuy(maphieu, macongty);
                    TrangThaiDuyetDAO.XoaTrangThaiDuyetBiXoa(maphieu, macongty);
                    pnaDAO.CapNhatPhieuGuiBiHuy(maphieu, macongty);
                    lblThongBao.Text = " Reject success!";
                    HienThiDanhSach();
                }

            }
        }

        
    }
}