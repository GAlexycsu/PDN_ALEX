using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
public partial class WF_ViewReport : ViewReport
{
    BLL_ExportToExcel _bll = new BLL_ExportToExcel();
    CommonFunction cf = new CommonFunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = "";
        if (cf.IsNullOrEmpty(Request["Type"]))
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            type = Request["Type"].ToString();
        }
        switch (type)
        {
            case "LayDanhSachDuLieuNhapVao":

                break;

        }
        
             
    }
    public void LayDanhSachDuLieuNhapVao()
    {
        List<string> Path = new List<string>();
        Path.Add("");
        string XieXing = (string)Session["XieXing"];
        string SheHao = (string)Session["SheHao"];
        Hashtable htb = new Hashtable();
        DataSet ds = new DataSet();
        htb.Add("XieXing", XieXing);
        htb.Add("SheHao", SheHao);
        ds = _bll.LayDanhSachDuLieuNhapVao(XieXing, SheHao);
        ShowExecl(Path, ds, htb);
    }
}