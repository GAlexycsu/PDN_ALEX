using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class BDepartmentDAO
    {
       static iOfficeDataContext db = new iOfficeDataContext();
       public static List<BDepartment> DanhSachBoPhan(string idcongty)
       {
           return db.BDepartments.Where(p => p.GSBH == idcongty && p.PlanYN == true && p.DepartmentTypeID != 0 && p.Dclass == "E" && (p.IdUserChuQuan != null || p.IdUserChuQuan != "")).ToList();
       }
       public static List<BDepartment> DanhSachBoPhan()
       {
           return db.BDepartments.Where(p=>p.PlanYN==true && p.DepartmentTypeID!=0 && p.Dclass=="E" && (p.IdUserChuQuan!=null || p.IdUserChuQuan!="" )).ToList();
       }
       public static BDepartment TimMaDonVi(string madonvi, string macongty)
       {
           return db.BDepartments.Where(p => p.ID == madonvi && p.GSBH == macongty).FirstOrDefault();
       }
       public static BDepartment TimTenDonVi(string tendonvi, string macongty)
       {
           return db.BDepartments.Where(p => p.DepName == tendonvi && p.GSBH == macongty).FirstOrDefault();
       }
       public static List<BDepartment> TimKiemDonViTheoDieuKien(string dieukien,string macongty)
       {
           return db.BDepartments.Where(p => p.ID.Contains(dieukien.ToUpper()) || p.DepName.ToUpper().Contains(dieukien.ToUpper())&& p.GSBH==macongty).ToList();
       }
       public static BDepartment LayTenBoPhanTheoMaNguoiDuyet(string manguoiduyet)
       {
           BDepartment list = (from p in db.Busers2s
                               from q in db.BDepartments
                               where (p.BADEPID == q.ID && p.USERID == manguoiduyet)
                               select q).FirstOrDefault();
           return list;
       }
       public static BDepartment LayBoPhanTheoMaNguoiDuyet(string manguoiduyet,string macongty)
       {
           BDepartment list = (from p in db.Busers2s
                               from q in db.BDepartments
                               where (p.BADEPID == q.ID && p.USERID == manguoiduyet && p.GSBH==macongty && q.PlanYN==true && q.DepartmentTypeID!=0 && q.Dclass=="E" && (q.IdUserChuQuan!=null || q.IdUserChuQuan!="" ))
                               select q).FirstOrDefault();
           return list;
       }
       public static bool ThemBoPhan(BDepartment pdepartment)
       {
           try
           {
               db.BDepartments.InsertOnSubmit(pdepartment);
               db.SubmitChanges();
               return true;
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
               BDepartment depart = new BDepartment();
               depart = db.BDepartments.Where(p => p.ID == pdepart.ID).FirstOrDefault();
               depart.ID = pdepart.ID;
               depart.GSBH = pdepart.GSBH;
               depart.DepartmentTypeID = pdepart.DepartmentTypeID;
               depart.IdUserChuQuan = pdepart.IdUserChuQuan;
               depart.DepName = pdepart.DepName;
               db.SubmitChanges();
               return true;
           }
           catch (Exception)
           {
               throw;
           }
 
       }
    }
}