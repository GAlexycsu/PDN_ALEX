using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
public partial class importData : System.Web.UI.Page
{
    BLL_Import _bll = new BLL_Import();
    DAL_ImportData _dll = new DAL_ImportData();
    ABC _dd = new ABC();
    List<string> list = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string id = (string)Session["UserID"];
        //if (id == null)
        //{
        //    Response.Redirect("http://portal.footgear.com.vn/");
        //}
        if (!IsPostBack)
        {

            btnSave.Attributes["Onclick"] = "return confirm('New data can overwrite old data. Do you really want to save?')";
          
            Div1.Visible = true;
            Div2.Visible = false;
            ShowGrid.Visible = true;
            idquery.Visible = true;
            idCount.Visible = false;
            Div3.Visible = false;
            idquery.Visible = false;
            idXieXing.Visible = false;
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
    
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
             if (FileUpload1.HasFile)
                {

                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
           
                    string FolderPath = "D:\\FilesImport\\"+FileName;
         
                    FileUpload1.PostedFile.SaveAs(FolderPath);
                    GetExcelSheets(FolderPath, Extension, "Yes");
                    Div1.Visible = false;
                    Div2.Visible = true;
                    String Path1 = HttpContext.Current.Request.PhysicalApplicationPath + FileUpload1.FileName;
                    Session["duongdan"] = Path1;
                }
        }
        catch (Exception)
        {

           // Response.Redirect("thongbaoloi.aspx");
            throw;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    private void GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
        try
        {
            string conStr = "";
            switch (Extension)
            {
                //case ".xls": //Excel 97-03
                //    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                //    break;
                //case ".xlsx": //Excel 07
                //    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                //    break;
                case ".xls": //Excel 97-03
                    //conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    conStr = @" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + @";Extended Properties=""Excel 8.0;HDR=YES""";
                    break;
                case ".xlsx": //Excel 07
                    //conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + @";Extended Properties=""Excel 8.0;HDR=YES;""";
                    break;
            }

            //Get the Sheets in Excel WorkBoo
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            cmdExcel.Connection = connExcel;
            connExcel.Open();

            //Bind the Sheets to DropDownList
            ddlSheets.Items.Clear();
            ddlSheets.Items.Add(new ListItem("--Select Sheet--","Sh"));
            ddlSheets.DataSource = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            ddlSheets.DataTextField = "TABLE_NAME";
            ddlSheets.DataValueField = "TABLE_NAME";
            ddlSheets.DataBind();
            connExcel.Close();

            lblFileName.Text = Path.GetFileName(FilePath);
            Div2.Visible = true;
            Div1.Visible = false;
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
             if (ddlSheets.SelectedValue == "Sh")
            {
                return;
            }
            else
            {
                
                //string UserID = Session["UserID"].ToString();
                //string UserID = "27276";
                string strFileName = lblFileName.Text;
                //string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FolderPath = @"D:\FilesImport\" + strFileName;

                //string FilePath = @"D:\FilesImport\ly_erp-Y1001-A0-01.xls";
                string Extension = Path.GetExtension(strFileName);
               // string[] RootFile = ddlSheets.SelectedItem.Text.ToString().Split('$');
                string SheetName = ddlSheets.SelectedItem.Text.ToString();
               // string SheetName = "TRINH KY";
               
                DataTable dt = _bll.DocFileExcel(FolderPath, SheetName, Extension);
                string XieXing = dt.Rows[1][1].ToString().Trim();
                
                DataTable dd = _bll.TimMaMauTheoDangDay(XieXing);
                foreach (DataRow row in dd.Rows)
                {
                    string sh=row["SheHao"].ToString();
                    ListBox1.Items.Add(new ListItem(sh, sh));
                }
                txtXieXing.Text = XieXing;
               
                Div3.Visible = true;
                Div2.Visible = false;
                ShowGrid.Visible = true;
                Div1.Visible = false;

                idquery.Visible = true;
            }
            string OKL1 = "Ok";
            Session["OKL"] = OKL1;
        }
        catch (Exception)
        {

            Response.Redirect("thongbaoloi.aspx");
        }
    }

