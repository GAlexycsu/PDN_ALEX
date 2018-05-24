using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.BUS
{
    public class LanguegeBus : System.Web.UI.Page
    {
       static iOfficeDataContext db = new iOfficeDataContext();
        protected Hashtable hasLanguege;
        string Url = "";
        
        public void  LayDuLieuNgonNgu()
        {
           
            try
            {
                Url = Request.Url.LocalPath;
                hasLanguege = new System.Collections.Hashtable();
                hasLanguege = CateLanguegeDAO.LayNgonNgu(CateLanguegeDAO.LayMaManHinh(Url.Substring(Url.LastIndexOf('/') + 1)), Session["languege"].ToString());


            }

            catch (Exception )
            {
                throw;
            }
        }
        public  void LayngonNgu(int id,string NgonNgu)
        {
            try
            
            {
               
                    // urlll = Request.Url.LocalPath;
                    Url = Request.Url.LocalPath.Substring(Url.LastIndexOf('/') + 1);
                    hasLanguege = new System.Collections.Hashtable();
                    hasLanguege = CateLanguegeDAO.LayNgonNgu(id, NgonNgu);
               

            }
            catch (Exception)
            {
                throw;
            }
        }
        //public static AbScreen LayMaManHinh(int id)
        //{
        //    try
        //    {
        //        //return db.AbScreens.Where(p => p.ScreenID == id).FirstOrDefault();
        //        var list = from p in db.AbScreens.Where(a => a.ScreenID == id) select p;
        //        return list.FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        protected void DoLuLieuVaoGridView(GridView pGrv, object pDataSoure)
        {
            try
            {
                pGrv.DataSource = pDataSoure;
                pGrv.DataBind();
                if (pGrv.Rows.Count > 0)
                {
                    GanNgonNguVaoGridView();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual void GanNgonNguVaoGridView()
        {
        }
        public virtual void GanNgonNguVaoConTrol()
        {
            try
            {
               

            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}