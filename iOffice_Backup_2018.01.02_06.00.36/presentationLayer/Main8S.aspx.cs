using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.presentationLayer
{
    public partial class Main8S : LanguegeBus
    {
        Stem8SDAL dal = new Stem8SDAL();
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
                Session.Remove("ThemThanhCong");
                HienThiStemLenDrop();
                DropDownDD.Items.Insert(0, new ListItem("", "0"));
                HienThiDanhSach();
                lblAA.Text = DropDownDD.SelectedValue;
            }
        }
        public void HienThiStemLenDrop()
        {
            DataTable dt = dal.LayStypeVN();
            if (dt.Rows.Count > 0)
            {
               
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DropDownDD.DataSource = dt;
                    DropDownDD.DataValueField = "Sitemtp";
                    DropDownDD.DataTextField = "Stpnamevn";
                    DropDownDD.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDownDD.DataSource = dt;
                    DropDownDD.DataValueField = "Sitemtp";
                    DropDownDD.DataTextField = "Stpnamech";
                    DropDownDD.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDownDD.DataSource = dt;
                    DropDownDD.DataValueField = "Sitemtp";
                    //DropDownDD.DataTextField = "Stpnameen";
                    DropDownDD.DataTextField = "Stpnamevn";
                    DropDownDD.DataBind();
                }
            }
        }
        public void HienThiDanhSach()
        {
            string DD = DropDownDD.SelectedValue.ToString();
            if (DD.Trim() == "0")
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dal.QryPhieutem8SVNAll();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dal.QryPhieutem8STWAll();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dal.QryPhieutem8SVNAll();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                DataTable dtPhanTram = dal.LayTongPhanTram();
                if (dtPhanTram.Rows.Count > 0)
                {
                    lblPhanTram.Text = dtPhanTram.Rows[0]["Sitemscore"].ToString()+"  Score";
                }
            }
            else
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DataTable dt = dal.QryPhieutem8SVN(DD);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DataTable dt = dal.QryPhieutem8STW(DD);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dal.QryPhieutem8SVN(DD);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                DataTable dtPhanTram = dal.LayTongPhanTramTheoID(DD);
                if (dtPhanTram.Rows.Count > 0)
                {
                    lblPhanTram.Text = dtPhanTram.Rows[0]["Sitemscore"].ToString() + "  Score";
                }
            }
            

         
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {


            string DD = DropDownDD.SelectedValue.ToString();
            string ID = txtSitemNo.Text.Trim().ToString();
            string VN = txtSitemVN.Text.Trim();
            string TW = txtSitemTW.Text.Trim();
            string EN = txtSitemEN.Text.Trim();
            string diem = txtScore.Text.Trim();
            int Score = 0;
            try
            {
                Score = int.Parse(diem);

            }
            catch
            {
                Score = 0;
            }
            if (txtIDTemp.Text.Trim() != "")
            {
                dal.SuaStem8S(ID, DD, VN, TW, EN, Score);
            }
            else
            {
                dal.ThemStemt8S(ID, DD, VN, TW, EN, Score);
            }
            HienThiDanhSach();
            DropDownDD.SelectedValue = DD;
            DropDownDD.Enabled = true;
            txtSitemNo.ReadOnly = false;
            txtSitemNo.Enabled = true;
            txtSitemNo.Text = "";
            txtSitemVN.Text = "";
            txtSitemTW.Text = "";
            txtSitemEN.Text = "";
            txtScore.Text = "";
            txtSitemNo.Focus();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            txtScore.Text = "";
            txtSitemEN.Text = "";
            txtSitemNo.Text = "";
            txtSitemTW.Text = "";
            txtSitemVN.Text = "";
            txtSitemNo.Focus();
        }

        protected void DropDownDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDownDD.SelectedValue;
            lblAA.Text = a;
            HienThiDanhSach();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            Label lblSitemtp = (Label)row.FindControl("lblSitemtp");
            Label lblSitemno = (Label)row.FindControl("lblSitemno");
            Label lblSnamevn = (Label)row.FindControl("lblSnamevn");
            Label lblSnamech = (Label)row.FindControl("lblSnamech");
            Label lblSnameen = (Label)row.FindControl("lblSnameen");
            Label lblSitemscore = (Label)row.FindControl("lblSitemscore");
            txtIDTemp.Text = lblSitemno.Text.Trim();
            DropDownDD.SelectedValue = lblSitemtp.Text.Trim();
            txtSitemNo.Text = lblSitemno.Text.Trim();
            txtSitemVN.Text = lblSnamevn.Text.Trim();
            txtSitemTW.Text = lblSnamech.Text.Trim();
            txtSitemEN.Text = lblSnameen.Text.Trim();
            txtScore.Text = lblSnameen.Text.Trim();
            txtSitemNo.ReadOnly = true;
            txtSitemNo.Enabled = false;
            DropDownDD.Enabled = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}