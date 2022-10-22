using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLabP3.Data;
using ApiLabP3.Models;

namespace ApiLabP3.Controllers
{
    public class ShipmentController : ApiController
    {
        // GET: api/Shipment
        public List<ShippingModel> Get()
        {
            return ShipmentData.Get();
        }

        // GET: api/Shipment/5
        public ShippingModel Get(int id)
        {
            return ShipmentData.GetOnly(id);
        }

        // POST: api/Shipment
        public bool Post([FromBody]ShippingModel value)
        {
            return ShipmentData.Save(value);
        }

        // PUT: api/Shipment/5
        public bool Put(int id, [FromBody]ShippingModel value)
        {
            return ShipmentData.Set(id, value);
        }

        // DELETE: api/Shipment/5
        public bool Delete(int id)
        {
            return ShipmentData.Drop(id);
        }
    }
}
