using Proyecto_2.Capas.Acceso_a_datos.Curso;
using Proyecto_2.Capas.Acceso_a_datos.Estudiante;
using Proyecto_2.Capas.Acceso_a_datos.Grado;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Grados : System.Web.UI.Page
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
            CargarEstudiantes();
        }

        protected void btn_PanelPrincipal_Editar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = true;
            PanelEliminar.Visible = false;
            CargarGrados();
            CargarCursosParaEditar();
            CargarEstudiantesParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarGradoParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarGradosParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarGrado_Click(object sender, EventArgs e)
        {
            try
            {
                int StudentId = Convert.ToInt32(ddl_IdEstudiantes.SelectedValue.ToString());
                int CourseId = Convert.ToInt32(ddl_IdCursos.SelectedValue.ToString());
                float Grade = float.Parse(TxtGrado.Text);
                string Comment = TxtComentario.Text;

                AC_InsertGrade insert = new AC_InsertGrade();
                string resultado = insert.Insert_Grade( StudentId,  CourseId,  Grade,  Comment);

                if (resultado == "Registro exitoso")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Grado registrado exitosamente.');", true);             
                    TxtGrado.Text = "";
                    TxtComentario.Text = "";
                    
                }
                else if (resultado == "El Grado ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el Grado se encuentra registrada, intente con otra.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el grado.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }
       

        protected void btnInsertarGrado_Cancelar_Click(object sender, EventArgs e)
        {
            TxtGrado.Text = "";
            TxtComentario.Text = "";
            MostralPanelPrincipal();
        }

        //Editar

        private void CargarGrados()
        {
            AC_UpdateGrade grado = new AC_UpdateGrade();
            var listadoGrado = grado.ObtenerGradoEspecifica(0);

            ddl_Grado.DataSource = listadoGrado;
            ddl_Grado.DataValueField = "GradeId";
            ddl_Grado.DataTextField = "Grade";
            ddl_Grado.DataBind();
        }
        protected void ddl_Grado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrado = Convert.ToInt32(ddl_Grado.SelectedValue.ToString());
            AC_UpdateGrade grado = new AC_UpdateGrade();
            var listado = grado.ObtenerGradoEspecifica(idGrado);

            foreach (var item in listado)
            {
                ddl_Grado.Text = item.Grade.ToString();
                ddl_editar_Estudiantes.Text = item.StudentId.ToString();
                ddl_editar_Cursos.Text = item.CourseId.ToString();
                TxtEditar_Grado.Text = item.Grade.ToString();
                TxtEditar_Comentario.Text = item.Comment.ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int vId = Convert.ToInt32(ddl_Grado.SelectedValue.ToString());
            int vStudentId = Convert.ToInt32(ddl_editar_Estudiantes.SelectedValue.ToString());
            int vCourseId = Convert.ToInt32(ddl_editar_Cursos.SelectedValue.ToString());
            float vGrade = float.Parse(TxtEditar_Grado.Text);
            string vComment = TxtEditar_Comentario.Text;
            
            AC_UpdateGrade escuelas = new AC_UpdateGrade();
            escuelas.Update_Grade( vId,  vStudentId,  vCourseId,  vGrade,  vComment);
            TxtEditar_Grado.Text = "";
            TxtEditar_Comentario.Text = "";
            CargarGrados();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Grado editada correctamente.');", true);
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
            int vidGrado = Convert.ToInt32(ddl_EliminarGrado.SelectedValue.ToString());
            AC_DeleteGrade borrar = new AC_DeleteGrade();
            borrar.Delete_Grade(vidGrado);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Grado eliminado.');", true);
            CargarGradoParaEliminar();
        }

        private void CargarGradoParaEliminar()
        {
            AC_UpdateGrade grado = new AC_UpdateGrade();
            var listadoGrado = grado.ObtenerGradoEspecifica(0);

            ddl_EliminarGrado.DataSource = listadoGrado;
            ddl_EliminarGrado.DataValueField = "GradeId";
            ddl_EliminarGrado.DataTextField = "Grade";
            ddl_EliminarGrado.DataBind();
        }
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarGradosParaConsulta()
        {
            AC_UpdateGrade grado = new AC_UpdateGrade();
            var listadoGrado = grado.ObtenerGradoEspecifica(0);

            GVGrados.DataSource = listadoGrado;
            GVGrados.DataBind();
        }

        private void CargarEstudiantes()
        {
            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            var listadoCLases = estudiantes.ObtenerEstudianteEspecifico(0);

            ddl_IdEstudiantes.DataSource = listadoCLases;
            ddl_IdEstudiantes.DataValueField = "StudentId";
            ddl_IdEstudiantes.DataTextField = "StudentName";
            ddl_IdEstudiantes.DataBind();
        }

        private void CargarEstudiantesParaEditar()
        {
            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            var listadoCLases = estudiantes.ObtenerEstudianteEspecifico(0);
            ddl_editar_Estudiantes.DataSource = listadoCLases;
            ddl_editar_Estudiantes.DataValueField = "StudentId";
            ddl_editar_Estudiantes.DataTextField = "StudentName";
            ddl_editar_Estudiantes.DataBind();
        }

        private void CargarCursos()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCLases = cursos.ObtenerCursoEspecifica(0);

            ddl_IdCursos.DataSource = listadoCLases;
            ddl_IdCursos.DataValueField = "CourseId";
            ddl_IdCursos.DataTextField = "CourseName";
            ddl_IdCursos.DataBind();
        }

        private void CargarCursosParaEditar()
        {
            AC_UpdateCourse cursos = new AC_UpdateCourse();
            var listadoCLases = cursos.ObtenerCursoEspecifica(0);
            ddl_editar_Cursos.DataSource = listadoCLases;
            ddl_editar_Cursos.DataValueField = "CourseId";
            ddl_editar_Cursos.DataTextField = "CourseName";
            ddl_editar_Cursos.DataBind();
        }
    }
}
