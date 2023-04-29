using Proyecto_2.Capas.Entidad.Course;
using Proyecto_2.Capas.Entidad.Grade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Grado
{
    public class AC_UpdateGrade
    {
        public List<EN_ListadoGrade> ObtenerListadoGrados()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListGrade";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoGrade> records = new List<EN_ListadoGrade>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoGrade(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoGrade> ObtenerGradoEspecifica(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListGrade_Id @GradeId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@GradeId", id);

            List<EN_ListadoGrade> records = new List<EN_ListadoGrade>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    records.Add(new EN_ListadoGrade(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public void Update_Grade(int Id, int StudentId, int CourseId, float Grade, string Comment)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARGRADE @GradeId, @StudentId, @CourseId, @Grade, @Comment";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@GradeId", Id);
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.Parameters.AddWithValue("@CourseId", CourseId);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@Comment", Comment);

            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}