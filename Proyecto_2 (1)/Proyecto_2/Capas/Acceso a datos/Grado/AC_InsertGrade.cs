using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Grado
{
    public class AC_InsertGrade
    {
        public string Insert_Grade(int StudentId, int CourseId, float Grade, string Comment)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_AGREGARGRADE @StudentId, @CourseId, @Grade, @Comment";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.Parameters.AddWithValue("@CourseId", CourseId);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Comment", Comment);


            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}