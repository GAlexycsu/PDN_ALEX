using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
namespace iOffice.presentationLayer
{
    public partial class OverViewShare : System.Web.UI.Page
    {
        DAL_ProjectShare dal = new DAL_ProjectShare();
        string Status = string.Empty;
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiUserLenDropDow();
            }
        }
        public void HienThiUserLenDropDow()
        {
            string UserID = Session["UserID"].ToString();
            DataTable dt = dal.QryUserLenDropBoxShare(congty, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownUserName.DataSource = dt;
                DropDownUserName.DataValueField = "userid";
                DropDownUserName.DataTextField = "USERNAME";
                DropDownUserName.DataBind();
            }
        }
        public void HienThiDuLieu()
        {
            string UserID=Session["UserID"].ToString();
            string UserShare=DropDownUserName.SelectedValue.ToString();
            DateTime pTuNgay=DateTime.Parse(txtFromDate.Text.Trim());
            DateTime pDenNgay=DateTime.Parse(txtToDate.Text.Trim());
            DataTable dt = dal.QryProjectShareByAuditor(congty, UserShare, UserID, pTuNgay, pDenNgay);
            
                GridView1.DataSource = dt;
                GridView1.DataBind();
            
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            this.GridView1.AllowPaging = false;
            this.GridView1.AllowSorting = false;
            this.GridView1.EditIndex = -1;
            this.GridView1.Columns[0].Visible = false;
            this.GridView1.Columns[2].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.xls";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            // Response.AddHeader("content-disposition",
            //          "attachment;filename=MyList.xlsx");
            Response.AppendHeader("content-disposition", string.Format("attachment; filename={0}", "MyList.xlsx"));
            Response.Charset = "";

            using (StringWriter swriter = new StringWriter())
            {
                this.HienThiDuLieu();
                HtmlTextWriter hwriter = new HtmlTextWriter(swriter);
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = Color.Yellow;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {

                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Color.Red;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GridView1.RenderControl(hwriter);
                Response.Write(swriter.ToString());
                Response.End();
            }
        }
    }
}