using Microsoft.AspNetCore.Mvc;
using PimAplication.Repository;
using PimAplication.Repository.Interface;

namespace PimAplication.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IEnderecoRepository _repository;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public ContatoController(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("consultar{id}")]

        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var endereco = await _repository.GetEnderecoById(id);

            if(endereco != null)
            {
                return Ok(endereco);
            }
            else
            {
                return NotFound("Endereço não encontrado");
            }
        }
    }
}
