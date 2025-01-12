document.addEventListener('DOMContentLoaded', function() {
    const ONE_DAY_IN_MS = 24 * 60 * 60 * 1000;

    // Função para verificar se os dados estão no cache e se precisam ser atualizados
    function shouldUpdateCache(lastUpdate) {
        if (!lastUpdate) return true;
        const now = new Date().getTime();
        return (now - lastUpdate) > ONE_DAY_IN_MS;
    }

    // Função para popular a lista de vendedores
    async function popularVendedores() {
        const lastUpdate = localStorage.getItem('vendedoresLastUpdate');
        const vendedores = localStorage.getItem('vendedores');

        if (vendedores && !shouldUpdateCache(lastUpdate)) {
            populateSelect('nome_vendedor', JSON.parse(vendedores));
        } else {
            try {
                const response = await fetch('URL_DA_API_VENDEDORES');
                const data = await response.json();
                localStorage.setItem('vendedores', JSON.stringify(data));
                localStorage.setItem('vendedoresLastUpdate', new Date().getTime());
                populateSelect('nome_vendedor', data);
            } catch (error) {
                console.error('Erro ao carregar vendedores:', error);
            }
        }
    }

    // Função para popular a lista de planos
    async function popularPlanos() {
        const lastUpdate = localStorage.getItem('planosLastUpdate');
        const planos = localStorage.getItem('planos');

        if (planos && !shouldUpdateCache(lastUpdate)) {
            populateSelect('plano', JSON.parse(planos));
        } else {
            try {
                const response = await fetch('URL_DA_API_PLANOS');
                const data = await response.json();
                localStorage.setItem('planos', JSON.stringify(data));
                localStorage.setItem('planosLastUpdate', new Date().getTime());
                populateSelect('plano', data);
            } catch (error) {
                console.error('Erro ao carregar planos:', error);
            }
        }
    }

    // Função para popular um elemento select com dados
    function populateSelect(elementId, data) {
        const selectElement = document.getElementById(elementId);
        data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.nome;
            selectElement.appendChild(option);
        });
    }

    // Chama as funções para popular as listas
    popularVendedores();
    popularPlanos();
});

document.getElementById("nova-venda-form").addEventListener("submit", async (event) => {
    event.preventDefault();
    
    const isWhatsapp = document.getElementById('is-whatsapp').checked;

    // Coletar os dados do formulário
    const venda = {
        nomeCliente: document.getElementById('nome_cliente').value,
        telefone: document.getElementById('telefone').value,
        isWhatsapp: isWhatsapp,        
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
