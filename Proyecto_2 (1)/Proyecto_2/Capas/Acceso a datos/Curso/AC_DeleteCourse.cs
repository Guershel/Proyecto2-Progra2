using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso
{
    public class AC_DeleteCourse
    {
        public void Delete_Course(int id)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_BORRARCOURSE @CourseId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@CourseId", id);


            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}