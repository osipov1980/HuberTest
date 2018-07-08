//GUI design changed
//Reports button added (open reports folder)
//Huber send next temperature bug fixed (temporary, need code refactoring)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;                 //For Excel
using Excel = Microsoft.Office.Interop.Excel;   //For Excel
using System.IO;                                //for read/write txt file
using System.Diagnostics;


namespace serPort
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        string reportName;
        int sumOfProgramRunningTicks;   //for calculate the sum of all ticks (example: 2 ticks/1 second. So 60*2 = ticks need for one minute) 
        float str;
        string rate;
        int secondsToEnd;
        int flagToPrintSecondsToEnd;
        //Huber
        string huberReadWriteFlag;
        public static string temperature2Print;
        string InputDataHuber = String.Empty;
        delegate void SetTextCallbackHuber(string text);
        string checkType;
        int upperCheckLimit;
        int flagToPrintTemperatureToRealDataControl;
        int decimal_part_of_target;       //decimal part of target temperature
        int position_in_array;            //this array adding value to actual huber temperature every second
        int low_temperature_increased;    //value for increase every second or two (Depending on Rate)
        int high_temperature_decreased;   //value for increase every second or two (Depending on Rate)
        //Excel
        string excelTemplatePath;
        Excel.Workbooks excelWorkBook;
        Excel.Workbook excelSheet;
        Excel.Worksheet actualSheet;
        Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        int ROW;
        int oneMinuteCounter;    //counter for Excel input data 1(time)/1(minute)
        int twoMinuteCounter;    //counter for Excel input data 1(time)/2(minute)
        float huberValueForExcel;
        int xlxsCopiesCounter;   //this variable will be used for creating of temporary copies of Excel documents durring the check running
        int resolution2PrintExcelData;      //how many times to write data to Excel per minute
        int increasedRate;
        Mitutoyo mitutoyo_1 = new Mitutoyo();
        Mitutoyo mitutoyo_2 = new Mitutoyo();


        public MainForm()
        {
            InitializeComponent();

            HuberPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(huberPort_DataReceived);
        }

        //Start/Stop button
        private void start_stop_btn_Click(object sender, EventArgs e)
        {
            if (start_stop_btn.Text == "START")
            {
                startStopBtnStyle("STOP");          //if flag == "STOP" (show the button as "STOP")
                initializeVariables();
                //Read Settings of Com Ports from .txt file ("Settings")
                initializeComPortsName();
                huberStart();
                if (indicators_cmBox.Text == "1")
                {
                    //Read first time height from Mitutoyo
                    mitutoyo_1.startReadMitutoyo();     //automatic open port in Class
                }
                else if (indicators_cmBox.Text == "2")
                {
                    //Read first time height from Mitutoyo
                    mitutoyo_1.startReadMitutoyo();     //automatic open port in Class
                    mitutoyo_2.startReadMitutoyo();     //automatic open port in Class
                }
                updateMitutoyoLables();
                //Start reading data from Mitutoyo and Huber by timer
                openExistingExcelTemplate();
                readTimer.Start();
            }
            else
            {
                startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                readTimer.Stop();
                mitutoyo_1.closePort(1);
                huberStop();
                HuberPort.Close();
                saveCloseExcelWorkbook();
            }
        }

        //Start/Stop button view text
        private void startStopBtnStyle(string styleFlag)
        {
            //if flag == "START" (show the button as "START")          
            if (styleFlag == "START")
            {
                start_stop_btn.Text = "START";
                start_stop_btn.ForeColor = Color.Black;
                start_stop_btn.BackColor = Color.DarkTurquoise;
            }
            else
            {
                //if flag == "STOP"  (show the button as "STOP" )
                start_stop_btn.Text = "STOP";
                start_stop_btn.BackColor = Color.Red;
                start_stop_btn.ForeColor = Color.White;
            }
        }

        private void initializeVariables()
        {
            reportName = project_name_txtBox.Text;
            checkType = check_type_cmBox.Text;

            //calculate basic program running time (Only UP, Rate 1)
            int low_temperature = Int32.Parse(low_temperature_cmBox.Text);
            int high_temperature = Int32.Parse(high_temperature_cmBox.Text);

            //here is 3 variants of low and high temperature
            if (low_temperature < 0 && high_temperature > 0)
            {           //60-one minute; 2-read data two times/second
                sumOfProgramRunningTicks = (high_temperature + (low_temperature * (-1))) * 60 * 2;
            }
            else if (low_temperature >= 0 && high_temperature > 0)
            {          //60-one minute; 2-read data two times/second
                sumOfProgramRunningTicks = (high_temperature - low_temperature) * 60 * 2;
            }
            else
            {         //60-one minute; 2-read data two times/second; (-1)-remove minus
                sumOfProgramRunningTicks = ((low_temperature - high_temperature) * (-1)) * 60 * 2;
            }

            //Mitutoyo lables before BeginInvoke of Com Port
            if (indicators_cmBox.Text == "1")
            {
                mitutoyo_1_actual_value_lbl.Text = "";
            }
            else if (indicators_cmBox.Text == "2")
            {
                mitutoyo_1_actual_value_lbl.Text = "";
                mitutoyo_2_actual_value_lbl.Text = "";
            }

            //Initialize Mitutoyo Class variables
            if (indicators_cmBox.Text == "1")
            {
                mitutoyo_1.initializeVariables();
            }
            else if (indicators_cmBox.Text == "2")
            {
                mitutoyo_1.initializeVariables();
                mitutoyo_2.initializeVariables();
            }

            //Huber
            prepareDataForHuber();

            //Mitutoyo Class variable - initialize Sto ("0.1" is defined as default value)
            if (indicators_cmBox.Text == "1")
            {
                mitutoyo_1.sto = float.Parse(sto_cmBox.Text);
            }
            else if (indicators_cmBox.Text == "2")
            {
                mitutoyo_1.sto = float.Parse(sto_cmBox.Text);
                mitutoyo_2.sto = float.Parse(sto_cmBox.Text);
            }

            //initialize Str
            str = float.Parse(str_cmBox.Text);

            //initialize Sum of Program Running Ticks ("1" is defined as default value)
            if (rate_cmBox.Text == "1")
            {
                if (check_type_cmBox.Text == "Full Test")
                { sumOfProgramRunningTicks *= 2; }
                //if Only UP and Rate 1 - do nothing             
            }
            else if (rate_cmBox.Text == "2")
            {
                if (check_type_cmBox.Text == "Only UP")
                { sumOfProgramRunningTicks *= 2; }
                else
                { sumOfProgramRunningTicks = sumOfProgramRunningTicks * 2 * 2; }
            }

            //initialize rate
            rate = rate_cmBox.Text;

            //initialize sto_lbl
            sto_lbl.Text = "";
            sto_2_lbl.Text = "";

            //initialize str_lbl
            str_lbl.Text = "";
            str_2_lbl.Text = "";

            //calculate sum of seconds to end
            secondsToEnd = sumOfProgramRunningTicks / 2;

            //initialize flag for print time to left once per second
            flagToPrintSecondsToEnd = 1;

            //initialize flag for print temperature value to Real Data Control once per 10 second
            flagToPrintTemperatureToRealDataControl = 5;

            //initialize Sto captured value
            sto_height_captured_lbl.Text = "";
            sto_2_height_captured_lbl.Text = "";

            //Excel
            ROW = 1;

            //initialize counter for first input data to Excel
            oneMinuteCounter = 60;

            //initialize counter for first input data to Excel
            twoMinuteCounter = 120;

            //reset counter of Excel Real Time copies
            xlxsCopiesCounter = 1;

            //define while to print 2 times the same value of Mitutoyo because
            //the the check is turn back in "Full Test"
            if (check_type_cmBox.Text == "Full Test")
            {
                upperCheckLimit = (sumOfProgramRunningTicks / 2);
            }

            //Data resolution is optional (can be null parameter)
            //it's changed by user for more printing points to Excel
            if (data_resolution_cmBox.Text != null)
            {
                initializeDataResolution();
            }
            else
            {
                resolution2PrintExcelData = -2;  //-2 == no need
            }

            //Huber (ivisible value, for debuging use only)
            decimal_part_of_target = 0;

            //Huber
            decimal_part_of_target = 0;
            huberReadWriteFlag = "sendSetPoint";
        }

        //Timer Ticks
        private void readTimer_Tick(object sender, EventArgs e)
        {
            //Huber
            if (huberReadWriteFlag == "readActualTemperature")
            {

                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
            }
            else
            {
                if (HuberPort.IsOpen == false) HuberPort.Open();
                updateHuberTargetTemperature();
                huberReadWriteFlag = "readActualTemperature";
            }

            //check if user changed data resolution
            if (resolution2PrintExcelData == -2)
            {
                //Write data to Excel workbook
                if (rate == "1")
                {
                    rate1();
                }
                else if (rate == "2")
                {
                    rate2();
                }
            }
            else
            {
                //Write data to Excel workbook with increased intensity
                //defined by user
                writeData2ExcelWithIncreasedIntensity();
            }

            //Call function from Class - Read height from Mitutoyo
            if (indicators_cmBox.Text == "1")
            {
                mitutoyo_1.startReadMitutoyo();
            }
            else if (indicators_cmBox.Text == "2")
            {
                mitutoyo_1.startReadMitutoyo();
                mitutoyo_2.startReadMitutoyo();
            }

            //Mitutoyo update data
            updateMitutoyoLables();

            //Print seconds to end
            if (flagToPrintSecondsToEnd == 1)
            {
                flagToPrintSecondsToEnd = 0;
                printTimeToEnd();
            }
            else if (flagToPrintSecondsToEnd == 0)
            {
                flagToPrintSecondsToEnd = 1;
            }

            //Stop running condition
            if (sumOfProgramRunningTicks == 0)
            {
                hysteresis_lbl.Text = "Now STOP";
                readTimer.Stop();
                startStopBtnStyle("START");    //if flag == "START" (show the button as "START")  
                saveCloseExcelWorkbook();
                huberStop();
                HuberPort.Close();
            }

            //increment one second to counter for Excel input (need 60 for next input cycle)
            if (flagToPrintSecondsToEnd == 1)
            {
                oneMinuteCounter++;
                twoMinuteCounter++;
                increasedRate++;
            }

            sumOfProgramRunningTicks--;
        }

        //Rate 1 - Write Data to Excel
        private void rate1()
        {
            if (checkType == "Full Test")
            {
                if (oneMinuteCounter == 60)
                {
                    if (sumOfProgramRunningTicks == upperCheckLimit)    //condition for printing upper limit line in Excel 
                    {
                        writeData2Excel();
                        drawRedLimitForFullTestExcel();
                        writeData2Excel();
                        oneMinuteCounter = 0;      //reset value for next cycle
                    }
                    else
                    {
                        writeData2Excel();
                        oneMinuteCounter = 0;      //reset value for next cycle
                    }
                }
            }
            else    //if checkType == "Only UP"
            {
                if (oneMinuteCounter == 60)
                {
                    writeData2Excel();
                    oneMinuteCounter = 0;      //reset value for next cycle
                }
            }
        }

        //Rate 2 - Write Data to Excel
        private void rate2()
        {
            if (checkType == "Full Test")
            {
                if (twoMinuteCounter == 120)
                {
                    if (sumOfProgramRunningTicks == upperCheckLimit)
                    {
                        writeData2Excel();
                        drawRedLimitForFullTestExcel();
                        writeData2Excel();
                        twoMinuteCounter = 0;      //reset value for next cycle
                    }
                    else
                    {
                        writeData2Excel();
                        twoMinuteCounter = 0;      //reset value for next cycle
                    }
                }
            }
            else    //if checkType == "Only UP"  
            {
                if (twoMinuteCounter == 120)
                {
                    writeData2Excel();
                    twoMinuteCounter = 0;      //reset value for next cycle
                }
            }
        }

        //write to Excel with increased intensity resolution 
        private void writeData2ExcelWithIncreasedIntensity()
        {
            if (checkType == "Full Test")
            {
                if (increasedRate == resolution2PrintExcelData)
                {
                    if (sumOfProgramRunningTicks == upperCheckLimit)
                    {
                        writeData2Excel();
                        drawRedLimitForFullTestExcel();
                        writeData2Excel();
                        increasedRate = 0;      //reset value for next cycle
                    }
                    else
                    {
                        writeData2Excel();
                        increasedRate = 0;
                    }
                }
            }
            else if (checkType == "Only UP")
            {
                if (increasedRate == resolution2PrintExcelData)
                {
                    writeData2Excel();
                    increasedRate = 0;
                }
            }
        }

        //Timer to End
        private void printTimeToEnd()
        {
            time_to_end_lbl.Text = secondsToEnd.ToString();
            secondsToEnd--;
        }

        //Mitutoyo
        private void updateMitutoyoLables()
        {
            if (indicators_cmBox.Text == "1")
            {
                //Mitutoyo - 1
                mitutoyo_1_actual_value_lbl.Text = mitutoyo_1.mitutoyo_actual_value;

                if (mitutoyo_1.sto_lbl.Text != "")
                {
                    sto_lbl.Text = mitutoyo_1.sto_lbl.Text;
                }

                if (mitutoyo_1.sto_height_captured_lbl.Text != "")
                {
                    sto_height_captured_lbl.Text = mitutoyo_1.sto_height_captured_lbl.Text;
                }
            }
            else if (indicators_cmBox.Text == "2")
            {
                //Mitutoyo - 1
                mitutoyo_1_actual_value_lbl.Text = mitutoyo_1.mitutoyo_actual_value;

                if (mitutoyo_1.sto_lbl.Text != "")
                {
                    sto_lbl.Text = mitutoyo_1.sto_lbl.Text;
                }

                if (mitutoyo_1.sto_height_captured_lbl.Text != "")
                {
                    sto_height_captured_lbl.Text = mitutoyo_1.sto_height_captured_lbl.Text;
                }

                //Mitutoyo - 2
                mitutoyo_2_actual_value_lbl.Text = mitutoyo_2.mitutoyo_actual_value;

                if (mitutoyo_2.sto_lbl.Text != "")
                {
                    sto_2_lbl.Text = mitutoyo_2.sto_lbl.Text;
                }

                if (mitutoyo_2.sto_height_captured_lbl.Text != "")
                {
                    sto_2_height_captured_lbl.Text = mitutoyo_2.sto_height_captured_lbl.Text;
                }
            }
        }

        //Huber
        private void huberStart()
        {
            if (HuberPort.IsOpen == false) HuberPort.Open();
            if (HuberPort.BytesToWrite > 0)
            {
                HuberPort.DiscardOutBuffer();
            }

            if (HuberPort.IsOpen) HuberPort.Write("{M140001\r\n");       //Start Huber
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HuberPort.Close();
        }

        //Huber
        private void huberStop()
        {
            if (HuberPort.IsOpen == false) HuberPort.Open();
            if (HuberPort.BytesToWrite > 0)
            {
                HuberPort.DiscardOutBuffer();
            }

            if (HuberPort.IsOpen) HuberPort.Write("{M140000\r\n");       //Stop Huber
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Huber
        private void prepareDataForHuber()
        {
            low_temperature_increased = Int32.Parse(low_temperature_cmBox.Text);
            high_temperature_decreased = Int32.Parse(high_temperature_cmBox.Text);
            position_in_array = 0;
        }

        //Huber
        private void updateHuberTargetTemperature()
        {
            if (rate_cmBox.Text == "1")
            {
                if (flagToPrintSecondsToEnd == 1)
                {
                    if (checkType == "Only UP") { huberSendNextTargetTemperatureRate1Up(); }
                    else //checkType == "Full Test"
                    { }
                }

            }
            else  //rate_cmBox.Text == "2"
            {

            }
        }

        //Huber update target temperature every second 
        private void huberSendNextTargetTemperatureRate1Up()
        {
            //values for adding to actual temperature
            int[] add_to_next_target = { 1, 2, 2 };

            if (oneMinuteCounter == 60)
            {
                //add first value after increment the left side of temperature (example: 43 to 44.00) => 44.02 (first value .02 is added)
                decimal_part_of_target += 2;
            }
            else if (decimal_part_of_target >= 98)
            {
                //add last value before increment the left side of temperature (example: 43 to 44.00) => 43.98 (last value .02 is added)
                decimal_part_of_target = 0;
                low_temperature_increased++;
            }
            else
            {
                //add value from array
                decimal_part_of_target += add_to_next_target[position_in_array];
                //increase position
                if (position_in_array < 2)
                    position_in_array++;
                else
                    position_in_array = 0;
            }

            string increased_temperature;
            //some_label.Text = decimal_part_of_target.ToString();     
            if (decimal_part_of_target == 0)
            {
                increased_temperature = low_temperature_increased.ToString() + "00";  //Example: 3198 => 3200 9998 
            }
            else if (decimal_part_of_target < 10)
            {
                increased_temperature = low_temperature_increased.ToString() + "0" + decimal_part_of_target.ToString();
            }
            else
            {
                increased_temperature = low_temperature_increased.ToString() + decimal_part_of_target.ToString();
            }

            int converted_2_int_increased_temperature = Int32.Parse(increased_temperature);
            huber_dec_value_lbl.Text = converted_2_int_increased_temperature.ToString();                               /////////////////////////////////////////////////Do it not visible//////////////////////////
            increased_temperature = converted_2_int_increased_temperature.ToString("X");
            //add zeros from left if HEX number less than 4. Example: F2A, A9, BC3, 5
            //It must be 4 HEX numbers, like A2B8, 11D5
            increased_temperature = addZeros2HexNumberFromLeft(increased_temperature);
            huber_hex_value_lbl.Text = increased_temperature;                                                          /////////////////////////////////////////////////Do it not visible//////////////////////////

            //if (HuberPort.IsOpen == false) HuberPort.Open();
            if (HuberPort.BytesToRead > 0)
            {
                HuberPort.DiscardInBuffer();
                HuberPort.DiscardOutBuffer();
            }

            if (HuberPort.IsOpen) HuberPort.Write("{M00" + increased_temperature + "\r\n");       //send SetPoint temperature to Huber for next second
            else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HuberPort.Close();
        }

        //Huber add zeros from left to final sending string
        private string addZeros2HexNumberFromLeft(string increased_temperature)
        {
            while (increased_temperature.Length < 4)
            {
                increased_temperature = "0" + increased_temperature;
            }
            return increased_temperature;
        }

        //Huber
        private void huberReadTemperature()
        {
            if (HuberPort.IsOpen == false) HuberPort.Open();
            if (HuberPort.BytesToRead > 0)
            {
                HuberPort.DiscardInBuffer();
                HuberPort.DiscardOutBuffer();
            }
            huber_stop_temperature_lbl.Text = "";

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
            huber_stop_temperature_lbl.Text += value;                     //put data into lable before copy to temporary variable    
            string rawData = huber_stop_temperature_lbl.Text;             //copy text from lable for next operation
            rawData = rawData.Remove(0, 4);                        //cut first 4 symbols from left 
            int temperature = int.Parse(rawData, System.Globalization.NumberStyles.HexNumber);   //convert string that contains HEX value to Int32
            temperature2Print = temperature.ToString();     //convert integer value to string

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
            if (flagToPrintTemperatureToRealDataControl == 5)
            {
                actual_temperature_lbl.Text = "";
                actual_temperature_lbl.Text = temperature2Print;      //print temperature value to real data control
                flagToPrintTemperatureToRealDataControl = 0;          //reset the flag for next cycle
            }
            flagToPrintTemperatureToRealDataControl++;                //increment counter for moving it to 20 (20 ticks == 10 seconds)

            huberValueForExcel = float.Parse(temperature2Print);       //convert temperature to numeric for Excel

            //Str
            //check if Str Label is empty (if empty so Str is did not find yet)
            if (str_lbl.Text == "")
            {
                //check if Str is now
                //convert value of temperature2Print to float for compare with Str temperature
                if (float.Parse(temperature2Print) >= str)
                {
                    //mitutoyo height value at the Str moment
                    if (indicators_cmBox.Text == "1")
                    {
                        str_lbl.Text = mitutoyo_1.mitutoyoValueForExcel.ToString();
                    }
                    else if (indicators_cmBox.Text == "2")
                    {
                        str_lbl.Text = mitutoyo_1.mitutoyoValueForExcel.ToString();
                        str_2_lbl.Text = mitutoyo_2.mitutoyoValueForExcel.ToString();
                    }
                }
            }
        }

        //Open Excel template file
        private void openExistingExcelTemplate()
        {
            excelTemplatePath = @"C:\serPort\Test Template.xlsx";
            excelApp = new Excel.Application();
            excelApp.Visible = true;

            excelWorkBook = excelApp.Workbooks;
            excelSheet = excelWorkBook.Open(excelTemplatePath);
            actualSheet = (Excel.Worksheet)excelSheet.Worksheets.get_Item(1);
        }

        //Excel - write content to worksheet
        private void writeData2Excel()
        {
            actualSheet.Cells[ROW, 1] = huberValueForExcel;           //A1  temperature/minute
            //convert only mitutoyo value to float
            if (indicators_cmBox.Text == "1")
            {
                actualSheet.Cells[ROW, 2] = mitutoyo_1.mitutoyoValueForExcel;        //B1  mitutoyo height/minute 
            }
            else if (indicators_cmBox.Text == "2")
            {
                actualSheet.Cells[ROW, 2] = mitutoyo_1.mitutoyoValueForExcel;        //B1  mitutoyo height/minute 
                actualSheet.Cells[ROW, 7] = mitutoyo_2.mitutoyoValueForExcel;        //G1  mitutoyo-2 height/minute 
            }
            ROW++;
        }

        //Excel
        private void drawRedLimitForFullTestExcel()
        {
            actualSheet.Cells[ROW, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);        //A1  temperature/minute
            actualSheet.Cells[ROW, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);        //B1  mitutoyo height/minute   
            ROW++;
        }

        //Excel Create Actual xlxs
        private void create_actual_xlxs_btn_Click(object sender, EventArgs e)
        {
            writeFinalData2ExcelTables();

            //After write the content to the cell, next step is to save the excel file in your system
            string path = @"C:\serPort\Reports\" + reportName + "_Temporary_" + xlxsCopiesCounter + ".xlsx";
            excelSheet.SaveAs(path);
            xlxsCopiesCounter++;
        }

        //Excel save workbook
        private void saveCloseExcelWorkbook()
        {
            writeFinalData2ExcelTables();

            //After write the content to the cell, next step is to save the excel file in your system
            string path = @"C:\serPort\Reports\" + reportName + ".xlsx";
            excelSheet.SaveAs(path);
            excelSheet.Close();
            excelApp.Quit();
        }

        //Excel write final values to tables before save
        private void writeFinalData2ExcelTables()
        {
            if (indicators_cmBox.Text == "1")
            {
                //Mitutoyo-1
                //save Sto value                                                                        
                actualSheet.Cells[4, 5] = sto_lbl.Text;
                //save Rate value                                                                        
                actualSheet.Cells[5, 5] = rate;
                //save Str value                                                                         
                actualSheet.Cells[6, 5] = str_lbl.Text;
            }
            else if (indicators_cmBox.Text == "2")
            {
                //Mitutoyo-1
                //save Sto value                                                                        
                actualSheet.Cells[4, 5] = sto_lbl.Text;
                //save Rate value                                                                        
                actualSheet.Cells[5, 5] = rate;
                //save Str value                                                                         
                actualSheet.Cells[6, 5] = str_lbl.Text;

                //Mitutoyo-2
                //save Sto value                                                                        
                actualSheet.Cells[4, 10] = sto_2_lbl.Text;
                //save Rate value                                                                        
                actualSheet.Cells[5, 10] = rate;
                //save Str value                                                                         
                actualSheet.Cells[6, 10] = str_2_lbl.Text;
            }
        }

        //Initialize Com Ports Name
        private void initializeComPortsName()
        {
            if (HuberPort.IsOpen == true)
            {
                HuberPort.Close();
            }

            string path = @"C:\serPort\Settings.txt";
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

            if (indicators_cmBox.Text == "1")
            {  //Mitutoyo-1
                mitutoyo_1.initializeComPortsName("1");
            }
            else if (indicators_cmBox.Text == "2")
            {
                //Mitutoyo-1
                mitutoyo_1.initializeComPortsName("1");
                //Mitutoyo-2
                mitutoyo_2.initializeComPortsName("2");
            }
        }

        //write data to Excel resolution
        private void initializeDataResolution()
        {
            string resolution = data_resolution_cmBox.Text;

            switch (resolution)
            {
                case "1 time/min":
                    resolution2PrintExcelData = 60;   //60 seconds
                    break;
                case "2 times/min":
                    resolution2PrintExcelData = 30;   //30 seconds
                    break;
                case "3 times/min":
                    resolution2PrintExcelData = 20;   //20 seconds
                    break;
                case "4 times/min":
                    resolution2PrintExcelData = 15;   //15 seconds
                    break;
                case "5 times/min":
                    resolution2PrintExcelData = 12;   //12 seconds
                    break;
                case "6 times/min":
                    resolution2PrintExcelData = 10;   //10 seconds
                    break;
                default:
                    resolution2PrintExcelData = -2;  //Default value to sign 
                    break;
            }

            //increasedRate is dynamic (for increment), resolution2PrintExcelData is static (for compare)
            increasedRate = resolution2PrintExcelData;
        }

        //Settings button      
        private void settings_btn_Click_1(object sender, EventArgs e)
        {
            //mitutoyo_1.closePort(1);
            //HuberPort.Close();
            new Settings().Show();
        }

        private void open_reports_folder_btn_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\serPort\Reports");
        }
    }
}
