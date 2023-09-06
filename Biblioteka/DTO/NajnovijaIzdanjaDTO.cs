using Biblioteka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.DTO
{
    public class NajnovijaIzdanjaDTO
    {
        public int IzdanjeID { get; set; }
        public int Godina { get; set; }
        public string IzdavackaKuca { get; set; }
        public string SlikaKorica { get; set; }
        public string Knjiga { get; set; }

      
    }
}