using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    internal class Interfaz
    {
        public static int[] edad = new int[1000];
        public static int[] voto = new int[1000];
        public static int cont = 0;

        public static int PantallaPrincipal()
        {
            string texto = "================================\n" +
                   "Encuesta Covid-19\n" +
                   "================================\n" +
                   "1: Realizar Encuesta\n" +
                   "2: Mostrar Datos de la encuesta\n" +
                   "3: Mostrar Resultados\n" +
                   "4: Buscar Personas por edad\n" +
                   "5: Salir\n" +
                   "================================\n";
            Console.Write(texto);
            return getEntero("Ingrese una opción: ", texto);
        }
        public static int Encuesta() 
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n";
            Console.Write(texto);

            int EDAD = getEntero("¿Qué edad tienes: ", texto);
            if (cont == 1000)
            {
                Console.WriteLine("LA LISTA YA ESTÁ LLENA");
            }
            else
            {
                string texto2 = "Te has vacunado\n" +
                "1: Sí\n" +
                "2: No\n" +
                "================================\n";
                Console.Write(texto2);

                int VOTO;
                do
                {
                    VOTO = getEntero("Ingrese una opción: ", texto);

                    if (VOTO != 1 && VOTO != 2)
                    {
                        Console.WriteLine("Ingresa una opción valida");
                    }
                } while (VOTO != 1 && VOTO != 2);

                edad[cont] = EDAD;
                voto[cont] = VOTO;
                cont++;
            }

            Console.Clear();
            return Gracias();
        }
        public static int Gracias() 
        {
            string texto = " ================================\n" +
                 "Encuesta de vacunación\n" +
                 "================================\n" +
                 " \n" +
                 " \n" +
                 "¡Gracias por participar!\n" +
                 " \n" +
                 " \n" +
                 "================================\n" +
                 "1: Regresar al menú\n" +
                 "================================\n";
            Console.Write(texto);

            int opcion = getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int Datos() 
        {
            string texto = "================================\n" +
              "Datos de la encuesta\n" +
              "================================\n" +
              " \n" +
              "  ID |\tEdad |\tVacunado\n" +
              "================================\n";
            Console.Write(texto);

            if (cont == 0)
            {
                Console.WriteLine("No extisten notas");
            }
            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine($"{i.ToString("D4")} | {edad[i].ToString().PadLeft(4)}  | {(voto[i] == 1 ? "Si" : "No").PadRight(2)}");
            }
            Console.WriteLine("================================\n" +
              "1: Regresar\n" +
              "================================\n");
            int opcion = getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int Mostrar() 
        {
            string texto = "================================\n" +
              "Resultados de la encuesta\n" +
              "================================\n";
            Console.Write(texto);
            int[] conteoPorOpcion = new int[3];
            int[] conteoPorEdad = new int[7];

            for (int i = 0; i < cont; i++)
            {
                int OPCION = voto[i];
                conteoPorOpcion[OPCION]++;

                int EDAD = edad[i];

                if (EDAD >= 1 && EDAD <= 20)
                {
                    conteoPorEdad[1]++;
                }
                else if (EDAD >= 21 && EDAD <= 30)
                {
                    conteoPorEdad[2]++;
                }
                else if (EDAD >= 31 && EDAD <= 40)
                {
                    conteoPorEdad[3]++;
                }
                else if (EDAD >= 41 && EDAD <= 50)
                {
                    conteoPorEdad[4]++;
                }
                else if (EDAD >= 51 && EDAD <= 60)
                {
                    conteoPorEdad[5]++;
                }
                else if (EDAD > 60)
                {
                    conteoPorEdad[6]++;
                }
            }
            Console.WriteLine($"{conteoPorOpcion[1]} personas se han vacunado\n" +
             $"{conteoPorOpcion[2]} personas no se han vacunado\n" +
             " \n" +
             "Existen:\n" +
             $"{conteoPorEdad[1]} personas entre 01 y 20 años\n" +
             $"{conteoPorEdad[2]} personas entre 21 y 30 años\n" +
             $"{conteoPorEdad[3]} personas entre 31 y 40 años\n" +
             $"{conteoPorEdad[4]} personas entre 41 y 50 años\n" +
             $"{conteoPorEdad[5]} personas entre 51 y 60 años\n" +
             $"{conteoPorEdad[6]} personas de más de 61 años\n" +
             "================================\n" +
             "1: Regresar\n" +
             "================================\n");

            int opcion = getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int Buscar() 
        {
            string texto = "================================\n" +
             "Busca a personas por edad\n" +
             "================================\n";
            Console.Write(texto);

            int valorBuscar = getEntero("¿Qué edad quieres buscar?: ", texto);
            int vacunados = 0;
            int noVacunados = 0;
            bool numeroEncontrado = false;

            for (int i = 0; i < cont; i++)
            {
                if (valorBuscar == edad[i])
                {
                    if (voto[i] == 1)
                    {
                        vacunados++;
                    }
                    else if (voto[i] == 2)
                    {
                        noVacunados++;
                    }
                    numeroEncontrado = true;
                }
            }
            if (!numeroEncontrado)
            {
                Console.WriteLine("\nEl número ingresado no existe");
            }
            else
            {
                Console.WriteLine($"\n{vacunados} se vacunaron");
                Console.WriteLine($"{noVacunados} no se vacunaron");
            }
            Console.WriteLine(" \n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n");
            int opcion = getEntero("Ingrese una opción: ",texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int getEntero(string prefijo, string reemplazo)
        {

            int respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);
                if (!correcto)
                {
                    Console.Clear();
                    Console.WriteLine(reemplazo);
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;

        }
        public static string getTextoPantalla(string prefijo)
        {
            Console.Write(prefijo);
            return Console.ReadLine();
        }
    }
}
