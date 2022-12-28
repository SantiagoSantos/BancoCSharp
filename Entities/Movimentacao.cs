using System.Globalization;
using BancoCSharp.Enums;

namespace BancoCSharp.Entities
{
    public class Movimentacao
    {
        //24/12/2022 17:00
        //    - R$10.00
        //    + R$200.00

        public DateTime DataMovimentacao { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public double Valor { get; private set; }
        
        public Movimentacao(DateTime dataMovimentacao, TipoMovimentacao tipoMovimentacao, double valor)
        {
            DataMovimentacao = dataMovimentacao;
            TipoMovimentacao = tipoMovimentacao;
            Valor = valor;
        }

        public override string ToString()
        {
            var valor = (TipoMovimentacao == TipoMovimentacao.Deposito || TipoMovimentacao == TipoMovimentacao.Abertura || TipoMovimentacao == TipoMovimentacao.Compensacao) ? 
                            $"+R$ {Valor.ToString("F2", CultureInfo.InvariantCulture)}" : 
                            $"-R$ {Valor.ToString("F2", CultureInfo.InvariantCulture)}";

            return $"{DataMovimentacao.ToString()}\n{TipoMovimentacao.ToString().PadRight(25,'.')}{valor}";
        }
        
          
    }
}