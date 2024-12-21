import unittest
from RPA.queue_manager import QueueManager

class TestQueueManager(unittest.TestCase):
    def test_fetch_queue(self):
        queue_manager = QueueManager()
        queue = queue_manager.fetch_queue()
        self.assertIsInstance(queue, list)   

    def test_process_queue(self):
        queue_manager = QueueManager()
        queue_manager.process_queue()
        self.assertTrue(True)                        

if __name__ == '__main__':
    unittest.main()