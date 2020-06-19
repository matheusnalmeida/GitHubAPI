using System;
using System.Collections.Generic;

namespace AppConsole2.src
{
    class RecursiveFunctions
    {
        private int[] array;
        public RecursiveFunctions()
        {
            this.gerarArrayAleatorio(10);
        }

        //Funcao responsavel por criar um array com o tamanho especificado e com numeros aleatorios entre 0 e 11
        private void gerarArrayAleatorio(int size) {
            this.array = new int[size];
            Random random = new Random();
            for (int i = 0; i < this.array.Length; i++) {
                array[i] = random.Next(0, 11);
            }
        }

        /*
        Funcao responsavel por retornar os valores da media dos elementos do vetor e os 
        valores do vetor que possuem valor maior que a media respectivamente     
         */
        public int[] funcaoMenu1() {
            int[] valoresContabilizados = new int[2];
            valoresContabilizados[0] = calculaMediaRecursivo(0, 0);
            valoresContabilizados[1] = calculaMaiorQueAMediaRecursivo(valoresContabilizados[0], 0, 0);

            return valoresContabilizados;
        }

        //----------------------------------FUNCOES PARA OPCAO 1 DO MENU----------------------------------------------------------

        //Funcao responsavel por calcular a media dos elementos do array de forma recursiva
        private int calculaMediaRecursivo(int contadorMedia, int posicaoAtual) {
            if (posicaoAtual == this.array.Length) {
                return contadorMedia / this.array.Length;
            }
            return this.calculaMediaRecursivo(contadorMedia + this.array[posicaoAtual], posicaoAtual+1);
        }

        //Funcao responsavel por retornar o numero de elementos maiores que media
        private int calculaMaiorQueAMediaRecursivo(int media, int posicaoAtual, int quantidadeElementos) {
            if (posicaoAtual == this.array.Length) {
                return quantidadeElementos;
            }
            if (this.array[posicaoAtual] > media) {
                quantidadeElementos++;
            }
            return this.calculaMaiorQueAMediaRecursivo(media, posicaoAtual+1, quantidadeElementos);
        }

        //----------------------------------FUNCOES PARA OPCAO 2 DO MENU----------------------------------------------------------
        //Funcao responsavel por printar o vetor na ordem inversa
        public void printarVetorInverso(int posicaoAtual) {
            if (posicaoAtual == (this.array.Length - 1)) {
                Console.Write(this.array[posicaoAtual] + " , ");
                return;
            }
            this.printarVetorInverso(posicaoAtual+1);
            if (posicaoAtual == 0)
            {
                Console.Write(this.array[posicaoAtual]);
            }
            else {
                Console.Write(this.array[posicaoAtual] + " , ");
            }
        }

        public void printarVetorOrdem() {
            for (int i = 0; i < this.array.Length; i++) {
                if (i == this.array.Length - 1) {
                    Console.Write(this.array[i]);
                    break;
                }
                Console.Write(this.array[i] + " , ");
            }
        }
    }
}
