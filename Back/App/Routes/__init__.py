# Arquivo __init__.py dentro de routes
from .auth import router as auth_router
from .vendas import router as vendas_router
from .clientes import router as clientes_router

# Aqui você pode importar e definir todas as rotas que o projeto vai utilizar
