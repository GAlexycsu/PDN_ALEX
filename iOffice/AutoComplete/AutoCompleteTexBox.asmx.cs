using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using iOffice.DTO;
namespace iOffice.AutoComplete
{
    /// <summary>
    /// Summary description for AutoCompleteTexBox
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
        
    public class AutoCompleteTexBox : System.Web.Services.WebService
    {
        static iOfficeDataContext db = new iOfficeDataContext();

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        //public static List<sp_ArticleSearchResult> SearchAjax(string article)
        //{
        //    DataClassesDataContext db = new DataClassesDataContext(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString);
        //    var ls = new List<sp_ArticleSearchResult>();
        //    ls = db.sp_ArticleSearch(article).ToList();
        //    return ls;
        //}
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static List<ListDonViTinhResult> GetDataTextBox(string name)
        {
            var list = new List<ListDonViTinhResult>();
            list = db.ListDonViTinh(name).ToList();
            return list;
        }
    }
}
