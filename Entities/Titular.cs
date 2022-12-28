namespace BancoCSharp.Entities
{
    public class Titular
    {                   
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; set; }
        public double RendaMensal { get; private set; }
        public Endereco Endereco { get; set; }

        public Titular(string nome, string cpf, string telefone, double rendaMensal, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            RendaMensal = rendaMensal;
        }

        private void ValidaObjeto()
        {
            if (Nome == null || Nome.Trim().Length == 0)
            {
                throw new ArgumentException("O Nome do titular é obrigatório.");
            }

            if (Cpf == null || Cpf.Trim().Length == 0)
            {
                throw new ArgumentException("O Cpf do titular é obrigatório.");
            }

            if (Telefone == null || Telefone.Trim().Length == 0)
            {
                throw new ArgumentException("O Telefone do titular é obrigatório.");
            }
        }
    }
}