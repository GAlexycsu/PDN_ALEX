using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class danhsachphieuchuadichND : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
       
        public override void GanNgonNguVaoGridView()
        {
            GridView1.Columns[2].HeaderText = hasLanguege["pdno24"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["mytitle24"].ToString();
            GridView1.Columns[4].HeaderText = hasLanguege["USERNAME24"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["CFMDate24"].ToString();
        }
        private void HienThiDanhSachPhieuChuaDich()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryPhieuChoDichTheoNguoiDich(macongty, manguoidung);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
          
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lbl = (Label)row.FindControl("lblPdno");
            string maphieu = lbl.Text;
            Session["maphieu"] = maphieu;
            Label lblisPause = (Label)row.FindControl("lblisPause");
            string ispause = lblisPause.Text.Trim().ToLower();

                string macongty = Session["congty"].ToString();
                pdna timphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
                if (timphieu != null && timphieu.Abtype == "PDN2")
                {
                    if (ispause == "true")
                    {
                        Response.Redirect("ChiTietPhieuTraVeChuaDich2.aspx");
                    }
                    else
                    {
                        Response.Redirect("frmSuaphieumuahangND.aspx");
                    }
                }
                else
                {
                    if (ispause == "true")
                    {
                        Response.Redirect("ChiTietPhieuTraVeChuaDich1.aspx");
                    }
                    else
                    {
                        Response.Redirect("chitietphieuchuadichND.aspx");
                    }
                }
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             string languege = (string)Request["languege"];
                string UserID = (string)Request["UserID"];
                string idcongty = (string)Request["GSBH"];
               

                if (languege != null && UserID != null && idcongty != null )
                {
                    Session["languege"] = languege;
                    Session["congty"] = idcongty;
                    Session["user"] = UserID;
                    Session["UserID"] = UserID;
                }
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();

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
                HienThiDanhSachPhieuChuaDich();
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));
                    Label lbtn2 = ((Label)e.Row.FindControl("lblnoiDung"));
                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Phản Hồi";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";
                        lbtn2.Text = "反馈";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Details";
                        lbtn2.Text = "Feedback";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSachPhieuChuaDich();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;
            //string maphieu = row.Cells[0].Text;
            Label lblmaphieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPdno");
            Label lblUser = (Label)GridView1.Rows[e.RowIndex].FindControl("lblUserID");
            Session["maphieu"] = lblmaphieu.Text;
            Session["manguoitao"] = lblUser.Text;
            Response.Redirect("feedback.aspx");

        }
    }
}