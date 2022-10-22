using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLabP3.Models
{
    public class UserModel
    {
        public int id_user { get; set; }
        public string names { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public int type_user { get; set; }
        public string name_type_user { get; set; }
        public int active { get; set; }
    }
}