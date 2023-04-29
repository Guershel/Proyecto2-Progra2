using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Estudiante
{
    public class AC_DeleteStudent
    {
        public void Delete_Student(int id)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_BORRARSTUDENT @StudentId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@StudentId", id);


            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}