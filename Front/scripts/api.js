const API_URL = "https://localhost:7223/api";
let jwtToken = "";

// Função para realizar chamadas autenticadas à API
async function apiRequest(endpoint, method = "GET", body = null) {
    const headers = {
        "Content-Type": "application/json",
        //"Authorization": `Bearer ${jwtToken}`
    };

    const options = { method, headers };

    if (body) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(`${API_URL}/${endpoint}`, options);

    if (response.ok) {
        try{
            return await response.json();
        }
        catch(error){
            console.error(`Erro na requisição para ${endpoint}:`, error);
            throw new Error("Erro na  " + error);
        }
        
    } else {
        console.error(`Erro na requisição para ${endpoint}:`, response.status);
        throw new Error("Erro na  " + response.status);
    }
}

// Função para login (obter JWT)
async function login(username, password) {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        jwtToken = data.token;
        return data;
    } else {
        throw new Error("Falha no login");
    }
}
