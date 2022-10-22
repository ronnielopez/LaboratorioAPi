using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class DepartmentModel
    {
        public int id_department { get; set; }
        public string department_name { get; set; }
        public string prefix { get; set; }
        public int active { get; set; }
    }
}