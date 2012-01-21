using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class PrediccionesRepository:BaseRepository, Interfaces.IPrediccionesRep
    {
        polendamusEntities _dbContext = null;

        public polendamusEntities DBContext
        {
            get
            {
                return _dbContext;
            }

            set
            {
                _dbContext = value;
            }
        }

        public IQueryable<Predicciones> GetPredicciones()
        {
            return (from u in _dbContext.Predicciones
                    select u);
        }

        public Predicciones GetPrediccionByIdProvincia(int idProvincia)
        {
            return (from u in _dbContext.Predicciones
                    where u.Id_Provincia == idProvincia
                    select u).FirstOrDefault();
        }

        public void Clean()
        {
            foreach (var item in _dbContext.Predicciones)
            {
                _dbContext.Predicciones.DeleteObject(item);
            }
            _dbContext.SaveChanges();
        }

        public void AddPrediccion(Predicciones predicciones)
        {
            _dbContext.AddToPredicciones(predicciones);
            //_dbContext.SaveChanges();
        }
    }
}