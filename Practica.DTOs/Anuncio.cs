using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.DTOs
{
    public class Anuncio
    {
        public Int32 Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public Int32 Precio { get; set; }

        public string Imagen { get; set; }
    }
}
