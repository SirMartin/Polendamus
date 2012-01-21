using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polendamus.Repositories
{
    public class AlergiasRepository:BaseRepository, Interfaces.IAlergiasRep
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

        public IQueryable<Alergias> GetAlergias()
        {
            return (from u in _dbContext.Alergias
                    where u.Visible==true
                    select u);
        }
        public Alergias GetAlergiasByName(string nombre)
        {
            return (from u in _dbContext.Alergias
                    where u.Nombre.Equals(nombre) && u.Visible==true
                    select u).FirstOrDefault();
        }

        public Alergias GetAlergiasById(int idPlanta)
        {
            return (from u in _dbContext.Alergias
                    where u.Id == idPlanta && u.Visible==true
                    select u).FirstOrDefault();
        }
    }
}