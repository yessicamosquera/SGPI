﻿using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Pago
    {
        public Pago()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
