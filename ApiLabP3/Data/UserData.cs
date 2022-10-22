using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiLabP3.Models;
using ApiLabP3.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace ApiLabP3.Data
{
    public class UserData
    {
        public static bool Save(UserModel oUser) {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion)) {

                SqlCommand cmd = new SqlCommand("PR_create_user", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@names", oUser.names);
                cmd.Parameters.AddWithValue("@email", oUser.email);
                cmd.Parameters.AddWithValue("@pwd", oUser.pwd);
                cmd.Parameters.AddWithValue("@type_user", oUser.type_user);


                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    return true;
                }
                catch (Exception ex) {

                    return false;
                }

            }

        }

        public static List<UserModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<UserModel> listUsers = new List<UserModel>();
                SqlCommand cmd = new SqlCommand("PR_get_users", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader()) {

                        while (dr.Read()) {
                            listUsers.Add(new UserModel() {
                                id_user = Convert.ToInt32(dr["id_user"]),
                                names = (dr["names"]).ToString(),
                                email = (dr["email"]).ToString(),
                                type_user = Convert.ToInt32(dr["type_user"]),
                                name_type_user = (dr["name_type_user"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                        oConnection.Close();
                    return listUsers;
                }
                catch (Exception ex)
                {

                    return listUsers;
                }

            }

        }

        public static UserModel GetOnly(int id)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                UserModel listUsers = new UserModel();
                SqlCommand cmd = new SqlCommand("PR_get_users_only", oConnection);
                cmd.Parameters.AddWithValue("@id_user", id);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            listUsers.id_user = Convert.ToInt32(dr["id_user"]);
                            listUsers.names = (dr["names"]).ToString();
                            listUsers.email = (dr["email"]).ToString();
                            listUsers.type_user = Convert.ToInt32(dr["type_user"]);
                            listUsers.name_type_user = (dr["name_type_user"]).ToString();
                            listUsers.active = Convert.ToInt32(dr["active"]);
                        }
                    }
                    oConnection.Close();
                    return listUsers;
                }
                catch (Exception ex)
                {

                    return listUsers;
                }

            }

        }

        public static bool Set(int id, UserModel oUser)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {

                SqlCommand cmd = new SqlCommand("PR_set_user", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_user", id);
                cmd.Parameters.AddWithValue("@names", oUser.names);
                cmd.Parameters.AddWithValue("@email", oUser.email);
                cmd.Parameters.AddWithValue("@type_user", oUser.type_user);
                cmd.Parameters.AddWithValue("@active", oUser.active);


                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }

        }

        public static bool Drop(int id)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {

                SqlCommand cmd = new SqlCommand("PR_drop_user", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_user", id);

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }
    }
}