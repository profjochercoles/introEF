using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFInstituto
{
    class EFInstitutoContext : DbContext
    {
        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Materia> Materia { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=VOSTRO\SQLEXPRESS2019;Initial catalog=Instituto2022;Integrated Security=true");
            optionsBuilder.UseSqlServer(@"Data Source=LOGAN\SQLEXPRESS;Initial catalog=Instituto2022;Integrated Security=true");
        }
    }

    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            using (EFInstitutoContext context = new EFInstitutoContext())
            {
                if (context.Maestro.Count() == 0 && context.Alumno.Count() == 0 && context.Materia.Count() == 0)
                {
                    MenuCarga(context);
                }

                MainMenu(context);
            }
        }

        public static void MostrarDatos(EFInstitutoContext context)
        {
            #region Muestro los datos.
            Console.WriteLine("\r\nList");
            List<Maestro> maestros = context.Maestro.ToList();

            maestros = maestros.Where(mae => mae.Id >= 3).ToList();
            foreach (Maestro mae in maestros)
            {
                Console.WriteLine("{0} {1} {2}", mae.Id, mae.Nombre, mae.Apellido);
            }

            Console.WriteLine("\r\nList con Linq");
            List<Maestro> maestros2 = (List<Maestro>)(from mae in context.Maestro select mae).ToList();

            maestros2 = maestros2.Where(mae => mae.Id >= 3).ToList();
            foreach (Maestro mae in maestros2)
            {
                Console.WriteLine("{0} {1} {2}", mae.Id, mae.Nombre, mae.Apellido);
            }

            Console.WriteLine("\r\nIEnumerable con Linq");
            IEnumerable<Maestro> maestros3 = from mae in context.Maestro select mae;

            maestros3 = maestros3.Where(mae => mae.Id >= 3);
            foreach (Maestro mae in maestros3)
            {
                Console.WriteLine("{0} {1} {2}", mae.Id, mae.Nombre, mae.Apellido);
            }

            Console.WriteLine("\r\nIQueryable con Linq");
            IQueryable<Maestro> maestros4 = from mae in context.Maestro select mae;

            maestros4 = maestros4.Where(mae => mae.Id >= 3);
            foreach (Maestro mae in maestros4)
            {
                Console.WriteLine("{0} {1} {2}", mae.Id, mae.Nombre, mae.Apellido);
            }
            #endregion
        }
    }
}
