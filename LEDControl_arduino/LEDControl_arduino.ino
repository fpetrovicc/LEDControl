String ulaz = "";
String komanda = "";

boolean ulazPrim = false;

const unsigned long dTime = 100; // delay u ms
const unsigned long baudRate = 9600; // baudrate za serial
const int ledPin = 13; // pin za LED

unsigned long prethodnoVreme = millis();
bool blink = false;
bool isOn = false;

// ezOutput library

void setup() 
{
  Serial.begin(baudRate); // otvaranje serial porta
  pinMode(ledPin, OUTPUT); // podesavanje pina za output

  Serial.println("[SETUP ZAVRSEN]");
}

void loop()
{
  
  unsigned long trenutnoVreme = millis();
  
  if (blink) {
    if (trenutnoVreme - prethodnoVreme >= dTime) {
    	
      if (isOn) {
      	digitalWrite(ledPin, LOW);
      } else {
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
      ledBlinkTimed();
    }

    // Zaustavljanje sijalice
    else if (komanda.equals("STOP"))
    {
      Serial.println("[STOP FUNKCIJA]");
      //led.low();
      digitalWrite(ledPin, LOW);
    }

    // Paljenje sijalice
    else if (komanda.equals("LEDON"))
    {
        Serial.println("[LED ON FUNKCIJA]");
        //led.high();
        digitalWrite(ledPin, HIGH);
      
    }

    // Gasenje sijalice
    else if (komanda.equals("LEDOF"))
    {
        Serial.println("[LED OFF FUNKCIJA]");
        //led.low();
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
        ledBlinkTimed();
    }
    
    else if (komanda.equals("STOPB")) {
    	blink = false;
      	isOn = false;
      	digitalWrite(ledPin, LOW);
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
  blink = true;
}

// Privremena test funkcija
void ledBlink()
{
  digitalWrite(ledPin, HIGH);
  delay(1000);
  digitalWrite(ledPin, LOW);
  delay(1000);
  digitalWrite(ledPin, HIGH);
  delay(1000);
  digitalWrite(ledPin, LOW);
}
