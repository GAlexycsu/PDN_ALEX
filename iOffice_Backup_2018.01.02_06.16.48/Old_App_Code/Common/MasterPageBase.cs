using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MasterPageBase
/// </summary>
public class MasterPageBase : System.Web.UI.MasterPage
{
    protected LinkButton _lbtnSignOut = new LinkButton();
    protected Label _lblUserName = new Label();
    public MasterPageBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        try
        {
            Session.RemoveAll();
            Response.Redirect("../../HomPage/Common/Login.aspx");
        }
        catch
        {

        }
    }
    void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            //CommonFunction _cmm = new CommonFunction();
            //if (_cmm.IsNullOrEmpty(Session["TenNV"]))
            //{
            //    _lbtnSignOut.Visible = false;
            //}
            //else
            //{
            //    _lbtnSignOut.Visible = true;
            //    _lblUserName.Text = Session["TenNV"].ToString();
            //}
        }
        catch
        {
            _lbtnSignOut.Visible = false;
        }
    }
}