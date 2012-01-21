using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IProvinciasRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Provincias> GetProvincias();
        Provincias GetProvinciaByName(string nombre);
    }
}