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
    public partial class Action_Group : System.Web.UI.Page
    {
        DAL_GroupShare dalGroup = new DAL_GroupShare();
        string CongTy = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            divAttact.Visible = false;
            string USID = (string)Request["USID"];
           // string USID = "2015070004";
            DataTable dt = dalGroup.LayGroupMessageLenGrid(USID);
            if (dt.Rows.Count > 0)
            {
                txtMaShare.Text = dt.Rows[0]["USID"].ToString();
                lblGroup.Text = dt.Rows[0]["UGtitle"].ToString();
                lblTitle.Text = dt.Rows[0]["UStitle"].ToString();
                lblMemo.Text = dt.Rows[0]["USmemo"].ToString();
                lblUserName.Text = dt.Rows[0]["USERNAME"].ToString();
                string fromdate=dt.Rows[0]["sdate"].ToString();
                string todate=dt.Rows[0]["edate"].ToString();
                lblFromDate.Text = DateTime.Parse(fromdate).ToString("yyyy/MM/dd");
                lblToDate.Text = DateTime.Parse(todate).ToString("yyyy/MM/dd");
                //  
                
            }

            DataTable dtAtt = dalGroup.QryFileDinhKemTT(USID);
            if (dtAtt.Rows.Count > 0)
            {
                divAttact.Visible = true;
                DataTable ds = new DataTable();
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                ds.Columns.Add("FilePath");
                foreach (DataRow row in dtAtt.Rows)
                {
                    string lin1 = row["Linkfile"].ToString();
                    string lin2 = row["Linkfile2"].ToString();
                    string lin3 = row["Linkfile3"].ToString();

                    DataRow d = ds.NewRow();
                    if (lin1 != "")
                    {
                        string[] a1 = lin1.Split('\\');
                        d["ID"] = "LinkFile";
                        d["FileName"] = a1[2];
                        d["FilePath"] = lin1;
                        ds.Rows.Add(d);
                    }
                    DataRow d2 = ds.NewRow();
                    if (lin2 != "")
                    {
                        string[] a2 = lin2.Split('\\');
                        d2["ID"] = "LinkFile2";
                        d2["FileName"] = a2[2];
                        d2["FilePath"] = lin2;
                        ds.Rows.Add(d2);
                    }
                    DataRow d3 = ds.NewRow();
                    if (lin3 != "")
                    {
                        string[] a3 = lin3.Split('\\');
                        d3["ID"] = "LinkFile3";
                        d3["FileName"] = a3[2];
                        d3["FilePath"] = lin3;
                        ds.Rows.Add(d3);
                    }
                }
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
            }
            else
            {
                divAttact.Visible = false;
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {

            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = gvDetails.DataKeys[0]["FilePath"].ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtMaShare.Text.Trim());

            dalGroup.DeleteMessageByID(ID);
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
        }

    }
}