    private void HienThiDanhSach(string Y1001_AO,string BWBH)
    {
        idCount.Visible = true;
       
        string UserDate = DateTime.Today.ToString("yyyyMMdd");
        string UserID = (string)Session["UserID"];
        //string UserID = "25554";
        //DataTable dt = _bll.LayDanhSachTheoNgay(UserDate, UserID).Tables[0];  
       

        DataTable dt = _bll.LayDanhSachDuLieuTheoNgay(UserDate, UserID,Y1001_AO,BWBH).Tables[0];
        GridView1.DataSource = dt;
        GridView1.DataBind();
        int lcolumncount = GridView1.Columns.Count;
        lblRecord.Text = dt.Rows.Count.ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Div1.Visible = true;
        Div2.Visible = false;
       
        ShowGrid.Visible = false;
        idquery.Visible = false;
    }
    protected void btnReads_Click(object sender, EventArgs e)
    {
        if (ddlSheets.SelectedValue == "Sh")
        {
            return;
        }
        else
        {
            string strFileName = lblFileName.Text;
            // string FolderPath = ConfigurationManager.AppSettings["FolderPath"];


            string FolderPath = "D:\\FilesImport\\" + strFileName;
            //string FilePath = Server.MapPath(FolderPath + strFileName);
           // string FilePath = System.IO.Path.GetFullPath("D:\\FilesImport\\y_erp-Y1001-A0-01.xls");
            string FilePath = FolderPath + strFileName;
            string Extension = Path.GetExtension(FilePath);
            string[] RootFile = ddlSheets.SelectedItem.Text.ToString().Split('$');
            string SheetName = RootFile[0];
            // string SheetName = ddlSheets.SelectedItem.Text.ToString();
            //DataTable dt = _bll.DocFileExcel(FilePath, SheetName, Extension);
            //GridTemp.DataSource = dt;
            //GridTemp.DataBind();
            Div1.Visible = false;
            Div2.Visible = true;
            
            ShowGrid.Visible = false;
            idquery.Visible = false;
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
         
            Div1.Visible = true;
            Div2.Visible = false;
            
            ShowGrid.Visible = false;
            idquery.Visible = false;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string UserID = "27276";
        string ngay = DateTime.Today.ToString("yyyyMMdd");
        GridViewRow row = GridView1.SelectedRow;
       
        TextBox txtDangDay =(TextBox) GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
        TextBox txtMaMau = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
        TextBox txtViTri = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
        txtDangDay.Width = 50;
        txtMaMau.Width = 30;
        txtViTri.Width = 40;
        string DangDay = txtDangDay.Text.Trim();
        string MaMau = txtMaMau.Text.Trim();
        string ViTri = txtViTri.Text.Trim();
        int cot = GridView1.Rows[0].Cells.Count;
        for (int i = 5; i < cot; i++)
        {
           
            string Size = GridView1.HeaderRow.Cells[i].Text.Trim();
            TextBox txtSoLuong = (TextBox)GridView1.Rows[e.RowIndex].Cells[i].Controls[0];
            txtSoLuong.Width = 30;
            string SoLuong1 = txtSoLuong.Text.Trim();
            decimal SoLuong = 0;
          
            try
            {
                SoLuong = decimal.Parse(SoLuong1);
            }
            catch
            {
                SoLuong = 0;
            }
            _bll.UpdateData(DangDay, MaMau, ViTri, Size,ngay,UserID, SoLuong);
        }
        GridView1.EditIndex = -1;
        HienThiDanhSach(DangDay,MaMau);
        string OKL1 = "Ok";
        Session["OKL"] = OKL1;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // bun ngu qua di
        GridView1.EditIndex = e.NewEditIndex;
        int cot = GridView1.Rows[0].Cells.Count;
        //for (int i = 4; i < cot; i++)
        //{
        //    //// TextBox txtS = (TextBox)GridView1.Rows[e.NewEditIndex].Cells[i].Controls[0];
        //    //TextBox txt = new TextBox();
        //    //txt.ID = "txt" + (i).ToString();
        //    //txt.Width = 50;
        //    //txt.Text = GridView1.Rows[e.NewEditIndex].Cells[i].Controls[0].ToString();
            

        //}
        
        //HienThiDanhSachTheoDieuKien();
        string dangday = (string)Session["dangday"];
        string mamau = (string)Session["mamau"];
        if (dangday != null && mamau != null)
        {
            HienThiDanhSach(dangday,mamau);
        }
        
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        string dangday = (string)Session["dangday"];
        string mamau = (string)Session["mamau"];
        if (dangday != null && mamau != null)
        {
            HienThiDanhSach(dangday, mamau);
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      
        string DangDay = GridView1.Rows[e.RowIndex].Cells[1].Text.Trim();
        string MaMau = GridView1.Rows[e.RowIndex].Cells[2].Text.Trim();
        string ViTri = GridView1.Rows[e.RowIndex].Cells[3].Text.Trim();
        
             _bll.XoaDuLieu(DangDay, MaMau, ViTri);
             string dangday = (string)Session["dangday"];
             string mamau = (string)Session["mamau"];
             if (dangday != null && mamau != null)
             {
                 HienThiDanhSach(dangday, mamau);
             }
    }
    protected void OnUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // string UserID = Session["UserID"].ToString();
        string UserID = "27276";
        string ngay = DateTime.Today.ToString("yyyyMMdd");
        GridViewRow row = GridView1.SelectedRow;

        TextBox txtDangDay = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
        TextBox txtMaMau = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
        TextBox txtViTri = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
        txtDangDay.Width = 50;
        txtMaMau.Width = 30;
        txtViTri.Width = 40;
        string DangDay = txtDangDay.Text.Trim();
        string MaMau = txtMaMau.Text.Trim();
        string ViTri = txtViTri.Text.Trim();
        int cot = GridView1.Rows[0].Cells.Count;
        for (int i = 8; i < cot; i++)
        {

            string Size = GridView1.HeaderRow.Cells[i].Text.Trim();
            TextBox txtSoLuong = (TextBox)GridView1.Rows[e.RowIndex].Cells[i].Controls[0];
            txtSoLuong.Width = 30;
            string SoLuong1 = txtSoLuong.Text.Trim();
            decimal SoLuong = 0;
            try
            {
                SoLuong = decimal.Parse(SoLuong1);
            }
            catch
            {
                SoLuong = 0;
            }
            _bll.UpdateData(DangDay, MaMau, ViTri, Size,ngay,UserID, SoLuong);
        }
        GridView1.EditIndex = -1;
        HienThiDanhSach(DangDay,MaMau);

    }
   
  
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string dangday = (string)Session["dangday"];
        string mamau = (string)Session["mamau"];
        if (dangday != null && mamau != null)
        {
            HienThiDanhSach(dangday, mamau);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        GridView1.AllowPaging = false;
        //GridView1.Columns[0].Visible = false;
        string dangday = (string)Session["dangday"];
        string mamau = (string)Session["mamau"];
        if (dangday != null && mamau != null)
        {
           this. HienThiDanhSach(dangday, mamau);
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        this.GridView1.AllowPaging = false;
        this.GridView1.AllowSorting = false;
        this.GridView1.ShowHeader = true;
        this.GridView1.EditIndex = -1;
        this.GridView1.Columns[0].Visible = false;


        // Let's bind data to GridView
        string dangday = (string)Session["dangday"];
        string mamau = (string)Session["mamau"];
        if (dangday != null && mamau != null)
        {
            this.HienThiDanhSach(dangday, mamau);
        }

        // Let's output HTML of GridView
        Response.Clear();
        Response.ContentType = "application/vnd.xls";
        Response.AddHeader("content-disposition",
                "attachment;filename=MyList.xls");
        Response.Charset = "";
        StringWriter swriter = new StringWriter();
        HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
        GridView1.RenderControl(hwriter);
        Response.Write(swriter.ToString());
        Response.End();
    }
    protected void btnFileKhac_Click(object sender, EventArgs e)
    {
        //Div1.Visible = true;
        //Div2.Visible = false;
        //Div3.Visible = false;
        //ShowGrid.Visible = false;
        //idquery.Visible = true;
        //idCount.Visible = false;
        Session.Remove("dangday");
        Session.Remove("mamau");
        Response.Redirect("importData.aspx");
    }
    protected void btnImportDT_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSheets.SelectedValue == "Sh")
            {
                return;
            }
            else
            {
                System.Threading.Thread.Sleep(5000);
               string UserID = Session["UserID"].ToString();
               // string UserID = "25554";
                string strFileName = lblFileName.Text;
                //string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FolderPath = @"D:\FilesImport\" + strFileName;

                //string FilePath = @"D:\FilesImport\ly_erp-Y1001-A0-01.xls";
                string Extension = Path.GetExtension(strFileName);
                string[] RootFile = ddlSheets.SelectedItem.Text.ToString().Trim().Split('$');
                string SheetName1 = RootFile[0];
                string SheetName="";
                if (SheetName1.Contains(" ")|| SheetName1.Contains("'"))
                {
                    SheetName = SheetName1.Substring(1);
                }
                else
                {
                    SheetName = RootFile[0];
                }
                //string Sheets = ddlSheets.SelectedItem.ToString().Trim();
                //string SheetName = Sheets.Substring(Sheets.IndexOf('$'));
                //// string SheetName = "TRINH KY";
                string Y1001_AO = "";
                string BWBH = "";
                if (ListBox1.Text=="")
                {
                   
                }
                else
                {
                    foreach (ListItem item in ListBox1.Items)
                    {
                        if (item.Selected)
                        {
                            list.Add(item.Value);
                        }
                    }
                    _bll.Import(list, FolderPath, SheetName, Extension, UserID, ref Y1001_AO, ref BWBH);
                    HienThiDanhSach(Y1001_AO, BWBH);
                    list.Clear();
                    Session["dangday"] = Y1001_AO;
                    Session["mamau"] = BWBH;
                    Div2.Visible = false;
                    Div3.Visible = true;
                    ShowGrid.Visible = true;
                    Div1.Visible = false;
                    idXieXing.Visible = true;
                    idquery.Visible = true;
                }
               
            }
            string OKL1 = "Ok";
            Session["OKL"] = OKL1;
        }
        catch (Exception)
        {
            throw;
           // Response.Redirect("thongbaoloi.aspx");
        }
    }



    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string xieXing = txtXieXing.Text.Trim();
        string User = Session["UserID"].ToString();
       //string User = "27276";
       
        if (xieXing != "")
        {
            if (User != null)
            {
                Session["UserID"] = User;
                Response.Redirect("Search.aspx?XieXing="+xieXing);
            }
        }
    }
}