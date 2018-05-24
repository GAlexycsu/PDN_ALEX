using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class PDNSheetFlowDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<PDNSheetFlow> QryPDNSheetFlow()
        {
            try
            {
                return db.ChiTietBuocKies.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ThemPDNSheetFlow(PDNSheetFlow pchitiet)
        {
            try
            {
                db.ChiTietBuocKies.InsertOnSubmit(pchitiet);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaPDNSheetFlow(PDNSheetFlow pchitiet,bool duyet)
        {
            try
            {
                PDNSheetFlow ch = new PDNSheetFlow();
                ch = db.ChiTietBuocKies.Where(p => p.Id == pchitiet.Id).FirstOrDefault();
                ch.Id = pchitiet.Id;
               
                ch.pdno = pchitiet.pdno;
                ch.abstep = pchitiet.abstep;
                if (duyet == true)
                {
                    ch.Yn = 1;
                }
                else
                {
                    ch.Yn = 2;
                }
                
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaPDNSheetFlow(int idchitiet)
        {
            try
            {
                PDNSheetFlow chi = new PDNSheetFlow();
                chi = db.ChiTietBuocKies.Where(p => p.Id == idchitiet).FirstOrDefault();
                db.ChiTietBuocKies.DeleteOnSubmit(chi);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static PDNSheetFlow LayPDNSheetFlowTheoIdVanBanBuocKy(string idvanban, int buocky)
        {
            var list = from p in db.ChiTietBuocKies.Where(a => a.pdno == idvanban && a.abstep == buocky) select p;
            return list.FirstOrDefault();
        }
        public static PDNSheetFlow LayPDNSheetFlowCuaBuoc1(string idvanban, string idcongty)
        {
            try
            {
                return db.ChiTietBuocKies.Where(p => p.pdno == idvanban && p.GSBH == idcongty && p.abstep == 1).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static PDNSheetFlow KiemTraPhieuTrongBangPDNSheetFlow(string maphieu, string macongty,string manguoiduyet)
        {
            try
            {
                return db.ChiTietBuocKies.Where(p => p.pdno == maphieu && p.GSBH == macongty && p.IdNguoiDuyet==manguoiduyet).FirstOrDefault();

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static PDNSheetFlow TimMaPDNSheetFlow(string maphieu, string macongty, int capky, int buocky)
        {
            try
            {
                return db.ChiTietBuocKies.Where(p => p.pdno == maphieu && p.GSBH == macongty && p.abstep == capky && p.ABPS == buocky).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<PDNSheetFlow> QryPDNSheetFlowTheoPhieu(string maphieu, string macongty)
        {
            var list = from p in db.ChiTietBuocKies where p.pdno == maphieu && p.GSBH == macongty select p;
            return list.ToList();
        }
        public static bool XoaPDNSheetFlowBiHuy(string maphieu, string macongty)
        {
            try
            {
                List<PDNSheetFlow> list= db.ChiTietBuocKies.Where(p=>p.pdno==maphieu && p.GSBH==macongty).ToList();
                if (list.Count > 0)
                {
                    foreach (PDNSheetFlow chitiet in list)
                    {
                        db.ChiTietBuocKies.DeleteOnSubmit(chitiet);
                        db.SubmitChanges();
                    }
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