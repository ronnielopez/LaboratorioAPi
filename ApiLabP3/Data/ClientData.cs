using ApiLabP3.Controllers;
using ApiLabP3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiLabP3.Data
{
    public class ClientData
    {
        public static List<ClientModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<ClientModel> listClient = new List<ClientModel>();
                SqlCommand cmd = new SqlCommand("PR_get_clients", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listClient.Add(new ClientModel()
                            {
                                id_client = Convert.ToInt32(dr["id_client"]),
                                id_user = Convert.ToInt32(dr["id_user"]),
                                client_type = Convert.ToInt32(dr["client_type"]),
                                names = (dr["names"]).ToString(),
                                email = (dr["email"]).ToString(),
                                name_type = (dr["names"]).ToString(),
                                package_capacity = Convert.ToInt32(dr["package_capacity"]),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listClient;
                }
                catch (Exception ex)
                {

                    return listClient;
                }

            }

        }
    }
}