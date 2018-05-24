using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAL_ERPTW_GenericDataAccess
/// </summary>
public class DAL_ERPTW_GenericDataAccess : DAL_Base
{
	public DAL_ERPTW_GenericDataAccess()
	{
        _strConnectionName = "ERP1";
        cmd = new ETT_ERP_SqlCommand();
	}
}