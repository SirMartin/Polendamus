using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polendamus.Services;
using Polendamus.Repositories;


namespace Polendamus.Tests
{
    [TestClass]
    public class UnitTest1
    {
        protected Polendamus.polendamusEntities GetNewDBContext()
        {
            Polendamus.polendamusEntities db = new Polendamus.polendamusEntities();
            db.ContextOptions.LazyLoadingEnabled = false;
            return db;
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (polendamusEntities dbContext = GetNewDBContext())
            {

                NivelesRepository nivelesrepository = new NivelesRepository();
                PrediccionesRepository prediccionesrepository = new PrediccionesRepository();
                UrlsTiempoRepository URLTiemposrepository = new UrlsTiempoRepository();

                nivelesrepository.DBContext = dbContext;
                prediccionesrepository.DBContext = dbContext;
                URLTiemposrepository.DBContext = dbContext;

                //Borramos todos los niveles y predicciones
                nivelesrepository.Clean();
                prediccionesrepository.Clean();
                
                ScrapCastillaMancha scCastilla = new ScrapCastillaMancha();
                List<Niveles> nivCastilla = scCastilla.GetDatosFromCastillaLaMancha();
                int conCastillaProv0 = nivCastilla.Where(g => g.Id_Provincia == 0).Count();
                int conCastillaProv1 = nivCastilla.Where(g => g.Id_Provincia == -1).Count();

                int conCastillaPlan0 = nivCastilla.Where(g => g.Id_Planta == 0).Count();
                int conCastillaPlan1 = nivCastilla.Where(g => g.Id_Planta == -1).Count();

                ScrapCatalunya scCatalunya = new ScrapCatalunya();
                List<Niveles> nivCatalunya = scCatalunya.GetDatosFromCatalunya();
                int conCatalunyaProv0 = nivCatalunya.Where(g => g.Id_Provincia == 0).Count();
                int conCatalunyaProv1 = nivCatalunya.Where(g => g.Id_Provincia == -1).Count();

                int conCatalunyaPlan0 = nivCatalunya.Where(g => g.Id_Planta == 0).Count();
                int conCatalunyaPlan1 = nivCatalunya.Where(g => g.Id_Planta == -1).Count();

                ScrapPolenes scPolenes = new ScrapPolenes();
                List<Niveles> nivPolenes = scPolenes.GetDatosFromPolenes();
                int conPolenesProv0 = nivPolenes.Where(g => g.Id_Provincia == 0).Count();
                int conPolenesProv1 = nivPolenes.Where(g => g.Id_Provincia == -1).Count();

                int conPolenesPlan0 = nivPolenes.Where(g => g.Id_Planta == 0).Count();
                int conPolenesPlan1 = nivPolenes.Where(g => g.Id_Planta == -1).Count();

                ScrapElTiempo scElTiempo = new ScrapElTiempo();
                List<Niveles> nivElTiempo = scElTiempo.GetDatosFromElTiempo();
                int conElTiempoProv0 = nivElTiempo.Where(g => g.Id_Provincia == 0).Count();
                int conElTiempoProv1 = nivElTiempo.Where(g => g.Id_Provincia == -1).Count();

                int conElTiempoPlan0 = nivElTiempo.Where(g => g.Id_Planta == 0).Count();
                int conElTiempoPlan1 = nivElTiempo.Where(g => g.Id_Planta == -1).Count();

                ScrapAemet scAemet = new ScrapAemet();
                List<Predicciones> predicciones = scAemet.GetPredicciones(URLTiemposrepository.GetUrlsTiempo().ToList());
                int conAemetProv0 = predicciones.Where(g => g.Id_Provincia == 0).Count();
                int conAemetProv1 = predicciones.Where(g => g.Id_Provincia == -1).Count();

                List<Niveles> niveles = new List<Niveles>();
                niveles.AddRange(nivCastilla);
                niveles.AddRange(nivCatalunya);
                niveles.AddRange(nivElTiempo);
                niveles.AddRange(nivPolenes);

                int cont = 0;
                foreach (var n in niveles)
                {
                    //Añadimos los nuevos datos
                    n.Id = cont;
                    nivelesrepository.AddNivel(n);
                    cont++;

                }

                int i = 0;
                foreach (var p in predicciones)
                {
                    p.Id = i;
                    prediccionesrepository.AddPrediccion(p);
                    i++;
                }
                dbContext.SaveChanges();

                String a = "";
            }
        }
    }
}
