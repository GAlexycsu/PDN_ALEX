using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Text;
using System.Data;

public partial class Search : System.Web.UI.Page
{
    BLL_Import _bll = new BLL_Import();
    CommonFunction cmm = new CommonFunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = (string)Session["UserID"];
        if (id == null)
        {
            Response.Redirect("http://portal.footgear.com.vn/");
        }
        if (!IsPostBack)
        {
            try
            {
                 string UserID = (string)Session["UserID"];
                if (UserID == null)
                {
                    Response.Redirect("http://portal.footgear.com.vn/");
                }
                else
                {
                    string xiexing = "";
                    string SheHao = "";
                    if (cmm.IsNullOrEmpty(Request["XieXing"]))
                    {
                        // tam de doa
                    }
                    else
                    {
                        xiexing = Request["XieXing"].ToString();
                        //string[] list=xiexing.Split('%');
                        //string XieXing = list[1];
                        DataTable dt = _bll.LayDanhSachDataByCondition1(UserID, xiexing, SheHao).Tables[0];
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetXieXing(string prefixText, int count, string contextKey)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ERP1"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        // Try to use parameterized inline query/sp to protect sql injection
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " XieXing FROM xtbwyl1 where XieXing!='NULL' and XieXing  LIKE '" + prefixText + "%'", conn);
        SqlDataReader oReader;
        conn.Open();
        List<string> CompletionSet = new List<string>();
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (oReader.Read())
            CompletionSet.Add(oReader["XieXing"].ToString());
        return CompletionSet.ToArray();
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetSheHao(string prefixText, int count, string contextKey)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ERP1"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        // Try to use parameterized inline query/sp to protect sql injection
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " SheHao FROM xtbwyl1 where SheHao!='NULL' and SheHao  LIKE '" + prefixText + "%'", conn);
        SqlDataReader oReader;
        conn.Open();
        List<string> CompletionSet = new List<string>();
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (oReader.Read())
            CompletionSet.Add(oReader["SheHao"].ToString());
        return CompletionSet.ToArray();
    }
    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("importData.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        GridView1.AllowPaging = false;
        //GridView1.Columns[0].Visible = false;
        string dangday = txtXieXing.Text.Trim();
        string mamau = (string)Session["mamau"];
        if (dangday != "")
        {
            this.HienThiDanhSachTheoDieuKien();
        }
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        GridView1.AllowPaging = true;
        GridView1.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    public void HienThiDanhSachTheoDieuKien()
    {
        try
        {

            string XieXing = txtXieXing.Text.Trim();
            string SheHao = txtSheHao.Text.Trim();

            string UserID = (string)Session["UserID"];
             //string UserID = "27276";
            if (UserID != null)
            {
                if (SheHao == "")
                {
                    DataTable dt = _bll.LayDanhSachDataByCondition1(UserID, XieXing, SheHao).Tables[0];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    DataTable dt = _bll.LayDanhSachDataByCondition2(UserID, XieXing, SheHao).Tables[0];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        HienThiDanhSachTheoDieuKien();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void OnUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}