using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class ClientPricingModel
    {
        public int id_client_pricing { get; set; }
        public int client_type { get; set; }
        public int transport_type { get; set; }
        public int zone_type { get; set; }
        public double price { get; set; }
        public int active { get; set; }
        public string name_type { get; set; }
        public int package_capacity { get; set; }
        public string transport_name { get; set; }
        public string zone_name { get; set; }
    }
}