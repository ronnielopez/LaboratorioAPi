using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class BranchOfficeModel
    {
        public int id_branch { get; set; }
        public string name_branch { get; set; }
        public int id_warehouse { get; set; }
        public int active { get; set; }
    }
}