// Filip Petrovic, IV-1, 2021.

using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace LEDControl
{
    public partial class Form1 : Form
    {
        private static readonly string[] Status = { 
            "SPREMAN", "UPALJEN", "BLINKANJE"
        };
        private bool _isConnected; 
        private bool _isActive;
        
        String[] _ports;
        SerialPort _port;

        /* Event binding & form initialization */
        public Form1()
        {
            InitializeComponent();
            DisableControls(); 
            GetAvailablePorts(); 

            foreach (string port in _ports)
            {
                comboBox1.Items.Add(port);
                if (_ports[0] != null)
                {
                    comboBox1.SelectedItem = _ports[0];
                }
            }

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click_1;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                InitArduino(); 
            }

            else
            {
                DiscArduino();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                if (!_isActive)
                {
                    _isActive = true;
                    textBox1.Text = Status[1];
                    _port.Write("#LEDON\n");
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                if (_isActive)
                {
                    _isActive = false;
                    _port.Write("#LEDOF\n");
                    textBox1.Text = Status[0];
                }
            }
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                if (!_isActive)
                {
                    _isActive = true;
                    textBox1.Text = Status[2];
                    _port.Write("#LEDBL\n");
                }
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                if (!_isActive)
                {
                    _isActive = true;
                    textBox1.Text = Status[2];
                    _port.Write("#LEDB3\n");
                }
            }
        }

        void GetAvailablePorts()
        {
            _ports = SerialPort.GetPortNames();
        }

        private void InitArduino()
        {
            _isConnected = true;
            
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            _port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            
            _port.Open();
            _port.Write("#STAR\n");
            button5.Text = @"Diskonektuj se";

            EnableControls();
        }

        private void DiscArduino()
        {
            _isConnected = false;
            
            _port.Write("#STOP\n");
            _port.Close();

            button5.Text = @"Inicijalizacija";

            DisableControls();
            ResetDefaults();
        }

        private void EnableControls()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void DisableControls()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void ResetDefaults()
        {
            textBox1.Text = Status[0];
        }
    }
}