namespace BancoCSharp.Entities
{
    public static class ContasCadastradas
    {
        private static readonly List<Conta> Contas = new();

        public static void AddConta(Conta c)
        {
            Contas.Add(c);
        }

        public static List<Conta> ObterContas()
        {
            return Contas;
        }

        public static Conta ObterPorId(int id)
        {
            return Contas.FirstOrDefault(p => p.Id == id);
        }
    }
}