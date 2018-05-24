using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;

namespace iOffice.DAO
{
    public class AbconDAO
    {
       static iOfficeDataContext db = new iOfficeDataContext();
      
        public static int DemSoLuongMaVanBan_CapDuyet()
        {
            //var list = (from p in db.Abcons
            //            from q in db.pdnas
            //            where (p.pdno == q.pdno)
            //            select p.pdno).ToList().Count();
            //dem = db.PDNA_ABDEs.Count();
            //var list1 = (from p in db.Abcons
            //            from q in db.pdnas
            //            where (p.pdno == q.pdno)
            //            select p.pdno).Count();
          int dem = 0;
            try
            {
                //if (kiemTraBiXoa)
                //{
                //    //dem = db..Where(vb => vb.BiXoa == false).Count();
                //    //dem=db.Abcons.Where(vb=>vb.pdno)
                //    // return maVB;
                //    dem = list;
                //}
                //else
                //{
                //    dem = list1;
                //}
                //if (db != null)
                //    db.ToString();
                //else
                //{
                //    //don't
                //}
            return  dem = db.Abcons.ToList().Count();
               // dem = list;
                //return dem;
                //List<Abcon> list = db.Abcons.ToList();
                //str
            }
            catch (Exception )
            {
                
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return -1;
            }
            finally
            {
                if (db != null)
                    db.ToString();

            }
        }

