// Filip Petrovic, IV-1, 2021.

// TO-DO - Uraditi dugmad
// TO-DO - Uraditi interfejs sa arduinom
// TO-DO - Dodati opciju za biranje serial port-a

using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace LEDControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LEDControl_Load(object sender, EventArgs e)
        {
            // TO-DO - uraditi setovanje default vrednost
        }
        
        /* Glavna dugmad za paljenje - main on/off buttons */
        
        // ON dugme/button
        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        // OFF dugme/button
        private void button2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        /* Dodatna dugmad sa strane - additional buttons on side */
       
        // Blinkanje dugme/button
        private void button3_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        // Proizvoljno/TBA
        private void button4_Click_1(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        // Proizvoljno/TBA
        private void button5_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}