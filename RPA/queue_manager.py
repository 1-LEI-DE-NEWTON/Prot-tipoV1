import requests
import logging
import os
from config import API_CONFIG
from dotenv import load_dotenv

load_dotenv()

logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

class QueueManager:
    def __init__(self):
        self.base_url = API_CONFIG["base_url"]
        self.get_queue_endpoint = API_CONFIG["get_queue_endpoint"]
        self.update_status_endpoint = API_CONFIG["update_status_endpoint"]
        self.auth_token = self.authenticate()

    def _get_headers(self):        
        return {
            "Authorization": f"Bearer {self.auth_token}",
            "Content-Type": "application/json"
        }

    def authenticate(self):        
        auth_url = f"{self.base_url}login"
        credentials = {
            "username": os.getenv("API_USER"),
            "password": os.getenv("API_PASSWORD")
        }        
        try:
            response = requests.post(auth_url, json=credentials, verify=False)
            response.raise_for_status()
            token = response.json().get("token")
            logging.info("Autenticação bem-sucedida.")
            return token
        except requests.RequestException as e:
            logging.error(f"Erro ao autenticar: {e}")
            return None

    def fetch_queue(self):        
        try:
            url = f"{self.base_url}{self.get_queue_endpoint}"
            response = requests.get(url, headers=self._get_headers(), verify=False)
            response.raise_for_status()
            vendas = response.json()
            logging.info(f"Fila carregada: {len(vendas)} vendas na fila.")
            return vendas
        except requests.RequestException as e:
            logging.error(f"Erro ao carregar fila: {e}")
            return []

    def update_status(self, venda_id, status):        
        try:
            url = f"{self.base_url}{self.update_status_endpoint.format(id=venda_id)}"
            payload = {
                "status": status
            }
            response = requests.put(url, headers=self._get_headers(), json=payload, verify=False)
            response.raise_for_status()
            logging.info(f"Venda {venda_id} atualizada para status '{status}'.")
            return True
        except requests.RequestException as e:
            logging.error(f"Erro ao atualizar status da venda {venda_id}: {e}")
            return False

    def process_queue(self):        
        vendas = self.fetch_queue()
        for venda in vendas:
            venda_id = venda["id"]
            try:
                # Atualiza o status para "Em processamento"
                self.update_status(venda_id, 2)
                
                # Passa a venda para o RPA para ser processada
                self._process_venda(venda)
                
                # Atualiza o status para "Concluída" se for bem-sucedido
                self.update_status(venda_id, 1)
            except Exception as e:
                # Atualiza o status para "Erro" em caso de falha
                logging.error(f"Erro ao processar venda {venda_id}: {e}")
                self.update_status(venda_id, 3, detalhes=str(e))

    def _process_venda(self, venda):
        """
        Processa uma venda específica.
        Este método deve chamar o módulo de RPA para interagir com o site de terceiros.
        """
        logging.info(f"Processando venda {venda['id']}: {venda['nomeCliente']}")
        # Aqui você chamaria o RPA para preencher os dados no site.
        # Por exemplo:
        # rpa_worker.process(venda)
        pass