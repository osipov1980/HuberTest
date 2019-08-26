using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;           //for read/write txt file
using System.Diagnostics;  //for openeng Device Manager
using System.IO.Ports;

namespace serPort
{
    public partial class Settings : Form
    {
        //Public variables
        string path = @"C:\serPort\Settings.txt";
        string InputDataHuber = String.Empty;
        delegate void SetTextCallbackHuber(string text);
        //Mitutoyo
        SerialPort MitutoyoPort = new SerialPort();
        SerialPort MitutoyoPort2 = new SerialPort();
        SerialPort MitutoyoPort3 = new SerialPort();
        SerialPort MitutoyoPort4 = new SerialPort();
        public delegate void SetTextCallback(string text);

        public Settings()
        {
            InitializeComponent();

            HuberPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(huberPort_DataReceived);
            MitutoyoPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
            MitutoyoPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived2);
            MitutoyoPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived3);
            MitutoyoPort4.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived4);
        }

        //Close all ports when form is closed
        //private void Settings_FormClosed(object sender,FormClosedEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {


        //        HuberPort.Dispose();
        //        MitutoyoPort.Dispose();
        //        MitutoyoPort2.Dispose();
        //        MitutoyoPort3.Dispose();
        //        MitutoyoPort4.Dispose();
        //    }
        //        // Prompt user to save his data

        //    if (e.CloseReason == CloseReason.WindowsShutDown)
        //    { }
        //        // Autosave and clear up ressources           
        //}

        //Huber port update
        private void update_huber_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 1;
            string newText = "Huber(Pilot ONE) ComPort: COM" + huber_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        //Mitutoyo-1 port update
        private void update_mitutoyo1_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 2;
            string newText = "Mitutoyo1(ITN)   ComPort: COM" + mitutoyo1_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        //Mitutoyo-2 port update
        private void update_mitutoyo2_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 3;
            string newText = "Mitutoyo2(ITN)   ComPort: COM" + mitutoyo2_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        //Mitutoyo-3 port update
        private void update_mitutoyo3_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 4;
            string newText = "Mitutoyo3(ITN)   ComPort: COM" + mitutoyo3_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        //Mitutoyo-4 port update

        private void update_mitutoyo4_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 5;
            string newText = "Mitutoyo4(ITN)   ComPort: COM" + mitutoyo4_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        //Open device manager
        private void open_device_manager_btn_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        //Test Huber
        private void test_huber_device_btn_Click(object sender, EventArgs e)
        {
            initializeComPortsName();
            if (HuberPort.IsOpen == false) HuberPort.Open();
            if (HuberPort.BytesToRead > 0)
            {
                HuberPort.DiscardInBuffer();
                HuberPort.DiscardOutBuffer();
            }
            huber_actual_temperature_txtBox.Text = "";

            if (HuberPort.IsOpen) HuberPort.Write("{M01****\r\n");       //read actual temperature from Huber
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Huber
        void huberPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputDataHuber = HuberPort.ReadExisting();
            //refresh the rawData
            if (InputDataHuber != String.Empty) BeginInvoke(new SetTextCallbackHuber(SetTextHuber), new object[] { InputDataHuber });
        }

        //Huber
        private void SetTextHuber(string value)
        {
            huber_actual_temperature_txtBox.Text += value;                     //put data into lable before copy to temporary variable    
            string rawData = huber_actual_temperature_txtBox.Text;             //copy text from lable for next operation
            rawData = rawData.Remove(0, 4);                        //cut first 4 symbols from left 
            int temperature = int.Parse(rawData, System.Globalization.NumberStyles.HexNumber);   //convert string that contains HEX value to Int32
            string temperature2Print = temperature.ToString();     //convert integer value to string

            if (temperature2Print.Length > 4)  //if temperature < 0 it's return value of integer like 65516...
            {
                if (temperature2Print[0] == '1') //if temperature is more than 99C and start from "1" like 126.00C
                {
                    temperature2Print = temperature2Print.Insert(3, ".");  //add '.' like 120.08
                }
                else
                {
                    int actualTemperature = (65536 - Int32.Parse(temperature2Print)); //max integer value (65536) - actual Temperature
                    temperature2Print = actualTemperature.ToString();   //raw value of minus temperature
                    if (temperature2Print.Length == 1)
                    {
                        //add 2 digits in front, floating point and minus
                        temperature2Print = temperature2Print.Insert(0, "00");
                        temperature2Print = temperature2Print.Insert(1, ".");
                        temperature2Print = temperature2Print.Insert(0, "-");
                    }
                    else if (temperature2Print.Length == 2)
                    {
                        //add 1 digit in front, floating point and minus
                        temperature2Print = temperature2Print.Insert(0, "0");
                        temperature2Print = temperature2Print.Insert(1, ".");
                        temperature2Print = temperature2Print.Insert(0, "-");
                    }
                    else if (temperature2Print.Length == 3)
                    {
                        //add floating point and minus like "-5.65"
                        temperature2Print = temperature2Print.Insert(1, ".");
                        temperature2Print = temperature2Print.Insert(0, "-");
                    }
                    else
                    {
                        //add floating point and minus like "-15.65"
                        temperature2Print = temperature2Print.Insert(2, ".");
                        temperature2Print = temperature2Print.Insert(0, "-");
                    }
                }
            }
            else if (temperature2Print.Length == 1)
            {
                temperature2Print = temperature2Print.Insert(0, "00");  //add two '0' like 008
                temperature2Print = temperature2Print.Insert(1, ".");  //add two '.' like 0.08
            }
            else if (temperature2Print.Length == 2)
            {
                temperature2Print = temperature2Print.Insert(0, "0");  //add one '0' like 28
                temperature2Print = temperature2Print.Insert(1, ".");  //add two '.' like 0.28
            }
            else if (temperature2Print.Length == 3)
            {
                temperature2Print = temperature2Print.Insert(1, ".");  //add point to temperature value like: "2.65"
            }
            else
            {
                temperature2Print = temperature2Print.Insert(2, ".");  //add point to temperature value like: "37.65"   
            }
            //output final data to mitutoyo_1_actual_value_lbl
            huber_actual_temperature_txtBox.Text = "";
            huber_actual_temperature_txtBox.Text = temperature2Print;      //print temperature value to real data control
        }


        //Read Settings of Com Ports from .txt file ("Settings")
        private void initializeComPortsName()
        {
            string path = @"C:\serPort\Settings.txt";
            //Huber
            if (HuberPort.IsOpen == true)
            {
                HuberPort.Close();
            }
            try
            {
                string newPortName = "";

                //initialize Huber Port
                string[] arrLine = File.ReadAllLines(path);
                int line_to_edit = 1;
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                HuberPort.PortName = newPortName;
                HuberPort.BaudRate = 9600;
                HuberPort.DataBits = 8;
                HuberPort.Parity = Parity.None;
                HuberPort.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
            }
            
            //Mitutoyo1 Port
            try
            {            
                string newPortName = "";
                //position of Mitutoyo Com Ports in "Settings" file starts at line 2,
                //so if need to initialize Mitutoyo 1 => go to indicatorNum + 1 (line 2 in "settings")
                int line_to_edit = 2;
                string[] arrLine = File.ReadAllLines(path);
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                MitutoyoPort.PortName = newPortName;
                MitutoyoPort.BaudRate = 9600;
                MitutoyoPort.DataBits = 8;
                MitutoyoPort.Parity = Parity.None;
                MitutoyoPort.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
                //MitutoyoPort = null;
            }

            //initialize Mitutoyo2 Port
            try
            {
                string newPortName = "";
                //position of Mitutoyo Com Ports in "Settings" file starts at line 2,
                //so if need to initialize Mitutoyo 1 => go to indicatorNum + 1 (line 2 in "settings")
                int line_to_edit = 3;
                string[] arrLine = File.ReadAllLines(path);
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                MitutoyoPort2.PortName = newPortName;
                MitutoyoPort2.BaudRate = 9600;
                MitutoyoPort2.DataBits = 8;
                MitutoyoPort2.Parity = Parity.None;
                MitutoyoPort2.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
                //MitutoyoPort = null;
            }

            //initialize Mitutoyo3 Port
            try
            {
                string newPortName = "";
                //position of Mitutoyo Com Ports in "Settings" file starts at line 2,
                //so if need to initialize Mitutoyo 1 => go to indicatorNum + 1 (line 2 in "settings")
                int line_to_edit = 4;
                string[] arrLine = File.ReadAllLines(path);
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                MitutoyoPort3.PortName = newPortName;
                MitutoyoPort3.BaudRate = 9600;
                MitutoyoPort3.DataBits = 8;
                MitutoyoPort3.Parity = Parity.None;
                MitutoyoPort3.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
                //MitutoyoPort = null;
            }

            //initialize Mitutoyo4 Port
            try
            {
                string newPortName = "";
                //position of Mitutoyo Com Ports in "Settings" file starts at line 2,
                //so if need to initialize Mitutoyo 1 => go to indicatorNum + 1 (line 2 in "settings")
                int line_to_edit = 5;
                string[] arrLine = File.ReadAllLines(path);
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                MitutoyoPort4.PortName = newPortName;
                MitutoyoPort4.BaudRate = 9600;
                MitutoyoPort4.DataBits = 8;
                MitutoyoPort4.Parity = Parity.None;
                MitutoyoPort4.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
                //MitutoyoPort = null;
            }
        }

        //Test Mitutoyo 1 device
        private void test_mitutoyo_1_btn_Click(object sender, EventArgs e)
        {
            initializeComPortsName();
            if (MitutoyoPort.IsOpen == false)
            {
                MitutoyoPort.Open();
            }
            //Clean the buffer before read data
            if (MitutoyoPort.BytesToRead > 0)
            {
                MitutoyoPort.DiscardInBuffer();
                MitutoyoPort.DiscardOutBuffer();
                //MitutoyoPort.ReadExisting();  ------>   another option by Sharon to clean the buffer
            }
            mitutoyo_1_txtBox.Text = "";
            mitutoyo_raw_value_lbl.Text = "";

            if (MitutoyoPort.IsOpen) MitutoyoPort.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Test Mitutoyo 1 device
        string InputData = String.Empty;       
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = MitutoyoPort.ReadExisting();
            //refresh the rawData
            if (InputData != String.Empty)
                mitutoyo_1_txtBox.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
        }

        //Mitutoyo 1
        public void SetText(string value)
        {
            mitutoyo_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_1_txtBox.Text = rawData;   //output final data to mitutoyo_actual_value_lbl
        }

        //Test Mitutoyo 2 device
        private void test_mitutoyo_2_btn_Click(object sender, EventArgs e)
        {
            initializeComPortsName();
            if (MitutoyoPort2.IsOpen == false)
            {
                MitutoyoPort2.Open();
            }
            //Clean the buffer before read data
            if (MitutoyoPort2.BytesToRead > 0)
            {
                MitutoyoPort2.DiscardInBuffer();
                MitutoyoPort2.DiscardOutBuffer();
                //MitutoyoPort2.ReadExisting();  ------>   another option by Sharon to clean the buffer
            }
            mitutoyo_2_txtBox.Text = "";
            mitutoyo_raw_value_lbl.Text = "";

            if (MitutoyoPort2.IsOpen) MitutoyoPort2.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Test Mitutoyo 2 device
        string InputData2 = String.Empty;
        public void port_DataReceived2(object sender, SerialDataReceivedEventArgs e)
        {
            InputData2 = MitutoyoPort2.ReadExisting();
            //refresh the rawData
            if (InputData2 != String.Empty)
                mitutoyo_2_txtBox.BeginInvoke(new SetTextCallback(SetText2), new object[] { InputData2 });
        }

        //Mitutoyo 2
        public void SetText2(string value)
        {
            mitutoyo_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_2_txtBox.Text = rawData;   //output final data to mitutoyo_actual_value_lbl
        }

        //Test Mitutoyo 3 device
        private void test_mitutoyo_3_btn_Click(object sender, EventArgs e)
        {
            initializeComPortsName();
            if (MitutoyoPort3.IsOpen == false)
            {
                MitutoyoPort3.Open();
            }
            //Clean the buffer before read data
            if (MitutoyoPort3.BytesToRead > 0)
            {
                MitutoyoPort3.DiscardInBuffer();
                MitutoyoPort3.DiscardOutBuffer();
                //MitutoyoPort2.ReadExisting();  ------>   another option by Sharon to clean the buffer
            }
            mitutoyo_3_txtBox.Text = "";
            mitutoyo_raw_value_lbl.Text = "";

            if (MitutoyoPort3.IsOpen) MitutoyoPort3.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Test Mitutoyo 3 device
        string InputData3 = String.Empty;
        public void port_DataReceived3(object sender, SerialDataReceivedEventArgs e)
        {
            InputData3 = MitutoyoPort3.ReadExisting();
            //refresh the rawData
            if (InputData3 != String.Empty)
                mitutoyo_3_txtBox.BeginInvoke(new SetTextCallback(SetText3), new object[] { InputData3 });
        }

        //Mitutoyo 3
        public void SetText3(string value)
        {
            mitutoyo_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_3_txtBox.Text = rawData;   //output final data to mitutoyo_actual_value_lbl
        }

        //Test Mitutoyo 4 device
        private void test_mitutoyo_4_btn_Click(object sender, EventArgs e)
        {
            initializeComPortsName();
            if (MitutoyoPort4.IsOpen == false)
            {
                MitutoyoPort4.Open();
            }
            //Clean the buffer before read data
            if (MitutoyoPort4.BytesToRead > 0)
            {
                MitutoyoPort4.DiscardInBuffer();
                MitutoyoPort4.DiscardOutBuffer();
                //MitutoyoPort2.ReadExisting();  ------>   another option by Sharon to clean the buffer
            }
            mitutoyo_4_txtBox.Text = "";
            mitutoyo_raw_value_lbl.Text = "";

            if (MitutoyoPort4.IsOpen) MitutoyoPort4.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Test Mitutoyo 4 device
        string InputData4 = String.Empty;
        public void port_DataReceived4(object sender, SerialDataReceivedEventArgs e)
        {
            InputData4 = MitutoyoPort4.ReadExisting();
            //refresh the rawData
            if (InputData4 != String.Empty)
                mitutoyo_4_txtBox.BeginInvoke(new SetTextCallback(SetText4), new object[] { InputData4 });
        }

        //Mitutoyo 4
        public void SetText4(string value)
        {
            mitutoyo_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_4_txtBox.Text = rawData;   //output final data to mitutoyo_actual_value_lbl
        }

        //Keyboard
        private void keyboard_btn_Click(object sender, EventArgs e)
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            string osk = null;

            if (osk == null)
            {
                osk = Path.Combine(Path.Combine(windir, "sysnative"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = Path.Combine(Path.Combine(windir, "system32"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = "osk.exe";
            }

            Process.Start(osk);
        }

        private void HuberID_update_btn_Click(object sender, EventArgs e)
        {
            string path = @"C:\serPort\Settings.txt";
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 11;
            string newText = "Huber ID: " + huberID_textBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        private void Close_ports_btn_Click(object sender, EventArgs e)
        {
            HuberPort.Dispose();
            MitutoyoPort.Dispose();
            MitutoyoPort2.Dispose();
            MitutoyoPort3.Dispose();
            MitutoyoPort4.Dispose();
        }
    }
}

