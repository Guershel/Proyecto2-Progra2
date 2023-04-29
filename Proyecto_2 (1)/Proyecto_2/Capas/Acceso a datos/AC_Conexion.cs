using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_2.Capas.Acceso_a_datos
{
    public class AC_Conexion
    {
        //private string cadenaConexion = @"Data Source=P_IP;Initial Catalog=P_BD;Persist Security Info=True;User ID=P_USER;Password=P_PASS";
        private string cadenaConexion = @"Data Source=DESKTOP-FDJ6OTM\SQLEXPRESS;Initial Catalog=GestiondeEducacion;Integrated Security=True";

        public string CadenaConexion() {
            
            return cadenaConexion;
        
        }
    }
}