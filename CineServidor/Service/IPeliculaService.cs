using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineServidor.Service
{
    public interface IPeliculaService
    {
        Pelicula Create(Pelicula Pelicula);
        Pelicula Get(long id);
        IQueryable<Pelicula> Get();
        void Put(Pelicula Pelicula);
        Pelicula Delete(long id);
    }
}
