using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso_Estudiante
{
    public class AC_DeleteStudent_Course
    {
        public void Delete_StudentCourse(int id)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_BORRARSTUDENTCOURSE @StudentId, @CourseId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@CourseId", id);


            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}