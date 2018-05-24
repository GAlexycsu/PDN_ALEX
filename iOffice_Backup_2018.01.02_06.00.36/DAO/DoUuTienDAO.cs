using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class DoUuTienDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<aABC> LayCapDoUuTien()
        {
            try
            {
                return db.aABCs.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}