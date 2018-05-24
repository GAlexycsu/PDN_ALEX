using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for WF_ViewReport
/// </summary>
public class ViewReport : System.Web.UI.Page
{
    public ViewReport()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected bool ShowExecl(List<string> pPath, DataSet ds)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {

            foreach (string strPath in pPath)
            {
                crystalReport.Load(Server.MapPath(strPath));

            }
            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "");
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }
    }

    protected bool ShowPDF(List<string> pPath, DataSet ds)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {

            foreach (string strPath in pPath)
            {
                crystalReport.Load(Server.MapPath(strPath));

            }
            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }
    }
    protected bool ShowPDF(List<string> pPath, DataSet ds, Hashtable pHtbParameter)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {
            foreach (string strPath in pPath)
            {
                crystalReport.Load(Server.MapPath(strPath));
            }
            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            foreach (DictionaryEntry entry in pHtbParameter)
            {
                crystalReport.SetParameterValue(entry.Key.ToString(), entry.Value.ToString());
            }
            crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }
    }

    protected bool ShowExecl(List<string> pPath, DataSet ds, Hashtable pHtbParameter)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {
            foreach (string strPath in pPath)
            {
                crystalReport.Load(Server.MapPath(strPath));

            }
            //// crystalReport.Load(@"D:\PhieuDeNghi\iOffice\vanphong\Report\crtBaoCaoTuanExcel.rpt");

            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            foreach (DictionaryEntry entry in pHtbParameter)
            {
                crystalReport.SetParameterValue(entry.Key.ToString(), entry.Value.ToString());
            }
            crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "BaoCaoTuan8S" );

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }
    }
       
    protected bool ShowExecl(List<string> pPath, DataSet ds, Hashtable pHtbParameter,string chuoi)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {
            foreach (string strPath in pPath)
            {
                crystalReport.Load(Server.MapPath(strPath));

            }
           //// crystalReport.Load(@"D:\PhieuDeNghi\iOffice\vanphong\Report\crtBaoCaoTuanExcel.rpt");
           
            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            foreach (DictionaryEntry entry in pHtbParameter)
            {
                crystalReport.SetParameterValue(entry.Key.ToString(), entry.Value.ToString());
            }
            crystalReport.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "Report_"+chuoi);
            
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }
    }
       
}