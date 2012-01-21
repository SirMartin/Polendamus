using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Interfaces
{
    public interface INivelesRep
    {
        polendamusEntities DBContext
        {
            get;
            set;
        }

        IQueryable<Niveles> GetNiveles();
        Niveles GetNivelesByProvByAlergia(int idProv, int idAlergia);
        void Clean();
        void AddNivel(Niveles nivel);
    }
}