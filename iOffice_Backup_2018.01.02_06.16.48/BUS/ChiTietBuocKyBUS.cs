using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class PDNSheetFlowBUS
    {
        public static List<PDNSheetFlow> QryPDNSheetFlow()
        {
            try
            {
                return PDNSheetFlowDAO.QryPDNSheetFlow();
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
                return PDNSheetFlowDAO.ThemPDNSheetFlow(pchitiet);
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
                return PDNSheetFlowDAO.SuaPDNSheetFlow(pchitiet,duyet);
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
                return PDNSheetFlowDAO.XoaPDNSheetFlow(idchitiet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static PDNSheetFlow LayPDNSheetFlowTheoIdVanBanBuocKy(string idvanban, int buocky)
        {
            try
            {
                return PDNSheetFlowDAO.LayPDNSheetFlowTheoIdVanBanBuocKy(idvanban, buocky);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaPDNSheetFlowBiHuy(string maphieu, string macongty)
        {
            try
            {
             
                return PDNSheetFlowDAO.XoaPDNSheetFlowBiHuy(maphieu, macongty);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}