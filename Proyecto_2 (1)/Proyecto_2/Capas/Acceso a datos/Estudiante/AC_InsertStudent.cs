using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Estudiante
{
    public class AC_InsertStudent
    {
        public string Insert_Student(int classId, string studentName, string studentNumber, string totalGrade,
            string address, string phone, string email)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_AGREGARSTUDENT @ClassId, @StudentName, @StudentNumber , @TotalGrade, @Address, @Phone, @Email";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@ClassId", classId);
            cmd.Parameters.AddWithValue("@StudentName", studentName);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            cmd.Parameters.AddWithValue("@TotalGrade", totalGrade);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);


            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}