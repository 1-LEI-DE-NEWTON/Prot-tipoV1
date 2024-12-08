document.getElementById('login-form').addEventListener('submit', function(event) {
    event.preventDefault();
    
    // Pegando os dados do formulário
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Aqui, você pode integrar com a API ou fazer outras ações
    console.log('Username:', username);
    console.log('Password:', password);

    // Simulando sucesso no login
    alert('Login realizado com sucesso!');
});
