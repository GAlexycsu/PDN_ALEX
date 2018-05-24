using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for BaseGUI
/// </summary>
public class BaseGUI : System.Web.UI.Page
{
    protected string _PageTitle = "";
    protected bool _isWritable = false;
    protected CommonFunction _cmmf = new CommonFunction();
    public BaseGUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected void CacPhuongThucChung()
    {
        try
        {
            KiemTraQuyen();
        }
        catch (Exception)
        {
            throw;
        }
    }

    void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            string Module = Session["Module"].ToString();
            this.MasterPageFile = "~/MasterPage/" + Module + "/" + Module + ".master";
        }
        catch { }
    }

    public string DD_MM_YYYY(object obj)
    {
        try
        {
            if (!_cmmf.IsNullOrEmpty(obj))
            {
                return DateTime.Parse(obj.ToString()).ToString("dd-MM-yyyy");
            }
            else
            {
                return "";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Common()
    {
        try
        {
            _PageTitle = _PageTitle.ToUpper();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void FillGirdView(GridView pGrid, object pDataSource)
    {
        try
        {
            pGrid.DataSource = pDataSource;
            pGrid.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void InsertItemIntoDropdownList(DropDownList pDDL, string pText, string pValue, int pIndex)
    {
        try
        {
            ListItem Li = new ListItem();
            Li.Text = pText;
            Li.Value = pValue;
            pDDL.Items.Insert(pIndex, Li);
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void FillDropdowlist(DropDownList pDDL, DataTable pDataSource)
    {
        try
        {
            pDDL.DataSource = pDataSource;
            pDDL.DataTextField = "Name";
            pDDL.DataValueField = "ID";
            pDDL.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void FillDropdowlistWithEmptyItem(DropDownList pDDL, DataTable pDataSource)
    {
        try
        {
            FillDropdowlist(pDDL, pDataSource);
            InsertItemIntoDropdownList(pDDL, "", "", 0);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool IsNullOrEmpty(object obj)
    {
        try
        {
            return _cmmf.IsNullOrEmpty(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected int KiemTraQuyen()
    {
        try
        {
            //int intRole = 0;
            //if (_cmmf.IsNullOrEmpty(Session["ActiveCode"]))
            //{
            //    Response.Redirect(@"../../HomPage/Common/Login.aspx");
            //}
            //else
            //{
            //    BLL_Users bllUser = new BLL_Users();
            //    string Url = Request.Url.LocalPath;
            //    intRole = bllUser.KiemTraQuyen(Session["ActiveCode"].ToString(), Url.Substring(Url.LastIndexOf('/') + 1));
            //    if (intRole == 0)
            //    {
            //        Response.Redirect(@"../../HomPage/Common/Login.aspx");
            //    }
            //    else
            //    {
            //        if (intRole > 1)
            //        {
            //            _isWritable = true;
            //        }
            //    }
            //}
            //return intRole;
            return 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Page_Error(object sender, EventArgs e)
    {
        try
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string strError = "";
            strError += "#Error in: " + Request.Url.ToString();
            strError += "\n";
            strError += "\n";
            strError += "#Message: " + objErr.Message;
            strError += "\n";
            strError += "\n";
            strError += "#StackTrace: " + objErr.StackTrace;
            strError += "\n";
            strError += "\n";
            strError += "#TargetSite: " + objErr.TargetSite;
            strError += "\n";
            strError += "\n";
            BLL_File ctrlError = new BLL_File();
            ctrlError.WriteSystemErrorLog(strError);
            Server.ClearError();
            throw objErr;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}