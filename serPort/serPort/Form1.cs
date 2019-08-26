using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace serPort
{
    public partial class Form1 : Form
    {
        string InputData = String.Empty;
        SerialPort port = new SerialPort();
        delegate void SetTextCallback(string text);

        public Form1()
        {
            InitializeComponent();

            port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.PortName = "COM3";
            // try to open the selected port:
            try
            {
                port.PortName = "COM3";
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.Two;
                port.DtrEnable = true;    // Data-terminal-ready 
                port.Handshake = Handshake.None;
                port.RtsEnable = true;    // Request-to-send
                port.Open();
                rtbTerminal.AppendText("Port" + port.PortName + " is Open!");
            }

            // give a message, if the port is not available:
            catch
            {
                MessageBox.Show("Serial port " + port.PortName +
                "cannot be opened!", "RS232 tester",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = port.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }


        private void SetText(string text)
        {
            textBox1.Text += text;
        }


        private void button2_Click(object sender, EventArgs e)
        {           
            if (port.IsOpen==false)
            {
                port.PortName = "COM3";
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.Two;
                port.DtrEnable = true;    // Data-terminal-ready 
                port.Handshake = Handshake.None;
                port.RtsEnable = true;    // Request-to-send
                port.Open();
            }
            
            if (port.BytesToRead>0)
            {
                port.ReadExisting();
            }
            textBox1.Text = "";
              
            if (port.IsOpen) port.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);         
        }
    }
}
