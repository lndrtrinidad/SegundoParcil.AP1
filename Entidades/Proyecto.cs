using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoParcial.AP1.Entidades
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        
    }
}
