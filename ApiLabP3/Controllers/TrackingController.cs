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
    public class TrackingController : ApiController
    {
        // GET: api/Tracking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tracking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tracking
        public ShippingModel Post([FromBody]string tracking_number)
        {
                using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
                {
                    ShippingModel shipData = new ShippingModel();
                    SqlCommand cmd = new SqlCommand("PR_get_tracking_shipment", oConnection);
                    cmd.Parameters.AddWithValue("@tracking_number", tracking_number);
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

        // PUT: api/Tracking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tracking/5
        public void Delete(int id)
        {
        }
    }
}
