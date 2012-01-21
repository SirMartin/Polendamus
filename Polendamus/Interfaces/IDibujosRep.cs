using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IDibujosRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Dibujos> GetDibujos();
        
    }
}