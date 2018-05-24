using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class TrangThaiDuyetDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static bool ThemTrangThaiDuyet(ABTrangThaiDuyet trangthai)
        {
            try
            {
                db.ABTrangThaiDuyets.InsertOnSubmit(trangthai);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaTrangThaiDuyet(ABTrangThaiDuyet trangthai,bool duyet)
        {
            try
            {
                ABTrangThaiDuyet abtrangthai = new ABTrangThaiDuyet();
                abtrangthai = db.ABTrangThaiDuyets.Where(p => p.IDTrangThai == trangthai.IDTrangThai).FirstOrDefault();
                abtrangthai.GSBH = trangthai.GSBH;
                abtrangthai.pdno = trangthai.pdno;
                if (duyet)
                {
                    abtrangthai.Yn = 8;
                }
                else
                {
                    abtrangthai.Yn = 2;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        public static ABTrangThaiDuyet TimKiemMaVanTheoTrangThaiDuyet(string idvanban, string idcongty)
        {
            try
            {
                return db.ABTrangThaiDuyets.Where(p => p.pdno == idvanban && p.GSBH == idcongty).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaTrangThaiDuyet(int idtrangthai)
        {
            try
            {
                 ABTrangThaiDuyet trangthai = db.ABTrangThaiDuyets.Where(p => p.IDTrangThai == idtrangthai).SingleOrDefault();
                db.ABTrangThaiDuyets.DeleteOnSubmit(trangthai);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool XoaTrangThaiDuyetBiXoa(string maphieu, string macongty)
        {
            try
            {
                ABTrangThaiDuyet trangthai = db.ABTrangThaiDuyets.Where(p => p.pdno == maphieu && p.GSBH == macongty).SingleOrDefault();
                db.ABTrangThaiDuyets.DeleteOnSubmit(trangthai);
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