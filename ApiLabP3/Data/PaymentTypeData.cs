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
    public class PaymentTypeData
    {
        public static List<PaymentTypeModel> Get()
        {

            using (SqlConnection oConnection = new SqlConnection(Connection.rutaConexion))
            {
                List<PaymentTypeModel> listPaymentType = new List<PaymentTypeModel>();
                SqlCommand cmd = new SqlCommand("PR_get_payment_type", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listPaymentType.Add(new PaymentTypeModel()
                            {
                                id_pay = Convert.ToInt32(dr["id_pay"]),
                                name_pay = (dr["name_pay"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listPaymentType;
                }
                catch (Exception ex)
                {

                    return listPaymentType;
                }

            }

        }
    }
}