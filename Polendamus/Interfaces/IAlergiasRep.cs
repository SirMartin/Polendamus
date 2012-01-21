using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IAlergiasRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Alergias> GetAlergias();
        Alergias GetAlergiasByName(string nombre);
    }
}