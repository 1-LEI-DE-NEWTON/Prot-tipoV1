document.addEventListener("DOMContentLoaded", async () => {
    try {
        const vendas = await apiRequest("ListarVendas");
        const historicoContainer = document.getElementById("historico-container");

        vendas.forEach((venda) => {
            const vendaBox = document.createElement("div");
            vendaBox.className = "historico-box";
            vendaBox.innerHTML = `
                <p><strong>Nome:</strong> ${venda.nomeCliente}</p>
                <p><strong>Data:</strong> ${venda.dataVenda}</p>
            `;
            vendaBox.addEventListener("click", () => {
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