using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Configuration;
using System.Management;

namespace iOffice.presentationLayer
{
    public partial class pageMain : System.Web.UI.Page
    {
        string Status = string.Empty;
        string SelectTime = string.Empty;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        DAL_projectn dalProjectm = new DAL_projectn();
        DAL_Projects dalProjects = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiTreeview();
            }
        }
        public void HienThiTreeview()
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string CongTy = "LTY";
            RadTreeNode roottree = new RadTreeNode("System");
            RadTreeView1.Nodes.Add(roottree);

            DataTable dtSystem = dalSystem.QryProjectTheoUserID(UserID, CongTy);
            if (dtSystem.Rows.Count > 0)
            {
                foreach (DataRow row in dtSystem.Rows)
                {
                    string SysID = row["jsysid"].ToString();
                    string SysName = row["sysname"].ToString();
                    RadTreeNode nootcha = new RadTreeNode("");
                    nootcha.Text = SysName;
                    nootcha.Value = SysID;
                    roottree.Nodes.Add(nootcha);
                    roottree.ExpandChildNodes();
                    DataTable dtProjectm = dalProjectm.QryProjectTheoUserID1(UserID, CongTy, SysID);

                    if (dtProjectm.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtProjectm.Rows)
                        {
                            string SystemID = dr["jsysid"].ToString();
                            string subSystemID = dr["jsubid"].ToString();
                            string subName = dr["jsubname"].ToString();
                            RadTreeNode parentNode = new RadTreeNode("Sub System");
                            parentNode.Text = subName;
                            parentNode.ToolTip = subSystemID;
                            parentNode.Value = SystemID.ToString();
                            nootcha.Nodes.Add(parentNode);
                            nootcha.ExpandChildNodes();
                            DataTable dtProjects = dalProjects.HienThiDanhSachTheoHeThong(UserID, CongTy, SystemID, subSystemID);
                            if (dtProjects.Rows.Count > 0)
                            {
                                foreach (DataRow drs in dtProjects.Rows)
                                {
                                    string systemID = drs["jsysid"].ToString();
                                    string subSystem = drs["jsubid"].ToString();
                                    string jobID = drs["jobid"].ToString();
                                    string jobName = drs["jobname"].ToString();
                                    RadTreeNode childNode = new RadTreeNode("");
                                    childNode.Value = jobID;
                                    childNode.ToolTip = subSystem;
                                    childNode.Target = systemID.ToString();
                                    childNode.Text = jobName;
                                    parentNode.Nodes.Add(childNode);
                                    parentNode.ExpandChildNodes();
                                }
                            }
                        }
                    }

                }
            }
            RadTreeView1.ExpandAllNodes();


        }
    }
}