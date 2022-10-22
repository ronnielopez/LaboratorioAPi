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
    public class ShipmentStatusData
    {
        public static List<ShipmentStatusModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<ShipmentStatusModel> listShipmentStatus = new List<ShipmentStatusModel>();
                SqlCommand cmd = new SqlCommand("PR_get_shipments_status", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listShipmentStatus.Add(new ShipmentStatusModel()
                            {
                                id_shipment_status = Convert.ToInt32(dr["id_shipment_status"]),
                                shipment_status_name = (dr["shipment_status_name"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listShipmentStatus;
                }
                catch (Exception ex)
                {

                    return listShipmentStatus;
                }

            }

        }
    }
}