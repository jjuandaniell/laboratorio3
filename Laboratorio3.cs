using System.Text.RegularExpressions;

List<string> estudiantes = new List<string>();
List<double> calificaciones = new List<double>();
List<string> EstudiantesAsignados = new List<string>();

Console.WriteLine("Bienvenido al sistema de gestión de estudiantes");

while (true)
{
    Console.WriteLine("\n1. Agregar estudiante");
    Console.WriteLine("2. Mostrar lista de estudiantes");
    Console.WriteLine("3. Calcular promedio de calificaciones");
    Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine());

    if (opcion == 1)
    {
        string nombre;
        while (true)
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            nombre = Console.ReadLine();
            if (Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
            {
                break;
            }
            else
            {
                Console.WriteLine("Nombre inválido. Por favor, ingrese un nombre que contenga solo letras.");
            }
        }

        // Agregar apellido
        string apellidoEstudiante;
        while (true)
        {
            Console.Write("Ingrese el apellido del estudiante: ");
            apellidoEstudiante = Console.ReadLine();
            if (Regex.IsMatch(apellidoEstudiante, @"^[a-zA-Z]+$"))
            {
                break;
            }
            else
            {
                Console.WriteLine("Apellido inválido. Por favor, ingrese un apellido que contenga solo letras.");
            }
        }

        // Agregar carrera
        Console.WriteLine("Seleccione la carrera del estudiante:");
        Console.WriteLine("1. Ingeniería en Sistemas");
        Console.WriteLine("2. Ingeniería Civil");
        Console.WriteLine("3. Ingeniería Industrial");
        Console.Write("Ingrese el número correspondiente a la carrera: ");
        int carreraOpcion = int.Parse(Console.ReadLine());

        string carreraEstudiante = carreraOpcion switch
        {
            1 => "Ingeniería en Sistemas",
            2 => "Ingeniería Civil",
            3 => "Ingeniería Aeroespacial",
            _ => "No existente"
        };
        Console.WriteLine("Seleccione la carrera del estudiante:");
        Console.WriteLine("1. Programacion 1");
        Console.WriteLine("2. Calculo 1");
        Console.WriteLine("3. Fisica 1");
        Console.Write("Ingrese el número correspondiente al curso: ");
        int CursoOpcion = int.Parse(Console.ReadLine());

        string CursoEstudiante = CursoOpcion switch
        {
            1 => "Programacion 1",
            2 => "Calculo 1",
            3 => "Fisica 1",
            _ => "Ninguno"
        };

        Console.Write("Ingrese la calificación del estudiante: ");
        double calificacion = double.Parse(Console.ReadLine());

        // Agregar estudiante a la lista de estudiantes asignados
        EstudiantesAsignados.Add($"{nombre} {apellidoEstudiante} - Carrera: {carreraEstudiante} Materias asignadas {CursoEstudiante}");
        calificaciones.Add(calificacion);

        Console.WriteLine("Estudiante agregado correctamente.");
    }

    else if (opcion == 2)
    {
        if (EstudiantesAsignados.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("\nLista de estudiantes:");
            for (int i = 0; i < EstudiantesAsignados.Count; i++)
            {
                Console.WriteLine($"{EstudiantesAsignados[i]} - Calificación: {calificaciones[i]}");
            }
        }
    }
    else if (opcion == 3)
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }
            double promedio = suma / calificaciones.Count;
            Console.WriteLine($"El promedio de calificaciones es: {promedio}");
        }
    }
    else if (opcion == 4)
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double maxCalificacion = calificaciones[0];
            string estudianteMax = EstudiantesAsignados[0];
            for (int i = 1; i < calificaciones.Count; i++)
            {
                if (calificaciones[i] > maxCalificacion)
                {
                    maxCalificacion = calificaciones[i];
                    estudianteMax = EstudiantesAsignados[i];
                }
            }
            Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
        }
    }
    else if (opcion == 5)
    {
        Console.WriteLine("Saliendo del sistema...");
        break;
    }
    else
    {
        Console.WriteLine("Opción no válida. Intente de nuevo.");
    }
}
