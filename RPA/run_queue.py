# filepath: /c:/Users/TKFir/OneDrive/Estudos/TI/Programação/Códigos/ProtótipoV1/RPA/run_queue_manager.py
from queue_manager import QueueManager

if __name__ == "__main__":
    manager = QueueManager()
    manager.fetch_queue()

    # roda o update
    manager.update_status(9, 3)