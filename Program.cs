using System;

class Program
{
    static void Main(string[] args)
    {
        int numEstudiantes, numMaterias;

        Console.Write("Ingrese la cantidad de estudiantes: ");
        numEstudiantes = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese la cantidad de materias: ");
        numMaterias = int.Parse(Console.ReadLine()!);

        string[] estudiantes = new string[numEstudiantes];
        string[] materias = new string[numMaterias];
        double[,] notas = new double[numEstudiantes, numMaterias];

        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Registrar estudiantes");
            Console.WriteLine("2. Registrar materias");
            Console.WriteLine("3. Ingresar notas");
            Console.WriteLine("4. Mostrar notas");
            Console.WriteLine("5. Mostrar promedio por estudiante");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine()!);
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
                    PromedioEstudiante(estudiantes, materias, notas);
                    break;

                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 6);
    }

    // ===== FUNCIONES =====

    static void RegistrarEstudiantes(string[] estudiantes)
    {
        for (int i = 0; i < estudiantes.Length; i++)
        {
            Console.Write($"Ingrese el nombre del estudiante {i + 1}: ");
            estudiantes[i] = Console.ReadLine()!;
        }
    }

    static void RegistrarMaterias(string[] materias)
    {
        for (int i = 0; i < materias.Length; i++)
        {
            Console.Write($"Ingrese el nombre de la materia {i + 1}: ");
            materias[i] = Console.ReadLine()!;
        }
    }

    static void IngresarNotas(string[] estudiantes, string[] materias, double[,] notas)
    {
        for (int i = 0; i < estudiantes.Length; i++)
        {
            for (int j = 0; j < materias.Length; j++)
            {
                double nota;
                bool valido;

                do
                {
                    Console.Write($"Nota de {estudiantes[i]} en {materias[j]}: ");
                    valido = double.TryParse(Console.ReadLine(), out nota);

                    if (!valido)
                    {
                        Console.WriteLine("❌ Error: ingrese un número válido.");
                    }

                } while (!valido);

                notas[i, j] = nota;
            }
        }
    }

    static void MostrarNotas(string[] estudiantes, string[] materias, double[,] notas)
    {
        Console.Write("Estudiante\t");
        for (int j = 0; j < materias.Length; j++)
        {
            Console.Write(materias[j] + "\t");
        }
        Console.WriteLine();

        for (int i = 0; i < estudiantes.Length; i++)
        {
            Console.Write(estudiantes[i] + "\t\t");
            for (int j = 0; j < materias.Length; j++)
            {
                Console.Write(notas[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void PromedioEstudiante(string[] estudiantes, string[] materias, double[,] notas)
    {
        for (int i = 0; i < estudiantes.Length; i++)
        {
            double suma = 0;

            for (int j = 0; j < materias.Length; j++)
            {
                suma += notas[i, j];
            }

            double promedio = suma / materias.Length;
            Console.WriteLine($"Promedio de {estudiantes[i]}: {promedio:F2}");
        }
    }
}
