using Proyecto_2.Capas.Entidad.School;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos.School
{
    public class AC_UpdateSchool
    {
        public List<EN_ListadoEscuelas> ObtenerListadEscuelas()
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListSchool";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);

            List<EN_ListadoEscuelas> records = new List<EN_ListadoEscuelas>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoEscuelas(reader));

                }
            }
            Conexion.Close(); //O hacer lo del valor 0 y usar eso en todo para que solo tenga un procedimiento
            return records;
        }

        public List<EN_ListadoEscuelas> ObtenerEscuelaEspecifica(int id)
        {

            AC_Conexion conx = new AC_Conexion();

            var Conexion = new SqlConnection(conx.CadenaConexion());
            string sql = "EXEC SP_ListSchool_Id @Id";

            Conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("@Id", id);

            List<EN_ListadoEscuelas> records = new List<EN_ListadoEscuelas>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new EN_ListadoEscuelas(reader));

                }
            }
            Conexion.Close();
            return records;
        }
        public string Update_School(int Id, string schoolName, string description, string address, string phone, string postCode, string postAddress)
        {
            AC_Conexion con = new AC_Conexion();

            var conexion = new SqlConnection(con.CadenaConexion());
            string sql = "EXEC SP_UpdateSchool @Id , @SchoolName, @Description, @Address , @Phone, @PostCode, @PostAddress";
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@SchoolName", schoolName);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@PostCode", postCode);
            cmd.Parameters.AddWithValue("@PostAddress", postAddress);

            string resultado = cmd.ExecuteScalar().ToString();

            conexion.Close();

            return resultado;
        }
    }
}