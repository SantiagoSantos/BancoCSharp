using System.Globalization;
using System.Text;

namespace BancoCSharp.Entities
{
    public abstract class Conta
    {
        #region Propriedades
        public int Id { get; private set; }
        public Titular Titular { get; private  set; }
        public double Saldo { get; protected set; }
        public DateTime DataAbertura { get; private set; }
        protected List<Movimentacao> Movimentacoes { get; private set; }        
        #endregion
        
        #region Construtores
        public Conta(Titular titular)
        {
            Titular = titular;
            DataAbertura = DateTime.Now;

            Id = new Random().Next(DateTime.Now.Year);

            Movimentacoes = new();
            RegistraMovimentacao(Enums.TipoMovimentacao.Abertura, Saldo, DataAbertura);
            
        }
        #endregion

        #region Variaveis
        protected readonly double VALOR_MINIMO = 10.0;
        #endregion

        #region Metodos
        public void AddConta()
        {
            ContasCadastradas.AddConta(this);
        }

        public virtual void Depositar(double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo paraa  operação solicitada.");
            }

            Saldo += valor;

            RegistraMovimentacao(Enums.TipoMovimentacao.Deposito, valor, DateTime.Now);
        }

        public virtual void Sacar(double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo para a operação solicitada.");
            }

            if (Saldo < valor)
            {
                throw new ArgumentException($"Saldo insuficiente.");
            }

            Saldo -= valor;

            RegistraMovimentacao(Enums.TipoMovimentacao.Saque, valor, DateTime.Now);
        }

        public virtual void Transferir(Conta contaDestino, double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo para a operação solicitada.");
            }
            
            if(Saldo < valor)
            {
                throw new ArgumentException($"Saldo insuficiente.");
            }

            Saldo -= valor;

            RegistraMovimentacao(Enums.TipoMovimentacao.Transferencia, valor, DateTime.Now);

            contaDestino.Depositar(valor);
        }

        protected void RegistraMovimentacao(Enums.TipoMovimentacao movimento, double valor, DateTime dataMovimento)
        {
            Movimentacoes.Add(
                new Movimentacao(dataMovimento, movimento, valor)
            );
        }

        public abstract void ImprimirExtrato();

        public override string ToString()
        {
            return $"Titular: {Titular.Nome}, Id: {Id}, saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }

        #endregion

    }
}