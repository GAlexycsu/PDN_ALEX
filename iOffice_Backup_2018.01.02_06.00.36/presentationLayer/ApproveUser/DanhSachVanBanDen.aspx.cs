using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.Share;
using iOffice.DAO;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class DanhSachVanBanDen : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();

        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string ngonngu = (string)Session["languege"];
                string user = (string)Session["user"];

                if (user==null && ngonngu==null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
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
               
                
                GanNgonNguVaoConTrol();
               
               
                GanNgonNguVaoGridView();
                HienThiDanhSach();
               
            }
            
     
        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
           
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView2.DataSource = AbconDAO.QryVanBanDenTheoNguoiDuyet(manguoidung, macongty);
                GridView2.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.DataSource = AbconDAO.QryVanBanDenTheoNguoiDuyetTW(manguoidung, macongty);
                GridView2.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView2.DataSource = AbconDAO.QryVanBanDenTheoNguoiDuyetEN(manguoidung, macongty);
                GridView2.DataBind();
            }
        }
        public override void GanNgonNguVaoGridView()
        {
           
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView2.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["YnName"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[8].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["ID"].ToString();
                GridView2.Columns[10].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["YnName"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[8].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["ID"].ToString();
                GridView2.Columns[10].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView2.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["abname"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["pdno"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["mytitle"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["YnName"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["NameABC"].ToString();
                GridView2.Columns[8].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView2.Columns[9].HeaderText = hasLanguege["ID"].ToString();
                GridView2.Columns[10].HeaderText = hasLanguege["DepName"].ToString();
            }
           
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                Label1.Text = "Danh sách văn bản đến";
            }
            else if (ngonngu == "lbl_TW")
            {
                Label1.Text = "资料名单";
            }
            else if (ngonngu == "lbl_EN")
            {
                Label1.Text = "List PDN to ";
            }
        }
        private void hienthi()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            List<Abcon> Captruoc = AbconBUS.LayCapDuyetTruocCuaNhanVienTheoChiTiet(manguoidung);

            Abcon capdangduyet = AbconBUS.LayCapDuyetCuaNhanVien(manguoidung);
            int buoctruoc=capdangduyet.Abstep-1;
            string nguoiduyet=Session["user"].ToString();
            Busers2 suer = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);

            GridView2.DataSource = db.QryVanBanDenChuaDuyetTheoNguoiDuyet(manguoidung, buoctruoc);
            GridView2.DataBind();
            //string maphieu = row.Cells[1].Text;
            //Session["maphieu"] = maphieu;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblpdn = (Label)row.FindControl("lblpdno");
            string maphieu = lblpdn.Text;
            Session["maphieu"] = maphieu;

            string loaiphieu = row.Cells[3].Text;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[5].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[10].Text;
            Session["bophan"] = bophan;
            
            Label lblMaloaiPhieu = (Label)row.FindControl("lblCustID");
            string maloaiphieu = lblMaloaiPhieu.Text;
            Session["maloaiphieu"] = maloaiphieu;
            Label lblMaDV = (Label)row.FindControl("LblIDdep");
            string mabophan = lblMaDV.Text;
            Session["mabophan"] = mabophan;
            // Response.Redirect("~/presentationLayer/ApproveUser/frmDetails.aspx");
            if (maloaiphieu == "PDN2")
            {
                Response.Redirect("chitietphieumuahang.aspx");
            }
            else
            {
                Response.Redirect("frmDetails.aspx");
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));
                    Label lbtn2 = ((Label)e.Row.FindControl("lblNoiDung"));
                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Xem Quy Trình";
                        lbtn2.Text = "Chi Tiết";
                        
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "检查流程";
                        lbtn2.Text = "详情";
                        
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Check Work Flow";
                        lbtn2.Text = "Detail";
                       
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
            
            //string maphieu = (string)GridView2.Rows[e.RowIndex].Cells[4].Text;

            Label lbl = (Label)GridView2.Rows[e.RowIndex].FindControl("lblpdno");
            Session["maphieu"] = lbl.Text;

            Response.Redirect("tinhtrangtheovanban.aspx");
        }

        
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

      

        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        
    }
}