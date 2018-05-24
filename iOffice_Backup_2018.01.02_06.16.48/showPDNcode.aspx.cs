using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
namespace iOffice
{
    public partial class showPDNcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string[] getPDNCode(string term)
        {
            List<string> retCategory = new List<string>();

            // string ConnectionString = @"Data Source=192.168.11.15;Initial Catalog=LY_ERP;User ID=Programer;Password=P@ssw0rd";
            // string ConnectionString = @"Data Source=192.168.11.6;Initial Catalog=LY_ERP;User ID=sa;Password=tuan123";
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select  distinct top 20 pdno  from pdna where pdno like +@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", term);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retCategory.Add(string.Format("{0}", dr["pdno"]));

                    }
                    return retCategory.ToArray();
                }

            }
            //return retCategory.ToArray();
        }
        [WebMethod]
        public List<string> GetData(string DName)
        {
            string gsbh = "LTY";
            string UserID = Session["UserID"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select pdno from pdna where CFMID0='" + UserID + "' and GSBH='" + gsbh + "'and  pdno like '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", DName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["pdno"].ToString());
                    }
                    return result;
                }
            }
        }    
    }
}