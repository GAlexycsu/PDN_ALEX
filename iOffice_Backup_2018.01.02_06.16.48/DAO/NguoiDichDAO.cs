using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;

namespace iOffice.DAO
{
    
    public class NguoiDichDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<ABTranslator> QryNguoiDich()
        {
            return db.ABTranslatores.ToList();
        }
        public static ABTranslator TimMaNguoiDich(string manguoidich)
        {
            try
            {
                return db.ABTranslatores.Where(p => p.UserID == manguoidich).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}