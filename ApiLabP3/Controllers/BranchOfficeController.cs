using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLabP3.Models;
using ApiLabP3.Data;

namespace ApiLabP3.Controllers
{
    public class BranchOfficeController : ApiController
    {
        // GET api/<controller>
        public List<BranchOfficeModel> Get()
        {
            return BranchOfficeData.Get();
        }

        // GET api/<controller>/5
        public BranchOfficeModel Get(int id)
        {
            return BranchOfficeData.GetOnly(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]BranchOfficeModel value)
        {
            return BranchOfficeData.Save(value);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]BranchOfficeModel value)
        {
            return BranchOfficeData.Set(id, value);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return BranchOfficeData.Drop(id);
        }
    }
}