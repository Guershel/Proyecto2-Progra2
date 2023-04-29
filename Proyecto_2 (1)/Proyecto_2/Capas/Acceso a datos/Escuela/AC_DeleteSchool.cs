using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.School
{
    public class AC_DeleteSchool
    {
        public void Delete_School(int id)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_BORRARSCHOOL @SchoolId";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@SchoolId", id);
           

            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}