﻿using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Programacion
    {
        public int IdProgramacion { get; set; }
        public string PeriodoAcademico { get; set; } = null!;
        public int IdPrograma { get; set; }
        public DateTime FechaProgramacion { get; set; }
        public string Salon { get; set; } = null!;
        public int IdModulo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual Programa IdProgramaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
