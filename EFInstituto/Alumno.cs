using System;
using System.Collections.Generic;
using System.Text;

namespace EFInstituto
{
    internal class Alumno
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int ProfesorId { get; set; }
    }
}
