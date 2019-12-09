using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace WebSocketApp
{
    class Producer
    {
        Queue<string> queue;
        static int seq;
        public Producer(Queue<string> queue)
        {
            this.queue = queue;
        }

        public void produce(string s)
        {
            while (true) //just testinng 15 items
            {
                string item = "item" + seq;
                queue.Enqueue(item);
                Console.WriteLine("Producing {0}", item);
            }
        }
    }
}


