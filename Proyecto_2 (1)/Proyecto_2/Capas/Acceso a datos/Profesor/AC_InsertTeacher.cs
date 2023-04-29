using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Profesor
{
    public class AC_InsertTeacher
    {
        public string Insert_Teacher(int schoolId, string teacherName, string description)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_AGREGARTEACHER @SchoolId, @TeacherName, @Description";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@SchoolId", schoolId);
            cmd.Parameters.AddWithValue("@TeacherName", teacherName);
            cmd.Parameters.AddWithValue("@description", description);
           
            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}