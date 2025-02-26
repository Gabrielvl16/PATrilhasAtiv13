using System;
using System.Collections.Generic;

namespace BancoApp
{
    class Banco
    {
        public string Nome { get; private set; }
        public int Cpf { get; private set; }
        private double saldo;

        public Banco(string nome, int cpf)
        {
            Nome = nome;
            Cpf = cpf;
            saldo = 0.0;
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado! Saldo atual: {saldo:C}");
            }
            else
            {
                Console.WriteLine("Erro! O valor do depósito deve ser positivo.");
            }
        }

        public void Sacar(double valor)
        {
            if (valor > 0 && valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado! Saldo atual: {saldo:C}");
            }
            else
            {
                Console.WriteLine("Erro! Saldo insuficiente ou valor inválido.");
            }
        }

        public void MostrarSaldo()
        {
            Console.WriteLine($"Saldo de {Nome}: {saldo:C}");
        }
    }

    class Program
    {
        static List<Banco> contas = new List<Banco>();

        static void Main()
        {
            do
            {
                Console.WriteLine("\n==== BANCO ====");
                Console.WriteLine("1 - Abrir conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Fechar conta");
                Console.WriteLine("5 - Listar contas");
                Console.WriteLine("6 - Sair");
                Console.WriteLine("================");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        AbrirConta();
                        break;
                    case 2:
                        OperacaoBancaria("depositar");
                        break;
                    case 3:
                        OperacaoBancaria("sacar");
                        break;
                    case 4:
                        FecharConta();
                        break;
                    case 5:
                        ListarContas();
                        break;
                    case 6:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();

            } while (true);
        }

        static void AbrirConta()
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do cliente: ");
            int cpf = int.Parse(Console.ReadLine());

            if (contas.Exists(c => c.Cpf == cpf))
            {
                Console.WriteLine("Erro! CPF já cadastrado.");
                return;
            }

            contas.Add(new Banco(nome, cpf));
            Console.WriteLine("Conta aberta com sucesso!");
        }

        static void OperacaoBancaria(string operacao)
        {
            Console.Write("Digite o CPF da conta: ");
            int cpf = int.Parse(Console.ReadLine());

            Banco conta = contas.Find(c => c.Cpf == cpf);

            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada!");
                return;
            }

            Console.Write($"Digite o valor para {operacao}: ");
            double valor = double.Parse(Console.ReadLine());

            if (operacao == "depositar")
            {
                conta.Depositar(valor);
            }
            else if (operacao == "sacar")
            {
                conta.Sacar(valor);
            }
        }

        static void FecharConta()
        {
            Console.Write("Digite o CPF da conta a ser fechada: ");
            int cpf = int.Parse(Console.ReadLine());

            Banco conta = contas.Find(c => c.Cpf == cpf);

            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada! Tente novamente.");
                return; // Evita que o programa feche ao encontrar um erro
            }

            contas.Remove(conta);
            Console.WriteLine("Conta fechada com sucesso!");
        }

        static void ListarContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.WriteLine("\n=== Contas cadastradas ===");
            foreach (var conta in contas)
            {
                Console.WriteLine($"Nome: {conta.Nome}, CPF: {conta.Cpf}");
            }
        }
    }
}
