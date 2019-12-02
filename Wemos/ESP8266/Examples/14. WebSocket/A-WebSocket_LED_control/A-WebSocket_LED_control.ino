#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <WebSocketsServer.h>

#include <Adafruit_NeoPixel.h>

#define PIN   D2
#define LED_NUM 12
Adafruit_NeoPixel pixels = Adafruit_NeoPixel(LED_NUM, PIN, NEO_GRB + NEO_KHZ800);




ESP8266WiFiMulti wifiMulti;       // Create an instance of the ESP8266WiFiMulti class, called 'wifiMulti'
     // create a web server on port 80
WebSocketsServer webSocket(81);    // create a websocket server on port 81
                                  // a File variable to temporarily store the received file

const char *ssid = "ESP8266"; // The name of the Wi-Fi network that will be created
const char *password = "123456";   // The password required to connect to it, leave blank for an open network

const char *OTAName = "ESP8266";           // A name and a password for the OTA service
const char *OTAPassword = "esp8266";

const char* mdnsName = "esp8266"; // Domain name for the mDNS responder

/*__________________________________________________________SETUP__________________________________________________________*/

void setup() {

  Serial.begin(115200);        // Start the Serial communication to send messages to the computer
  delay(10);
  Serial.println("\r\n");

  startWiFi();                 // Start a Wi-Fi access point, and try to connect to some given access points. Then wait for either an AP or STA connection
  startWebSocket();            // Start a WebSocket server
  
  pixels.begin();
  pixels.setBrightness(200);  // Lower brightness and save eyeballs!
  pixels.show();
  pixels.clear();
  
}

/*__________________________________________________________LOOP__________________________________________________________*/

unsigned long prevMillis = millis();

void loop() {
  webSocket.loop();                           // constantly check for websocket events
}

/*__________________________________________________________SETUP_FUNCTIONS__________________________________________________________*/

void startWiFi() { // Start a Wi-Fi access point, and try to connect to some given access points. Then wait for either an AP or STA connection
  WiFi.softAP(ssid, password);             // Start the access point
  Serial.print("Access Point \"");
  Serial.print(ssid);
  Serial.println("\" started\r\n");

  wifiMulti.addAP("PIPPO_Osp", "62353054417892078167");   // add Wi-Fi networks you want to connect to
  wifiMulti.addAP("whyphy", "esp8266");
  wifiMulti.addAP("INCAS-GUEST", "Inc4sGroup");
  wifiMulti.addAP("FASTWEB-B3A2AD", "HAY9KMZPTK"); //CASA DI DANA
  

  Serial.println("Connecting");
  while (wifiMulti.run() != WL_CONNECTED && WiFi.softAPgetStationNum() < 1) {  // Wait for the Wi-Fi to connect
    delay(250);
    Serial.print('.');
  }
  Serial.println("\r\n");
  if(WiFi.softAPgetStationNum() == 0) {      // If the ESP is connected to an AP
    Serial.print("Connected to ");
    Serial.println(WiFi.SSID());             // Tell us what network we're connected to
    Serial.print("IP address:\t");
    Serial.print(WiFi.localIP());            // Send the IP address of the ESP8266 to the computer
  } else {                                   // If a station is connected to the ESP SoftAP
    Serial.print("Station connected to ESP8266 AP");
  }
  Serial.println("\r\n");
}

void startWebSocket() { // Start a WebSocket server
  webSocket.begin();                          // start the websocket server
  webSocket.onEvent(webSocketEvent);          // if there's an incomming websocket message, go to function 'webSocketEvent'
  Serial.println("WebSocket server started.");
}

/*__________________________________________________________SERVER_HANDLERS__________________________________________________________*/


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
       
       pixels.show();

        
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



       pixels.setPixelColor(le, pixels.Color(g, r, b));
       pixels.setBrightness(br); 
  
       pixels.show();

       
       
        
      } else if (payload[0] == 'C') {                      // the browser sends an R when the rainbow effect is enabled
       pixels.clear();
       pixels.show();
      } else if (payload[0] == 'N') {                      // the browser sends an N when the rainbow effect is disabled
      
      }
      break;
  }
}

/*__________________________________________________________HELPER_FUNCTIONS__________________________________________________________*/

String formatBytes(size_t bytes) { // convert sizes in bytes to KB and MB
  if (bytes < 1024) {
    return String(bytes) + "B";
  } else if (bytes < (1024 * 1024)) {
    return String(bytes / 1024.0) + "KB";
  } else if (bytes < (1024 * 1024 * 1024)) {
    return String(bytes / 1024.0 / 1024.0) + "MB";
  }
}
