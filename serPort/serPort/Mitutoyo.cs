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
        public float sto;                                         //initialized from Main (need refactoring)
        //public float str;
        public string mitutoyo_actual_value;
        //for BeginInvoke Method in "startReadMitutoyo()"
        Form newForm = new Form();
        Label mitutoyo_raw_value_lbl = new Label();
        public Label mitutoyo_actual_value_lbl = new Label();
        public Label sto_lbl = new Label();
        public Label sto_height_captured_lbl = new Label();
        public float mitutoyoValueForExcel;

        SerialPort MitutoyoPort = new SerialPort();
        public delegate void SetTextCallback(string text);

        //Constructor
        public Mitutoyo()
        {
            mitutoyo_raw_value_lbl.Text = "";
            newForm.Controls.Add(mitutoyo_raw_value_lbl);

            mitutoyo_actual_value_lbl.Text = "";
            mitutoyo_actual_value_lbl.Top = 25;   //20 pixels down from the previous label
            newForm.Controls.Add(mitutoyo_actual_value_lbl);

            sto_lbl.Text = "";
            sto_lbl.Top = 50;
            newForm.Controls.Add(sto_lbl);

            sto_height_captured_lbl.Text = "";
            sto_height_captured_lbl.Top = 70;
            newForm.Controls.Add(sto_height_captured_lbl);

            newForm.Show();
            newForm.Visible = false;

            MitutoyoPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
        }

        //Initialize Com Ports Name
        public void initializeComPortsName(string indicatorNum)
        {
            try
            {
                //initialize Mitutoyo1 Port             
                string path = @"C:\serPort\Settings.txt";
                string newPortName = "";
                //position of Mitutoyo Com Ports in "Settings" file starts at line 2,
                //so if need to initialize Mitutoyo 1 => go to indicatorNum + 1 (line 2 in "settings")
                int line_to_edit = (Int32.Parse(indicatorNum) + 1);
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
        }

        //Initialize variables (called from Main)
        public void initializeVariables()
        {
            mitutoyo_raw_value_lbl.Text = "";
            mitutoyo_actual_value_lbl.Text = "";
            sto_lbl.Text = "";
            sto_height_captured_lbl.Text = "";
            mitutoyo_actual_value = "";
            mitutoyoValueForExcel = 0.0f;
        }

        //Start Read
        public void startReadMitutoyo()
        {
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
            mitutoyo_raw_value_lbl.Text = "";
            mitutoyo_actual_value_lbl.Text = "";

            if (MitutoyoPort.IsOpen) MitutoyoPort.WriteLine("1\r\n");
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = MitutoyoPort.ReadExisting();
            //refresh the rawData
            if (InputData != String.Empty)
                mitutoyo_raw_value_lbl.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
        }

        public void SetText(string value)
        {
            mitutoyo_raw_value_lbl.Text += value;       //put data into lable before copy to temporary variable
            string rawData = mitutoyo_raw_value_lbl.Text;
            rawData = rawData.Remove(0, 3);               //first cut 3 symbols from left
            rawData = rawData.Remove(1, 3);               //second cut symbols     
            mitutoyo_actual_value_lbl.Text = rawData;   //output final data to mitutoyo_actual_value_lbl
            mitutoyo_actual_value = rawData;
            mitutoyoValueForExcel = float.Parse(rawData);

            //check if Sto Lable is empty (if empty so Sto is did not find yet)
            if (sto_lbl.Text == "")
            {
                //check if Sto is now
                float actualStoValueToCheck = float.Parse(rawData);
                if (actualStoValueToCheck >= sto)
                {
                    //temperature value at the Sto moment
                    sto_lbl.Text = MainForm.temperature2Print;
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
                    MitutoyoPort.Close();   //Mitutoyo 1
                    break;
                case 2:
                    //Mitutoyo2Port.Close();   //Mitutoyo 2
                    break;
                default:
                    MitutoyoPort.Close();  //Default value close Mitutoyo 1 Com Port
                    break;
            }
        }
    }
}
