using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class EstadisticasRepository:BaseRepository, Interfaces.IEstadisticasRep
    {
        /*polendamusEntities _dbContext = null;

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

        public IQueryable<Alergias> GetAlergias()
        {
            return (from u in _dbContext.Alergias
                    select u);
        }
        public Alergias GetAlergiasByName(string nombre)
        {
            return (from u in _dbContext.Alergias
                    where u.Nombre.Equals(nombre)
                    select u).FirstOrDefault();
        }

        public Alergias GetAlergiasById(int idPlanta)
        {
            return (from u in _dbContext.Alergias
                    where u.Id == idPlanta
                    select u).FirstOrDefault();
        }*/
    }
}