using Proyecto_2.Capas.Entidad.Course;
using Proyecto_2.Capas.Entidad.Student_Course;
using Proyecto_2.Capas.Entidad.Teacher;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Curso_Estudiante
{
    public class AC_UpdateStudent_Course
    {
        public List<EN_ListadoCurso_Estudiantes> ObtenerListadoEstuCour()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_MODIFICARSTUDENTCOURSE @StudentId, @CourseId";// no se que correr

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoCurso_Estudiantes> records = new List<EN_ListadoCurso_Estudiantes>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoCurso_Estudiantes(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoCurso_Estudiantes> ObtenerEstuCourEspecifico(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_MODIFICARSTUDENTCOURSE @StudentId, @CourseId";//No se que correr

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@Id", id);

            List<EN_ListadoCurso_Estudiantes> records = new List<EN_ListadoCurso_Estudiantes>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoCurso_Estudiantes(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public void Update_StudentCourse(int studentId,  int courseId, int courseOld)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARSTUDENTCOURSE @StudentId, @CourseId, @CourseOld";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@StudentId", studentId);
            cmd.Parameters.AddWithValue("@CourseId", courseId);
            cmd.Parameters.AddWithValue("@CourseOld", courseOld);

            cmd.ExecuteNonQuery();

            conexion.Close();

  
        }

    }
}