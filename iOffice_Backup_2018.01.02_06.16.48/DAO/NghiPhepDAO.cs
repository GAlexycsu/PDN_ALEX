using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.DAO
{
    public class NghiPhepDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<ABJobAgent> QryNghiPhep(string macongty)
        {
            try
            {
                return db.ABJobAgents.Where(p => p.GSBH == macongty).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        //public static LayNguoiNguoiVangMatTheoNgayNghi(string macongty, string manguoiduyet)
        //{
        //    DateTime ngay=DateTime.Today;
        //}
        public static ABJobAgent KiemTraNguoiNghi(DateTime ngaytao,DateTime denngay, string manguoiduyet, string macongty)
        {
            //var query = from post in Context.Table where input_date >= post.start_date && input_date <= post.end_date 

            var list = from p in db.ABJobAgents.Where(a => a.IDNguoiDuyet == manguoiduyet && a.GSBH == macongty && ngaytao >= a.TuNgay && denngay <= a.DenNgay)
                       select p;
            return list.FirstOrDefault();

        }
        public static List<ABJobAgent> Kiemtranghiphep(DateTime ngaytao, string manguoiduyet, string macongty)
        {
            var list = db.ExecuteQuery<ABJobAgent>("select * from ABJobAgent where GSBH='" + macongty + "' and IDNguoiDuyet='" + manguoiduyet + "' and '"+ngaytao+"' between TuNgay and DenNgay");
            return list.ToList();
        }
        public static bool ThemDuLieu(ABJobAgent pnghiphep)
        {
            try
            {
                db.ABJobAgents.InsertOnSubmit(pnghiphep);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaDuLieu(ABJobAgent pnghiphep)
        {
            try
            {
                ABJobAgent nghi = new ABJobAgent();
                nghi = db.ABJobAgents.Where(p => p.ID == pnghiphep.ID).FirstOrDefault();
                nghi.ID = pnghiphep.ID;
                nghi.GSBH = pnghiphep.GSBH;
                nghi.TuNgay = pnghiphep.TuNgay;
                nghi.DenNgay = pnghiphep.DenNgay;
                nghi.IDNguoiDuyet = pnghiphep.IDNguoiDuyet;
                nghi.tennguoiuyquyen = pnghiphep.tennguoiuyquyen;
                nghi.IDNguoiDuocUyQuyen = pnghiphep.IDNguoiDuocUyQuyen;
                nghi.tennguoithaythe = pnghiphep.tennguoithaythe;
                nghi.ThongQua = pnghiphep.ThongQua;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaDuLieu(int id)
        {
            try
            {
                ABJobAgent nghi = new ABJobAgent();
                nghi = db.ABJobAgents.Where(p => p.ID == id).FirstOrDefault();
                db.ABJobAgents.DeleteOnSubmit(nghi);
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