using System;

class Program
{
    static void Main(string[] args)
    {
        int cantidadEstudiantes;
        int cantidadMaterias;

        do
        {
            Console.Write("ingrese la cantidad de estudiantes: ");
        } while (!int.TryParse(Console.ReadLine(), out cantidadEstudiantes) || cantidadEstudiantes <= 0);

        do
        {
            Console.Write("ingrese la cantidad de materias: ");
        } while (!int.TryParse(Console.ReadLine(), out cantidadMaterias) || cantidadMaterias <= 0);

        string[] estudiantes = new string[cantidadEstudiantes];
        string[] materias = new string[cantidadMaterias];
        double[,] notas = new double[cantidadEstudiantes, cantidadMaterias];

        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("menu principal");
            Console.WriteLine("1. registrar estudiantes");
            Console.WriteLine("2. registrar materias");
            Console.WriteLine("3. ingresar notas");
            Console.WriteLine("4. mostrar notas");
            Console.WriteLine("5. mostrar promedio por estudiante");
            Console.WriteLine("6. salir");

            // Validar opción del menú
            bool esValido;
            do
            {
                Console.Write("\nSeleccione una opción: ");
                string? input = Console.ReadLine();
                esValido = int.TryParse(input, out opcion);

                if (!esValido || opcion < 1 || opcion > 6)
                {
                    esValido = false;
                    Console.WriteLine("opción no válida. Ingrese un número del 1 al 6.");
                }
            } while (!esValido);

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    RegistrarEstudiantes(estudiantes);
                    break;

                case 2:
                    RegistrarMaterias(materias);
                    break;

                case 3:
                    IngresarNotas(estudiantes, materias, notas);
                    break;

                case 4:
                    MostrarNotas(estudiantes, materias, notas);
                    break;

                case 5:
                    MostrarPromedios(estudiantes, materias, notas);
                    break;

                case 6:
                    Console.WriteLine("saliendo del programa...");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }

    static void RegistrarEstudiantes(string[] estudiantes)
    {
        Console.WriteLine("registro de estudiantes");
        for (int i = 0; i < estudiantes.Length; i++)
        {
            Console.Write($"nombre del estudiante {i + 1}: ");
            estudiantes[i] = Console.ReadLine()!;
        }
    }

    static void RegistrarMaterias(string[] materias)
    {
        Console.WriteLine("registro de materias");
        for (int i = 0; i < materias.Length; i++)
        {
            Console.Write($"nombre de la materia {i + 1}: ");
            materias[i] = Console.ReadLine()!;
        }
    }

    static void IngresarNotas(string[] estudiantes, string[] materias, double[,] notas)
    {
        Console.WriteLine("ingreso de notas");

        for (int i = 0; i < estudiantes.Length; i++)
        {
            for (int j = 0; j < materias.Length; j++)
            {
                double nota;
                bool esValido;

                do
                {
                    Console.Write($"nota de {estudiantes[i]} en {materias[j]}: ");
                    string? input = Console.ReadLine();
                    esValido = double.TryParse(input, out nota);

                    if (!esValido)
                    {
                        Console.WriteLine("ingrese un número válido.");
                    }
                } while (!esValido);

                notas[i, j] = nota;
            }
        }
    }

    static void MostrarNotas(string[] estudiantes, string[] materias, double[,] notas)
    {
        Console.WriteLine("notas registradas\n");

        Console.Write("{0,-20}", "Estudiante");
        for (int j = 0; j < materias.Length; j++)
        {
            Console.Write("{0,-10}", materias[j]);
        }
        Console.WriteLine();

        for (int i = 0; i < estudiantes.Length; i++)
        {
            Console.Write("{0,-20}", estudiantes[i]);
            for (int j = 0; j < materias.Length; j++)
            {
                Console.Write("{0,-10}", notas[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void MostrarPromedios(string[] estudiantes, string[] materias, double[,] notas)
    {
        Console.WriteLine("promedio por Estudiante\n");

        for (int i = 0; i < estudiantes.Length; i++)
        {
            double suma = 0;

            for (int j = 0; j < materias.Length; j++)
            {
                suma += notas[i, j];
            }

            double promedio = suma / materias.Length;
            Console.WriteLine($"promedio de {estudiantes[i]}: {promedio:F2}");
        }
    }
}
