using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ETT_PCM_Base
/// </summary>
public class ETT_ERP_Base : ETT_Base
{
    public ETT_ERP_Base()
    {
        _dal = new DAL_ERP_GenericDataAccess();
    }
}