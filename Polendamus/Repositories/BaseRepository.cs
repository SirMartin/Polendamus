using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Objects;

namespace Polendamus.Repositories
{
    public class BaseRepository
    {
        private polendamusEntities CreateNew()
        {
            polendamusEntities db = new polendamusEntities();
            return db;
        }

        private static void context_SavingChanges(object sender, EventArgs e)
        {

            // Ensure that we are passed an ObjectContext
            polendamusEntities context = sender as polendamusEntities;
            if (context != null)
            {
                // Validate the state of each entity in the context
                // before SaveChanges can succeed.
                foreach (ObjectStateEntry entry in
                    context.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Added | EntityState.Modified))
                {
                    // Find an object state entry for a SalesOrderHeader object. 
                    if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(Provincias)))
                    {
                        Provincias provincias = entry.Entity as Provincias;

                    }
                    else if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(Alergias)))
                    {
                        Alergias alergias = entry.Entity as Alergias;
                    }
                    else if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(UrlsTiempo)))
                    {
                        UrlsTiempo urlsTiempo = entry.Entity as UrlsTiempo;
                    }
                    else if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(Predicciones)))
                    {
                        Predicciones predicciones = entry.Entity as Predicciones;
                    }
                    else if (!entry.IsRelationship && (entry.Entity.GetType() == typeof(Niveles)))
                    {
                        Niveles niveles = entry.Entity as Niveles;
                       
                    }
                }
            }

        }
    }
}