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
    public class DepartmentData
    {
        public static List<DepartmentModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<DepartmentModel> listDepartment = new List<DepartmentModel>();
                SqlCommand cmd = new SqlCommand("PR_get_departments", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listDepartment.Add(new DepartmentModel()
                            {
                                id_department = Convert.ToInt32(dr["id_department"]),
                                department_name = (dr["department_name"]).ToString(),
                                prefix = (dr["prefix"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listDepartment;
                }
                catch (Exception ex)
                {

                    return listDepartment;
                }

            }

        }
    }
}