<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>
<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <table width="75%" align="center">
        <tr>
            <td>
                <p align="justify" style="font-family: Calibri; font-size: medium">
                    “Polendamus: el oráculo del polen” es un proyecto desarrollado dentro de la iniciativa
                    AbreDatos, una manifestación proactiva a favor de la apertura de datos públicos.
                    El objetivo del mismo es reunir un equipo de 4 personas que durante 48 horas desarrolle
                    una aplicación ejecutable basada en datos en abierto, además de predisponer el plan
                    de promoción.
                </p>
                <p align="justify" style="font-family: Calibri; font-size: medium">
                    Nuestro equipo formado por Eduardo, Victor, Adriana y Juan, ha centrado su trabajo
                    alrededor de las alergias al polen. Nuestra intención, presentar un visualizador
                    intuitivo y divertido del estado actual de la concentración de polen así como la
                    previsión de mañana, en relación al cruce de la densidad de polen en el aire(situación
                    actual) con las previsiones meteorológicas del día siguiente(situación futura- más
                    viento, más lluvia menos polen :-) // más sol, menos aire, no lluvia más polen :-(
                    ). Utilizando la base de imágenes de Thinkers Co. realizados por nuestro amigo Rafa,
                    se construye la personalidad de la aplicación. El objetivo final, desarrollar una
                    aplicación que mas allá de los menús desplegables y las páginas “frías” e “insípidas”
                    de consulta actuales, se centre en proporcionar un método de visualización rápido,
                    intuitivo, divertido, social… en definitiva, un nuevo modelo de consulta de los
                    niveles de polen, apto para mayores como para niños.
                </p>
                <p align="justify" style="font-family: Calibri; font-size: medium">
                    A su vez, la aplicación dispone de un cruce de los datos de polen con una segunda
                    tabla de datos de meteorología, con el objeto de dotar a los usuarios de una previsión
                    estimada de subida o bajada de los niveles. Para ello, hemos optado por mezclarlo
                    en la versión actual BETA1.0 con las precipitaciones del día siguiente de lluvia,
                    un indicador aproximado de la evolución de los mismo aumenta (correlación estimada):
                    cuando llueve el polen bajo, si el ambiente está seco.
                </p>
            </td>
        </tr>
    </table>
    <br />
    <table width="75%" align="center">
        <tr>
            <td align="center">
                <a target="_blank" href="https://www.facebook.com/pages/Polendamus/185335544847974">
                    <img src="../../Content/Images/boton_fb.png" width="75px" height="125px" /></a>
            </td>
            <td align="center">
                <a target="_blank" href="http://www.scalabble.com/">
                    <img src="../../Content/Images/logoScalabble.png" width="120px" height="120px" /></a>
            </td>
            <td align="center">
                <a target="_blank" href="http://polendamus.tumblr.com/">
                    <img src="../../Content/Images/iconomedio.jpg" width="120px" height="120px" /></a>
            </td>
            <td align="center">
                <a target="_blank" href="http://www.abredatos.es/">
                    <img src="../../Content/Images/logoAbreDatos.png" width="120px" height="120px" /></a>
            </td>
            <td align="center">
                <a target="_blank" href="http://www.thinkersco.com/">
                    <img src="../../Content/Images/logoThinkersco.jpg" width="180px" height="38px" /></a>
            </td>
            <td align="center">
                <a target="_blank" href="http://twitter.com/Polendamus">
                    <img src="../../Content/Images/boton_tw.png" width="75px" height="125px" /></a>
            </td>
        </tr>
    </table>
</asp:Content>
