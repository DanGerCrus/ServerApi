//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Abonents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Abonents()
        {
            this.Abonents_equipment = new HashSet<Abonents_equipment>();
            this.Applications = new HashSet<Applications>();
            this.Contracts = new HashSet<Contracts>();
            this.Services = new HashSet<Services>();
        }
    
        public int id_abonent { get; set; }
        public string personal_schet { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string passport_data { get; set; }
        public string adress { get; set; }
        public string number_phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonents_equipment> Abonents_equipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contracts> Contracts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }
    }
}