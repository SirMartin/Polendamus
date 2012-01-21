using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polendamus.Constantes;

namespace Polendamus.Services
{
    public class ScrapElTiempo
    {
        public List<String[]> GetDatos(String URL)
        {
            //Cogemos el HTML en cuestión de polenes.
            Scrapping sc = new Scrapping();
            String html = sc.GetHtml(URL);

            String texto1 = "<th class=\"level\">Nivel</th>";

            int indexTR = html.IndexOf(texto1);
            html = html.Substring(indexTR + texto1.Length);

            List<String[]> listaDatos = new List<String[]>();
            String comienzo = "<td class=\"type\">";
            String fin = "</td>";
            String comienzoNivel = "<td class=\"level\"><strong class=\"";
            String finNivel = "\">";
            while (html.IndexOf(comienzo) != -1)
            {
                int indexInicio = html.IndexOf(comienzo);
                html = html.Substring(indexInicio + comienzo.Length);
                int indexFin = html.IndexOf(fin);
                String[] array = new String[2];
                //El nombre de la planta.
                //Cambiamos el nombre por el id.
                array[0] = TipoElTiempo.GetIdPlanta(html.Substring(0, indexFin).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "")).ToString();

                int indexComienzoNivel = html.IndexOf(comienzoNivel);
                html = html.Substring(indexComienzoNivel + comienzoNivel.Length);
                int indexFinNivel = html.IndexOf(finNivel);
                array[1] = html.Substring(0, indexFinNivel).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "");

                if ((array[0] != "-1") && (array[1] != ""))
                {
                    listaDatos.Add(array);
                }
            }

            return listaDatos;
        }

        public List<Niveles> GetDatosFromElTiempo()
        {
            List<Niveles> niveles = new List<Niveles>();
            List<String> listaUrls = Constantes.TipoElTiempo.GetAllUrls();

            foreach (String url in listaUrls)
            {
                List<String[]> lista = GetDatos(url);

                foreach (String[] item in lista)
                {
                    Niveles niv = new Niveles()
                    {
                        Id_Provincia = TipoElTiempo.GetIdProvincia(url),
                        Id_Planta = int.Parse(item[0]),
                        Descripcion = item[1],
                        Estado = TipoElTiempo.GetEstado(item[1]).ToString()
                    };

                    niveles.Add(niv);
                }
            }

            return niveles;
        }
    }
}