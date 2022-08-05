using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPrueba.Models;

namespace ProyectoPrueba.DTBConnection
{
    public class CRUD
    {
        private readonly string estadoNoCompletado = "NC";
        private readonly string estadoCompletado = "C";

        public void Insert(string nombre)
        {
            try
            {
                using (PruebaContext cn = new PruebaContext())
                {
                    Tarea tarea = new Tarea();
                    tarea.Nombre = nombre;
                    tarea.CreatedAt = DateTime.Now;
                    tarea.Estado = estadoNoCompletado;
                    cn.Tareas.Add(tarea);
                    cn.SaveChanges();

                }
            }
            catch(Exception e)
            {

            }
        }


        public List<Tarea> Get()
        {
            try
            {

                using (PruebaContext cn = new PruebaContext())
                {

                    var query = (from d in cn.Tareas where d.Estado == estadoNoCompletado select d).ToList();
                    return query;


                }
            }catch(Exception e)
            {
                return null;

            }

        }


        public void Update(int id)
        {
            try
            {


                using (PruebaContext cn = new PruebaContext())
                {
                    Tarea tarea = cn.Tareas.Find(id);
                    tarea.Estado = estadoCompletado;
                    tarea.CompletedAt = DateTime.Now;
                    cn.Entry(tarea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    cn.SaveChanges();



                }
            }
            catch(Exception e) {
            
            }


        }


        public void Borrar(int id)
        {

            try
            {


                using (PruebaContext cn = new PruebaContext())
                {
                    Tarea tarea = cn.Tareas.Find(id);
                    cn.Tareas.Remove(tarea);
                    cn.SaveChanges();



                }

            }catch(Exception e)
            {



            }

        }



    }
}
