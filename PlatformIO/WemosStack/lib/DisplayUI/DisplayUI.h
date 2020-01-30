#ifndef DISPLAYUI_H
#define DISPLAYUI_H
#include <Adafruit_SSD1306.h>
#include <Adafruit_GFX.h>

#define OLED_RESET 0  // GPIO0

class DisplayUI {
  private:
    Adafruit_SSD1306 display;
  public:
    DisplayUI();
    
    void ShowMessage(String message);
    void Clear();
    void Reiceve();
    void Send();

    };

    #endif