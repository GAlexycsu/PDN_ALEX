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
    public partial class ViewShare : System.Web.UI.Page
    {
        departDAL dal = new departDAL();
        DAL_ProjectShare dalShare = new DAL_ProjectShare();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = dal.GetDate();
                string date = dt.Rows[0]["NgayThang"].ToString();
                DateTime a = DateTime.Parse(date.ToString());
                txtFromDate.Text = a.ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                HienThiUserLenDropDow();
            }
        }
        public void HienThiUserLenDropDow()
        {
            string UserID = Session["UserID"].ToString();
            DataTable dt = dalShare.QryUserLenDropBoxShare(congty, UserID);
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
            string UserID=(string)Session["UserID"];
            string UserShare=DropDownUserName.SelectedValue.ToString();
            DateTime pTuNgay=DateTime.Parse(txtFromDate.Text.Trim());
            DateTime pDenNgay=DateTime.Parse(txtToDate.Text.Trim());
            DataTable dt = dalShare.QryProjectShareByAuditor(congty, UserShare,UserID, pTuNgay, pDenNgay);
         // 
                GridView1.DataSource = dt;
                GridView1.DataBind();
           

        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectShareByUser.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhanTram1 = (Label)e.Row.FindControl("lblSpercent0");
                Label lblPhanTram2 = (Label)e.Row.FindControl("lblSpercent1");
                Label lblPhanTram3 = (Label)e.Row.FindControl("lbljpercent2");
                Label lblSystemName = (Label)e.Row.FindControl("lblSystemName");
                lblSystemName.ForeColor = System.Drawing.Color.Blue;
                Label lbljsubname = (Label)e.Row.FindControl("lbljsubname");
                lbljsubname.ForeColor = System.Drawing.Color.Blue;
                Label lbljobname = (Label)e.Row.FindControl("lbljobname");
                lbljobname.ForeColor = System.Drawing.Color.Blue;
                int p1, p2, p3;
                try
                {
                    p1 = int.Parse(lblPhanTram1.Text.Trim());
                }
                catch
                {
                    p1 = 0;
                }
                try
                { p2 = int.Parse(lblPhanTram2.Text.Trim()); }
                catch { p2 = 0; }
                try { p3 = int.Parse(lblPhanTram3.Text.Trim()); }
                catch { p3 = 0; }
                if (p1 == 100)
                {
                    lblPhanTram1.ForeColor = System.Drawing.Color.Turquoise;

                }
                else
                {
                    lblPhanTram1.ForeColor = System.Drawing.Color.Tomato;
                }
                if (p2 == 100)
                {
                    lblPhanTram2.ForeColor = System.Drawing.Color.Turquoise;
                }
                else
                {
                    lblPhanTram2.ForeColor = System.Drawing.Color.Tomato;
                }
                if (p3 == 100)
                {
                    lblPhanTram3.ForeColor = System.Drawing.Color.Turquoise;
                    //
                }
                else
                {
                    lblPhanTram3.ForeColor = System.Drawing.Color.Tomato;
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            this.GridView1.AllowPaging = false;
            this.GridView1.AllowSorting = false;
            this.GridView1.EditIndex = -1;
            this.GridView1.Columns[0].Visible = false;
            this.GridView1.Columns[1].Visible = false;
            this.GridView1.Columns[2].Visible = false;
            this.GridView1.Columns[3].Visible = false;
            this.GridView1.Columns[16].Visible = false;

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.HienThiDuLieu();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in GridView1.HeaderRow.Cells)
                    {
                        cell.BackColor = GridView1.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = Color.WhiteSmoke;
                            }
                            else
                            {
                                cell.BackColor = GridView1.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    GridView1.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

        }
    }
}