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
    public class UserTypeController : ApiController
    {
        // GET: api/UserType
        public List<UsertTypeModel> Get()
        {
            return UserTypeData.Get();
        }

        // GET: api/UserType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserType/5
        public void Delete(int id)
        {
        }
    }
}
