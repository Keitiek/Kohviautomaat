using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KohviAutomaat.Models
{
    public class kohvimasin
    {
        public int Id { get; set; }
        public string Jooginimi { get; set; }
        public int Täitepakis { get; set; }
        public int Topsejuua { get; set; }
    }
}