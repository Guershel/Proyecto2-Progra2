using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertarEscuela_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEscuela = TxtNombreEscuela.Text;
                string descripcion = TxtDescripcion.Text;
                string direccion = TxtDireccion.Text;
                string telefono = TxtTelefono.Text;
                string codigoPostal = TxtCodigoPostal.Text;
                string direccionPostal = TxtDireccionPostal.Text;

                AC_InsertSchool insert = new AC_InsertSchool();
                string resultado = insert.Insert_School(nombreEscuela, descripcion, direccion, telefono, codigoPostal, direccionPostal);

                if (resultado == "Escuela registrada.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Escuela registrada exitosamente.');", true);
                    TxtNombreEscuela.Text = "";
                    TxtDescripcion.Text = "";
                    TxtDireccion.Text = "";
                    TxtTelefono.Text = "";
                    TxtCodigoPostal.Text = "";
                    TxtDireccionPostal.Text = "";
                }
                else if (resultado == "Escuela ya existe registrada.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya la escuela se encuentra registrada, intente con otra.');", true);
                    return; 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar la escuela.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }
    }
}