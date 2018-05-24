using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BLL_Base
/// </summary>
public class BLL_ERP_Base : BLL_Base
{
    public BLL_ERP_Base()
    {
        _dalBase = new DAL_ERP_GenericDataAccess();
    }
}