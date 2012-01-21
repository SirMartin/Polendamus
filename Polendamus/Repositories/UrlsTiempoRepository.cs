using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class UrlsTiempoRepository:BaseRepository, Interfaces.IUrlsTiempoRep
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

        public IQueryable<UrlsTiempo> GetUrlsTiempo()
        {
            return (from u in _dbContext.UrlsTiempo
                    select u);
        }

        public UrlsTiempo GetUrlByIdProvincia(int idProvincia)
        {
            return (from u in _dbContext.UrlsTiempo
                    where u.Id_Provincia == idProvincia
                    select u).FirstOrDefault();
        }
    }
}