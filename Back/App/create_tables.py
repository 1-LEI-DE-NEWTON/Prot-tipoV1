from database import Base, engine
from models import Usuario, Venda

Base.metadata.create_all(bind=engine)
