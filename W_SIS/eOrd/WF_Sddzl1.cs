using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class WF_Sddzl1 : BaseGUI
{
    BLL_Ddzl _BLL = new BLL_Ddzl();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            Get_datas();

       }
    }

    protected void Get_datas()
    {
        try
        {
            //int ID = 0;
            //if (string.IsNullOrEmpty(txtID.Text)) { } else
            //{
            //    ID = int.Parse(txtID.Text.Trim());
            //}

            DataTable dt = _BLL.Querys1(txtID.Text.Trim(), txtFID.Text.Trim(), txtFNA.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
                GridView1.DataSource = dt;
                GridView1.DataBind();
            //}

        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnLayDanhSach_Click(object sender, EventArgs e)
    {
        //Session["getData"] = "getData";
        //string ID = ddlDBase.SelectedValue;
        //Session["CompanyID"] = ID.Trim();
        //Session["TableID"] = txtTableID.Text.Trim();
        //Session["TableNameVN"] = txtTableNameVN.Text.Trim();
        //Session["TableNameCH"] = txtTableNameCH.Text.Trim();
        //Session["TableNameEN"] = txtTableNameEN.Text.Trim();
        //string Url = HttpContext.Current.Request.Url.AbsoluteUri;
        //Response.Redirect(Url);
            Get_datas();
        
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //Label lblDBase = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDBase");
            //Label lblTable = (Label)GridView1.Rows[e.RowIndex].FindControl("lblTable");
            //string DBase = lblDBase.Text.Trim();
            //string TableID = lblTable.Text.Trim();
            _BLL.delete(int.Parse(txtID.Text.Trim()));
            Get_datas();
          
        }
        catch (Exception)
        {
            throw;
        }
    
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        //    LinkButton Link111 = (LinkButton)e.Row.FindControl("Link111");
        //    Link111.OnClientClick = "return confirm('Are you sure?')";

        }
    }
  
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Get_datas();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }


    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
        //    DropDownList ddlDBaseF = (DropDownList)GridView1.FooterRow.FindControl("ddlDBaseF");
        //    TextBox txtTable = (TextBox)GridView1.FooterRow.FindControl("txtTableID");
        //    TextBox txtNameEN = (TextBox)GridView1.FooterRow.FindControl("txtNameEN");
        //    TextBox txtNameVN = (TextBox)GridView1.FooterRow.FindControl("txtNameVN");
        //    TextBox txtNameCH = (TextBox)GridView1.FooterRow.FindControl("txtNameCH");
        //    TextBox txtMemo = (TextBox)GridView1.FooterRow.FindControl("txtMemo");
            string UserID = (string)Session["UserID"];
            if (UserID == null)
            {
                Response.Redirect("WF_DangNhap.aspx");
            }
            else
            {
                //ddlDBase.SelectedValue = ddlDBaseF.SelectedValue;
                _BLL.Insert(int.Parse(txtID.Text.Trim()));
                Get_datas();
            }
        }
        catch (Exception)
        {

            throw;
        }
    
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            Get_datas();
            GridView1.EditIndex = -1;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //Label lblDBase = (Label)GridView1.Rows[e.RowIndex].FindControl("lblDBase");
            //Label lblTable = (Label)GridView1.Rows[e.RowIndex].FindControl("lblTable");
            //Label lblField = (Label)GridView1.Rows[e.RowIndex].FindControl("lblField");
            //TextBox txten = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txten");
            //TextBox txtvn = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtvn");
            //TextBox txtch = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtch");
            //TextBox txtsm = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsm");
            //TextBox txtdt = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdt");
            //TextBox txtde = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtde");
            //TextBox txtm1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtm1");
            //TextBox txtds = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtds");
            ////
            //string pID = lblDBase.Text.Trim();
            //string pFID = lblTable.Text.Trim();
            //string pFNA = lblField.Text.Trim();
            //string pVN = txtvn.Text.Trim();
            //string pEN = txten.Text.Trim();
            //string pCH = txtch.Text.Trim();
            //string pSM = txtsm.Text.Trim();
            //string pDT = txtdt.Text.Trim();
            //string pDE = txtde.Text.Trim();
            //string pM1 = txtm1.Text.Trim();
            //string pDS = txtds.Text.Trim();
            //_BLL.Update(pID, pFID, pFNA, pDT, pDE, pVN, pEN, pCH, pDS, pSM, pM1);
            Get_datas();
            GridView1.EditIndex = -1;

        }
        catch (Exception)
        {
            throw;
        }
    }
}