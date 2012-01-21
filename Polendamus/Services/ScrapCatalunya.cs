using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polendamus.Services
{
    public class ScrapCatalunya
    {
        public List<String[]> GetDatos(String URL)
        {
            //Cogemos el HTML en cuestión de polenes.
            Scrapping sc = new Scrapping();
            String html = sc.GetHtml(URL);

            String texto1 = "<th class=\"ttitol\">";

            int indexTR = html.IndexOf(texto1);
            html = html.Substring(indexTR + texto1.Length);

            List<String[]> listaDatos = new List<String[]>();
            String comienzoPlanta = "<td class=\"taxon\">";
            String finPlanta = "(<cite>";
            String inicioNivel = "</td><td>";
            String finNivel = "<td class=\"coldreta\">";
            while (html.IndexOf(comienzoPlanta) != -1)
            {
                int indexInicioPlanta = html.IndexOf(comienzoPlanta);
                html = html.Substring(indexInicioPlanta + comienzoPlanta.Length);
                int indexFinPlanta = html.IndexOf(finPlanta);
                String[] array = new String[9];
                //El nombre de la planta.
                //Cambiamos el nombre por el id.
                String prueba = html.Substring(0, indexFinPlanta).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
                array[0] = GetIdPlanta(prueba).ToString();

                int i = 1;
                while (html.IndexOf(inicioNivel) != -1)
                {
                    //Los distintos valores.
                    int indexInicioNivel = html.IndexOf(inicioNivel);
                    html = html.Substring(indexInicioNivel + inicioNivel.Length);
                    int indexFinNivel = html.IndexOf(finNivel);
                    String pruebaNivel = html.Substring(0, indexFinNivel).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "").Replace("</td>", "").Replace(" ", "");
                    array[i] = pruebaNivel;
                    i++;

                    if (i == array.Length)
                    {
                        break;
                    }
                }

                listaDatos.Add(array);
            }

            return listaDatos;

        }

        public List<Niveles> GetDatosFromCatalunya()
        {
            String URL = "http://lap.uab.cat/aerobiologia/es/forecast/catalunya";
            List<Niveles> listaNiveles = new List<Niveles>();
            List<String[]> lista = new List<String[]>();

            lista = GetDatos(URL);

            foreach (String[] item in lista)
            {
                Niveles nivelBarcelona = new Niveles()
                {
                    Id_Provincia = 8,
                    Id_Planta = int.Parse(item[0]),
                    Estado = (int.Parse(item[Constantes.TiposCatalunya.indiceBarcelona]) + 1).ToString(),
                    Descripcion = (int.Parse(item[Constantes.TiposCatalunya.indiceBarcelona]) + 1).ToString() 
                };

                if (nivelBarcelona.Id_Planta != -1)
                {
                    listaNiveles.Add(nivelBarcelona);
                }

                Niveles nivelGerona = new Niveles()
                {
                    Id_Provincia = 17,
                    Id_Planta = int.Parse(item[0]),
                    Estado = (int.Parse(item[Constantes.TiposCatalunya.indiceGerona]) + 1).ToString(),
                    Descripcion = (int.Parse(item[Constantes.TiposCatalunya.indiceGerona]) + 1).ToString() 
                };

                if (nivelGerona.Id_Planta != -1)
                {
                    listaNiveles.Add(nivelGerona);
                }

                Niveles nivelLerida = new Niveles()
                {
                    Id_Provincia = 25,
                    Id_Planta = int.Parse(item[0]),
                    Estado = (int.Parse(item[Constantes.TiposCatalunya.indiceLerida]) + 1).ToString(),
                    Descripcion = (int.Parse(item[Constantes.TiposCatalunya.indiceLerida]) + 1).ToString() 
                };

                if (nivelLerida.Id_Planta != -1)
                {
                    listaNiveles.Add(nivelLerida);
                }

                Niveles nivelTarragona = new Niveles()
                {
                    Id_Provincia = 43,
                    Id_Planta = int.Parse(item[0]),
                    Estado = (int.Parse(item[Constantes.TiposCatalunya.indiceTarragona]) + 1).ToString(),
                    Descripcion = (int.Parse(item[Constantes.TiposCatalunya.indiceTarragona]) + 1).ToString() 
                };

                if (nivelTarragona.Id_Planta != -1)
                {
                    listaNiveles.Add(nivelTarragona);
                }
            }

            return listaNiveles;
        }

        public int GetIdPlanta(String nombrePlanta)
        {
            if (nombrePlanta == "Parietaria")
            {
                return 8;
            }
            else if (nombrePlanta == "Gram?neas")
            {
                return 1;
            }
            else if (nombrePlanta == "Olivo")
            {
                return 14;
            }
            else if (nombrePlanta == "Abedul")
            {
                return 10;
            }
            else if (nombrePlanta == "C??igos")
            {
                return -1;
            }
            else if (nombrePlanta == "Chopo")
            {
                return 18;
            }
            else if (nombrePlanta == "Cipreses")
            {
                return 3;
            }
            else if (nombrePlanta == "Cruc?feras(Brasic?ceas)")
            {
                return -1;
            }
            else if (nombrePlanta == "Fresno")
            {
                return 12;
            }
            else if (nombrePlanta == "Haya")
            {
                return -1;
            }
            else if (nombrePlanta == "Llant?n")
            {
                return 20;
            }
            else if (nombrePlanta == "Mercurial")
            {
                return 6;
            }
            else if (nombrePlanta == "Moreras")
            {
                return 7;
            }
            else if (nombrePlanta == "Palmeras")
            {
                return -1;
            }
            else if (nombrePlanta == "Pino")
            {
                return 15;
            }
            else if (nombrePlanta == "Pl?tano")
            {
                return 2;
            }
            else if (nombrePlanta == "Poligon?ceastotales")
            {
                return -1;
            }
            else if (nombrePlanta == "Roble/Encina")
            {
                return 13;
            }
            else if (nombrePlanta == "Sauce")
            {
                return -1;
            }
            else if (nombrePlanta == "Alternaria")
            {
                return 22;
            }
            else if (nombrePlanta == "Cladosporium")
            {
                return -1;
            }

            return 0;
        }
    }
}
