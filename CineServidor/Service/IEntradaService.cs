using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineServidor.Service
{
    public interface IEntradaService
    {
        Entrada Create(Entrada Entrada);
        Entrada Get(long id);
        IQueryable<Entrada> Get();
        void Put(Entrada Entrada);
        Entrada Delete(long id);
    }
}
