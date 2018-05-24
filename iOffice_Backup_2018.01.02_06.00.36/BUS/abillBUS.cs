using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class abillBUS
    {
        public static List<abill> ListBill()
        {
            return abillDAO.ListBill();
        }
        public static abill SearchAbillByID(string id)
        {
            return abillDAO.SearchAbillByID(id);
        }
        public static bool InsertAbill(abill bill)
        {
            return abillDAO.InsertAbill(bill);
        }
        public static bool UpdateAbill(abill pabill)
        {
            return abillDAO.UpdateAbill(pabill);
        }
        public static bool DeleteAbill(string id)
        {
            return abillDAO.DeleteAbill(id);
        }
    }
}