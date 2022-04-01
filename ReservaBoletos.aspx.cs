using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BaseDatosCinemix;

public partial class CompraBoletos : System.Web.UI.Page
{
    InfoCinePelicula pelicula;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int idCinePeli = Convert.ToInt32(Request.QueryString["idCinePelicula"]);
            pelicula = DataManager.GetPelicula(idCinePeli);
            lblPelicula.Text = pelicula.Titulo;
            lblPelicula.CssClass = "styTitCompra";
            imgPelicula.ImageUrl = "Imagenes/Peliculas/" + pelicula.ArchivoImg;
            lblClasificacion.Text = pelicula.Clasificacion;
            lblDuracion.Text = pelicula.Duracion.ToString() + " min";

            List<string> horarios = DataManager.GetHorarios(idCinePeli);
            int i = 0;

            foreach (var h in horarios)
            {
                radHorarios.Items.Add(new ListItem(h, i.ToString()));
                i++;
            }
            radHorarios.Items[0].Selected = true;

            txtBolAdulto.Text = "0";
            txtBolNiño.Text = "0";
            txtBol3aEdad.Text = "0";

        }
    }

    /// <summary>
    /// Se simula la reserva de boletos de una pelicula
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReserva_Click(object sender, EventArgs e)
    {

        //Completa el método para calcular el total de la reserva
        //de acuerdo a la cantidad seleccionada de boletos en las
        //cajas de texto

        //Si el total es mayor a cero, muestra en el control lblInfoReserva el mensaje correspondiente
        //a la reserva indicando el total, de lo contrario muestra un mensaje indicando que se deben seleccionar los boletos.
                int total = Convert.ToInt32(txtBolAdulto.Text)*70 + Convert.ToInt32(txtBolNiño.Text)*54 + 
            Convert.ToInt32(txtBol3aEdad.Text)*50;

        string msg;

        string time  = "";

        for (int i = 0; i < radHorarios.Items.Count; i++)
        {
            if (radHorarios.Items[i].Selected == true)
            {
                time = radHorarios.Items[i].Text;
            }
        }

        if (total == 0)
        {
            msg = "No se seleccionarons boletos";
        }
        else
        {
            msg = "Tus boletos han sido reservados a las " + time + " hrs. Pagarás en el cine: $" + total.ToString()
            + "<br><br>¡Qué disfrutes la película!";
        }
        
        lblInfoReserva.Text = msg;

        pnlReserva.Visible = true;

    }


    /// <summary>
    /// Incrementa en uno la cantidad de boletos de una categoria:
    /// Adulto, niño o 3a edad.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIncrementa(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        int nBol;

        if (btn.ID == "btnMasAdulto")
        {
            nBol = Convert.ToInt32(txtBolAdulto.Text);
        }
        else if (btn.ID == "btnMasNiño")
        {
            nBol = Convert.ToInt32(txtBolNiño.Text);
        }
        else
        {
            nBol = Convert.ToInt32(txtBol3aEdad.Text);
        }

        ++nBol;
        if (nBol > 10)
        {
            nBol = 10;
        }

        if (btn.ID == "btnMasAdulto")
        {
            txtBolAdulto.Text = nBol.ToString();
        }
        else if (btn.ID == "btnMasNiño")
        {
            txtBolNiño.Text = nBol.ToString();
        }
        else
        {
            txtBol3aEdad.Text = nBol.ToString();
        }

    }

    /// <summary>
    /// Decrementa en uno la cantidad de boletos de una categoria:
    /// Adulto, niño o 3a edad.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDecrementa(object sender, EventArgs e)
    {
        //Completa el metodo para decrementar uno a uno la cantidad de boletos
        //Si la cantidad es negativa el valor de la caja de texto debe quedar en cero
                Button btn = sender as Button;

        int nBol;

        if (btn.ID == "btnMenosAdulto")
        {
            nBol = Convert.ToInt32(txtBolAdulto.Text);
        }
        else if (btn.ID == "btnMenosNiño")
        {
            nBol = Convert.ToInt32(txtBolNiño.Text);
        }
        else
        {
            nBol = Convert.ToInt32(txtBol3aEdad.Text);
        }

        --nBol;
        if (nBol < 0)
        {
            nBol = 0;
        }

        if (btn.ID == "btnMenosAdulto")
        {
            txtBolAdulto.Text = nBol.ToString();
        }
        else if (btn.ID == "btnMenosNiño")
        {
            txtBolNiño.Text = nBol.ToString();
        }
        else
        {
            txtBol3aEdad.Text = nBol.ToString();
        }

    }
}
