using Proyecto_2.Capas.Entidad.Student_Course;
using Proyecto_2.Capas.Entidad.Teacher_Course;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso_Profesor
{
    public class AC_UpdateTeacher_Course
    {
        public List<EN_ListadoCurso_Profesores> ObtenerListadoCurso_Profesores()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListTeacherCourse";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoCurso_Profesores> records = new List<EN_ListadoCurso_Profesores>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoCurso_Profesores(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoCurso_Profesores> ObtenerCursoProfesoresEspecifica(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListTeacherCourse_Id @SId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@Id", id);

            List<EN_ListadoCurso_Profesores> records = new List<EN_ListadoCurso_Profesores>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    records.Add(new EN_ListadoCurso_Profesores(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public string Update_TeacherCourse(string teacherId, string courseId)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARTEACHERCOURSE @TeacherId, @CourseId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@TeacherId", teacherId);
            cmd.Parameters.AddWithValue("@CourseId", courseId);

            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}