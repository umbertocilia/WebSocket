using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace WebSocketApp
{

    class Consumer
    {
        Queue<Led> queue;
        Object lockObject;
        WebSocketSharp.WebSocket ws;
        int lumos = 200;
        public Consumer(Queue<Led> queue, Object lockObject, WebSocketSharp.WebSocket ws)
        {
            this.queue = queue;
            this.lockObject = lockObject;
            this.ws = ws;
        }

        public void consume()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (queue.Count == 0)
                    {
                        continue;
                    }

                    SetColor(queue.Dequeue(), ws);
                }
            }
        }

        public void SetColor(Led l, WebSocket ws)
        {
            ws.Connect();

            byte[] bytes = BitConverter.GetBytes(l.GetColor().ToArgb());
            byte bVal = bytes[0];
            byte gVal = bytes[1];
            byte rVal = bytes[2];
            byte aVal = bytes[3];


            string led = "";
            if (l.Number <= 9) { led = "0" + l.Number.ToString(); }
            else { led = l.Number.ToString(); }
            string r = rVal.ToString().PadLeft(3, '0');
            string g = gVal.ToString().PadLeft(3, '0');
            string b = bVal.ToString().PadLeft(3, '0');
            string lum = lumos.ToString().PadLeft(3, '0');


            string result = "#" + led + r + g + b + lum;

            ws.Send(result);
        }
    }
}

