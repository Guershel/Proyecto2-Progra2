using Proyecto_2.Capas.Acceso_a_datos.Clase;
using Proyecto_2.Capas.Acceso_a_datos.Estudiante;
using Proyecto_2.Capas.Acceso_a_datos.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2.Capas.Presentacion
{
    public partial class Mantenimiento_Estudiante : System.Web.UI.Page
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
            CargarClases();
        }

        protected void btn_PanelPrincipal_Editar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = true;
            PanelEliminar.Visible = false;
            CargarEstudiantes();
            CargarClasesParaEditar();
        }

        protected void btn_PanelPrincipal_Eliminar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = false;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = true;
            CargarEstudiantesParaEliminar();
        }

        protected void btn_PanelPrincipal_Consultar_Click(object sender, EventArgs e)
        {
            PanelPrincipaL.Visible = false;
            PanelAgregar.Visible = false;
            PanelConsultar.Visible = true;
            PanelEditar.Visible = false;
            PanelEliminar.Visible = false;
            CargarEstudiantesParaConsulta();
        }

        //CODIGO PARA LOS MANTENIMIENTOS

        //INSERTAR
        protected void btnInsertarEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                int classId = Convert.ToInt32(ddl_IdClase.SelectedValue.ToString());
                string studentName = TxtNombreEstudiante.Text;
                string studentNumber = TxtNumeroEstudiante.Text;
                string totalGrade = TxtCalificacion.Text;
                string address = TxtDirreccion.Text;
                string phone = TxtTelefono.Text;
                string email = TxtEmail.Text;

                AC_InsertStudent insert = new AC_InsertStudent();
                string resultado = insert.Insert_Student( classId,  studentName,  studentNumber,  totalGrade,
                 address,  phone,  email);

                if (resultado == "Registro exitoso")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Estudiante registrado exitosamente.');", true);

                    TxtNombreEstudiante.Text = "";
                    TxtNumeroEstudiante.Text = "";
                    TxtCalificacion.Text = "";
                    TxtDirreccion.Text = "";
                    TxtTelefono.Text = "";
                    TxtEmail.Text = "";
                }
                else if (resultado == "El estudiante ya existe.")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Ya el estudiante se encuentra registrado, intente con otro.');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error al registrar el Estudiante.');", true);
                    return;
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Error');", true);
                return;
            }
        }

        protected void btnInsertarEstudiante_Cancelar_Click(object sender, EventArgs e)
        {
           
            TxtNombreEstudiante.Text = "";
            TxtNumeroEstudiante.Text = "";
            TxtCalificacion.Text = "";
            TxtDirreccion.Text = "";
            TxtTelefono.Text = "";
            TxtEmail.Text = "";
            MostralPanelPrincipal();
        }

        //Editar

        private void CargarEstudiantes()
        {
            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            var listadoEstudiantes = estudiantes.ObtenerEstudianteEspecifico(0);

            ddl_Estudiantes.DataSource = listadoEstudiantes;
            ddl_Estudiantes.DataValueField = "StudentId";
            ddl_Estudiantes.DataTextField = "StudentName";
            ddl_Estudiantes.DataBind();
        }
        protected void ddl_Estudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEstudiante = Convert.ToInt32(ddl_Estudiantes.SelectedValue.ToString());
            AC_UpdateStudent estudiante = new AC_UpdateStudent();
            var listado = estudiante.ObtenerEstudianteEspecifico(idEstudiante);

            foreach (var item in listado)
            {
                ddl_Estudiantes.Text = item.StudentId.ToString();
                TxtEditar_NombreEstudiante.Text = item.StudentName.ToString();
                TxtEditar_NumeroEstudiante.Text = item.StudentNumber.ToString();
                TxtEditar_Calificacion.Text = item.TotalGrade.ToString();
                TxtEditar_Direccion.Text = item.Address.ToString();
                TxtEditar_Telefono.Text = item.Phone.ToString();
                TxtEditar_Email.Text = item.Email.ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int vId = Convert.ToInt32(ddl_Estudiantes.SelectedValue.ToString());
            int vclassId = Convert.ToInt32(ddl_Editar_IdClase.SelectedValue.ToString());
            string vstudentName = TxtEditar_NombreEstudiante.Text;
            string vstudentNumber = TxtEditar_NumeroEstudiante.Text;
            string vtotalGrade = TxtEditar_Calificacion.Text;
            string vaddress = TxtEditar_Direccion.Text;
            string vphone = TxtEditar_Telefono.Text;
            string vemail = TxtEditar_Email.Text;

            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            estudiantes.Update_Student( vId,  vclassId,  vstudentName,  vstudentNumber,  vtotalGrade,
             vaddress,  vphone,  vemail);      
               
                TxtEditar_NombreEstudiante.Text = "";
                TxtEditar_NumeroEstudiante.Text = "";
                TxtEditar_Calificacion.Text = "";
                TxtEditar_Direccion.Text = "";
                TxtEditar_Telefono.Text = "";
                TxtEditar_Email.Text = "";
                CargarEstudiantes();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Estudiante editada correctamente.');", true);
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
            AC_DeleteStudent borrar = new AC_DeleteStudent();
            borrar.Delete_Student(vidEstudiante);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "alert('Estudiante eliminado.');", true);
            CargarEstudiantesParaEliminar();
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
        //PARA CONSULTAR
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            MostralPanelPrincipal();
        }

        private void CargarEstudiantesParaConsulta()
        {
            AC_UpdateStudent estudiantes = new AC_UpdateStudent();
            var listadoEstudiante = estudiantes.ObtenerEstudianteEspecifico(0);

            GVEstudiantes.DataSource = listadoEstudiante;
            GVEstudiantes.DataBind();
        }
        
            private void CargarClases()
        {
            AC_UpdateClass clases = new AC_UpdateClass();
            var listadoCLases = clases.ObtenerClaseEspecifica(0);

            ddl_IdClase.DataSource = listadoCLases;
            ddl_IdClase.DataValueField = "ClassId";
            ddl_IdClase.DataTextField = "ClassName";
            ddl_IdClase.DataBind();
        }

        private void CargarClasesParaEditar()
        {
            AC_UpdateClass clases = new AC_UpdateClass();
            var listadoCLases = clases.ObtenerClaseEspecifica(0);

            ddl_Editar_IdClase.DataSource = listadoCLases;
            ddl_Editar_IdClase.DataValueField = "ClassId";
            ddl_Editar_IdClase.DataTextField = "ClassName";
            ddl_Editar_IdClase.DataBind();
        }

    }
}