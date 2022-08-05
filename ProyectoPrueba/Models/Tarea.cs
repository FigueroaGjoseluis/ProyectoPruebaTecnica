using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.Models
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string Estado { get; set; }
    }
}
