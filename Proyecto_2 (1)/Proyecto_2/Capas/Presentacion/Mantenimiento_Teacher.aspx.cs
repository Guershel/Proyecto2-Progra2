using Proyecto_2.Capas.Acceso_a_datos.Profesor;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Teacher : System.Web.UI.Page
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
            CargarProfesores();
            CargarEscuelasParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarProfesorParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarProfesorParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                int SchoolId = Convert.ToInt32(ddl_IdEscuela.SelectedValue.ToString());
                string teacherName = TxtNombreProfesor.Text;
                string description = TxtDescripcion.Text;
             

                AC_InsertTeacher insert = new AC_InsertTeacher();
                string resultado = insert.Insert_Teacher( SchoolId,  teacherName,  description);

                if (resultado == "Registro exitoso")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Profesor registrada exitosamente.');", true);
                    
                    TxtNombreProfesor.Text = "";
                    TxtDescripcion.Text = "";
                   
                }
                else if (resultado == "El Profesor ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el profesor se encuentra registrada, intente con otra.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el profesor.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarProfesor_Cancelar_Click(object sender, EventArgs e)
        {
           
            TxtNombreProfesor.Text = "";
            TxtDescripcion.Text = "";
            
            MostralPanelPrincipal();
        }

        //Editar

        private void CargarProfesores()
        {
            AC_UpdateTeacher profesor = new AC_UpdateTeacher();
            var listadoProfesor = profesor.ObtenerProfesorEspecifico(0);

            ddl_Profesor.DataSource = listadoProfesor;
            ddl_Profesor.DataValueField = "TeacherId";
            ddl_Profesor.DataTextField = "TeacherName";
            ddl_Profesor.DataBind();
        }
        protected void ddl_Profesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProfesor = Convert.ToInt32(ddl_Profesor.SelectedValue.ToString());
            AC_UpdateTeacher profesor = new AC_UpdateTeacher();
            var listado = profesor.ObtenerProfesorEspecifico(idProfesor);

            foreach (var item in listado)
            {
                ddl_Profesor.Text = item.TeacherId.ToString();
                ddl_Editar_Escuela.Text = item.SchoolId.ToString();
                TxtEditar_NombreProfesor.Text = item.TeacherName.ToString();
                TxtEditar_Descripcion.Text = item.Description.ToString();             
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int teacherId = Convert.ToInt32(ddl_Profesor.SelectedValue.ToString());
            int schoolId = Convert.ToInt32(ddl_Editar_Escuela.SelectedValue.ToString());
            string teacherName = TxtEditar_NombreProfesor.Text;
            string description = TxtEditar_Descripcion.Text;
            
            AC_UpdateTeacher profesor = new AC_UpdateTeacher();
            profesor.Update_Teacher( teacherId,  schoolId,  teacherName,  description);           
            TxtEditar_NombreProfesor.Text = "";
            TxtEditar_Descripcion.Text = "";   
            CargarProfesores();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Profesor editado correctamente.');", true);
                return;
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
            int vidProfesor = Convert.ToInt32(ddl_EliminarProfesor.SelectedValue.ToString());
            AC_DeleteTeacher borrar = new AC_DeleteTeacher();
            borrar.Delete_Teacher(vidProfesor);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Profesor eliminada.');", true);
            CargarProfesorParaEliminar();
        }

        private void CargarProfesorParaEliminar()
        {
            AC_UpdateTeacher profesor = new AC_UpdateTeacher();
            var listadoProfesor = profesor.ObtenerProfesorEspecifico(0);

            ddl_EliminarProfesor.DataSource = listadoProfesor;
            ddl_EliminarProfesor.DataValueField = "TeacherId";
            ddl_EliminarProfesor.DataTextField = "TeacherName";
            ddl_EliminarProfesor.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarProfesorParaConsulta()
        {
            AC_UpdateTeacher profesor = new AC_UpdateTeacher();
            var listadoProfesor = profesor.ObtenerProfesorEspecifico(0);

            GVProfesor.DataSource = listadoProfesor;
            GVProfesor.DataBind();
        }
        //CARGAS
        private void CargarEscuelas()
        {
            AC_UpdateSchool escuela = new AC_UpdateSchool();
            var listadoCLases = escuela.ObtenerEscuelaEspecifica(0);

            ddl_IdEscuela.DataSource = listadoCLases;
            ddl_IdEscuela.DataValueField = "Id";
            ddl_IdEscuela.DataTextField = "Nombre";
            ddl_IdEscuela.DataBind();
        }

        private void CargarEscuelasParaEditar()
        {
            AC_UpdateSchool escuela = new AC_UpdateSchool();
            var listadoCLases = escuela.ObtenerEscuelaEspecifica(0);
            ddl_Editar_Escuela.DataSource = listadoCLases;
            ddl_Editar_Escuela.DataValueField = "Id";
            ddl_Editar_Escuela.DataTextField = "Nombre";
            ddl_Editar_Escuela.DataBind();
        }
    }
}