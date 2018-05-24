using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public partial class them8S : System.Web.UI.Page
    {
        
        Stem8SDAL dalType = new Stem8SDAL();
        S8recDAL dal8Rec = new S8recDAL();
        protected string yn = "";
        protected DataTable dt = new DataTable();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.Enabled = false;
                btnAdd.Attributes.CssStyle.Add("opacity", "0.3");
            }
        }

        public void HienThiDanhSachTheoDieuKien()
        {

            string tungay = txtFromDate.Text.Trim();
            string denngay = txtToDate.Text.Trim();
            DateTime FromDate;
            DateTime ToDate;
            string DepartID = DropDownDonVi.SelectedValue;

            if (tungay != "" && denngay != "" && DepartID != "0")
            {

                try
                {
                    FromDate = DateTime.Parse(tungay);
                    ToDate = DateTime.Parse(denngay);
                }
                catch
                {
                    FromDate = DateTime.Today.AddDays(-7);
                    ToDate = DateTime.Today;
                }
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    dt = dalType.LayDanhSachS8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                    yn = dt.Rows[0]["yn"].ToString();
                }
                else if (ngonngu == "lbl_TW")
                {
                     dt = dalType.LayDanhSachS8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                     yn = dt.Rows[0]["yn"].ToString();
                }
                else if (ngonngu == "lbl_EN")
                {
                     dt = dalType.LayDanhSachS8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                     yn = dt.Rows[0]["yn"].ToString();
                }
                //DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                //if (dtDiem.Rows.Count > 0)
                //{
                //    divScore.Visible = true;
                //    string donvi = dtDiem.Rows[0]["depid"].ToString();
                //    lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();

                //    lblDiem.Text = dtDiem.Rows[0]["sub_score"].ToString();


                //}
                //else
                //{
                //    divScore.Visible = false;
                //}
            }
            else
            {

                FromDate = DateTime.Today.AddDays(-7);
                ToDate = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                     dt = dalType.LayDanhSachS8TheoDieuKienVN1(FromDate, ToDate, DepartID);
                     yn = dt.Rows[0]["yn"].ToString();
                }
                else if (ngonngu == "lbl_TW")
                {
                     dt = dalType.LayDanhSachS8TheoDieuKienTW1(FromDate, ToDate, DepartID);
                     yn = dt.Rows[0]["yn"].ToString();
                }
                else if (ngonngu == "lbl_EN")
                {
                     dt = dalType.LayDanhSachS8TheoDieuKienEN1(FromDate, ToDate, DepartID);
                     yn = dt.Rows[0]["yn"].ToString();
                }
                //DataTable dtDiem = dalType.LayTongDiemTheoDonVi(DepartID, FromDate, ToDate);
                //if (dtDiem.Rows.Count > 0)
                //{
                //    divScore.Visible = true;
                //    string donvi = dtDiem.Rows[0]["depid"].ToString();
                //    lblDiemChuan.Text = dtDiem.Rows[0]["Sitemscore"].ToString();
                //    lblDiem.Text = dtDiem.Rows[0]["sub_score"].ToString();
                //}
                //else
                //{
                //    divScore.Visible = false;
                //}
            }

        }
        protected void DropDownDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            if (ID.Trim() != "0")
            {

                 DateTime FromDate;
                 DateTime ToDate;
                 try
                    {
                        FromDate = DateTime.Parse(txtFromDate.Text.Trim());
                        ToDate = DateTime.Parse(txtToDate.Text.Trim());
                    }
                    catch
                    {
                        FromDate = DateTime.Today.AddDays(-6);
                        ToDate = DateTime.Today;
                    }
                 DataTable dt = dal8Rec.KiemTraDonViTruocKhiThem(ID, FromDate, ToDate);
                 if (dt.Rows.Count > 0)
                 {
                     btnAdd.Enabled = false;
                     btnAdd.Attributes.CssStyle.Add("opacity", "0.3");
                     HienThiDanhSachTheoDieuKien();
                 }
                 else
                 {
                     btnAdd.Enabled = true;
                     btnAdd.Attributes.CssStyle.Add("opacity", "100");
                 }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            string UserID = (string)Session["UserID"];
            if (UserID != null)
            {
                try
                {
                    dal8Rec.Them8SVaoTrongbangS8Rec(Congty, ID, UserID);
                    HienThiDanhSachTheoDieuKien();
                }
                catch
                {
                    
                }
            }
        }
    }
}