using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ServerApi.Сlasses
{
    public class ResponseContracts
    {
        public ResponseContracts(Contracts contracts) {
            id_contract = contracts.id_cotract;           
            date_start = contracts.date_start;           
            date_end = contracts.date_end;
            reason_end = contracts.reason_end;
            Id_abonents = contracts.id_abonent;

        }
        public int id_contract { get; set; }
        public DateTime date_start { get; set; }        
        public DateTime? date_end { get; set; }
        public string reason_end { get; set; }
        public Nullable<int> Id_abonents { get; set; }        
    }
}