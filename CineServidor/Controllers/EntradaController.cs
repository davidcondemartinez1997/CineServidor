using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CineServidor;
using CineServidor.Models;
using CineServidor.Service;
using System.Web.Http.Cors;

namespace CineServidor.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntradaController : ApiController
    {
        private IEntradaService EntradaService;

        public EntradaController(IEntradaService _EntradaService)
        {
            this.EntradaService = _EntradaService;
        }

        // GET: api/Entrada
        public IQueryable<Entrada> GetEntrada()
        {
            return EntradaService.Get();
        }

        // GET: api/Entrada/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada Entrada = EntradaService.Get(id);
            if (Entrada == null)
            {
                return NotFound();
            }

            return Ok(Entrada);
        }

        // PUT: api/Entrada/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada Entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Entrada.Id)
            {
                return BadRequest();
            }

            try
            {
                EntradaService.Put(Entrada);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entrada
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada Entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entrada = EntradaService.Create(Entrada);

            return CreatedAtRoute("DefaultApi", new { id = Entrada.Id }, Entrada);
        }

        // DELETE: api/Entrada/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada Entrada;
            try
            {
                Entrada = EntradaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(Entrada);
        }
    }
}