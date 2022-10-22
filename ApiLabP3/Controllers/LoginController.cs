using ApiLabP3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLabP3.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public UserModel Post([FromBody]UserModel oUser)
        {
            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                UserModel userReturn = new UserModel();
                SqlCommand cmd = new SqlCommand("PR_login_user", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", oUser.email);
                cmd.Parameters.AddWithValue("@pwd", oUser.pwd);
                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            userReturn.id_user = Convert.ToInt32(dr["id_user"]);
                            userReturn.names = (dr["names"]).ToString();
                            userReturn.email = (dr["email"]).ToString();
                            userReturn.type_user = Convert.ToInt32(dr["type_user"]);
                            userReturn.name_type_user = (dr["name_type_user"]).ToString();
                            userReturn.active = Convert.ToInt32(dr["active"]);
                        }
                        oConnection.Close();
                        return userReturn;
                    }
                }
                catch (Exception ex)
                {

                    return userReturn;
                }

            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}