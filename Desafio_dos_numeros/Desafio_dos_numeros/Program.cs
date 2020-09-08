using System;

namespace Desafio_dos_numeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Letreiro();
            // Declaração de variáveis e captura das mesmas
            int quantidadeAlunos = CapturaInteiro("Quantos alunos a sala possui? ");

            int[] vetorRA = new int[quantidadeAlunos];

            // Parte do processamento
            for (int i = 0; i < quantidadeAlunos; i++)
            {
                vetorRA[i] = CapturaInteiro("Escreva o RA do " + Convert.ToInt32(i + 1) + "° aluno");
                if (i > 0)
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (vetorRA[i] == vetorRA[j])
                        {
                            Console.WriteLine("Não pode haver duas matrículas iguais. ");
                            i--;
                            break;
                        }
                    }
            }

            string[] duplas = DuplasFormadas(vetorRA);

            // Saída de dados
            Console.Write("\n\n");
            Console.WriteLine("As duplas aleatórias são: ");

            for (int i = 0; i < duplas.Length; i++)
            {
                if (i == 0 && quantidadeAlunos % 2 == 1)
                {
                    Console.WriteLine("Como o número de alunos é ímpar, temos um trio. \n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Trio {0} ---> {1}\n", i + 1, duplas[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dupla {0} ---> {1}\n", i + 1 , duplas[i]);
                    Console.ResetColor();
                }
            }
            
            Console.WriteLine("Toque em qualquer tecla para encerrar o programa. ");
            Console.ReadKey();
            
        }
        /// <summary>
        /// Este método imprime a interface inicial do console
        /// </summary>
        static void Letreiro()
        {
            Console.WriteLine("Nome: Guilherme Dias Lima Turtera RA: 081200007");
            Console.WriteLine("Nome: Nathan Vilela de Souza      RA: 081200028");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("      |||||   |||||  |||||    ||||    |||||  ||    ||||");
            Console.WriteLine("      |   ||  |      ||      |    |   |           ||  ||");
            Console.WriteLine("      |   ||  |||      ||    ||||||   |||    ||   ||  ||");
            Console.WriteLine("      |   ||  |         ||   |    |   |      ||   ||  ||");
            Console.WriteLine("      |||||   |||||  |||||   |    |   |      ||    ||||");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("                      |||||   ||||  |||||");
            Console.WriteLine("                      |   || ||  || ||   ");
            Console.WriteLine("                      |   || ||  ||   || ");
            Console.WriteLine("                      |   || ||  ||    ||");
            Console.WriteLine("                      |||||   ||||  |||||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("     ||    ||  ||   || ||    || |||||  ||||    ||||  |||||");
            Console.WriteLine("     |||   ||  ||   || |||  ||| |      |   |  ||  || ||   ");
            Console.WriteLine("     || |  ||  ||   || || || || |||    ||||   ||  ||   || ");
            Console.WriteLine("     ||  | ||  ||   || ||    || |      |  |   ||  ||    ||");
            Console.WriteLine("     ||   |||    |||   ||    || |||||  |   |   ||||  ||||| \n \n");
            Console.ResetColor();

        }
        /// <summary>
        /// Este método manda uma mensagem pedindo um inteiro, e o retorna, caso for maior do que 0
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Inteiro > 0</returns>
        static int CapturaInteiro(string texto)
        {
            int num = 0;
            do
            {
                try
                {
                    Console.WriteLine(texto);
                    num = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Escreva um número válido. ");
                }
            } while (num < 0);

            return num;
        }

        /// <summary>
        /// Este método recebe um vetor de matrículas, e os converte em duplas aleatórias. Caso o número de matrículas for ímpar, faz um trio
        /// </summary>
        /// <param name="vetorRA"></param>
        /// <returns>Vetor de duplas em string aleatórias</returns>
        static string[] DuplasFormadas(int[] vetorRA)
        {
            string[] duplas = new string[vetorRA.Length / 2];
            Random numero = new Random();
            int sorteio1, sorteio2, sorteioImpar;
            for (int i = 0; i < vetorRA.Length / 2; i++)
            {
                if (i == 0 && vetorRA.Length % 2 == 1)
                {
                    sorteioImpar = numero.Next(0, vetorRA.Length);
                    duplas[i] = Convert.ToString(vetorRA[sorteioImpar]) + ", ";
                    vetorRA[sorteioImpar] = -1;
                }

                do
                {
                    sorteio1 = numero.Next(0, vetorRA.Length);
                } while (vetorRA[sorteio1] == -1);

                do
                {
                    sorteio2 = numero.Next(0, vetorRA.Length);
                } while (sorteio2 == sorteio1 || vetorRA[sorteio2] == -1);

                duplas[i] += Convert.ToString(vetorRA[sorteio1]) + ", " + Convert.ToString(vetorRA[sorteio2]);
                vetorRA[sorteio1] = -1;
                vetorRA[sorteio2] = -1;
            }

            return duplas;
        }
    }
}

