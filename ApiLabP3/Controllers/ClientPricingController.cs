using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ApiLabP3.Data;
using ApiLabP3.Models;
using System.Web.Http;

namespace ApiLabP3.Controllers
{
    public class ClientPricingController : ApiController
    {
        // GET api/<controller>
        public List<ClientPricingModel> Get()
        {
            return ClientPricingData.Get();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]ClientPricingModel value)
        {
            return ClientPricingData.Save(value);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]ClientPricingModel value)
        {
            return ClientPricingData.Set(id, value);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ClientPricingData.Drop(id);
        }
    }
}