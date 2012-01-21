using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polendamus.Services
{
    public class ScrapCastillaMancha
    {
        public List<String[]> GetDatos(String URL)
        {
            //Cogemos el HTML en cuestión de polenes.
            Scrapping sc = new Scrapping();
            String html = sc.GetHtml(URL);

            String texto1 = "<tr class=\"odd\">";

            int indexTR = html.IndexOf(texto1);
            html = html.Substring(indexTR + texto1.Length);

            List<String[]> listaDatos = new List<String[]>();
            String comienzo = "_24x24.gif); background-position : left center; background-repeat : no-repeat; padding-left : 24px;\">";
            String fin = "</td>";
            String comienzoNivel = "<td>";
            String finNivel = "<br/><img src";
            while (html.IndexOf(comienzo) != -1)
            {
                int indexInicio = html.IndexOf(comienzo);
                html = html.Substring(indexInicio + comienzo.Length);
                int indexFin = html.IndexOf(fin);
                String[] array = new String[2];
                //El nombre de la planta.
                //Cambiamos el nombre por el id.
                array[0] = GetIdPlanta(html.Substring(0, indexFin).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "")).ToString();

                int indexComienzoNivel = html.IndexOf(comienzoNivel);
                html = html.Substring(indexComienzoNivel + comienzoNivel.Length);
                int indexFinNivel = html.IndexOf(finNivel);
                array[1] = html.Substring(0, indexFinNivel).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "");

                if (!array[0].Equals("0"))
                {
                    listaDatos.Add(array);
                }
            }

            return listaDatos;

        }

        public List<Niveles> GetDatosFromCastillaLaMancha()
        {
            List<Niveles> niveles = new List<Niveles>();

            //Para Albacete.
            List<String[]> listaAlbacete = GetDatos(Constantes.TiposCastillaMancha.urlAlbacete);
            int idProvincia = 2;
            foreach (String[] item in listaAlbacete)
            {
                Niveles niv = new Niveles()
                {
                    Id_Provincia = idProvincia,
                    Id_Planta = int.Parse(item[0]),
                    Descripcion = item[1],
                    Estado = TraducirNiveles(item[1]).ToString()
                };

                niveles.Add(niv);
            }

            //Para Ciudad Real.
            List<String[]> listaCiudadReal = GetDatos(Constantes.TiposCastillaMancha.urlCiudadReal);
            idProvincia = 13;
            foreach (String[] item in listaAlbacete)
            {
                Niveles niv = new Niveles()
                {
                    Id_Provincia = idProvincia,
                    Id_Planta = int.Parse(item[0]),
                    Descripcion = item[1],
                    Estado = TraducirNiveles(item[1]).ToString()
                };

                niveles.Add(niv);
            }

            //Para Cuenca.
            List<String[]> listaCuenca = GetDatos(Constantes.TiposCastillaMancha.urlCuenca);
            idProvincia = 16;
            foreach (String[] item in listaAlbacete)
            {
                Niveles niv = new Niveles()
                {
                    Id_Provincia = idProvincia,
                    Id_Planta = int.Parse(item[0]),
                    Descripcion = item[1],
                    Estado = TraducirNiveles(item[1]).ToString()
                };

                niveles.Add(niv);
            }

            //Para Guadalajara.
            List<String[]> listaGuadalajara = GetDatos(Constantes.TiposCastillaMancha.urlGuadalajara);
            idProvincia = 19;
            foreach (String[] item in listaAlbacete)
            {
                Niveles niv = new Niveles()
                {
                    Id_Provincia = idProvincia,
                    Id_Planta = int.Parse(item[0]),
                    Descripcion = item[1],
                    Estado = TraducirNiveles(item[1]).ToString()
                };

                niveles.Add(niv);
            }

            //Para Toledo.
            List<String[]> listaToledo = GetDatos(Constantes.TiposCastillaMancha.urlToledo);
            idProvincia = 45;
            foreach (String[] item in listaAlbacete)
            {
                Niveles niv = new Niveles()
                {
                    Id_Provincia = idProvincia,
                    Id_Planta = int.Parse(item[0]),
                    Descripcion = item[1],
                    Estado = TraducirNiveles(item[1]).ToString()
                };

                niveles.Add(niv);
            }

            return niveles;
        }

        private int GetIdPlanta(String nombrePlanta)
        {
            if (nombrePlanta.Equals("Acederas, Vinagreras (Rumex)"))
            {
                return 5;
            }
            else if (nombrePlanta.Equals("Gram??neas"))
            {
                return 1;
            }
            else if (nombrePlanta.Equals("Olivo"))
            {
                return 14;
            }
            else if (nombrePlanta.Equals("Cipr??s-Ariz??nicas"))
            {
                return 3;
            }
            else if (nombrePlanta.Equals("Alternaria"))
            {
                return 22;
            }
            else if (nombrePlanta.Equals("Ortigas-parietaria"))
            {
                return 8;
            }
            else if (nombrePlanta.Equals("Encinas, quejigos,... (Quercus)"))
            {
                return 13;
            }
            else if (nombrePlanta.Equals("Llantenes"))
            {
                return 20;
            }
            else if (nombrePlanta.Equals("Pinos"))
            {
                return 15;
            }
            return 0;
        }

        private int TraducirNiveles(String nivel)
        {
            if (nivel.Equals("Nulo"))
            {
                return Enums.ValoresPolen.Nulo;
            }
            else if (nivel.Equals("Bajo"))
            {
                return Enums.ValoresPolen.Bajo;
            }
            else if (nivel.Equals("Bajo / Medio"))
            {
                return Enums.ValoresPolen.Medio;
            }
            else if (nivel.Equals("Medio"))
            {
                return Enums.ValoresPolen.Medio;
            }
            else if (nivel.Equals("Medio / Alto"))
            {
                return Enums.ValoresPolen.Alto;
            }
            else if (nivel.Equals("Alto"))
            {
                return Enums.ValoresPolen.Alto;
            }
            else if (nivel.Equals("Alto / Muy alto"))
            {
                return Enums.ValoresPolen.MuyAlto;
            }
            else if (nivel.Equals("Muy alto"))
            {
                return Enums.ValoresPolen.MuyAlto;
            }
            return Enums.ValoresPolen.Nulo;
        }
    }
}
