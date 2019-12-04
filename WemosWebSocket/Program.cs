using System;
using System.Text;
using WebSocketSharp;



namespace WemosWebSocket
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ws = new WebSocket("ws://192.168.137.240:81"))
            {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine("Laputa says: " + e.Data);

                ws.Connect();

                Loop(ws);
                
                Random rnd = new Random();

                while(true)
                {
                    string led = rnd.Next(0, 11).ToString();
                    if (led.Length == 1) { led = "0" + led; }
                    string r = rnd.Next(0, 255).ToString().PadLeft(3, '0');
                    string g = rnd.Next(0, 255).ToString().PadLeft(3, '0');
                    string b = rnd.Next(0, 255).ToString().PadLeft(3, '0');
                    string lum = rnd.Next(0, 255).ToString().PadLeft(3, '0');


                    string result = "#" + led + r + g + b + lum;

                    Console.WriteLine(result);


                    ws.Send("C");


                    ws.Send(result);



                    System.Threading.Thread.Sleep(100);

                }

                void Loop(WebSocket WS)
                {
                    string sequence = "";

                    for (int i = 0; i < 12; i++)
                    {

                        WS.Send("C");
                        sequence = "#" + i.ToString().PadLeft(2, '0') + "000255000255";
                        Console.WriteLine(sequence);


                        WS.Send(sequence);

                        System.Threading.Thread.Sleep(100);
                    }


                }







            }

           

            
        }


       


    }
}




