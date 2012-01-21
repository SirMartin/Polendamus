using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IPrediccionesRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Predicciones> GetPredicciones();
        Predicciones GetPrediccionByIdProvincia(int idProvincia);
        void Clean();
        void AddPrediccion(Predicciones prediccion);

    }
}