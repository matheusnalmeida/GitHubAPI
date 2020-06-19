using System;
using AppConsole2.src; 

namespace AppConsole2
{
    class MainAPP
    {
        static void Main(string[] args)
        {
            RecursiveFunctions recursiveFunctions = new RecursiveFunctions();
            bool estaRodando = true;
            while (estaRodando) {
                Console.WriteLine("0 - Finalizar Programa");
                Console.WriteLine("1- Imprimir Media e Quantidade de elementos maiores que a media");
                Console.WriteLine("2 - Imprimir vetor em ordem inversa");
                Console.WriteLine("3 - Imprimir vetor em ordem");
                int opcaoMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcaoMenu)
                {
                    case 0:
                        estaRodando = false;
                        break;
                    case 1:
                        int[] valores = recursiveFunctions.funcaoMenu1();
                        Console.WriteLine("A media dos elementos do vetor é {0}", valores[0]);
                        Console.WriteLine("A quantidade de elementos do vetor maiores que a media é {0}", valores[1]);
                        Console.WriteLine();
                        break;
                    case 2:
                        recursiveFunctions.printarVetorInverso(0);
                        Console.WriteLine();
                        break;
                    case 3:
                        recursiveFunctions.printarVetorOrdem();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Selecione uma opcao valida do menu!");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
