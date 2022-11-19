using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponceServices
    {
        public ResponceServices(Services services)
        {
            id_service=services.id_service;
            id_abonent=services.id_abonent;
            id_name_service=services.id_name_service;
        }
        public Nullable<int> id_service { get; set; }
        public Nullable<int> id_abonent { get; set; }
        public Nullable<int> id_name_service { get; set; }
    }
}
