using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iOffice.DTO;

namespace iOffice.DAO
{
    public class CanBoDonViDAO
    {
      static  iOfficeDataContext db = new iOfficeDataContext();
        public static List<CanBoDonVi> LayDanhSachCanBoDonVi()
        {
            return db.CanBoDonVis.ToList();

        }
        public static bool ThemCanBoDonVi(CanBoDonVi pcanbo)
        {
            try
            {
                db.CanBoDonVis.InsertOnSubmit(pcanbo);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool SuaCanBoDonVi(CanBoDonVi pcanbo)
        {
            try
            {
                CanBoDonVi canbo = new CanBoDonVi();
                canbo = db.CanBoDonVis.Where(p => p.ID == pcanbo.ID).FirstOrDefault();
                canbo.GSBH = pcanbo.GSBH;
                canbo.BADepID = pcanbo.BADepID;
                canbo.UserIDQLDonVi = pcanbo.UserIDQLDonVi;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}