        public static Abcon TimKiemChiTietXetDuyetTheoMa(int maChiTietXetDuyet,bool kiemtrabixoa=true)
        {
            
            try
            {
                if (kiemtrabixoa)
                {
                    Abcon ct = db.Abcons.Where(ctxd => ctxd.IDCT == maChiTietXetDuyet && ctxd.bixoa==false).FirstOrDefault();
                    db.ToString();
                    return ct;
                }
                else
                {
                    Abcon ct = db.Abcons.Where(ctxd => ctxd.IDCT == maChiTietXetDuyet).FirstOrDefault();
                    db.ToString();
                    return ct;
                }
            }
            catch (Exception )
            {

                //Util.WriteFileLogServer("TimKiemChiTietXetDuyetTheoMa\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return null;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }

        }
       
        public static List<Abcon> QryChiTietXetDuyet1(int IDCT, bool kiemtrabixoa = true)
        {

            try
            {
                if (kiemtrabixoa)
                {
                    //List<Abcon> ll = db.Abcons.Where(cd => cd.Id_VB_CD == IDCT).ToList();
                    //db.ToString();
                    //return ll;
                    List<Abcon> ll = (from a in db.Abcons
                                      
                                      where (a.IDCT == IDCT)
                                      select a).ToList();
                    return ll;
                }

                List<Abcon> ll1 = (from a in db.Abcons

                                  where (a.IDCT == IDCT)
                                  select a).ToList();
                return ll1;

            }
            catch (Exception)
            {

                //Util.WriteFileLogServer("QryChiTietXetDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return new List<Abcon>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static List<Abcon> QryChiTietXetDuyetTheoIdVanBan(string idvanban, bool kiemtrabixoa = true)
        {

            try
            {
                if (kiemtrabixoa)
                {
                    //List<Abcon> ll = db.Abcons.Where(cd => cd.Id_VB_CD == IDCT).ToList();
                    //db.ToString();
                    //return ll;
                    List<Abcon> ll = (from a in db.Abcons

                                      where (a.pdno == idvanban)
                                     orderby a.IDCT select a).ToList();
                    return ll;
                }

                List<Abcon> ll1 = (from a in db.Abcons

                                   where (a.pdno == idvanban)
                                  orderby a.IDCT  select a).ToList();
                return ll1;

            }
            catch (Exception)
            {

                //Util.WriteFileLogServer("QryChiTietXetDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return new List<Abcon>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static Abcon LayChiTietXetDuyetCuaMotNhanVien(string idNhanVien, string idVanBan)
        {
          
            try
            {
               
                    var chitiet = from ct in db.Abcons
                                  from p in db.pdnas
                                  from q in db.Busers2s
                                  where ct.Auditor==q.USERID && ct.pdno==p.pdno && p.pdno == idVanBan && ct.Auditor == idNhanVien 
                                  select ct;
                    db.ToString();
                    return chitiet.FirstOrDefault();
              
            }
            catch (Exception )
            {
                //Util.WriteFileLogServer("LayChiTietXetDuyetCuaMotNhanVien\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return null;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static Busers2 LayNhanVienTheoIdChiTietXetDuyet(int idChiTietXetDuyet, bool kiemTraBiXoa = true)
        {
            try
            {

                ////var list = (from nv in db.Busers
                ////            from ct in db.Abcons
                ////            where (nv.USERID == ct.Auditor && ct.IDCT == idChiTietXetDuyet)
                //            select nv).FirstOrDefault();
               
                if (kiemTraBiXoa)
                {
                    //var list2 = (from q in db.Busers
                    //             join p in db.Abcons
                    //                 on q.USERID equals p.Auditor
                    //             where p.IDCT.Equals(idChiTietXetDuyet)
                    //             select q).FirstOrDefault();
                    var list = (from nv in db.Busers2s
                                from ct in db.Abcons
                                where (nv.USERID == ct.Auditor && ct.IDCT == idChiTietXetDuyet)
                                select nv).FirstOrDefault();
                    
                }
                var lstnv2 = from nv in db.Busers2s
                             from ctxd in db.Abcons
                             where nv.USERID == ctxd.Auditor && ctxd.IDCT == idChiTietXetDuyet 
                             select nv;
                db.ToString();
                return lstnv2.FirstOrDefault();
            }
            catch (Exception )
            {

                //Util.WriteFileLogServer("LayNhanVienTheoIdChiTietXetDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return null;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static bool ThemChiTiet(Abcon ct)
        {
            try
            {
                db.Abcons.InsertOnSubmit(ct);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool SuaChiTiet(Abcon ct,bool kiemtrabixoa=true)
        {
            Abcon chitiet = new Abcon();

            if (kiemtrabixoa)
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            else
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            Busers2 list = (from p in db.Busers2s
                          from q in db.Abcons
                          where (p.USERID == q.Auditor)
                          select p).FirstOrDefault();
                try
                {
                    
                    chitiet.IDCT = ct.IDCT;
                    chitiet.Auditor = ct.Auditor;
                    chitiet.abrult = ct.abrult;
                    chitiet.abmomo = ct.abmomo;
                    chitiet.Password2 = list.Password2;
                    chitiet.signatue = list.signatue;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

        }
        public static bool SuaChiTietXetDuyet(Abcon ct, bool kiemtrabixoa = true)
        {
            Abcon chitiet = new Abcon();

            if (kiemtrabixoa)
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            else
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            Busers2 list = (from p in db.Busers2s
                            from q in db.Abcons
                            where (p.USERID == q.Auditor)
                            select p).FirstOrDefault();
            try
            {

                chitiet.IDCT = ct.IDCT;
                chitiet.Auditor = ct.Auditor;
                chitiet.abrult = ct.abrult;
                chitiet.abmomo = ct.abmomo;
                chitiet.Password2 = list.Password2;
                chitiet.signatue = list.signatue;
                chitiet.abtype = ct.abtype;
                chitiet.Abstep = ct.Abstep;
                chitiet.abrult = ct.abrult;
                chitiet.abps = ct.abps;
                chitiet.ABC = ct.ABC;
                chitiet.abmomo = ct.abmomo;
                chitiet.Maintitle = ct.Maintitle;
                chitiet.ncancel = ct.ncancel;
                chitiet.Password2 = list.Password2;
                chitiet.pdno = ct.pdno;
                chitiet.received = ct.received;
                chitiet.signatue = list.signatue;
                chitiet.Userdate = ct.Userdate;
                chitiet.IDChiTiet = ct.IDChiTiet;
                chitiet.Yn = ct.Yn;
                chitiet.lydokhongduyet = ct.lydokhongduyet;
                chitiet.kytoanbo = ct.kytoanbo;
                chitiet.IDCapDuyet = ct.IDCapDuyet;
                chitiet.Id_VB_CD = ct.Id_VB_CD;
                chitiet.Gsbh = ct.Gsbh;
                chitiet.from_depart = ct.from_depart;
                chitiet.from_user = ct.from_user;
                chitiet.boqua = ct.boqua;
                chitiet.bixoa = ct.bixoa;
               
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool SuaChiTietXD(Abcon ct, bool kiemtrabixoa = true)
        {
            Abcon chitiet = new Abcon();

            if (kiemtrabixoa)
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            else
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            
            try
            {

                chitiet.IDCT = ct.IDCT;
                chitiet.Auditor = ct.Auditor;
                chitiet.Gsbh = ct.Gsbh;
                chitiet.pdno = ct.pdno;
                chitiet.abmomo = ct.abmomo;
                chitiet.abtype = ct.abtype;
                chitiet.abrult = false;
                chitiet.abps = ct.abps;
                chitiet.ABC = ct.ABC;
                chitiet.bixoa = false;
                chitiet.boqua = false;
                chitiet.cothutu = true;
                chitiet.from_depart = ct.from_depart;
                chitiet.from_user = ct.from_user;
                chitiet.Id_VB_CD = ct.Id_VB_CD;
                chitiet.Maintitle = ct.Maintitle;
                chitiet.Yn = 4;
                chitiet.IDCapDuyet = ct.IDCapDuyet;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool SuaChiTietXD1(Abcon ct, bool kiemtrabixoa = true)
        {
            Abcon chitiet = new Abcon();

            if (kiemtrabixoa)
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }
            else
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
            }

            try
            {

                chitiet.IDCT = ct.IDCT;
                chitiet.Auditor = ct.Auditor;
                chitiet.Gsbh = ct.Gsbh;
                chitiet.pdno = ct.pdno;
                chitiet.abmomo = ct.abmomo;
                chitiet.abtype = ct.abtype;
                chitiet.abrult = false;
                chitiet.abps = ct.abps;
                chitiet.ABC = ct.ABC;
                chitiet.bixoa = false;
                chitiet.boqua = false;
                chitiet.cothutu = true;
                chitiet.from_depart = ct.from_depart;
                chitiet.from_user = ct.from_user;
                chitiet.Id_VB_CD = ct.Id_VB_CD;
                chitiet.Maintitle = ct.Maintitle;
                chitiet.Yn = 4;
                chitiet.IDCapDuyet = ct.IDCapDuyet;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool SuaChiTiet1(Abcon ct, string idnguoiduyet,string ghichu, bool duyet, bool kiemtrabixoa = true)
        {
            Abcon chitiet = new Abcon();
            DateTime ngayky = DateTime.Today;
            if (kiemtrabixoa)
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT && ct.Auditor==idnguoiduyet).FirstOrDefault();
            }
            else
            {
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT && ct.Auditor == idnguoiduyet).FirstOrDefault();
            }
            Busers2 list = (from p in db.Busers2s
                          from q in db.Abcons
                          where (p.USERID == q.Auditor &&  q.Auditor==idnguoiduyet)
                          select p).FirstOrDefault();
            try
            {
                if (duyet==true)
                {
                    chitiet.IDCT = ct.IDCT;
                    chitiet.Auditor = ct.Auditor;
                    chitiet.abrult = ct.abrult;
                    chitiet.abmomo = ct.abmomo;
                    chitiet.Password2 = list.Password2;
                    chitiet.signatue = list.signatue;
                    chitiet.lydokhongduyet = ghichu;
                    chitiet.Yn = 1;
                    chitiet.Userdate = ngayky;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if (duyet==false)
                    {
                        chitiet.IDCT = ct.IDCT;
                        chitiet.Auditor = ct.Auditor;
                        chitiet.abrult = ct.abrult;
                        chitiet.abmomo = ct.abmomo;
                        chitiet.Password2 = list.Password2;
                        chitiet.signatue = list.signatue;
                        chitiet.lydokhongduyet = ghichu;
                        chitiet.Userdate = ct.Userdate;
                        chitiet.Yn = 2;
                        db.SubmitChanges();
                        return true;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //return false;
                throw;
            }

        }
        public static bool SuaChiTietQuaMail( string idnguoiduyet, string maphieu,string macongty, string ghichu, bool duyet)
        {
            Abcon chitiet = new Abcon();
            DateTime ngayky = DateTime.Today;
           
                chitiet = db.Abcons.Where(p=>p.Auditor == idnguoiduyet && p.pdno==maphieu && p.Gsbh==macongty).FirstOrDefault();
            
            Busers2 list = (from p in db.Busers2s
                            from q in db.Abcons
                            where (p.USERID == q.Auditor && q.Auditor == idnguoiduyet)
                            select p).FirstOrDefault();
            try
            {
                if (duyet == true)
                {

                    chitiet.Auditor = idnguoiduyet;
                    chitiet.abrult = true;
                    chitiet.Password2 = list.Password2;
                    chitiet.signatue = list.signatue;
                    chitiet.lydokhongduyet = ghichu;
                    chitiet.Yn = 1;
                    chitiet.Userdate = ngayky;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    if (duyet == false)
                    {

                        chitiet.Auditor = idnguoiduyet;
                        chitiet.abrult = false;
                        chitiet.Password2 = list.Password2;
                        chitiet.signatue = list.signatue;
                        chitiet.lydokhongduyet = ghichu;
                        chitiet.Userdate = ngayky;
                        chitiet.Yn = 2;
                        db.SubmitChanges();
                        return true;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                //return false;
                throw;
            }

        }
        public static bool XoaChiTiet(int Id, bool kiemtrabixoa=true)
        {
            Abcon chiet = AbconDAO.TimKiemChiTietXetDuyetTheoMa(Id,true);
            try
            {
                if (kiemtrabixoa)
                {
                    chiet = db.Abcons.Where(p => p.IDCT == Id && p.bixoa == false).FirstOrDefault();
                    chiet.bixoa = true;
                    db.SubmitChanges();
                    return true;
                }
                chiet = db.Abcons.Where(p => p.IDCT == Id && p.bixoa == false).FirstOrDefault();
                chiet.bixoa = true;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static bool XoaPhieuTrongChiTietPhieu( int  itct)
        {
            try
            {
                 Abcon chitiet = new Abcon();
                    chitiet = db.Abcons.Where(p => p.IDCT == itct).FirstOrDefault();
                    db.Abcons.DeleteOnSubmit(chitiet);
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       

        public static List<Abcon> TimKiemVanBanDen(string idVanBan, string idNhanVien, bool kiemTraBiXoa = true)
        {
           
            List<Abcon> lst_myVBD = new List<Abcon>();
            try
            {
                if (kiemTraBiXoa)
                {
                    lst_myVBD = (from vbd in db.Abcons
                                 from vb in db.pdnas
                                 from b in db.Busers2s
                                 where vbd.pdno == vb.pdno && vbd.from_user == b.USERID && vbd.from_user == vb.CFMID0 && vbd.from_user == idNhanVien && vbd.pdno == idVanBan 
                                 select vbd).ToList();
                    //return temp.ToList();
                }
                else
                {
                    lst_myVBD = (from vbd in db.Abcons
                                 from vb in db.pdnas
                                 from b in db.Busers2s
                                 
                                 where vbd.pdno == vb.pdno && vbd.from_user == b.USERID && vbd.from_user==vb.CFMID0 && vbd.from_user == idNhanVien && vbd.pdno == idVanBan 
                                 select vbd).ToList();
                    //return temp1.ToList();
                }
                if (db != null)
                    db.ToString();
                else
                {
                    //don't
                }
                return lst_myVBD;
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("TimKiemVanBanDen\t\t" + "\tMessage Error:\t\t" + ex.Message);
                //  HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return new List<Abcon>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        //public static bool CapNhatVanBanDen2(Abcon vbd)
        //{
           
        //    Abcon temp = new Abcon();
        //    try
        //    {
        //        // VanBanDen temp = TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(vbd.IdVanBan, vbd.IDNhanVien, vbd.IDNguoiChuyen, false);

        //        temp = (from vb in db.Abcons
        //                from q in db.pdnas
        //                from h in db.Busers2s
        //                where vb.from_user==h.USERID && vb.pdno==q.pdno && vb.pdno == vbd.pdno && vb.from_user == vbd.from_user 
        //                select vb).FirstOrDefault();
        //        //return temp1.FirstOrDefault();
        //        if (temp == null)
        //        {
        //            if (db != null)
        //                db.ToString();
        //            else
        //            {
        //                //don't
        //            }
        //            return false;
        //        }
        //        else
        //        {
        //            temp.bixoa = false;
        //            db.SubmitChanges();
        //            if (db != null)
        //                db.ToString();
        //            else
        //            {
        //                //don't
        //            }
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Until.WriteFileLogServer("CapNhatVanBanDen\t\t" + "\tMessage Error:\t\t" + ex.Message);
        //        // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
        //        return false;
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.ToString();
        //    }
        //}

        public static bool CapNhatVanBanDen(Abcon vbd)
        {
            
            Abcon temp = new Abcon();
            try
            {
                // VanBanDen temp = TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(vbd.IdVanBan, vbd.IDNhanVien, vbd.IDNguoiChuyen, false);

                temp = (from vb in db.Abcons
                        from q in db.pdnas
                        from h in db.Busers2s
                        where vb.from_user == h.USERID && vb.pdno == q.pdno && vb.pdno == vbd.pdno && vb.from_user == vbd.from_user
                        select vb).FirstOrDefault();
                if (temp == null)
                {
                    if (db != null)
                        db.ToString();
                    else
                    {
                        //don't
                    }
                    return false;
                }
                else
                {

                    temp.received = true;
                    temp.bixoa = false;
                    db.SubmitChanges();
                    if (db != null)
                        db.ToString();
                    else
                    {
                        //don't
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("CapNhatVanBanDen\t\t" + "\tMessage Error:\t\t" + ex.Message);
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return false;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

      

        public static List<Abcon> QryVanBanCapDuyetTheoVanBan(string idVanBan, bool kiemTraBiXoa = true)
        {

            List<Abcon> lst_vbcd = new List<Abcon>();
            try
            {
                if (kiemTraBiXoa)
                {
                  var  lst_vbcd1 = (from q in db.Abcons
                                where q.pdno==idVanBan
                                select q);
                    return lst_vbcd=lst_vbcd1.OrderBy(p=>p.abps).ToList();
                }
                else
                {
                    var lst_vbcd1 = (from q in db.Abcons
                                     where q.pdno == idVanBan
                                     select q);
                    return lst_vbcd = lst_vbcd1.OrderBy(p => p.abps).ToList();
                }
                
               // return lst_vbcd;
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("QryVanBanCapDuyetTheoVanBan\t\t" + "\tMessage Error:\t\t" + ex.Message);
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return new List<Abcon>();
            }
            finally
            {
                if (db != null)
                    db.ToString();

            }
        }

        public static List<Abcon> LayDSLoaiVanBan_CapDuyet(string idLoaiVanBan, bool kiemTraBiXoa = true)
        {


            List<Abcon> listLVBCD = new List<Abcon>();

            try
            {
                if (kiemTraBiXoa)
                {
                    //var lvb_cd1 = from p in db.Abcons
                    //              from q in db.abills
                    //              where p.abtype == q.abtype && p.abtype == idLoaiVanBan 
                    //              select p;
                    //listLVBCD = lvb_cd1.OrderBy(x => x.abde).ToList();
                    var list = (from q in db.Abcons
                                join p in db.abills
                                    on q.abtype equals p.abtype
                                where q.abtype.Equals(idLoaiVanBan)
                                select q).ToList();
                    return list;

                }
                else
                {
                    var lvb_cd1 = from p in db.Abcons
                                  from q in db.abills
                                  where p.abtype == idLoaiVanBan
                                  select p;
                    listLVBCD = lvb_cd1.OrderBy(x => x.abps).ToList();
                }

                List<Abcon> myList = new List<Abcon>();
                foreach (Abcon lvb_cd in listLVBCD)
                {
                    Abcon myLVB_CD = new Abcon();
                    myLVB_CD.IDCT = lvb_cd.IDCT;
                    myLVB_CD.abps = lvb_cd.abps;
                    myLVB_CD.abtype = lvb_cd.abtype;
                    //foreach (ChiTietXetDuyetMau ct in lvb_cd.ChiTietXetDuyetMaus.ToList())
                    //{
                    //    myChiTietXetDuyetMau mct = new myChiTietXetDuyetMau();
                    //    mct.m_chitietxetduyetmau = ct;
                    //    mct.m_NhanVien = ct.NhanVien;
                    //    mct.m_LoaiVanBan_CapDuyet = ct.LoaiVanBan_CapDuyet;
                    //    myLVB_CD.m_myChiTietXetDuyetMaus.Add(mct);
                    //}
                    myList.Add(myLVB_CD);
                }
                db.ToString();
                if (myList != null)
                    return myList;
                else
                    return new List<Abcon>();
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("LayDSLoaiVanBan_CapDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return new List<Abcon>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static Abcon TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(string idVanBan, string idNhanVien, string idNguoiChuyen, bool kiemTraBiXoa = true)
        {
           
            Abcon vbden = new Abcon();
            try
            {
                if (kiemTraBiXoa)
                {
                    vbden = (from vbd in db.Abcons
                             where vbd.pdno == idVanBan && vbd.Auditor == idNhanVien && vbd.bixoa == false && vbd.from_user == idNguoiChuyen
                             select vbd).FirstOrDefault();
                    //return temp.FirstOrDefault();
                }
                else
                {
                    vbden = (from vbd in db.Abcons
                             where vbd.pdno == idVanBan && vbd.Auditor == idNhanVien && vbd.from_user == idNguoiChuyen
                             select vbd).FirstOrDefault();
                    //return temp1.FirstOrDefault();
                }
                if (db != null)
                    db.ToString();
                else
                {
                    //don't
                }
                return vbden;
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan\t\t" + "\tMessage Error:\t\t" + ex.Message);
                //  HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return new Abcon();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static Abcon LaymaVanBanTheoCapDuyet1(string idvanban,int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == id).FirstOrDefault();
        }
        public static Abcon LaymaVanBanTheoCapDuyet2(string idvanban, int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == id).FirstOrDefault();
        }
        public static Abcon LaymaVanBanTheoCapDuyet3(string idvanban,int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == 3).FirstOrDefault();
        }
        public static Abcon LaymaVanBanTheoCapDuyet4(string idvanban,int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == 4).FirstOrDefault();
        }
        public static Abcon LaymaVanBanTheoCapDuyet5(string idvanban, int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == 5).FirstOrDefault();
        }
        public static Abcon LaymaVanBanTheoCapDuyet6(string idvanban, int id)
        {
            return db.Abcons.Where(p => p.pdno == idvanban && p.abrult == true && p.abps == 6).FirstOrDefault();
        }
        public static Busers2 LayMaNguoiTaoTheoIDVanBan(string idvanban, string macongty)
        {
            Busers2 list = (from p in db.pdnas
                        from h in db.Busers2s
                        where (p.CFMID0 == h.USERID && p.pdno == idvanban && h.GSBH==macongty)
                        select h).FirstOrDefault();
            return list;
        }
        public static Abcon LayCapDangDuyetCuaVanBan(string idvanban,int capduyet, bool kiemtrabixoa = true)
        {
            Abcon list = (from q in db.Abcons
                          
                          where (q.abps==capduyet && q.pdno == idvanban)
                          select q).FirstOrDefault();
            return list;
        }
        public static Abcon LayCapDuyetTruocCuaNhanVienTheoVanBan(string idnhanvien, string idvanban)
        {
           
            //List<Abcon> caphientai = (from p in db.Abcons
            //                          from q in db.abill1s
            //                          where (p.abde == q.Abde && p.Abstep == q.Abstep && p.Auditor == idnhanvien && p.pdno == idvanban)
            //                          select p).ToList();
            //Abcon captruoc = (from p in caphientai
            //                  from q in caphientai
            //                  where (p.Abstep == q.Abstep - 1 && q.abde == p.abde && p.Auditor == q.Auditor && q.pdno == idvanban)
            //                  select q).FirstOrDefault();
            //return captruoc;
            List<Abcon> caphientai = (
                                      from q in db.Abcons
                                      where ( q.Auditor == idnhanvien && q.pdno==idvanban)
                                      select q).ToList();
            if (caphientai.Count() == 0)
            {
                return null;
            }
            else
            {
                Abcon cd = caphientai.First();
                List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                int max = (from ct in lstChiTietXetDuyet
                           select ct.Abstep - 1).Max();

                Abcon ca = (from p in db.Abcons where (p.Abstep == max) select p).FirstOrDefault();
                return ca;
            }
            
        }

        public static Abcon LayCapDuyetHienTaiCuaNhanVienTheoVanBan(string idnhanvien, string idvanban)
        {

            
           Abcon caphientai = (
                                      from q in db.Abcons
                                      where ( q.Auditor == idnhanvien && q.pdno == idvanban )
                                      select q).FirstOrDefault();
           return caphientai;
          
        }

        public static Abcon LayCapDuyetTruocCuaNhanVien(string idnhanvien)
        {
            
            List<Abcon> caphientai = (
                                      from q in db.Abcons
                                      where ( q.Auditor == idnhanvien)
                                      select q).ToList();
            if (caphientai.Count() == 0)
            {
                return null;
            }
            else
            {
                Abcon cd = caphientai.First();
                List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                int max = (from ct in lstChiTietXetDuyet
                           select ct.Abstep - 1).Max();

                Abcon ca = (from p in db.Abcons where (p.Abstep == max) select p).FirstOrDefault();
                return ca;
            }
            
        }
        public static List<Abcon> LayCapDuyetTruocCuaNhanVienTheoChiTiet(string idnhanvien)
        {

            List<Abcon> caphientai = (
                                      from q in db.Abcons
                                      where (q.Auditor == idnhanvien  ) 
                                      select q).ToList();
              List<Abcon> caa=new List<Abcon>();
            
            if (caphientai.Count() == 0)
            {
                return null;
            }
            else
            {
                //Abcon cd = caphientai.First();
                foreach( Abcon cap in caphientai)
                {
                    List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cap.IDCT, true).ToList();
                int  max= (from ct in lstChiTietXetDuyet
                               select ct.Abstep - 1).Max();
                 Abcon  ca = (from p in db.Abcons where (p.Abstep == max) select p).FirstOrDefault();
                 caa.Add(ca);
                }
                return caa.ToList();
           
            }

        }
        public static Abcon LayCapDuyetCuaNhanVien(string idnhanvien)
        {
          
            Abcon caphientai = (
                                      from q in db.Abcons
                                      where (q.Auditor == idnhanvien)
                                      select q).FirstOrDefault();
            return caphientai;
        }
        public static Abcon LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(string mavanban, string manhanvien, string macongty)
        {
            Abcon caphientai = (from p in db.Abcons.Where(p => p.pdno == mavanban && p.Auditor == manhanvien && p.Gsbh == macongty) select p).FirstOrDefault();
            return caphientai;
        }
        public static Abcon LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(string mavanban, string macongty,int cap,int buocduyet)
        {
            Abcon buoctruoc = (from p in db.Abcons.Where(p => p.pdno == mavanban  && p.Gsbh == macongty && p.Abstep==cap&& p.abps==buocduyet) select p).FirstOrDefault();
            return buoctruoc;
        }
        public static List<Abcon> LayBuocTruocCuaPhieu(string pdno, string gsbh, int abstep)
        {
            try
            {
                var list = from p in db.Abcons.Where(p => p.pdno == pdno && p.Gsbh == gsbh && p.Abstep == abstep) select p;
                return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon1> QryVanBanDenTheoNguoiDuyet(string manguoiduyet, string macongty)
        {
            
            var lstList = (from p in db.Abcons
                      join k in db.pdnas on p.pdno equals k.pdno
                      join b in db.ABYns on p.Yn equals b.Yn
                      join ab in db.aABCs on p.ABC equals ab.ABC
                      join pd in db.pdnas on p.pdno equals pd.pdno
                      join bu in db.Busers2s on p.from_user equals bu.USERID
                      join bd in db.BDepartments on p.from_depart equals bd.ID
                      join a in db.abills on p.abtype equals a.abtype
                      join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                      where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false && tr.Yn==4)
                      select  new
                      {
                          a.abtype,
                          a.abname,
                          b.YnName,
                          ab.NameABC,
                          k.pdno,
                          k.mytitle,
                          bu.USERNAME,
                          bd.ID,
                          bd.DepName,
                          k.CFMDate0
                      }).Distinct();

            List<Abcon1> listDL = new List<Abcon1>();
            

            Abcon1 Abcon1;
           
            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon1 = new Abcon1()
                {
                    abtype = item.abtype,
                    abname = item.abname,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnName,
                    NameABC = item.NameABC,
                    USERNAME = item.USERNAME,
                    ID = item.ID,
                    DepName = item.DepName,
                    CFMDate0=item.CFMDate0
                };
               

                    Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, manguoiduyet, macongty);
                if(caphientai!=null && caphientai.Abstep==1)
                {
                    if (caphientai!=null&&caphientai.abps > 1)
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon1[] { Abcon1 }));
                                maphieu1 = Abcon1.pdno;
                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (caphientai.abps == 1)
                        {
                            if (caphientai.abrult == false && caphientai.Yn == 4 )
                            {
                                listDL.AddRange((new Abcon1[] { Abcon1 }));
                                maphieu1 = Abcon1.pdno;
                            }
                            else { }
                        }
                    }
                }// cap >1
                else
                {
                    List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, macongty, caphientai.Abstep - 1);
                    if (listAbcon.Count > 0)
                    {
                        int maxABps = (from p in listAbcon select p.abps).Max();
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep - 1, maxABps);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abps > 1)
                            {

                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon1[] { Abcon1 }));
                                    maphieu1 = Abcon1.pdno;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (capbuoctruoc.abps == 1)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon1[] { Abcon1 }));
                                        maphieu1 = Abcon1.pdno;
                                    }
                                    else { }
                                }
                            }
                        }
                    }

                }
                    
            }
           

            return listDL;
           

                                  

        }
        public static List<Abcon1> QryVanBanDenTheoNguoiDuyetEN(string manguoiduyet, string macongty)
        {

            var lstList = (from p in db.Abcons
                           join k in db.pdnas on p.pdno equals k.pdno
                           join b in db.ABYns on p.Yn equals b.Yn
                           join ab in db.aABCs on p.ABC equals ab.ABC
                           join pd in db.pdnas on p.pdno equals pd.pdno
                           join bu in db.Busers2s on p.from_user equals bu.USERID
                           join bd in db.BDepartments on p.from_depart equals bd.ID
                           join a in db.abills on p.abtype equals a.abtype
                           join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                           where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false && tr.Yn == 4)
                           select new
                           {
                               a.abtype,
                               a.abnameEng,
                               b.YnName,
                               ab.NameABCEng,
                               k.pdno,
                               k.mytitle,
                               bu.USERNAME,
                               bd.ID,
                               bd.DepName,
                               k.CFMDate0
                           }).Distinct();

            List<Abcon1> listDL = new List<Abcon1>();


            Abcon1 Abcon1;

            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon1 = new Abcon1()
                {
                    abtype = item.abtype,
                    abname = item.abnameEng,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnName,
                    NameABC = item.NameABCEng,
                    USERNAME = item.USERNAME,
                    ID = item.ID,
                    DepName = item.DepName,
                    CFMDate0 = item.CFMDate0
                };


                Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, manguoiduyet, macongty);
                if (caphientai != null && caphientai.Abstep == 1)
                {
                    if (caphientai != null && caphientai.abps > 1)
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon1[] { Abcon1 }));
                                maphieu1 = Abcon1.pdno;
                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (caphientai.abps == 1)
                        {
                            if (caphientai.abrult == false && caphientai.Yn == 4)
                            {
                                listDL.AddRange((new Abcon1[] { Abcon1 }));
                                maphieu1 = Abcon1.pdno;
                            }
                            else { }
                        }
                    }
                }// cap >1
                else
                {
                    List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, macongty, caphientai.Abstep - 1);
                    if (listAbcon.Count > 0)
                    {
                        int maxABps = (from p in listAbcon select p.abps).Max();
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep - 1, maxABps);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abps > 1)
                            {

                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon1[] { Abcon1 }));
                                    maphieu1 = Abcon1.pdno;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (capbuoctruoc.abps == 1)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon1[] { Abcon1 }));
                                        maphieu1 = Abcon1.pdno;
                                    }
                                    else { }
                                }
                            }
                        }
                    }

                }

            }


            return listDL;




        }
        public static List<AbconTKVN> TimKiemDanhSachPhieuTheoDieuKien(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, int Yn1, int Yn2, int Yn4)
        {
            try
            {
                //pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle
                // ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0
                var lstList = (from p in db.Abcons
                      join k in db.pdnas on p.pdno equals k.pdno
                      join b in db.ABYns on p.Yn equals b.Yn
                      join ab in db.aABCs on p.ABC equals ab.ABC
                      join pd in db.pdnas on p.pdno equals pd.pdno
                      join bu in db.Busers2s on p.from_user equals bu.USERID
                      join bd in db.BDepartments on p.from_depart equals bd.ID
                      join a in db.abills on p.abtype equals a.abtype
                      join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                      where (p.Auditor == idNguoiDuyet && p.Gsbh == pGSBH && ((p.Yn == Yn4 && p.abrult == false)||(p.Yn==Yn2 && p.abrult==false)||(p.Yn==Yn1 && p.abrult==true)) && (k.CFMDate0>=pTuNgay &&k.CFMDate0<=pDenNgay))
                      select  new
                      {
                         k.Abtype,
                         a.abname,
                         k.pdno,
                         k.mytitle,
                         p.ABC,
                         ab.NameABC,
                         p.from_user,
                         bu.USERNAME,
                         p.from_depart,
                         bd.DepName,
                         p.Yn,
                         b.YnName,
                         k.CFMDate0
                      }).Distinct();
                List<AbconTKVN> listVN = new List<AbconTKVN>();
                AbconTKVN abconVN;
                foreach (var item in lstList)
                {
                    string maphieu1;
                    abconVN = new AbconTKVN()
                    {
                        Abtype=item.Abtype,
                        abname=item.abname,
                        pdno=item.pdno,
                        mytitle=item.mytitle,
                        ABC=item.ABC,
                        NameABC=item.NameABC,
                        from_user=item.from_user,
                        USERNAME=item.USERNAME,
                        from_depart=item.from_depart,
                        DepName=item.DepName,
                        Yn=item.Yn,
                        YnName=item.YnName,
                        CFMDate0=item.CFMDate0
                    };
                    if (abconVN.Yn == 1 || abconVN.Yn == 2)
                    {
                        //listDL.AddRange((new Abcon1[] { Abcon1 }));
                        listVN.AddRange((new AbconTKVN[] { abconVN }));
                    }
                    else
                    {
                        if (abconVN.Yn == 4)
                        {
                            Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(abconVN.pdno, idNguoiDuyet, pGSBH);
                            if (caphientai != null && caphientai.Abstep == 1)
                            {
                                if (caphientai != null && caphientai.abps > 1)
                                {
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconVN.pdno, pGSBH, caphientai.Abstep, caphientai.abps - 1);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                        {
                                            listVN.AddRange((new AbconTKVN[] { abconVN }));
                                            maphieu1 = abconVN.pdno;
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    if (caphientai.abps == 1)
                                    {
                                        if (caphientai.abrult == false && caphientai.Yn == 4)
                                        {
                                            listVN.AddRange((new AbconTKVN[] { abconVN }));
                                            maphieu1 = abconVN.pdno;
                                        }
                                        else { }
                                    }
                                }
                            }// cap >1
                            else
                            {
                                List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, pGSBH, caphientai.Abstep - 1);
                                if (listAbcon.Count > 0)
                                {
                                    int maxABps = (from p in listAbcon select p.abps).Max();
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconVN.pdno, pGSBH, caphientai.Abstep - 1, maxABps);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abps > 1)
                                        {

                                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                            {
                                                listVN.AddRange((new AbconTKVN[] { abconVN }));
                                                maphieu1 = abconVN.pdno;
                                            }
                                            else
                                            {
                                            }
                                        }
                                        else
                                        {
                                            if (capbuoctruoc.abps == 1)
                                            {
                                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                                {
                                                    listVN.AddRange((new AbconTKVN[] { abconVN }));
                                                    maphieu1 = abconVN.pdno;
                                                }
                                                else { }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                return listVN.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<AbconTKEN> TimKiemDanhSachPhieuTheoDieuKienEN(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, int Yn1, int Yn2, int Yn4)
        {
            try
            {
                //pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle
                // ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0
                var lstList = (from p in db.Abcons
                               join k in db.pdnas on p.pdno equals k.pdno
                               join b in db.ABYns on p.Yn equals b.Yn
                               join ab in db.aABCs on p.ABC equals ab.ABC
                               join pd in db.pdnas on p.pdno equals pd.pdno
                               join bu in db.Busers2s on p.from_user equals bu.USERID
                               join bd in db.BDepartments on p.from_depart equals bd.ID
                               join a in db.abills on p.abtype equals a.abtype
                               join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                               where (p.Auditor == idNguoiDuyet && p.Gsbh == pGSBH && ((p.Yn == Yn4 && p.abrult == false) || (p.Yn == Yn2 && p.abrult == false) || (p.Yn == Yn1 && p.abrult == true)) && (k.CFMDate0 >= pTuNgay && k.CFMDate0 <= pDenNgay))
                               select new
                               {
                                   k.Abtype,
                                   a.abnameEng,
                                   k.pdno,
                                   k.mytitle,
                                   p.ABC,
                                   ab.NameABCEng,
                                   p.from_user,
                                   bu.USERNAME,
                                   p.from_depart,
                                   bd.DepName,
                                   p.Yn,
                                   b.YnName,
                                   k.CFMDate0
                               }).Distinct();
                List<AbconTKEN> listEN = new List<AbconTKEN>();
                AbconTKEN abconEN;
                foreach (var item in lstList)
                {
                    string maphieu1;
                    abconEN = new AbconTKEN()
                    {
                        Abtype = item.Abtype,
                        abname = item.abnameEng,
                        pdno = item.pdno,
                        mytitle = item.mytitle,
                        ABC = item.ABC,
                        NameABC = item.NameABCEng,
                        from_user = item.from_user,
                        USERNAME = item.USERNAME,
                        from_depart = item.from_depart,
                        DepName = item.DepName,
                        Yn = item.Yn,
                        YnName = item.YnName,
                        CFMDate0 = item.CFMDate0
                    };
                    if (abconEN.Yn == 1 || abconEN.Yn == 2)
                    {
                        //listDL.AddRange((new Abcon1[] { Abcon1 }));
                        listEN.AddRange((new AbconTKEN[] { abconEN }));
                    }
                    else
                    {
                        if (abconEN.Yn == 4)
                        {
                            Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(abconEN.pdno, idNguoiDuyet, pGSBH);
                            if (caphientai != null && caphientai.Abstep == 1)
                            {
                                if (caphientai != null && caphientai.abps > 1)
                                {
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconEN.pdno, pGSBH, caphientai.Abstep, caphientai.abps - 1);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                        {
                                            listEN.AddRange((new AbconTKEN[] { abconEN }));
                                            maphieu1 = abconEN.pdno;
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    if (caphientai.abps == 1)
                                    {
                                        if (caphientai.abrult == false && caphientai.Yn == 4)
                                        {
                                            listEN.AddRange((new AbconTKEN[] { abconEN }));
                                            maphieu1 = abconEN.pdno;
                                        }
                                        else { }
                                    }
                                }
                            }// cap >1
                            else
                            {
                                List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, pGSBH, caphientai.Abstep - 1);
                                if (listAbcon.Count > 0)
                                {
                                    int maxABps = (from p in listAbcon select p.abps).Max();
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconEN.pdno, pGSBH, caphientai.Abstep - 1, maxABps);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abps > 1)
                                        {

                                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                            {
                                                listEN.AddRange((new AbconTKEN[] { abconEN }));
                                                maphieu1 = abconEN.pdno;
                                            }
                                            else
                                            {
                                            }
                                        }
                                        else
                                        {
                                            if (capbuoctruoc.abps == 1)
                                            {
                                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                                {
                                                    listEN.AddRange((new AbconTKEN[] { abconEN }));
                                                    maphieu1 = abconEN.pdno;
                                                }
                                                else { }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                return listEN.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<abconTKTW> TimKiemDanhSachPhieuTheoDieuKienTW(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, int Yn1, int Yn2, int Yn4)
        {
            try
            {
                //pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle
                // ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0
                var lstList = (from p in db.Abcons
                               join k in db.pdnas on p.pdno equals k.pdno
                               join b in db.ABYns on p.Yn equals b.Yn
                               join ab in db.aABCs on p.ABC equals ab.ABC
                               join pd in db.pdnas on p.pdno equals pd.pdno
                               join bu in db.Busers2s on p.from_user equals bu.USERID
                               join bd in db.BDepartments on p.from_depart equals bd.ID
                               join a in db.abills on p.abtype equals a.abtype
                               join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                               where (p.Auditor == idNguoiDuyet && p.Gsbh == pGSBH && ((p.Yn == Yn4 && p.abrult == false) || (p.Yn == Yn2 && p.abrult == false) || (p.Yn == Yn1 && p.abrult == true)) && (k.CFMDate0 >= pTuNgay && k.CFMDate0 <= pDenNgay))
                               select new
                               {
                                   k.Abtype,
                                   a.abnameTW,
                                   k.pdno,
                                   k.mytitle,
                                   p.ABC,
                                   ab.NameABCTW,
                                   p.from_user,
                                   bu.USERNAME,
                                   p.from_depart,
                                   bd.DepName,
                                   p.Yn,
                                   b.YnName,
                                   k.CFMDate0
                               }).Distinct();
                List<abconTKTW> listTW = new List<abconTKTW>();
                abconTKTW abconTW;
                foreach (var item in lstList)
                {
                    string maphieu1;
                    abconTW = new abconTKTW()
                    {
                        Abtype = item.Abtype,
                        abname = item.abnameTW,
                        pdno = item.pdno,
                        mytitle = item.mytitle,
                        ABC = item.ABC,
                        NameABC = item.NameABCTW,
                        from_user = item.from_user,
                        USERNAME = item.USERNAME,
                        from_depart = item.from_depart,
                        DepName = item.DepName,
                        Yn = item.Yn,
                        YnName = item.YnName,
                        CFMDate0 = item.CFMDate0
                    };
                    if (abconTW.Yn == 1 || abconTW.Yn == 2)
                    {
                        //listDL.AddRange((new Abcon1[] { Abcon1 }));
                        listTW.AddRange((new abconTKTW[] { abconTW }));
                    }
                    else
                    {
                        if (abconTW.Yn == 4)
                        {
                            Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(abconTW.pdno, idNguoiDuyet, pGSBH);
                            if (caphientai != null && caphientai.Abstep == 1)
                            {
                                if (caphientai != null && caphientai.abps > 1)
                                {
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconTW.pdno, pGSBH, caphientai.Abstep, caphientai.abps - 1);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                        {
                                            listTW.AddRange((new abconTKTW[] { abconTW }));
                                            maphieu1 = abconTW.pdno;
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    if (caphientai.abps == 1)
                                    {
                                        if (caphientai.abrult == false && caphientai.Yn == 4)
                                        {
                                            listTW.AddRange((new abconTKTW[] { abconTW }));
                                            maphieu1 = abconTW.pdno;
                                        }
                                        else { }
                                    }
                                }
                            }// cap >1
                            else
                            {
                                List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, pGSBH, caphientai.Abstep - 1);
                                if (listAbcon.Count > 0)
                                {
                                    int maxABps = (from p in listAbcon select p.abps).Max();
                                    Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(abconTW.pdno, pGSBH, caphientai.Abstep - 1, maxABps);
                                    if (capbuoctruoc != null)
                                    {
                                        if (capbuoctruoc.abps > 1)
                                        {

                                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                            {
                                                listTW.AddRange((new abconTKTW[] { abconTW }));
                                                maphieu1 = abconTW.pdno;
                                            }
                                            else
                                            {
                                            }
                                        }
                                        else
                                        {
                                            if (capbuoctruoc.abps == 1)
                                            {
                                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                                {
                                                    listTW.AddRange((new abconTKTW[] { abconTW }));
                                                    maphieu1 = abconTW.pdno;
                                                }
                                                else { }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                return listTW.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Abcon2> QryPhieuChoDuyetTheoNguoiDuyet(string manguoiduyet, string macongty)
        {

            var lstList = (from p in db.Abcons
                           join k in db.pdnas on p.pdno equals k.pdno
                           join b in db.ABYns on p.Yn equals b.Yn
                           join ab in db.aABCs on p.ABC equals ab.ABC
                           join pd in db.pdnas on p.pdno equals pd.pdno
                           join bu in db.Busers2s on p.from_user equals bu.USERID
                           join bd in db.BDepartments on p.from_depart equals bd.ID
                           join a in db.abills on p.abtype equals a.abtype
                           where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false)
                           select new
                           {
                               a.abtype,
                               a.abname,
                               b.YnName,
                               ab.NameABC,
                               k.pdno,
                               k.mytitle,
                               p.from_user,
                               bu.USERNAME,
                               bd.ID,
                               bd.DepName,
                               p.Yn,
                               k.CFMDate0
                           }).Distinct();

            List<Abcon2> listDL = new List<Abcon2>();


            Abcon2 Abcon2;

            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon2 = new Abcon2()
                {
                    abtype = item.abtype,
                    abname = item.abname,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnName,
                    NameABC = item.NameABC,
                    UserID=item.from_user,
                    USERNAME = item.USERNAME,
                    from_depart = item.ID,
                    DepName = item.DepName,
                    Yn=item.Yn,
                    CFMDate0=item.CFMDate0
                };


                Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, manguoiduyet, macongty);
                if (caphientai!=null &&caphientai.Abstep == 1)
                {
                    if (caphientai.abps > 1)
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (caphientai!=null&&caphientai.abps == 1)
                        {
                            if (caphientai.abrult == false && caphientai.Yn == 4 )
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                            else { }
                        }

                    }
                }// cap >1
                else
                {
                    if (caphientai!=null &&caphientai.abps == 1)
                    {
                        List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, macongty, caphientai.Abstep - 1);
                        if (listAbcon.Count > 0)
                        {
                            int maxABps = (from p in listAbcon select p.abps).Max();
                            Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep - 1, maxABps);
                            if (capbuoctruoc!=null &&capbuoctruoc.abps > 1)
                            {

                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon2[] { Abcon2 }));
                                    maphieu1 = Abcon2.pdno;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (capbuoctruoc!=null &&capbuoctruoc.abps == 1)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon2[] { Abcon2 }));
                                        maphieu1 = Abcon2.pdno;
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    else
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                        }
                    }

                }

            }
            return listDL;
        }
        public static List<Abcon2> QryPhieuChoDuyetTheoNguoiDuyetEN(string manguoiduyet, string macongty)
        {

            var lstList = (from p in db.Abcons
                           join k in db.pdnas on p.pdno equals k.pdno
                           join b in db.ABYns on p.Yn equals b.Yn
                           join ab in db.aABCs on p.ABC equals ab.ABC
                           join pd in db.pdnas on p.pdno equals pd.pdno
                           join bu in db.Busers2s on p.from_user equals bu.USERID
                           join bd in db.BDepartments on p.from_depart equals bd.ID
                           join a in db.abills on p.abtype equals a.abtype
                           where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false)
                           select new
                           {
                               a.abtype,
                               a.abnameEng,
                               b.YnName,
                               ab.NameABCEng,
                               k.pdno,
                               k.mytitle,
                               p.from_user,
                               bu.USERNAME,
                               bd.ID,
                               bd.DepName,
                               p.Yn,
                               k.CFMDate0
                           }).Distinct();

            List<Abcon2> listDL = new List<Abcon2>();


            Abcon2 Abcon2;

            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon2 = new Abcon2()
                {
                    abtype = item.abtype,
                    abname = item.abnameEng,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnName,
                    NameABC = item.NameABCEng,
                    UserID = item.from_user,
                    USERNAME = item.USERNAME,
                    from_depart = item.ID,
                    DepName = item.DepName,
                    Yn = item.Yn,
                    CFMDate0 = item.CFMDate0
                };


                Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, manguoiduyet, macongty);
                if (caphientai != null && caphientai.Abstep == 1)
                {
                    if (caphientai.abps > 1)
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (caphientai != null && caphientai.abps == 1)
                        {
                            if (caphientai.abrult == false && caphientai.Yn == 4)
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                            else { }
                        }

                    }
                }// cap >1
                else
                {
                    if (caphientai != null && caphientai.abps == 1)
                    {
                        List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, macongty, caphientai.Abstep - 1);
                        if (listAbcon.Count > 0)
                        {
                            int maxABps = (from p in listAbcon select p.abps).Max();
                            Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep - 1, maxABps);
                            if (capbuoctruoc != null && capbuoctruoc.abps > 1)
                            {

                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon2[] { Abcon2 }));
                                    maphieu1 = Abcon2.pdno;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                if (capbuoctruoc != null && capbuoctruoc.abps == 1)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon2[] { Abcon2 }));
                                        maphieu1 = Abcon2.pdno;
                                    }
                                    else { }
                                }
                            }
                        }
                    }
                    else
                    {
                        Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon2.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                        if (capbuoctruoc != null)
                        {
                            if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                            {
                                listDL.AddRange((new Abcon2[] { Abcon2 }));
                                maphieu1 = Abcon2.pdno;
                            }
                        }
                    }

                }

            }
            return listDL;
        }
        public static List<Abcon1> QryVanBanDenTheoNguoiDuyetTW(string manguoiduyet, string macongty)
        {

            var lstList = (from p in db.Abcons
                           join k in db.pdnas on p.pdno equals k.pdno
                           join b in db.ABYns on p.Yn equals b.Yn
                           join ab in db.aABCs on p.ABC equals ab.ABC
                           join pd in db.pdnas on p.pdno equals pd.pdno
                           join bu in db.Busers2s on p.from_user equals bu.USERID
                           join bd in db.BDepartments on p.from_depart equals bd.ID
                           join a in db.abills on p.abtype equals a.abtype
                           join tr in db.ABTrangThaiDuyets on p.pdno equals tr.pdno
                           where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false && tr.Yn==4)
                           select new
                           {
                               a.abtype,
                               a.abnameTW,
                               b.YnNameTW,
                               ab.NameABCTW,
                               k.pdno,
                               k.mytitle,
                               bu.USERNAME,
                               bd.ID,
                               bd.DepName,
                               k.CFMDate0
                           }).Distinct();

            List<Abcon1> listDL = new List<Abcon1>();


            Abcon1 Abcon1;

            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon1 = new Abcon1()
                {
                    abtype = item.abtype,
                    abname = item.abnameTW,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnNameTW,
                    NameABC = item.NameABCTW,
                    USERNAME = item.USERNAME,
                    ID = item.ID,
                    DepName = item.DepName,
                    CFMDate0=item.CFMDate0
                };


                Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, manguoiduyet, macongty);
                if (caphientai != null)
                {
                    if (caphientai.Abstep == 1)
                    {
                        if (caphientai.abps == 1 && caphientai.Yn == 4 && caphientai.abrult == false)
                        {
                            listDL.AddRange((new Abcon1[] { Abcon1 }));
                            maphieu1 = Abcon1.pdno;
                        }
                        else
                        {
                            if (caphientai.abrult != true)
                            {

                                int buoctruoc = caphientai.abps - 1;
                                Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep, buoctruoc);
                                if (capbuoctruoc != null)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon1[] { Abcon1 }));
                                        maphieu1 = Abcon1.pdno;
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (caphientai.abps == 1 && caphientai.boqua == false && caphientai.abrult == false)
                        {
                            listDL.AddRange((new Abcon1[] { Abcon1 }));
                            maphieu1 = Abcon1.pdno;
                        }
                        else
                        {
                            if (caphientai.abrult != true)
                            {
                                int buoctruoc = caphientai.abps - 1;
                                Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon1.pdno, macongty, caphientai.Abstep, buoctruoc);
                                if (capbuoctruoc != null)
                                {
                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1 && caphientai.boqua == false)
                                    {
                                        listDL.AddRange((new Abcon1[] { Abcon1 }));
                                        maphieu1 = Abcon1.pdno;
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            
            }


            return listDL;




        }
        public static List<Abcon3> QryPhieuChoDuyetTheoNguoiDuyetTW(string manguoiduyet, string macongty)
        {

            var lstList = (from p in db.Abcons
                           join k in db.pdnas on p.pdno equals k.pdno
                           join b in db.ABYns on p.Yn equals b.Yn
                           join ab in db.aABCs on p.ABC equals ab.ABC
                           join pd in db.pdnas on p.pdno equals pd.pdno
                           join bu in db.Busers2s on p.from_user equals bu.USERID
                           join bd in db.BDepartments on p.from_depart equals bd.ID
                           join a in db.abills on p.abtype equals a.abtype
                           where (p.Auditor == manguoiduyet && p.Gsbh == macongty && p.Yn == 4 && p.abrult == false)
                           select new
                           {
                               a.abtype,
                               a.abnameTW,
                               b.YnName,
                               ab.NameABCTW,
                               k.pdno,
                               k.mytitle,
                               p.from_user,
                               bu.USERNAME,
                               bd.ID,
                               bd.DepName,
                               p.Yn,
                               k.CFMDate0
                           }).Distinct();

            List<Abcon3> listDL = new List<Abcon3>();


            Abcon3 Abcon3;

            foreach (var item in lstList)
            {
                string maphieu1;
                Abcon3 = new Abcon3()
                {
                    abtype = item.abtype,
                    abname = item.abnameTW,
                    pdno = item.pdno,
                    mytitle = item.mytitle,
                    YnName = item.YnName,
                    NameABC = item.NameABCTW,
                    UserID = item.from_user,
                    USERNAME = item.USERNAME,
                    from_depart = item.ID,
                    DepName = item.DepName,
                    Yn=item.Yn,
                    CFMDate0=item.CFMDate0
                };


                Abcon caphientai = AbconDAO.LayBuocHienTaiCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon3.pdno, manguoiduyet, macongty);
                if (caphientai != null)
                {
                    if (caphientai.Abstep == 1)
                    {
                        if (caphientai.abps > 1)
                        {
                            Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon3.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                            if (capbuoctruoc != null)
                            {
                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon3[] { Abcon3 }));
                                    maphieu1 = Abcon3.pdno;
                                }
                                else
                                {
                                }
                            }
                        }
                        else
                        {
                            if (caphientai.abps == 1)
                            {
                                if (caphientai.abrult == false && caphientai.Yn == 4)
                                {
                                    listDL.AddRange((new Abcon3[] { Abcon3 }));
                                    maphieu1 = Abcon3.pdno;
                                }
                                else { }
                            }
                        }
                    }// cap >1
                    else
                    {
                        if (caphientai.abps == 1)
                        {
                            List<Abcon> listAbcon = AbconDAO.LayBuocTruocCuaPhieu(caphientai.pdno, macongty, caphientai.Abstep - 1);
                            if (listAbcon.Count > 0)
                            {
                                int maxABps = (from p in listAbcon select p.abps).Max();
                                Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon3.pdno, macongty, caphientai.Abstep - 1, maxABps);
                                if (capbuoctruoc.abps > 1)
                                {

                                    if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                    {
                                        listDL.AddRange((new Abcon3[] { Abcon3 }));
                                        maphieu1 = Abcon3.pdno;
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    if (capbuoctruoc.abps == 1)
                                    {
                                        if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                        {
                                            listDL.AddRange((new Abcon3[] { Abcon3 }));
                                            maphieu1 = Abcon3.pdno;
                                        }
                                        else { }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Abcon capbuoctruoc = AbconDAO.LayBuocTruocCuaNhanVienTheoMaNhanVien_IDVanBan(Abcon3.pdno, macongty, caphientai.Abstep, caphientai.abps - 1);
                            if (capbuoctruoc != null)
                            {
                                if (capbuoctruoc.abrult == true && capbuoctruoc.Yn == 1)
                                {
                                    listDL.AddRange((new Abcon3[] { Abcon3 }));
                                    maphieu1 = Abcon3.pdno;
                                }
                            }
                        }
                    }
                }

            }
            return listDL;
        }
        public static List<Abcon> QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(string mavanban,string macongty)
        {
            var list = (from p in db.Abcons
                        from h in db.Busers2s
                        from q in db.pdnas
                        where (p.pdno == q.pdno && h.USERID == p.from_user && p.pdno == mavanban&& p.Gsbh==macongty) 
                        select p).ToList();
            return list;
        }
        public static List<Abcon> QryNguoiDuyetBuocDauTien(string mavanban, string idnguoitrinh, string macongty, int buoc=1, int abps=1)
        {
            var list = (from p in db.Abcons
                        from h in db.Busers2s
                        from q in db.pdnas
                        where (p.pdno == q.pdno && h.USERID == p.from_user && p.pdno == mavanban && p.from_user == idnguoitrinh && p.Abstep==buoc && p.abps==abps && p.Gsbh==macongty)
                        select p).ToList();
            return list;
        }
        public static List<Abcon> QryBuocDuyetCuaVanBan(string mavanban, int buocky)
        {
            var list = (from p in db.Abcons
                        from h in db.Busers2s
                        from q in db.pdnas
                        where (p.pdno == q.pdno && h.USERID == p.Auditor && p.pdno == mavanban && p.Abstep == buocky)
                        select p).ToList();
            return list;
        }
        public static Abcon TimBuocKyChuaHoanThanh(string idvanban, int buocky)
        {
            var list = from p in db.Abcons.Where(p => p.pdno == idvanban && p.Abstep == buocky  && p.abrult == false ) select p;
            return list.FirstOrDefault();
        }
        public static Abcon LayBuocKeTiepCuaNhanVien(string gsbh,string pdno,int buocduyet, int cap)
        {
            List<Abcon> caphientai = ( from q in db.Abcons
                                      where (q.Gsbh==gsbh && q.pdno==pdno && q.Abstep==buocduyet && q.abps==cap)
                                      select q).ToList();
            if (caphientai.Count() == 0)
            {
                return null;
            }
            else
            {
                Abcon cd = caphientai.First();
                List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                int max = (from ct in lstChiTietXetDuyet
                           select ct.Abstep).Max();
            

                Abcon ca = (from p in db.Abcons where (p.Abstep == max) select p).FirstOrDefault();
                return ca;
            }
        }
        public static Abcon LayBuocKeTiepCuaNhanVienTrongCung1Cap(string idnhanvien,string pdno, int buocduyet, int cap)
        {
            List<Abcon> caphientai = (from q in db.Abcons
                                      where (q.Auditor == idnhanvien && q.pdno==pdno && q.Abstep == buocduyet && q.abps == cap)
                                      select q).ToList();
            if (caphientai.Count() == 0)
            {
                return null;
            }
            else
            {
                Abcon cd = caphientai.First();
                List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                int max = (from ct in lstChiTietXetDuyet
                           select ct.abps + 1).Max();


                Abcon ca = (from p in db.Abcons where (p.abps == max) select p).FirstOrDefault();
                return ca;
            }
        }
        public static List<Abcon> QryNguoiDuyetBuocKeTiep(string idvanban, int buocduyet)
        {
            try
            {
                return db.Abcons.Where(p => p.pdno == idvanban && p.Abstep == buocduyet ).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> QryNguoiDuyetTrongCung1Cap(string idvanban, int capduyet)
        {
            var list = from p in db.Abcons.Where(a => a.pdno == idvanban && a.Abstep == capduyet) select p;
            return list.ToList();
        }
        public static Abcon LayChiTietXetDuyetTheoNhanVienDuyet(string idvanban, string idnhanvien)
        {
            var list=from p in db.Abcons.Where(a=>a.Auditor==idnhanvien && a.pdno==idvanban)select p;
            return list.FirstOrDefault();
        }
        public static Abcon LayChiTietXetDuyetTheoNhanVienGui(string idvanban, string idnhanvien)
        {
            var list = from p in db.Abcons.Where(a => a.from_user == idnhanvien && a.pdno == idvanban) select p;
            return list.FirstOrDefault();
        }
        public static Abcon LayChiTietXetDuyetTheoNhanVienDuyet1(string idvanban, string macongty, int buocky)
        {
            var list = from p in db.Abcons.Where(a => a.Gsbh == macongty && a.pdno == idvanban && a.Abstep==buocky ) select p;
            return list.FirstOrDefault();
        }
        public static List<Abcon> QryVanBanChuaDuyet(string idnguoiduyet, string macongty)
        {
            List<Abcon> list = (from p in db.Abcons
                               from h in db.ChiTietBuocKies
                               where(p.Auditor==idnguoiduyet && p.pdno==h.pdno  && p.Gsbh==macongty && p.abrult==false && p.Yn==4) select p).ToList();
            List<int> danhsachbuoc = new List<int>();
            var listnew = new List<Abcon>();
            foreach (Abcon ab in list)
            {
                if (ab.Abstep == 1)
                {
                    Abcon nguoiduyettruoc = AbconDAO.LayChiTietXetDuyetTheoNhanVienDuyet1(ab.pdno, ab.Gsbh, 1);
                    Abcon list2 = (from p in db.Abcons
                                   from q in db.ChiTietBuocKies
                                   where (p.pdno == ab.pdno && q.abstep == 1 && p.Gsbh == macongty && p.abrult == true && q.Yn == 1 && p.pdno == ab.pdno && p.Auditor == nguoiduyettruoc.Auditor)
                                   select p).FirstOrDefault();
                    // Where(a=>a.Abstep==buoctruoc && a.pdno==ab.pdno && a.Gsbh == macongty && a.abrult == true && a.Yn == 1) ).ToList();
                    if (list2 == null)
                    {
                        if (nguoiduyettruoc.abrult == false)
                        {
                            listnew.Add(list2);
                        }
                    }
                    else
                    {
                        if (list2.abrult == true && list2.Yn == 1)
                        {
                            listnew.Add(list2);
                        }
                        else
                        {
 
                        }
                    }
                    
                }
                else
                {
                    int buochientai = ab.Abstep;
                    int buoctruoc = buochientai - 1;
                    Abcon nguoiduyettruoc = AbconDAO.LayChiTietXetDuyetTheoNhanVienDuyet1(ab.pdno, macongty, buoctruoc);
                    Abcon list2 = (from p in db.Abcons
                                   from q in db.ChiTietBuocKies
                                   where (p.pdno == ab.pdno && q.abstep == buoctruoc && p.Gsbh == macongty && p.abrult == true && q.Yn == 1  && p.Auditor==nguoiduyettruoc.Auditor && p.pdno==nguoiduyettruoc.pdno)
                                   select p).FirstOrDefault();
                    if (list2 == null)
                    {
                        //if (nguoiduyettruoc.abrult == false)
                        //{
                        //    listnew.Add(list2);
                        //}
                    }
                    else
                    {
                        if (list2.abrult == true && list2.Yn == 1)
                        {
                            listnew.Add(list2);
                        }
                        else
                        {
                            
                        }
                    }
                }
                
                #region cai nay bo
                //if (list2 == null)
                //{

                   
                //}
                //else
                //{
                //    var vanban = (from p in db.Abcons
                //                  from q in db.abills
                //                  from h in db.ABYns
                //                  from k in db.aABCs
                //                  from a in db.pdnas
                //                  from b in db.Busers
                //                  from bd in db.BDepartments
                //                  where (p.abtype == q.abtype && p.ABC == k.ABC && p.Yn == h.Yn && p.pdno == a.pdno && p.Abstep == ab.Abstep && p.abrult == false && p.Yn == 4 && p.pdno==ab.pdno)
                //                  select new
                //                  {
                //                      abtype = q.abtype,
                //                      abname = q.abname,
                //                      pdno = a.pdno,
                //                      mytitle = a.mytitle,
                //                      YnName = h.YnName,
                //                      NameABC = k.NameABC,
                //                      USERNAME = b.USERNAME,
                //                      ID = bd.ID,
                //                      DepName = bd.DepName
                //                  });

                //    foreach (var item in vanban)
                //    {
                //        Abcon1 lst = new Abcon1() { abtype = item.abtype, abname = item.abname, pdno = item.pdno, mytitle = item.mytitle, YnName = item.YnName, NameABC = item.NameABC, USERNAME = item.USERNAME, ID = item.ID, DepName = item.DepName };
                //        listnew.AddRange((new Abcon1[] { lst }));
                //    }
                //}
                #endregion
            }
          
            return listnew;
        }

        public static List<Abcon> LayDanhDanhPhieuDaDuyetTheoNguoiTao(string idnguoitao, string macongty)
        {
            var list = (from p in db.Abcons
                        from q in db.ABTrangThaiDuyets
                        where (p.pdno == q.pdno && p.Yn == q.Yn && q.Yn == 1 && p.abrult == true && p.bixoa==false && p.Gsbh==macongty && p.from_user==idnguoitao)
                        select p).ToList();
            return list;
        }
        public static List<Abcon> LayDanhDanhPhieuDaDuyetTheoNguoiDuyet(string idnguoiduyet, string macongty)
        {
            var list = (from p in db.Abcons
                        from q in db.ChiTietBuocKies
                        where (p.pdno == q.pdno && p.Yn == q.Yn && q.Yn == 1 && p.abrult == true && p.Auditor==idnguoiduyet && p.Gsbh==macongty)
                        select p).ToList();
            return list;
        }
        public static List<Abcon> LayDanhDanhPhieuDaDuyetTheoNguoiDuyetCatVaoKho(string idnguoiduyet, string macongty)
        {
            var list = (from p in db.Abcons
                        from q in db.ChiTietBuocKies
                        where (p.pdno == q.pdno && p.Yn == q.Yn && q.Yn == 1 && p.abrult == true && p.bixoa==true && p.Auditor == idnguoiduyet && p.Gsbh == macongty)
                        select p).ToList();
            return list;
        }
        public static List<Abcon> LayDanhDanhPhieuKhongDuyetTheoNguoiDuyet(string idnguoiduyet, string macongty)
        {
            var list = (from p in db.Abcons
                        from q in db.ABTrangThaiDuyets
                        where (p.pdno == q.pdno && p.Yn == q.Yn && q.Yn == 2 && p.abrult == false && p.Auditor == idnguoiduyet && p.Gsbh == macongty)
                        select p).ToList();
            return list;
        }
        public static List<Abcon> LayDanhDanhPhieuKhongDuyetTheoNguoiTao(string idnguoitao, string macongty)
        {
            var list = (from p in db.Abcons
                        from q in db.ABTrangThaiDuyets
                        where (p.pdno == q.pdno && p.Yn == q.Yn && q.Yn == 2 && p.abrult == false && p.from_user == idnguoitao && p.Gsbh == macongty)
                        select p).ToList();
            return list;
        }
        public static Abcon LayPhieuTheoNguoiDuyet(string idnguoiduyet, string idcongty, string idvanban)
        {
            return db.Abcons.Where(p => p.Auditor == idnguoiduyet && p.Gsbh == idcongty && p.pdno == idvanban).FirstOrDefault();

        }
        public static Abcon KiemTraPhieuTrongBangAbcon(string maphieu, string macongty,string manguoiduyet)
        {
            try
            {
                return db.Abcons.Where(p => p.pdno == maphieu && p.Gsbh == macongty && p.Auditor==manguoiduyet).SingleOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static Abcon LayPhieuChuaDuyetTheoNguoiDuyet(string maphieu, string manguoiduyet, string macongty)

        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.Auditor == manguoiduyet && p.Gsbh == macongty ).FirstOrDefault();
        }
        public static List<Abcon> QryBuocDuyet(string maphieu, string macongty, int buocduyet)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.Gsbh == macongty && p.Abstep == buocduyet).ToList();
        }
        public static bool CapNhatChiTietPhieuTheoNguoiDuyet(Abcon chitiet, string macongty)
        {
            Abcon chi = new Abcon();
            chi = db.Abcons.Where(p => p.IDCT == chitiet.IDCT).FirstOrDefault();
            chi.IDCT = chitiet.IDCT;
            chi.Gsbh = chitiet.Gsbh;
            chi.pdno = chitiet.pdno;
            chi.Abstep = chitiet.Abstep;
            chi.boqua = true;
            db.SubmitChanges();
            return true;
        }
        public static Abcon LayPhieuKhongDuyetTheoNguoiDuyet(string maphieu, string manguoiduyet, string macongty)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.Gsbh == macongty && p.Auditor == manguoiduyet && p.abrult == false && p.Yn == 2).FirstOrDefault();
        }
        public static Abcon TimMaPhieuTheoNguoiDuyet(string maphieu, string nguoiduyet, string macongty)
        {
            try
            {
                 return db.Abcons.Where(p => p.pdno == maphieu && p.Auditor == nguoiduyet && p.Gsbh == macongty).SingleOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool CapNhatPhieuTheoNguoiDuyet(Abcon chitiet, string macongty)
        {
            try
            {
                Abcon chi = new Abcon();
                chi = db.Abcons.Where(p => p.IDCT == chitiet.IDCT).FirstOrDefault();
                chi.IDCT = chitiet.IDCT;
                chi.Gsbh = chitiet.Gsbh;
                chi.pdno = chitiet.pdno;

                chi.bixoa = true;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> LayChiTietPhieuChuaKyTheoNguoiKyCuaBophan(string manguoiduyet,string maloaiphieu, string macongty, string madonvi)
        {
            var list = (from p in db.Abcons
                        from h in db.QPDNFlows
                        where (p.abtype == h.abtype && p.Gsbh == h.GSBH
                        && p.from_depart == h.BADEPID && p.from_depart == madonvi && p.Auditor == manguoiduyet
                        && p.abtype == maloaiphieu && p.Gsbh == macongty && p.abrult == false && p.Yn == 4 && p.bixoa == false && p.boqua == false)
                        select p).Distinct();
            return list.ToList();
        }
        public static List<Abcon> LayChiTietPhieuChuaKyTheoNguoiKyCuaBophan1( string maloaiphieu, string macongty, string madonvi)
        {
            var list = (from p in db.Abcons
                        from h in db.QPDNFlows
                        where (p.abtype == h.abtype && p.Gsbh == h.GSBH
                        && p.from_depart == h.BADEPID && p.from_depart == madonvi 
                        && p.abtype == maloaiphieu && p.Gsbh == macongty && p.abrult == false && p.Yn == 4 && p.bixoa == false && p.boqua == false )
                        select p).Distinct();
            return list.ToList();
        }
        public static List<Abcon> LayQuyTrinhKyCua1Phieu(string maphieu, string maloaiphieu, string madonvi, string macongty)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty orderby p.Abstep ascending select p;
            return list.ToList();
        }
        public static List<Abcon> LayQuyTrinhKyCua1PhieuTheoNguoiThemVao(string maphieu, string maloaiphieu, string madonvi, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.Abstep == buocky orderby p.Abstep ascending select p;
            return list.ToList();
        }
        public static Abcon TimNguoiDuyetMoiThemVaoTrongPhieu(string manguoiduyet,string maphieu, string maloaiphieu, string madonvi, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.Abstep == buocky && p.Auditor==manguoiduyet orderby p.Abstep ascending select p;
            return list.FirstOrDefault();
        }
        public static List<Abcon> LayQuyTrinhKyCua1Phieu1(string maphieu, string maloaiphieu, string madonvi, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.Abstep>buocky orderby p.Abstep ascending select p;
            return list.ToList();
        }
        public static List<Abcon> LayQuyTrinhKyCua1Phieu2(string maphieu, string maloaiphieu, string madonvi, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.Abstep >= buocky orderby p.Abstep ascending select p;
            return list.ToList();
        }
        public static List<Abcon> LayQuyTrinhKyCua1PhieuTaiThoiDiem(string maphieu, string maloaiphieu, string madonvi, string macongty,int macapduyet)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.IDCapDuyet>=macapduyet orderby p.Abstep ascending select p;
            return list.ToList();
        }
        public static bool CapNhatPhieuChuyen(Abcon aa)
        {
            try
            {
               
                Abcon chi = new Abcon();
                chi = db.Abcons.Where(p =>  p.Gsbh==aa.Gsbh && p.from_depart==aa.from_depart && p.pdno==aa.pdno && p.abtype==aa.abtype && p.Abstep==aa.Abstep && p.abps==aa.abps).FirstOrDefault();
                chi.abtype = aa.abtype;
                chi.pdno = aa.pdno;
                chi.Gsbh = aa.Gsbh;
                chi.IDCT = aa.IDCT;
                chi.Abstep = aa.Abstep;
                chi.abps = aa.abps;
                chi.from_depart = aa.from_depart;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static Abcon TimViTriCuaBuocKy(string maphieu, string maloaiphieu, string madonvi, string macongty, int buocky)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.abtype == maloaiphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.Abstep == buocky).FirstOrDefault();
        }
        public static List<Abcon> LayNguoiDuyetCoTrongQPDNFlow(string madondi, string macongty, string maloaiphieu, string manguoiduyet)
        {
            try
            {
                return db.Abcons.Where(p => p.from_depart == madondi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.Auditor == manguoiduyet && p.boqua == false && p.bixoa == false && p.ncancel == 0 && p.abrult == false && p.Yn == 4).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Abcon> QryQuyTrinhTrenSoPhieu(string madonvi, string macongty, string maloaiphieu, string maphieu,int buocduyet)
        {
            //return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abde>buocduyet).ToList();
            var list = from p in db.Abcons where p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.Abstep >= buocduyet orderby p.IDCapDuyet ascending select p;
            return list.ToList();
        }
        public static List<Abcon> QryQuyTrinhTrenSoPhieu1(string madonvi, string macongty, string maloaiphieu, string maphieu, int buocduyet)
        {
            //return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abde >= buocduyet).ToList();
            var list = from p in db.Abcons where p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abps >= buocduyet orderby p.IDCapDuyet, p.Abstep ascending select p;
            return list.ToList();
        }
        public static bool CapNhatChiTietSoPhieu(Abcon ct)
        {
            try
            {
                Abcon chitiet = new Abcon();
                chitiet = db.Abcons.Where(p => p.IDCT == ct.IDCT).FirstOrDefault();
                chitiet.IDCT = ct.IDCT;
                chitiet.pdno = ct.pdno;
                chitiet.Abstep = ct.Abstep;
                chitiet.abps = ct.abps;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool CapNhatAbconNew(Abcon ct)
        {
            try
            {
                Abcon chitiet = new Abcon();
                chitiet = db.Abcons.Where(p=>p.Gsbh==ct.Gsbh && p.abtype==ct.abtype && p.pdno==ct.pdno && p.Abstep==ct.Abstep&& p.abps==ct.abps && p.IDCT==ct.IDCT).FirstOrDefault();
                chitiet.Abstep = ct.Abstep - 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool XoaChiTietTheoSoPhieu(int  idct)
        {
            try
            {
                Abcon ab = new Abcon();
                ab = db.Abcons.Where(p => p.IDCT == idct).SingleOrDefault();
                db.Abcons.DeleteOnSubmit(ab);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool XoaAbconNew(string GSBH,  string abtype, string pdno, int abstep, int abps)
        {
            try
            {
                Abcon ab = new Abcon();
                ab = db.Abcons.Where(p => p.Gsbh==GSBH && p.abtype==abtype && p.pdno==pdno && p.Abstep==abstep && p.abps==abps).SingleOrDefault();
                db.Abcons.DeleteOnSubmit(ab);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Abcon TimNguoiDuyetTrongPhieu(string madonvi, string macongty, string maloaiphieu, string maphieu, string manguoiduyet)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.Auditor==manguoiduyet).FirstOrDefault();
        }
        public static Abcon TimBuocKyTiepTrongPhieu(string madonvi, string macongty, string maloaiphieu, string maphieu, int buocke)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abps >= buocke).FirstOrDefault();
        }
        public static Abcon TimBuocKyTruocTrongPhieu(string madonvi, string macongty, string maloaiphieu, string maphieu, int buocke)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abps == buocke).FirstOrDefault();
        }
        public static List<Abcon> QryVanBanChuaDuyetTheoNguoiDuyet( string madonvi, string maloaiphieu, string macongty, string manguoiduyet)
        {
            return db.Abcons.Where(p=> p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Auditor==manguoiduyet && p.abrult == false && p.Yn == 4 && p.bixoa == false && p.boqua == false && p.ncancel == 0).ToList();
        }

        public static List<Abcon> QryPhieuChuaDichTheoBuocDuyetCuaChiTiet(string madonvi, string maloaiphieu, string macongty, int buocky)
        {
           // return db.Abcons.Where(p => p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Abstep >= buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false).ToList();
            var list = from p in db.Abcons where p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Abstep >= buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false orderby p.pdno, p.abps, p.IDCapDuyet ascending select p;
            return list.ToList();
        }
        public static List<Abcon> QryPhieuTrongChiTietPhieuTheoCapDuyet1(string madonvi, string macongty, string maloaiphieu, string maphieu, int buocduyet)
        {
            return db.Abcons.Where(p => p.pdno == maphieu && p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.abps >= buocduyet).ToList();
        }
        public static List<Abcon> QryPhieuTheoNguoiDuyetCapDuyet(string madonvi, string macongty, string maloaiphieu, string manguoiduyet)
        {
            return db.Abcons.Where(p =>  p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.Auditor== manguoiduyet && p.abrult==false && p.Yn==4 && p.bixoa==false && p.boqua==false && p.ncancel==0).ToList();
        }
        public static List<Abcon> QryChiTietPhieuTheoNguoiDuyetCapDuyet(string madonvi, string macongty, string maloaiphieu, string maphieu)
        {
            return db.Abcons.Where(p => p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.pdno == maphieu).ToList();
        }
        public static List<Abcon> QryChiTietPhieuTheoNguoiDuyetCapDuyet1(string madonvi, string macongty, string maloaiphieu, string maphieu,string manguoiduyet,int buocduyet)
        {
            return db.Abcons.Where(p => p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.pdno == maphieu && p.Auditor!=manguoiduyet && p.Abstep>=buocduyet).ToList();
        }
        public static List<Abcon> QryChiTietPhieu(string madonvi, string macongty, string maloaiphieu)
        {
            //return db.Abcons.Where(p => p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu ).ToList();
            var list = from p in db.Abcons where p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu orderby p.pdno, p.abps ascending select p;
            return list.ToList();
        }
        public static List<Abcon> QryPhieuCuaChiTietPhieu(string madonvi, string macongty, string maloaiphieu,string maphieu)
        {
            //return db.Abcons.Where(p => p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu ).ToList();
            var list = from p in db.Abcons where p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.pdno == maphieu orderby p.abps, p.IDCapDuyet ascending select p;
            return list.ToList();
        }
        public static Abcon TimCapDuyetTheoBuocDuyet(string madonvi, string macongty, string maloaiphieu, string maphieu, int buocduyet)
        {
            var list = from p in db.Abcons where p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.pdno == maphieu && p.Abstep==buocduyet  select p;
            return list.FirstOrDefault();
        }
        public static List<Abcon> QryPhieuTaiCapDuyetChuaDuyet(string madonvi, string maloaiphieu, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Abstep == buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false orderby p.pdno, p.abps, p.IDCapDuyet ascending select p;
            return list.ToList();
        }
        public static List<Abcon> QryPhieuTaiCapDuyetChuaDuyet1(string madonvi, string maloaiphieu, string macongty,string maphieu, int buocky)
        {
            var list = from p in db.Abcons where p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.pdno == maphieu && p.Abstep >= buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false orderby p.pdno, p.abps, p.IDCapDuyet ascending select p;
            return list.Distinct().ToList();
        }
        public static List<Abcon> QryPhieuTaiCapDuyetChuaDuyet2(string madonvi, string maloaiphieu, string macongty, int buocky)
        {
            var list = from p in db.Abcons where p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Abstep > buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false orderby p.pdno, p.abps, p.IDCapDuyet ascending select p;
            return list.Distinct().ToList();
        }

        //public static List<Abcon> QryPhieuTaiCapDuyetChuaDuyet3(string madonvi, string maloaiphieu, string macongty, string maphieu)
        //{
        //    //var list = from p in db.Abcons where p.from_depart == madonvi && p.abtype == maloaiphieu && p.Gsbh == macongty && p.Abstep > buocky && p.abrult == false && p.Yn == 4 && p.ncancel == 0 && p.boqua == false && p.boqua == false orderby p.pdno, p.abde, p.IDCapDuyet ascending select p;
        //    //return list.ToList();
        //    var list =(from p in db.Abcons
        //               from h in db.QPDNFlows
        //               where(p.from_depart==h.BADEPID && p.abtype==h.abtype && )
        //}
        public static Abcon LayPhieuKhongDuyetTheoPhieu(string madonvi, string maloaiphieu, string macongty, string maphieu)
        {
            var list = from p in db.Abcons where p.from_depart == madonvi && p.Gsbh == macongty && p.abtype == maloaiphieu && p.pdno == maphieu && p.abrult==false && p.Yn==2  select p;
            return list.FirstOrDefault();
        }
        public static List<Abcon> QryChiTietPhieuTheoPhieuKhongDuocDuyet(string maphieu, string macongty,string manguoitao)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.Gsbh == macongty && p.from_user == manguoitao orderby p.abps ascending select p;
            return list.ToList();
        }
        public static Abcon LayPhieuKhongDuyetTheoNguoiTao(string maphieu, string manguoitao, string macongty)
        {
            var list = from p in db.Abcons where p.pdno == maphieu && p.from_user == manguoitao && p.Gsbh == macongty && p.abrult==false && p.Yn==2 select p;
            return list.FirstOrDefault();
        }
        public static List<Abcon> QryPhieuCoCungCapDuyet(string maphieu, string macongty, int capduyet)
        {
            var list = from p in db.Abcons where p.pdno == maphieu  && p.Gsbh == macongty && p.IDCapDuyet==capduyet select p;
            return list.ToList();
        }
        public static Abcon KiemTraPhieu(string maphieu, string macongty, int capduyet, int buocduyet)
        {
            var list = from p in db.Abcons where (p.pdno == maphieu && p.Gsbh == macongty && p.abps == capduyet && p.Abstep == buocduyet) select p;
            return list.FirstOrDefault();
        }
        public static bool  XoaPhieuBiHuy(string pdno, string macongty)

        {
            try
            {
               List<Abcon> abcon = new List<Abcon>();
               abcon = db.Abcons.Where(p => p.pdno == pdno && p.Gsbh == macongty).ToList();
               foreach (Abcon phieu in abcon)
               {
                  
                   db.Abcons.DeleteOnSubmit(phieu);
                   db.SubmitChanges();
               }
               return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static Abcon TimPhieuTheoNguoiTao(string maphieu, string macongty, string manguoiduyet)
        {
            var list = db.Abcons.Where(p => p.pdno == maphieu && p.Gsbh == macongty && p.Auditor == manguoiduyet).FirstOrDefault();
            return list;
        }
        public static Abcon LayBuocKyChuaKyXong(string pdno, string gsbh, int abstep)
        {
            try
            {
                var list = db.Abcons.Where(p => p.pdno == pdno && p.Gsbh == gsbh && p.Abstep == abstep && p.abrult == false && p.Yn == 4).FirstOrDefault();
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static Abcon TimBuocKeTiepTrongCung1CapDuyet(string pdno, string gsbh, int abstep, int abps)
        {
            try
            {
                var list = db.Abcons.Where(p => p.pdno == pdno && p.Gsbh == gsbh && p.Abstep == abstep && p.abps == abps).SingleOrDefault();
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> dsPhieuChuaDuyetTheoBuocDuyetCapDuyet(string GSBH, string BaDepid, string abtype, int abstep, int abps)
        {
            try
            {
                return db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.abtype == abtype && p.Abstep == abstep  && p.abps == abps && p.abrult == false && p.Yn == 4).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Abcon> TimPhieuChuaDuyetTheoBuocDuyetCapDuyet(string GSBH, string BaDepid, string abtype,string Auditor, int abstep)
        {
            try
            {
                return db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.abtype == abtype && p.Abstep == abstep && p.Auditor==Auditor && p.abrult==false && p.Yn==4).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> QryBuocKyLonHonBuocHienTaiTrongBangABcon(string GSBH, string BaDepid, string abtype, string pdno, int abstep, int abps)
        {
            try
            {
                // return db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.Abstep == abstep && p.abtype == abtype && p.pdno == pdno && p.abps >= abps).ToList();
                var list = from p in db.Abcons where p.Gsbh == GSBH && p.from_depart == BaDepid && p.Abstep == abstep && p.abtype == abtype && p.pdno == pdno && p.abps > abps orderby p.abps descending select p;
                return list.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Abcon> QryBuocKyLonHonBuocHienTaiTrongPhieu(string GSBH, string BaDepid, string abtype, string pdno, int abstep, int abps)
        {
            try
            {
               // return db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.Abstep == abstep && p.abtype == abtype && p.pdno == pdno && p.abps >= abps).ToList();
                var list = from p in db.Abcons where p.Gsbh == GSBH && p.from_depart == BaDepid && p.Abstep == abstep && p.abtype == abtype && p.pdno == pdno && p.abps >= abps orderby p.abps descending select p;
                return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> TimABPSMaxTrongBangABcon(string GSBH, string BaDepid, string abtype, string pdno, int abstep)
        {
            try
            {
                var list = db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.abtype == abtype && p.pdno == pdno && p.Abstep==abstep).ToList();
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> LayBuocHonBuocHienTaiTrongBangABcon(string GSBH, string BaDepid, string abtype, string pdno, int abstep)
        {
            try
            {
                var list = from p in db.Abcons where p.Gsbh == GSBH && p.from_depart == BaDepid && p.abtype == abtype && p.pdno == pdno && p.Abstep > abstep orderby p.Abstep ascending select p;
                return list.ToList();

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> QryCapTrongCung1Buoc(string GSBH, string BADePid, string abtype, string pdno, int abstep, int abps)
        {
            var list = from p in db.Abcons where p.Gsbh == GSBH && p.from_depart == BADePid && p.abtype == abtype && p.pdno == pdno && p.Abstep == abstep && p.abps > abps orderby p.abps ascending select p;
            return list.ToList();
        }
        public static Abcon TimBuocTrongQuyTrinhPhieu(string GSBH, string BADePid, string abtype, string pdno, int abstep, int abps)
        {
            var list = from p in db.Abcons where p.Gsbh == GSBH && p.from_depart == BADePid && p.abtype == abtype && p.pdno == pdno && p.Abstep == abstep && p.abps==abps  select p;
            return list.SingleOrDefault();
        }
        public static List<Abcon> DanhSachBuocDuyetTrongCapDuyetPhieu(string GSBH, string BaDepid, string abtype, string pdno, int abstep)
        {
            try
            {
                return   db.Abcons.Where(p => p.Gsbh == GSBH && p.from_depart == BaDepid && p.abtype == abtype && p.pdno == pdno && p.Abstep == abstep).ToList();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Abcon> DanhSachPhieuChoDuyetTheoNguoiDuyet(string GSBH,  string auditor)
        {
            try
            {
                var list = db.Abcons.Where(p => p.Gsbh == GSBH  && p.Auditor == auditor && p.abrult == true && p.Yn == 4).ToList();
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> QryBuocTrong1PhieuTheoCongTy(string pdno, string GSBH)
        {
            try
            {
                var list = from p in db.Abcons where p.pdno == pdno && p.Gsbh == GSBH orderby p.Abstep, p.abps ascending select p;

                return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static List<Abcon> QryBuocKyTrong1Cap(string pdno, string GSBH, string abtype, int abstep)
        {
            try
            {
                var list = from p in db.Abcons where p.abtype == abtype && p.Gsbh == GSBH && p.pdno == pdno && p.Abstep == abstep orderby p.Abstep, p.abps ascending select p;
                return list.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static Abcon TimPhieuChuaDuyet(string pdno, string GSBH)
        {
            try
            {
                return db.Abcons.Where(p => p.pdno == pdno && p.Gsbh == GSBH && p.Yn != 4).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}