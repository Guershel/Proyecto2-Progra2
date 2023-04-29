using Proyecto_2.Capas.Entidad.School;
using Proyecto_2.Capas.Entidad.Student;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Estudiante
{
    public class AC_UpdateStudent
    {
        public List<EN_ListadoEstudiantes> ObtenerListadoEstudiantes()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListStudent";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoEstudiantes> records = new List<EN_ListadoEstudiantes>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoEstudiantes(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoEstudiantes> ObtenerEstudianteEspecifico(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListStudent_Id @StudentId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@StudentId", id);

            List<EN_ListadoEstudiantes> records = new List<EN_ListadoEstudiantes>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoEstudiantes(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoEstudiantes> ObtenerListadoEstudianteXCedula(string cedula)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ObtenerEstudianteXCedula @Cedula";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@Cedula", cedula);

            List<EN_ListadoEstudiantes> records = new List<EN_ListadoEstudiantes>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoEstudiantes(reader));

                }
            }
            Conexion.Close();
            return records;
        }


        public void Update_Student(int Id, int classId, string studentName, string studentNumber, string totalGrade,
            string address, string phone, string email)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARSTUDENT @StudentId, @ClassId, @StudentName, @StudentNumber, @TotalGrade, @Address, @Phone, @Email";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@StudentId", Id);
            cmd.Parameters.AddWithValue("@ClassId", classId);
            cmd.Parameters.AddWithValue("@StudentName", studentName);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            cmd.Parameters.AddWithValue("@TotalGrade", totalGrade);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}