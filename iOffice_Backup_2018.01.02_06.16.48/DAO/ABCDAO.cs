using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;

namespace iOffice.DAO
{
    public class ABCDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static aABC TimDoUuTien(int mauutien)
        {
            return db.aABCs.Where(p => p.ABC == mauutien).FirstOrDefault();
        }
    }
}