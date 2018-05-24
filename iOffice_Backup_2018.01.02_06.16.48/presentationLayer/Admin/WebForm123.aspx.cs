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
    public partial class WebForm123 : LanguegeBus
    {
        userDAL dalUser = new userDAL();
        dalPDN dal = new dalPDN();
        departDAL dalD = new departDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
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
              string UserID = (string)Session["user"];
              if (UserID == null)
              {
                  Response.Redirect("http://portal.footgear.com.vn/");
              }
              DataTable dt = dalD.GetDate();
              string date = dt.Rows[0]["NgayThang"].ToString();
              DateTime a = DateTime.Parse(date.ToString());
              txtFromDate.Text = a.ToString("yyyy/MM/dd");
              txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
             
              GanNgonNguVaoGridView();
          }
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["lblNguoiTao"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[12].HeaderText = hasLanguege["lblAuditor"].ToString();

            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[1].HeaderText = hasLanguege["lblNguoiTao"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView2.Columns[12].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["lblNguoiTao"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["lblAbStep"].ToString();
                GridView1.Columns[12].HeaderText = hasLanguege["lblAuditor"].ToString();
            }
        }
        public void HienThiDanhSach()
        {
            string ngonngu = Session["languege"].ToString();
            string congty = "LTY";
            int YnDuyet;
            int YnKhongDuyet;
            if (cbOk.Checked == true)
            {
                YnDuyet = 8;
            }
            else
            {
                YnDuyet = 9;
            }
            if (cbNoOk.Checked == true)
            {
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
                        divGrid2.Visible = false;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["UserIDTK"] = "All";
                    }
                }
                else
                {
                    if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUserTW(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                            divGrid2.Visible = true;
                            divGrid1.Visible = false;
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            Session["UserIDTK"] = "All";
                        }
                    }
                    else
                    {
                        DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                        if (dt.Rows.Count > 0)
                        {
                            divGrid1.Visible = true;
                            divGrid2.Visible = false;
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = "All";
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
                            divGrid1.Visible = true;
                            divGrid2.Visible = false;
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = UserIDTK;
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUserTW(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid2.Visible = true;
                                divGrid1.Visible = false;
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid1.Visible = true;
                                divGrid2.Visible = false;
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
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
                            divGrid1.Visible = true;
                            divGrid2.Visible = false;
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = "All";
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUserTW(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid2.Visible = true;
                                divGrid1.Visible = false;
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                Session["UserIDTK"] = "All";
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoAllUser(congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid1.Visible = true;
                                divGrid2.Visible = false;
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = "All";
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
                            divGrid1.Visible = true;
                            divGrid2.Visible = false;
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["UserIDTK"] = UserIDTK;
                        }
                    }
                    else
                    {
                        if (ngonngu == "lbl_TW")
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUserTW(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid2.Visible = true;
                                divGrid1.Visible = false;
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                            }
                        }
                        else
                        {
                            DataTable dt = dal.AdminTimKiemDanhSachPhieuTheoUser(UserIDTK, congty, YnDuyet, YnKhongDuyet, fromdate, todate);
                            if (dt.Rows.Count > 0)
                            {
                                divGrid1.Visible = true;
                                divGrid2.Visible = false;
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                Session["UserIDTK"] = UserIDTK;
                            }
                        }
                    }
                }
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            string ngongu = Session["languege"].ToString();
            if (ngongu == "lbl_VN" || ngongu == "lbl_EN")
            {
                this.GridView1.AllowPaging = false;
                this.GridView1.AllowSorting = false;
                this.GridView1.EditIndex = -1;
                this.GridView1.Columns[0].Visible = false;
                this.GridView1.Columns[6].Visible = false;
                this.GridView1.Columns[8].Visible = false;
                this.GridView1.Columns[11].Visible = false;

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
            else
            {
                this.GridView2.AllowPaging = false;
                this.GridView2.AllowSorting = false;
                this.GridView2.EditIndex = -1;
                this.GridView2.Columns[0].Visible = false;
                this.GridView2.Columns[6].Visible = false;
                this.GridView2.Columns[8].Visible = false;
                this.GridView2.Columns[11].Visible = false;
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
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}