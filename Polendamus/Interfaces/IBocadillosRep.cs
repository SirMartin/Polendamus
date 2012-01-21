using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IBocadillosRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Bocadillos> GetBocadillos();
        IQueryable<Bocadillos> GetBocadillosIniciales(bool esinicio);
        
    }
}