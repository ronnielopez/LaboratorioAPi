using ApiLabP3.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ApiLabP3.Models;

namespace ApiLabP3.Data
{
    public class ClientPricingData
    {
        public static bool Save(ClientPricingModel oClientPricing)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("PR_create_client_pricing", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@client_type", oClientPricing.client_type);
                cmd.Parameters.AddWithValue("@transport_type", oClientPricing.transport_type);
                cmd.Parameters.AddWithValue("@zone_type", oClientPricing.zone_type);
                cmd.Parameters.AddWithValue("@price", oClientPricing.price);

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

        public static List<ClientPricingModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<ClientPricingModel> listClientPricing= new List<ClientPricingModel>();
                SqlCommand cmd = new SqlCommand("PR_get_branch_office", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listClientPricing.Add(new ClientPricingModel()
                            {
                                id_client_pricing = Convert.ToInt32(dr["id_client_pricing"]),
                                client_type = Convert.ToInt32(dr["client_type"]),
                                transport_type = Convert.ToInt32(dr["transport_type"]),
                                zone_type = Convert.ToInt32(dr["zone_type"]),
                                price = Convert.ToDouble(dr["price"]),
                                name_type = (dr["name_type"]).ToString(),
                                package_capacity = Convert.ToInt32(dr["package_capacity"]),
                                transport_name = (dr["transport_name"]).ToString(),
                                zone_name = (dr["zone_name"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listClientPricing;
                }
                catch (Exception ex)
                {

                    return listClientPricing;
                }

            }

        }

        public static bool Set(int id, ClientPricingModel oClientPricing)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {

                SqlCommand cmd = new SqlCommand("PR_set_client_pricing", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_client_pricing", id);
                cmd.Parameters.AddWithValue("@client_type", oClientPricing.client_type);
                cmd.Parameters.AddWithValue("@transport_type", oClientPricing.transport_type);
                cmd.Parameters.AddWithValue("@zone_type", oClientPricing.zone_type);
                cmd.Parameters.AddWithValue("@price", oClientPricing.price);
                cmd.Parameters.AddWithValue("@active", oClientPricing.active);

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

                SqlCommand cmd = new SqlCommand("PR_drop_client_pricing", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_client_pricing", id);

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