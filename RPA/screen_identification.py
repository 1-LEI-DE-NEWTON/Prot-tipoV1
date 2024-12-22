import logging
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from config import WAIT_CONFIG

# Inicializa o log
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

class ScreenIdentifier:
    def __init__(self, driver):
        """Inicializa com o driver do Selenium."""
        self.driver = driver

    def identificar_tela(self):
        """
        Identifica a tela atual com base em elementos do DOM.
        Retorna um string indicando o tipo de tela:
        - 'sucesso': Tela de sucesso ao processar a venda.
        - 'erro': Tela de erro genérico.
        - 'alternativa': Tela alternativa para ajustes manuais.
        - 'indefinido': Nenhum estado conhecido detectado.
        """
        try:
            # Verifica se a tela de sucesso está presente
            if self._is_element_present(By.ID, "sucesso"):
                logging.info("Tela de sucesso identificada.")
                return "sucesso"

            # Verifica se há mensagem de erro no DOM
            if "CPF já cadastrado" in self.driver.page_source:
                logging.warning("Tela de erro detectada: CPF já cadastrado.")
                return "erro"

            # Verifica se há uma tela alternativa
            if self._is_element_present(By.ID, "form_alternativo"):
                logging.info("Tela alternativa detectada.")
                return "alternativa"

            # Nenhum estado conhecido identificado
            logging.error("Tela indefinida.")
            return "indefinido"
        except Exception as e:
            logging.error(f"Erro ao identificar tela: {e}")
            return "indefinido"

    def _is_element_present(self, by, identifier):
        """
        Verifica se um elemento está presente na página.
        Retorna True se o elemento for encontrado, caso contrário False.
        """
        try:
            WebDriverWait(self.driver, WAIT_CONFIG["default_wait"]).until(
                EC.presence_of_element_located((by, identifier))
            )
            return True
        except:
            return False

    def corrigir_erro(self):
        """
        Executa ações para corrigir erros específicos, se possível.
        Exemplo: Navegar para uma tela alternativa ou preencher dados faltantes.
        """
        try:
            logging.info("Tentando corrigir o erro detectado.")
            
            # Exemplo: Clicar no botão para acessar tela alternativa
            if self._is_element_present(By.ID, "botao_corrigir"):
                self.driver.find_element(By.ID, "botao_corrigir").click()
                logging.info("Correção iniciada com sucesso.")
                return True
            else:
                logging.error("Botão de correção não encontrado.")
                return False
        except Exception as e:
            logging.error(f"Erro ao tentar corrigir: {e}")
            return False
