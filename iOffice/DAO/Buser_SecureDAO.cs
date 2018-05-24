using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.DAO
{
    public class Buser_SecureDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static Buser_Securety TimKiemNhanVien_MaBaoMatTheoIDNhanVien_Ngay(string idNhanVien, DateTime ngay)
        {
            
            try
            {
                var ngaygannhat = (from bm in db.Buser_Secureties
                                   from q in db.Busers2s
                                   where bm.UserID==q.USERID && bm.UserID == idNhanVien && DateTime.Compare(bm.ngay.Value, ngay) <= 0
                                   select bm.ngay.Value).ToList().Max();
                if (ngaygannhat != null)
                {
                    return db.Buser_Secureties.Where(cd => cd.UserID == idNhanVien && DateTime.Compare(cd.ngay.Value, (DateTime)ngaygannhat) == 0).SingleOrDefault();
                }
                else
                    return new Buser_Securety();
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("TimKiemNhanVien_MaBaoMatTheoIDNhanVien_Ngay\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return new Buser_Securety();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
    }
}