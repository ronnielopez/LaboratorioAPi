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
    public class WarehouseData
    {
        public static List<WarehouseModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<WarehouseModel> listWarehouse = new List<WarehouseModel>();
                SqlCommand cmd = new SqlCommand("PR_get_warehouse", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listWarehouse.Add(new WarehouseModel()
                            {
                                id_warehouse = Convert.ToInt32(dr["id_warehouse"]),
                                name_warehouse = (dr["name_warehouse"]).ToString(),
                                ware_type = Convert.ToInt32(dr["ware_type"]),
                                ware_type_n = (dr["ware_type_n"]).ToString(),
                                department = Convert.ToInt32(dr["department"]),
                                department_name = (dr["department_name"]).ToString(),
                                warehouse_address = (dr["warehouse_address"]).ToString(),
                                prefix = (dr["prefix"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listWarehouse;
                }
                catch (Exception ex)
                {

                    return listWarehouse;
                }

            }

        }
    }
}