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
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<UserModel> Get()
        {
            return UserData.Get();
        }

        // GET api/<controller>/5
        public UserModel Get(int id)
        {
            return UserData.GetOnly(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]UserModel user)
        {
            return UserData.Save(user);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]UserModel user)
        {
            return UserData.Set(id, user);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return UserData.Drop(id);
        }
    }
}