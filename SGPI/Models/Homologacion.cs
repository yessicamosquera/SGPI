using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Homologacion
    {
        public int IdHomologacion { get; set; }
        public int IdEstudiante { get; set; }
        public string PeriodoAcademico { get; set; } = null!;
        public double Nota { get; set; }
        public int IdPrograma { get; set; }
        public int IdModulo { get; set; }
        public string CodigoHomologacion { get; set; } = null!;
        public string NomAsigHomologacion { get; set; } = null!;
        public int CreditosHomologacion { get; set; }
        public int IdTipoHomolo { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
        public virtual TipoHomologacion IdHomologacionNavigation { get; set; } = null!;
        public virtual Modulo IdModuloNavigation { get; set; } = null!;
        public virtual Programa IdProgramaNavigation { get; set; } = null!;
    }
}
