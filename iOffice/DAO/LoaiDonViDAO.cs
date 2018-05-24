using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class LoaiDonViDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<AbDepartmentType> QryLoaiDonVi(string macongty)
        {
            try
            {
                return db.AbDepartmentTypes.Where(p => p.GSBH == macongty).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static AbDepartmentType TimMaLoaiDonVi(int maloaidonvi, string macongty)
        {
            try
            {
                return db.AbDepartmentTypes.Where(p => p.DepartmentTypeID == maloaidonvi && p.GSBH ==macongty).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}