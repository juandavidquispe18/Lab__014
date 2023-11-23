using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab__014
{
    internal class Program
    {
        static int[] edades = new int[1000];
        static bool[] vacunado = new bool[1000];
        static int total_encuestados = 0;

        static void Main()
        {

            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("" +
                    "================================\n" +
                    "Encuesta Covid-19\n" +
                    "================================\n" +
                    "1: Realizar Encuesta\n" +
                    "2: Mostrar Datos de la encuesta\n" +
                    "3: Mostrar Resultados\n" +
                    "4: Buscar Personas por edad\n" +
                    "5: Salir\n" +
                    "================================");
                Console.Write("Ingrese una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        Realizar_Encuesta();
                        break;
                    case 2:
                        Mostrar_Datos_Encuesta();
                        break;
                    case 3:
                        Mostrar_Resultados();
                        break;
                    case 4:
                        Buscar_Por_Edad();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Error: Opción no válida.");
                        break;
                }

                if (opcion != 5)
                {

                    Console.WriteLine("");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void Realizar_Encuesta()
        {

            Console.Clear();
            Console.WriteLine("" +
                "===================================\n" +
                "Encuesta de vacunación\n" +
                "===================================");

            Console.Write("¿Qué edad tienes?: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Te has vacunado\n1: Sí\n2: No");
            Console.Write("Ingrese una opción: ");

            bool respuesta_valida = false;
            bool ha_vacunado = false;

            while (!respuesta_valida)
            {

                string respuesta = Console.ReadLine();

                if (respuesta == "1")
                {

                    ha_vacunado = true;
                    respuesta_valida = true;
                }
                else if (respuesta == "2")
                {
                    ha_vacunado = false;
                    respuesta_valida = true;
                }
                else
                {
                    Console.WriteLine("Respuesta no válida. Intente nuevamente.");
                    Console.Write("Ingrese una opción válida (1: Sí / 2: No): ");
                }
            }

            edades[total_encuestados] = edad;
            vacunado[total_encuestados] = ha_vacunado;
            total_encuestados++;

            Console.Clear();
            Console.WriteLine("" +
                "===================================\n" +
                "Encuesta de vacunación\n" +
                "===================================\n" +
                "¡Gracias por participar!\n" +
                "===================================\n" +
                "Presione una tecla ...");
        }

        static void Mostrar_Datos_Encuesta()
        {

            Console.Clear();
            Console.WriteLine("" +
                "===================================\n" +
                "Datos de la encuesta\n" +
                "===================================\n" +
                "ID    | Edad | Vacunado\n" +
                "=======================");

            for (int i = 0; i < total_encuestados; i++)
            {

                Console.WriteLine($"{i:D4}  |  {edades[i]:D2}  |   {(vacunado[i] ? "Si" : "No")}");
            }

            Console.WriteLine("\n===================================\nPresione una tecla para regresar ...\n");
        }

        static void Mostrar_Resultados()
        {

            Console.Clear();
            Console.WriteLine("" +
                "===================================\n" +
                "Resultados de la encuesta\n" +
                "===================================");

            int vacunados = 0;
            int no_vacunados = 0;
            int[] rango_edades = new int[6];

            for (int i = 0; i < total_encuestados; i++)
            {

                if (vacunado[i])
                {

                    vacunados++;
                }
                else
                {
                    no_vacunados++;
                }

                if (edades[i] >= 1 && edades[i] <= 20) rango_edades[0]++;
                else if (edades[i] >= 21 && edades[i] <= 30) rango_edades[1]++;
                else if (edades[i] >= 31 && edades[i] <= 40) rango_edades[2]++;
                else if (edades[i] >= 41 && edades[i] <= 50) rango_edades[3]++;
                else if (edades[i] >= 51 && edades[i] <= 60) rango_edades[4]++;
                else rango_edades[5]++;
            }

            Console.WriteLine($"{vacunados} personas se han vacunado\n{no_vacunados} personas no se han vacunado\n\nExisten:");

            Console.WriteLine($"{rango_edades[0]:D2} personas entre 01 y 20 años");
            Console.WriteLine($"{rango_edades[1]:D2} personas entre 21 y 30 años");
            Console.WriteLine($"{rango_edades[2]:D2} personas entre 31 y 40 años");
            Console.WriteLine($"{rango_edades[3]:D2} personas entre 41 y 50 años");
            Console.WriteLine($"{rango_edades[4]:D2} personas entre 51 y 60 años");
            Console.WriteLine($"{rango_edades[5]:D2} personas de más de 61 años");

            Console.WriteLine("\n===================================\nPresione una tecla para regresar ...\n");
        }

        static void Buscar_Por_Edad()
        {

            Console.Clear();
            Console.WriteLine("" +
                "===============================\n" +
                "Busca a personas por edad\n" +
                "===============================");

            Console.Write("¿Qué edad quieres buscar?: ");
            int edad_buscada = Convert.ToInt32(Console.ReadLine());

            int vacunados = 0;
            int no_vacunados = 0;

            for (int i = 0; i < total_encuestados; i++)
            {

                if (edades[i] == edad_buscada)
                {

                    if (vacunado[i])
                    {

                        vacunados++;
                    }
                    else
                    {
                        no_vacunados++;
                    }
                }
            }

            Console.WriteLine($"\n{vacunados} se vacunaron\n{no_vacunados} no se vacunaron\n===============================\nPresione una tecla para regresar ...\n");
        }
    }
}
