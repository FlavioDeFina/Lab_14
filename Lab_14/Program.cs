using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = Interfaz.PantallaPrincipal();
            do
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        opcion = Interfaz.Encuesta();
                        break;
                    case 2:
                        opcion = Interfaz.Datos();
                        break;
                    case 3:
                        opcion = Interfaz.Mostrar();
                        break;
                    case 4:
                        opcion = Interfaz.Buscar();
                        break;
                    case 0:
                    default:
                        opcion = Interfaz.PantallaPrincipal();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
