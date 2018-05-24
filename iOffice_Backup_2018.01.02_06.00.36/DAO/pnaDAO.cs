using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.DAO
{
    public class pnaDAO
    {
       static  iOfficeDataContext db = new iOfficeDataContext();
        public static List<pdna> ListPDNA()
        {
            return db.pdnas.ToList();
        }
        public static bool InsertPDNA(pdna pd)
        {
            try
            {
                db.pdnas.InsertOnSubmit(pd);
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                throw;
            }

        }
      
        public static bool UpdatePDNA(pdna pd)
        {
            try
            {
                DateTime date = DateTime.Now;
                //string ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("yyyy/MM/dd");
                pdna p = new pdna();
                p = db.pdnas.Where(q => q.pdno == pd.pdno).FirstOrDefault();
                {
                    p.GSBH = pd.GSBH;
                    p.pdno = pd.pdno;
                    p.pduser = pd.pduser;

                    p.USERDATE = DateTime.Today;
                    p.USERID = pd.USERID;
                    p.YN = pd.YN;
                    p.yymemo = pd.yymemo;

                    p.CFMDate1 = DateTime.Today;
                    p.CFMDate2 = DateTime.Today;
                    p.CFMID0 = pd.CFMID0;
                    p.CFMID1 = pd.CFMID1;
                    p.CFMID2 = pd.CFMID2;
                   
                    p.mytitle = pd.mytitle;
                    p.pdDate = pd.pdDate;
                    p.pddepid = pd.pddepid;
                    p.pdLX = pd.pdLX;
                    p.pdmemoch = pd.pdmemoch;
                    p.pdmemovn = pd.pdmemovn;
                    p.NoiDungDich = pd.NoiDungDich;
                    p.bixoa = false;
                    p.dagui = true;
                    p.ABC = pd.ABC;
                    p.Abtype = pd.Abtype;
                   
                }
                db.SubmitChanges();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      
        public static bool CapNhatVanBan(string pd, string macongty)
        {
            try
            {
                //pdna p = new pdna();
                pdna p = db.pdnas.Where(q => q.pdno == pd).FirstOrDefault();
                pdna phieu = new pdna();
                {
                    phieu.pdno = p.pdno;
                    phieu.GSBH = p.GSBH;
                    phieu.dagui = true;
                    phieu.bixoa = false;
                    phieu.YN=4;
                }
                //{
                //    p.pdno = pd.pdno;
                //    p.GSBH = macongty;
                //    p.dagui = true;
                //    p.YN = 4;
                //    p.bixoa = false;
                //    p.dagui = true;
                //    ///////////

                //    //p.GSBH = macongty;
                //    //p.pdno = pd.pdno;
                //    //p.pddepid = pd.pddepid;
                //    //p.mytitle = pd.mytitle;
                //    //p.Abtype = pd.Abtype;
                //    //p.pdmemovn = pd.pdmemovn;
                //    //p.CFMDate0 = pd.CFMDate0;
                //    //p.USERID = pd.USERID;
                //    ////phieun.CFMID0 = user;
                //    //p.CFMID0 = pd.CFMID0;
                //    //p.bixoa = false;
                //    //p.dagui = true;
                //    //p.YN = 4;
                //    //p.USERDATE = pd.USERDATE;
                //    //p.ABC = pd.ABC;
                //    //p.LevelDoing = 1;

                //}

                db.SubmitChanges();
                return true;

            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool DeletePDNA(string id)
        {
            try
            {
                pdna p = new pdna();
                p = db.pdnas.Where(q => q.pdno == id).FirstOrDefault();
                db.pdnas.DeleteOnSubmit(p);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool CapNhatTinhTrangVanBan(string idVanBan, int tinhTrang, bool kiemTraBiXoa = true)
        {

            var list = (from p in db.Abcons
                        from q in db.pdnas
                        where p.pdno == q.pdno &&  q.pdno==idVanBan 
                        select q).FirstOrDefault();
            DateTime date = DateTime.Now;
           // string ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("yyyy/MM/dd");
            pdna vanban = new pdna();
            //if (kiemTraBiXoa)
            //    //vanban = db.pdnas.Where(v => v.pdno == idVanBan && v.bixoa == false).FirstOrDefault();
            //    vanban = list;
            //else
            //    vanban = db.pdnas.Where(v => v.pdno == idVanBan).FirstOrDefault();

            if (vanban == null)
            {
                return false;
            }
            try
            {
                vanban = list;
                {
                    vanban.pdno = idVanBan;
                    vanban.YN = tinhTrang;
                    vanban.CFMDate1 = DateTime.Today;
                }
                db.SubmitChanges();
               
                return true;
            }
            catch (Exception )
            {
                
                return false;
            }

            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static bool CapNhatCapDangDuyetChoVanban(string idVanBan, int capDangDuyet, bool kiemTraBiXoa = true)
        {
          
            pdna vanban = new pdna();
            //var loai=(from p in db.abills 
            //             from  q in db.pdnas where(p.abtype==q.a))
            if (kiemTraBiXoa)
                vanban = db.pdnas.Where(v => v.pdno == idVanBan ).FirstOrDefault();
            else
                vanban = db.pdnas.Where(v => v.pdno == idVanBan).FirstOrDefault();
            //VanBan vanban = TimKiemVanBanTheoMa(idVanBan, kiemTraBiXoa);
            if (vanban == null)
            {
                return false;
            }

            try
            {
                //vanban. = vanban.IdLoaiVanBan;
                vanban.LevelDoing = capDangDuyet;
                vanban.CFMDate2 = DateTime.Now;
                
                db.SubmitChanges();
                if (db != null)
                    db.ToString();
                return true;
            }
            catch (Exception )
            {
               
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return false;
            }

            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static List<pdna> QryVanBanBiXoaTheoMaBoPhan(string idBophan, string idNhanVien, bool kiemTraBiXoa = true)
        {
            var list = (from vb in db.pdnas
                        join pb in db.BDepartments on vb.pddepid equals pb.ID
                        select vb
                                  ).ToList();
            List<pdna> lstVanBan = new List<pdna>();
            try
            {
                if (kiemTraBiXoa)
                {
                   
                    lstVanBan = (from vb in list
                                
                                 where vb.CFMID0 == idNhanVien && vb.pddepid == idBophan && vb.bixoa == true
                                 select vb).ToList();
                    if (db != null)
                        db.ToString();
                    else
                    {
                        // don't
                    }
                    return lstVanBan;
                    // return vanban1s.ToList();
                }
                return new List<pdna>();
            }
            catch (Exception )
            {
                
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return new List<pdna>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        //public static List<pdna> QryVanBanTheoNhanVien(string idNhanVien, bool kiemTraBiXoa = true)
        //{

        //    var listNV = (from p in db.pdnas
        //                  join q in db.Busers on p.CFMID0 equals q.USERID
        //                  select p).ToList();
        //    var listCT = (from p in db.DetailsApproveds
        //                  join q in db.Busers on p.UserID equals q.USERID
        //                  select p).ToList();
        //    var listVB=(from q in listCT
        //                    join p in db.pdnas on q.pdno equals p.pdno select p).ToList();

        //    List<pdna> result = new List<pdna>();
        //    try
        //    {
        //        if (kiemTraBiXoa)
        //        {
        //            var vanban = from vb in listNV
        //                         where vb.CFMID0 == idNhanVien && vb.bixoa == false
        //                         select vb;
        //            var vanban1 = (from ctxd in listVB
        //                           where ctxd.CFMID2 == idNhanVien 
        //                           && ((ctxd.YN!= 0 && ctxd.YN != 1) || (ctxd.YN == 1 && !ctxd..Equals(null)) || (ctxd.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && ctxd.Duyet.Equals(null) && ctxd.VanBan_CapDuyet.VanBan.CapDangDuyet == ctxd.VanBan_CapDuyet.IdCapDuyet))
        //                            && !vanban.ToList().Contains(ctxd.VanBan_CapDuyet.VanBan)
        //                           select ctxd.VanBan_CapDuyet.VanBan).Distinct();
        //            var vanban2 = (from ctuq in db.ChiTietUyQuyens
        //                           where ctuq.UyQuyen.IdNguoiDuocUyQuyen == idNhanVien && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.BiXoa == false && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.BiXoa == false && ctuq.ChiTietXetDuyet.BiXoa == false && ctuq.BiXoa == false
        //                               && ((ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 0 && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 1) || (ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && !ctuq.ChiTietXetDuyet.Duyet.Equals(null)) || (ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && ctuq.ChiTietXetDuyet.Duyet.Equals(null) && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.CapDangDuyet == ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdCapDuyet))
        //                           && !vanban1.ToList().Contains(ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan)
        //                           && !vanban.ToList().Contains(ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan)
        //                           select ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan).Distinct();

        //            result.AddRange(vanban.ToList());
        //            result.AddRange(vanban1.ToList());
        //            result.AddRange(vanban2.ToList());

        //        }
        //        else
        //        {
        //            var vanbanx = from vb in db.VanBans
        //                          where vb.IdNguoiTao == idNhanVien && vb.BiXoa == false
        //                          select vb;
        //            var vanbanxx = (from ctxd in db.ChiTietXetDuyets
        //                            where ctxd.IdNhanVien == idNhanVien && ctxd.VanBan_CapDuyet.BiXoa == false && ctxd.VanBan_CapDuyet.VanBan.BiXoa == false && ctxd.BiXoa == false
        //                           && ((ctxd.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && !ctxd.Duyet.Equals(null)) || (ctxd.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && ctxd.Duyet.Equals(null) && ctxd.VanBan_CapDuyet.VanBan.CapDangDuyet == ctxd.VanBan_CapDuyet.IdCapDuyet) || (ctxd.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 0 && ctxd.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 1))
        //                             && !vanbanx.ToList().Contains(ctxd.VanBan_CapDuyet.VanBan)
        //                            select ctxd.VanBan_CapDuyet.VanBan).Distinct();
        //            var vanbanxxx = (from ctuq in db.ChiTietUyQuyens
        //                             where ctuq.UyQuyen.IdNguoiDuocUyQuyen == idNhanVien && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.BiXoa == false && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.BiXoa == false && ctuq.ChiTietXetDuyet.BiXoa == false && ctuq.BiXoa == false
        //                              && ((ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 0 && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet != 1) || (ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && !ctuq.ChiTietXetDuyet.Duyet.Equals(null)) || (ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TinhTrangXetDuyet == 1 && ctuq.ChiTietXetDuyet.Duyet.Equals(null) && ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.CapDangDuyet == ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdCapDuyet))
        //                             && !vanbanx.ToList().Contains(ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan)
        //                             && !vanbanxx.ToList().Contains(ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan)
        //                             select ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan).Distinct();

        //            result.AddRange(vanbanx.ToList());
        //            result.AddRange(vanbanxx.ToList());
        //            result.AddRange(vanbanxxx.ToList());
        //        }
        //        if (db != null)
        //            db.ToString();
        //        else
        //        {
        //            // don't
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.WriteFileLogServer("QryVanBanTheoNhanVien\t\t" + "\tMessage Error:\t\t" + ex.Message);
        //        // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
        //        return new List<VanBan>();
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.ToString();
        //    }
        //}

       

        public static int DemSoLuongVanBanTheoBoPhan(string idPhongBan, bool kiemTraBiXoa = true)
        {
           
            try
            {
                int dem = 0;
                if (kiemTraBiXoa)
                {
                    dem = (from vb in db.pdnas
                           from nv in db.Busers2s
                           from p in db.BDepartments
                           where vb.CFMID0 == nv.USERID && vb.pddepid==p.ID &&vb.pddepid == idPhongBan && nv.bixoa == false && vb.bixoa == false
                           select vb.pdno).Count();
                    //return vanban1s;
                }
                else
                {
                    dem = (from vb in db.pdnas
                           from nv in db.Busers2s
                           from p in db.BDepartments
                           where vb.CFMID0 == nv.USERID && vb.pddepid == p.ID && vb.pddepid == idPhongBan 
                           select vb.pdno).Count();
                    //  return vanban2s;
                }
                if (db != null)
                    db.ToString();
                else
                {
                    //--------------------
                }
                return dem;
            }
            catch (Exception )
            {
                
                return -1;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static List<pdna> TimKiemVanBanTheoMaNguoiTao(string maNguoiTao,string macongty, bool kiemTraBiXoa = true)
        {
            
            List<pdna> lstVanBan = new List<pdna>();
            try
            {
                if (kiemTraBiXoa)
                {

                    var list = from p in db.Busers2s
                               from q in db.pdnas
                               where (p.USERID == q.CFMID0 && q.CFMID0 == maNguoiTao && p.GSBH==macongty && q.bixoa==false)
                               select q;
                }
                else
                {
                    var list = from p in db.Busers2s
                               from q in db.pdnas
                               where (p.USERID == q.CFMID0 && q.CFMID0 == maNguoiTao && p.GSBH == macongty)
                               select q;

                    //  return db.VanBans.Where(vb => vb.IdNguoiTao == maNguoiTao).ToList();
                }
                db.ToString();
                return lstVanBan;
            }
            catch (Exception)
            {
               
                return new List<pdna>();
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static pdna TimKiemVanBanTheoMaNguoiTaoCongTy(string maphieu,string maNguoiTao, string macongty, bool kiemTraBiXoa = true)
        {

            
            try
            {
                if (kiemTraBiXoa)
                {

                    var list = from p in db.Busers2s
                               from q in db.pdnas
                               where (p.USERID == q.CFMID0 && q.CFMID0 == maNguoiTao && q.GSBH == macongty && q.pdno==maphieu && q.bixoa == false)
                               select q;
                    return list.FirstOrDefault();
                }
                else
                {
                    var list = from p in db.Busers2s
                               from q in db.pdnas
                               where (p.USERID == q.CFMID0 && q.CFMID0 == maNguoiTao && q.GSBH == macongty && q.pdno == maphieu)
                               select q;
                    return list.FirstOrDefault();
                    //  return db.VanBans.Where(vb => vb.IdNguoiTao == maNguoiTao).ToList();
                }
              
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static Dictionary<bool, Abcon> LayCapDangDuyetCuaVanBan1(string idVanBan, string idnhanvien,string macongty ,System.Nullable<bool> flag, bool kiemTraBiXoa = true)
        {

            //var list=(from p in db.pdnas
            //         from q in db.Abcons
            //         where(q.pdno==p.pdno) select p).ToList();
            try
            {
                if (kiemTraBiXoa )
                {

                    Abcon cdd = (from p in db.Abcons
                                     
                                     where p.pdno == idVanBan  && p.Auditor==idnhanvien && p.Gsbh==macongty && p.bixoa==false 
                                     select p).FirstOrDefault();


                    Dictionary<bool, Abcon> result = new Dictionary<bool, Abcon>();
                    result.Add(true, cdd);
                    if (db != null)
                        db.ToString();
                    else
                    {
                        // don't
                    }
                    return result;

                }
                else 
                {


                    Abcon cdd = (from p in db.Abcons

                                 where p.pdno == idVanBan && p.Auditor == idnhanvien && p.Gsbh == macongty && p.bixoa == false 
                                 select p).FirstOrDefault();




                    Dictionary<bool, Abcon> result = new Dictionary<bool, Abcon>();
                    result.Add(true, cdd);
                    if (db != null)
                        db.ToString();
                    else
                    {
                        // don't
                    }
                    return result;

                }
                
            }
            catch (Exception ex)
            {

                //return new Dictionary<bool, PDNA_ABDE>();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static Dictionary<bool, Abcon> LayCapDangDuyetCuaVanBanQuaMail(string idVanBan, string idnhanvien, string macongty, System.Nullable<bool> flag, bool kiemTraBiXoa = true)
        {

            //var list=(from p in db.pdnas
            //         from q in db.Abcons
            //         where(q.pdno==p.pdno) select p).ToList();
            try
            {
                if (kiemTraBiXoa)
                {

                    Abcon cdd = (from p in db.Abcons

                                 where p.pdno == idVanBan && p.Auditor == idnhanvien && p.Gsbh == macongty && p.bixoa == false
                                 select p).FirstOrDefault();


                    Dictionary<bool, Abcon> result = new Dictionary<bool, Abcon>();
                    result.Add(true, cdd);
                    if (db != null)
                        db.ToString();
                    else
                    {
                        // don't
                    }
                    return result;

                }
                else
                {


                    Abcon cdd = (from p in db.Abcons

                                 where p.pdno == idVanBan && p.Auditor == idnhanvien && p.Gsbh == macongty && p.bixoa == false
                                 select p).FirstOrDefault();




                    Dictionary<bool, Abcon> result = new Dictionary<bool, Abcon>();
                    result.Add(true, cdd);
                    if (db != null)
                        db.ToString();
                    else
                    {
                        // don't
                    }
                    return result;

                }

            }
            catch (Exception ex)
            {

                //return new Dictionary<bool, PDNA_ABDE>();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static bool CapNhatIdNguoiDangDuyetChoVanBan(string idVanBan, string idNguoiDangDuyet, bool kiemTraBiXoa = true)
        {
           
            pdna vanban = new pdna();
            if (kiemTraBiXoa)
                vanban = db.pdnas.Where(v => v.pdno == idVanBan).FirstOrDefault();
            else
                vanban = db.pdnas.Where(v => v.pdno == idVanBan).FirstOrDefault();
            if (vanban == null)
            {

                return false;
            }

            try
            {
                
                vanban.CFMID2 = idNguoiDangDuyet;
                vanban.CFMDate2 = DateTime.Now;
                

                db.SubmitChanges();
                if (db != null)
                    db.ToString();
                else
                {
                    // don't
                }
                return true;
                //return true;
            }
            catch (Exception )
            {
                
                // HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return false;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }

        public static pdna LayNoiDungVanBanTheoMaVanBan(string id)
        {
            var list=(from q in db.Abcons
                          from p in db.pdnas where(q.pdno==p.pdno && p.pdno==id) select p).FirstOrDefault();
            return list;
        }
        //public static pdna TimVanBanTheoMa(string idvanban,string macongty,  bool kiemtrabixoa = true)
        //{
        //    //var list = (from p in db.pdnas
        //    //            where ( p.pdno == idvanban && p.bixoa == false)
        //    //            select p).FirstOrDefault();
        //    //return list;
        //    var list = from p in db.pdnas.Where(p => p.pdno == idvanban && p.GSBH==macongty) select p;
        //    return list.FirstOrDefault();
        //   // return db.pdnas.Where(p => p.pdno == idvanban).FirstOrDefault();
        //}
        public static pdna TimVanBanTheoMa(string idvanban, string idcty, bool kiemtrabixoa = true)
        {
            //var list = (from p in db.pdnas
            //            where ( p.pdno == idvanban && p.bixoa == false)
            //            select p).FirstOrDefault();
            //return list;
            //var list = from p in db.pdnas.Where(p => p.pdno == idvanban && p.GSBH == idcty && p.bixoa == false) select p;
            //return list.FirstOrDefault();
            return db.pdnas.Where(p => p.pdno == idvanban && p.GSBH == idcty && p.bixoa == false).SingleOrDefault();
        }
        public static pdna LayNoiDungCuaVanBan(string idvanban, bool kiemtrabixoa = true)
        {
           
                if (kiemtrabixoa)
                {
                    var list = (from p in db.pdnas
                                from q in db.Abcons
                                where (p.pdno == q.pdno && p.pdno == idvanban && p.bixoa == false && q.bixoa == false)
                                select p).FirstOrDefault();
                    return list;
                }
                var list1 = (from p in db.pdnas
                             from q in db.Abcons
                             where (p.pdno == q.pdno && p.pdno == idvanban && p.bixoa == false && q.bixoa == false)
                             select p).FirstOrDefault();
                return list1;
          
        }
        public static int DemSoLuongVanBan()
        {

            try
            {
                int dem = db.pdnas.ToList().Count();
                db.ToString();
                return dem;
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("DemSoLuongChiTietXetDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
                return 0;
            }

        }
        public static List<pdna> QryVanBanDen()
        {
            return db.pdnas.ToList();
        }
        public static bool XoaVanBan(pdna pVanBan, bool kiemTraBiXoa = true)
        {
          
            try
            {
                //VanBan vanban = TimKiemVanBanTheoMa(pVanBan.IdVanBan, kiemTraBiXoa);
                pdna vanban = new pdna();
                if (kiemTraBiXoa)
                    vanban = db.pdnas.Where(v => v.pdno == pVanBan.pdno && v.bixoa == false).FirstOrDefault();
                else
                    vanban = db.pdnas.Where(v => v.pdno == pVanBan.pdno).FirstOrDefault();

                if (vanban == null)
                {
                    return false;
                }

                if (kiemTraBiXoa)
                {
                    vanban.bixoa = true;
                    db.SubmitChanges();
                    db.ToString();
                    return true;
                }

                db.pdnas.DeleteOnSubmit(vanban);
                db.SubmitChanges();
                db.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Until.WriteFileLogServer("XoaVanBan\t\t" + "\tMessage Error:\t\t" + ex.Message);
                //  HeThong.khoiTaoData(HeThong.laychuoiketnoi());
                return false;
            }
            finally
            {
                if (db != null)
                    db.ToString();
            }
        }
        public static pdna LayNoiDungVanBanTheoIDPhieuIDNhanVien(string idphieu, string idnhanvien,string macongty)
        {
            var list = (from p in db.pdnas
                        from q in db.Abcons
                        from h in db.Busers2s
                        where (p.pdno == q.pdno && q.Auditor == h.USERID && q.Auditor == idnhanvien && p.pdno == idphieu && q.Gsbh==macongty)
                        select p).FirstOrDefault();
            return list;
        }
        public static pdna LayVanBanDaGuiDenNguoiDuyetTheoNGuoiTrinhDuyet(string idvanban, string idnguoidich, string macongty)
        {
            try
            {
                return db.pdnas.Where(p => p.pdno == idvanban && p.IdnguoiDich == idnguoidich && p.GSBH == macongty && p.trangthaidich==false && p.YN==6).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static pdna LayVanBanChuaDichTheoNguoiTrinhKy(string idvanban, string macongty, string nguoistrinhky)
        {
            try
            {
                return db.pdnas.Where(p => p.pdno == idvanban && p.GSBH == macongty && p.CFMID0 == nguoistrinhky && p.trangthaidich==false).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<pdna> QryVanBanChuaDichTheoNguoiTrinhKy(string macongty, string manguoitrinhduyet)
        {
            try
            {
                return db.pdnas.Where(p=>p.GSBH==macongty && p.CFMID0==manguoitrinhduyet && p.trangthaidich==false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<pdna> QryVanBanDaDichTheoNguoiTrinhKy(string macongty, string manguoitrinhduyet)
        {
            try
            {
                return db.pdnas.Where(p => p.GSBH == macongty && p.CFMID0 == manguoitrinhduyet && p.trangthaidich == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static pdna LayVanBanChuaDichTheoNguoiDich(string idvanban, string macongty, string idnguoidich)
        {
            try
            {
                return db.pdnas.Where(p => p.pdno == idvanban && p.GSBH == macongty && p.IdnguoiDich == idnguoidich && p.trangthaidich == false).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<pdna> QryVanBanChuaDichTheoNguoiDich(string macongty, string manguoidich)
        {
            try
            {
                return db.pdnas.Where(p => p.GSBH == macongty && p.IdnguoiDich == manguoidich && p.trangthaidich == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<pdna> QryVanBanDaDichTheoNguoiDich(string macongty, string manguoidich)
        {
            try
            {
                return db.pdnas.Where(p => p.GSBH == macongty && p.IdnguoiDich == manguoidich && p.trangthaidich == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static pdna LayVanBanDaDichTheoNguoiDich(string maphieu,string macongty, string manguoidich)
        {
            try
            {
                return db.pdnas.Where(p => p.GSBH == macongty && p.pdno==maphieu && p.IdnguoiDich == manguoidich && p.trangthaidich == true).FirstOrDefault();
                //var list = (from p in db.pdnas
                //            from q in db.ChiTietBuocKies
                //            where (p.pdno == q.pdno &&p.pdno==maphieu && p.GSBH == macongty && p.IdnguoiDich == manguoidich && p.trangthaidich == true )
                //            select p).FirstOrDefault();
                //return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool CapNhatPhieuDich(pdna phieudich,string macongty)
        {
            try
            {
                pdna phieu = new pdna();
                phieu = db.pdnas.Where(p => p.pdno == phieudich.pdno && p.GSBH == macongty).FirstOrDefault();
                phieu.pdno = phieudich.pdno;
                phieu.GSBH = macongty;
                phieu.CFMDate2 = phieudich.CFMDate2;
                phieu.CFMDate4 = phieudich.CFMDate4;
                phieu.NoiDungDich = phieudich.NoiDungDich;
                phieu.trangthaidich = phieudich.trangthaidich;
                phieu.IdnguoiDich = phieudich.IdnguoiDich;
                phieu.bixoa = false;

                phieu.dagui = false;
                
                db.SubmitChanges();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool CapNhatPhieuTao(pdna phieutao, string macongty)
        {
            try
            {
               // db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, phieutao);
                pdna phieu = new pdna();
                phieu = db.pdnas.Where(p => p.pdno == phieutao.pdno && p.GSBH == macongty).FirstOrDefault();

                phieu.pdno = phieutao.pdno;
                phieu.GSBH = macongty;
                phieu.CFMDate1 = phieutao.CFMDate1;
                phieu.pdmemovn = phieutao.pdmemovn;
               
                phieu.NoiDungDich = phieutao.NoiDungDich;
                phieu.trangthaidich = false;
                phieu.IdnguoiDich = phieutao.IdnguoiDich;
                phieu.mytitle = phieutao.mytitle;
                phieu.bixoa = false;
               
                phieu.CFMID0 = phieutao.CFMID0;
                
                phieu.dagui = false;
                phieu.LevelDoing = 1;
                phieu.mytitle = phieutao.mytitle;
             
                phieu.pddepid = phieutao.pddepid;
                
                phieu.USERID = phieutao.USERID;
                phieu.YN = 5;
              
               
                db.SubmitChanges();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool CapNhatPhieuTao1(pdna phieutao, string macongty)
        {
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.pdnas.Where(p=>p.pdno==phieutao.pdno && p.GSBH==macongty).FirstOrDefault());
                pdna phieu = new pdna();
                phieu = db.pdnas.Where(p => p.pdno == phieutao.pdno && p.GSBH == macongty).FirstOrDefault();

                phieu.pdno = phieutao.pdno;
                phieu.GSBH = macongty;
                phieu.CFMDate1 = phieutao.CFMDate1;
                phieu.pdmemovn = phieutao.pdmemovn;

                //phieu.NoiDungDich = phieutao.NoiDungDich;
                phieu.trangthaidich = phieutao.trangthaidich;
                phieu.IdnguoiDich = phieutao.IdnguoiDich;
                phieu.mytitle = phieutao.mytitle;
                phieu.bixoa = phieutao.bixoa;

                phieu.CFMID0 = phieutao.CFMID0;

                phieu.dagui = phieutao.dagui;
                phieu.LevelDoing = phieutao.LevelDoing;
                phieu.mytitle = phieutao.mytitle;



                phieu.USERID = phieutao.USERID;
                phieu.YN = phieutao.YN;


                db.SubmitChanges();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                // db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.pdnas.ToList());

                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }

                db.SubmitChanges();
                return true;
            }
            //catch (System.Data.Linq.ChangeConflictException ex)
            //{
            //    foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
            //    {
            //        conflict.Resolve(RefreshMode.OverwriteCurrentValues);
            //    }

            //    db.SubmitChanges();
            //    return true;
            //}
            catch (Exception)
            {
                throw;
            }
        }

        
        public static bool CapNhatPhieuTaoNhoDich(pdna phieutao, string macongty)
        {
            try
            {
                //pdna phieu = new pdna();
             pdna   phieu = db.pdnas.Where(p => p.pdno == phieutao.pdno && p.GSBH==macongty ).SingleOrDefault();
               
                phieu.pdno = phieutao.pdno;
                phieu.GSBH = macongty;
                phieu.CFMDate1 = phieutao.CFMDate1;

                phieu.pdmemovn = phieutao.pdmemovn;
                phieu.NoiDungDich = phieutao.NoiDungDich;
                phieu.trangthaidich = false;
                phieu.IdnguoiDich = phieutao.IdnguoiDich;
                phieu.ABC = phieu.ABC;
                phieu.Abtype = phieu.Abtype;
                phieu.bixoa = false;
                phieu.CFMDate0 = phieutao.CFMDate0;
                phieu.CFMDate2 = phieutao.CFMDate2;
                phieu.CFMDate4 = phieutao.CFMDate4;
                phieu.CFMID0 = phieutao.CFMID0;
                phieu.CFMID1 = phieutao.CFMID1;
                phieu.CFMID2 = phieutao.CFMID2;
                phieu.dagui = false;
                phieu.LevelDoing = phieutao.LevelDoing;
                phieu.mytitle = phieutao.mytitle;
                phieu.pdDate = phieutao.pdDate;
                phieu.pddepid = phieutao.pddepid;
                phieu.pdLX = phieutao.pdLX;
                phieu.pdmemoch = phieutao.pdmemoch;
                phieu.pduser = phieutao.pduser;
                phieu.pdyyid = phieutao.pdyyid;
                phieu.PMARK = phieutao.PMARK;
                phieu.SB = phieutao.SB;
                phieu.shmemo = phieutao.shmemo;
                phieu.USERDATE = phieutao.USERDATE;
                phieu.USERID = phieutao.USERID;
                phieu.YN = 6;
                phieu.yymemo = phieutao.yymemo;
                phieu.ZSBH = phieutao.ZSBH;
                db.SubmitChanges();
                return true;
            }
            catch (System.Data.Linq.ChangeConflictException )
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    //?  

                    // ?Linq  
                    occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // Linq?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // ?  
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static pdna LayVanBanTheoNguoiTrinh(string idvanban, string macongty, string idnguoitrinh)
        {
            try
            {
                return db.pdnas.Where(p => p.pdno == idvanban && p.GSBH == macongty && p.CFMID0 == idnguoitrinh ).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<pdna> QryPhieuDaGuiTheoNguoiGui(string manguoigui, string macongty)
        {
            var list = (from p in db.pdnas
                        from q in db.ABTrangThaiDuyets
                        where (p.pdno == q.pdno && p.GSBH == macongty && p.CFMID0 == manguoigui)
                        select p).ToList();
            return list;
        }
        public static pdna LayPhieuTheoNguoiGui(string maphieu, string manguoitao, string macongty)
        {
            try
            {
                return db.pdnas.Where(p => p.pdno == maphieu && p.CFMID0 == manguoitao && p.GSBH==macongty).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool CapNhatPhieuBiHuy(pdna pd)
        {
            try
            {
                 DateTime date = DateTime.Now;
               //  string ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("yyyy/MM/dd");
                pdna p = new pdna();
                p = db.pdnas.Where(q => q.pdno == pd.pdno).FirstOrDefault();
                {
                    p.GSBH = pd.GSBH;
                    p.pdno = pd.pdno;


                    p.USERDATE = date;
                    p.CFMDate0 = date;
                    p.YN = pd.YN;


                    p.CFMDate1 = pd.CFMDate1;
                    p.CFMDate2 = pd.CFMDate2;
                    p.CFMDate4 = pd.CFMDate4;
                   
                    p.NoiDungDich = pd.NoiDungDich;
                    p.bixoa = false;
                    p.dagui = false;
                    p.ABC = pd.ABC;
                  
                    p.IdnguoiDich = pd.IdnguoiDich;
                    p.trangthaidich = false;
                    p.YN = pd.YN;
                   
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static pdna TimPhieuDaTungBiHuy(string maphieu, string macongty)
        {
            return db.pdnas.Where(p => p.pdno == maphieu && p.GSBH == macongty && p.oldpdno != null ).FirstOrDefault();
        }
        public static List<BOfSupply> LayPhieuMuaHang(string maphieu, string macongty)
        {
            var list = from p in db.pdnas
                       join h in db.BOfSupplies on p.pdno equals h.pdno
                       where p.pdno == h.pdno && p.GSBH == h.GSBH && h.pdno==maphieu && h.GSBH==macongty orderby h.IDOfSupplies ascending
                       select h;
            return list.ToList();

        }
        public static bool CapNhatPhieuGuiBiHuy(string maphieu, string macongty)
        {
            try
            {
                int YN=5;
                //pdna phieu = db.pdnas.Where(p => p.pdno == maphieu && p.GSBH == macongty).FirstOrDefault();
                //phieu.YN = 7;
                //phieu.pdno = maphieu;
                //phieu.GSBH = macongty;
                //db.SubmitChanges();
                //return true;
                db.ExecuteCommand("update pdna set YN='" + YN + "', dagui=0 where  pdno='" + maphieu + "' and GSBH='" + macongty + "'");
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static pdna TimKiemMaPhieuTheoNguoiDich(string pdno, string GSBH, string IDNguoiDich)
        {
            try
            {
                return db.pdnas.Where(p => p.GSBH == GSBH && p.pdno == pdno && (p.IdnguoiDich == IDNguoiDich || p.CFMID0 == IDNguoiDich) && p.bixoa == true).SingleOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}