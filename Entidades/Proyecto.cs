using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegundoParcial.AP1.Entidades
{
    public class Proyecto
    {
        [Key]
        public int TareaId { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public string TipoTarea { get; set; }
        
        [ForeignKey("ProyectoId")]
        public virtual List<DetalleTarea> Detalle { get; set; } = new List<DetalleTarea>();
    }
}


