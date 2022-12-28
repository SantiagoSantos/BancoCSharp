using System.Globalization;
using BancoCSharp.Entities;

namespace BancoCSharp.View
{
    public static class Tela
    {
        private static readonly int TamanhoLinha = 37;        
        public static void Principal()
        {           
            CabecalhoTela();
            LinhaVazia();
            MensagemLinha("1. Cadastrar Conta Corrente");
            MensagemLinha("2. Cadastrar Conta Poupança");
            MensagemLinha("3. Cadastrar Conta Investimento");
            MensagemLinha("4. Extrato");
            MensagemLinha("5. Depositar");
            MensagemLinha("6. Sacar");
            MensagemLinha("7. Transferir");
            MensagemLinha("8. Listar Contas");
            MensagemLinha("0. Logoff");
            LinhaVazia();
        }

        public static void ListarContas()
        {
            CabecalhoTela();
            LinhaVazia();
            
            Console.WriteLine();
            ContasCadastradas.ObterContas()
                                .ForEach(p => Console.WriteLine(p));
            LinhaVazia();
        }

        private static void CabecalhoTela()
        {
            Console.Clear();
            Console.WriteLine("#".PadRight(TamanhoLinha, '#'));
            Console.WriteLine("########### Banco CSharp ############");
            Console.WriteLine("#".PadRight(TamanhoLinha, '#'));
        }

        private static void MensagemLinha(string mensagem)
        {            
            Console.WriteLine($"| {mensagem}".PadRight(TamanhoLinha - 1) + "|");
        }

        private static void LinhaVazia()
        {
            Console.WriteLine("-".PadRight(TamanhoLinha, '-'));
        }

        #region Operações
        public static void CadastraContaCorrente()
        {
            // Titular titular;
            Endereco endereco = new Endereco("rua","s/n", "bairro", "cidade", "SP","12345600");
            
            string nomeTitular;
            string cpfTitular;
            string telefoneTitular;
            
            string rua;
            string numero;
            string bairro; 
            string cidade;
            string uf;
            string cep;

            double valorRendaMensal;
            bool isChequeEspecialHabilitado;

            CabecalhoTela();
            LinhaVazia();

            MensagemLinha("Nome do titular: ");
            nomeTitular = Console.ReadLine();
            MensagemLinha("CPF do titular: ");
            cpfTitular = Console.ReadLine();
            MensagemLinha("Telefone do titular: ");
            telefoneTitular = Console.ReadLine();

            MensagemLinha("Logradouro: ");
            rua = Console.ReadLine();
            MensagemLinha("Numero: ");
            numero = Console.ReadLine();
            MensagemLinha("Bairro: ");
            bairro = Console.ReadLine();
            MensagemLinha("Cidade: ");
            cidade = Console.ReadLine();
            MensagemLinha("UF: ");
            uf = Console.ReadLine();
            MensagemLinha("CEP: ");
            cep = Console.ReadLine();

            MensagemLinha("Renda mensal média:");
            valorRendaMensal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            MensagemLinha("Habilitar cheque especial? (S/N)");
            isChequeEspecialHabilitado = Console.ReadLine().ToUpper() == "S" ? true : false;

            endereco = new(rua, numero, bairro, cidade, uf, cep);
            ContaCorrente c = new(new Titular(nomeTitular, cpfTitular, telefoneTitular, valorRendaMensal, endereco), isChequeEspecialHabilitado);
            c.AddConta();
        }

        public static void CadastraContaPoupanca()
        {
            // Titular titular;
            Endereco endereco = new Endereco("rua","s/n", "bairro", "cidade", "SP","12345600");
            
            string nomeTitular;
            string cpfTitular;
            string telefoneTitular;
            
            string rua;
            string numero;
            string bairro; 
            string cidade;
            string uf;
            string cep;

            double valorRendaMensal;

            CabecalhoTela();
            LinhaVazia();

            MensagemLinha("Nome do titular: ");
            nomeTitular = Console.ReadLine();
            MensagemLinha("CPF do titular: ");
            cpfTitular = Console.ReadLine();
            MensagemLinha("Telefone do titular: ");
            telefoneTitular = Console.ReadLine();

            MensagemLinha("Logradouro: ");
            rua = Console.ReadLine();
            MensagemLinha("Numero: ");
            numero = Console.ReadLine();
            MensagemLinha("Bairro: ");
            bairro = Console.ReadLine();
            MensagemLinha("Cidade: ");
            cidade = Console.ReadLine();
            MensagemLinha("UF: ");
            uf = Console.ReadLine();
            MensagemLinha("CEP: ");
            cep = Console.ReadLine();

            MensagemLinha("Renda mensal média:");
            valorRendaMensal = double.Parse(Console.ReadLine());

            endereco = new(rua, numero, bairro, cidade, uf, cep);
            ContaPoupanca c = new(new Titular(nomeTitular, cpfTitular, telefoneTitular, valorRendaMensal, endereco));
            c.AddConta();
        }

