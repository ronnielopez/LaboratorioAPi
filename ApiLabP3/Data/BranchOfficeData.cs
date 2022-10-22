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
    public class BranchOfficeData
    {
        public static bool Save(BranchOfficeModel oBranch)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("PR_create_branch_office", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name_branch", oBranch.name_branch);
                cmd.Parameters.AddWithValue("@id_warehouse", oBranch.name_branch);


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

        public static List<BranchOfficeModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<BranchOfficeModel> listBranch = new List<BranchOfficeModel>();
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
                            listBranch.Add(new BranchOfficeModel()
                            {
                                id_branch = Convert.ToInt32(dr["id_branch"]),
                                name_branch = (dr["name_branch"]).ToString(),
                                id_warehouse = Convert.ToInt32(dr["id_warehouse"]),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listBranch;
                }
                catch (Exception ex)
                {

                    return listBranch;
                }

            }

        }

        public static BranchOfficeModel GetOnly(int id_branch) {
            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                BranchOfficeModel branch = new BranchOfficeModel();
                SqlCommand cmd = new SqlCommand("PR_get_branch_office_only", oConnection);
                cmd.Parameters.AddWithValue("@id_branch", id_branch);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            branch.id_branch = Convert.ToInt32(dr["id_branch"]);
                            branch.name_branch = (dr["name_branch"]).ToString();
                            branch.id_warehouse = Convert.ToInt32(dr["id_warehouse"]);
                            branch.active = Convert.ToInt32(dr["active"]);
                            
                        }
                    }
                    oConnection.Close();
                    return branch;
                }
                catch (Exception ex)
                {

                    return branch;
                }

            }
        }

        public static bool Set(int id, BranchOfficeModel oBranch)
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {

                SqlCommand cmd = new SqlCommand("PR_set_branch_office", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_branch", id);
                cmd.Parameters.AddWithValue("@name_branch", oBranch.name_branch);
                cmd.Parameters.AddWithValue("@id_warehouse", oBranch.name_branch);
                cmd.Parameters.AddWithValue("@active", oBranch.active);

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

                SqlCommand cmd = new SqlCommand("PR_drop_branch_office", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_branch", id);

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