using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
   public class bllPDN
    {
        DAL_PDN dal = new DAL_PDN();
    //public BllPDN()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    public DataTable SoPhieuChoToiDuyet(string IDNguoiDuyet,string GSBH, DateTime NgayGui)
    {
        try
        {
           // DateTime pNgayGui = DateTime.Parse(NgayGui);
            return dal.SoPhieuChoToiDuyet(IDNguoiDuyet,GSBH, NgayGui);
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
            return dal.SoPhieuDaDichChoToiGui(IDnguoiTao, Ngay);
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
            return dal.SoPhieuChoToiDich(IDNguoiDich, GSBH);
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
            return dal.QryPhieuDaKyDaDich(GSBH, UserID, FromDate);
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
            return dal.QryPhieuDaDich(GSBH, UserID);
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
            return dal.QryPhieuChoKyTheoNguoiKy(UserID, GSBH);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    }
}
