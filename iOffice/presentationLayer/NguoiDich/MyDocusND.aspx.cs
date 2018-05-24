using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class MyDocusND :LanguegeBus
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string UserID = (string)Request["UserID"];
                string macongty = (string)Request["congty"];
                string languege = (string)Request["languege"];
                if (UserID == null)
                {
                    Session.RemoveAll();
                    Response.Redirect("http://portal.footgear.com.vn/");
                }
               
                if (UserID != null && macongty != null && languege != null)
                {
                    Session["user"] = UserID;
                    Session["UserID"] = UserID;
                    Session["languege"] = languege;
                    Session["congty"] = macongty;
                }
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(24, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoGridView();
                string cbChuadich=(string)Request["cbChuaDich"];
                string cbDaDich = (string)Request["cbDaDich"];
                string fromdate = (string)Request["FromDate"];
                string todate = (string)Request["ToDate"];
                if (cbChuadich == null && cbDaDich == null && fromdate == null && todate == null)
                {
                    DataTable dt = dal.QryPhieuChoDich(UserID, macongty);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    DateTime FromDate=DateTime.Parse(fromdate);
                    DateTime ToDate=DateTime.Parse(todate);
                    DataTable dtphieu = dal.QryPhieuTheoDieuKienCuaNguoiDich(UserID, macongty, FromDate, ToDate);
                    if (dtphieu.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtphieu;
                        GridView1.DataBind();
                    }
                }
            }
        }
        public override void GanNgonNguVaoGridView()
        {
            GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["pdno24"].ToString();
            GridView1.Columns[4].HeaderText = hasLanguege["mytitle24"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["DepName"].ToString();
            GridView1.Columns[8].HeaderText = hasLanguege["USERNAME24"].ToString();
            GridView1.Columns[9].HeaderText = hasLanguege["CFMDate24"].ToString();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSoPhieu");
            //string macongty = Session["congty"].ToString();
            //string UserID = Session["UserID"].ToString();
            //DataTable dt = dal.LayTrangThaiTheoBangPDNA(macongty, lblMaPhieu.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    lblTrangThai.Text = dt.Rows[0]["YnName"].ToString();
            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            string UserID = Session["user"].ToString();
            string macongty = Session["congty"].ToString();
            Session["maphieu"]=lblMaPhieu.Text.Trim();
            Label lblisPause = (Label)row.FindControl("lblisPause");
            string ispause = lblisPause.Text.Trim().ToLower();
            pdna timmaphieu = pnaDAO.TimVanBanTheoMa(lblMaPhieu.Text.Trim(), macongty, false);
            if (timmaphieu != null)
            {
                if (timmaphieu.Abtype == "PDN2")
                {
                    if (timmaphieu.trangthaidich == false)
                    {
                        Response.Redirect("frmSuaphieumuahangND.aspx");
                    }
                }
                else
                {
                    Response.Redirect("chitietphieuchuadichND.aspx");
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
                        lbtn1.Text = "Details";
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}