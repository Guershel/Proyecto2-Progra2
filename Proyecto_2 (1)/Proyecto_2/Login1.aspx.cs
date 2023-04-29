using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIngresar_Click1(object sender, EventArgs e)
        {

            if (Login.ValidarUsuario(TUsuario.Text, TPassword.Text) > 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lmensaje.Text = "Usuario no existe.";
            }

        }

        
    }
}