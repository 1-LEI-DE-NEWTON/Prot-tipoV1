document.getElementById('venda-form').addEventListener('submit', function(e) {
    e.preventDefault();
    
    // Coletar os dados do formulário
    const produto = document.getElementById('produto').value;
    const quantidade = document.getElementById('quantidade').value;
    const preco = document.getElementById('preco').value;
    const desconto = document.getElementById('desconto').value || 0;

    // Verificação simples
    if (!produto || !quantidade || !preco) {
        alert('Por favor, preencha todos os campos obrigatórios!');
        return;
    }

    // Exemplo de como os dados poderiam ser enviados via API
    // Aqui você pode usar fetch() para enviar dados ao backend (FastAPI ou outro)
    const dadosVenda = {
        produto,
        quantidade,
        preco,
        desconto
    };

    console.log(dadosVenda); // Aqui você pode substituir por uma chamada fetch, por exemplo

    // Limpar o formulário após submissão
    document.getElementById('venda-form').reset();
});
