﻿using BackEnd_NET6.Models;
using BackEnd_NET6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_NET6.Controllers
{
    public class RpaController : Controller
    {
        private readonly I_Venda_Service _vendaService;

        public RpaController(I_Venda_Service vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        [Route("api/rpa/obter-fila-vendas")]

        public IActionResult ObterFilaVendas()
        {
            var vendas = _vendaService.ListarVendasNaFila();

            if (vendas == null)
            {
                return NotFound(new
                {
                    mensagem = "Nenhuma venda na fila"
                });
            }

            return Ok(vendas);
        }

        //atualizar status da venda

        [HttpPut]
        [Route("api/rpa/atualizar-status-venda/{id}")]

        public IActionResult AtualizarStatusVenda(int id, [FromBody] StatusVenda status)
        {
            if (id <= 0)
            {
                return BadRequest(new
                {
                    mensagem = "Id inválido"
                });
            }

            if (string.IsNullOrEmpty(status.ToString()))
            {
                return BadRequest(new
                {
                    mensagem = "Status inválido"
                });
            }

            try
            {
                _vendaService.AtualizarStatusVenda(id, status);
                return Ok(new
                {
                    mensagem = "Status da venda atualizado com sucesso"
                });
            }
            catch (System.Exception e)
            {
                return BadRequest(new
                {
                    mensagem = "Erro ao atualizar status da venda: " + e.Message
                });
            }            
        }        
    }
}