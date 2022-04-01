using System;
using System.Web.UI.WebControls;
using BaseDatosCinemix;

public partial class CinePeliculas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //La página que invoca a ésta webform envia un dato: idCine
            int idCine = Convert.ToInt32(Request.QueryString["idCine"]);  //se obtiene el dato idCine 

            //Invoca al metodo de DataManager que corresponda para obtener el nombre del cine para el idCine que se
            //acaba de obtener. Asígnalo a la propiedad correspondiente del control lblCine Done
            lblCine.Text = DataManager.GetNomCine(idCine);



            //Invoca al metodo de DataManager que corresponda para obtener todas las peliculas que tiene un cine
            //de acuerdo a su idCine. Asgnalo al DataSource del listview Done
            lvPeliculas.DataSource = DataManager.GetPeliculasDelCine(idCine);
            lvPeliculas.DataBind();
        }
    }

    protected void lvPeliculas_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "CompraBoletos")
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;

            int idCinePel;
            idCinePel = Convert.ToInt32(lvPeliculas.DataKeys[dataItem.DisplayIndex]["IdCinePelicula"].ToString());

            //Se dirige a una nueva pagina llamada ReservaBoletos y se le envía el idCinePel de la pelicula seleccionada en la cartelera
            Response.Redirect("ReservaBoletos.aspx?idCinePelicula=" + idCinePel);
        }
    }

}
