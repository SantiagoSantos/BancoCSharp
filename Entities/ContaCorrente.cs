using System.Globalization;
using System.Text;

namespace BancoCSharp.Entities
{
    public class ContaCorrente : Conta
    {
        #region Propriedades
        public bool IsChequeEspecialHabilitado { get; private set; }
        public double LimiteChequeEspecial { get; private set; }
        public double SaldoChequeEspecial { get; private set; }
        
        
        
        #endregion

        #region Construtor
        public ContaCorrente(Titular titular, bool isChequeEspecialHabilitado) : base(titular)
        {
            IsChequeEspecialHabilitado = isChequeEspecialHabilitado;
            CalculaLimiteChequeEspecial();
        }
        #endregion

        #region Metodos

        public override void Sacar(double valor)
        {
            double valorCompensacao = 0;

            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo para a operação solicitada.");
            }
            
            if((Saldo < valor && !IsChequeEspecialHabilitado)
                || (IsChequeEspecialHabilitado && Saldo + LimiteChequeEspecial < valor))
            {
                throw new ArgumentException($"Saldo insuficiente.");
            }

            Saldo -= valor;

            if (Saldo < 0)
            {
                valorCompensacao = Saldo * -1;
                Saldo = 0.0;
                SaldoChequeEspecial = SaldoChequeEspecial - valorCompensacao;

                if (valorCompensacao != valor) RegistraMovimentacao(Enums.TipoMovimentacao.Saque, valorCompensacao, DateTime.Now);
                RegistraMovimentacao(Enums.TipoMovimentacao.Especial, valorCompensacao, DateTime.Now);
            }
            else
            {
                RegistraMovimentacao(Enums.TipoMovimentacao.Saque, valor, DateTime.Now);
            }
        }

        public override void Depositar(double valor)
        {
            var valorAux = 0.0;

            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo paraa  operação solicitada.");
            }

            if (IsChequeEspecialHabilitado && SaldoChequeEspecial < LimiteChequeEspecial)
            {
                var compensacao = LimiteChequeEspecial - SaldoChequeEspecial;

                if (valor <= compensacao)
                {
                    SaldoChequeEspecial += valor;

                    RegistraMovimentacao(Enums.TipoMovimentacao.Especial, valor, DateTime.Now);
                }
                else 
                {
                    valorAux = LimiteChequeEspecial - SaldoChequeEspecial;

                    RegistraMovimentacao(Enums.TipoMovimentacao.Compensacao, valorAux, DateTime.Now);

                    SaldoChequeEspecial = LimiteChequeEspecial;
                    Saldo += valor - valorAux;

                    RegistraMovimentacao(Enums.TipoMovimentacao.Deposito, valor - valorAux, DateTime.Now);
                }
            }
            else
            {
                base.Depositar(valor);
            }
        }

        public override void Transferir(Conta contaDestino, double valor)
        {
            double valorCompensacao = 0;

            if (valor < VALOR_MINIMO)
            {
                throw new ArgumentException($"Valor R$ {valor.ToString("F2", CultureInfo.InvariantCulture)} é inferior ao mínimo para a operação solicitada.");
            }
            
            if((Saldo < valor && !IsChequeEspecialHabilitado)
                || (IsChequeEspecialHabilitado && Saldo + LimiteChequeEspecial < valor))
            {
                throw new ArgumentException($"Saldo insuficiente.");
            }

            Saldo -= valor;

            if (Saldo < 0)
            {
                valorCompensacao = Saldo * -1;
                Saldo = 0.0;
                SaldoChequeEspecial = SaldoChequeEspecial - valorCompensacao;

                if (valorCompensacao != valor) RegistraMovimentacao(Enums.TipoMovimentacao.Transferencia, valorCompensacao, DateTime.Now);
                RegistraMovimentacao(Enums.TipoMovimentacao.Especial, valorCompensacao, DateTime.Now);
            }
            else
            {
                RegistraMovimentacao(Enums.TipoMovimentacao.Transferencia, valor, DateTime.Now);
            }

            contaDestino.Depositar(valor);
        }

        private void CalculaLimiteChequeEspecial()
        {
            if ((IsChequeEspecialHabilitado && Titular.RendaMensal < 600.00) || !IsChequeEspecialHabilitado)
            {
                LimiteChequeEspecial = 0.0;
                SaldoChequeEspecial = 0.0;
            }
            else
            {
                LimiteChequeEspecial = Titular.RendaMensal * 0.25;
                SaldoChequeEspecial = LimiteChequeEspecial;
            }
            
        }

        public override void ImprimirExtrato()
        {
            Movimentacoes
            .OrderByDescending(c => c.DataMovimentacao)
            .ToList()
            .ForEach(conta => Console.WriteLine(conta));
            Console.WriteLine();
            Console.WriteLine($"Saldo atual: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Saldo Especial: {SaldoChequeEspecial.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public override string ToString()
        {
            return $"Titular: {Titular.Nome}, Id: {Id}, saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}, Saldo Cheque Especial: {SaldoChequeEspecial.ToString("F2", CultureInfo.InvariantCulture)}";
        }
        #endregion
    }
}