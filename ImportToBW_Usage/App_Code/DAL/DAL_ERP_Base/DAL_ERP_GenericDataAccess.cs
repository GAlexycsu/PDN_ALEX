using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DAL_HRM_GenericDataAccess
/// </summary>
public class DAL_ERP_GenericDataAccess : DAL_Base
{
    public DAL_ERP_GenericDataAccess()
    {
        _strConnectionName = "ERP";
        cmd = new ETT_ERP_SqlCommand();
    }
}