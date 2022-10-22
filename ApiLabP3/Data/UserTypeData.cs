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
    public class UserTypeData
    {
        public static List<UsertTypeModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<UsertTypeModel> listClient = new List<UsertTypeModel>();
                SqlCommand cmd = new SqlCommand("PR_get_user_type", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listClient.Add(new UsertTypeModel()
                            {
                                id_type = Convert.ToInt32(dr["id_type"]),
                                name_type = (dr["name_type"]).ToString(),
                                description = (dr["description"]).ToString(),
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