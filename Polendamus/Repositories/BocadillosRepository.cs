using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class BocadillosRepository:BaseRepository, Interfaces.IBocadillosRep
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

        public IQueryable<Bocadillos> GetBocadillos()
        {
            return (from u in _dbContext.Bocadillos
                    select u);
        }

        public IQueryable<Bocadillos> GetBocadillosIniciales(bool esinicio)
        {
            return (from u in _dbContext.Bocadillos
                    where u.EsGet==esinicio
                    select u);
        }
      
    }
}