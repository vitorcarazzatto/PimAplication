using System.Runtime.CompilerServices;

namespace PimAplication.Models.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }

        //Relacionamento com a tabela Endereco
        public int EnderecoId { get; set; }
        public Endereco ?Endereco { get; set; }

    }
}
