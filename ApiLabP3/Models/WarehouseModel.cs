using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class WarehouseModel
    {
        public int id_warehouse { get; set; }
        public string name_warehouse { get; set; }
        public int ware_type { get; set; }
        public int department { get; set; }
        public string warehouse_address { get; set; }
        public int active { get; set; }
        public string ware_type_n { get; set; }
        public string department_name { get; set; }
        public string prefix { get; set; }

    }
}