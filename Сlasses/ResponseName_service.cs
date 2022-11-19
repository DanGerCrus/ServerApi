using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponseName_service
    {
        public ResponseName_service(name_service name_Service) 
        {
            id_name_service = name_Service.id_name_service;
            name_service1 = name_Service.id_name_service;
        }
        public int id_name_service { get; set; }
        public int name_service1 { get; set; }
    }
}