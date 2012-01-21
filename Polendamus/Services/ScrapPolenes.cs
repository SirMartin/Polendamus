using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polendamus.Constantes;
using Polendamus.Enums;
using Polendamus.Repositories;

namespace Polendamus.Services
{
    public class ScrapPolenes
    {
        public List<String[]> GetDatos(String URL)
        {
            //Cogemos el HTML en cuestión de polenes.
            Scrapping sc = new Scrapping();
            String html = sc.GetHtml(URL);

            //
            int indexTR = html.IndexOf("<TR>");
            html = html.Substring(indexTR + 4);

            indexTR = html.IndexOf("<TR>");
            html = html.Substring(indexTR + 4);

            indexTR = html.IndexOf("<TR>");
            html = html.Substring(indexTR + 4);
            //Este es el index donde empiezan los datos de cada ciudad.
            indexTR = html.IndexOf("<TR>");

            List<String[]> listaDatos = new List<String[]>();

            while (html.IndexOf("<TR>") != 0)
            {
                int i = 0;
                String[] array = new String[8];
                while (html.IndexOf("<TD><p class=\"p\">") != 0)
                {
                    String empieza = "<TD><p class=\"p\">";
                    int empiezaTD = html.IndexOf(empieza);
                    String fin = "</p></TD>";
                    int finTD = html.IndexOf(fin);
                    String nivel = html.Substring(empiezaTD + empieza.Length, finTD - empiezaTD - empieza.Length).Replace("&nbsp;", "").Replace("\n", "").Replace("\t", "");
                    nivel.Replace("<B><FONT COLOR=\"#ff0000\">", "").Replace("</FONT></B>", "");
                    array[i] = nivel;
                    html = html.Substring(finTD + fin.Length);
                    i++;
                    if (i == array.Length - 1)
                    {
                        break;
                    }
                }

                listaDatos.Add(array);

                if (html.IndexOf("<TR>") != -1)
                {
                    int ind = html.IndexOf("<TR>") + 4;
                    html = html.Substring(ind);
                }
                else
                {
                    break;
                }
            }

            return listaDatos;

        }

        public List<Niveles> GetDatosFromPolenes()
        {
            List<Niveles> niveles = new List<Niveles>();
            List<String> listaUrls = Constantes.TiposPolenes.GetAllUrls();

            foreach (String tipoPlanta in listaUrls)
            {
                String url = TiposPolenes.urlPolenes1 + tipoPlanta + TiposPolenes.urlPolenes2;
                List<String[]> lista = GetDatos(url);

                foreach (String[] item in lista)
                {
                    Niveles niv = new Niveles()
                    {
                        Id_Provincia = TiposPolenes.GetIdProvincia(item[0]),
                        Id_Planta = TiposPolenes.GetIdPlanta(tipoPlanta),
                        Descripcion = item[5], //item[6]
                        Estado = CalculaEstado(TiposPolenes.GetIdPlanta(tipoPlanta), item[5])
                    };

                    if (niv.Id_Provincia != -1)
                    {
                        niveles.Add(niv);
                    }
                }
            }


            return niveles;
        }

        public string CalculaEstado(int idPlanta, String nivel)
        {
            string descripcion = "";
            AlergiasRepository AlergiasRep = new AlergiasRepository();
            AlergiasRep.DBContext = new polendamusEntities();
            Alergias alergia = AlergiasRep.GetAlergiasById(idPlanta);

            if (alergia != null)
            {
                if (alergia.EsArbol.HasValue)
                {
                    //Es Arbol
                    if (alergia.EsArbol.Value)
                    {
                        descripcion = GetNivelPolenArbol(nivel).ToString();
                    }
                    else//Es planta
                    {
                        descripcion = GetNivelPolenPlanta(nivel).ToString();
                    }
                }
            }

            return descripcion;
        }

        private int GetNivelPolenArbol(string estado)
        {
            int resultado = 0;
            if ((!Int32.TryParse(estado, out resultado)) || (Int32.Parse(estado) == 0))
            {
                resultado = ValoresPolen.Nulo;
            }
            else if (1 <= Int32.Parse(estado) && Int32.Parse(estado) <= 50)
            {
                resultado = ValoresPolen.Bajo;
            }
            else if (51 <= Int32.Parse(estado) && Int32.Parse(estado) <= 200)
            {
                resultado = ValoresPolen.Medio;
            }
            else if (201 <= Int32.Parse(estado) && Int32.Parse(estado) <= 400)
            {
                resultado = ValoresPolen.Alto;
            }
            else if (Int32.Parse(estado) > 400)
            {
                resultado = ValoresPolen.MuyAlto;
            }
            return resultado;
        }

        private int GetNivelPolenPlanta(string estado)
        {
            int resultado = 0;
            if ((!Int32.TryParse(estado, out resultado)) || (Int32.Parse(estado) == 0))
            {
                resultado = ValoresPolen.Nulo;
            }
            else if (1 <= Int32.Parse(estado) && Int32.Parse(estado) <= 15)
            {
                resultado = ValoresPolen.Bajo;
            }
            else if (16 <= Int32.Parse(estado) && Int32.Parse(estado) <= 30)
            {
                resultado = ValoresPolen.Medio;
            }
            else if (31 <= Int32.Parse(estado) && Int32.Parse(estado) <= 50)
            {
                resultado = ValoresPolen.Alto;
            }
            else if (Int32.Parse(estado) > 250)
            {
                resultado = ValoresPolen.MuyAlto;
            }
            return resultado;
        }
    }
}