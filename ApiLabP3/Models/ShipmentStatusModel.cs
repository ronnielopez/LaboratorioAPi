using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class ShipmentStatusModel
    {
        public int id_shipment_status { get; set; }
        public string shipment_status_name { get; set; }
        public int active { get; set; }
    }
}