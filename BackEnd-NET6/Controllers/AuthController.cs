using Microsoft.AspNetCore.Mvc;
using BackEnd_NET6.Data;
using BackEnd_NET6.Models;
using BackEnd_NET6.Models.DTOs;

namespace BackEnd_NET6.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly VendaContext _context;
        
        public AuthController(VendaContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("api/login")]
        
        public IActionResult Login([FromBody] LoginDTO login)
        {    
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Dados inválidos");
            }
            
            // Verificar se as credenciais do usuário estão corretas            
            var usuario = _context.Usuarios
                                   .FirstOrDefault(u => u.Username == login.Username 
                                   && u.Password == login.Password);                                            

            // Autenticação bem-sucedida, retorna uma resposta de sucesso
            return Ok("Autenticação bem-sucedida");
        }
    }
}
