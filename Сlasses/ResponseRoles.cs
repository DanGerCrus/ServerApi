using ServerApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponseRoles
    {
        public ResponseRoles(Roles roles) 
        {
            id_role = roles.id_role;
            name_role = roles.name_role;            
        }
        public int id_role { get; set;}
        public string name_role { get; set;}
             
    }
}