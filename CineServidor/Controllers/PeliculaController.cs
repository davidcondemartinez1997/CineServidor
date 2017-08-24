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
    public class PeliculaController : ApiController
    {
        private IPeliculaService PeliculaService;

        public PeliculaController(IPeliculaService _PeliculaService)
        {
            this.PeliculaService = _PeliculaService;
        }

        // GET: api/Pelicula
        public IQueryable<Pelicula> GetPelicula()
        {
            return PeliculaService.Get();
        }

        // GET: api/Pelicula/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult GetPelicula(long id)
        {
            Pelicula Pelicula = PeliculaService.Get(id);
            if (Pelicula == null)
            {
                return NotFound();
            }

            return Ok(Pelicula);
        }

        // PUT: api/Pelicula/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPelicula(long id, Pelicula Pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Pelicula.Id)
            {
                return BadRequest();
            }

            try
            {
                PeliculaService.Put(Pelicula);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pelicula
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult PostPelicula(Pelicula Pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pelicula = PeliculaService.Create(Pelicula);

            return CreatedAtRoute("DefaultApi", new { id = Pelicula.Id }, Pelicula);
        }

        // DELETE: api/Pelicula/5
        [ResponseType(typeof(Pelicula))]
        public IHttpActionResult DeletePelicula(long id)
        {
            Pelicula Pelicula;
            try
            {
                Pelicula = PeliculaService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(Pelicula);
        }
    }
}