using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class SuppliesDAO
    {
       static  iOfficeDataContext db = new iOfficeDataContext();
        public static bool ThemVatTu(BOfSupply pvattu)
        {
            try
            {
                db.BOfSupplies.InsertOnSubmit(pvattu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool SuaVatTu(BOfSupply pvattu)
        {
            try
            {

                BOfSupply vattu = new BOfSupply();
                vattu = db.BOfSupplies.Where(p => p.IDOfSupplies == pvattu.IDOfSupplies).FirstOrDefault();
                vattu.IDOfSupplies = pvattu.IDOfSupplies;
               
                vattu.OfSuppliesName = pvattu.OfSuppliesName;
                
                vattu.BUnit = pvattu.BUnit;
                vattu.BNumber = pvattu.BNumber;
                vattu.BCommnent = pvattu.BCommnent;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool SuaVatTu1(BOfSupply pvattu)
        {
            try
            {

                BOfSupply vattu = new BOfSupply();
                vattu = db.BOfSupplies.Where(p => p.IDOfSupplies == pvattu.IDOfSupplies).FirstOrDefault();
                vattu.IDOfSupplies = pvattu.IDOfSupplies;

                vattu.OfSuppliesName = pvattu.OfSuppliesName;

                vattu.BUnit = pvattu.BUnit;
                
                vattu.BCommnent = pvattu.BCommnent;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool XoaVatTu(int mavattu)
        {
            try
            {
                 BOfSupply vattu = db.BOfSupplies.Where(p => p.IDOfSupplies == mavattu).SingleOrDefault();
                db.BOfSupplies.DeleteOnSubmit(vattu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<BOfSupply> QryHangTheoPhieu(string maphieu, string macongty)
        {
            var list = from p in db.pdnas
                       join h in db.BOfSupplies on p.pdno equals h.pdno
                       where p.pdno == h.pdno && p.GSBH == h.GSBH && h.GSBH == macongty && h.pdno == maphieu
                       orderby h.IDOfSupplies ascending
                       select h;
            return list.ToList();
                 
        }
        [WebMethod]
        public static List<ListDonViTinhResult> SearchAjax(string article)
        {

            var ls = new List<ListDonViTinhResult>();
            //ls = db.ListDonViTinh(article).ToList();
            ls = db.ListDonViTinh(article).ToList();
            return ls;
        }
    }
}