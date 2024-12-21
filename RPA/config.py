
# Configurações do Site de Terceiros
SITE_CONFIG = {
    "url": "https://www.site-do-terceiro.com",  
    "login_endpoint": "/login",                
    "form_endpoint": "/formulario",            
}

# Credenciais de Acesso
CREDENTIALS = {
    "username": "seu_usuario",                
    "password": "sua_senha"                   
}

# Configurações de Tempo de Espera
WAIT_CONFIG = {
    "default_wait": 10,  
    "max_wait": 30,      
    "retry_interval": 2  
}

API_CONFIG = {
    "base_url": "https://localhost:7223/api/",    
    "get_queue_endpoint": "rpa/obter-fila-vendas",    
    "update_status_endpoint": "rpa/atualizar-status-venda/{id}",
    "auth_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdGUiLCJleHAiOjE3MzQ4MDEwNzAsImlzcyI6Im15YXBwIiwiYXVkIjoibXlhcHB1c2VycyJ9.PqGhtdJ2dpwN5YEU0wJlvxzLjoOysZpChx6zGsfEpJo",           
}

# Configurações do RPA
RPA_CONFIG = {
    "headless": True,              
    "screenshot_on_error": True,   
    "log_path": "logs/rpa.log",    
}

# Configurações de Logs
LOG_CONFIG = {
    "log_level": "INFO",           
    "log_file": "logs/rpa.log",    
}

# Outras Configurações Gerais
GENERAL_CONFIG = {
    "retry_attempts": 3,  
}
