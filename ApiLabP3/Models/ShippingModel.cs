using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class ShippingModel
    {
        public int? id_shipment { get; set; }
        public int? id_client { get; set; }
        public string client_name { get; set; }
        public string client_type_name { get; set; }
        public int? package_capacity { get; set; }
        public int? shipment_status { get; set; }
        public string shipment_status_name { get; set; }
        public string tracking_number { get; set; }
        public int? id_warehouse_dest { get; set; }
        public string warehouse_name_dest { get; set; }
        public string arrival_warehouse_date { get; set; }
        public int? id_branchoffice { get; set; }
        public string department_prefix { get; set; }
        public string arrival_branchoffice { get; set; }
        public string name_branch { get; set; }
        public string client_send_date { get; set; }
        public int? id_department { get; set; }
        public string department_name { get; set; }
        public string prefix { get; set; }
        public int? payment_type { get; set; }
        public string payment_type_n { get; set; }
        public int? failed_attempt { get; set; }
        public int active { get; set; }
    }
}
