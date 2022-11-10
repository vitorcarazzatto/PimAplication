using Microsoft.EntityFrameworkCore;
using PimAplication.Data;
using PimAplication.Models.Entities;
using PimAplication.Repository.Interface;

namespace PimAplication.Repository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private readonly PimContext _context;

        public EnderecoRepository(PimContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Endereco?> GetEnderecoById(int id)
        {
                return await _context.Enderecos
                .Where(x => x.Id == id).FirstOrDefaultAsync();  
        }
    }
}
