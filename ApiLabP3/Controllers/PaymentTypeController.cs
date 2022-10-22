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
    public class PaymentTypeController : ApiController
    {
        // GET: api/PaymentType
        public List<PaymentTypeModel> Get()
        {
            return PaymentTypeData.Get();
        }

        // GET: api/PaymentType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PaymentType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PaymentType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PaymentType/5
        public void Delete(int id)
        {
        }
    }
}
