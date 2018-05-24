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
/// Summary description for ViewReport
/// </summary>
public class ViewReport : System.Web.UI.Page
{
    CommonFunction _cmf = new CommonFunction();
	public ViewReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected bool ShowExcel(List<string> pPath, DataSet ds)
    {
        ReportDocument report = new ReportDocument();
        try
        {
            foreach (string path in pPath)
            {
                report.Load(Server.MapPath(path));
            }
            if (ds.Tables.Count != 0)
            {
                report.SetDataSource(ds);
            }
            report.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "");
            return true;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            report.Close();
            report.Dispose();
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
            if (ds.Tables.Count != 0)
            {
                crystalReport.SetDataSource(ds);
            }
            foreach (DictionaryEntry entry in pHtbParameter)
            {
                crystalReport.SetParameterValue(entry.Key.ToString(), entry.Value.ToString());
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
    public void Show(string pPath, Hashtable pHtbReportDataSet)
    {
        try
        {
            ReportDocument crystalReport = new ReportDocument();
            //Check Path
            if (String.IsNullOrEmpty(pPath))
            {
                Response.Write("No Path!");
            }
            else
            {
                //Map path
                crystalReport.Load(Server.MapPath(pPath));
            }
            foreach (DictionaryEntry entry in pHtbReportDataSet)
            {
                try
                {
                    DataSet ds = (DataSet)entry.Value;
                    //Check DataSet
                    if (_cmf.IsNullOrEmpty(ds))
                    {
                        Response.Write("Null Data!");
                    }
                    else
                    {
                        if (ds.Tables.Count != 0)
                        {
                            //Set DataSet
                            if (entry.Key.ToString().ToLower().Equals("main"))
                            {
                                //Set DataSet for main report
                                crystalReport.SetDataSource(ds);
                            }
                            else
                            {
                                //Set DataSet for Subreport
                                crystalReport.Subreports[entry.Key.ToString()].SetDataSource(ds);
                            }
                        }
                        else
                        {
                            Response.Write("No Data!");
                        }
                    }
                }
                catch
                {
                    Response.Write("Null Data!");
                }
            }
            try
            {
                //Show report
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            }
            catch
            {
                //Error 
                Response.Write("Export Error");
            }
            finally
            {
                //Close Report
                crystalReport.Close();
                crystalReport.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Show(string pPath, Hashtable pHtbReportDataSet, Hashtable pHtbParameter)
    {
        try
        {
            ReportDocument crystalReport = new ReportDocument();
            //Check Path
            if (String.IsNullOrEmpty(pPath))
            {
                Response.Write("No Path!");
            }
            else
            {
                //Map path
                crystalReport.Load(Server.MapPath(pPath));
            }
            foreach (DictionaryEntry entry in pHtbReportDataSet)
            {
                try
                {
                    DataSet ds = (DataSet)entry.Value;
                    //Check DataSet
                    if (_cmf.IsNullOrEmpty(ds))
                    {
                        Response.Write("Null Data!");
                    }
                    else
                    {
                        if (ds.Tables.Count != 0)
                        {
                            //Set DataSet
                            if (entry.Key.ToString().ToLower().Equals("main"))
                            {
                                //Set DataSet for main report
                                crystalReport.SetDataSource(ds);
                            }
                            else
                            {
                                //Set DataSet for Subreport
                                crystalReport.Subreports[entry.Key.ToString()].SetDataSource(ds);
                            }
                        }
                        else
                        {
                            Response.Write("No Data!");
                        }
                    }
                }
                catch
                {
                    Response.Write("Null Data!");
                }
            }
            //Add parameter
            foreach (DictionaryEntry entry in pHtbParameter)
            {
                crystalReport.SetParameterValue(entry.Key.ToString(), entry.Value.ToString());
            }
            try
            {
                //Show report
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            }
            catch
            {
                //Error 
                Response.Write("Export Error");
            }
            finally
            {
                //Close Report
                crystalReport.Close();
                crystalReport.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool Show(List<string> pPath, DataSet ds, Hashtable pHtbParameter)
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
            //crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");

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
    protected bool Show(List<string> pPath, DataSet ds)
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
}