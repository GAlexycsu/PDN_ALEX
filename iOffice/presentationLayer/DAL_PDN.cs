using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_PDN:DAL_SQL_GenericDataAccess
    {
        public DAL_PDN()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       
        string maphieua = "";
        public DataTable SoPhieuChoToiDuyet(string IDNguoiDuyet, string GSBH, DateTime NgayGui)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct ab.pdno from Abcon ab";
                //cmd.CommandText += " left join pdna pd on ab.pdno=pd.pdno and pd.GSBH=ab.Gsbh";
                //cmd.CommandText += " where  ab.Auditor=@Auditor and ab.GSBH=@GSBH and ab.Yn=4 ";
                cmd.CommandText = "SoPhieuChoToiDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("Auditor", IDNguoiDuyet, SqlDbType.VarChar));
               // cmd.Parameters.Add(Para("CFMDate0", NgayGui, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SoPhieuDaDichChoToiGui(string IDnguoiTao, DateTime Ngay)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pdno  from pdna where trangthaidich=1";
                //cmd.CommandText += " and dagui=0  and CFMID0=@CFMID0";
                cmd.CommandText = "SoPhieuDaDichChoToiGui";
                cmd.Parameters.Add(Para("CFMID0", IDnguoiTao, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CFMDate2", Ngay, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SoPhieuChoToiDich(string IDNguoiDich, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SoPhieuChoToiDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuChuaDuyet(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct abc.pdno from Abcon abc";
                //cmd.CommandText += " left join pdna pd on abc.pdno =pd.pdno and abc.Gsbh=pd.GSBH";
                //cmd.CommandText += " where abc.Yn=4 and abc.abrult=0 and abc.Gsbh=@GSBH and abc.Auditor=@Auditor ";
                cmd.CommandText = "QryPhieuChuaDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Auditor", UserID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaKyDaDich(string GSBH, string UserID, DateTime FromDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select pd.Abtype,abil.abname, pd.pdno,";
                //cmd.CommandText += " (pd.mytitle +''+pd.pdnsubject) as  mytitle,pd.pddepid,bd.DepName";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.CFMID0 and bu.GSBH=pd.GSBH";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                //cmd.CommandText += "  (pd.YN=1 and pd.CFMDate0=@CFMDate0 or pd.YN=6 and pd.trangthaidich=1 ) and pd.bixoa=0";
                cmd.CommandText = "QryPhieuDaKyDaDich1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CFMDate0", FromDate, SqlDbType.DateTime));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDich(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.pdno";
                //cmd.CommandText += " from pdna pd ";
                //cmd.CommandText += " where  pd.YN=6 and pd.trangthaidich=1 and pd.bixoa=0 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                cmd.CommandText = "QryPhieuDaDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CFMID0", UserID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuChoDuyetChuaPhan(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct ab.pdno from Abcon ab";
                //cmd.CommandText += " left join pdna pd on ab.pdno=pd.pdno and pd.GSBH=ab.Gsbh";
                //cmd.CommandText += " where  ab.Auditor=@Auditor and ab.GSBH=@GSBH and ab.Yn='4' and ab.bixoa='0'";
                cmd.CommandText = "QryPhieuChoDuyetChuaPhan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Auditor", UserID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayCapHienTaiCuaNguoiDuyet(string maphieu, string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayCapHienTaiCuaNguoiDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("pdno", maphieu, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Auditor", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Gsbh", GSBH, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayCapTruocCuaNhanVien(string pdno, string GSBH, int Abstep, int abps)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayCapTruocCuaNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Gsbh", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Abstep", Abstep, SqlDbType.Int));
                cmd.Parameters.Add(Para("abps", abps, SqlDbType.Int));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayCapTruocCuaNhanVien1(string pdno, string GSBH, int Abstep, int abps)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayCapTruocCuaNhanVien1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Gsbh", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Abstep", Abstep, SqlDbType.Int));
                cmd.Parameters.Add(Para("abps", abps, SqlDbType.Int));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayBuocMaxCuaCapTruoc(string pdno, string GSBH, int Abstep)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LayBuocMaxCuaCapTruoc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Gsbh", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Abstep", Abstep, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> QryPhieuChoKyTheoNguoiKy(string UserID, string GSBH)
        {
            try
            {
                DataTable dt = QryPhieuChoDuyetChuaPhan(GSBH, UserID);
                List<string> list = new List<string>();

                //DataTable dsPhieu = new DataTable();
                foreach (DataRow dr in dt.Rows)
                {
                    string maphieu = dr["pdno"].ToString().Trim();
                    maphieua = maphieu;
                    DataTable dtPhieuHienTai = LayCapHienTaiCuaNguoiDuyet(maphieu, UserID, GSBH);
                    int caphientai = int.Parse(dtPhieuHienTai.Rows[0]["Abstep"].ToString());
                    int buochientai = int.Parse(dtPhieuHienTai.Rows[0]["abps"].ToString());
                    int YnHienTai = int.Parse(dtPhieuHienTai.Rows[0]["Yn"].ToString());
                    string giaitriHT = dtPhieuHienTai.Rows[0]["abrult"].ToString().ToLower();
                    if (caphientai == 1 && YnHienTai == 4)
                    {
                        if (buochientai > 1)
                        {
                            DataTable dtCapTruoc = LayCapTruocCuaNhanVien(maphieu, GSBH, caphientai, buochientai - 1);

                            string giatritruoc = dtCapTruoc.Rows[0]["abrult"].ToString().ToLower();
                            int YnCapTruoc = int.Parse(dtCapTruoc.Rows[0]["Yn"].ToString());
                            //string maphieuTruoc = dt.Rows[0]["pdno"].ToString();
                            if (giatritruoc == "true" && YnCapTruoc == 1)
                            {
                                //foreach (DataRow drCT in dtCapTruoc.Rows)
                                //{
                                //    dsPhieu.Rows.Add(drCT["pdno"].ToString());

                                //}
                                list.Add(maphieu);

                            }
                        }
                        else if (buochientai == 1)
                        {
                            list.Add(maphieu);
                        }

                    }// cap hien tai >1
                    else
                    {
                        DataTable dtMaxHientai = LayBuocMaxCuaCapTruoc(maphieu, GSBH, caphientai);
                        int abpsMax = int.Parse(dtMaxHientai.Rows[0]["abps"].ToString());
                        if (abpsMax == 1)
                        {
                            DataTable dtMaxTruoc = LayBuocMaxCuaCapTruoc(maphieu, GSBH, caphientai - 1);
                            int BuocMax = int.Parse(dtMaxTruoc.Rows[0]["abps"].ToString());
                            DataTable dtTruoc = LayCapTruocCuaNhanVien1(maphieu, GSBH, caphientai - 1, BuocMax);
                            int AbtypeTruoc = int.Parse(dtTruoc.Rows[0]["Abstep"].ToString());
                            int abpsTruoc = int.Parse(dtTruoc.Rows[0]["abps"].ToString());
                            int YnTruoc = int.Parse(dtTruoc.Rows[0]["Yn"].ToString());
                            string abrultTruoc = dtTruoc.Rows[0]["abrult"].ToString().ToLower();
                            if (abpsTruoc > 1)
                            {
                                if (YnTruoc == 1 && abrultTruoc == "true")
                                {
                                    list.Add(maphieu);
                                }
                            }
                            else if (abpsTruoc == 1)
                            {
                                if (YnTruoc == 1 && abrultTruoc == "true")
                                {
                                    list.Add(maphieu);
                                }
                            }
                        }
                        else
                        {
                            if (buochientai <= abpsMax)
                            {
                                if (buochientai > 1)
                                {
                                    DataTable dtCapTruoc = LayCapTruocCuaNhanVien(maphieu, GSBH, caphientai, buochientai - 1);

                                    string giatritruoc = dtCapTruoc.Rows[0]["abrult"].ToString().ToLower();
                                    int YnCapTruoc = int.Parse(dtCapTruoc.Rows[0]["Yn"].ToString());
                                    //string maphieuTruoc = dt.Rows[0]["pdno"].ToString();
                                    if (giatritruoc == "true" && YnCapTruoc == 1)
                                    {
                                        //foreach (DataRow drCT in dtCapTruoc.Rows)
                                        //{
                                        //    dsPhieu.Rows.Add(drCT["pdno"].ToString());

                                        //}
                                        list.Add(maphieu);

                                    }
                                }
                                else
                                {
                                    if (buochientai == 1)
                                    {
                                        DataTable dtMaxTruoc = LayBuocMaxCuaCapTruoc(maphieu, GSBH, caphientai - 1);
                                        if (dtMaxTruoc.Rows.Count > 0)
                                        {
                                            try
                                            {


                                                string ab = dtMaxTruoc.Rows[0]["abps"].ToString();

                                                int BuocMax = int.Parse(ab);
                                                DataTable dtTruoc = LayCapTruocCuaNhanVien1(maphieu, GSBH, caphientai - 1, BuocMax);
                                                int AbtypeTruoc = int.Parse(dtTruoc.Rows[0]["Abstep"].ToString());
                                                int abpsTruoc = int.Parse(dtTruoc.Rows[0]["abps"].ToString());
                                                int YnTruoc = int.Parse(dtTruoc.Rows[0]["Yn"].ToString());
                                                string abrultTruoc = dtTruoc.Rows[0]["abrult"].ToString().ToLower();
                                                if (abpsTruoc > 1)
                                                {
                                                    if (YnTruoc == 1 && abrultTruoc == "true")
                                                    {
                                                        list.Add(maphieu);
                                                    }
                                                }
                                                else if (abpsTruoc == 1)
                                                {
                                                    if (YnTruoc == 1 && abrultTruoc == "true")
                                                    {
                                                        list.Add(maphieu);
                                                    }
                                                }

                                            }
                                            catch
                                            {
                                                throw;
                                            }
                                        }
                                    }
                                }
                            }
                        }


                    }
                }

                //dsPhieu.Columns.Add("value");
                //foreach (string ph in list)
                //{
                //    DataRow drphieu = dsPhieu.NewRow();
                //    drphieu["value"] = ph;
                //    dsPhieu.Rows.Add(drphieu);
                //}
                //return dsPhieu;
                return list;
            }
            catch (Exception)
            {
                string k = maphieua;
                throw;
            }
        }
    }
}
