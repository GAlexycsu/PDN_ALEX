using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;

namespace iOffice.DAO
{
    public class QPDNFlowDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<QPDNFlow> LayDSQPDNFlow( string idcongty)
        {
             return db.QPDNFlows.Where(p => p.GSBH == idcongty).ToList();
          
        }
        public static QPDNFlow LayQuyTrinhTheoDonVi(string iddonvi, string idcongty,string idloaiphieu)
        {
            return db.QPDNFlows.Where(p => p.BADEPID == iddonvi && p.GSBH == idcongty&& p.abtype==idloaiphieu).SingleOrDefault();
        }
        public static QPDNFlow LayQuyTrinhTheoDonViLoaiPhieu(string iddonvi, string idcongty, string idloaiphieu)
        {
            return db.QPDNFlows.Where(p => p.BADEPID == iddonvi && p.GSBH == idcongty && p.abtype == idloaiphieu).SingleOrDefault();
        }
        public static List<QPDNFlow> QryQuyTrinhTheoDonVi(string iddonvi, string idcongty, string idloaiphieu,int idloaidonvi)
        {
           // return db.QPDNFlows.Where(p => p.BADEPID == iddonvi && p.GSBH == idcongty && p.abtype == idloaiphieu && p.IDLoaiDonVi == idloaidonvi).ToList();
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH==idcongty && h.abtype==idloaiphieu && h.IDLoaiDonVi==idloaidonvi orderby h.ABstep, h.ABPS ascending select h;
            return list.ToList();
            
        }
        public static List<QPDNFlow> QryQuyTrinhTheoDonViLoaiPhieu(string iddonvi, string idcongty, string idloaiphieu, int idloaidonvi)
        {
            //return db.QPDNFlows.Where(p => p.BADEPID == iddonvi && p.GSBH == idcongty && p.abtype == idloaiphieu && p.IDLoaiDonVi==idloaidonvi ).ToList();
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.IDLoaiDonVi == idloaidonvi orderby h.ABstep,h.ABPS ascending select h;
            return list.ToList();
             
        }
        public static List<QPDNFlow> QryQuyTrinhAll(string iddonvi, string idcongty, string idloaiphieu)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu  orderby h.ABstep,h.ABPS ascending select h;
            return list.ToList();
        }
        public static List<QPDNFlow> QryQuyTrinhTheoDieuKien(string iddonvi, string idcongty, string idloaiphieu, int idloaidonvi, int Abstep,int idCapDuyet)
        {
            try
            {
                var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.IDLoaiDonVi == idloaidonvi && h.ABstep>=Abstep && h.IDCapDuyet>=idCapDuyet orderby h.ABstep,h.ABPS ascending select h;
                 return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<QPDNFlow> QryQuyTrinhTheoDieuKien2(string iddonvi, string idcongty, string idloaiphieu, int idloaidonvi, int Abstep)
        {
            try
            {
                var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.IDLoaiDonVi == idloaidonvi && h.ABstep >= Abstep orderby h.ABstep,h.ABPS ascending select h;
                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool ThemQuyTrinh(QPDNFlow pquytrinh)
        {
            try
            {
                db.QPDNFlows.InsertOnSubmit(pquytrinh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaQuyTrinh(QPDNFlow pquytrinh)
        {
            try
            {
                QPDNFlow quytrinh = new QPDNFlow();
                quytrinh = db.QPDNFlows.Where(p => p.IDQuyTrinh == pquytrinh.IDQuyTrinh && p.GSBH==pquytrinh.GSBH && p.abtype==pquytrinh.abtype && p.ABstep==pquytrinh.ABstep && p.BADEPID==pquytrinh.BADEPID && p.ABPS==pquytrinh.ABPS).FirstOrDefault();
                quytrinh.IDQuyTrinh = pquytrinh.IDQuyTrinh;
                quytrinh.GSBH = pquytrinh.GSBH;
                quytrinh.abtype = pquytrinh.abtype;
                quytrinh.abtypenameTW = pquytrinh.abtypenameTW;
                quytrinh.BADEPID = pquytrinh.BADEPID;
                quytrinh.tendonviTW = pquytrinh.tendonviTW;
                quytrinh.NguoiDuyet = pquytrinh.NguoiDuyet;
                quytrinh.USERNAME = pquytrinh.USERNAME;
                quytrinh.ABstep = pquytrinh.ABstep;
                quytrinh.DonViThongQua = pquytrinh.DonViThongQua;
                quytrinh.tendonvithongqua = pquytrinh.tendonvithongqua;
                quytrinh.IDLoaiDonVi = pquytrinh.IDLoaiDonVi;
                quytrinh.DepartmentTypeNameTW=pquytrinh.DepartmentTypeNameTW;
                quytrinh.ABstep = pquytrinh.ABstep;
                quytrinh.IDChucVu = pquytrinh.IDChucVu;
                quytrinh.TenChucVuTiengHoa = pquytrinh.TenChucVuTiengHoa;
                quytrinh.ABPS = pquytrinh.ABPS;
               // quytrinh.VangMat = pquytrinh.VangMat;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaQuyTrinh( string GSBH, string abtype, int ABstep, string BADEPID, int ABPS)
        {
            try
            {
                QPDNFlow quytrinh = new QPDNFlow();
                quytrinh = db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.ABstep == ABstep && p.BADEPID == BADEPID && p.ABPS == ABPS).FirstOrDefault();
                db.QPDNFlows.DeleteOnSubmit(quytrinh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool XoaQuyTrinh1(QPDNFlow quytrinhxd)
        {
            try
            {

                QPDNFlow quytrinh = db.QPDNFlows.Where(p => p.IDQuyTrinh == quytrinhxd.IDQuyTrinh && p.GSBH==quytrinhxd.GSBH && p.abtype==quytrinhxd.abtype && p.ABstep==quytrinhxd.ABstep && p.ABPS==quytrinhxd.ABPS && p.BADEPID==quytrinhxd.BADEPID).FirstOrDefault();
                db.QPDNFlows.DeleteOnSubmit(quytrinh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static QPDNFlow TimMaQuytrinh(string GSBH,string BADePid,string abtype,int abstep, int abps)
        {
            return db.QPDNFlows.Where(p => p.GSBH==GSBH && p.BADEPID==BADePid && p.abtype==abtype && p.ABstep==abstep && p.ABPS==abps).FirstOrDefault();
        }
        public static List<QPDNFlow> DanhSachQuytrinhHonBuocTruoc(string GSBH, string BADePid, string abtype, int abstep, int abps)
        {
            //return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.BADEPID == BADePid && p.abtype == abtype && p.ABstep == abstep && p.ABPS == abps).FirstOrDefault();
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.BADEPID == BADePid && p.abtype == abtype && p.ABstep == abstep && p.ABPS > abps select p;
            return list.ToList();

        }
        public static int DemQPDNFlow()
        {
            int dem = 0;
            try
            {

                dem = db.QPDNFlows.Count();
                return dem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<QPDNFlow> QryQuyTrinhTheoBoPhan(string mabophan, string macongty)
        {
            return db.QPDNFlows.Where(p => p.BADEPID == mabophan && p.GSBH == macongty).ToList();
            
        }
        public static QPDNFlow TimBuocKyThongQuaNguoiDuyet(string manguoiduyet, string macongty, string madonvi, string maloaiphieu)
        {
            return db.QPDNFlows.Where(p => p.abtype == maloaiphieu && p.BADEPID == madonvi && p.NguoiDuyet == manguoiduyet && p.GSBH == macongty).FirstOrDefault();
        }
        public static QPDNFlow TimNguoiTrongQuyTrinh(string manguoi, string maloaiphieu, string madonvi, string macongty)
        {
            return db.QPDNFlows.Where(p => p.NguoiDuyet == manguoi && p.abtype == maloaiphieu && p.BADEPID == madonvi && p.GSBH == macongty).FirstOrDefault();
        }
        public static QPDNFlow TimCapDuyetTrongQuyTrinh(string maloaiphieu, string madonvi, string macongty,int buocduyet)
        {
            return db.QPDNFlows.Where(p => p.ABstep == buocduyet && p.abtype == maloaiphieu && p.BADEPID == madonvi && p.GSBH == macongty).FirstOrDefault();
        }
        public static List<QPDNFlow> QryQuyTrinhTheoDonViTaiBuocDuyet(string iddonvi, string idcongty, string idloaiphieu, int buocky)
        {
            // return db.QPDNFlows.Where(p => p.BADEPID == iddonvi && p.GSBH == idcongty && p.abtype == idloaiphieu && p.IDLoaiDonVi == idloaidonvi).ToList();
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.ABstep >= buocky orderby h.ABstep,h.ABPS ascending select h;
            return list.ToList();

        }
        public static bool CapNhatQuyTrinh(QPDNFlow quytrinh)
        {
            try
            {
                QPDNFlow ss = db.QPDNFlows.Where(p => p.GSBH==quytrinh.GSBH && p.abtype==quytrinh.abtype && p.ABstep==quytrinh.ABstep && p.ABPS==quytrinh.ABPS && p.BADEPID==quytrinh.BADEPID).FirstOrDefault();
                
                ss.ABstep = quytrinh.ABstep;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static bool CapNhatQuyTrinhNew(QPDNFlow quytrinh)
        {
            try
            {
                QPDNFlow ss = db.QPDNFlows.Where(p => p.GSBH == quytrinh.GSBH && p.abtype == quytrinh.abtype && p.ABstep == quytrinh.ABstep && p.IDQuyTrinh == quytrinh.IDQuyTrinh && p.BADEPID == quytrinh.BADEPID).FirstOrDefault();

                //ss.GSBH = quytrinh.GSBH;
                
                //ss.abtype = quytrinh.abtype;
                //ss.BADEPID = quytrinh.BADEPID;
                //ss.ABstep = quytrinh.ABstep;
                ss.ABPS = quytrinh.ABPS+1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static List<QPDNFlow> QryQuyTrinhTheoCapDuyet(string iddonvi, string idcongty, string idloaiphieu)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu  orderby  h.IDCapDuyet ascending select h;
            return list.ToList();

        }
        public static List<QPDNFlow> QryQuyTrinhTheoCapDuyet1(string iddonvi, string idcongty, string idloaiphieu)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu orderby h.ABstep,h.ABPS ascending select h;
            return list.ToList();

        }
        public static QPDNFlow TimCapTiepTheoTrongQuyTrinh(string iddonvi, string idcongty, string idloaiphieu, int buoctieptheo)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.ABstep==buoctieptheo select h;
            return list.FirstOrDefault();

        }
        public static QPDNFlow TimCapTiepTheoTrongQuyTrinh1(string iddonvi, string idcongty, string idloaiphieu, int capduyet)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.IDCapDuyet == capduyet select h;
            return list.FirstOrDefault();

        }
        public static QPDNFlow TimBuocTiepTheoTrongQuyTrinh1(string iddonvi, string idcongty, string idloaiphieu, int buoc)
        {
            var list = from h in db.QPDNFlows where h.BADEPID == iddonvi && h.GSBH == idcongty && h.abtype == idloaiphieu && h.ABstep == buoc select h;
            return list.FirstOrDefault();

        }
        public static QPDNFlow TimNguoiDuyetTrongQuyTrinh(string idDonVi, string idCongTy, string abtype, string UserID)
        {
            try
            {
                var list = from p in db.QPDNFlows where p.BADEPID == idDonVi && p.GSBH == idCongTy && p.abtype == abtype && p.NguoiDuyet == UserID select p;
                return list.SingleOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static QPDNFlow TimMaQuyTrinhTruocKhiThem(string GSBH, string abtype, string BADEPID, int ABStep, int ABPS)
        {
            try
            {
                return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS==ABPS).SingleOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<QPDNFlow> TimABPSQuyTrinhMAX(string GSBH, string abtype, string BADEPID, int ABStep)
        {
            try
            {
                //return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS == ABPS).SingleOrDefault();
                var list = db.QPDNFlows.Where(a => a.GSBH == GSBH && a.abtype == abtype && a.BADEPID == BADEPID && a.ABstep == ABStep).ToList();
                // var l = list.Where(a=>a.ABPS==list.Max(k=>k.ABPS)).SingleOrDefault();
                // return l;
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<QPDNFlow> DanhSachQuyTrinhTrong1Buoc(string GSBH, string abtype, string BADEPID, int ABStep)
        {
            try
            {
                return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<QPDNFlow> DanhSachQuyTrinhHonBuocHienTai(string GSBH, string abtype, string BADEPID, int ABStep)
        {
            try
            {
                //return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep >ABStep).ToList();
                var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep > ABStep orderby p.ABstep, p.ABPS descending select p;
                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<QPDNFlow> DanhSachQuyTrinhHonHoacBangBuocHienTaiABPS(string GSBH, string abtype, string BADEPID, int ABStep, int abps)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS >= abps orderby p.ABstep, p.ABPS descending select p;
            return list.ToList();
        }
        public static List<QPDNFlow> DanhSachQuyTrinhLonHonBuocHienTaiABPS(string GSBH, string abtype, string BADEPID, int ABStep, int abps)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS > abps orderby p.ABPS ascending select p;
            return list.ToList();
        }
        public static QPDNFlow DanhSachQuyTrinhLonHonBuocTiepTheoABPS(string GSBH, string abtype, string BADEPID, int ABStep, int abps)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS == abps select p;
            return list.SingleOrDefault();
        }
        public static QPDNFlow TimBuocKyCanSua(string GSBH, string abtype, string BADEPID, int ABStep, int abps)
        {
            return db.QPDNFlows.Where(p => p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS == abps).FirstOrDefault();
        }
        public static QPDNFlow TimNguoiTrongQuyTrinh(string GSBH, string abtype, string BADEPID, int ABStep)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep==ABStep orderby p.ABstep, p.ABPS ascending select p;
            return list.FirstOrDefault();
        }
        public static List<QPDNFlow> DanhSachNguoiTrongQuyTrinh(string GSBH, string abtype, string BADEPID, int ABStep)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep >= ABStep orderby p.ABstep, p.ABPS descending select p;
            return list.ToList();
        }
        public static List<QPDNFlow> DanhSachNguoiDuyetTrong1Cap(string GSBH, string abtype, string BADEPID, int ABStep, int abps)
        {
            var list = from p in db.QPDNFlows where p.GSBH == GSBH && p.abtype == abtype && p.BADEPID == BADEPID && p.ABstep == ABStep && p.ABPS == abps orderby p.ABPS ascending select p;
            return list.ToList();
        }
    }
}