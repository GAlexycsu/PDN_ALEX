using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class ChucVuDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<ChucVu> Qrychucvu()
        {
            try
            {
                return db.ChucVus.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ChucVu TimMaChucVu(string machucvu, string macongty)
        {
            try
            {
                var list = (from p in db.ChucVus.Where(a => a.IDChucVu == machucvu && a.GSBH == macongty) select p).FirstOrDefault();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ThemChucVu(ChucVu pchucvu)
        {
            try
            {
                db.ChucVus.InsertOnSubmit(pchucvu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaChucVu(ChucVu pchucvu)
        {
            try
            {
                ChucVu chuc = new ChucVu();
                chuc = db.ChucVus.Where(p => p.IDChucVu == pchucvu.IDChucVu).FirstOrDefault();
                {
                    chuc.IDChucVu = pchucvu.IDChucVu;
                    chuc.TenChucVu = pchucvu.TenChucVu;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaChucVu(string idchucvu)
        {
            try
            {
                ChucVu chuc = new ChucVu();
                chuc = db.ChucVus.Where(p => p.IDChucVu == idchucvu).FirstOrDefault();
                db.ChucVus.DeleteOnSubmit(chuc);
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