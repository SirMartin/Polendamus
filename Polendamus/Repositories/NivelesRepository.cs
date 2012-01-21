using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class NivelesRepository:BaseRepository, Interfaces.INivelesRep
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

        public IQueryable<Niveles> GetNiveles()
        {
            return (from u in _dbContext.Niveles
                    select u);
        }
        public Niveles GetNivelesByProvByAlergia(int idProv, int idAlergia)
        {
            return (from u in _dbContext.Niveles
                    where u.Id_Provincia == idProv && u.Id_Planta==idAlergia
                    select u).FirstOrDefault();
        }

        public void AddNivel(Niveles nivel)
        {
            _dbContext.AddToNiveles(nivel);
            //_dbContext.SaveChanges();
        }

        public void Clean()
        {
            foreach (var item in _dbContext.Niveles)
            {
                _dbContext.Niveles.DeleteObject(item);
            }
            _dbContext.SaveChanges();
        }
    }
}