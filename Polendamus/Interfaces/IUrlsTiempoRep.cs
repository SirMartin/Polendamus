using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface IUrlsTiempoRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<UrlsTiempo> GetUrlsTiempo();
        UrlsTiempo GetUrlByIdProvincia(int idProvincia);
    }
}