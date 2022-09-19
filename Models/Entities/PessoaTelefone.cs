namespace PimAplication.Models.Entities
{
    public class PessoaTelefone
    {
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }
    }
}
