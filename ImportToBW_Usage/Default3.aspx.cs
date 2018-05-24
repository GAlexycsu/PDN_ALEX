using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////string[] RootFile = ddlSheets.SelectedItem.Text.ToString().Split('$');
        ////string SheetName1 = RootFile[0];
        //string Sheets = ddlSheets.SelectedItem.ToString().Trim();
        //string SheetName = Sheets.Substring(Sheets.IndexOf('$'));
         string SheetName = "'TRINH KY$'";
         string[] ma = SheetName.Split('$');
         string aa = SheetName[0].ToString();

       

    }
}