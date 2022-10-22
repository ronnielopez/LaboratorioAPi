using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class PaymentTypeModel
    {
        public int id_pay { get; set; }
        public string name_pay { get; set; }
        public int active { get; set; }
    }
}