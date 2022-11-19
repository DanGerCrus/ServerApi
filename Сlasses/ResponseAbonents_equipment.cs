using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ServerApi.Сlasses
{
    public class ResponseAbonents_equipment
    {
        public ResponseAbonents_equipment(Abonents_equipment Abonents_equipment)
        {
            id_equipment = Abonents_equipment.id_equipment;
            name = Abonents_equipment.name;
            count_portov = Abonents_equipment.count_portov;
            standart_transmission = Abonents_equipment.standart_transmission;
            speed_transmission = Abonents_equipment.speed_transmission;
            id_abonent = Abonents_equipment.id_abonent;            
        }
        public int id_equipment { get; set; }
        public string name { get; set; }
        public int count_portov { get; set; }
        public string standart_transmission { get; set; }
        public double speed_transmission { get; set; }
        public Nullable<int> id_abonent { get; set; }
    }
    
}