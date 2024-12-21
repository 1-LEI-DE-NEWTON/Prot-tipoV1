
# Configurações do Site de Terceiros
SITE_CONFIG = {
    "url": "https://www.site-do-terceiro.com",  # URL base do site
    "login_endpoint": "/login",                # Endpoint da página de login
    "form_endpoint": "/formulario",            # Endpoint da página de formulário
}

# Credenciais de Acesso
CREDENTIALS = {
    "username": "seu_usuario",                # Nome de usuário para login
    "password": "sua_senha"                   # Senha para login
}

# Configurações de Tempo de Espera
WAIT_CONFIG = {
    "default_wait": 10,  # Tempo padrão de espera explícita (segundos)
    "max_wait": 30,      # Tempo máximo para elementos carregarem
    "retry_interval": 2  # Intervalo entre tentativas de interação
}

# Configurações da API (se necessário)
API_CONFIG = {
    "base_url": "https://sua-api.com/api",    # URL base da API
    "get_queue_endpoint": "/fila-vendas",    # Endpoint para buscar vendas na fila
    "update_status_endpoint": "/vendas/{id}/status",  # Endpoint para atualizar status da venda
    "auth_token": "seu_token_jwt",           # Token JWT para autenticação
}

# Configurações do RPA
RPA_CONFIG = {
    "headless": True,              # Executar o navegador no modo headless (sem interface gráfica)
    "screenshot_on_error": True,   # Tirar captura de tela em caso de erro
    "log_path": "logs/rpa.log",    # Caminho do arquivo de log
}

# Configurações de Logs
LOG_CONFIG = {
    "log_level": "INFO",           # Nível de log (DEBUG, INFO, WARNING, ERROR)
    "log_file": "logs/rpa.log",    # Caminho para salvar os logs
}

# Outras Configurações Gerais
GENERAL_CONFIG = {
    "retry_attempts": 3,  # Número de tentativas em caso de falha
}
