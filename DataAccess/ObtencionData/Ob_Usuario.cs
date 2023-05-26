using DataAccess.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ObtencionData
{
    public  class Ob_Usuario
    {
        public AspNetUser obtenerUsuarioPorId ( string usuarioId)
        {
            using( var nuevoContexto = new AsistenteBDContext())
            {
                return nuevoContexto.AspNetUsers.Where( e=> e.Id == usuarioId).FirstOrDefault();
            }
        }

        public void ActualizarUsuario( AspNetUser usuario) {
            using (var nuevoContexto = new AsistenteBDContext())
            {
                nuevoContexto.AspNetUsers.Update( usuario );
                nuevoContexto.SaveChanges();
            }
        }

        public async Task<bool> AsignarPensumViejo( string usuarioId)
        {

            using( var context = new AsistenteBDContext())
            {

                //VALIDAR QUE EL USUARIO EXISTE
                var usuario = context.AspNetUsers.Where( e=> e.Id==usuarioId).FirstOrDefault();
                if (usuario == null)
                {
                    return false;
                }

                var cantidadRegistros = context.Relacions.Where(e => e.AspNetUserId == usuarioId ).Count();
                if( cantidadRegistros > 0)
                {
                    //si entra aca es porque ya existe por lo que no lo asignaremos nuevamente.
                    return false;
                }

                //Si llega aca entonces hay que hacer una insercion en la base de datos de relaciones

                List<Curso> cursos = context.Cursos.ToList();

                foreach (var curso in cursos)
                {
                    Relacion nuevaRelacion = new Relacion();
                    nuevaRelacion.RelacionId = Guid.NewGuid().ToString();
                    nuevaRelacion.Estado = false;
                    nuevaRelacion.Color = "";
                    nuevaRelacion.CursoId = curso.CursoId;
                    nuevaRelacion.AspNetUserId = usuarioId;

                    context.Relacions.Add(nuevaRelacion);
                    context.SaveChanges();

                }

                //Tambien hay que cambiar el estado del usuario
                usuario.AsignacionVieja = false;
                context.AspNetUsers.Update(usuario);
                context.SaveChanges();

                return true;

            }

        }
    
        public List<Curso> ObtenerCursosPorId( string usuarioId)
        {
            using( var context = new AsistenteBDContext() )
            {
                return context.Relacions.Where(e => e.AspNetUserId == usuarioId).Select(e => e.Curso).ToList();
            }
        } 

        public int ObtenerAprovadosPorId( string usuarioId)
        {
            using (var context = new AsistenteBDContext())
            {
                return context.Relacions.Where(e => e.AspNetUserId == usuarioId && e.Estado).Count();
            }
        }

        public int ObtenerCreditosPorId(string usuarioId)
        {
            using (var context = new AsistenteBDContext())
            {
                return context.Relacions.Where(e => e.AspNetUserId == usuarioId && e.Estado).Sum( e=> e.Curso.Creditos );
            }
        }

        //Metodo para retornar las relaciones de un usuario mediante su ID
        public List<Relacion> ObtenerRelacionesPorId( string usuarioId)
        {
            using( var context = new AsistenteBDContext())
            {
                return context.Relacions.Where( e => e.AspNetUserId == usuarioId ).Include( e=> e.Curso ).OrderBy( e => e.Curso.Semestre).ToList();
            }
        }


        //Metodo para cambiar el estado en la tabla de relaciones
        public void CambiarEstado(string idRelacion)
        {
            using (var context = new AsistenteBDContext())
            {
                Relacion relacion = context.Relacions.Where(e => e.RelacionId == idRelacion).FirstOrDefault();
                if( relacion != null ) {
                    relacion.Estado = !relacion.Estado;
                    context.Relacions.Update(relacion);
                    context.SaveChanges();
                }
            }
        }
    }
}
