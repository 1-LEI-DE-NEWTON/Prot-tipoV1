using BackEnd_NET6.Data;
using BackEnd_NET6.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_NET6.Controllers
{
    [ApiController]
    public class VendasController : Controller
    {
        private readonly VendaContext _context;

        public VendasController(VendaContext context)
        {
            _context = context;
        }

        [HttpPost]

        [Route("api/vendas/adicionar")]

        public IActionResult AdicionarVenda([FromBody] VendaDTO vendaDTO)
        {
            if (string.IsNullOrEmpty(vendaDTO.NomeCliente) ||
            string.IsNullOrEmpty(vendaDTO.Telefone) ||
            string.IsNullOrEmpty(vendaDTO.CPF) ||
            string.IsNullOrEmpty(vendaDTO.RG) ||
            string.IsNullOrEmpty(vendaDTO.CEP) ||
            string.IsNullOrEmpty(vendaDTO.Endereco) ||
            string.IsNullOrEmpty(vendaDTO.Numero) ||
            string.IsNullOrEmpty(vendaDTO.Complemento))
            {
                return BadRequest("Todos os campos são obrigatórios");
            }
            
            
            else
            {
                try
                {
                    AdicionarVenda(vendaDTO);
                    return Ok("Venda adicionada com sucesso");
                }
                catch (Exception e)
                {
                    return BadRequest("Erro ao adicionar venda: " + e.Message);
                }
            }
        }

        [HttpGet]

        [Route("api/servicos/listar")]

        public IActionResult ListarVendas()
        {
            return Ok(ListarVendas());
        }

        [HttpGet]

        [Route("api/search/{nome}")]

        public IActionResult PesquisarVendasPorNome(string nome)
        {
            return Ok(PesquisarVendasPorNome(nome));
        }

        [HttpGet]

        [Route("api/search/{cpf}")]

        public IActionResult PesquisarVendaPorCPF(string cpf)
        {
            return Ok(PesquisarVendaPorCPF(cpf));
        }

        [HttpGet]

        [Route("api/search/{telefone}")]

        public IActionResult PesquisarVendaPorTelefone(string telefone)
        {
            return Ok(PesquisarVendaPorTelefone(telefone));
        }
        
                    
    }
}
