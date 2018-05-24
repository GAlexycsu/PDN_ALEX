using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for BLL_Import
/// </summary>
public class BLL_Import
{
    DAL_ImportData _dll = new DAL_ImportData();
	public BLL_Import()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet LayDanhSachData()
    {
        try
        {
            return _dll.LayDanhSachData();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
   
    public DataSet LayDanhSachTheoNgay(DateTime userdate,string UserID)
    {
        try
        {
            return _dll.LayDanhSachTheoNgay(userdate,UserID);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public DataTable TimMaMauTheoDangDay(string XieXing)
    {
        try
        {
            return _dll.TimMaMauTheoDangDay(XieXing);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet DemSoLuongRecordInsert(string userid, DateTime UserDate)
    {
        try
        {
            return _dll.DemSoLuongRecordInsert(userid, UserDate);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataTable DocFileExcel(string excelFile, string SheetName, string Extension)
    {
        try
        {
            return _dll.DocFileExcel(excelFile, SheetName, Extension);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public void OpenFileExcel(string fileName)
    {
        try
        {
            _dll.OpenFileExcel(fileName);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public void Import(List<string> list,string excelFile, string SheetName, string Extension, string UserID, ref string Y1001_AO,ref string BWBH)
    {
        try
        {
            _dll.Import(list,excelFile, SheetName, Extension, UserID, ref Y1001_AO,ref BWBH);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet GetExcel(string fileName, string sheetName)
    {
        try
        {
            return _dll.GetExcel(fileName, sheetName);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public int UpdateData(string XieXing, string SheHao, string BWBH, string XTCC,string UserDate,string UserID, decimal CLSL)
    {
        try
        {
            return _dll.UpdateData(XieXing, SheHao, BWBH, XTCC,UserDate,UserID, CLSL);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public int XoaDuLieu(string XieXing, string SheHao, string BWBH)
    {
        try
        {
            return _dll.XoaDuLieu(XieXing, SheHao, BWBH);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachDataByCondition(string TuNgay, string DenNgay, string id, string UserID)
    {
        try
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;
            if (TuNgay != "")
            {
                fromDate = DateTime.Parse(TuNgay.ToString());
            }
            if (DenNgay != "")
            {
                toDate = DateTime.Parse(DenNgay.ToString());
            }
            return _dll.LayDanhSachDataByCondition(fromDate, toDate, id, UserID);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachDuLieuNhapVao(string XieXing, string SheHao)
    {
        try
        {
           return  _dll.LayDanhSachDuLieuNhapVao(XieXing, SheHao);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachDuLieuTheoNgay(string UserDate, string UserID, string XieXing, string SheHao)
    {
        try
        {
            return _dll.LayDanhSachDuLieuTheoNgay(UserDate, UserID,XieXing,SheHao);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachDataByCondition1(string UserID, string XieXing, string SheHao)
    {
        try
        {
            //DateTime? fromDate = null;
            //DateTime? toDate = null;
            //if (TuNgay != "")
            //{
            //    fromDate = DateTime.Parse(TuNgay.ToString());
            //}
            //if (DenNgay != "")
            //{
            //    toDate = DateTime.Parse(DenNgay.ToString());
            //}
            return _dll.LayDanhSachDataByCondition1( UserID, XieXing, SheHao);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachDataByCondition2(string UserID, string XieXing, string SheHao)
    {
        try
        {
            return _dll.LayDanhSachDataByCondition2(UserID, XieXing, SheHao);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet DanhSachMaDay()
    {
        try
        {
            return _dll.DanhSachMaDay();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet DanhSachMaMau()
    {
        try
        {
            return _dll.DanhSachMaMau();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public  string[] GetXieXing(string prefixText, int count, string contextKey)
    {
        try
        {
            return _dll.GetXieXing(prefixText, count, contextKey);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public string[] GetSheHao(string prefixText, int count, string contextKey)
    {
        try
        {
            return _dll.GetSheHao(prefixText, count, contextKey);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
   
}