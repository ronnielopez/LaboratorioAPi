using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class UsertTypeModel
    {
        public int id_type { get; set; }
        public string name_type { get; set; }
        public string description { get; set; }
        public int active { get; set; }
    }
}