#include <ezOutput.h>

String ulaz = "";
String komanda = "";

boolean ulazPrim = false;

const unsigned long dTime = 1000; // delay u ms
const unsigned long baudRate = 9600; // baudrate za serial
const int ledPin = 5; // pin za LED

// ezOutput library
ezOutput led(ledPin);

void setup() 
{
  Serial.begin(baudRate); // otvaranje serial porta
  pinMode(ledPin, OUTPUT); // podesavanje pina za output

  Serial.println("[SETUP ZAVRSEN]");
}

void loop()
{
  while (Serial.available())
  {
    ulaz = Serial.readString(); // citanje ulaza sa serial porta
    traziKomandu(); // ucitavanje ulaza kao komanda

    // Komanda na inicijalizaciji konekcije
    if (komanda.equals("STAR"))
    {
      Serial.println("[START FUNKCIJA]");
      ledBlinkTimed();
    }

    // Zaustavljanje sijalice
    else if (komanda.equals("STOP"))
    {
      Serial.println("[STOP FUNKCIJA]");
      led.low();
    }

    // Paljenje sijalice
    else if (komanda.equals("LEDON"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        Serial.println("[LED ON FUNKCIJA]");
        led.high();
      }
      
    }

    // Gasenje sijalice
    else if (komanda.equals("LEDOF"))
    {
      boolean LedState = led.getState();

      if (LedState == true)
      {
        Serial.println("[LED OFF FUNKCIJA]");
        led.low();
      }
    }

    // Blinkanje bez prestanka
    else if (komanda.equals("LEDBL"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        Serial.println("[LED BLINK FUNKCIJA]");
        ledBlink();
      }
      
    }

    // Blinkanje tri puta
    else if (komanda.equals("LEDB3"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        Serial.println("[LED BLINK x3 FUNKCIJA]");
        ledBlinkTimed();
      }
    }
  }

  ulaz = "";

}

// Prosledjivanje ulaza kao komanda
void traziKomandu()
{
  if (ulaz.length() > 0)
  {
    komanda = ulaz;
    Serial.println("[KOMANDA: " + komanda + "]");
  }
}

/* Funkcije za blinkanje LED lampica */
void ledBlinkTimed()
{
  // TO-DO - dodati blinkanje sa odredjenim tajmingom
}

// Privremena test funkcija
void ledBlink()
{
  led.high();
  delay(1000);
  led.low();
  delay(1000);
  led.high();
  delay(1000);
  led.low();
}
