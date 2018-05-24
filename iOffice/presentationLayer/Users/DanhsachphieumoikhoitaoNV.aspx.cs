﻿using System;
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
namespace iOffice.presentationLayer.Users
{
    public partial class DanhsachphieumoikhoitaoNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
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
            if (!IsPostBack)
            {
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
                GridView1.DataSource = dal.DanhSachPhieuMoiKhoiTaoTheoNguoiTao(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.DanhSachPhieuMoiKhoiTaoTheoNguoiTaoTW(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.DanhSachPhieuMoiKhoiTaoTheoNguoiTaoEN(manguoidung, macongty);
                GridView1.DataBind();
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
                GridView1.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName"].ToString();
            }

        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            Label lblMaloaiphieu = (Label)row.FindControl("lblabtype");
            string maloaiphieu = lblMaloaiphieu.Text;
            Session["loaiphieu"] = maloaiphieu;
            string tenloaiphieu = row.Cells[2].Text;
            Session["loaiP"] = tenloaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string tenbophan = row.Cells[7].Text;
            Session["bophan"] = tenbophan;
            Label lblMaDV = (Label)row.FindControl("lblDepart");
            string mabophan = lblMaDV.Text;
            Session["bp"] = mabophan;

           Response.Redirect("FrmView.aspx");
           
        }

      
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void TimerKhoiTao_Tick(object sender, EventArgs e)
        {




               

           
          
        }

        
    }
}