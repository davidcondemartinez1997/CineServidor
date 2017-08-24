
using CineServidor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineServidor.Service
{
    public class EntradaService : IEntradaService
    {
        private IEntradaRepository IEntradaRepository;

        public EntradaService(IEntradaRepository _IEntradaRepository)
        {
            this.IEntradaRepository = _IEntradaRepository;
        }

        public Entrada Get(long id)
        {
            return IEntradaRepository.Get(id);
        }

        public IQueryable<Entrada> Get()
        {
            return IEntradaRepository.Get();
        }

        public Entrada Create(Entrada Entrada)
        {
            return IEntradaRepository.Create(Entrada);
        }

        public void Put(Entrada Entrada)
        {
            IEntradaRepository.Put(Entrada);
        }

        public Entrada Delete(long id)
        {
            return IEntradaRepository.Delete(id);
        }
    }
}