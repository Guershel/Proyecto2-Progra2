using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Profesor
{
    public class AC_DeleteTeacher
    {
        public void Delete_Teacher(int id)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_BORRARTEACHER @TeacherId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@TeacherId", id);


            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}