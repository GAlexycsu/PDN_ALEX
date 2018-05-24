using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class CanBoDonViBUS
    {
        public static List<CanBoDonVi> LayDanhSachCanBoDonVi()
        {
            try
            {
                return CanBoDonViDAO.LayDanhSachCanBoDonVi();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ThemCanBoDonVi(CanBoDonVi pcanbo)
        {
            try
            {
                return CanBoDonViDAO.ThemCanBoDonVi(pcanbo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaCanBoDonVi(CanBoDonVi pcanbo)
        {
            try
            {
                return CanBoDonViDAO.SuaCanBoDonVi(pcanbo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}