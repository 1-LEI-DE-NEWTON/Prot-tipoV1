using BackEnd_NET6.Data;
using BackEnd_NET6.Models;
using BackEnd_NET6.Models.DTOs;
using BackEnd_NET6.Services.Interfaces;

namespace BackEnd_NET6.Services
{
    public class Venda_service : I_Venda_Service
    {
        private readonly VendaContext _context;

        public Venda_service(VendaContext context)
        {
            _context = context;
        }

        public void AdicionarVenda(VendaDTO vendaDTO)
        {
            var venda = new Venda
            {
                NomeCliente = vendaDTO.NomeCliente,
                Email = vendaDTO.Email,
                Telefone = vendaDTO.Telefone,
                IsWhatsApp = vendaDTO.IsWhatsApp,
                CPF = vendaDTO.CPF,
                RG = vendaDTO.RG,                                
                DataNascimento = vendaDTO.DataNascimento.Date,
                CEP = vendaDTO.CEP,
                Endereco = vendaDTO.Endereco,
                Numero = vendaDTO.Numero,
                Complemento = vendaDTO.Complemento,
                DataVencimento = vendaDTO.DataVencimento,
                DataVenda = DateTime.Now
            };

            try 
            {
                _context.Vendas.Add(venda);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar venda: " + e.Message);
            }
        }

        public List<Venda> ListarVendas()
        {
            return _context.Vendas.ToList();
        }
        
        public List<Venda> PesquisarVendasPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return null;
            }
            
            return _context.Vendas
                           .Where(v => v.NomeCliente.Contains(nome))
                           .ToList();
        }

        public Venda PesquisarVendaPorId(int id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }
            
            return _context.Vendas
                           .FirstOrDefault(v => v.Id == id);
        }
        
        public Venda PesquisarVendaPorCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return null;
            }

            return _context.Vendas
                           .FirstOrDefault(v => v.CPF == cpf);
        }
                
        public Venda PesquisarVendaPorTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                return null;
            }
            return _context.Vendas
                           .FirstOrDefault(v => v.Telefone == telefone);
        }

        public void AtualizarVenda(Venda venda)
        {
            if (venda == null)
            {
                throw new Exception("Venda não encontrada");
            }            

            var vendaDB = _context.Vendas
                                  .FirstOrDefault(v => v.Id == venda.Id);

            if (vendaDB == null)
            {
                throw new Exception("Venda não encontrada");
            }            

            vendaDB.NomeCliente = venda.NomeCliente;
            vendaDB.Email = venda.Email;
            vendaDB.Telefone = venda.Telefone;
            vendaDB.IsWhatsApp = venda.IsWhatsApp;
            vendaDB.CPF = venda.CPF;
            vendaDB.RG = venda.RG;
            vendaDB.DataNascimento = venda.DataNascimento;
            vendaDB.CEP = venda.CEP;
            vendaDB.Endereco = venda.Endereco;
            vendaDB.Numero = venda.Numero;
            vendaDB.Complemento = venda.Complemento;
            vendaDB.DataVencimento = venda.DataVencimento;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar venda: " + e.Message);
            }
                                            
        }
    }        
}
