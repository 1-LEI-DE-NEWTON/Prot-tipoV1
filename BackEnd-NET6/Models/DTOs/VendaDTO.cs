namespace BackEnd_NET6.Models.DTOs
{
    public class VendaDTO
    {                
        // Necessário atualizar DTO para incluir ICCID, PDV e Vendedor
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool IsWhatsApp { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }    
        public DateTime DataNascimento { get; set; }                
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int DataVencimento { get; set; }        
    }
}
