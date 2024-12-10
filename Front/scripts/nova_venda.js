document.getElementById("nova-venda-form").addEventListener("submit", async (event) => {
    event.preventDefault();
    
    // Coletar os dados do formulário
    const venda = {
        nomeCliente: document.getElementById('nome_cliente').value,
        telefone: document.getElementById('telefone').value,
        email: document.getElementById('email').value,
        cpf: document.getElementById('cpf').value,
        rg: document.getElementById('rg').value,
        dataNascimento: document.getElementById('data_nascimento').value,
        cep: document.getElementById('cep').value,
        endereco: document.getElementById('endereco').value,
        numero: document.getElementById('numero').value,
        complemento: document.getElementById('complemento').value,
        dataVencimento: document.getElementById('data_vencimento').value    
    };

    // Validar os dados do formulário
    if (Object.values(venda).some(value => value === "")) {
        alert("Preencha todos os campos!");
        return;
    }
    
    // Enviar os dados para a API
    try {
        await apiRequest("vendas/adicionar", "POST", venda);
        alert("Venda cadastrada com sucesso!");
        window.location.href = "menu_inicial.html";                        
    } catch (error) {
        if (error.message.includes("CPF inválido")) {
            alert("CPF inválido! Por favor, verifique o CPF informado.");
        }
        else{
        alert("Erro ao cadastrar a venda! " + error.message);
        }
    }
});
