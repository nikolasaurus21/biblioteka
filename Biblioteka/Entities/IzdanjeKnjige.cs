//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteka.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class IzdanjeKnjige
    {
        public int IzdanjeID { get; set; }
        public int Godina { get; set; }
        public int IzdavackaKucaID { get; set; }
        public string SlikaKorica { get; set; }
        public int KnjigaID { get; set; }
    
        public virtual IzdavackaKuca IzdavackaKuca { get; set; }
        public virtual Knjige Knjige { get; set; }
    }
}
