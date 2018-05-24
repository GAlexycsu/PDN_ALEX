using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;

namespace iOffice.DAO
{
    public class PDNA1DAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static bool ThemHang(pdna1 hang)
        {
            try
            {
                db.pdna1s.InsertOnSubmit(hang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool SuaHang(pdna1 hang)
        {
            try
            {
                pdna1 ha = db.pdna1s.Where(p => p.GSBH == hang.GSBH && p.pdNO == hang.pdNO && p.CLBH == hang.CLBH && p.Size == hang.Size).SingleOrDefault();
                ha.Qty = hang.Qty;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool XoaHang(string gsbh,string pdno,string clbh, string size)
        {
            try
            {
                pdna1 ha = db.pdna1s.Where(p => p.GSBH == gsbh && p.pdNO == pdno && p.CLBH == clbh && p.Size == size).SingleOrDefault();
                db.pdna1s.DeleteOnSubmit(ha);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<pdna1> QryHangTheoPhieu(string GSBH, string pdno)
        {
            try
            {
                var list = db.pdna1s.Where(p => p.GSBH == GSBH && p.pdNO == pdno);
                return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}