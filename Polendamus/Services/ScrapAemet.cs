using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polendamus.Enums;
using Polendamus.Repositories;

namespace Polendamus.Services
{
    public class ScrapAemet
    {

        private Predicciones GetDatos(UrlsTiempo provincia)
        {
            //Variables.
            int precipitacion; //En porcentaje
            int viento; //Velocidad

            //Cogemos el HTML en cuestión de polenes.
            Scrapping sc = new Scrapping();
            String html = sc.GetHtml(provincia.url);

            #region Precipitaciones
            String inicioProbLluvia = "<th title=\"Probabilidad de precipitaci";
            html = html.Substring(html.IndexOf(inicioProbLluvia) + inicioProbLluvia.Length);

            String iniLluvia = "<td class=\"borde_rb\" colspan=\"2\">";
            html = html.Substring(html.IndexOf(iniLluvia) + iniLluvia.Length);
            String finLluvia = "</td>";
            int indexFinLluvia = html.IndexOf(finLluvia);

            String precipitacionString = html.Substring(0, indexFinLluvia).Replace("&nbsp;", "").Replace("%", "");

            precipitacion = int.Parse(precipitacionString);
            #endregion

            #region Viento
            String inicioViento = "<th title=\"Velocidad del viento en kilometros por hora";
            html = html.Substring(html.IndexOf(inicioViento) + inicioViento.Length);

            String iniViento1 = "<td class=\"borde_b\">";
            html = html.Substring(html.IndexOf(iniViento1) + iniViento1.Length);
            String finViento = "</td>";
            int indexFin = html.IndexOf(finViento);

            String viento1String = html.Substring(0, indexFin).Replace("&nbsp;", "").Replace("&nbsp", "").Replace("%", "");

            String iniViento2 = "<td class=\"borde_rb\">";
            html = html.Substring(html.IndexOf(iniViento2) + iniViento2.Length);

            String viento2String = html.Substring(0, indexFin).Replace("&nbsp;", "").Replace("&nbsp", "").Replace("%", "").Replace("<", "");

            int wind1 = 0;
            int wind2 = 0;
            if ((int.TryParse(viento1String, out wind1)) && (int.TryParse(viento2String, out wind2)))
            {
                viento = (int.Parse(viento1String) + int.Parse(viento2String)) / 2;
            }
            else
            {
                viento = 0;
            }
            #endregion

            Predicciones predicciones = new Predicciones()
            {
                Id_Provincia = provincia.Id_Provincia
            };

            #region Calculos para la prediccion

            if (viento > 20)
            {
                if (precipitacion > 50)
                {
                    //Igual
                    predicciones.Estado = ValoresPrediccion.Mantiene.ToString();
                }
                else
                {
                    //Sube
                    predicciones.Estado = ValoresPrediccion.Sube.ToString();
                }
            }
            else
            {
                if (precipitacion > 50)
                {
                    //Baja.
                    predicciones.Estado = ValoresPrediccion.Baja.ToString();
                }
                else
                {
                    //Igual.
                    predicciones.Estado = ValoresPrediccion.Mantiene.ToString();
                }
            }
            #endregion

            return predicciones;
        }

        public List<Predicciones> GetPredicciones(List<UrlsTiempo> provinciasAemet)
        {
            //Recuperamos todas las provincias con URLs para recorrerlas.
            //UrlsTiempoRepository rep = new UrlsTiempoRepository();
            //List<UrlsTiempo> provinciasAemet = rep.GetUrlsTiempo().ToList();

            //Recorremos todas las provincias.
            List<Predicciones> predicciones = new List<Predicciones>();
            foreach (UrlsTiempo item in provinciasAemet)
            {
                //Cogemos los datos de la provincia y los añadimos a la lista.
                Predicciones prediccion = GetDatos(item);
                predicciones.Add(prediccion);
            }

            return predicciones;
        }
    }
}
