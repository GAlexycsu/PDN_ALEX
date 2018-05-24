using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for BLL_Ddzl
/// </summary>
public class BLL_Ddzl
{
    DAL_Ddzl _DAL = new DAL_Ddzl();
    public BLL_Ddzl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable Querys1(string pDBase, string pTableID, string pColumnID)
    {
        try
        {
            return _DAL.Querys1(pDBase, pTableID, pColumnID);

        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public int delete(int pID)
    {
        try
        {
            return _DAL.delete(pID);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public int Insert(int pID)
    {
        try
        {
            return _DAL.Insert( pID);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    //public int BUpdate(string pDBase, string pTableID, string pColumnID, string pDT
    //    , string pDE, string pVN, string pEN, string pCH, string pDS, string pSM, string pM1)
    //{
    //    try
    //    {
    //        return _DAL.BUpdate(pDBase, pTableID, pColumnID, pDT, pDE, pVN, pEN, pCH, pDS, pSM, pM1);
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    public int Update(int pID, string pFID, string pFNA, string pVN, string pEN, string pCH, string pUI
    , DateTime pUD, string pST, string pSM, string pDB, string pUs, string pFN)
    {
        try
        {
            return _DAL.Update(pID, pFID, pFNA, pVN, pEN, pCH, pUI
    ,  pUD, pST,  pSM,  pDB, pUs, pFN);
        }
        catch (Exception)
        {

            throw;
        }
    }


}