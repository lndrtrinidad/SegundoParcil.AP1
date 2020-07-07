using SegundoParcial.AP1.DAL;
using SegundoParcial.AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial.AP1.BLL
{
    public class DetalleTareaBLL
    {
        public static List<Proyecto> GetList()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyecto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyectos;
        }
    }
}
