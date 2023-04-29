using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Escuela : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }

        private void MostralPanelPrincipal()
        {
            PanelPrincipaL.Visible = true;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
        }

        //BOTONES DEL PANEL PRINCIPAL
        protected void btn_PanelPrincipal_Agregar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = true;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
        }

        protected void btn_PanelPrincipal_Editar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = true;
            PanelEliminar.Visible = false;
            CargarEscuelas();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarEscuelasParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarEscuelasParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
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

        protected void btnInsertarEscuela_Cancelar_Click(object sender, EventArgs e)
        {
            TxtNombreEscuela.Text = "";
            TxtDescripcion.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Text = "";
            TxtCodigoPostal.Text = "";
            TxtDireccionPostal.Text = "";
            MostralPanelPrincipal();
        }

        //Editar

        private void CargarEscuelas()
        {
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            var listadoEscuela = escuelas.ObtenerEscuelaEspecifica(0);

            ddl_Escuelas.DataSource = listadoEscuela;
            ddl_Escuelas.DataValueField = "Id";
            ddl_Escuelas.DataTextField = "Nombre";
            ddl_Escuelas.DataBind();
        }
        protected void ddl_Escuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEscuela = Convert.ToInt32(ddl_Escuelas.SelectedValue.ToString());
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            var listado = escuelas.ObtenerEscuelaEspecifica(idEscuela);

            foreach (var item in listado)
            {
                TxtEditar_NombreEscuela.Text = item.Nombre.ToString();
                TxtEditar_Descripcion.Text = item.Descripcion.ToString();
                TxtEditar_Direccion.Text = item.Direccion.ToString();
                TxtEditar_Telefono.Text = item.Telefono.ToString();
                TxtEditar_CodigoPostal.Text = item.CodigoPostal.ToString();
                TxtEditar_DireccionPostal.Text = item.DIreccionPostal.ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int vidEscuela = Convert.ToInt32(ddl_Escuelas.SelectedValue.ToString());
            string vnombreEscuela = TxtEditar_NombreEscuela.Text;
            string vDescripcion = TxtEditar_Descripcion.Text;
            string vDirecccion = TxtEditar_Direccion.Text;
            string vTelefono = TxtEditar_Telefono.Text;
            string vCodigoPostal = TxtEditar_CodigoPostal.Text;
            string vDireccionPostal = TxtEditar_DireccionPostal.Text;
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            string resultado = escuelas.Update_School(vidEscuela, vnombreEscuela, vDescripcion, vDirecccion, vTelefono, vCodigoPostal, vDireccionPostal);

            if (resultado == "Escuela editada.")
            {
                //Alert de editado con exito
                TxtEditar_NombreEscuela.Text = "";
                TxtEditar_Descripcion.Text = "";
                TxtEditar_Direccion.Text = "";
                TxtEditar_Telefono.Text = "";
                TxtEditar_CodigoPostal.Text = "";
                TxtEditar_DireccionPostal.Text = "";
                CargarEscuelas();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Escuela editada correctamente.');", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Se presento un error al editar la escuela.');", true);
                return;
            }
        }

        protected void btnEdittar_Cancelar_Click(object sender, EventArgs e)
        {

            MostralPanelPrincipal();
        }

       

        protected void btnEliminar_Cancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int vidEscuela = Convert.ToInt32(ddl_EliminarEscula.SelectedValue.ToString());
            AC_DeleteSchool borrar = new AC_DeleteSchool();
            borrar.Delete_School(vidEscuela);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Escuela eliminada.');", true);
            CargarEscuelasParaEliminar();
        }

        private void CargarEscuelasParaEliminar()
        {
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            var listadoEscuela = escuelas.ObtenerListadEscuelas();

            ddl_EliminarEscula.DataSource = listadoEscuela;
            ddl_EliminarEscula.DataValueField = "Id";
            ddl_EliminarEscula.DataTextField = "Nombre";
            ddl_EliminarEscula.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarEscuelasParaConsulta()
        {
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            var listadoEscuela = escuelas.ObtenerEscuelaEspecifica(0);

            GVEscuelas.DataSource = listadoEscuela;
            GVEscuelas.DataBind();
        }


    }
}