using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
     
    public class PDNLinkDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<PDNLink> GetLinkAttactFileByPDNO(string congty, string pdno)
        {
            var list = db.PDNLinks.Where(p => p.Gsbh == congty && p.pdno == pdno && p.Cancel==false).ToList();
            return list;
        }
        public static bool InsertFile(PDNLink pdn)
        {
            try
            {
                db.PDNLinks.InsertOnSubmit(pdn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool UpdateFile(PDNLink pdn)
        {
            try
            {

                PDNLink link = db.PDNLinks.Where(p => p.ID == pdn.ID && p.Gsbh == pdn.Gsbh && p.pdno == pdn.pdno).FirstOrDefault();
                if(link!=null)
                {
                    link.ID = pdn.ID;
                    link.pdno = pdn.pdno;
                    link.Gsbh = pdn.Gsbh;
                   
                    link.Cancel = pdn.Cancel;
                    db.SubmitChanges();
                   
                }
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}