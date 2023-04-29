using Proyecto_2.Capas.Entidad.Student;
using Proyecto_2.Capas.Entidad.Teacher;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Profesor
{
    public class AC_UpdateTeacher
    {
        public List<EN_ListadoProfesores> ObtenerListadoProfesores()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListTeacher";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoProfesores> records = new List<EN_ListadoProfesores>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoProfesores(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoProfesores> ObtenerProfesorEspecifico(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListTeacher_Id @TeacherId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@TeacherId", id);

            List<EN_ListadoProfesores> records = new List<EN_ListadoProfesores>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoProfesores(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public void Update_Teacher(int teacherId, int schoolId, string teacherName, string description)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARTEACHER @TeacherId , @SchoolId, @TeacherName, @Description";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@TeacherId", teacherId);
            cmd.Parameters.AddWithValue("@SchoolId", schoolId);
            cmd.Parameters.AddWithValue("@TeacherName", teacherName);
            cmd.Parameters.AddWithValue("@Description", description);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}