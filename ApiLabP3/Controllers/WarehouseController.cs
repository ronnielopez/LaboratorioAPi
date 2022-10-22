using ApiLabP3.Data;
using ApiLabP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLabP3.Controllers
{
    public class WarehouseController : ApiController
    {
        // GET: api/Warehouse
        public List<WarehouseModel> Get()
        {
            return WarehouseData.Get();
        }

        // GET: api/Warehouse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Warehouse
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Warehouse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Warehouse/5
        public void Delete(int id)
        {
        }
    }
}
