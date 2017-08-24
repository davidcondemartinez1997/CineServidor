using CineServidor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CineServidor.Repository
{
    public class EntradaRepository : IEntradaRepository
    {
        public Entrada Create(Entrada Entrada)
        {
            return ApplicationDbContext.applicationDbContext.Entrada.Add(Entrada);
        }

        public Entrada Delete(long id)
        {
            Entrada Entrada = ApplicationDbContext.applicationDbContext.Entrada.Find(id);
            if (Entrada == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Entrada.Remove(Entrada);
            return Entrada;
        }

        public IQueryable<Entrada> Get()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entrada);

            return lista.AsQueryable();
        }

        public Entrada Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Entrada.Find(id);
        }

        public void Put(Entrada Entrada)
        {
            if (ApplicationDbContext.applicationDbContext.Entrada.Count(e => e.Id == Entrada.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(Entrada).State = EntityState.Modified;
        }
    }
}
