// Filip Petrovic, IV-1, 2021.

// TO-DO - Uraditi interfejs sa arduinom
// TO-DO - Dodati opciju za biranje serial port-a

using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace LEDControl
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();

        struct Choice
        {
            public string PortName;
            public string BaudRate;
        }
        
        Choice choice;
        
        public Form1()
        {
            InitializeComponent();

            FormClosed += Form1_FormClosed;
            comboBox1.DropDownClosed += comboBox1_DropDownClosed;
            comboBox2.DropDownClosed += comboBox2_DropDownClosed;
            button1.Click += button1_Click;
        }

        private void LEDControl_Load(object sender, EventArgs e)
        {
            // Inicijalizacija - initialization
            port.PortName = "COM1";
            port.BaudRate = 9600;
        }

        /* Eventovi za formu - form events */
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            choice.PortName = (sender as ComboBox).SelectedItem.ToString();
            port.PortName = choice.PortName;
            MessageBox.Show($"[COM: {choice.PortName}]");
        }
        
        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            choice.BaudRate = (sender as ComboBox).SelectedItem.ToString();
            port.BaudRate = Convert.ToInt32(choice.BaudRate);
            MessageBox.Show($"[BITRATE: {choice.BaudRate}]");
        }
        
        /* Glavna dugmad za paljenje - main on/off buttons */
        
        // ON dugme/button
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"COM: [{port.PortName}] BR: [{port.BaudRate}]");
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