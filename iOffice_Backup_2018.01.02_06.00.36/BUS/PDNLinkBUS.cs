using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class PDNLinkBUS
    {
        public static List<PDNLink> GetLinkAttactFileByPDNO(string congty, string pdno)
        {
            try
            {
                return PDNLinkDAO.GetLinkAttactFileByPDNO(congty, pdno);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool InsertFile(PDNLink pdn)
        {
            try
            {
                return PDNLinkDAO.InsertFile(pdn);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool UpdateFile(PDNLink pdn)
        {
            try
            {
                return PDNLinkDAO.UpdateFile(pdn);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}