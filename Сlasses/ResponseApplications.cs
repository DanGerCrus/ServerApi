using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponseApplications
    {
        public ResponseApplications(Applications applications)
        {
            id_applications = applications.id_application;
            id_abonent = applications.id_abonent;
            id_name_service = applications.id_name_service;
            data_create = applications.date_create;
            status = applications.status;
            type_problem = applications.type_problem;
            opisanie = applications.opisanie;
            date_end = applications.date_end;
            id_staff = applications.id_staff;
            
        }
        public Nullable<int> id_applications { get; set; }
        public Nullable<int> id_abonent { get; set; }
        public Nullable<int> id_name_service { get; set; }
        public DateTime data_create { get; set; }
        public string status { get; set; }
        public string type_problem { get; set; }
        public string opisanie { get; set; }
        public DateTime? date_end { get; set; }
        public Nullable<int> id_staff { get; set; }
        public string Abonents { get; set; }
        
        

    }
}
