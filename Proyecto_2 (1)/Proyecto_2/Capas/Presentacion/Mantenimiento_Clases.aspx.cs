using Microsoft.Ajax.Utilities;
using Proyecto_2.Capas.Acceso_a_datos.Clase;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Clases : System.Web.UI.Page
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
            CargarEscuelas();
        }

        protected void btn_PanelPrincipal_Editar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = true;
            PanelEliminar.Visible = false;
            CargarClases();
            CargarEscuelasParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarClaseParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarClasesParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarClase_Click(object sender, EventArgs e)
        {
            try
            {
                int SchoolId = Convert.ToInt32(ddl_IdEscuela.SelectedValue.ToString());
                string ClassName = TxtNombreClase.Text;
                string Description = TxtDescripcion.Text;
               

                AC_InsertClass insert = new AC_InsertClass();
                string resultado = insert.Insert_Class(SchoolId, ClassName, Description);

                if (resultado == "Registro exitoso") //TIENE QUE DECIR EXACTAMENTE LO QUE DICE LA bd SI NO NO VA A FUNCIONAR
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Clase registrada exitosamente.');", true);
                    
                    TxtNombreClase.Text = "";
                    TxtDescripcion.Text = "";
                    
                }
                else if (resultado == "La clase ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya la clase se encuentra registrada, intente con otra.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar la clase.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarClases_Cancelar_Click(object sender, EventArgs e)
        {
           
            TxtNombreClase.Text = "";
            TxtDescripcion.Text = "";
            MostralPanelPrincipal();
        }

        //Editar

        private void CargarClases()
        {

            //Le voy a arrelgar este pero ponga atencion, primero vamos a ver el listado de lo que devuelve la BD
            AC_UpdateClass clases = new AC_UpdateClass();
            var listadoCLases = clases.ObtenerListadoClases();

            ddl_Clases.DataSource = listadoCLases;
            ddl_Clases.DataValueField = "ClassId"; //AQUI VAN LOS NOMBRES QUE LE PUSIERON AL CONTRUCTOR (ID)
            ddl_Clases.DataTextField = "ClassName";//AQUI VAN LOS NOMBRES QUE LE PUSIERON AL CONTRUCTOR (NONBRE)
            ddl_Clases.DataBind();
        }
        protected void ddl_Clases_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idClase = Convert.ToInt32(ddl_Clases.SelectedValue.ToString());
            AC_UpdateClass escuelas = new AC_UpdateClass();
            var listado = escuelas.ObtenerClaseEspecifica(idClase);

            foreach (var item in listado)
            {
                ddl_Clases.Text = item.ClassId.ToString();
                ddl_Editar_Escuela.SelectedValue = item.SchoolId; //Este selecciona el valor de la BD al listado para que sea el que tiene
                TxtEditar_NombreClase.Text = item.ClassName.ToString();
                TxtEditar_Descripcion.Text = item.Descripcion.ToString();
                
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int vidClase = Convert.ToInt32(ddl_Clases.SelectedValue.ToString());
            int vIdEscuela = Convert.ToInt32(ddl_Editar_Escuela.SelectedValue.ToString());//no se si esta bueno // QUE CLASE DE PERSONA PONE ESTO 
            string nombreClase = TxtEditar_NombreClase.Text;
            string vDescripcion = TxtEditar_Descripcion.Text;
            
            AC_UpdateClass escuelas = new AC_UpdateClass();

            escuelas.Update_Class(vidClase, vIdEscuela, nombreClase, vDescripcion);
            TxtEditar_NombreClase.Text = "";
            TxtEditar_Descripcion.Text = "";

            CargarClases();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Clase editada correctamente.');", true);
            return;
        }

        protected void btnEditar_Cancelar_Click(object sender, EventArgs e)
        {

            MostralPanelPrincipal();
        }



        protected void btnEliminar_Cancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int vidClase = Convert.ToInt32(ddl_EliminarCLases.SelectedValue.ToString());
            AC_DeleteClass borrar = new AC_DeleteClass();
            borrar.Delete_Class(vidClase);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Clase eliminada.');", true);
            CargarClaseParaEliminar();
        }

        private void CargarClaseParaEliminar()
        {
            AC_UpdateClass clases = new AC_UpdateClass();
            var listadoClases = clases.ObtenerListadoClases();

            ddl_EliminarCLases.DataSource = listadoClases;
            ddl_EliminarCLases.DataValueField = "ClassId"; //AQUI VAN LOS NOMBRES QUE LE PUSIERON AL CONTRUCTOR (ID)
            ddl_EliminarCLases.DataTextField = "ClassName";//AQUI VAN LOS NOMBRES QUE LE PUSIERON AL CONTRUCTOR (NONBRE)
            ddl_EliminarCLases.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarClasesParaConsulta()
        {
            AC_UpdateClass clases = new AC_UpdateClass();
            var listadoClases = clases.ObtenerListadoClases();

            GVClases.DataSource = listadoClases;
            GVClases.DataBind();
        }

        /*ESTO ES PARA CARGAR LAS ESCUELAS*/

        private void CargarEscuelas()
        {
            AC_UpdateSchool escuela = new AC_UpdateSchool();
            var listadoCLases = escuela.ObtenerListadEscuelas();

            ddl_IdEscuela.DataSource = listadoCLases;
            ddl_IdEscuela.DataValueField = "Id";
            ddl_IdEscuela.DataTextField = "Nombre";
            ddl_IdEscuela.DataBind();
        }

        private void CargarEscuelasParaEditar()
        {
            AC_UpdateSchool escuela = new AC_UpdateSchool();
            var listadoCLases = escuela.ObtenerListadEscuelas();

            ddl_Editar_Escuela.DataSource = listadoCLases;
            ddl_Editar_Escuela.DataValueField = "Id";
            ddl_Editar_Escuela.DataTextField = "Nombre";
            ddl_Editar_Escuela.DataBind();
        }

        protected void ddl_EliminarCLases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}