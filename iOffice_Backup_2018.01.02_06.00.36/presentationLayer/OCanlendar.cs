using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iOffice.presentationLayer
{
    class OCanlendar
    {
        public OCanlendar()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int ID { get; set; }
        public string GSBH { get; set; }
        public string UserID { get; set; }
        public DateTime? pdates { get; set; }
        public DateTime? pdatee { get; set; }
        public DateTime? modidate { get; set; }
        public string wkmemo { get; set; }
        public string wklink { get; set; }
        public decimal jobpercent { get; set; }
        public DateTime? cfmdate { get; set; }
        public string cfmuser { get; set; }
        public string Subject { get; set; }
        public string Yn { get; set; }

    }
}
