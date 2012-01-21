using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polendamus.Enums;

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

        public void CalculaDescripcion(Niveles nivel)
        {
            if (nivel.Alergias.EsArbol.HasValue)
            {
                //Es Arbol
                if (nivel.Alergias.EsArbol.Value)
                {
                    nivel.Descripcion = GetNivelPolenArbol(nivel.Estado).ToString();
                }
                else//Es planta
                {
                    nivel.Descripcion = GetNivelPolenPlanta(nivel.Estado).ToString();
                }
            }
        }

        private int GetNivelPolenArbol(string estado)
        {
            int resultado=0;
            if (Int32.Parse(estado) == 0)
            {
                resultado = ValoresPolen.Nulo;
            }
            else if (1 <= Int32.Parse(estado) && Int32.Parse(estado) <= 50)
            {
                resultado = ValoresPolen.Bajo;
            }
            else if (51 <= Int32.Parse(estado) && Int32.Parse(estado) <= 200)
            {
                resultado = ValoresPolen.Medio;
            }
            else if (201 <= Int32.Parse(estado) && Int32.Parse(estado) <= 400)
            {
                resultado = ValoresPolen.Alto;
            }
            else if (Int32.Parse(estado) > 400)
            {
                resultado = ValoresPolen.MuyAlto;
            }
            return resultado;
        }

        private int GetNivelPolenPlanta(string estado)
        {
            int resultado = 0;
            if (Int32.Parse(estado) == 0)
            {
                resultado = ValoresPolen.Nulo;
            }
            else if (1 <= Int32.Parse(estado) && Int32.Parse(estado) <= 15)
            {
                resultado = ValoresPolen.Bajo;
            }
            else if (16 <= Int32.Parse(estado) && Int32.Parse(estado) <= 30)
            {
                resultado = ValoresPolen.Medio;
            }
            else if (31 <= Int32.Parse(estado) && Int32.Parse(estado) <= 50)
            {
                resultado = ValoresPolen.Alto;
            }
            else if (Int32.Parse(estado) > 250)
            {
                resultado = ValoresPolen.MuyAlto;
            }
            return resultado;
        }
    }
}