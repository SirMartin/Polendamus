using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Constantes
{
    public class TipoElTiempo
    {
        //Galicia
        public static String urlCoruna = "http://www.eltiempo.es/la-coruna/polen/";
        public static String urlLugo = "http://www.eltiempo.es/lugo/polen/";
        public static String urlOrense = "http://www.eltiempo.es/orense/polen/";
        public static String urlPontevedra = "http://www.eltiempo.es/pontevedra/polen/";

        //Andalucia
        public static String urlCadiz = "http://www.eltiempo.es/cadiz/polen/";
        public static String urlCordoba = "http://www.eltiempo.es/cordoba/polen/";
        public static String urlGranada = "http://www.eltiempo.es/granada/polen/";
        public static String urlHuelva = "http://www.eltiempo.es/huelva/polen/";
        public static String urlJaen = "http://www.eltiempo.es/jaen/polen/";
        public static String urlMalaga = "http://www.eltiempo.es/malaga/polen/";

        //Aragon
        public static String urlHuesca = "http://www.eltiempo.es/huesca/polen/";
        public static String urlTeruel = "http://www.eltiempo.es/teruel/polen/";
        public static String urlZaragoza = "http://www.eltiempo.es/zaragoza/polen/";

        //Asturias
        public static String urlAsturias = "http://www.eltiempo.es/asturias/polen/";

        //Madrid
        public static string urlMadrid = "http://www.eltiempo.es/madrid/polen/";

        //Baleares
        public static String urlBaleares = "http://www.eltiempo.es/baleares/polen/";

        //Cantabria
        public static String urlCantabria = "http://www.eltiempo.es/cantabria/polen/";

        //Castilla y Leon
        public static String urlAvila = "http://www.eltiempo.es/avila/polen/";
        public static String urlLeon = "http://www.eltiempo.es/leon/polen/";
        public static String urlPalencia = "http://www.eltiempo.es/palencia/polen/";
        public static String urlSalamanca = "http://www.eltiempo.es/salamanca/polen/";
        public static String urlSegovia = "http://www.eltiempo.es/segovia/polen/";
        public static String urlSoria = "http://www.eltiempo.es/soria/polen/";
        public static String urlValladolid = "http://www.eltiempo.es/valladolid/polen/";
        public static String urlZamora = "http://www.eltiempo.es/zamora/polen/";

        //Comunidad Valenciana
        public static String urlCastellon = "http://www.eltiempo.es/castellon/polen/";
        public static String urlValencia = "http://www.eltiempo.es/valencia/polen/";

        //Pais Vasco
        public static String urlVizcaya = "http://www.eltiempo.es/vizcaya/polen/";
        public static String urlAlava = "http://www.eltiempo.es/alava/polen/";

        //Murcia
        public static String urlMurcia = "http://www.eltiempo.es/murcia/polen/";

        public static List<String> GetAllUrls()
        {
            List<String> lista = new List<String>();

            //Galicia
            lista.Add(urlCoruna);
            lista.Add(urlLugo);
            lista.Add(urlOrense);
            lista.Add(urlPontevedra);

            //Andalucia
            lista.Add(urlCadiz);
            lista.Add(urlCordoba);
            lista.Add(urlGranada);
            lista.Add(urlHuelva);
            lista.Add(urlJaen);
            lista.Add(urlMalaga);

            //Aragon
            lista.Add(urlHuesca);
            lista.Add(urlTeruel);
            lista.Add(urlZaragoza);

            //Madrid
            lista.Add(urlMadrid);

            //Asturias
            lista.Add(urlAsturias);

            //Baleares
            lista.Add(urlBaleares);

            //Cantabria
            lista.Add(urlCantabria);

            //Castilla y Leon
            lista.Add(urlAvila);
            lista.Add(urlLeon);
            lista.Add(urlPalencia);
            lista.Add(urlSalamanca);
            lista.Add(urlSegovia);
            lista.Add(urlSoria);
            lista.Add(urlValladolid);
            lista.Add(urlZamora);

            //Comunidad Valenciana
            lista.Add(urlCastellon);
            lista.Add(urlValencia);

            //Pais Vasco
            lista.Add(urlVizcaya);
            lista.Add(urlAlava);

            //Murcia
            lista.Add(urlMurcia);

            return lista;
        }

        public static int GetIdProvincia(String url)
        {
            if (url.Equals(urlCoruna))
            {
                return 15;
            }
            else if (url.Equals(urlLugo))
            {
                return 27;
            }
            else if (url.Equals(urlOrense))
            {
                return 32;
            }
            else if (url.Equals(urlPontevedra))
            {
                return 36;
            }
            else if (url.Equals(urlCadiz))
            {
                return 11;
            }
            else if (url.Equals(urlCordoba))
            {
                return 14;
            }
            else if (url.Equals(urlGranada))
            {
                return 18;
            }
            else if (url.Equals(urlHuelva))
            {
                return 21;
            }
            else if (url.Equals(urlJaen))
            {
                return 23;
            }
            else if (url.Equals(urlMalaga))
            {
                return 29;
            }
            else if (url.Equals(urlHuesca))
            {
                return 22;
            }
            else if (url.Equals(urlTeruel))
            {
                return 44;
            }
            else if (url.Equals(urlZaragoza))
            {
                return 50;
            }
            else if (url.Equals(urlMadrid))
            {
                return 28;
            }
            else if (url.Equals(urlAsturias))
            {
                return 33;
            }
            else if (url.Equals(urlBaleares))
            {
                return 7;
            }
            else if (url.Equals(urlCantabria))
            {
                return 39;
            }
            else if (url.Equals(urlAvila))
            {
                return 5;
            }
            else if (url.Equals(urlLeon))
            {
                return 24;
            }
            else if (url.Equals(urlPalencia))
            {
                return 34;
            }
            else if (url.Equals(urlSalamanca))
            {
                return 37;
            }
            else if (url.Equals(urlSegovia))
            {
                return 40;
            }
            else if (url.Equals(urlSoria))
            {
                return 42;
            }
            else if (url.Equals(urlValladolid))
            {
                return 47;
            }
            else if (url.Equals(urlZamora))
            {
                return 49;
            }
            else if (url.Equals(urlCastellon))
            {
                return 12;
            }
            else if (url.Equals(urlValencia))
            {
                return 46;
            }
            else if (url.Equals(urlVizcaya))
            {
                return 48;
            }
            else if (url.Equals(urlAlava))
            {
                return 1;
            }
            else if (url.Equals(urlMurcia))
            {
                return 30;
            }

            return 0;
        }

        public static int GetEstado(String descripcion)
        {
            if (descripcion.Equals("Nothing"))
            {
                return 1;
            }
            else if (descripcion.Equals("Low"))
            {
                return 2;
            }
            else if (descripcion.Equals("Medium"))
            {
                return 3;
            }
            else if (descripcion.Equals("High"))
            {
                return 4;
            }

            return 1;
        }

        public static int GetIdPlanta(String nombrePlanta)
        {
            if (nombrePlanta.Equals("Abedul"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Pl??tano de sombra"))
            {
                return 2;
            }
            else if (nombrePlanta.Equals("Gram??neas"))
            {
                return 1;
            }
            else if (nombrePlanta.Equals("Olivo"))
            {
                return 14;
            }
            else if (nombrePlanta.Equals("Ortigas"))
            {
                return 8;
            }
            else if (nombrePlanta.Equals("Cipr??s"))
            {
                return 3;
            }
            else if (nombrePlanta.Equals("Robles y encinas"))
            {
                return 13;
            }
            else if (nombrePlanta.Equals("Chenopodiaceae-Amaranthaceae"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Alisos"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Casta??o"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Casuarina"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Avellanos"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Compuestas"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Fresnos"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Aligustre"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Mor??ceas"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("??lamos"))
            {
                return -1;
            }
            else if (nombrePlanta.Equals("Olmos"))
            {
                return -1;
            }
            return 0;
        }
    }
}