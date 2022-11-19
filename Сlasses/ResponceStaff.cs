using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponceStaff
    {
        public ResponceStaff(Staff staff) 
        {

            id_staff = staff.id_staff;            
            Name = staff.Name;
            MiddleName = staff.MIddleName;
            LastName = staff.LastName;
            password = staff.password;
            Id_role = staff.id_role;
            photo = staff.photo;
            otpusk=staff.otpusk;
            email= staff.email;

        }
        public int id_staff { get; set; }        
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }
        public Nullable<int> Id_role { get; set; }
        public byte[] photo { get; set; }
        public bool? otpusk { get; set; }
        public string email { get; set; }
    }
}