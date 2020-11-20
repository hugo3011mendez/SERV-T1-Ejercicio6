using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ejercicio6
{
    class Program
    {
        static bool paroDisplay = false;
        static bool acabar = false;
        static readonly object l = new object();
        static int contadorComun = 0;
        static void sacarAleatorio()
        {
            while (!acabar)
            {
                lock (l)
                {
                    Random generador = new Random();
                    int num = generador.Next(1, 11); // Creo y defino una variable como el número aleatrorio entre 1 y 10

                    Console.WriteLine(num);

                    if (num == 5 || num == 7)
                    {
                        if () // Si es player1
                        {
                            if (paroDisplay != true)
                            {
                                contadorComun ++;
                            }
                            else
                            {
                                contadorComun += 5;
                            }
                            paroDisplay = true;
                        }
                        else if () // Si es player2
                        {
                            if (paroDisplay != false)
                            {
                                paroDisplay = false;

                                contadorComun--;
                            }
                            else
                            {
                                contadorComun -= 5;
                            }
                        }  
                    }

                    if (contadorComun >= 20 || contadorComun <= -20)
                    {
                        acabar = true;
                    }

                    Thread.Sleep(generador.Next(100, (100*num)+1));
                }
            }
        }

        static void cambioCaracter()
        {
            char[] caracteres = {'|', '/', '-', '\\'}; // Creo una matriz con los caracteres a mostrar
            int cont = 0; // Y creo un contador para determinar qué caracter muestro

            while (!paroDisplay)
            {
                lock (l)
                {
                    // Cambio de caracter cada 200ms
                    Thread.Sleep(200);
                    Console.SetCursorPosition(30,1);
                    Console.Write(caracteres[cont]);

                    cont ++;
                    if (cont >= caracteres.Length)
                    {
                        cont = 0;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Thread player1 = new Thread(sacarAleatorio);
            Thread player2= new Thread(sacarAleatorio);
            Thread display = new Thread(cambioCaracter);

            player1.Start();
            player2.Start();
            display.Start();

            player1.Join();

            if (contadorComun >= 20)
            {
                Console.WriteLine("Ha ganado el jugador 1!");
            }
            else if (contadorComun <= -20)
            {
                Console.WriteLine("Ha ganado el jugador 2!");
            }
        }
    }
}
