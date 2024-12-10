using BackEnd_NET6.Data;
using BackEnd_NET6.Models.DTOs;
using BackEnd_NET6.Services;
using BackEnd_NET6.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_NET6.Controllers
{
    [ApiController]
    [Authorize]
    public class VendasController : Controller
    {
        private readonly I_Venda_Service _vendaService;

        public VendasController(I_Venda_Service vendaService)
        {
            _vendaService = vendaService;
        }        

        [HttpPost]

        [Route("api/vendas/adicionar")]

        public IActionResult AdicionarVenda([FromBody] VendaDTO vendaDTO)
        {
            if (string.IsNullOrEmpty(vendaDTO.NomeCliente) ||
            string.IsNullOrEmpty(vendaDTO.Telefone) ||
            string.IsNullOrEmpty(vendaDTO.Email) ||
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
                    _vendaService.AdicionarVenda(vendaDTO);
                    return Ok( new{
                        mensagem = "Venda adicionada com sucesso"
                    });
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
            return Ok(_vendaService.ListarVendas());
        }

        [HttpGet]

        [Route("api/search/nome/{nome}")]

        public IActionResult PesquisarVendasPorNome(string nome)
        {
            return Ok(_vendaService.PesquisarVendasPorNome(nome));
        }

        [HttpGet]

        [Route("api/search/cpf/{cpf}")]

        public IActionResult PesquisarVendaPorCPF(string cpf)
        {
            return Ok(_vendaService.PesquisarVendaPorCPF(cpf));
        }

        [HttpGet]

        [Route("api/search/telefone/{telefone}")]

        public IActionResult PesquisarVendaPorTelefone(string telefone)
        {
            return Ok(_vendaService.PesquisarVendaPorTelefone(telefone));
        }
        
        [HttpGet]

        [Route("api/search/id/{id}")]

        public IActionResult PesquisarVendaPorId(int id)
        {
            return Ok(_vendaService.PesquisarVendaPorId(id));
        }
                    
    }
}
