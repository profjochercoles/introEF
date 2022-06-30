using System;
using System.Collections.Generic;
using System.Linq;

namespace EFInstituto
{
    internal class ProgramBase
    {
        #region MenuPrincipal
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
        #endregion

        #region MenuCarga
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
            Console.WriteLine("*CARGAR NUEVO MAESTRO*");
            Maestro maestro = new Maestro();
                
            Console.WriteLine("Nombre: ");
            maestro.Nombre = Console.ReadLine() ?? throw new Exception ("El valor Nombre no puede ser nulo");
                
            Console.WriteLine("Apellido: ");
            maestro.Apellido = Console.ReadLine() ?? throw new Exception("El valor Apellido no puede ser nulo");
                
            Console.WriteLine("Id de Materia: ");
            if (!int.TryParse(Console.ReadLine(), out int idMateria))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }

            List<Materia> materia = (List<Materia>)(from mate in context.Materia select mate).ToList();
            if (materia.Any(mat => mat.Id == idMateria))
            {
                maestro.MateriaId = idMateria;
                context.Maestro.Add(maestro);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("*ERROR* ID de materia inexistente");
            }
        }
        private static void CrearAlumno(EFInstitutoContext context)
        {
            Console.WriteLine("*CARGAR NUEVO ALUMNO*");
            Alumno alumno = new Alumno();
                
            Console.WriteLine("Nombre :");
            alumno.Nombre = Console.ReadLine() ?? throw new Exception("El valor Nombre no puede ser nulo");
                
            Console.WriteLine("Apellido: ");
            alumno.Apellido = Console.ReadLine() ?? throw new Exception("El valor Apellido no puede ser nulo");
                
            Console.WriteLine("ID de Maestro: ");
            if (!int.TryParse(Console.ReadLine(), out int idMaestro))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }

            List<Maestro> maestro = (List<Maestro>)(from mae in context.Maestro select mae).ToList();
            if (maestro.Any(mae => mae.Id == idMaestro))
            {
                alumno.ProfesorId = idMaestro;
                context.Alumno.Add(alumno);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("*ERROR* ID de maestro inexistente");
            }
        }
        private static void CrearMateria(EFInstitutoContext context)
        {
            Console.WriteLine("*CARGAR NUEVA MATERIA*");
            Materia materia = new Materia();
                
            Console.WriteLine("Nombre de la materia: ");
            materia.Descripcion = Console.ReadLine() ?? throw new Exception("El valor Nombre no puede ser nulo");
                
            Console.WriteLine("Curso/Division: ");
            materia.CursoDivision = Console.ReadLine() ?? throw new Exception("El valor CursoDivision no puede ser nulo");
                
            context.Materia.Add(materia);
            context.SaveChanges();
        }
        #endregion

        #region MenuBaja
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
                    Console.WriteLine(ex);
                    Console.ReadKey();
                    Console.Clear();
                }
                #endregion
            } while (!exit);
        }
        private static void EliminarMaestros(EFInstitutoContext context)
        {
           
            Console.WriteLine("*ELIMINAR MAESTRO*");
            Console.Write("Ingrese ID de Maestro: ");

            int idMaestro;
            if (!int.TryParse(Console.ReadLine(), out idMaestro))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }

            List<Maestro> maestro = (List<Maestro>)(from mae in context.Maestro select mae).ToList();
            if (maestro.Any(mae => mae.Id == idMaestro))
            {
                Console.WriteLine("Va a eliminar un Maestro, esta seguro? S/N");
                var input = Console.ReadLine().ToUpper();
                do
                {
                    switch (input)
                    {
                        case "S":
                            context.Maestro.Remove(context.Maestro.Where(x => x.Id == idMaestro).FirstOrDefault());
                            context.SaveChanges();
                            Console.ReadKey();
                            break;
                        case "N":

                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                } while (input == "S" ^ input == "N");
            }
            else
            {
                throw new Exception("*ERROR* ProfesorId inexistente");
            } 
        }
        private static void EliminarAlumnos(EFInstitutoContext context)
        { 
            Console.WriteLine("*ELIMINAR ALUMNOS*");
            Console.Write("Ingrese ID del Alumno: ");
            int idAlumno; 
            if (!int.TryParse(Console.ReadLine(), out idAlumno)) 
            { 
                throw new Exception("*Error* Se esperaba un numero"); 
            }
            List<Alumno> alumno = (List<Alumno>)(from alu in context.Alumno select alu).ToList();
            if (alumno.Any(alu => alu.Id == idAlumno))
            {
                Console.WriteLine("Va a eliminar un Alumno, esta seguro? S/N");
                var input = Console.ReadLine().ToUpper();
                do
                {
                    switch (input)
                    {
                        case "S":
                            context.Alumno.Remove(context.Alumno.Where(x => x.Id == idAlumno).FirstOrDefault());
                            context.SaveChanges();
                            break;
                        case "N":
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                } while (input == "S" ^ input == "N");
            }
            else
            {
                throw new Exception("*ERROR* AlumnoID inexistente");
            }
        }
        private static void EliminarMaterias(EFInstitutoContext context)
        {
            Console.WriteLine("*ELIMINAR MATERIA*");
            Console.Write("Ingrese ID de Materia: ");
            int idMateria;
            if (!int.TryParse(Console.ReadLine(), out idMateria))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }
            List<Materia> materia = (List<Materia>)(from mat in context.Materia select mat).ToList();
            if (materia.Any(mat => mat.Id == idMateria))
            {
                Console.WriteLine("Va a eliminar un Materia, esta seguro? S/N");
                var input = Console.ReadLine().ToUpper();
                do
                {
                    switch (input)
                    {
                        case "S":
                            context.Materia.Remove(context.Materia.Where(x => x.Id == idMateria).FirstOrDefault());
                            context.SaveChanges();
                            break;
                        case "N":
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                } while (input == "S" ^ input == "N");
            }
            else
            {
                throw new Exception("*ERROR* MateriaID inexistente");
            }
        }
        #endregion

        #region MenuModificar
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
            Console.WriteLine("*MODIFICAR MAESTRO*");
            Console.Write("Ingrese ID de Maestro: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }
            var maestro = context.Maestro.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine($"Nombre y Apellido: {maestro.Nombre} {maestro.Apellido}");
                   
            //Devuelve la descripcion de la materia.
            Console.WriteLine($"Materia a cargo: {(context.Materia.Where(x => x.Id == maestro.MateriaId).FirstOrDefault()).Descripcion}");

            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            maestro.Nombre = nombre ?? throw new Exception("El valor Nombre no puede ser nulo");

            Console.Write("Apellido: ");
            var apellido = Console.ReadLine();
            maestro.Apellido = apellido ?? throw new Exception("El valor Apellido no puede ser nulo");

            Console.Write("Id Materia: ");
            if (!int.TryParse(Console.ReadLine(), out int idMateria))
            {
                throw new Exception("*Error* Se esperaba un numero"); ;
            }
            List<Materia> materia = (List<Materia>)(from mate in context.Materia select mate).ToList();
            if (materia.Any(mat => mat.Id == idMateria))
            {
                maestro.MateriaId = idMateria;
                context.Maestro.Add(maestro);
                Console.WriteLine("Va a Modificar un Maestro, esta seguro? S/N");
                var input = Console.ReadLine().ToUpper();
                do
                {
                    switch (input)
                    {
                        case "S":
                            context.SaveChanges();
                            break;
                        case "N":
                            break;
                        default:
                            Console.WriteLine("Debe ingresar una opcion Correcta: ");
                            break;
                    }
                } while (input == "S" ^ input == "N") ;
            }
            else
            {
                throw new Exception("*ERROR* ID de materia inexistente");
            }
        }

        private static void ModificarAlumnos(EFInstitutoContext context)
        {
            Console.WriteLine("*MODIFICAR ALUMNOS*");
            Console.Write("Ingrese ID del Alumno: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }
            var alumno = context.Alumno.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine($"Nombre y Apellido: {alumno.Nombre} {alumno.Apellido}");
            //Devuelve el nombre del Maestro
            Console.WriteLine($"Maestro: {(context.Maestro.Where(x => x.Id == alumno.ProfesorId).FirstOrDefault()).Nombre}");

            Console.Write("Nombre: ");
            alumno.Nombre = Console.ReadLine() ?? throw new Exception("El valor Nombre no puede ser nulo");

            Console.Write("Apellido: ");
            alumno.Apellido = Console.ReadLine() ?? throw new Exception("El valor Apellido no puede ser nulo");
                     

            Console.WriteLine("ID de Maestro: ");
            if (!int.TryParse(Console.ReadLine(), out int idMaestro))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }

            List<Maestro> maestro = (List<Maestro>)(from mae in context.Maestro select mae).ToList();
            if (maestro.Any(mae => mae.Id == idMaestro))
            {
                alumno.ProfesorId = idMaestro;
                context.Alumno.Add(alumno);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("*ERROR* ProfesorId inexistente");
            }

            Console.WriteLine("Va a Modificar un Alumno, esta seguro? S/N");
            var input = Console.ReadLine().ToUpper();
            do
            {
                switch (input)
                {
                    case "S":
                        context.SaveChanges();
                        break;
                    case "N":
                        break;
                    default:
                        Console.WriteLine("Debe ingresar una opcion Correcta: ");
                        break;
                }
            } while (input == "S" ^ input == "N");
        }

        private static void ModificarMaterias(EFInstitutoContext context)
        {
            Console.WriteLine("*MODIFICAR MATERIA*");
            Console.Write("Ingrese ID de Materia: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new Exception("*Error* Se esperaba un numero");
            }
            var materia = context.Materia.Where(x => x.Id == id).FirstOrDefault();
            Console.WriteLine($"Descripción: {materia.Descripcion}");
            Console.WriteLine($"Curso Division: {materia.CursoDivision}");

            Console.Write("Descripción: ");
            materia.Descripcion = Console.ReadLine() ?? throw new Exception("El valor Descripcion no puede ser nulo");
            

            Console.Write("Curso Division: ");
            materia.CursoDivision = Console.ReadLine() ?? throw new Exception("El valor Descripcion no puede ser nulo");

            Console.WriteLine("Va a Modificar un Materia, esta seguro? S/N");
            var input = Console.ReadLine().ToUpper();
            do
            {
                switch (input)
                {
                    case "S":
                        context.SaveChanges();
                        break;
                    case "N":
                        break;
                    default:
                        Console.WriteLine("Debe ingresar una opcion Correcta: ");
                        break;
                }
            } while (input == "S" ^ input == "N");
        }
        #endregion

        #region MenuConsulta
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
                            MostrarMaestros(context);
                            break;
                        case 2:
                            MostrarAlumnos(context);
                            break;
                        case 3:
                            MostrarMaterias(context);
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
                
        private static void MostrarMaterias(EFInstitutoContext context)
        {
            List<Materia> materia = (List<Materia>)(from mate in context.Materia select mate).ToList();

            foreach (Materia mate in materia)
            {
                Console.WriteLine($@"
                ID:{mate.Id}
                Materia: {mate.Descripcion}
                Curso y Division: {mate.CursoDivision}");
            }
            Console.ReadKey();
        }

        private static void MostrarAlumnos(EFInstitutoContext context)
        {
            List<Alumno> alumnos = (List<Alumno>)(from alu in context.Alumno select alu).ToList();

            foreach (Alumno alu in alumnos)
            {
                Console.WriteLine($@"
                ID:{alu.Id}
                Nombre y Apellido: {alu.Nombre} {alu.Apellido}
                Maestro: {(context.Maestro.Where(x => x.Id == alu.ProfesorId).FirstOrDefault()).Apellido}");
            }
            Console.ReadKey();
        }

        private static void MostrarMaestros(EFInstitutoContext context)
        {
            List<Maestro> maestros = (List<Maestro>)(from mae in context.Maestro select mae).ToList();

            foreach (Maestro mae in maestros)
            {
                Console.Write($@"
                ID:{mae.Id}
                Nombre y Apellido: {mae.Nombre} {mae.Apellido}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}