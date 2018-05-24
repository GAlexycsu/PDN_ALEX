using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    public partial class ShareProject : System.Web.UI.Page
    {
        DAL_ProjectShare dal = new DAL_ProjectShare();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                HienThiDropDowSystem();
                HienThiDropDowSubSystem();
                DropDownsystem.Items.Insert(0, " ");
                DropDownSubsystem.Items.Insert(0, "");
                HienThiDuLieu();
                string SystemChange = (string)Session["SystemChange111"];
                if(SystemChange!=null)
                {
                    DropDownsystem.SelectedValue = SystemChange;
                }
            }
        }
        public void HienThiDropDowSystem()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            DataTable dt = dal.HienThiDropDowSystemTheoUserID(GSBH, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownsystem.DataSource = dt;
                DropDownsystem.DataValueField = "jsysid";
                DropDownsystem.DataTextField = "SysTemName";
                DropDownsystem.DataBind();
            }
        }
        public void HienThiDropDowSubSystem()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string System = DropDownsystem.SelectedValue.ToString().Trim();
            if (System != "")
            {
                DataTable dt = dal.HienThiDropDowSubSystemTheoUserID(GSBH, UserID, System);
                if (dt.Rows.Count > 0)
                {
                    DropDownSubsystem.DataSource = dt;
                    DropDownSubsystem.DataValueField = "jsubid";
                    DropDownSubsystem.DataTextField = "jsubname";
                    DropDownSubsystem.DataBind();
                }
                else
                {
                    DropDownSubsystem.DataSource = null;
                  
                    DropDownSubsystem.DataBind();
                }
            }
            else
            {
                DropDownSubsystem.DataSource = null;
                DropDownSubsystem.DataBind();
            }
        }
        public void HienThiDuLieu()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            int TruongHop;
            string System = DropDownsystem.SelectedValue.ToString().Trim();
            string SubSystem=DropDownSubsystem.SelectedValue;
            if (System == "")
            {
                TruongHop = 1;
            }
            else
            {
                if (SubSystem.Trim() == "")
                {
                    TruongHop = 2;
                }
                else
                {
                    TruongHop = 3;
                }
            }
            DataTable dt = dal.QryJobShare(UserID, GSBH, System, SubSystem,TruongHop);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        protected void DropDownsystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string System = DropDownsystem.SelectedValue;
            if (System != "")
            {
                DataTable dt = dal.HienThiDropDowSubSystemTheoUserID(GSBH, UserID, System);
                if (dt.Rows.Count > 0)
                {
                    DropDownSubsystem.DataSource = dt;
                    DropDownSubsystem.DataValueField = "jsubid";
                    DropDownSubsystem.DataTextField = "jsubname";
                    DropDownSubsystem.DataBind();
                    Session["SystemChange111"] = System;
                }
                else
                {
                    DropDownSubsystem.DataSource = dt;
                    DropDownSubsystem.DataBind();
                }
            }
            else
            {
                DropDownSubsystem.DataSource = null;
                DropDownSubsystem.DataBind();
            }
        }

        protected void btnShareU_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProjectShare.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblGSBH=(Label)GridView1.Rows[e.RowIndex].FindControl("lblGSBH");
            Label lblJsysid=(Label)GridView1.Rows[e.RowIndex].FindControl("lblJsysid");
            Label lblJsubid=(Label)GridView1.Rows[e.RowIndex].FindControl("lblJsubid");
            Label lblJodid=(Label)GridView1.Rows[e.RowIndex].FindControl("lblJodid");
            Label lblJuserid=(Label)GridView1.Rows[e.RowIndex].FindControl("lblJuserid");
            Label lbluserid=(Label)GridView1.Rows[e.RowIndex].FindControl("lbluserid");
            dal.XoaProjectShare(lblGSBH.Text.Trim(), lblJsysid.Text.Trim(), lblJsubid.Text.Trim(), lblJodid.Text.Trim(), lblJuserid.Text.Trim(), lbluserid.Text.Trim());
            HienThiDuLieu();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblGSBH = (Label)row.FindControl("lblGSBH");
            Label lblJsysid = (Label)row.FindControl("lblJsysid");
            Label lblJsubid = (Label)row.FindControl("lblJsubid");
            Label lblJodid = (Label)row.FindControl("lblJodid");
            Label lblJuserid = (Label)row.FindControl("lblJuserid");
            Label lbluserid = (Label)row.FindControl("lbluserid");
            string jSystem = lblJsysid.Text.Trim();
            string jsubsystem = lblJsubid.Text.Trim();
            string jJobid = lblJodid.Text.Trim();
            string jUserShare = lblJuserid.Text.Trim();
          
           // Response.Redirect("EditProjectShare.aspx" + "?jSystem=" + jSystem + "&jsubsystem=" + jsubsystem + "&jJobid=" + jJobid + "&jUserShare="+jUserShare);
        }

        protected void DropDownSubSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        protected void DropDownJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}