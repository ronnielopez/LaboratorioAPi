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
    public class ShipmentStatusController : ApiController
    {
        // GET: api/ShipmentStatus
        public List<ShipmentStatusModel> Get()
        {
            return ShipmentStatusData.Get();
        }

        // GET: api/ShipmentStatus/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShipmentStatus
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShipmentStatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShipmentStatus/5
        public void Delete(int id)
        {
        }
    }
}
