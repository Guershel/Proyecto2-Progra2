using Proyecto_2.Capas.Acceso_a_datos.Clase;
using Proyecto_2.Capas.Acceso_a_datos.Curso;
using Proyecto_2.Capas.Acceso_a_datos.Curso_Estudiante;
using Proyecto_2.Capas.Acceso_a_datos.Estudiante;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_CursoEstudiante : System.Web.UI.Page
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
            CargarCursos();
            CargarEstudiante();
        }

        protected void btn_PanelPrincipal_Editar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = true;
            PanelEliminar.Visible = false;
            CargarCursosParaEditar();
            //CargarEstudianteParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarCursosParaEliminar();
            CargarEstudiantesParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarCursosEstudiantesParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarCursoEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                int StudentId = Convert.ToInt32(ddl_Estudiantes.SelectedValue.ToString());
                int CourseId = Convert.ToInt32(ddl_Cursos.SelectedValue.ToString());


                AC_InsertStudent_Course insert = new AC_InsertStudent_Course();
                string resultado = insert.Insert_StudentCourse( StudentId,  CourseId);

                if (resultado == "Registro exitoso")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Curso registrada a estudiante exitosamente.');", true);
                    CargarCursos();
                    CargarEstudiante();

                }
                else if (resultado == "El Curso del estudiante ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el estudiante tiene ese curso, intento con otro');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el curso al estudiante.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarCursoEstudiante_Cancelar_Click(object sender, EventArgs e)
        {
            
            
            MostralPanelPrincipal();
        }

        //Editar

       /* private void CargarEstuCurso()
        {
            AC_UpdateStudent_Course EstuCurso = new AC_UpdateStudent_Course();
            var listadoEC = EstuCurso.ObtenerListadoEstuCour();

            ddl_Estudiante.DataSource = listadoEC;
            ddl_Estudiante.DataValueField = "Id";
            ddl_Estudiante.DataTextField = "Nombre";
            ddl_Estudiante.DataBind();


        }*/
        protected void ddl_Estudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEstudiante = Convert.ToInt32(ddl_Estudiantes.SelectedValue.ToString());
            AC_UpdateStudent_Course escuelas = new AC_UpdateStudent_Course();
            var listado = escuelas.ObtenerEstuCourEspecifico(idEstudiante);

            foreach (var item in listado)
            {
                ddl_Cursos.Text = item.CourseId.ToString();
                
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(ddl_Editar_Estudiante.SelectedValue.ToString());
            int courseId = Convert.ToInt32(ddl_Editar_Curso.SelectedValue.ToString());
            int courseOld = Convert.ToInt32(ddl_EditarCursosActuales.SelectedValue.ToString());


            AC_UpdateStudent_Course escuelas = new AC_UpdateStudent_Course();
            escuelas.Update_StudentCourse( studentId,  courseId, courseOld);
            string valorCedula = "";
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            TxtEditarCedula_Curso.Text = "";
            var listado = estudiante.ObtenerListadoEstudianteXCedula(valorCedula);

            ddl_Editar_Estudiante.DataSource = listado;
            ddl_Editar_Estudiante.DataValueField = "StudentId";
            ddl_Editar_Estudiante.DataTextField = "StudentName";
            ddl_Editar_Estudiante.DataBind();

            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursosXEstudiante(valorCedula);
            ddl_EditarCursosActuales.DataSource = listadoCursos;
            ddl_EditarCursosActuales.DataValueField = "CourseId";
            ddl_EditarCursosActuales.DataTextField = "CourseName";
            ddl_EditarCursosActuales.DataBind();


            CargarCursosParaEditar();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('curso a estudiante editado correctamente.');", true);
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
            int vidEstudiante = Convert.ToInt32(ddl_EliminarEstudiante.SelectedValue.ToString());
            int vidCurso = Convert.ToInt32(ddl_EliminarCurso.SelectedValue.ToString());
            AC_DeleteStudent_Course borrar = new AC_DeleteStudent_Course();
            borrar.Delete_StudentCourse(vidEstudiante);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Eliminado correctamente.');", true);

            string valorCedula = "";
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listado = estudiante.ObtenerListadoEstudianteXCedula(valorCedula);

            ddl_EliminarEstudiante.DataSource = listado;
            ddl_EliminarEstudiante.DataValueField = "StudentId";
            ddl_EliminarEstudiante.DataTextField = "StudentName";
            ddl_EliminarEstudiante.DataBind();

            
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursosXEstudiante(valorCedula);
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
        private void CargarCursosEstudiantesParaConsulta()
        {
            AC_UpdateStudent_Course CurEs = new AC_UpdateStudent_Course();
            var listadoEstudiante = CurEs.ObtenerEstuCourEspecifico(0);


            GVCurEstu.DataSource = listadoEstudiante;
            GVCurEstu.DataBind();
        }
        //Cursos
        private void CargarCursos()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCLases = cursos.ObtenerCursoEspecifica(0);

            ddl_Cursos.DataSource = listadoCLases;
            ddl_Cursos.DataValueField = "CourseId";
            ddl_Cursos.DataTextField = "CourseName";
            ddl_Cursos.DataBind();
        }

        private void CargarCursosParaEditar()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCLases = cursos.ObtenerCursoEspecifica(0);

            ddl_Editar_Curso.DataSource = listadoCLases;
            ddl_Editar_Curso.DataValueField = "CourseId";
            ddl_Editar_Curso.DataTextField = "CourseName";
            ddl_Editar_Curso.DataBind();
        }

        private void CargarCursosParaEliminar()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoEscuela = cursos.ObtenerCursoEspecifica(0);

            ddl_EliminarCurso.DataSource = listadoEscuela;
            ddl_EliminarCurso.DataValueField = "CourseId";
            ddl_EliminarCurso.DataTextField = "CourseName";
            ddl_EliminarCurso.DataBind();
        }
        //Estudiantes 
        private void CargarEstudiante()
        {
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listadoCLases = estudiante.ObtenerEstudianteEspecifico(0);

            ddl_Estudiantes.DataSource = listadoCLases;
            ddl_Estudiantes.DataValueField = "StudentId";
            ddl_Estudiantes.DataTextField = "StudentName";
            ddl_Estudiantes.DataBind();
        }

        private void CargarEstudianteParaEditar()
        {
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listadoCLases = estudiante.ObtenerEstudianteEspecifico(0);

            ddl_Editar_Estudiante.DataSource = listadoCLases;
            ddl_Editar_Estudiante.DataValueField = "StudentId";
            ddl_Editar_Estudiante.DataTextField = "StudentName";
            ddl_Editar_Estudiante.DataBind();
        }
        private void CargarEstudiantesParaEliminar()
        {
            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            var listadoEscuela = estudiantes.ObtenerEstudianteEspecifico(0);

            ddl_EliminarEstudiante.DataSource = listadoEscuela;
            ddl_EliminarEstudiante.DataValueField = "StudentId";
            ddl_EliminarEstudiante.DataTextField = "StudentName";
            ddl_EliminarEstudiante.DataBind();
        }

        protected void btnBuscarCedula_Click(object sender, EventArgs e)
        {
            string valorCedula = TxtEditarCedula_Curso.Text;
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listado = estudiante.ObtenerListadoEstudianteXCedula(valorCedula);

            ddl_Editar_Estudiante.DataSource = listado;
            ddl_Editar_Estudiante.DataValueField = "StudentId";
            ddl_Editar_Estudiante.DataTextField = "StudentName";
            ddl_Editar_Estudiante.DataBind();

            int vidEstudiante = Convert.ToInt32(ddl_Editar_Estudiante.SelectedValue.ToString());
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursosXEstudiante(valorCedula);
            ddl_EditarCursosActuales.DataSource = listadoCursos;
            ddl_EditarCursosActuales.DataValueField = "CourseId";
            ddl_EditarCursosActuales.DataTextField = "CourseName";
            ddl_EditarCursosActuales.DataBind();
        }

        protected void ddl_Editar_Estudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnBuscarEliminarCurso_Click(object sender, EventArgs e)
        {
            string valorCedula = TxtEliminar_Curso.Text;
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listado = estudiante.ObtenerListadoEstudianteXCedula(valorCedula);

            ddl_EliminarEstudiante.DataSource = listado;
            ddl_EliminarEstudiante.DataValueField = "StudentId";
            ddl_EliminarEstudiante.DataTextField = "StudentName";
            ddl_EliminarEstudiante.DataBind();

           
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCursos = cursos.ObtenerCursosXEstudiante(valorCedula);
            ddl_EliminarCurso.DataSource = listadoCursos;
            ddl_EliminarCurso.DataValueField = "CourseId";
            ddl_EliminarCurso.DataTextField = "CourseName";
            ddl_EliminarCurso.DataBind();
        }
        
    }
}