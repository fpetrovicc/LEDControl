// Filip Petrovic, IV-1, 2021.

using System;
using System.Threading;
using System.Windows.Forms;

namespace LEDControl
{
    public partial class Form1 : Form
    {
        /* Initialization of private variables */
        private const int Timeout = 2000; // Timeout used in showing messages
        private static readonly string[] Status = { 
            "SPREMAN", "UPALJEN", "BLINKANJE", "UGASEN"
        }; // Status message array

        /* Event binding & form initialization */
        public Form1()
        {
            InitializeComponent();
            
            AppDomain.CurrentDomain.UnhandledException += Program.UnhandledEx;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click_1;
            button4.Click += button4_Click;
        }

        /* Main on/off buttons */
        
        // ON button
        private void button1_Click(object sender, EventArgs e)
        {
            Program.IsRunning = true;
            textBox1.Text = Status[1];
            Program.OnInf(Program.Driver);
        }
        
        // OFF button
        private void button2_Click(object sender, EventArgs e)
        {
            Program.IsRunning = false;
            Program.Off(Program.Driver);
            textBox1.Text = Status[3];
            Thread.Sleep(Timeout);
            textBox1.Text = Status[0];
        }
        
        /* Additional side buttons */
       
        // Blinking button
        private void button3_Click_1(object sender, EventArgs e)
        {
            Program.IsRunning = true;
            textBox1.Text = Status[2];
            Program.SendBlink(Program.Driver);
            Thread.Sleep(Timeout);
            textBox1.Text = Status[0];
        }
        
        // Blinking 3x button
        private void button4_Click(object sender, EventArgs e)
        {
            Program.IsRunning = true;
            textBox1.Text = Status[2];
            Program.SendBlink3(Program.Driver);
            Thread.Sleep(Timeout);
            textBox1.Text = Status[0];
        }
    }
}