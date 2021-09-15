/*
* AUTORI: Luka Mitrovic IV-1, Filip Petrovic IV-1
* @mitrovicl, @fpetrovicc
*/

String ulaz = "";
String komanda = "";

boolean ulazPrim = false;

const int ledPin = 13; // pin za LED
const unsigned long dTime = 100; // delay u ms
const unsigned long baudRate = 9600; // baudrate za serial

bool isOn = false;
bool blink = false;
unsigned long prethodnoVreme = millis();

void setup() 
{
  Serial.begin(baudRate); // otvaranje serial porta
  pinMode(ledPin, OUTPUT); // podesavanje pina za output

  Serial.println("[SETUP ZAVRSEN]");
}

void loop()
{
  unsigned long trenutnoVreme = millis();
  
  if (blink) 
  {
    
    if (trenutnoVreme - prethodnoVreme >= dTime) 
    {
    	
      if (isOn) 
      {
        digitalWrite(ledPin, LOW);
      } 
    
      else 
      {
	    	digitalWrite(ledPin, HIGH);
      }

      isOn = !isOn;
      prethodnoVreme = trenutnoVreme;
      
    }

  }
  
  if (Serial.available())
  {
    ulaz = Serial.readString(); // citanje ulaza sa serial porta
    traziKomandu(); // ucitavanje ulaza kao komanda

    // Komanda na inicijalizaciji konekcije
    if (komanda.equals("STAR"))
    {
      Serial.println("[START FUNKCIJA]");
      ledBlink();
    }

    // Zaustavljanje sijalice
    else if (komanda.equals("STOP"))
    {
      Serial.println("[STOP FUNKCIJA]");
      
      blink = false;
      isOn = false;
      digitalWrite(ledPin, LOW);
    }

    // Paljenje sijalice
    else if (komanda.equals("LEDON"))
    {
        Serial.println("[LED ON FUNKCIJA]");
        digitalWrite(ledPin, HIGH);
    }

    // Gasenje sijalice
    else if (komanda.equals("LEDOF"))
    {
        Serial.println("[LED OFF FUNKCIJA]");
      	digitalWrite(ledPin, LOW);
    }

    // Blinkanje bez prestanka
    else if (komanda.equals("LEDBL"))
    {
        Serial.println("[LED BLINK FUNKCIJA]");
        ledBlink();
    }

    // Blinkanje tri puta
    else if (komanda.equals("LEDBT"))
    {
        Serial.println("[LED BLINK x3 FUNKCIJA]");
        ledBlink3();
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
void ledBlink()
{
  blink = true;
}

void ledBlink3()
{
  digitalWrite(ledPin, HIGH);
  delay(1000);
  digitalWrite(ledPin, LOW);
  delay(1000);
  digitalWrite(ledPin, HIGH);
  delay(1000);
  digitalWrite(ledPin, LOW);
}