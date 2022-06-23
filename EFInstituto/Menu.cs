using System;
using System.Linq;

namespace EFInstituto
{
    internal class ProgramBase
    {
        public static void MainMenu(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write(@"
                    #########################
                    # Menu Principal        #
                    #########################
                    # Cargar:               #
                    #   1-Alta              #
                    #   2-Baja              #
                    #   3-Modificacion      #
                    #   4-Consultar Datos   #
                    #   0-Salir             #
                    #########################
            
                    Seleccione una opcion: ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            MenuCarga(context);
                            break;
                        case 2:
                            MenuBaja(context);
                            break;
                        case 3:
                            MenuModificacion(context);
                            break;
                        case 4:
                            MenuConsulta(context);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                }
            } while (!exit);
        }
        public static void MenuCarga(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write(@"
                    #########################
                    # Menu de carga de datos#
                    #########################
                    # Cargar:               #
                    #   1-Maestros          #
                    #   2-Alumnos           #
                    #   3-Materias          #
                    #   0-Volver            #
                    #########################
            
                    Seleccione una opcion: ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            CrearMaestro(context);
                            break;
                        case 2:
                            CrearAlumno(context);
                            break;
                        case 3:
                            CrearMateria(context);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                }
            } while (!exit);

        }
        private static void CrearMaestro(EFInstitutoContext context)
        {
            try
            {
                Console.WriteLine("*CARGAR NUEVO MAESTRO*");
                Maestro maestro = new Maestro();
                Console.WriteLine("Nombre: ");
                maestro.Nombre = Console.ReadLine();
                Console.WriteLine("Apellido: ");
                maestro.Apellido = Console.ReadLine();
                Console.WriteLine("Id de Materia: ");
                maestro.MateriaId = Convert.ToInt16(Console.ReadLine());
                context.Maestro.Add(maestro);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
                Console.Clear();
            }
        }
        private static void CrearAlumno(EFInstitutoContext context)
        {
            try
            {
                Console.WriteLine("*CARGAR NUEVO ALUMNO*");
                Alumno alumno = new Alumno();
                Console.WriteLine("Nombre :");
                alumno.Nombre = Console.ReadLine();
                Console.WriteLine("Apellido: ");
                alumno.Apellido = Console.ReadLine();
                Console.WriteLine("ID de Maestro: ");
                alumno.ProfesorId = Convert.ToInt16(Console.ReadLine());
                context.Alumno.Add(alumno);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
                Console.Clear();
            }
        }
        private static void CrearMateria(EFInstitutoContext context)
        {
            try
            {
                Console.WriteLine("*CARGAR NUEVA MATERIA*");
                Materia materia = new Materia();
                Console.WriteLine("Nombre de la materia");
                materia.Descripcion = Console.ReadLine();
                Console.WriteLine("CursoDivision");
                materia.CursoDivision = Console.ReadLine();
                context.Materia.Add(materia);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void MenuBaja(EFInstitutoContext context) 
        {
            var exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write(@"
                    ##########################
                    # Menu de carga de datos #
                    ##########################
                    # Eliminar:              #
                    #   1-Maestros           #
                    #   2-Alumnos            #
                    #   3-Materias           #
                    #   0-Volver             #
                    ##########################
            
                    Seleccione una opcion: ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            EliminarMaestros(context);
                            break;
                        case 2:
                            EliminarAlumnos(context);
                            break;
                        case 3:
                            EliminarMaterias(context);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }
        private static void EliminarMaestros(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*ELIMINAR MAESTRO*");
                    Console.Write("Ingrese ID de Maestro: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Va a eliminar un Maestro, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.Maestro.Remove(context.Maestro.Where(x => x.Id == id).FirstOrDefault());
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();

                }
                #endregion
            } while (!exit);
        }
        private static void EliminarAlumnos(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*ELIMINAR ALUMNOS*");
                    Console.Write("Ingrese ID del Alumno: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Va a eliminar un Alumno, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.Alumno.Remove(context.Alumno.Where(x => x.Id == id).FirstOrDefault());
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                    
                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }
        private static void EliminarMaterias(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*ELIMINAR MATERIA*");
                    Console.Write("Ingrese ID de Materia: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Va a eliminar un Materia, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.Materia.Remove(context.Materia.Where(x => x.Id == id).FirstOrDefault());
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }

        public static void MenuModificacion(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write(@"
                    #################################
                    # Menu de modificacion de datos #
                    #################################
                    # Modificar:                    #
                    #   1-Maestros                  #
                    #   2-Alumnos                   #
                    #   3-Materias                  #
                    #   0-Volver                    #
                    #################################
            
                    Seleccione una opcion: ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            ModificarMaestros(context);
                            break;
                        case 2:
                            ModificarAlumnos(context);
                            break;
                        case 3:
                            ModificarMaterias(context);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }

        private static void ModificarMaestros(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*MODIFICAR MAESTRO*");
                    Console.Write("Ingrese ID de Maestro: ");
                    int id = int.Parse(Console.ReadLine());
                    var maestro = context.Maestro.Where(x => x.Id == id).FirstOrDefault();
                    Console.WriteLine($"Nombre y Apellido: {maestro.Nombre} {maestro.Apellido}");
                    //Devuelve la descripcion de la materia.
                    Console.WriteLine($"Materia a cargo: {(context.Materia.Where(x => x.Id == maestro.MateriaId).FirstOrDefault()).Descripcion}");

                    Console.Write("Nombre: ");
                    var nombre = Console.ReadLine();
                    if (nombre != null) { maestro.Nombre = nombre; }

                    Console.Write("Apellido: ");
                    var apellido = Console.ReadLine();
                    if (apellido != null) { maestro.Apellido = apellido; }

                    Console.Write("Id Materia: ");
                    var idMateria = int.Parse(Console.ReadLine());
                    if (idMateria >= 0) { maestro.MateriaId = idMateria; }

                    Console.WriteLine("Va a Modificar un Maestro, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }

        private static void ModificarAlumnos(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*MODIFICAR ALUMNOS*");
                    Console.Write("Ingrese ID del Alumno: ");
                    int id = int.Parse(Console.ReadLine());
                    var alumno = context.Alumno.Where(x => x.Id == id).FirstOrDefault();
                    Console.WriteLine($"Nombre y Apellido: {alumno.Nombre} {alumno.Apellido}");
                    //Devuelve el nombre del Maestro
                    Console.WriteLine($"Maestro: {(context.Maestro.Where(x => x.Id == alumno.ProfesorId).FirstOrDefault()).Nombre}");
                    
                    Console.Write("Nombre: ");
                    var nombre = Console.ReadLine();
                    if (nombre != null) { alumno.Nombre= nombre; }
                    
                    Console.Write("Apellido: ");
                    var apellido = Console.ReadLine();
                    if (apellido != null) { alumno.Apellido = apellido; }

                    Console.Write("ID Profesor: ");
                    var profesor = int.Parse(Console.ReadLine());
                    if (profesor >= 0) { alumno.ProfesorId = profesor; }

                    Console.WriteLine("Va a Modificar un Alumno, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }

                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }
        
        private static void ModificarMaterias(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.WriteLine("*MODIFICAR MATERIA*");
                    Console.Write("Ingrese ID de Materia: ");
                    int id = int.Parse(Console.ReadLine());
                    var materia = context.Materia.Where(x => x.Id == id).FirstOrDefault();
                    Console.WriteLine($"Descripción: {materia.Descripcion}");
                    Console.WriteLine($"Curso Division: {materia.CursoDivision}");
                    
                    Console.Write("Descripción: ");
                    var descripcion = Console.ReadLine();
                    if (descripcion != null) { materia.Descripcion = descripcion; }
                    
                    Console.Write("Curso Division: ");
                    var cursoDivision = Console.ReadLine();
                    if (cursoDivision != null) { materia.CursoDivision = cursoDivision; } 
                    

                    Console.WriteLine("Va a Modificar un Materia, esta seguro? S/N");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "S":
                            context.SaveChanges();
                            exit = true;
                            break;
                        case "N":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }

        public static void MenuConsulta(EFInstitutoContext context)
        {
            var exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write(@"
                    #################################
                    # Menu de consulta de datos     #
                    #################################
                    # Mostrar:                      #
                    #   1-Maestros                  #
                    #   2-Alumnos                   #
                    #   3-Materias                  #
                    #   0-Volver                    #
                    #################################
            
                    Seleccione una opcion: ");
                    var input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            ModificarMaestros(context);
                            break;
                        case 2:
                            ModificarAlumnos(context);
                            break;
                        case 3:
                            ModificarMaterias(context);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                }
                #region Catch
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);


        }
}