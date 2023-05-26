using System;
using System.Collections.Generic;

namespace DataAccess.Models.DB
{
    public partial class Relacion
    {
        public string RelacionId { get; set; } = null!;
        public bool Estado { get; set; }
        public string Color { get; set; } = null!;
        public string CursoId { get; set; } = null!;
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
        public virtual Curso Curso { get; set; } = null!;
    }
}
