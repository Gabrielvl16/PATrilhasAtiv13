using System;

namespace Classes
{
    class Calculadora
    {
        public static int Soma(int a, int b)
        {
            return (a + b);  
        }

        public static int Subtracao(int a, int b)
        {
            return (a - b);  
        }

        public static int Multiplicacao(int a, int b)
        {
            return (a * b);  
        }

        public static float Divisao(float a, float b)
        {
            if (b == 0)
            {
                Console.WriteLine("Não é possível dividir por zero.");
                return 0; 
            }
            return (a / b);  
        }
    }
    
    class Program
    { 
        static void Valoraeb(out decimal a, out decimal b)
        {
            Console.Write("Digite o valor de a: ");
            a = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o valor de b: ");
            b = Convert.ToDecimal(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("====Calculadora====");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("===================");

                int opcao = int.Parse(Console.ReadLine());
                decimal a, b;

                switch (opcao)
                {
                    case 1:
                        Valoraeb(out a, out b); 
                        Console.WriteLine($"Resultado da Soma: {Calculadora.Soma((int)a, (int)b)}");
                        Console.Write("Pressione qualquer tecla para continuar1");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Valoraeb(out a, out b); 
                        Console.WriteLine($"Resultado da Subtração: {Calculadora.Subtracao((int)a, (int)b)}");
                        Console.Write("Pressione qualquer tecla para continuar1");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Valoraeb(out a, out b);
                        Console.WriteLine($"Resultado da Multiplicação: {Calculadora.Multiplicacao((int)a, (int)b)}");
                        Console.Write("Pressione qualquer tecla para continuar1");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Valoraeb(out a, out b); 
                        Console.WriteLine($"Resultado da Divisão: {Calculadora.Divisao((float)a, (float)b)}");
                        Console.Write("Pressione qualquer tecla para continuar1");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("Saindo...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            } while (true);
        }
    }
}
