using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Constantes
{
    public class TiposPolenes
    {
        public static String urlPolenes1 = "http://polenes.com/graficos/Semana2?pol=";
        public static String urlPolenes2 = "&radTipo=sem";

        public static String Cupresaceas = "CUPRE";
        public static String Palmaceas = "PALMA";
        public static String Rumex = "RUMEX";
        public static String Mercurialis = "MERCU";
        public static String Morus = "MORUS";
        public static String Urticaceas = "URTIC";
        public static String Alnus = "ALNUS";
        public static String Betula = "BETUL";
        public static String Carex = "CAREX";
        public static String Fraxinus = "FRAXI";
        public static String Quercus = "QUERC";
        public static String Olea = "OLEA";
        public static String Pinus = "PINUS";
        public static String Ulmus = "ULMUS";
        public static String Castanea = "CASTA";
        public static String Populus = "POPUL";
        public static String Gramineas = "GRAMI";
        public static String QuenoAmaran = "QUEAM";
        public static String Platanus = "PLATA";
        public static String Plantago = "PLANT";
        public static String Artemisia = "ARTEM";
        public static String Alternaria = "ALTER";

        public static List<String> GetAllUrls()
        {
            List<String> lista = new List<String>();

            lista.Add(Cupresaceas);
            lista.Add(Palmaceas);
            lista.Add(Rumex);
            lista.Add(Mercurialis);
            lista.Add(Morus);
            lista.Add(Urticaceas);
            lista.Add(Alnus);
            lista.Add(Betula);
            lista.Add(Carex);
            lista.Add(Fraxinus);
            lista.Add(Quercus);
            lista.Add(Olea);
            lista.Add(Pinus);
            lista.Add(Ulmus);
            lista.Add(Castanea);
            lista.Add(Populus);
            lista.Add(Gramineas);
            lista.Add(QuenoAmaran);
            lista.Add(Platanus);
            lista.Add(Plantago);
            lista.Add(Artemisia);
            lista.Add(Alternaria);

            return lista;
        }

        public static int GetIdProvincia(String provincia)
        {
            if (provincia.Equals("Albacete"))
            {
                return 2;
            }
            else if (provincia.Equals("Almer??a"))
            {
                return 4;
            }
            else if (provincia.Equals("Badajoz"))
            {
                return 6;
            }
            else if (provincia.Equals("Cuenca"))
            {
                return 16;
            }
            else if (provincia.Equals("Barcelona"))
            {
                return 8;
            }
            else if (provincia.Equals("Burgos"))
            {
                return 9;
            }
            else if (provincia.Equals("C??ceres"))
            {
                return 10;
            }
            else if (provincia.Equals("Ciudad Real"))
            {
                return 13;
            }
            else if (provincia.Equals("Elche"))
            {
                return -1;
            }
            else if (provincia.Equals("Guadalajara"))
            {
                return 19;
            }
            else if (provincia.Equals("Ja??n"))
            {
                return 23;
            }
            else if (provincia.Equals("Logro??o"))
            {
                return 26;
            }
            else if (provincia.Equals("Madrid"))
            {
                return 28;
            }
            else if (provincia.Equals("Pamplona"))
            {
                return 31;
            }
            else if (provincia.Equals("San Juan de Alicante"))
            {
                return 3;
            }
            else if (provincia.Equals("San Sebasti??n"))
            {
                return 20;
            }
            else if (provincia.Equals("Santander"))
            {
                return 39;
            }
            else if (provincia.Equals("Sevilla"))
            {
                return 41;
            }
            else if (provincia.Equals("Toledo"))
            {
                return 45;
            }
            else if (provincia.Equals("Vitoria"))
            {
                return 1;
            }
            else if (provincia.Equals("Zaragoza"))
            {
                return 50;
            }
            return 0;
        }

        public static int GetIdPlanta(String nombrePlanta)
        {
            if (nombrePlanta.Equals(Cupresaceas))
            {
                return 3;
            }
            else if (nombrePlanta.Equals(Palmaceas))
            {
                return 4;
            }
            else if (nombrePlanta.Equals(Rumex))
            {
                return 5;
            }
            else if (nombrePlanta.Equals(Mercurialis))
            {
                return 6;
            }
            else if (nombrePlanta.Equals(Morus))
            {
                return 7;
            }
            else if (nombrePlanta.Equals(Urticaceas))
            {
                return 8;
            }
            else if (nombrePlanta.Equals(Alnus))
            {
                return 9;
            }
            else if (nombrePlanta.Equals(Betula))
            {
                return 10;
            }
            else if (nombrePlanta.Equals(Carex))
            {
                return 11;
            }
            else if (nombrePlanta.Equals(Fraxinus))
            {
                return 12;
            }
            else if (nombrePlanta.Equals(Quercus))
            {
                return 13;
            }
            else if (nombrePlanta.Equals(Olea))
            {
                return 14;
            }
            else if (nombrePlanta.Equals(Pinus))
            {
                return 15;
            }
            else if (nombrePlanta.Equals(Ulmus))
            {
                return 16;
            }
            else if (nombrePlanta.Equals(Castanea))
            {
                return 17;
            }
            else if (nombrePlanta.Equals(Populus))
            {
                return 18;
            }
            else if (nombrePlanta.Equals(Gramineas))
            {
                return 1;
            }
            else if (nombrePlanta.Equals(QuenoAmaran))
            {
                return 19;
            }
            else if (nombrePlanta.Equals(Platanus))
            {
                return 2;
            }
            else if (nombrePlanta.Equals(Plantago))
            {
                return 20;
            }
            else if (nombrePlanta.Equals(Artemisia))
            {
                return 21;
            }
            else if (nombrePlanta.Equals(Alternaria))
            {
                return 22;
            }

            return 0;
        }
    }
}