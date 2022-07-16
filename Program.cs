using System;
using System.Collections.Generic;

namespace aplicacao_bancario
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string opcao = Opcoes();

        while (opcao.ToUpper() != "X"){
            switch (opcao)
            {
                case "1":
                    ListarConta();
                    break;
                case "2":
                    CadastrarConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                throw new ArgumentOutOfRangeException();
            }
            opcao = Opcoes();
        }
        Console.WriteLine("Obrigado por utilizar nossos serviços");
        Console.ReadLine();
}

        private static void Transferir()
        {
            if (listaContas.Count != 0)
            {
                ListarConta();
                Console.WriteLine("Digite o número da conta de origem: ");
                int indiceContaOrigem = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o número da conta de destino: ");
                int indiceContaDestino = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor a ser transferido: ");
                double valorTransferencia = double.Parse(Console.ReadLine());

                listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
            }else{
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
        }

        private static void Depositar()
        {
            if (listaContas.Count != 0)
            {
                ListarConta();

                Console.WriteLine("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser depositado: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                listaContas[indiceConta].Depositar(valorDeposito);
            }else
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
        }

        private static void Sacar()
        {
            if (listaContas.Count != 0)
            {
                ListarConta();
                Console.WriteLine("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser sacado: ");
                double valorSaque = double.Parse(Console.ReadLine());

                listaContas[indiceConta].Sacar(valorSaque);
            }else
            {
                 Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("Cadastrar nova conta");

             Console.WriteLine("Digite 1 para conta Física ou 2 para Jurídica: ");
             int entradaTipoConta = int.Parse(Console.ReadLine());

              Console.WriteLine("Digite o Nome do Cliente: ");
              string entradaNome = Console.ReadLine();

              Console.WriteLine("Digite o saldo inicial: ");
              double entradaSaldo = double.Parse(Console.ReadLine());

              Console.WriteLine("Digite o crédito: ");
              double entradaCredito = double.Parse(Console.ReadLine());

              Conta novaConta = new Conta(
                    tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entradaSaldo,
                    credito: entradaCredito,
                    nome: entradaNome);

                listaContas.Add(novaConta);
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar Contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine($"#{i} - {conta}");
            }
        }

        private static string Opcoes(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine();
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
