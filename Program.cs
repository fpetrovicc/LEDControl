using System;
using ArduinoDriver;
using System.Threading;
using System.Windows.Forms;
using ArduinoUploader.Hardware;
using ArduinoDriver.SerialProtocol;

namespace LEDControl
{
    static class Program
    {
        /* initialization of private variables */
        private const ArduinoModel AttachedArduino = ArduinoModel.UnoR3; // Arduino that is attached
        public static readonly dynamic Driver = new ArduinoDriver.ArduinoDriver(AttachedArduino, true); 
        private const byte ArduinoLedPin = 13; // LED pin used (default on most is pin 13)
        private const uint Delay = 1500; // Delay between blinking
        public static bool IsRunning; // Bool to check if certain pattern is running
        
        // Turns on LED infinitely
        public static void OnInf(dynamic arduino)
        {
            while (IsRunning)
            {
                arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.High));
            }
        }

        // Turns LED off
        public static void Off(dynamic arduino)
        {
            arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.Low));
        }

        // Sends blinks with delay in between
        public static void SendBlink(dynamic arduino)
        {
            while (IsRunning)
            {
                arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.High));
                Thread.Sleep((int) Delay);
                arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.Low));
                Thread.Sleep((int) Delay);
            }
        }

        // Sends three fast blinks and stops
        public static void SendBlink3(dynamic arduino)
        {
            for (int i = 0; i < 3; i++)
            {
                arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.High));
                Thread.Sleep((int) Delay / 2);
                arduino.Send(new DigitalWriteRequest(ArduinoLedPin, DigitalValue.Low));
                Thread.Sleep((int) Delay / 2);
            }
        }
        
        // Handles exception
        public static void UnhandledEx(object sender, UnhandledExceptionEventArgs exArgs)
        {
            Exception e = (Exception) exArgs.ExceptionObject;
            MessageBox.Show(@"Greska uhvacena: " + e.Message);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}




