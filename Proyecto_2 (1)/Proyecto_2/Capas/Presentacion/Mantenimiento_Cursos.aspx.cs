using Proyecto_2.Capas.Acceso_a_datos.Curso;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Cursos : System.Web.UI.Page
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
            CargarCursos();
            CargarEscuelasParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarCursosParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarCursosParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                int SchoolId = Convert.ToInt32(ddl_IdEscuela.SelectedValue.ToString());
                string nombreCurso = TxtNombreCurso.Text;               
                string descripcion = TxtDescripcion.Text;


                AC_InsertCourse insert = new AC_InsertCourse();
                string resultado = insert.Insert_Course(SchoolId, nombreCurso,  descripcion);

                if (resultado == "Registro exitoso")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Curso registrado exitosamente.');", true);

                    TxtNombreCurso.Text = "";
                    TxtDescripcion.Text = "";

                }
                else if (resultado == "El curso ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el curso se encuentra registrado, intente con otro.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el Curso.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarCurso_Cancelar_Click(object sender, EventArgs e)
        {
            TxtNombreCurso.Text = "";
            TxtDescripcion.Text = "";

            MostralPanelPrincipal();
        }

        //Editar

        private void CargarCursos()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursoEspecifica(0);

            ddl_Cursos.DataSource = listadoCursos;
            ddl_Cursos.DataValueField = "CourseId";
            ddl_Cursos.DataTextField = "CourseName";
            ddl_Cursos.DataBind();
        }
        protected void ddl_Cursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCurso = Convert.ToInt32(ddl_Cursos.SelectedValue.ToString());
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listado = cursos.ObtenerCursoEspecifica(idCurso);

            foreach (var item in listado)
            {
                ddl_Cursos.Text = item.CourseId.ToString();
                ddl_Editar_Escuela.Text = item.SchoolId.ToString();
                TxtEditar_NombreCurso.Text = item.CourseName.ToString();
                TxtEditar_Descripcion.Text = item.Descripcion.ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int vCourseId = Convert.ToInt32(ddl_Cursos.SelectedValue.ToString());
            string vcourseName = TxtEditar_NombreCurso.Text;
            int vIdEscuela = Convert.ToInt32(ddl_Editar_Escuela.SelectedValue.ToString());
            string vDescripcion = TxtEditar_Descripcion.Text;

            AC_UpdateCourse cursos = new AC_UpdateCourse();
            cursos.Update_Course(vCourseId, vcourseName, vIdEscuela, vDescripcion);
            TxtEditar_NombreCurso.Text = "";
            TxtEditar_Descripcion.Text = "";
            CargarCursos();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Curso editado correctamente.');", true);
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
            int vidCurso = Convert.ToInt32(ddl_EliminarCurso.SelectedValue.ToString());
            AC_DeleteCourse borrar = new AC_DeleteCourse();
            borrar.Delete_Course(vidCurso);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Curso eliminado.');", true);
            CargarCursosParaEliminar();
        }

        private void CargarCursosParaEliminar()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursoEspecifica(0);

            ddl_EliminarCurso.DataSource = listadoCursos;
            ddl_EliminarCurso.DataValueField = "CourseId";
            ddl_EliminarCurso.DataTextField = "CourseName";
            ddl_EliminarCurso.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarCursosParaConsulta()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursoEspecifica(0);

            GVCursos.DataSource = listadoCursos;
            GVCursos.DataBind();
        }
        //Cargas
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
    }
}