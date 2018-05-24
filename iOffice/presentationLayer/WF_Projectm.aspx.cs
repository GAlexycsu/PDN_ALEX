using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public partial class WF_Projectm : System.Web.UI.Page
    {
        DAL_projectn dalProjectm = new DAL_projectn();
        DAL_Projects dalProjects = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
        string conty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsubSystem.Visible = false;
                divJob.Visible = false;
                DropDownSystem.Items.Insert(0, "");
                RadDatePicker1.SelectedDate = DateTime.Today;
                RadDatePicker2.SelectedDate = DateTime.Today;
                HienThiDropSystem();
                HienSystem();

                string themxongprojectn = (string)Session["themjsysid"];
                if (themxongprojectn != null)
                {
                    divsubSystem.Visible = true;
                    NewProjectn();
                }
                string themxongjobsystem = (string)Session["themjobjsysid"];
                string themxongjobsubsystem = (string)Session["themjobjsubid"];
                if (themxongjobsystem != null && themxongjobsubsystem != null)
                {
                    divJob.Visible = true;
                    
                    HienThiGridJob();
                }
                DropDownSystem.Items.Insert(0, new ListItem("", "0"));
            }
        }
        public void HienSystem()
        {
            string UserID = (string)Session["UserID"];
            //string UserID = "27276";
            string GSBH = conty;

            DataTable dt = dalSystem.QryProjectTheoNgayThang(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        public void HienThiGridJob()
        {
            DateTime FromDate = DateTime.Today.AddDays(-10);
            DateTime ToDate = DateTime.Today;
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            string themxongjobsystem = (string)Session["themjobjsysid"];
            string themxongjobsubsystem = (string)Session["themjobjsubid"];
            DataTable dt = dalProjects.HienThiDanhSachJob(themxongjobsystem, themxongjobsubsystem, UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
        public void HienThiDropSystem()
        {
            string UserID = Session["UserID"].ToString();
            string GSBH = conty;
            DataTable dt = dalSystem.HienThiDropBoxSystem(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                DropDownSystem.DataSource = dt;
                DropDownSystem.DataValueField = "jsysid";
                DropDownSystem.DataTextField = "SystemName";
                DropDownSystem.DataBind();
            }
            else
            {
                DropDownSystem.Items.Clear();
            }
        }
        public void HienThiSystemTheoDieuKien()
        {
            string GSBH = DropDownGSBH.SelectedValue;
            string systemID = DropDownSystem.SelectedValue;
            //string TuNgay = txtTuNgay.Text.Trim();
            string TuNgay = RadDatePicker1.SelectedDate.ToString();
            string DenNgay = RadDatePicker2.SelectedDate.ToString();
            //string LeaderID = txtLeaderID.Text.Trim();
            string ynCancel = "";
            string ynHide = "";
            if (checkCancel.Checked == true)
            {
                ynCancel = "9";
            }
            else
            {
                ynCancel = "H";
            }
            if (checkHide.Checked == true)
            {
                ynHide = "8";
            }
            else
            {
                ynHide = "H";
            }
            if (checkHide.Checked != true && checkCancel.Checked != true)
            {
                string Yn1 = "0";
                string Yn2 = "1";
                string UserID = Session["UserID"].ToString();
                if (systemID == "0")
                {
                    DataTable dt1 = dalSystem.QryPhieuystemTheoDieuKien1(GSBH, TuNgay, DenNgay, UserID,Yn1,Yn2);
                    if (dt1.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    DataTable dt = dalSystem.QryPhieuystemTheoDieuKien(GSBH, systemID, TuNgay, DenNgay, UserID,Yn1,Yn2);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                string UserID = Session["UserID"].ToString();
                if (systemID == "0")
                {
                    DataTable dt1 = dalSystem.QryPhieuystemTheoDieuKien1Huy(GSBH, TuNgay, DenNgay,ynCancel,ynHide, UserID);
                    if (dt1.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    DataTable dt = dalSystem.QryPhieuystemTheoDieuKienHuy(GSBH, systemID, TuNgay, DenNgay,ynCancel,ynHide, UserID);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                }
            }
            
        }
        public void NewProjectn()
        {
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            string systemID = Session["themjsysid"].ToString();
            DataTable dt = dalProjectm.QryProjectTheoNgayThang1(UserID, GSBH, systemID);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        public void HienThiProjectn()
        {
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjectm.QryProjectTheoNgayThang(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        public void HienThiProjectnTheoIDSystem(string IDSystem)
        {
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjectm.QryProjectTheoNgayThangMaSystem(UserID, GSBH,IDSystem);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
        public void HienThiProjects()
        {
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjects.QryProjectsTheoUserID(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
        public void HienThiProjectsTheoSubSystem(string jsubid)
        {
            string UserID = (string)Session["UserID"];
            //string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjects.QryProjectsTheoUserIDVaSub(UserID, GSBH,jsubid);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
        protected void btnAddSystem_Click1(object sender, EventArgs e)
        {
            Session["themprojectm"] = "them";
            Response.Redirect("addSystem.aspx");
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain3.aspx");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Session["themprojectn"] = "them";//11
            Response.Redirect("addProjectn.aspx");
        }

        protected void btnAddSubproject_Click(object sender, EventArgs e)
        {
            Session["themprojects"] = "them";
            Response.Redirect("addProjects.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            divJob.Visible = false;
            divsubSystem.Visible = true;
            GridViewRow row = GridView1.SelectedRow;
            Label lblGSBH = (Label)row.FindControl("lblgsbh");
            Label lbljsysid = (Label)row.FindControl("lbljsysid");
            Session["themjsysid"] = lbljsysid.Text.Trim();
            string UserID = Session["UserID"].ToString();
            DataTable dt = dalProjectm.GetDataByGSBHSystem(UserID, lblGSBH.Text.Trim(), lbljsysid.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["suaprojectm"] = "sua";

            Label lblgsbh = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblgsbh");
            Label lbljsysid = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbljsysid");


            Label lblsysname = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblsysname");
            Label lblsysmemo = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblsysmemo");

            Label lbluserid = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbluserid");
            Label lbluserdate = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbluserdate");
            Label lblyn = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblyn");
            Label lblsLeaderid = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblsLeaderid");
            Label lbledates = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbledates");
            Label lbledatee = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lbledatee");
            Label lblSpercent = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblSpercent");

            Label lblsysnamevn = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblsysnamevn");
            Label lblsysmemovn = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblsysmemovn");


            Session["gsbh"] = lblgsbh.Text.Trim();
            Session["jsysid"] = lbljsysid.Text.Trim();

           
            Session["lblsLeaderid"] = lblsLeaderid.Text.Trim();
           

            Response.Redirect("addSystem.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string yn = "9";
            Label lblgsbh = (Label)GridView1.Rows[e.RowIndex].FindControl("lblgsbh");
            Label lbljsysid = (Label)GridView1.Rows[e.RowIndex].FindControl("lbljsysid");
            dalSystem.XoaProjectm(lblgsbh.Text.Trim(), lbljsysid.Text.Trim(),yn);
            dalProjectm.XoaProjectnTheoSYstem(lblgsbh.Text.Trim(), lbljsysid.Text.Trim(),yn);
            dalProjects.XoaProjectsTheoSystem(lblgsbh.Text.Trim(), lbljsysid.Text.Trim(),yn);
            HienSystem();
            //HienThiProjectn();
            //HienThiProjects();
            divsubSystem.Visible = false;
            divJob.Visible = false;
        }

        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            divJob.Visible = true;
            GridViewRow row = GridView2.SelectedRow;
            Label lblGSBH = (Label)row.FindControl("lblGSBH");
            Label lbljsysid = (Label)row.FindControl("lbljsysid");
            Label lbljsubid = (Label)row.FindControl("lbljsubid");
            Session["themjobjsysid"] = lbljsysid.Text.Trim();
            Session["themjobjsubid"] = lbljsubid.Text.Trim();
            string UserID = Session["UserID"].ToString();
            DataTable dt = dalProjects.HienThiDanhSachJob(lbljsysid.Text.Trim(), lbljsubid.Text.Trim(), UserID, lblGSBH.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["suaprojectn"] = "sua";

            Label lblgsbh = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lblgsbh");
            Label lbljsysid = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsysid");
            Label lbljsubid = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsubid");


            Label lbljsubname = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsubname");
            Label lbljsubmemo = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsubmemo");
            Label lbluserid = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbluserid");
            Label lbluserdate = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbluserdate");
            Label lblyn = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lblyn");
            Label lblsLeaderid = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lblsLeaderid");
            Label lbledates = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbledates");
            Label lbledatee = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbledatee");
            Label lblSpercent = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lblSpercent");
            Label lblPDNO = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lblPDNO");

            Label lbljsubnamevn = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsubnamevn");
            Label lbljsubmemovn = (Label)GridView2.Rows[e.NewEditIndex].FindControl("lbljsubmemovn");

            Session["gsbh"] = lblgsbh.Text.Trim();
            Session["jsysid"] = lbljsysid.Text.Trim();
            Session["jsubid"] = lbljsubid.Text.Trim();

            
            Response.Redirect("addProjectn.aspx");
        }
        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["suaprojects"] = "sua";
            Label lblgsbh = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lblgsbh");
            Label lbljsysid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljsysid");
            Label lbljsubid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljsubid");
            Label lbljobid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljobid");
            Label lblticketid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lblticketid");
            Label lbljobname = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljobname");
            Label lbljobmemo = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljobmemo");
            Label lbluserid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbluserid");
            Label lbluserdate = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbluserdate");
            Label lblyn = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lblyn");
            Label lblJleaderid = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lblJleaderid");
            Label lbledates = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbledates");
            Label lbledatee = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbledatee");
            Label lbljpercent = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljpercent");
            Label lblPDNO = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lblPDNO");
            Label lbljobnamevn = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljobnamevn");
            Label lbljobmemovn = (Label)GridView3.Rows[e.NewEditIndex].FindControl("lbljobmemovn");

            Session["lblgsbh"] = lblgsbh.Text.Trim();
            Session["lbljsysid"] = lbljsysid.Text.Trim();
            Session["lbljsubid"] = lbljsubid.Text.Trim();
            Session["lbljobid"] = lbljobid.Text.Trim();
            
          
            Response.Redirect("addProjects.aspx");
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string yn = "9";
            Label lblGSBH = (Label)GridView2.Rows[e.RowIndex].FindControl("lblGSBH");
            Label lbljsysid = (Label)GridView2.Rows[e.RowIndex].FindControl("lbljsysid");
            Label lbljsubid = (Label)GridView2.Rows[e.RowIndex].FindControl("lbljsubid");
            dalProjectm.XoaProjectn(lblGSBH.Text.Trim(), lbljsysid.Text.Trim(), lbljsubid.Text.Trim(),yn);
            dalProjects.XoaProjectsTheoSubSystem(lblGSBH.Text.Trim(), lbljsysid.Text.Trim(), lbljsubid.Text.Trim(),yn);
            HienThiProjectnTheoIDSystem(lbljsysid.Text.Trim());
            //HienThiProjects();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string yn = "9";
            Label lblgsbh = (Label)GridView3.Rows[e.RowIndex].FindControl("lblgsbh");
            Label lbljsysid = (Label)GridView3.Rows[e.RowIndex].FindControl("lbljsysid");
            Label lbljsubid = (Label)GridView3.Rows[e.RowIndex].FindControl("lbljsubid");
            Label lbljobid = (Label)GridView3.Rows[e.RowIndex].FindControl("lbljobid");
            dalProjects.XoaProjects(lblgsbh.Text.Trim(), lbljsysid.Text.Trim(), lbljsubid.Text.Trim(), lbljobid.Text.Trim(),yn);
            //HienThiProjects();
            HienThiProjectsTheoSubSystem(lbljsubid.Text.Trim());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            divsubSystem.Visible = false;
            divJob.Visible = false;
            Session.Remove("themjobjsysid");
            Session.Remove("themjobjsubid");
            Session.Remove("themjsysid");

            HienThiSystemTheoDieuKien();
        }

        protected void btnShareJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShareProject.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSpercent = (Label)e.Row.FindControl("lblSpercent");
                decimal Percent;
                try
                {
                    Percent = decimal.Parse(lblSpercent.Text.Trim());
                }
                catch
                {
                    Percent = 0;
                }

                //Button btnSelect = (Button)e.Row.FindControl("btbxoagr121");
                LinkButton btnSelect = (LinkButton)e.Row.FindControl("btbxoagr121");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btbxoagr12");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btbxoagr112");
                btnSelect.ForeColor = System.Drawing.Color.Blue;
                btnEdit.ForeColor = System.Drawing.Color.Blue;
                btnDelete.ForeColor = System.Drawing.Color.Red;
                if (Percent > 0)
                {
                    btnDelete.Enabled = false;
                    btnDelete.Attributes.CssStyle.Add("opacity", "0.3");
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnDelete.Attributes.CssStyle.Add("opacity", "100");
                    btnDelete.Attributes["Onclick"] = "return confirm('Are you sure you want to delete this event?')";
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSpercent = (Label)e.Row.FindControl("lblSpercent");
                decimal Percent;
                try
                {
                    Percent = decimal.Parse(lblSpercent.Text.Trim());
                }
                catch
                {
                    Percent = 0;
                }
                LinkButton btnSelect = (LinkButton)e.Row.FindControl("btbxoagr221");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btbxoagr22");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btbxoagr2");
                btnSelect.ForeColor = System.Drawing.Color.Blue;
                btnEdit.ForeColor = System.Drawing.Color.Blue;
                btnDelete.ForeColor = System.Drawing.Color.Red;
                if (Percent > 0)
                {
                    btnDelete.Enabled = false;
                    btnDelete.Attributes.CssStyle.Add("opacity", "0.3");
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnDelete.Attributes.CssStyle.Add("opacity", "100");
                    btnDelete.Attributes["Onclick"] = "return confirm('Are you sure you want to delete this event?')";
                }
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSpercent = (Label)e.Row.FindControl("lbljpercent");
                decimal Percent;
                try
                {
                    Percent = decimal.Parse(lblSpercent.Text.Trim());
                }
                catch
                {
                    Percent = 0;
                }
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btbxoagr32");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btbxoagr3");
                btnEdit.ForeColor = System.Drawing.Color.Blue;
                btnDelete.ForeColor = System.Drawing.Color.Red;
                if (Percent > 0)
                {
                    btnDelete.Enabled = false;
                    btnDelete.Attributes.CssStyle.Add("opacity", "0.3");
                    
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnDelete.Attributes.CssStyle.Add("opacity", "100");
                    btnDelete.Attributes["Onclick"] = "return confirm('Are you sure you want to delete this event?')";
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            if (RadDatePicker1.SelectedDate.ToString() != "" && RadDatePicker2.SelectedDate.ToString() != "" && UserID != null)
            {

                Response.Redirect("WF_ReportT.aspx?Type=BaoCaoProject&UserID=" + UserID + "&FromDate=" + RadDatePicker1.SelectedDate.ToString() + "&ToDate=" + RadDatePicker2.SelectedDate.ToString());
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView3.SelectedRow;
            Label lbljsysid = (Label)row.FindControl("lbljsysid");
            Label lbljsubid = (Label)row.FindControl("lbljsubid");
            Label lbljobid = (Label)row.FindControl("lbljobid");

            Response.Redirect("ShareJobWith.aspx?SystemID=" + lbljsysid.Text.Trim() + "&SubsystemID=" + lbljsubid.Text.Trim() + "&JobID=" + lbljobid.Text.Trim());
           
        }
    }
}