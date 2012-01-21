using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Caching;
using System.Net;
using Polendamus.Services;
using Polendamus.Repositories;
using Polendamus.Interfaces;

namespace Polendamus
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public INivelesRep nivelesrepository { get; set; }
        public IPrediccionesRep prediccionesrepository { get; set; }
        public IUrlsTiempoRep URLTiemposrepository { get; set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "Default", // Nombre de ruta
                "{controller}/{action}/{id}", // URL con parámetros
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Valores predeterminados de parámetro
            );

        }

        #region Timer
        private const bool _cacheItemTimerActivated = true;
        private const string DummyCacheItemKey = "GagaGuguGigi";
        //private const string DummyPageUrl = "http://localhost:6952/triggerDummyCache";
        private const string DummyPageUrl = "http://www.iloire.com/triggerDummyCache";


        public void CacheItemRemovedCallback(string key,
            object value, CacheItemRemovedReason reason)
        {
            //Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());

            // Do the service works

            HitPage();
            System.Threading.ThreadPool.QueueUserWorkItem(ExecuteFetchLevelsStatsAsync);

        }

        private void ExecuteFetchLevelsStatsAsync(object info)
        {
            using (polendamusEntities dbContext = GetNewDBContext())
            {
                /*nivelesrepository.DBContext = dbContext;
                prediccionesrepository.DBContext = dbContext;
                URLTiemposrepository.DBContext = dbContext;


                //Borramos todos los niveles y predicciones
                nivelesrepository.Clean();
                prediccionesrepository.Clean();

                //CASTILLA LA MANCHA
                ScrapCastillaMancha repCM = new ScrapCastillaMancha();
                List<Niveles> niveles = repCM.GetDatosFromCastillaLaMancha();

                //CATALUÑA
                ScrapCatalunya repCAT = new ScrapCatalunya();
                niveles.AddRange(repCAT.GetDatosFromCatalunya());

                //EL TIEMPO
                ScrapElTiempo repTIEMPO = new ScrapElTiempo();
                niveles.AddRange(repTIEMPO.GetDatosFromElTiempo());

                //POLENES
                ScrapPolenes repPOL = new ScrapPolenes();
                niveles.AddRange(repPOL.GetDatosFromPolenes());

                int cont = 0;
                foreach (var n in niveles)
                {
                    //Añadimos los nuevos datos
                    n.Id = cont;
                    nivelesrepository.AddNivel(n);
                    cont++;

                }

                //PREDICIONES
                ScrapAemet repAemet = new ScrapAemet();
                List<UrlsTiempo> provinciasAemet = URLTiemposrepository.GetUrlsTiempo().ToList();

                List<Predicciones> predicciones = repAemet.GetPredicciones(provinciasAemet).ToList();

                int i = 0;
                foreach (var p in predicciones)
                {
                    p.Id = i;
                    prediccionesrepository.AddPrediccion(p);
                    i++;
                }
                dbContext.SaveChanges();*/
            }
        }


        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache[DummyCacheItemKey])
                return false;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", null,
                DateTime.MaxValue, TimeSpan.FromMinutes(2),
                CacheItemPriority.Normal,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));

            return true;
        }



        private void HitPage()
        {
            WebClient client = new WebClient();
            client.DownloadData(DummyPageUrl);
        }

        #endregion


        protected void Application_Start()
        {

            if (_cacheItemTimerActivated)
                RegisterCacheEntry();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            if (nivelesrepository == null)
            {
                nivelesrepository = new NivelesRepository();
            }
            if (prediccionesrepository == null)
            {
                prediccionesrepository = new PrediccionesRepository();
            }
            if (URLTiemposrepository == null)
            {
                URLTiemposrepository = new UrlsTiempoRepository();
            }
            
            //borramos stats más antiguos que 40 días
            //repC.DeleteOldData(40);
        }


        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // If the dummy page is hit, then it means we want to add another item
            // in cache
            if (HttpContext.Current.Request.Url.ToString() == DummyPageUrl)
            {
                // Add the item in cache and when succesful, do the work.
                RegisterCacheEntry();
                Response.Clear();
                Response.Write("ok");
                Response.End();
            }
        }

        protected Polendamus.polendamusEntities GetNewDBContext()
        {
            Polendamus.polendamusEntities db = new Polendamus.polendamusEntities();
            db.ContextOptions.LazyLoadingEnabled = false;
            return db;
        }
    }
}