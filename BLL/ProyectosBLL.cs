using System;
using System.Collections.Generic;
using System.Text;
using SegundoParcial.AP1.Entidades;
using SegundoParcial.AP1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace SegundoParcial.AP1.BLL
{
    class ProyectosBLL
    {
        public static bool Guardar (Proyecto proyecto)
        {
            bool paso;

            if (!Existe(proyecto.TareaId))
                paso = Insertar(proyecto);
            else
                paso = Modificar(proyecto);
            return paso;
        }
        public static bool Insertar(Proyecto proyecto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Proyecto.Add(proyecto);
                paso = contexto.SaveChanges() > 0;
            }
            catch 
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Proyecto proyecto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From DetalleTarea Where Proyecto={proyecto.TareaId}");

                foreach(var item in proyecto.TipoTarea)
                {
                    contexto.Entry(proyecto).State = EntityState.Added;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyecto = contexto.Proyecto.Find(Id);
                if (proyecto != null)
                {
                    contexto.Proyecto.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            List<Proyecto> lista = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyecto.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int Id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();
            try
            {
                encontrado = contexto.Proyecto.Any(p => p.TareaId == Id);

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static Proyecto Buscar(int Id)
        {
            Proyecto proyecto = new Proyecto();
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyecto
                    .Where(p => p.TareaId == Id)
                    .SingleOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }
    }
}
