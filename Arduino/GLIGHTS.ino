#include <FastLED.h>
#define LED_PIN 3
#define NUM_LEDS 30

CRGB leds[NUM_LEDS];
int offset;
int x;
int hue;
float t;
int packet[91];
int color[89];
int currentPack = 0;
float smoothness = 0.2;
bool stringComplete;
bool off = 0;

void setup() 
{
  FastLED.addLeds<WS2812, LED_PIN, GRB>(leds, NUM_LEDS);
  Serial.begin(19200);
  for (int i = 0; i < 30; i++)
  {
    leds[i] = CHSV(0,200,0);
  }
  FastLED.show();
}

void loop() 
{
  if(stringComplete == true)
  {
    //Off
    if (packet[0] == 0)
    {
    for (int i = 0; i < 30; i++)
      {
        leds[i] = CRGB(0, 0, 0);
      }
      FastLED.show();
    }
    
    //Color Match
    if (packet[0] == 1)
    {
      for (int i = 0; i < 30; i++)
      {
        color[i] = color[i] + (packet[i+1] - color[i]) * smoothness;
        color[i+30] = color[i+30] + (packet[i+31] - color[i+30]) * smoothness;
        color[i+60] = color[i+60] + (packet[i+61] - color[i+60]) * smoothness;
      }
      
      for (int i = 0; i < 30; i++)
      {
        leds[i] = CRGB(color[i], color[i+30], color[i+60]);
      }
      FastLED.show();
    }
    
    
    //RGB Swirl
    if (packet[0] == 2)
    {
      for (int i = 0; i < 30; i++)
      {
        leds[i] = CHSV(i*8.5 + t, 255, 100);
      }
      t = t + 0.1;
      FastLED.show();
    }
    
    
    //Standing Wave
    if (packet[0] == 3)
    {
      for (int i = 0; i < 30; i++)
      {
        x = i;
        hue = ((sin(0.1046*x - t)+sin(0.1046*x + t))+t) * 100;
        leds[i] = CHSV(hue, 255, 100);
      }
      t = t + 0.005;
      FastLED.show();
    }
    //Settings
    if(packet[0] == 4)
    {
      //smoothness
      if(packet[1] == 0)
      {
        //Up
        if(packet[2] == 0)
        {
          if(smoothness < 1)
          {
            smoothness = smoothness + 0.05;
          }
        }
        //Down
        if(packet[2] == 1)
        {
          if(smoothness > 0)
          {
            smoothness = smoothness - 0.05;
          }
        }
      }
    }
    
    //Set all leds to a single color
    if(packet[0] == 5)
    {
      for(int i = 0; i < 30; i++)
      {
        leds[i] = CRGB(packet[1], packet[2], packet[3]);
        FastLED.show();
      }
    }
    
    //Experimental Color Match Left
    if (packet[0] == 6)
    {
      for (int i = 0; i < 8; i++)
      {
        color[i] = color[i] + (packet[i+1] - color[i]) * smoothness;
        color[i+8] = color[i+8] + (packet[i+9] - color[i+17]) * smoothness;
        color[i+16] = color[i+16] + (packet[i+17] - color[i+17]) * smoothness;
      }
      for (int i = 0; i < 8; i++)
      {
        leds[i] = CRGB(color[i], color[i+8], color[i+16]);
      }
      FastLED.show();
    }
    
    //Auto Connect
    if(packet[0] == 254)
    {
      Serial.write(254);
      packet[0] = 0;
    }
  }
}

void setLEDs(int r, int g, int b)
{
  for (int i = 0; i < 30; i++)
  {
    leds[i] = CRGB(r, g, b);
  }
  FastLED.show();
}

void serialEvent()
{
  while(Serial.available())
  {
    unsigned char inChar = (char)Serial.read();
    
    if(inChar != 255)
    {
      packet[currentPack] = inChar;
      currentPack++;
    }
    
    if(inChar == 255)
    {
      stringComplete = true;
      currentPack = 0;
    }
  }
}
