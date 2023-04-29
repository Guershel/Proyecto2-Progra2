using Proyecto_2.Capas.Acceso_a_datos.Curso_Estudiante;
using Proyecto_2.Capas.Acceso_a_datos.Curso_Profesor;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_CursoTeacher : System.Web.UI.Page
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
            CargarEstuCurso();
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
        protected void btnInsertarCursoProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                string StudentId = TxtIdProfesor.Text;
                string CourseId = TxtIdCurso.Text;


                AC_InsertTeacher_Course insert = new AC_InsertTeacher_Course();
                string resultado = insert.Insert_TeacherCourse(StudentId, CourseId);

                if (resultado == "Curso a profesor registrado.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Curso registrada a profesor exitosamente.');", true);
                    TxtIdProfesor.Text = "";
                    TxtIdCurso.Text = "";

                }
                else if (resultado == "El profesor ya tiene el curso.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el profesor tiene ese curso, intento con otro');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el curso al profesor.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarCursoProfesor_Cancelar_Click(object sender, EventArgs e)
        {
            TxtIdProfesor.Text = "";
            TxtIdCurso.Text = "";

            MostralPanelPrincipal();
        }

        //Editar

        private void CargarEstuCurso()
        {
            AC_UpdateTeacher_Course EstuCurso = new AC_UpdateTeacher_Course();
            var listadoEC = EstuCurso.ObtenerListadoCurso_Profesores();

            ddl_Profesor.DataSource = listadoEC;
            ddl_Profesor.DataValueField = "Id";
            ddl_Profesor.DataTextField = "Nombre";
            ddl_Profesor.DataBind();


        }
        protected void ddl_Profesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProfesor = Convert.ToInt32(ddl_Profesor.SelectedValue.ToString());
            AC_UpdateTeacher_Course escuelas = new AC_UpdateTeacher_Course();
            var listado = escuelas.ObtenerCursoProfesoresEspecifica(idProfesor);

            foreach (var item in listado)
            {
                EditarTxtIdCurso.Text = item.CourseId.ToString();

            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string studentId = ddl_Profesor.SelectedValue.ToString();
            string courseId = EditarTxtIdCurso.Text;

            AC_UpdateTeacher_Course escuelas = new AC_UpdateTeacher_Course();
            string resultado = escuelas.Update_TeacherCourse(studentId, courseId);

            if (resultado == "curso a profesor editada.")
            {
                //Alert de editado con exito
                EditarTxtIdCurso.Text = "";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('curso a profesor editado correctamente.');", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Se presento un error al cambiarle de curso al profesor.');", true);
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
            int vidEstudiante = Convert.ToInt32(ddl_EliminarProfesor.SelectedValue.ToString());
            AC_DeleteTeacher_Course borrar = new AC_DeleteTeacher_Course();
            borrar.Delete_TeacherCourse(vidEstudiante);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('profesor sin curso.');", true);
            CargarEscuelasParaEliminar();
        }

        private void CargarEscuelasParaEliminar()
        {
            AC_UpdateStudent_Course escuelas = new AC_UpdateStudent_Course();
            var listadoEscuela = escuelas.ObtenerListadoEstuCour();

            ddl_EliminarProfesor.DataSource = listadoEscuela;
            ddl_EliminarProfesor.DataValueField = "Id";
            ddl_EliminarProfesor.DataTextField = "Nombre";
            ddl_EliminarProfesor.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarEscuelasParaConsulta()
        {
            AC_UpdateSchool escuelas = new AC_UpdateSchool();
            var listadoEscuela = escuelas.ObtenerListadEscuelas();

            GVCurProfesor.DataSource = listadoEscuela;
            GVCurProfesor.DataBind();
        }
    }
}