from fastapi import FastAPI
from Routes import auth, vendas, clientes  # Importe as rotas que você criou
from database import engine, Base

# Criação do app FastAPI
app = FastAPI()

# Criação do banco de dados (caso necessário)
Base.metadata.create_all(bind=engine)

# Incluindo as rotas na API
app.include_router(auth.router, prefix="/auth", tags=["auth"])
app.include_router(vendas.router, prefix="/vendas", tags=["vendas"])
app.include_router(clientes.router, prefix="/clientes", tags=["clientes"])

# Página inicial (opcional)
@app.get("/")
def read_root():
    return {"message": "Bem-vindo à API!"}
