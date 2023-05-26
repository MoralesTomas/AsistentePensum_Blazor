using System;
using System.Collections.Generic;

namespace DataAccess.Models.DB
{
    public partial class Curso
    {
        public Curso()
        {
            Relacions = new HashSet<Relacion>();
        }

        public string CursoId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string PreRequisitos { get; set; } = null!;
        public int Creditos { get; set; }
        public int Semestre { get; set; }
        public bool Obligatorio { get; set; }
        public int CrMin { get; set; }
        public bool PensumViejo { get; set; }

        public virtual ICollection<Relacion> Relacions { get; set; }
    }
}
