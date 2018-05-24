using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;

namespace iOffice.DAO
{
    public class ChiTietPhieuMuaHangPDNSDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static bool ThemChiTietMuaHang(pdna1 chitiet)
        {
            try
            {
                db.pdna1s.InsertOnSubmit(chitiet);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool SuaChiTietPhieuMuaHang(pdna1 chitiet)
        {
            try
            {
                
                    pdna1 phieu = db.pdna1s.Where(p => p.GSBH == chitiet.GSBH && p.pdNO == chitiet.pdNO).SingleOrDefault();
                    phieu.GSBH = chitiet.GSBH;
                    phieu.pdNO = chitiet.pdNO;
                    phieu.CLBH = chitiet.CLBH;
                    phieu.Qty = chitiet.Qty;
                    phieu.CLmemo = chitiet.CLmemo;
                    phieu.Memo0 = chitiet.Memo0;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool XoaPhieuMuaHang(string pdno, string gsbh, string CLBH, string size)
        {
            try
            {
                pdna1 phieu = db.pdna1s.Where(p => p.GSBH == gsbh && p.pdNO == pdno && p.CLBH == CLBH && p.Size == size).SingleOrDefault();
                db.pdna1s.DeleteOnSubmit(phieu);
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