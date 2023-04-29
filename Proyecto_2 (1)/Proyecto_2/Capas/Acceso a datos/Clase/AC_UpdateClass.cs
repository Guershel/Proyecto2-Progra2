using Microsoft.Ajax.Utilities;
using Proyecto_2.Capas.Entidad.Class;
using Proyecto_2.Capas.Entidad.School;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.Clase
{
    public class AC_UpdateClass
    {

        public List<EN_ListadoClases> ObtenerListadoClases()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_CONSULTARCLASSTotal";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoClases> records = new List<EN_ListadoClases>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoClases(reader));

                }
            }
            Conexion.Close();
            return records;
        }

        public List<EN_ListadoClases> ObtenerClaseEspecifica(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListClass_Id @ClassId";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@ClassId", id);

            List<EN_ListadoClases> records = new List<EN_ListadoClases>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    records.Add(new EN_ListadoClases(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public void Update_Class(int Id, int schoolId, string className, string description)
        {

            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_MODIFICARCLASS @ClassId, @SchoolId, @ClassName, @Description";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@ClassId", Id);
            cmd.Parameters.AddWithValue("@SchoolId", schoolId);
            cmd.Parameters.AddWithValue("@ClassName", className);
            cmd.Parameters.AddWithValue("@Description", description);


            cmd.ExecuteNonQuery();

            conexion.Close();

            // return resultado;
        }
    }
}