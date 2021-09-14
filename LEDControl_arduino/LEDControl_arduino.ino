#include <ezOutput.h>

String ulaz = "";
boolean ulazPrim = false;
String komanda = "";

boolean isConnected = false;
unsigned long dTime = 1000;

ezOutput led(14);

void setup() {
  Serial.begin(9600);
}

void loop() {

  if (ulazPrim)
  {
    ulazPrim = false;
    traziKomandu();

    if (komanda.equals("STAR"))
    {
      led.blink(dTime, dTime, 2);
    }

    else if (komanda.equals("STOP"))
    {
      led.low();
    }

    else if (komanda.equals("LEDON"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        led.high();
      }
      
    }

    else if (komanda.equals("LEDOF"))
    {
      boolean LedState = led.getState();

      if (LedState == true)
      {
        led.low();
      }
    }

    else if (komanda.equals("LEDBL"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        led.blink(dTime, dTime);
      }
      
    }

    else if (komanda.equals("LEDB3"))
    {
      boolean LedState = led.getState();

      if (LedState == false)
      {
        led.blink(dTime, dTime, 3);
      }
    }
  }

  ulaz = "";
}

void traziKomandu()
{
  if (ulaz.length() > 0)
  {
    komanda = ulaz.substring(1, 5);
  }
}
/*
// Kontrola LED lampica
boolean getLedState()
{
  boolean state = false;

  if (ulaz.substring(5,7).equals("ON"))
  {
    state = true;
  }

  else 
  {
    state = false;
  }

  return state;
}

void ledBlinkTimed(int count)
{
  for (int i = 0; i < count; i++)
  {
    ledOn(ledPin);
    delay(dTime);
    ledOff(ledPin);
  }
}

void ledBlink()
{
  while (true)
  {
    ledOn(ledPin);
    delay(dTime);
    ledOff(ledPin);
  }
}

void ledOn(int pin)
{
  digitalWrite(pin, HIGH);
}

void ledOff(int pin)
{
  digitalWrite(pin, LOW);
}
*/
void serialEvent()
{
  while (Serial.available())
  {
    char inChar = (char)Serial.read();
    ulaz += inChar;

    if (inChar == '\n')
    {
      ulazPrim = true;
    }
  }
}
