using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApi.Сlasses
{
    public class ResponseAbonents
    {
        public ResponseAbonents(Abonents abonents)
            {
            id_abonent = abonents.id_abonent;
            personal_schet = abonents.personal_schet;
            Name = abonents.Name;
            MiddleName = abonents.MiddleName;
            LastName = abonents.LastName;
            passport_data = abonents.passport_data;
            adress = abonents.adress;
            number_phone = abonents.number_phone;
        }
        public int id_abonent { get; set; }
        public string personal_schet { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string passport_data { get; set; }
        public string adress { get; set; }
        public string number_phone { get; set; }
        

    }
}