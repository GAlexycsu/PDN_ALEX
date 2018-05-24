using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.BUS
{
    public class Buser_SecureBUS
    {
        public static Buser_Securety TimKiemNhanVien_MaBaoMatTheoIDNhanVien_Ngay(string idNhanVien, DateTime ngay)
        {
            return Buser_SecureDAO.TimKiemNhanVien_MaBaoMatTheoIDNhanVien_Ngay(idNhanVien, ngay);
        }
    }
}