using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.School
{
    public class AC_InsertSchool
    {
        public string Insert_School(string schoolName, string description, string address, string phone, string postCode, string postAddress)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_InsertSchool @SchoolName, @Description, @Address , @Phone, @PostCode, @PostAddress";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@SchoolName", schoolName);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@PostCode", postCode);
            cmd.Parameters.AddWithValue("@PostAddress", postAddress);

            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}