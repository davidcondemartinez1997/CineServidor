using CineServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CineServidor.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        public Pelicula Create(Pelicula Pelicula)
        {
            return ApplicationDbContext.applicationDbContext.Pelicula.Add(Pelicula);
        }

        public Pelicula Delete(long id)
        {
            Pelicula Pelicula = ApplicationDbContext.applicationDbContext.Pelicula.Find(id);
            if (Pelicula == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Pelicula.Remove(Pelicula);
            return Pelicula;
        }

        public IQueryable<Pelicula> Get()
        {
            IList<Pelicula> lista = new List<Pelicula>(ApplicationDbContext.applicationDbContext.Pelicula);

            return lista.AsQueryable();
        }

        public Pelicula Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Pelicula.Find(id);
        }

        public void Put(Pelicula Pelicula)
        {
            if (ApplicationDbContext.applicationDbContext.Pelicula.Count(e => e.Id == Pelicula.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(Pelicula).State = EntityState.Modified;
        }
    }
}
