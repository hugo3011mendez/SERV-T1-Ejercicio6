﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ejercicio6
{
    class Program
    {
        static bool flag = false;
        static readonly object l = new object();
        static int contadorComun = 0;
        static void sacarAleatorio()
        {
            Random generador = new Random();
            int num = generador.Next(1, 11); // Creo y defino una variable como el número aleatrorio entre 1 y 10

            lock (l)
            {
                Console.WriteLine(num);

                if (num == 5 || num == 7)
                {
                    if ()
                    {
                        if (flag != true)
                        {
                            contadorComun ++;
                        }
                        else
                        {
                            contadorComun += 5;
                        }
                        flag = true;
                    }
                    else if ()
                    {

                    }  
                }

                Thread.Sleep(generador.Next(100, (100*num)-1));
            }
        }

        static void cambioCaracter()
        {
            char[] caracteres = {'|', '/', '-', '\\'}; // Creo una matriz con los caracteres a mostrar
            int cont = 0; // Y creo un contador para determinar qué caracter muestro

            while (!flag)
            {
                Thread.Sleep(200); // Cambio de caracter cada 200ms
                Console.SetCursorPosition(30,1);
                Console.Write(caracteres[cont]);

                cont ++;
                if (cont >= caracteres.Length)
                {
                    cont = 0;
                }
            }        
        }

        static void Main(string[] args)
        {
            Thread player1 = new Thread(sacarAleatorio);
            Thread player2= new Thread(sacarAleatorio);
            Thread display;
        }
    }
}
