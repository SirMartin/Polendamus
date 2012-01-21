using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class DibujosRepository:BaseRepository, Interfaces.IDibujosRep
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

        public IQueryable<Dibujos> GetDibujos()
        {
            return (from u in _dbContext.Dibujos
                    select u);
        }
      
    }
}