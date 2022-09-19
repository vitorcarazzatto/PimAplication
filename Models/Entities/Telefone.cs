namespace PimAplication.Models.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int ddd { get; set; }

        //Relacionamento com a tabela TipoTelefone
        public int TipoTelefoneId { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
