using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso
{
    public class AC_InsertCourse
    {
        public string Insert_Course(int SchoolId,string CourseName,  string Description)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_AGREGARCOURSE @SchoolId , @CourseName, @Description";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@SchoolId", SchoolId);
            cmd.Parameters.AddWithValue("@CourseName", CourseName);     
            cmd.Parameters.AddWithValue("@Description", Description);


            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}