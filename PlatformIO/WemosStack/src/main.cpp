#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <WebSocketsServer.h>
#include <Adafruit_GFX.h>
#include <WEMOS_SHT3X.h>
#include <Adafruit_SSD1306.h>
#include <SPI.h>
#include <Wire.h>
#include <SD.h>
#include <DisplayUI.h>
#include <Tasker.h>



ESP8266WiFiMulti wifiMulti; 
WebSocketsServer webSocket(81);
DisplayUI UI; 
Tasker tasker; 

const char *ssid = "ESP8266"; // The name of the Wi-Fi network that will be created
const char *password = "123456";   // The password required to connect to it, leave blank for an open network

const char* mdnsName = "esp8266"; // Domain name for the mDNS responder

String ipToString(IPAddress ip){
  String s="";
  for (int i=0; i<4; i++)
    s += i  ? "." + String(ip[i]) : String(ip[i]);
  return s;
}

void startWiFi() { // Start a Wi-Fi access point, and try to connect to some given access points. Then wait for either an AP or STA connection
  WiFi.softAP(ssid, password);             // Start the access point
  Serial.print("Access Point \"");
  Serial.print(ssid);
  Serial.println("\" started\r\n");

  wifiMulti.addAP("PIPPO_Osp", "62353054417892078167");   // add Wi-Fi networks you want to connect to
  wifiMulti.addAP("whyphy", "esp82666");
  wifiMulti.addAP("INCAS-GUEST", "Inc4sGroup");
  wifiMulti.addAP("FASTWEB-B3A2AD", "HAY9KMZPTK"); //CASA DI DANA
  

  Serial.println("Connecting");
  UI.Clear();
  UI.ShowMessage("Connetting");

  while (wifiMulti.run() != WL_CONNECTED && WiFi.softAPgetStationNum() < 1) {  // Wait for the Wi-Fi to connect
    delay(250);
    Serial.print('.');
  }

  Serial.println("\r\n");
  if(WiFi.softAPgetStationNum() == 0) {      // If the ESP is connected to an AP
    Serial.print("Connected to ");

    UI.Clear();
    UI.ShowMessage(ipToString(WiFi.localIP()));
    UI.DrawBottomGrid();

    Serial.println(WiFi.SSID());             // Tell us what network we're connected to
    Serial.print("IP address:\t");
    Serial.print(WiFi.localIP());            // Send the IP address of the ESP8266 to the computer
  } else {                                   // If a station is connected to the ESP SoftAP
    Serial.print("Station connected to ESP8266 AP");
  }
  Serial.println("\r\n");
}



void webSocketEvent(uint8_t num, WStype_t type, uint8_t * payload, size_t lenght) { // When a WebSocket message is received
  switch (type) {
    case WStype_DISCONNECTED:             // if the websocket is disconnected
      Serial.printf("[%u] Disconnected!\n", num);
      break;
    case WStype_CONNECTED: {              // if a new websocket connection is established
        IPAddress ip = webSocket.remoteIP(num);
        Serial.printf("[%u] Connected from %d.%d.%d.%d url: %s\n", num, ip[0], ip[1], ip[2], ip[3], payload);
                      // Turn rainbow off when a new connection is established
      }
      break;
    case WStype_TEXT:                     // if new text data is received
      Serial.printf("[%u] get Text: %s\n", num, payload);
      if (payload[0] == '#') {            // we get RGB data
        
       //#01 222 333 444 000
       String pl = String((char *)payload);
       //Serial.print(pl);
       
        String ledino = pl.substring(1,3);
        String Red = pl.substring(3,6);
        String Green = pl.substring(6,9);
        String Blue = pl.substring(9,12);
        String Brigth = pl.substring(12,15);


        Serial.println(ledino);
        Serial.println(Red);
        Serial.println(Green);
        Serial.println(Blue);
        Serial.println(Brigth);

        uint8_t le = (uint8_t) ledino.toInt();
        uint8_t r = (uint8_t)Red.toInt();
        uint8_t g = (uint8_t)Green.toInt();
        uint8_t b = (uint8_t)Blue.toInt();
        uint8_t br = (uint8_t)Brigth.toInt();




       
       
        
      } else if (payload[0] == 'C') {                      // the browser sends an R when the rainbow effect is enabled
       
      } else if (payload[0] == 'N') {                      // the browser sends an N when the rainbow effect is disabled
      
      }
      break;

    default:
      break;
  }
}

void startWebSocket() { // Start a WebSocket server
  webSocket.begin();                          // start the websocket server
  webSocket.onEvent(webSocketEvent);          // if there's an incomming websocket message, go to function 'webSocketEvent'
  Serial.println("WebSocket server started.");
}

void ProgressBarTask(){
  UI.DrawBottomGrid();
}

void setup() {

  Serial.begin(115200);        // Start the Serial communication to send messages to the computer
  delay(10);
  Serial.println("\r\n");

  startWiFi();
  startWebSocket(); 
  tasker.setInterval(ProgressBarTask, 2000);
   
   
          
}

/*__________________________________________________________LOOP__________________________________________________________*/

unsigned long prevMillis = millis();

void loop() {
  webSocket.loop();                           // constantly check for websocket events
  tasker.loop();
}

