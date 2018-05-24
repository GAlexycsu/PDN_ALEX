using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class ChucVuBUS
    {
        public static List<ChucVu> Qrychucvu()
        {
            try
            {
                return ChucVuDAO.Qrychucvu();
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
                return ChucVuDAO.TimMaChucVu(machucvu, macongty);
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
                return ChucVuDAO.ThemChucVu(pchucvu);
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
                return ChucVuDAO.SuaChucVu(pchucvu);
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
                return ChucVuDAO.XoaChucVu(idchucvu);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}