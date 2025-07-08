using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdr.Models
{
    internal class Urun
    {
        
            public int UrunID { get; set; }
            public string UrunAdi { get; set; }
            public int UrunAdedi { get; set; }
            public string UrunOzelligi { get; set; }
            public decimal UrunAlisFiyati { get; set; }
            public decimal UrunSatisFiyati { get; set; }
            public DateTime EklenmeTarihi { get; set; }
            public int? EkleyenPersonelID { get; set; }
        

    }
}
