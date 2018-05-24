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
    public partial class Group : System.Web.UI.Page
    {
        departDAL dalDepart = new departDAL();

        userDAL dalUser = new userDAL();
        GroupDAL dalGroup = new GroupDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                HienThiDropDowslist();
                ddlDepartment.Items.Insert(0, "");
                HienThiGroup();
            }
        }
        public void HienThiGroup()
        {
            string UserID=Session["UserID"].ToString();
            DataTable dt = dalGroup.QryGroup(UserID, congty);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public void HienThiDropDowslist()
        {
            DataTable dt = dalDepart.QryDonVi(congty);
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "ID";
            ddlDepartment.DataTextField = "DepName";
            ddlDepartment.DataBind();

        }
        public void HienThiListTimTuDropDow()
        {
            string MaDV = ddlDepartment.SelectedValue;
            DataTable dt = dalUser.TimNhanVienTheoMaDonVi(congty, MaDV);
            if (dt.Rows.Count > 0)
            {
                lsbUserTim.Visible = true;
                lbsUserXuLy.Visible = true;
                lsbUserTim.DataSource = dt;
                lsbUserTim.DataBind();
            }

        }
        public void HienThiListTimTuTextBox()
        {
            string MaNV = txtKeySearch.Text;
            DataTable dt = dalUser.TimNhanVienTheoMa(congty, MaNV);
            if (dt.Rows.Count > 0)
            {
                lsbUserTim.Visible = true;
                lbsUserXuLy.Visible = true;
                lsbUserTim.DataSource = dt;
                lsbUserTim.DataBind();
            }

        }
        public void HienThiListTimTuTextBox1()
        {
            string MaNV = txtKeySearch.Text;
            DataTable dt = dalUser.TImNguoiTheoDieuKien(MaNV);
            if (dt.Rows.Count > 0)
            {
                lsbUserTim.Visible = true;
                lbsUserXuLy.Visible = true;
                lsbUserTim.DataSource = dt;
                lsbUserTim.DataBind();
            }

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drop = ddlDepartment.SelectedValue.ToString().Trim();
            if (drop != "0")
            {
                HienThiListTimTuDropDow();
            }
            else
            {
                lsbUserTim.DataSource = null;
                lsbUserTim.DataBind();
            }
        }

        protected void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            string NVMa = txtKeySearch.Text.Trim();
            if (NVMa != "")
            {
                HienThiListTimTuTextBox();
                txtKeySearch.Text = "";
            }
            else
            {
                lsbUserTim.DataSource = null;
                lsbUserTim.DataBind();
            }
        }

        protected void btnSearchUserProcess_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text.Trim() != "")
            {
                HienThiListTimTuTextBox1();
            }
            else
            {
                if (ddlDepartment.SelectedValue.ToString().Trim() != "")
                {
                    HienThiListTimTuDropDow();
                }
            }
        }

        protected void lnkAddUserProcess_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbUserTim.Items.Count; i++)
            {
                if (lsbUserTim.Items[i].Selected == true || lsbUserTim.Items.Count == 1)
                {
                    
                        lbsUserXuLy.Items.Add(lsbUserTim.Items[i]);
                        lsbUserTim.Items.RemoveAt(i);
                  
                }
            }
        }

        protected void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbsUserXuLy.Items.Count; i++)
            {
                if (lbsUserXuLy.Items[i].Selected == true)
                {
                    lsbUserTim.Items.Add(lbsUserXuLy.Items[i]);
                    lbsUserXuLy.Items.RemoveAt(i);

                }
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnForward_Click(object sender, EventArgs e)
        {

        }

        protected void grvWork_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grvWork_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row=GridView1.SelectedRow;
            //Label lblugno = (Label)row.FindControl("lblugno");
            //Label lblUGtitle = (Label)row.FindControl("lblUGtitle");
            //Label lbluserid2 = (Label)row.FindControl("lbluserid2");
            //Label lblUSERNAME = (Label)row.FindControl("lbUSERNAME");
            //Label lblUGmemo = (Label)row.FindControl("lblUGmemo");
            //txtGroupID.Text = lblugno.Text.Trim();
            //txtNote.Text = lblUGmemo.Text.Trim();
            //txtGroupName.Text = lblUGtitle.Text.Trim();
          //  lbsUserXuLy.Items.Add(new ListItem(lblUSERNAME.Text.Trim(),lbluserid2.Text.Trim()));
            
            //lbsUserXuLy.Visible = true;
            //btnInsert.Visible = false;
            //btnUpdate.Visible = true;
        }

        protected void Save(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            HienThiGroup();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;       
            HienThiGroup();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            Label lblugno = (Label)GridView1.Rows[e.RowIndex].FindControl("lblugno");
          //  GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbluserid2 = (Label)GridView1.Rows[e.RowIndex].FindControl("lbluserid2");
            TextBox txtUGtitle = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUGtitle");
            TextBox txtuserid2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtuserid2");
            TextBox txtUSERNAME = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUSERNAME");
            TextBox txtUGmemo = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUGmemo");
            dalGroup.SuaGroup(UserID,congty,lblugno.Text.Trim(),txtuserid2.Text.Trim(),txtUGtitle.Text.Trim(),txtUGmemo.Text.Trim());
            GridView1.EditIndex = -1;
            HienThiGroup();

        }

        protected void txtuserid2_TextChanged(object sender, EventArgs e)
        {
            //GridViewRow row = GridView1.SelectedRow;
            ////TextBox txtuserid2 = (TextBox)row.FindControl("txtuserid2");
            //TextBox txtuserid2 = (TextBox)GridView1.
            //DataTable dt = dalUser.TimNhanVienTheoMa(congty, txtuserid2.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    TextBox txtUserName = (TextBox)row.FindControl("txtUSERNAME");
            //    txtUserName.Text = dt.Rows[0]["USERNAME"].ToString();
            //}
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string TenNhom = txtWorkGroupName.Text.Trim();
            string Content = txtContent.Text.Trim();
            for (int i = 0; i < lbsUserXuLy.Items.Count; i++)
            {
                if (lbsUserXuLy.Items[i].Selected == true)
                {
                    string UserID2 = lbsUserXuLy.Items[i].Value;
                    dalGroup.ThemGroup(UserID, congty, txtugno.Text.Trim(), UserID2, TenNhom, Content);
                    
                }
            }
            HienThiGroup();
        }

        protected void LinkCreateMessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMessage.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            Label lblugno = (Label)GridView1.Rows[e.RowIndex].FindControl("lblugno");
            Label lbluserid2 = (Label)GridView1.Rows[e.RowIndex].FindControl("lbluserid2");
            dalGroup.XoaGroup1(UserID, congty, lblugno.Text.Trim(), lbluserid2.Text.Trim());
            HienThiGroup();
        }
    }
}