using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polendamus.Interfaces;
using System.Web.Routing;
using Polendamus.Repositories;
using Polendamus.Models;
using Polendamus.Enums;

namespace Polendamus.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public IProvinciasRep provinciasrepository { get; set; }
        public IAlergiasRep alergiasrepository { get; set; }
        public INivelesRep nivelesrepository { get; set; }
        public IBocadillosRep bocadillosrepository { get; set; }
        public IDibujosRep dibujosrepository { get; set; }
        public IPrediccionesRep prediccionesrepository { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (provinciasrepository == null)
            {
                provinciasrepository = new ProvinciasRepository();
            }
            if (alergiasrepository == null)
            {
                alergiasrepository = new AlergiasRepository();
            }
            if (nivelesrepository == null)
            {
                nivelesrepository = new NivelesRepository();
            }
            if (bocadillosrepository == null)
            {
                bocadillosrepository = new BocadillosRepository();
            }
            if (dibujosrepository == null)
            {
                dibujosrepository = new DibujosRepository();
            }
            if (prediccionesrepository == null)
            {
                prediccionesrepository = new PrediccionesRepository();
            }

            base.Initialize(requestContext);
        }
        public ActionResult Index()
        {
            using (polendamusEntities dbContext = GetNewDBContext())
            {
                provinciasrepository.DBContext = dbContext;
                alergiasrepository.DBContext = dbContext;
                bocadillosrepository.DBContext = dbContext;
                dibujosrepository.DBContext = dbContext;

                //Rellenamos el modelo con los textos iniciales
                PolenModel model = new PolenModel();

                model.Bocadillo1 = GetRandomNivelFrase(ValoresPolen.Inicio);
                model.Bocadillo2 = GetRandomPrediccionFrase(ValoresPrediccion.Inicio);

                ViewData["ImgPersona1"] = "Inicio1";
                ViewData["ImgPersona2"] = "Inicio2";

                List<Provincias> provincias = provinciasrepository.GetProvincias().ToList();         
                ViewData["Provincias"] = provincias;

                List<Alergias> alergias = alergiasrepository.GetAlergias().ToList();
                ViewData["Alergias"] = alergias;
                model.Provincia = provincias.FirstOrDefault().Nombre;
                model.Alergia = alergias.FirstOrDefault().Nombre;
                ViewData["Twitter"] = GetMensajeTwitter("", 0).ToString();

                ViewData.Model = model;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(PolenModel model)
        {
            using (polendamusEntities dbContext = GetNewDBContext())
            {
                provinciasrepository.DBContext = dbContext;
                alergiasrepository.DBContext = dbContext;
                nivelesrepository.DBContext = dbContext;
                prediccionesrepository.DBContext = dbContext;
                bocadillosrepository.DBContext = dbContext;
                dibujosrepository.DBContext = dbContext;

                List<Provincias> provincias = provinciasrepository.GetProvincias().ToList();
                List<Alergias> alergias = alergiasrepository.GetAlergias().ToList();

                Provincias provincia = provinciasrepository.GetProvinciaByName(model.Provincia);
                Alergias alergia = alergiasrepository.GetAlergiasByName(model.Alergia);
                Niveles NivelHoy = nivelesrepository.GetNivelesByProvByAlergia(provincia.Id, alergia.Id);
                Predicciones Prediccion = prediccionesrepository.GetPrediccionByIdProvincia(provincia.Id);

                ViewData["Provincias"] = provincias;
                ViewData["Alergias"] = alergias;
                if (NivelHoy != null)
                {
                    if (NivelHoy.Estado != "")
                    {
                        model.Bocadillo1 = GetRandomNivelFrase(int.Parse(NivelHoy.Estado));
                        model.Bocadillo1 = model.Bocadillo1.Replace("(Ciudad)", model.Provincia.ToString());
                        model.Bocadillo1 = model.Bocadillo1.Replace("(ciudad)", model.Provincia.ToString());
                        ViewData["Twitter"] = GetMensajeTwitter(model.Provincia, Convert.ToInt32(NivelHoy.Estado)).ToString();

                        if (NivelHoy.Estado == ValoresPolen.Nulo.ToString())
                        {
                            model.Bocadillo2 = "No somos magos, necesitamos datos, DATOS!";
                            ViewData["ImgPersona1"] = GetRandomNivelDibujo(int.Parse(NivelHoy.Estado));
                            ViewData["ImgPersona2"] = "Nulo2";
                        }
                        else
                        {
                            model.Bocadillo2 = GetRandomPrediccionFrase(int.Parse(Prediccion.Estado));
                            model.Bocadillo2 = model.Bocadillo2.Replace("(Ciudad)", model.Provincia.ToString());
                            model.Bocadillo2 = model.Bocadillo2.Replace("(ciudad)", model.Provincia.ToString());
                            ViewData["ImgPersona1"] = GetRandomNivelDibujo(int.Parse(NivelHoy.Estado));
                            ViewData["ImgPersona2"] = GetRandomPrediccionDibujo(int.Parse(Prediccion.Estado));

                        }
                    }
                    else
                    {
                        model.Bocadillo1 = "No tenemos datos, ups! ¿y ahora qué? quéjate para que ABRAN DATOS!";
                        model.Bocadillo2 = "No somos magos, necesitamos datos, DATOS!";
                        ViewData["ImgPersona1"] = "Inicio1";
                        ViewData["ImgPersona2"] = "Inicio2";
                        ViewData["Twitter"] = GetMensajeTwitter("", 0).ToString();
                    }
                }
                else
                {
                    model.Bocadillo1 = "No tenemos datos, ups! ¿y ahora qué? quéjate para que ABRAN DATOS!";
                    model.Bocadillo2 = "No somos magos, necesitamos datos, DATOS!";
                    ViewData["ImgPersona1"] = "Inicio1";
                    ViewData["ImgPersona2"] = "Inicio2";
                    ViewData["Twitter"] = GetMensajeTwitter("", 0).ToString();
                }


                ViewData.Model = model;
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }

        #region Frases y Dibujos Aleatorios
        private String GetRandomNivelFrase(int nivel)
        {
            String frase = "";
            String nivelTexto = nivel.ToString();
            List<Bocadillos> listaFrases = bocadillosrepository.GetBocadillos().Where(g => g.EsHoy == true && g.Estado.Equals(nivelTexto)).ToList();
            Random r = new Random((int)DateTime.Now.Ticks * 20);
            int digito;
            switch (nivel)
            {
                case ValoresPolen.Inicio:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesInicio);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPolen.Nulo:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesNulo);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPolen.Bajo:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesBajo);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPolen.Medio:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesMedio);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPolen.Alto:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesAlto);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPolen.MuyAlto:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesNivelesMuyAlto);
                    frase = listaFrases[digito].Texto;
                    break;
                default:
                    break;
            }

            return frase;
        }

        private String GetRandomNivelDibujo(int nivel)
        {
            String nombreImagen = "";
            String nivelTexto = nivel.ToString();
            Random r = new Random((int)DateTime.Now.Ticks * 20);
            List<Dibujos> listaDibujos = dibujosrepository.GetDibujos().Where(g => g.EsHoy == true && g.Estado.Equals(nivelTexto)).ToList();
            int digito;
            switch (nivel)
            {
                case ValoresPolen.Nulo:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosNivelesNulo);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPolen.Bajo:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosNivelesBajo);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPolen.Medio:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosNivelesMedio);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPolen.Alto:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosNivelesAlto);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPolen.MuyAlto:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosNivelesMuyAlto);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                default:
                    break;
            }

            return nombreImagen;
        }

        private String GetRandomPrediccionFrase(int nivel)
        {
            String frase = "";
            String nivelTexto = nivel.ToString();
            List<Bocadillos> listaFrases = bocadillosrepository.GetBocadillos().Where(g => g.EsHoy == false && g.Estado.Equals(nivelTexto)).ToList();
            Random r = new Random((int)DateTime.Now.Ticks * 20);
            int digito;
            switch (nivel)
            {
                case ValoresPrediccion.Inicio:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesPrevisionInicio);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPrediccion.Baja:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesPrevisionBaja);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPrediccion.Mantiene:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesPrevisionMantiene);
                    frase = listaFrases[digito].Texto;
                    break;
                case ValoresPrediccion.Sube:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numFrasesPrevisionSube);
                    frase = listaFrases[digito].Texto;
                    break;
                default:
                    break;
            }
            return frase;
        }

        private String GetRandomPrediccionDibujo(int nivel)
        {
            String nombreImagen = "";
            String nivelTexto = nivel.ToString();
            Random r = new Random((int)DateTime.Now.Ticks * 20);
            List<Dibujos> listaDibujos = dibujosrepository.GetDibujos().Where(g => g.EsHoy == false && g.Estado.Equals(nivelTexto)).ToList();
            int digito;
            switch (nivel)
            {
                 case ValoresPrediccion.Baja:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosPrevisionBaja);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPrediccion.Mantiene:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosPrevisionMantiene);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                case ValoresPrediccion.Sube:
                    digito = r.Next(0, Constantes.CantidadFrasesDibujos.numDibujosPrevisionSube);
                    nombreImagen = listaDibujos[digito].Nombre;
                    break;
                default:
                    break;
            }
            return nombreImagen;
        }

        #endregion

        #region Mensaje Compartir Twitter / Facebook

        public String GetMensajeTwitter(String provincia, int nivel)
        {
            String mensaje = "";

            switch (nivel)
            {
                case 0:
                    mensaje = "Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
                case 1:
                    mensaje = "Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
                case 2:
                    mensaje = "El nivel del polen en " + provincia + " hoy es bajo. Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
                case 3:
                    mensaje = "El nivel del polen en " + provincia + " hoy es medio. Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
                case 4:
                    mensaje = "El nivel del polen en " + provincia + " hoy es alto. Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
                case 5:
                    mensaje = "El nivel del polen en " + provincia + " hoy es muy alto. Conoce el nivel de polen en tu ciudad de una manera diferente, en www.polendamus.com";
                    break;
            }

            mensaje = mensaje.Replace(" ", "%20");

            return mensaje;
        }

        #endregion
    }
}
