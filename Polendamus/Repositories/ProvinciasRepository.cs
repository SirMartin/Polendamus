using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class ProvinciasRepository:BaseRepository, Interfaces.IProvinciasRep
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

        public IQueryable<Provincias> GetProvincias()
        {
            return (from u in _dbContext.Provincias
                    select u);
        }

        public Provincias GetProvinciaByName(string nombre)
        {
            return (from u in _dbContext.Provincias
                    where u.Nombre == nombre 
                    select u).FirstOrDefault();
        }
    }
}