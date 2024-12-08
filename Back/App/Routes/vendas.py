from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from database import SessionLocal
from models import Venda
from schemas import VendaSchema

router = APIRouter()

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@router.post("/vendas")
def criar_venda(venda: VendaSchema, db: Session = Depends(get_db)):
    nova_venda = Venda(cliente_id=venda.cliente_id, valor=venda.valor)
    db.add(nova_venda)
    db.commit()
    db.refresh(nova_venda)
    return nova_venda

@router.get("/vendas")
def listar_vendas(db: Session = Depends(get_db)):
    return db.query(Venda).all()
