using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class BDepartmentBUS
    {
        public static List<BDepartment> DanhSachBoPhan(string idcongty)
        {
            return BDepartmentDAO.DanhSachBoPhan(idcongty);
        }
        public static List<BDepartment> DanhSachBoPhan()
        {
            return BDepartmentDAO.DanhSachBoPhan();
        }
        public static BDepartment LayTenBoPhanTheoMaNguoiDuyet(string manguoiduyet)
        {
            return BDepartmentDAO.LayTenBoPhanTheoMaNguoiDuyet(manguoiduyet);
        }
        public static BDepartment TimMaDonVi(string madonvi, string macongty)
        {
            try
            {
                return BDepartmentDAO.TimMaDonVi(madonvi, macongty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ThemBoPhan(BDepartment pdepartment)
        {
            try
            {
                return BDepartmentDAO.ThemBoPhan(pdepartment);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public static bool SuaBoPhan(BDepartment pdepart)
        {
            try
            {
                return BDepartmentDAO.SuaBoPhan(pdepart);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}