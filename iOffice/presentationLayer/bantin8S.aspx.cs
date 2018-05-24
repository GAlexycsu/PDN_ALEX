using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer
{
    public partial class bantin8S : LanguegeBus
    {
        Stem8SDAL dalType = new Stem8SDAL();
        S8recDAL dal8Rec = new S8recDAL();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string ngonngu = (string)Session["languege"];
            if (UserID == null && ngonngu == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");
            }
            else
            {
                LayngonNgu(41, ngonngu);
            }
            if (!IsPostBack)
            {
               
                txtFromDate.Text = DateTime.Today.AddDays(-7).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                HienThiDropDonViERP();
                DropDownDonVi.Items.Insert(0, new ListItem("", "0"));
                HienThiThongTin();
            }
        }
        #region Don Vi HRM
        //  public void HienThiDropDonVi()
        //{
        //    int Nam = int.Parse(DateTime.Today.Year.ToString());
        //    int Month = int.Parse(DateTime.Today.Month.ToString());
        //    DataTable dt = dal8Rec.QryDonViLenDropBox(Nam, Month);
        //    if (dt.Rows.Count > 0)
        //    {

        //        string ngonngu = (string)Session["languege"];
        //        if (ngonngu != null)
        //        {
        //            if (ngonngu == "lbl_VN")
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "DV_TEN";
        //                DropDownDonVi.DataBind();
        //            }
        //            else
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "TENDV_TAIWAN";
        //                DropDownDonVi.DataBind();
        //            }
        //        }


        //        //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
        //        //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

        //    }

        //}
        #endregion
        public void HienThiDropDonViERP()
        {

            DataTable dt = dal8Rec.QryDonViLenDropBoxTrenERP(Congty);
            if (dt.Rows.Count > 0)
            {

                string ngonngu = (string)Session["languege"];
                if (ngonngu != null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                    else
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                }


                //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
                //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

            }

        }
          public void HienThiThongTin()
        {
           string Pfromdate=(string) Session["fromdate"]; 
           string ptodate=(string)Session["todate"] ;
           string pdonvi=(string)Session["donviQuery"];
           if (Pfromdate != null && ptodate != null && pdonvi != null)
           {
               DateTime FromDate = DateTime.Parse(txtFromDate.Text.Trim());
               DateTime ToDate = DateTime.Parse(txtToDate.Text.Trim());
               if (pdonvi == "0")
               {
                   string ngonngu = Session["languege"].ToString();
                   if (ngonngu == "lbl_VN")
                   {
                       DataTable dt = dal8Rec.QryBanTin8SVN(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
                   else if (ngonngu == "lbl_TW")
                   {
                       DataTable dt = dal8Rec.QryBanTin8STW(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
                   else if (ngonngu == "lbl_EN")
                   {
                       DataTable dt = dal8Rec.QryBanTin8SEN(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
               }
           }
           else
           {
               DateTime FromDate = DateTime.Today.AddDays(-7);
               DateTime ToDate = DateTime.Today;
               if (pdonvi == "0")
               {
                   string ngonngu = Session["languege"].ToString();
                   if (ngonngu == "lbl_VN")
                   {
                       DataTable dt = dal8Rec.QryBanTin8SVN(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
                   else if (ngonngu == "lbl_TW")
                   {
                       DataTable dt = dal8Rec.QryBanTin8STW(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
                   else if (ngonngu == "lbl_EN")
                   {
                       DataTable dt = dal8Rec.QryBanTin8SEN(FromDate, ToDate);
                       GridView1.DataSource = dt;
                       GridView1.DataBind();
                   }
               }
           }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime FromDate=DateTime.Parse(txtFromDate.Text.Trim());
            DateTime ToDate=DateTime.Parse(txtToDate.Text.Trim());
            string DonVi=DropDownDonVi.SelectedValue;

            if (DonVi == "0")
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dal8Rec.QryBanTin8SVN(FromDate, ToDate);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dal8Rec.QryBanTin8STW(FromDate, ToDate);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dal8Rec.QryBanTin8SEN(FromDate, ToDate);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                Session["fromdate"] = txtFromDate.Text.Trim();
                Session["todate"] = txtToDate.Text.Trim();
                Session["donviQuery"] = DonVi;
            }
            else
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dal8Rec.QryBanTin8SVN1(FromDate, ToDate,DonVi);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dal8Rec.QryBanTin8STW1(FromDate, ToDate,DonVi);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dal8Rec.QryBanTin8SEN1(FromDate, ToDate,DonVi);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                Session["fromdate"] = txtFromDate.Text.Trim();
                Session["todate"] = txtToDate.Text.Trim();
                Session["donviQuery"] = DonVi;
            }
        }
    }
}