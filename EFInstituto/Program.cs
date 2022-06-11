using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFInstituto
{
    class Maestro
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int MateriaId { get; set; }
    }

    class Alumno
    {
        public int id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int ProfesorId { get; set; }
    }

    class Materia
    {
        public int id { get; set; }

        public string Descripcion { get; set; }

        public string CursoDivision { get; set; }
    }

    class Profesor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int MateriaId { get; set; }
    }

    class EFInstitutoContext : DbContext
    {
        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Profesor> Profesor { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=VOSTRO\SQLEXPRESS2019;Initial catalog=Instituto2022;Integrated Security=true");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (EFInstitutoContext context = new EFInstitutoContext())
            {
                if (context.Maestro.Count() == 0 && context.Alumno.Count() == 0 && context.Materia.Count() == 0)
                {
                    CrearDatos(context);
                }

                MostrarDatos(context);

                Materia materia = new Materia();

                #region Agregar dato
                /*Console.Write("Descripción: ");
                materia.Descripcion = Console.ReadLine();

                Console.Write("Curso Division: ");
                materia.CursoDivision = Console.ReadLine();

                context.Materia.Add(materia); */
                #endregion

                #region Modificar dato
                /*
                Console.WriteLine("Datos a cambiar");
                Console.Write("Id Nateria: ");
                int id = int.Parse(Console.ReadLine());

                materia = context.Materia.Where(x => x.id == id).FirstOrDefault();

                Console.WriteLine("Descripción: {0}", materia.Descripcion);
                Console.WriteLine("Curso Division: {0}", materia.CursoDivision);

                Console.Write("Descripción: ");
                materia.Descripcion = Console.ReadLine();

                Console.Write("Curso Division: ");
                materia.CursoDivision = Console.ReadLine();

                context.SaveChanges();
                */
                #endregion

                #region Borrar datos
                /*
                Console.WriteLine("Datos a borrar");
                Console.Write("Id Nateria: ");
                int id = int.Parse(Console.ReadLine());

                materia = context.Materia.Where(x => x.id == id).FirstOrDefault();

                context.Materia.Remove(materia);

                context.SaveChanges();
                */
                #endregion
            }
        }

        /// <summary>
        /// Metodo para la creación de los la primera vez que se conecta con la DDBB.
        /// </summary>
        /// <param name="context">Una instancia de la clase DBContext</param>
        public static void CrearDatos(EFInstitutoContext context)
        {
            #region Agrego Materias.
            // Agrego las materias
            Materia materia = new Materia();

            materia.Descripcion = "Base de Datos Relacionales";
            materia.CursoDivision = "1A";
            context.Materia.Add(materia);

            materia = new Materia();

            materia.Descripcion = "Base de Datos No Relacionales";
            materia.CursoDivision = "1A";
            context.Materia.Add(materia);

            materia = new Materia();

            materia.Descripcion = "POO";
            materia.CursoDivision = "2A";
            context.Materia.Add(materia);

            materia = new Materia();

            materia.Descripcion = "Investigación Operativa";
            materia.CursoDivision = "3A";
            context.Materia.Add(materia);

            materia = new Materia();

            materia.Descripcion = "Ciencias de la Computación";
            materia.CursoDivision = "2A";
            context.Materia.Add(materia);

            context.SaveChanges();
            // Fin agregar Materias
            #endregion

            #region Agrego Maestros.
            //Agrego los maestros
            Maestro maestro = new Maestro();

            maestro.Nombre = "Javier";
            maestro.Apellido = "Chércoles";
            maestro.MateriaId = 3;
            context.Maestro.Add(maestro);

            maestro = new Maestro();
            maestro.Nombre = "José Luis";
            maestro.Apellido = "Caero";
            maestro.MateriaId = 1;
            context.Maestro.Add(maestro);

            maestro = new Maestro();
            maestro.Nombre = "Juan Carlos";
            maestro.Apellido = "Romero";
            maestro.MateriaId = 5;
            context.Maestro.Add(maestro);

            maestro = new Maestro();
            maestro.Nombre = "Mario";
            maestro.Apellido = "Perello";
            maestro.MateriaId = 2;
            context.Maestro.Add(maestro);

            maestro = new Maestro();
            maestro.Nombre = "Guillermo";
            maestro.Apellido = "Cherencio";
            maestro.MateriaId = 4;
            context.Maestro.Add(maestro);

            context.SaveChanges();
            //Fin agregar maestros
            #endregion

            #region Agrego Alumnos.
            // Agregar los alumnos

            Alumno alumno = new Alumno();

            alumno.Nombre = "Matias";
            alumno.Apellido = "Neto";
            alumno.ProfesorId = 1;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Raul Andres";
            alumno.Apellido = "Orlando";
            alumno.ProfesorId = 1;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Leonardo Martin";
            alumno.Apellido = "Alexandre";
            alumno.ProfesorId = 2;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Gastón Israel";
            alumno.Apellido = "Diaz";
            alumno.ProfesorId = 2;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Lucas";
            alumno.Apellido = "Carriquiry";
            alumno.ProfesorId = 3;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Martin";
            alumno.Apellido = "Carriquiry";
            alumno.ProfesorId = 3;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Brandon Gaston";
            alumno.Apellido = "Berrio";
            alumno.ProfesorId = 4;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Monica";
            alumno.Apellido = "Echegaray";
            alumno.ProfesorId = 4;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Santiago";
            alumno.Apellido = "Amenta";
            alumno.ProfesorId = 5;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Thiago";
            alumno.Apellido = "Miglioranza";
            alumno.ProfesorId = 5;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Luciano Carlos";
            alumno.Apellido = "Suppa";
            alumno.ProfesorId = 1;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Pablo Ariel";
            alumno.Apellido = "Soler";
            alumno.ProfesorId = 1;
            context.Alumno.Add(alumno);

            alumno = new Alumno();

            alumno.Nombre = "Alvaro";
            alumno.Apellido = "Astellano";
            alumno.ProfesorId = 2;
            context.Alumno.Add(alumno);

            context.SaveChanges();
            // Fin agregar alumnos
            #endregion
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
