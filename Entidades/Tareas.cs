﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoParcial.AP1.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public string TipoTarea { get; set; }
    }
}
