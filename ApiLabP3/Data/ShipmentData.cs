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
    public class ShipmentData
    {
        public static bool Save(ShippingModel oShipping)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("PR_create_shipping", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_client", oShipping.id_client);
                cmd.Parameters.AddWithValue("@tracking_number", oShipping.tracking_number);
                cmd.Parameters.AddWithValue("@id_warehouse_dest", oShipping.id_warehouse_dest);
                cmd.Parameters.AddWithValue("@id_branchoffice", oShipping.id_branchoffice);
                cmd.Parameters.AddWithValue("@id_department", oShipping.id_department);
                cmd.Parameters.AddWithValue("@active", oShipping.active);

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

        public static List<ShippingModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<ShippingModel> listShipments = new List<ShippingModel>();
                SqlCommand cmd = new SqlCommand("PR_get_shipments", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                Exception exs = new Exception();
                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listShipments.Add(new ShippingModel()
                            {
                                id_shipment = Convert.ToInt32(dr["id_shipment"]),
                                id_client = Convert.ToInt32(dr["id_client"]),
                                tracking_number = (dr["tracking_number"]).ToString(),
                                id_warehouse_dest = Convert.ToInt32(dr["id_warehouse_dest"]),
                                arrival_warehouse_date = (dr["arrival_warehouse_date"]).ToString(),
                                id_department = Convert.ToInt32(dr["id_department"]),
                                department_name = (dr["department_name"]).ToString(),
                                name_branch = (dr["name_branch"]).ToString(),
                                id_branchoffice = Convert.ToInt32(dr["id_branchoffice"]),
                                arrival_branchoffice = (dr["arrival_branchoffice"]).ToString(),
                                client_send_date = (dr["client_send_date"]).ToString(),
                                prefix = (dr["prefix"]).ToString(),
                                department_prefix = (dr["department_prefix"]).ToString(),
                                failed_attempt = Convert.ToInt32(dr["failed_attempt"]),
                                payment_type = Convert.ToInt32(dr["payment_type"]),
                                client_name = (dr["client_name"]).ToString(),
                                client_type_name = (dr["client_type_name"]).ToString(),
                                package_capacity = Convert.ToInt32(dr["package_capacity"]),
                                shipment_status_name = (dr["shipment_status_name"]).ToString(),
                                warehouse_name_dest = (dr["warehouse_name_dest"]).ToString(),
                                payment_type_n = (dr["payment_type_n"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    Console.Write(exs);
                    return listShipments;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return listShipments;
                }

            }

        }

        public static ShippingModel GetOnly(int id_shipment)
        {
            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                ShippingModel shipData = new ShippingModel();
                SqlCommand cmd = new SqlCommand("PR_get_shipments_only", oConnection);
                cmd.Parameters.AddWithValue("@id_shipment", id_shipment);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            shipData.id_shipment = Convert.ToInt32(dr["id_shipment"]);
                            shipData.id_client = Convert.ToInt32(dr["id_client"]);
                            shipData.tracking_number = (dr["tracking_number"]).ToString();
                            shipData.id_warehouse_dest = Convert.ToInt32(dr["id_warehouse_dest"]);
                            shipData.arrival_warehouse_date = (dr["arrival_warehouse_date"]).ToString();
                            shipData.id_department = Convert.ToInt32(dr["id_department"]);
                            shipData.department_name = (dr["department_name"]).ToString();
                            shipData.name_branch = (dr["name_branch"]).ToString();
                            shipData.id_branchoffice = Convert.ToInt32(dr["id_branchoffice"]);
                            shipData.arrival_branchoffice = (dr["arrival_branchoffice"]).ToString();
                            shipData.client_send_date = (dr["client_send_date"]).ToString();
                            shipData.prefix = (dr["prefix"]).ToString();
                            shipData.department_prefix = (dr["department_prefix"]).ToString();
                            shipData.payment_type = Convert.ToInt32(dr["payment_type"]);
                            shipData.shipment_status = Convert.ToInt32(dr["shipment_status"]);
                            shipData.failed_attempt = Convert.ToInt32(dr["failed_attempt"]);
                            shipData.client_name = (dr["client_name"]).ToString();
                            shipData.client_type_name = (dr["client_type_name"]).ToString();
                            shipData.package_capacity = Convert.ToInt32(dr["package_capacity"]);
                            shipData.shipment_status_name = (dr["shipment_status_name"]).ToString();
                            shipData.warehouse_name_dest = (dr["warehouse_name_dest"]).ToString();
                            shipData.payment_type_n = (dr["payment_type_n"]).ToString();
                            shipData.active = Convert.ToInt32(dr["active"]);

                        }
                    }
                    oConnection.Close();
                    return shipData;
                }
                catch (Exception ex)
                {

                    return shipData;
                }

            }
        }

        public static bool Set(int id, ShippingModel oShipping)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {

                SqlCommand cmd = new SqlCommand("PR_set_shipment", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_shipment", id);
                cmd.Parameters.AddWithValue("@id_client", oShipping.id_client);
                cmd.Parameters.AddWithValue("@shipment_status", oShipping.shipment_status);
                cmd.Parameters.AddWithValue("@id_warehouse_dest", oShipping.id_warehouse_dest);
                cmd.Parameters.AddWithValue("@id_branchoffice", oShipping.id_branchoffice);
                cmd.Parameters.AddWithValue("@arrival_branchoffice", oShipping.arrival_branchoffice);
                cmd.Parameters.AddWithValue("@arrival_warehouse_dest", oShipping.arrival_warehouse_date);
                cmd.Parameters.AddWithValue("@id_department", oShipping.id_department);
                cmd.Parameters.AddWithValue("@client_send_date", oShipping.client_send_date);
                cmd.Parameters.AddWithValue("@payment_type", oShipping.payment_type);
                cmd.Parameters.AddWithValue("@failed_attempt", 0);
                cmd.Parameters.AddWithValue("@active", oShipping.active);

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    Exception exc = new Exception();
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

                SqlCommand cmd = new SqlCommand("PR_drop_shipment", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_shipment", id);

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