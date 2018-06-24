using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Excel = Microsoft.Office.Interop.Excel;   //For Excel
using System.IO;                                //for read/write txt file
using System.Windows.Forms;
using System.Drawing;

namespace serPort
{
    public partial class Mitutoyo
    {
        string InputData = String.Empty;           
        public string rate;
        public float sto;
        public float str;
        public string mitutoyo_1_actual_value;
        //for BeginInvoke Method in "startReadMitutoyo()"
        Form newForm = new Form();
        Label mitutoyo_1_raw_value_lbl = new Label(); 
        public Label mitutoyo_1_actual_value_lbl = new Label();
        Label sto_lbl = new Label();
        Label sto_height_captured_lbl = new Label();
        public float mitutoyoValueForExcel;
        string temperature2Print;

        SerialPort Mitutoyo1Port = new SerialPort();
        public delegate void SetTextCallback(string text);

        public Mitutoyo()
        {                  
            mitutoyo_1_raw_value_lbl.Text = "";
            newForm.Controls.Add(mitutoyo_1_raw_value_lbl);
            
            mitutoyo_1_actual_value_lbl.Text = "";
            mitutoyo_1_actual_value_lbl.Top = 25;   //20 pixels down from the previous label
            newForm.Controls.Add(mitutoyo_1_actual_value_lbl);
            
            sto_lbl.Text = "";
            sto_lbl.Top = 50;
            newForm.Controls.Add(sto_lbl);
            
            sto_height_captured_lbl.Text = "";
            sto_height_captured_lbl.Top = 70;
            newForm.Controls.Add(sto_height_captured_lbl);

            newForm.Show();
            newForm.Visible = false;

            Mitutoyo1Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
        }

        //Initialize Com Ports Name
        public void initializeComPortsName()
        {
            try
            {
                //initialize Mitutoyo1 Port             
                string path = @"C:\serPort\Settings.txt";
                string newPortName = "";               
                int line_to_edit = 2;
                string[] arrLine = File.ReadAllLines(path);
                newPortName = arrLine[line_to_edit - 1];
                newPortName = newPortName.Remove(0, 26);
                Mitutoyo1Port.PortName = newPortName;
                Mitutoyo1Port.BaudRate = 9600;
                Mitutoyo1Port.DataBits = 8;
                Mitutoyo1Port.Parity = Parity.None;
                Mitutoyo1Port.StopBits = StopBits.One;
            }
            catch (Exception ex)
            {
                //do nothing
                //Mitutoyo1Port = null;
            }
        }

        //Start Read
        public void startReadMitutoyo()
        {
            if (Mitutoyo1Port.IsOpen == false)
            {
                Mitutoyo1Port.Open();
            }
            //Clean the buffer before read data
            if (Mitutoyo1Port.BytesToRead > 0)
            {
                Mitutoyo1Port.DiscardInBuffer();
                Mitutoyo1Port.DiscardOutBuffer();
                //Mitutoyo1Port.ReadExisting();  ------>   another option by Sharon to clean the buffer
            }
            mitutoyo_1_raw_value_lbl.Text = "";
            mitutoyo_1_actual_value_lbl.Text = "";

            if (Mitutoyo1Port.IsOpen) Mitutoyo1Port.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = Mitutoyo1Port.ReadExisting();
            //refresh the rawData
            if (InputData != String.Empty)
                mitutoyo_1_raw_value_lbl.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });            
        }

        public void SetText(string value)
        {
            mitutoyo_1_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_1_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_1_actual_value_lbl.Text = rawData;   //output final data to mitutoyo_1_actual_value_lbl
            mitutoyo_1_actual_value = rawData;
            mitutoyoValueForExcel = float.Parse(rawData);

            //check if Sto Lable is empty (if empty so Sto is did not find yet)
            if (sto_lbl.Text == "")
            {
                //check if Sto is now
                float actualStoValueToCheck = float.Parse(rawData);
                if (actualStoValueToCheck >= sto)
                {
                    //temperature value at the Sto moment
                    sto_lbl.Text = temperature2Print;
                    sto_height_captured_lbl.Text = rawData;
                }
            }
        }

        //Close Port
        public void closePort(int mitutoyo_number)
        {
            switch (mitutoyo_number)
            {
                case 1:
                    Mitutoyo1Port.Close();   //Mitutoyo 1
                    break;
                case 2:
                    //Mitutoyo2Port.Close();   //Mitutoyo 2
                    break;
                default:
                    Mitutoyo1Port.Close();  //Default value close Mitutoyo 1 Com Port
                    break;
            }
        }
    }
}
