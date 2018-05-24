using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.DAO
{
    public class abillDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<abill> ListBill()
        {
            return db.abills.ToList();
        }
        public static abill SearchAbillByID(string id)
        {
            return db.abills.Where(p => p.abtype.Equals(id)).FirstOrDefault();
        }
        public static bool InsertAbill(abill bill)
        {
            try
            {
                db.abills.InsertOnSubmit(bill);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static  bool UpdateAbill(abill pabill)
        {
            try
            {
                abill b = new abill();
                b = db.abills.Where(p => p.abtype == pabill.abtype).FirstOrDefault();
                {
                    b.abtype = pabill.abtype;
                    b.abname = pabill.abname;
                    b.maintable = pabill.maintable;
                    b.abnameTW = pabill.abnameTW;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            { throw; }
        }
        public static bool DeleteAbill(string id)
        {
            try
            {
                abill b = new abill();
                b = db.abills.Where(p => p.abtype == id).FirstOrDefault();
                db.abills.DeleteOnSubmit(b);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
    }
}