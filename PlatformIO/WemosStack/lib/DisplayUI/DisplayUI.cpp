#include "DisplayUI.h"
   

    DisplayUI::DisplayUI() {
      Adafruit_SSD1306 oled(OLED_RESET);
      this->display = oled;
      this->display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
      this->display.clearDisplay();    
    }
    

    void DisplayUI::ShowMessage(String message) {
      this->display.setTextSize(1);
      this->display.setTextColor(WHITE);
      this->display.setCursor(0,0);
      this->display.println(message);
      this->display.display();
    }

    void DisplayUI::Clear() {
      this->display.clearDisplay();
      this->display.display();
    }

    void DisplayUI::Reiceve(){
      this->display.setTextSize(1);
      this->display.setTextColor(WHITE);
      this->display.fillRect(50,40,10,10,BLACK);
      this->display.setCursor(50,40);
      display.write(31);
      display.display();
    }

    void DisplayUI::Send(){
      this->display.setTextSize(1);
      this->display.setTextColor(WHITE);
      this->display.fillRect(50,40,10,10,BLACK);
      this->display.setCursor(50,40);
      this->display.write(30);
      this->display.display();
    }
   
   
