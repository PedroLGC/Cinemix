
using System;
using System.Web.UI.WebControls;
using BaseDatosCinemix;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCiudad.DataSource = DataManager.GetCiudades();
            ddlCiudad.DataValueField = "idCiudad";
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("Selecciona la ciudad", ""));
            ddlCiudad.Items[0].Selected = true;
        }       
    }

    protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
            ddlCine.Enabled = true;
            int ciudad = Convert.ToInt32(ddlCiudad.SelectedValue);

            /* Agrega el codifo faltante aqui:
             * 1)Invoca al método GetCines de la clase DataManager 
             * pasando como parametro el id de cuiudad que se acaba de obtener
             * en la linea anterior (la ciudad seleccionada del DropDownList).
             * Lo que devuelve el metodo GetCines asignalo a la propiedad DataSource
             * del DropDownList del cine: ddlCine
             * 
             * 2)Despues asigna el string "idCine" y "nombre" a la propiedad de DataValueField y
             * a la propiedad DaataField respectivamente.
             * 
             * 3)Invoca al metodo DataBind del control ddlCine
             */

            ddlCine.Items.Insert(0, new ListItem("Selecciona el cine", ""));
            ddlCine.Items[0].Selected = true;   
    }

    protected void ddlCine_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Se transfiere a la página CinePeliculas
        //Se envía a esa página el id del cine seleccionado
        Response.Redirect("CinePeliculas.aspx?idCine=" + ddlCine.SelectedValue);
    }
}



