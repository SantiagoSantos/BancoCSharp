namespace BancoCSharp.Entities
{
    public class Endereco
    {
        
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Cep { get; private set; }

        public Endereco(string rua, string numero, string bairro, string cidade, string uf, string cep)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
        }

        private void ValidaObjeto()
        {
            if (Rua == null || Rua.Trim().Length == 0)
            {
                throw new ArgumentException("O Rua do titular é obrigatório.");
            }

            if (Bairro == null || Bairro.Trim().Length == 0)
            {
                throw new ArgumentException("O Cpf do titular é obrigatório.");
            }

            if (Cidade == null || Cidade.Trim().Length == 0)
            {
                throw new ArgumentException("O Cidade do titular é obrigatório.");
            }

            if (Uf == null || Uf.Trim().Length == 0)
            {
                throw new ArgumentException("O Uf do titular é obrigatório.");
            }

            if (Cep == null || Cep.Trim().Length == 0)
            {
                throw new ArgumentException("O Cep do titular é obrigatório.");
            }
        }
    }
}