        public static void CadastraContaInvestimento()
        {
            // Titular titular;
            Endereco endereco = new Endereco("rua","s/n", "bairro", "cidade", "SP","12345600");
            
            string nomeTitular;
            string cpfTitular;
            string telefoneTitular;
            
            string rua;
            string numero;
            string bairro; 
            string cidade;
            string uf;
            string cep;

            double valorRendaMensal;

            CabecalhoTela();
            LinhaVazia();

            MensagemLinha("Nome do titular: ");
            nomeTitular = Console.ReadLine();
            MensagemLinha("CPF do titular: ");
            cpfTitular = Console.ReadLine();
            MensagemLinha("Telefone do titular: ");
            telefoneTitular = Console.ReadLine();

            MensagemLinha("Logradouro: ");
            rua = Console.ReadLine();
            MensagemLinha("Numero: ");
            numero = Console.ReadLine();
            MensagemLinha("Bairro: ");
            bairro = Console.ReadLine();
            MensagemLinha("Cidade: ");
            cidade = Console.ReadLine();
            MensagemLinha("UF: ");
            uf = Console.ReadLine();
            MensagemLinha("CEP: ");
            cep = Console.ReadLine();

            MensagemLinha("Renda mensal média:");
            valorRendaMensal = double.Parse(Console.ReadLine());

            endereco = new(rua, numero, bairro, cidade, uf, cep);
            ContaInvestimento c = new(new Titular(nomeTitular, cpfTitular, telefoneTitular, valorRendaMensal, endereco));
            c.AddConta();
        }
        
        public static void Sacar()
        {
            CabecalhoTela();
            MensagemLinha("Informe o id da Conta:");
            int id = int.Parse(Console.ReadLine());            

            Conta c = ContasCadastradas.ObterPorId(id);

            if (c == null)
            {
                throw new ArgumentException($"ID {id} de conta não encontrado.");
            }
            else
            {
                MensagemLinha("Informe o valor a ser sacado:");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                c.Sacar(valor);
                MensagemLinha(c.ToString());
            }
            
            LinhaVazia();            
        }     

        public static void Depositar()
        {
            CabecalhoTela();
            MensagemLinha("Informe o id da Conta de destino:");

            int id = int.Parse(Console.ReadLine());            

            Conta c = ContasCadastradas.ObterPorId(id);

            if (c == null)
            {
                Console.WriteLine($"ID {id} de conta não encontrado.");
            }
            else
            {
                MensagemLinha("Informe o valor do depósito:");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                c.Depositar(valor);
                MensagemLinha(c.ToString());
            }
            
            LinhaVazia();
        }   

        public static void Transferir()
        {
            CabecalhoTela();
            MensagemLinha("Informe o id da conta de origem:");

            int idOrigem = int.Parse(Console.ReadLine());

            Conta co = ContasCadastradas.ObterPorId(idOrigem);

            if (co == null)
            {
                throw new ArgumentException($"ID {idOrigem} de conta não encontrado.");
            }

            MensagemLinha("Informe o id da conta de destino:");
            int idDestino = int.Parse(Console.ReadLine());
            Conta cd = ContasCadastradas.ObterPorId(idDestino);

            if (cd == null)
            {
                throw new ArgumentException($"ID {idOrigem} de conta não encontrado.");
            }

            else
            {
                MensagemLinha("Valor da transferência:");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                co.Transferir(cd, valor);
                MensagemLinha(co.ToString());
            }
            
            LinhaVazia();
        } 

        public static void ImprimirExtrato()
        {
            CabecalhoTela();
            MensagemLinha("Informe o id da Conta:");
            int id = int.Parse(Console.ReadLine());            

            Conta c = ContasCadastradas.ObterPorId(id);

            if (c == null)
            {
                throw new ArgumentException($"ID {id} de conta não encontrado.");
            }
            else
            {
                c.ImprimirExtrato();
            }
            
            LinhaVazia();
        }
        #endregion
    }
}