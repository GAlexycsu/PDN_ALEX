using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class danhsachvanbandaky : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null && Session["languege"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(9, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
           
            if (!IsPostBack)
            {
               
               
              
                GanNgonNguVaoGridView();
                HienThiDanhSach();
                
            }
            
        }
        private void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.QryVanBanDaKyTheoCapDuyet(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.QryVanBanDaKyTheoCapDuyetTW(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.QryVanBanDaKyTheoCapDuyetEN(manguoidung, macongty);
                GridView1.DataBind();
            }
           
        }
        public override void GanNgonNguVaoGridView()
        {
            //GridView1.HeaderRow.Cells[2].Text = hasLanguege["abname1"].ToString();
            //GridView1.HeaderRow.Cells[3].Text = hasLanguege["pdno1"].ToString();
            //GridView1.HeaderRow.Cells[4].Text = hasLanguege["mytitle11"].ToString();
            //GridView1.HeaderRow.Cells[5].Text = hasLanguege["YnName1"].ToString();
            //GridView1.HeaderRow.Cells[6].Text = hasLanguege["NameABC1"].ToString();
            //GridView1.HeaderRow.Cells[7].Text = hasLanguege["USERNAME1"].ToString();
            //GridView1.HeaderRow.Cells[8].Text = hasLanguege["DepName1"].ToString();
           
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle11"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName1"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle11"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName1"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle11"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName1"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manguoidung = Session["user"].ToString();
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[2].Text;
            Session["maphieu"] = maphieu;
            string loaiphieu = row.Cells[1].Text;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[3].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[7].Text;
            Session["bophan"] = bophan;
            Label lblMaDV = (Label)row.FindControl("lblMaDonVi");
            string mabophan = lblMaDV.Text.Trim();
            Session["mabophan"] = mabophan;
            Abcon chitietduyet = AbconBUS.LayChiTietXetDuyetTheoNhanVienDuyet(maphieu, manguoidung);

            if (chitietduyet.abtype == "PDN2")
            {
                Response.Redirect("phieumuahangD.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2D.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          
          //  //GridViewRow row = GridView1.SelectedRow;
          //  //string maphieu = row.Cells[3].Text;
          // string ab=GridView1.Controls[0].c
          ////  int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
          // // string maphieu = GridView1.DataKeys[e.RowIndex].Value.ToString();
          //  Abcon phieu = AbconDAO.LayPhieuTheoNguoiDuyet(Until.uNhanVien.USERID, macongty, maphieu);
          //  AbconDAO.XoaChiTiet(phieu.IDCT, true);
             string macongty=Session["congty"].ToString();
             string manguoidung = Session["user"].ToString();
            string maphieu = (string)GridView1.Rows[e.RowIndex].Cells[3].Text;
            Abcon phieu = AbconDAO.TimMaPhieuTheoNguoiDuyet(maphieu, manguoidung, macongty);
            AbconDAO.CapNhatPhieuTheoNguoiDuyet(phieu, macongty);
            HienThiDanhSach();
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));
                    //LinkButton lbtn2 = ((LinkButton)e.Row.Cells[1].Controls[0]);
                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        //lbtn2.Text = "Cất Vào Kho";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";
                        //lbtn2.Text = "转入资料库";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Detail";
                        //lbtn2.Text = "Cất Vào Kho";
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
            HienThiDanhSach();
        }

       
    }
}