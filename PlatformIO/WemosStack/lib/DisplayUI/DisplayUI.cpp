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

    void DisplayUI::DrawBottomGrid(){
      this->display.drawLine(0, 41, 64, 41 , WHITE);
      this->display.drawLine(0, 47, 64, 47 , WHITE);
      for(int i = 0; i<=64; i+=7){
        this->display.drawLine(i, 42, i, 48 , WHITE);
      }

       for(int j = 0; j<=64; j+=7){
         this->display.fillRect(j+3, 43, 2, 2 , WHITE);
         
         this->display.display();
         delay(200);

          for(int j = 0; j<=64; j+=7){
            this->display.fillRect(j+3, 43, 2, 2 , BLACK);
            
          }
          this->display.display();

      }

       for(int j = 0; j<=64; j+=7){
         this->display.fillRect(j+3, 43, 2, 2 , BLACK);
         this->display.display();
      }


      this->display.display();
    }
   
   
