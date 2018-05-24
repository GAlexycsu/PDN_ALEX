using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Telerik.Web.UI;
namespace iOffice.presentationLayer
{
    public partial class WF_Projectm2 : System.Web.UI.Page
    {
        DAL_projectn dalProjectm = new DAL_projectn();
        DAL_Projects dalProjects = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
        string conty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserID"] = "27276";
                string UserID = "27276";
                HienSystem();
                HienThiProjectn();
              //  HienThiProjects();
                string jsysid=(string)Session["hethongselect"];
                string jsubid=(string)Session["hethongconselect"];
                if(jsysid!=null && jsubid!=null)
                {
                    HienTHiABXC(jsysid, jsubid, UserID, conty);
                }
            }
        }
        public void HienSystem()
        {
           // string UserID = (string)Session["UserID"];
            string UserID = "27276";
            string GSBH = conty;

            DataTable dt = dalSystem.QryProjectTheoNgayThang(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
            }
        }
        public void HienThiProjectn()
        {
            //string UserID = (string)Session["UserID"];
            string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjectm.QryProjectTheoNgayThang(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                RadGrid2.DataSource = dt;
                RadGrid2.DataBind();
            }
            else
            {
                RadGrid2.DataSource = null;
                RadGrid2.DataBind();
            }
        }
        public void HienThiProjects()
        {
           // string UserID = (string)Session["UserID"];
            string UserID="27276";
            string GSBH = conty;
            DataTable dt = dalProjects.QryProjectsTheoUserID(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                RadGrid3.DataSource = dt;
                RadGrid3.DataBind();
            }
            else
            {
                RadGrid3.DataSource = null;
                RadGrid3.DataBind();
            }
        }
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1;
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                // Nếu được chọn lại chưa chắc anh đã chọn phương án 1, và có thể chọn phương án 2 
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USID"], e.Item.ItemIndex);
            }
        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                // Nếu được chọn lại chưa chắc anh đã chọn phương án 1, và có thể chọn phương án 2 
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USID"], e.Item.ItemIndex);
            }
        }

        protected void RadGrid3_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                // Nếu được chọn lại chưa chắc anh đã chọn phương án 1, và có thể chọn phương án 2 
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USID"], e.Item.ItemIndex);
            }
        }

        protected void RadGrid2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            //GridViewRow row = GridView2.SelectedRow;
            //Label lblGSBH = (Label)row.FindControl("lblGSBH");
            //Label lbljsysid = (Label)row.FindControl("lbljsysid");
            //Label lbljsubid = (Label)row.FindControl("lbljsubid");
            //Session["themjobjsysid"] = lbljsysid.Text.Trim();
            //Session["themjobjsubid"] = lbljsubid.Text.Trim();
            //string UserID = Session["UserID"].ToString();
            //DataTable dt = dalProjects.HienThiDanhSachJob(lbljsysid.Text.Trim(), lbljsubid.Text.Trim(), UserID, lblGSBH.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    GridView3.DataSource = dt;
            //    GridView3.DataBind();
            //}
            //else
            //{
            //    GridView3.DataSource = null;
            //    GridView3.DataBind();
            //}
            GridDataItem gridItem = (GridDataItem)RadGrid2.SelectedItems[0];
            string jsubid = gridItem.GetDataKeyValue("jsubid").ToString();
            string jsysid = gridItem.GetDataKeyValue("jsysid").ToString();
            string gsbh = gridItem.GetDataKeyValue("gsbh").ToString();
            string UserID = "27276";
            RadGrid3.Visible = true;
            HienTHiABXC(jsysid, jsubid, UserID, gsbh);
        }
        public void HienTHiABXC(string jsysid,string jsubid,string UserID,string gsbh)
        {
            DataTable dt = dalProjects.HienThiDanhSachJob(jsysid, jsubid, UserID, gsbh);
            if (dt.Rows.Count > 0)
            {
                RadGrid3.DataSource = dt;
                RadGrid3.DataBind();
            }
            else
            {
                RadGrid3.DataSource = null;
                RadGrid3.DataBind();
            }
        }
        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Label lblGSBH = (Label)e.Item.FindControl("lblGSBH");
                Label lbljsysid = (Label)e.Item.FindControl("lbljsysid");
                Label lbljsubid = (Label)e.Item.FindControl("lbljsubid");
                Session["hethongselect"] = lbljsysid.Text.Trim();
                Session["hethongconselect"] = lbljsubid.Text.Trim();

               // string UserID = Session["UserID"].ToString();
                string UserID = "27276";
                RadGrid3.Visible = true;
                HienTHiABXC(lbljsysid.Text.Trim(), lbljsubid.Text.Trim(), UserID, lblGSBH.Text.Trim());
              //  Response.Redirect("WF_Projectm2.aspx");
            }
        }
    }
}