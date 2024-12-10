const API_URL = "https://localhost:7223/api";
let jwtToken = localStorage.getItem("jwtToken") || "";

async function apiRequest(endpoint, method = "GET", body = null) {
    const headers = {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
    };

    const options = { method, headers };

    if (body) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(`${API_URL}/${endpoint}`, options);

    if (response.ok) {
        try {
            return await response.json();
        } catch (error) {
            console.error(`Erro na requisição para ${endpoint}:`, error);
            throw new Error("Erro: " + error);
        }        
    } else if (response.status === 401) {     
     console.error("Token expirado ou inválido. Redirecionando para a página de login.");
     localStorage.removeItem("jwtToken");
     jwtToken = "";
     window.location.href = "login.html";
    }    
    else {
        console.error(`Erro na requisição para ${endpoint}:`, response.status);
        throw new Error("Status: " + response.status);
    }
}

async function login(username, password) {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password })
    });

    if (response.ok) {
        const data = await response.json();
        jwtToken = data.token;
        localStorage.setItem("jwtToken", jwtToken);
        return data;
    } else {
        throw new Error("Falha no login");
    }
}