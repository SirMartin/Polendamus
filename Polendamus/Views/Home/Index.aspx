<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Polendamus.Models.PolenModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Polendamus: Tu oráculo del polen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <%if (ViewData["MessageWarning"] != null)
      { %>
    <h2>
        <%: ViewData["MessageWarning"]%></h2>
    <%} %>
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Change the image of hoverable images
            $(".imgHoverable").hover(function () {
                var hoverImg = HoverImgOf($(this).attr("src"));
                $(this).attr("src", hoverImg);
            }, function () {
                var normalImg = NormalImgOf($(this).attr("src"));
                $(this).attr("src", normalImg);
            }
   );
        });

        function HoverImgOf(filename) {
            var re = new RegExp("(.+)\\.(gif|png|jpg)", "g");
            return filename.replace(re, "$1_hover.$2");
        }
        function NormalImgOf(filename) {
            var re = new RegExp("(.+)_hover\\.(gif|png|jpg)", "g");
            return filename.replace(re, "$1.$2");
        }
    </script>
    <table width="100%">
        <tr>
            <td width="12%">
                <img src="/Content/Images/Personajes/<%: ViewData["ImgPersona1"] %>.png" alt="Nivel de polen actual." />
            </td>
            <td style="background-image: url('/Content/Images/bocadillo 2 alargado.png'); text-align: center;
                font-family: Comic Sans MS; font-size: medium; background-repeat: no-repeat;"
                width="400px" height="210px">
                <table width="100%">
                    <tr>
                        <td width="15%">
                        </td>
                        <td width="60%" align="center">
                            <%:Html.Label(Model.Bocadillo1)%>
                        </td>
                        <td width="25%">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20%">
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="35%">
                <table>
                    <tr>
                        <td>
                            Provincias:
                        </td>
                        <td>
                            <%  List<Polendamus.Provincias> provincias = (List<Polendamus.Provincias>)ViewData["Provincias"];%>
                            <%: Html.DropDownListFor(model => model.Provincia, new SelectList(provincias, "Nombre", "Nombre"), new { style = "width:200px;height:25px; font-size:small" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipos de Alergias:
                        </td>
                        <td>
                            <%  List<Polendamus.Alergias> alergias = (List<Polendamus.Alergias>)ViewData["Alergias"];%>
                            <%: Html.DropDownListFor(model => model.Alergia, new SelectList(alergias, "Nombre", "Nombre"), new { style = "width:200px;height:25px; font-size:small" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input id="boton" type="image" class="imgHoverable" src="../../Content/Images/buscar.png" />
                        </td>
                        <td>
                        <% 
                            if (ViewData["Twitter"] != null)
                           { %>
                        <a href="http://twitter.com/home?status= <%: ViewData["Twitter"] %>"><img src= "../../Content/Images/twitter.jpg" style="height:25px; width:25px" title="Comparte el nivel de polen con tus amigos en Twitter"/></a>
                        <a href="javascript: void(0);" onclick="window.open('http://www.facebook.com/sharer.php?u=http://www.polendamus.com/','ventanacompartir', 'toolbar=0, status=0, width=650, height=450');"><img src= "../../Content/Images/facebook.png" style="height:25px; width:25px" title="Comparte el nivel de polen con tus amigos en Facebook"/></a>
                        <%}
                           else
                           {%>
                           <img src= "../../Content/Images/twitter.jpg" style="height:25px; width:25px" title="Comparte el nivel de polen con tus amigos en Twitter"/>
                           <img src= "../../Content/Images/facebook.png" style="height:25px; width:25px" title="Comparte el nivel de polen con tus amigos en facebook"/>
                        <%} %>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="background-image: url('/Content/Images/bocadillo 1 alargado.png'); text-align: center;
                font-family: Comic Sans MS; font-size: medium; background-repeat: no-repeat;"
                width="400px" height="250px">
                <table width="100%">
                    <tr>
                        <td width="15%">
                        </td>
                        <td width="70%" align="center">
                            <%:Html.Label(Model.Bocadillo2)%>
                        </td>
                        <td width="15%">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="20%">
                <img src="/Content/Images/Personajes/<%: ViewData["ImgPersona2"] %>.png" alt="Previsión del polen de mañana." />
            </td>
        </tr>
    </table>
    <% }%>
</asp:Content>
