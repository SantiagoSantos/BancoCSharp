using System.Globalization;
using System.Text;

namespace BancoCSharp.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(Titular titular) : base(titular)
        {
        }

        public override void ImprimirExtrato()
        {
            Movimentacoes
                .OrderByDescending(conta => conta.DataMovimentacao)
                .ToList()
                .ForEach(conta => Console.WriteLine(conta));

            Console.WriteLine();
            Console.WriteLine($"Saldo atual: {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}