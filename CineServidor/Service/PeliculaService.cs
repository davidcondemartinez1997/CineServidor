
using CineServidor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineServidor.Service
{
    public class PeliculaService : IPeliculaService
    {
        private IPeliculaRepository IPeliculaRepository;

        public PeliculaService(IPeliculaRepository _IPeliculaRepository)
        {
            this.IPeliculaRepository = _IPeliculaRepository;
        }

        public Pelicula Get(long id)
        {
            return IPeliculaRepository.Get(id);
        }

        public IQueryable<Pelicula> Get()
        {
            return IPeliculaRepository.Get();
        }

        public Pelicula Create(Pelicula Pelicula)
        {
            return IPeliculaRepository.Create(Pelicula);
        }

        public void Put(Pelicula Pelicula)
        {
            IPeliculaRepository.Put(Pelicula);
        }

        public Pelicula Delete(long id)
        {
            return IPeliculaRepository.Delete(id);
        }
    }
}