from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy.orm import Session
from database import SessionLocal
from models import Usuario
from schemas import LoginSchema
from passlib.context import CryptContext

router = APIRouter()
pwd_context = CryptContext(schemes=["bcrypt"], deprecated="auto")

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@router.post("/login")
def login(user: LoginSchema, db: Session = Depends(get_db)):
    usuario = db.query(Usuario).filter(Usuario.email == user.email).first()
    if not usuario or not pwd_context.verify(user.senha, usuario.senha):
        raise HTTPException(status_code=401, detail="Credenciais inválidas")
    return {"message": "Login bem-sucedido"}
