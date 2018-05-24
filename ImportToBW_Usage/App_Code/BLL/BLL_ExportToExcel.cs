using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class BLL_ExportToExcel
{
    ExportToExcelDAO _dll = new ExportToExcelDAO();
	public BLL_ExportToExcel()
	{
		
	}
    public DataSet LayDanhSachDuLieuNhapVao(string XieXing, string SheHao)
    {
        try
        {
            return _dll.LayDanhSachDuLieuNhapVao(XieXing, SheHao);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}