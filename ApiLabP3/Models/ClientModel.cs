using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class ClientModel
    {
        public int id_client { get; set; }
        public int id_user { get; set; }
        public int client_type { get; set; }
        public int active { get; set; }
        public string names { get; set; }
        public string email { get; set; }
        public string name_type { get; set; }
        public int package_capacity { get; set; }

    }
}