<%@ Page Title="Cartelera" Language="C#" MasterPageFile="~/MasterPageCinemix.master" AutoEventWireup="true" CodeFile="CinePeliculas.aspx.cs" Inherits="CinePeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="nomCine">
        <asp:Label ID="lblCine" runat="server" Text="Cine"></asp:Label>
    </div>

    <div style="height: 400px; width: 100%; overflow: scroll;">
        <asp:ListView runat="server" ID="lvPeliculas" 
            OnItemCommand="lvPeliculas_ItemCommand" DataKeyNames="IdCinePelicula">
            <ItemTemplate>
                <table id="tablaPeliculas">
                    <colgroup>
                        <col id ="c1Pelicula" />
                        <col class ="cxPelicula" />
                        <col class ="cxPelicula" />
                        <col class ="cxPelicula" />
                    </colgroup>
                    <tr>
                        <td rowspan="3">
                            <asp:Image ID="imgPelicula" runat="server" 
                                ImageUrl='<%# "Imagenes/Peliculas/" + Eval("ArchivoImg")%>' CssClass="aspImg" />
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblPelicula" runat="server" CssClass="aspTitulo"><%# Eval("Titulo")%></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblSinopsis" runat="server" CssClass="aspSinopsis"><%# Eval("Sinopsis")%></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <!-- Agregar un control de tipo Label para que aparezca la clasificación de la pelicula 
                                 Sigue los ejemplos de los demas datos que se muestran en esta página-->
                            <asp:Label ID="IblClasificacion" runat="server" CssClass="aspClasificacion"><%# Eval("Clasificacion")%></asp:Label>
                        </td>
                        <td>
                            <!-- Agregar un control de tipo Label para que aparezca la duracion de la pelicula 
                                Sigue los ejemplos de los demas datos que se muestran en esta página-->
                            <asp:Label ID="IblDuracion" runat="server" CssClass="aspDuracion"><%# Eval("Duracion")%></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="BtnCompra" runat="server" Text="Boletos" CommandName="CompraBoletos" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

