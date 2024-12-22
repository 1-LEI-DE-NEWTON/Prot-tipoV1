import logging
import os
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from screen_identification import ScreenIdentifier
from config import SITE_CONFIG, WAIT_CONFIG
from dotenv import load_dotenv

load_dotenv()

logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

class RPAWorker:
    def __init__(self):        
        self.driver = webdriver.Chrome()
        self.driver.maximize_window()
        self.screen_identifier = ScreenIdentifier(self.driver)

    def login(self):        
        try:
            logging.info("Iniciando o login no site de terceiros.")            
            self.driver.get(SITE_CONFIG["login_endpoint"])
            self.driver.implicitly_wait(10)
            
            
            usernameField = WebDriverWait(self.driver, WAIT_CONFIG["default_wait"]).until(
                EC.presence_of_element_located((By.CSS_SELECTOR, '[formcontrolname="userId"]'))
            )                                                                                                        
            
            usernameField.send_keys(os.getenv("SITE_LOGIN_USER"))

            passwordField = self.driver.find_element(By.CSS_SELECTOR, '[formcontrolname="password"]')

            passwordField.send_keys(os.getenv("SITE_LOGIN_PASSWORD"))
            
            self.driver.find_element(By.CSS_SELECTOR, 'button[type="submit"]').click()

            WebDriverWait(self.driver, WAIT_CONFIG["default_wait"]).until(
                EC.presence_of_element_located((By.CSS_SELECTOR, os.getenv("OK_LOGIN_SCREEN")))
            )
            logging.info("Login realizado com sucesso.")
        except Exception as e:
            logging.error(f"Erro durante o login: {e}")
            raise

    def processar_venda(self, venda):
        """Preenche os dados da venda no site."""
        try:
            logging.info(f"Preenchendo dados para venda ID {venda['id']}.")

            # Navega para o formulário de vendas
            self.driver.get(os.getenv("SITE_CADASTRO_CLIENTE_URL"))

            # Preenche os campos
            #self._preencher_campo(By.ID, "nome_cliente", venda["nomeCliente"])
            #self._preencher_campo(By.ID, "telefone", venda["telefone"])
            self._preencher_campo(By.CSS_SELECTOR, '[aria-label="CPF"]', venda["cpf"])
            #self._preencher_campo(By.ID, "valor", str(venda["valor"]))

            # Submete o formulário
            self.driver.find_element(By.CSS_SELECTOR, 'button[type="submit"]').click()

            # Identifica o resultado
            self._identificar_tela()
        except Exception as e:
            logging.error(f"Erro ao processar venda {venda['id']}: {e}")
            raise

    def _preencher_campo(self, by, identifier, value):
        """Preenche um campo do formulário."""
        campo = WebDriverWait(self.driver, WAIT_CONFIG["default_wait"]).until(
            EC.presence_of_element_located((by, identifier))
        )
        campo.clear()
        campo.send_keys(value)
        logging.info(f"Campo {identifier} preenchido com: {value}")

    def _identificar_tela(self):
        """
        Identifica e lida com a tela retornada após o envio do formulário.
        """
        tela = self.screen_identifier.identificar_tela()

        if tela == "sucesso":
            logging.info("Venda processada com sucesso.")
            return "sucesso"
        elif tela == "erro":
            logging.warning("Erro identificado. Tentando corrigir...")
            if self.screen_identifier.corrigir_erro():
                return "erro corrigido"
            else:
                raise Exception("Erro não corrigido.")
        elif tela == "alternativa":
            logging.info("Fluxo alternativo detectado. Ajustando...")
            # Implemente a lógica para o fluxo alternativo aqui, se necessário
            return "alternativa"
        else:
            raise Exception("Tela indefinida após o envio.")

    def _corrigir_erro(self):
        """Lida com erros identificados durante o processamento."""
        try:
            # Implementa a lógica para corrigir erros, se possível
            logging.info("Tentando corrigir o erro.")
            self.driver.find_element(By.ID, "botao_corrigir").click()
        except Exception as e:
            logging.error(f"Erro ao tentar corrigir: {e}")
            raise

    def finalizar(self):
        """Encerra o navegador e libera os recursos."""
        self.driver.quit()
        logging.info("Navegador fechado.")

# Inicializa o RPA Worker
if __name__ == "__main__":
    worker = RPAWorker()
    worker.login()
    worker.processar_venda({
        "id": 1,
        "nomeCliente": "João da Silva",
        "telefone": "11999999999",
        "cpf": "12345678901",
        "valor": 100.00
    })