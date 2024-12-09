document.addEventListener("DOMContentLoaded", async () => {
    const historicoContainer = document.getElementById("historico-container");

    if (!historicoContainer) {
        console.error("Elemento 'historico-container' não encontrado no DOM.");
        return;
    }

    try {
        const vendas = await apiRequest("servicos/listar");

        vendas.forEach((venda) => {
            const vendaBox = document.createElement("div");
            vendaBox.className = "sales-box"; // Adiciona a classe sales-box
            //Faça Onclick verDetalhes(venda.nomeCliente)        
            


            // Converte a data de venda para um objeto DateTime            
            const dataVenda = new Date(venda.dataVenda);            

            const dataFormatada = dataVenda.toLocaleString('pt-BR', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
            });

            vendaBox.innerHTML = `
                <p class="client-name"> ${venda.nomeCliente}</p>
                <p class="sale-date"><strong>Data da venda:</strong> ${dataFormatada}</p>
            `;
            vendaBox.addEventListener("click", () => {
                verDetalhes(venda.nomeCliente);
                window.location.href = `detalhes.html?id=${venda.id}`;
            });
            historicoContainer.appendChild(vendaBox);
        });
    } catch (error) {
        alert("Erro ao carregar histórico: " + error.message);
    }
});

// Função para redirecionar para os detalhes da venda
function verDetalhes(cliente) {
    alert("Redirecionando para os detalhes de " + cliente);
    // Aqui, redirecione para a página de detalhes com o cliente selecionado
}

// Implementação básica de pesquisa
const searchInput = document.getElementById('search-input');
const searchBtn = document.getElementById('search-btn');
const salesBoxes = document.querySelectorAll('.sales-box');

searchBtn.addEventListener('click', () => {
    const query = searchInput.value.toLowerCase();
    salesBoxes.forEach(box => {
        const name = box.querySelector('.client-name').textContent.toLowerCase();
        if (name.includes(query)) {
            box.style.display = 'block'; // Mostra a box correspondente
        } else {
            box.style.display = 'none'; // Esconde as que não correspondem
        }
    });
});