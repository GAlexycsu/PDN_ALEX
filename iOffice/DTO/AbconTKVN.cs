using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iOffice.DTO
{
    public class AbconTKVN:Abcon
    {
        //pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle
       // ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0
        public string Abtype { get; set; }
        public string abname { get; set; }
       
        public string mytitle { get; set; }
      
        public string NameABC { get; set; }
       
        public string DepName { get; set; }
      
        public string YnName { get; set; }
        public DateTime? CFMDate0 { get;set; }
        public string USERNAME { get; set; }
    }
}