using Proyecto_2.Capas.Entidad.Class;
using Proyecto_2.Capas.Entidad.Course;
using Proyecto_2.Capas.Entidad.School;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso
{
    public class AC_UpdateCourse
    {
        public List<EN_ListadoCursos> ObtenerListadCursos()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListCourse_Id";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoCursos> records = new List<EN_ListadoCursos>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoCursos(reader));

                }
            }
            Conexion.Close();
            return records;
        }


        public List<EN_ListadoCursos> ObtenerCursoEspecifica(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListCourse_Id @CourseId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@CourseId", id);

            List<EN_ListadoCursos> records = new List<EN_ListadoCursos>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    records.Add(new EN_ListadoCursos(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public void Update_Course(int Id, string courseName, int schoolId, string description)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARCOURSE @CourseId,@CourseName, @SchoolId, @Description";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@CourseId", Id);
            cmd.Parameters.AddWithValue("@CourseName", courseName);
            cmd.Parameters.AddWithValue("@SchoolId", schoolId);
            cmd.Parameters.AddWithValue("@Description", description);

            cmd.ExecuteNonQuery();
            conexion.Close();
            
        }

        public List<EN_ListadoCursos> ObtenerCursosXEstudiante(string cedula)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ObtenerCursosActuales @StudentId";

            Conexion.Open(); 
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@StudentId", cedula);

            List<EN_ListadoCursos> records = new List<EN_ListadoCursos>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    records.Add(new EN_ListadoCursos(reader));

                }
            }
            Conexion.Close();
            return records;
        }
    }
}