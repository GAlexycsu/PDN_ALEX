﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class danhsachphieubanguikhongduocduyet : LanguegeBus
    {

        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

               
                
                if (!IsPostBack)
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
                   
                    
                    GanNgonNguVaoGridView();
                    HienThiDanhSach();
                    
                }
               
          
           
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        //public override void GanNgonNguVaoGridView()
        //{


        //    string ngonngu = Session["languege"].ToString();
        //    if (ngonngu == "lbl_VN")
        //    {
        //        //GridView1.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
        //        GridView1.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
        //        GridView1.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
        //        GridView1.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
        //        GridView1.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
        //        GridView1.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
        //        GridView1.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
        //        GridView1.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
        //        GridView1.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
        //    }
        //    else if (ngonngu == "lbl_TW")
        //    {
        //        //GridView2.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
        //        GridView2.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
        //        GridView2.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
        //        GridView2.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
        //        GridView2.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
        //        GridView2.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
        //        GridView2.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
        //        GridView2.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
        //        GridView2.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
        //    }
        //    else if (ngonngu == "lbl_EN")
        //    {
        //        //GridView1.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
        //        GridView1.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
        //        GridView1.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
        //        GridView1.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
        //        GridView1.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
        //        GridView1.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
        //        GridView1.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
        //        GridView1.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
        //        GridView1.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
        //    }

        //}
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
          

                ///
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName"].ToString();
            }


        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.QryPhieuKhongDuocDuyetTheoNguoiTao(manguoidung,macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.QryPhieuKhongDuocDuyetTheoNguoiTaoTW(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.QryPhieuKhongDuocDuyetTheoNguoiTao(manguoidung, macongty);
                GridView1.DataBind();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            Label lblMaloaiPhieu = (Label)row.FindControl("lblabtype");
            string maloaiphieu = lblMaloaiPhieu.Text;
            Session["maloaiphieu"] = maloaiphieu;
            string loaiphieu = row.Cells[2].Text;
            Session["tenloaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;

            string bophan = row.Cells[9].Text;
            Session["bophan"] = bophan;
            Label lblMaDV = (Label)row.FindControl("lblDepart");
            string mabophan = lblMaDV.Text;
            Session["mabophan"] = mabophan;
            // Response.Redirect("~/presentationLayer/ApproveUser/frmDetails.aspx");
            if (maloaiphieu == "PDN2")
            {
                Response.Redirect("phieumuahang.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2.aspx");
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
                        lbtn1.Text = "Chi Tiết";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
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