﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineServidor
{
    public class Pelicula
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Pais { get; set; }
        public string Genero { get; set; }
    }
}