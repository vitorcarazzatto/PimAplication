using PimAplication.Models.Entities;

namespace PimAplication.Repository.Interface
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> GetEnderecoById(int id);

    }

}
