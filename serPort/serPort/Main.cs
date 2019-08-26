//Octopus Version  0.0.1 by Igor Osipov
//osipov180@gmail.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using Excel = Microsoft.Office.Interop.Excel;   //For Excel
using System.IO;                                //for read/write txt file
using System.Diagnostics;                       //for open reports folder
using Outlook = Microsoft.Office.Interop.Outlook;


namespace serPort
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        int sumOfProgramRunningTicks;   //for calculate the sum of all ticks (example: 2 ticks/1 second. So 60*2 = ticks need for one minute) 
        decimal str;
        decimal strMax;
        string rate;
        int secondsToEnd;
        int flagToPrintSecondsToEnd;
        int timerTick;
        //Huber
        string huberReadWriteFlag;
        public static string temperature2Print;
        string InputDataHuber = String.Empty;
        delegate void SetTextCallbackHuber(string text);
        string checkType;
        int upperCheckLimit;
        int flagToPrintTemperatureToRealDataControl;
        int position_in_array;   //this array adding value to actual huber temperature every second
        //Excel
        string excelTemplatePath;
        Excel.Workbooks excelWorkBook;
        Excel.Workbook excelSheet;
        Excel.Worksheet actualSheet;
        Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        int ROW;
        int oneMinuteCounter;    //counter for Excel input data 1(time)/1(minute)
        float huberValueForExcel;
        int xlxsCopiesCounter;   //will be used for creating of temporary copies of Excel documents durring the check running
        //Chart
        Chart chart_1 = new Chart();
        Chart chart_2 = new Chart();
        Chart chart_3 = new Chart();
        Chart chart_4 = new Chart();
        WaitToEnd theEndwindow = new WaitToEnd();
        TimeSpan time;          //for converting seconds to end to time {H:M:S}
        //for BigData file
        String startTime;
        String stopTime;


        public MainForm()
        {
            InitializeComponent();

            HuberPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(huberPort_DataReceived);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            form_1_checkBox.Checked = false;
            form_2_checkBox.Checked = false;
            form_3_checkBox.Checked = false;
            form_4_checkBox.Checked = false;
        }

        //Start/Stop button
        private void start_stop_btn_Click(object sender, EventArgs e)
        {
            if (start_stop_btn.Text == "START")
            {
                startStopBtnStyle("STOP");          //if flag == "STOP" (show the button as "STOP")
                initializeVariables();
                initializeComPortsName();
                huberStart();
                updateMitutoyoLables();
                openExistingExcelTemplate();
                resetCharts();
                //Select Timer for reading data from Mitutoyo and Huber by timer
                selectTimerAndStartStop("START");
            }
            else
            {
                startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                selectTimerAndStartStop("STOP");
                //view waiting message window  
                theEndwindow.Show();
                HuberPort.Close();
                closePorts();
                string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                saveCloseExcelWorkbook();
                saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                saveCharts(getReportName());
                //view message that test finished
                theEndwindow.endMessage();
                goToNewStartTemperature();
                theEndwindow.Hide();
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

        public static int low_temperature;
        public static int high_temperature;
        private void initializeVariables()
        {
            checkType = check_type_cmBox.Text;

            //calculate basic program running time (Only UP, Rate 1)
            low_temperature = Int32.Parse(low_temperature_cmBox.Text);
            high_temperature = Int32.Parse(high_temperature_cmBox.Text);

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

            //Set huber low temperature
            huber_dec_value_lbl.Text = low_temperature_cmBox.Text + "00";

            //Convert actual temperature to integer without floating point (example 32.05 = 3205)
            actualTemperature = Int32.Parse(low_temperature_cmBox.Text + "00");

            //Huber - position in array of increment
            position_in_array = 0;

            //initialize Str
            //was: str = Convert.ToDecimal(str_cmBox.Text);
            str = decimal.Parse(str_cmBox.Text);

            //initialize strMax
            strMax = Convert.ToDecimal(str_max_cmBox.Text);

            //initialize Sum of Program Running Ticks ("1" is defined as default value)
            if (rate_cmBox.Text == "1")
            {
                //if Only UP and Rate 1 - do nothing 
                if (check_type_cmBox.Text == "Full Test")
                { sumOfProgramRunningTicks *= 2; }                  
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

            //Mitutoyo lables before BeginInvoke of Com Port
            mitutoyo_1_actual_value_lbl.Text = "";
            mitutoyo_2_actual_value_lbl.Text = "";
            mitutoyo_3_actual_value_lbl.Text = "";
            mitutoyo_4_actual_value_lbl.Text = "";

            //initialize sto_lbl
            sto_lbl.Text = "";
            sto_2_lbl.Text = "";
            sto_3_lbl.Text = "";
            sto_4_lbl.Text = "";

            //initialize str_lbl
            str_lbl.Text = "";
            str_2_lbl.Text = "";
            str_3_lbl.Text = "";
            str_4_lbl.Text = "";
            
            //initialize str_max_lbl
            str_max_lbl.Text = "";
            str_max_2_lbl.Text = "";
            str_max_3_lbl.Text = "";
            str_max_4_lbl.Text = "";
           
            //initialize hysteresis_lbl
            hysteresis_lbl.Text = "";
            hysteresis_2_lbl.Text = "";
            hysteresis_3_lbl.Text = "";
            hysteresis_4_lbl.Text = "";
           
            //initialize Sto captured value
            sto_height_captured_lbl.Text = "";
            sto_2_height_captured_lbl.Text = "";
            sto_3_height_captured_lbl.Text = "";
            sto_4_height_captured_lbl.Text = "";
            
            //calculate sum of seconds to end
            secondsToEnd = sumOfProgramRunningTicks / 2;

            //initialize flag for print "Time To Left" once per second
            flagToPrintSecondsToEnd = 1;

            //initialize flag for print temperature value to Real Data Control once per 10 second
            flagToPrintTemperatureToRealDataControl = 5;
            
            //Excel
            ROW = 1;

            //initialize counter for first input data to Excel
            oneMinuteCounter = 60;

            //reset counter of Excel Real Time copies
            xlxsCopiesCounter = 1;

            //print 2 times the same value of Mitutoyo on
            //upper limit in "Full Test"
            if (check_type_cmBox.Text == "Full Test")
            {
                upperCheckLimit = (sumOfProgramRunningTicks / 2);
            }

            //Huber
            huberReadWriteFlag = "sendSetPoint";

            timerTick = 1;
            //Chart Variables
            initializeChartsVariables();

            //Huber Rate 2
            sendNextSetPointFlag = true;

            //Data for BigData File (Galit)
            startTime = DateTime.Now.ToString("h:mm:ss");
        }

        //Timer selection
        private void selectTimerAndStartStop( string flag )
        {
            if ( check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "1")
            {
                if (flag == "START") OnlyUpR1M1.Start();
                else OnlyUpR1M1.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "2")
            {
                if (flag == "START") OnlyUpR1M2.Start();
                else OnlyUpR1M2.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "3")
            {
                if (flag == "START") OnlyUpR1M3.Start();
                else OnlyUpR1M3.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "4")
            {
                if (flag == "START") OnlyUpR1M4.Start();
                else OnlyUpR1M4.Stop();
            }
            //Rate 2 Only Up using same tamer as Rate 2 Only Up 
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "1")
            {
                if (flag == "START") OnlyUpR1M1.Start();
                else OnlyUpR1M1.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "2")
            {
                if (flag == "START") OnlyUpR1M2.Start();
                else OnlyUpR1M2.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "3")
            {
                if (flag == "START") OnlyUpR1M3.Start();
                else OnlyUpR1M3.Stop();
            }
            else if (check_type_cmBox.Text == "Only UP" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "4")
            {
                if (flag == "START") OnlyUpR1M4.Start();
                else OnlyUpR1M4.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "1")
            {
                if (flag == "START") FullTestR1M1.Start();
                else FullTestR1M1.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "2")
            {
                if (flag == "START") FullTestR1M2.Start();
                else FullTestR1M2.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "3")
            {
                if (flag == "START") FullTestR1M3.Start();
                else FullTestR1M3.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "1" && indicators_cmBox.Text == "4")
            {
                if (flag == "START") FullTestR1M4.Start();
                else FullTestR1M4.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "1")
            {
                if (flag == "START") FullTestR1M1.Start();
                else FullTestR1M1.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "2")
            {
                if (flag == "START") FullTestR1M2.Start();
                else FullTestR1M2.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "3")
            {
                if (flag == "START") FullTestR1M3.Start();
                else FullTestR1M3.Stop();
            }
            else if (check_type_cmBox.Text == "Full Test" && rate_cmBox.Text == "2" && indicators_cmBox.Text == "4")
            {
                if (flag == "START") FullTestR1M4.Start();
                else FullTestR1M4.Stop();
            }
        }

        //Timer OnlyUpR1M1
        private void OnlyUpR1M1_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsUp();

                if (oneMinuteCounter == 60)
                {
                    rate1OnlyUpM1();
                }   

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM1();

                //Str
                checkStrM1();

                //Str Max
                checkStrMaxM1();

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    OnlyUpR1M1.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer OnlyUpR1M2
        private void OnlyUpR1M2_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsUp();

                if (oneMinuteCounter == 60)
                {
                    rate1OnlyUpM2();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM2();

                //Str
                checkStrM2();

                //Str Max
                checkStrMaxM2();

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    OnlyUpR1M2.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }


        //Timer OnlyUpR1M3
        private void OnlyUpR1M3_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsUp();

                if (oneMinuteCounter == 60)
                {
                    rate1OnlyUpM3();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();
                chart_3.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM3();

                //Str
                checkStrM3();

                //Str Max
                checkStrMaxM3();

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    OnlyUpR1M3.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer OnlyUpR1M4
        private void OnlyUpR1M4_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsUp();

                if (oneMinuteCounter == 60)
                {
                    rate1OnlyUpM4();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();
                chart_3.startReadMitutoyo();
                chart_4.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM4();

                //Str
                checkStrM4();

                //Str Max
                checkStrMaxM4();

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    OnlyUpR1M4.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer FullTestR1M1
        private void FullTestR1M1_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsFull();

                if (oneMinuteCounter == 60)
                {
                    rate1FullTestM1();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM1();

                //Str
                checkStrM1();

                //Str Max
                checkStrMaxM1();

                //Check Hysteresis
                chart_1.checkHysteresis(temperature2Print);

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    FullTestR1M1.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer FullTestR1M2
        private void FullTestR1M2_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsFull();

                if (oneMinuteCounter == 60)
                {
                    rate1FullTestM2();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM2();

                //Str
                checkStrM2();

                //Str Max
                checkStrMaxM2();

                //Check Hysteresis
                chart_1.checkHysteresis(temperature2Print);
                chart_2.checkHysteresis(temperature2Print);

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    FullTestR1M2.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer FullTestR1M3
        private void FullTestR1M3_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsFull();

                if (oneMinuteCounter == 60)
                {
                    rate1FullTestM3();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();
                chart_3.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM3();

                //Str
                checkStrM3();

                //Str Max
                checkStrMaxM3();

                //Check Hysteresis
                chart_1.checkHysteresis(temperature2Print);
                chart_2.checkHysteresis(temperature2Print);
                chart_3.checkHysteresis(temperature2Print);

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    FullTestR1M3.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Timer FullTestR1M4
        private void FullTestR1M4_Tick(object sender, EventArgs e)
        {
            //Run the next Cycle & read actual temperature
            if (timerTick == 0)
            {
                timerTickDefaultOperationsFull();

                if (oneMinuteCounter == 60)
                {
                    rate1FullTestM4();
                }

                //Read height from Mitutoyo (Call function from Class) 
                chart_1.startReadMitutoyo();
                chart_2.startReadMitutoyo();
                chart_3.startReadMitutoyo();
                chart_4.startReadMitutoyo();

                //Mitutoyo update data
                updateMitutoyoLablesM4();

                //Str
                checkStrM4();

                //Str Max
                checkStrMaxM4();

                //Check Hysteresis
                chart_1.checkHysteresis(temperature2Print);
                chart_2.checkHysteresis(temperature2Print);
                chart_3.checkHysteresis(temperature2Print);
                chart_4.checkHysteresis(temperature2Print);

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
                    startStopBtnStyle("START");          //if flag == "START" (show the button as "START")               
                    FullTestR1M4.Stop();
                    //view waiting message window    
                    WaitToEnd theEndwindow = new WaitToEnd();
                    theEndwindow.Show();
                    HuberPort.Close();
                    closePorts();
                    //First readed Huber temperature (for BigData file)
                    string firstTemperatureValue = ((Excel.Range)actualSheet.Cells[1, 1]).Value2.ToString();
                    saveCloseExcelWorkbook();
                    saveCloseStatisticsExcelWorkbook(firstTemperatureValue);
                    saveCharts(getReportName());
                    //view message that test finished
                    theEndwindow.endMessage();
                    goToNewStartTemperature();
                    theEndwindow.Hide();
                }

                //increment one second to counter for Excel input (need 60 for next input cycle)
                if (flagToPrintSecondsToEnd == 1)
                {
                    oneMinuteCounter++;
                }
                sumOfProgramRunningTicks--;
            }
            else if (timerTick == 1)
            {
                //Do Nothing, because I can't Start Huber & Read Actual Temperature in same tick
                timerTick++;
            }
            else if (timerTick == 2)  //In second Tick I read te Actual Temperature before start running and Initialize charts
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
                showCharts();
                indicatorsFirstRead();
                timerTick = 0;          //Now start running the program
            }

            //Rule for checkBoxes of view/hide charts
            checkBoxesRule();
        }

        //Default Operations for Timer Tick OnlyUp
        private void timerTickDefaultOperationsUp()
        {
            //Huber read actual temperature
            if (huberReadWriteFlag == "readActualTemperature")
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
            }
            else  //Huber send set point
            {
                if (HuberPort.IsOpen == false) HuberPort.Open();
                updateHuberTargetTemperatureUp();
                huberReadWriteFlag = "readActualTemperature";
            }
        }

        //Default Operations for Timer Tick FullTest
        private void timerTickDefaultOperationsFull()
        {
            //Huber read actual temperature
            if (huberReadWriteFlag == "readActualTemperature")
            {
                huberReadTemperature();
                huberReadWriteFlag = "sendSetPoint";
            }
            else  //Huber send set point
            {
                if (HuberPort.IsOpen == false) HuberPort.Open();
                updateHuberTargetTemperatureFull();
                huberReadWriteFlag = "readActualTemperature";
            }
        }

        //Rate1 OnlyUp (X1) - Write Data to Excel
        private void rate1OnlyUpM1()
        {
            writeData2ExcelM1();
            updateChartUpR1M1();
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 OnlyUp (X2) - Write Data to Excel
        private void rate1OnlyUpM2()
        {
            writeData2ExcelM2();
            updateChartUpR1M2();
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 OnlyUp (X3) - Write Data to Excel
        private void rate1OnlyUpM3()
        {
            writeData2ExcelM3();
            updateChartUpR1M3();
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 OnlyUp (X4) - Write Data to Excel
        private void rate1OnlyUpM4()
        {
            writeData2ExcelM4();
            updateChartUpR1M4();
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 FullTest (X1) - Write Data to Excel
        private void rate1FullTestM1()
        {
            //Chart go UP
            if (sumOfProgramRunningTicks > upperCheckLimit)
            {
                writeData2ExcelM1();
                updateChartUpR1M1();
            }//Chart go DOWN
            else if (sumOfProgramRunningTicks < upperCheckLimit)
            {
                writeData2ExcelM1();
                updateChartDownR1M1();
            }
            else //if (sumOfProgramRunningTicks == upperCheckLimit)    //condition for printing Upper Limit line in Excel 
            {
                //upperLimit
                writeData2ExcelM1();
                ROW++;
                writeData2ExcelM1();
                //updateChart("upper limit");
                chart_1.updateUpChart(temperature2Print);
                chart_1.updateDownChart(temperature2Print);
       
                //Mitutoyo-1
                chart_1.hysteresisFlag = "DOWN";
            }
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 FullTest (X2) - Write Data to Excel
        private void rate1FullTestM2()
        {
            //Chart go UP
            if (sumOfProgramRunningTicks > upperCheckLimit)
            {
                writeData2ExcelM2();
                updateChartUpR1M2();
            }//Chart go DOWN
            else if (sumOfProgramRunningTicks < upperCheckLimit)
            {
                writeData2ExcelM2();
                updateChartDownR1M2();
            }
            else //if (sumOfProgramRunningTicks == upperCheckLimit)    //condition for printing Upper Limit line in Excel 
            {
                //upperLimit
                writeData2ExcelM2();
                ROW++;
                writeData2ExcelM2();

                //updateChart("upper limit");
                chart_1.updateUpChart(temperature2Print);
                chart_2.updateUpChart(temperature2Print);
                chart_1.updateDownChart(temperature2Print);
                chart_2.updateDownChart(temperature2Print);
                
                //Mitutoyo-1,2
                chart_1.hysteresisFlag = "DOWN";
                chart_2.hysteresisFlag = "DOWN";
                
            }
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 FullTest (X3) - Write Data to Excel
        private void rate1FullTestM3()
        {
            //Chart go UP
            if (sumOfProgramRunningTicks > upperCheckLimit)
            {
                writeData2ExcelM3();
                updateChartUpR1M3();
            }//Chart go DOWN
            else if (sumOfProgramRunningTicks < upperCheckLimit)
            {
                writeData2ExcelM3();
                updateChartDownR1M3();
            }
            else //if (sumOfProgramRunningTicks == upperCheckLimit)    //condition for printing Upper Limit line in Excel 
            {
                //upperLimit
                writeData2ExcelM3();
                ROW++;
                writeData2ExcelM3();
                //updateChart("upper limit");
                chart_1.updateUpChart(temperature2Print);
                chart_2.updateUpChart(temperature2Print);
                chart_3.updateUpChart(temperature2Print);
                chart_1.updateDownChart(temperature2Print);
                chart_2.updateDownChart(temperature2Print);
                chart_3.updateDownChart(temperature2Print);
                
                //Mitutoyo-1,2,3
                chart_1.hysteresisFlag = "DOWN";
                chart_2.hysteresisFlag = "DOWN";
                chart_3.hysteresisFlag = "DOWN";
            }
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Rate1 FullTest (X4) - Write Data to Excel
        private void rate1FullTestM4()
        {
            //Chart go UP
            if (sumOfProgramRunningTicks > upperCheckLimit)
            {
                writeData2ExcelM4();
                updateChartUpR1M4();
            }//Chart go DOWN
            else if (sumOfProgramRunningTicks < upperCheckLimit)
            {
                writeData2ExcelM4();
                updateChartDownR1M4();
            }
            else //if (sumOfProgramRunningTicks == upperCheckLimit)    //condition for printing Upper Limit line in Excel 
            {
                //upperLimit
                writeData2ExcelM4();
                ROW++;
                writeData2ExcelM4();
                //updateChart("upper limit");
                chart_1.updateUpChart(temperature2Print);
                chart_1.updateDownChart(temperature2Print);

                chart_2.updateUpChart(temperature2Print);
                chart_2.updateDownChart(temperature2Print);
                
                chart_3.updateUpChart(temperature2Print);
                chart_3.updateDownChart(temperature2Print);

                chart_4.updateUpChart(temperature2Print);
                chart_4.updateDownChart(temperature2Print);
                
                //Mitutoyo-1,2,3,4
                chart_1.hysteresisFlag = "DOWN";
                chart_2.hysteresisFlag = "DOWN";
                chart_3.hysteresisFlag = "DOWN";
                chart_4.hysteresisFlag = "DOWN";
            }
            oneMinuteCounter = 0;      //reset value for next cycle
        }

        //Charts Up (x1)
        private void updateChartUpR1M1()
        {
            chart_1.updateUpChart(temperature2Print);
        }

        //Charts Up (x2)
        private void updateChartUpR1M2()
        {
            chart_1.updateUpChart(temperature2Print);
            chart_2.updateUpChart(temperature2Print);
        }

        //Charts Up (x3)
        private void updateChartUpR1M3()
        {
            chart_1.updateUpChart(temperature2Print);
            chart_2.updateUpChart(temperature2Print);
            chart_3.updateUpChart(temperature2Print);
        }

        //Charts Up (x4)
        private void updateChartUpR1M4()
        {
            chart_1.updateUpChart(temperature2Print);
            chart_2.updateUpChart(temperature2Print);
            chart_3.updateUpChart(temperature2Print);
            chart_4.updateUpChart(temperature2Print);
        }

        //Charts Down (x1)
        private void updateChartDownR1M1()
        {
            chart_1.updateDownChart(temperature2Print);
        }

        //Charts Down (x2)
        private void updateChartDownR1M2()
        {
            chart_1.updateDownChart(temperature2Print);
            chart_2.updateDownChart(temperature2Print);
        }

        //Charts Down (x3)
        private void updateChartDownR1M3()
        {
            chart_1.updateDownChart(temperature2Print);
            chart_2.updateDownChart(temperature2Print);
            chart_3.updateDownChart(temperature2Print);
        }

        //Charts Down (x4)
        private void updateChartDownR1M4()
        {
            chart_1.updateDownChart(temperature2Print);
            chart_2.updateDownChart(temperature2Print);
            chart_3.updateDownChart(temperature2Print);
            chart_4.updateDownChart(temperature2Print);
        }

        //Timer to End
        private void printTimeToEnd()
        {
            time = TimeSpan.FromSeconds(secondsToEnd);

            //here backslash is must to tell that colon is
            //not the part of format, it just a character that we want in output
            time_to_end_lbl.Text = time.ToString(@"hh\:mm\:ss");

            //time_to_end_lbl.Text = secondsToEnd.ToString();
            secondsToEnd--;
        }

        //Mitutoyo Update Mtutoyo Lables
        private void updateMitutoyoLables()
        {
            switch (indicators_cmBox.Text)
            {
                case "1":
                    updateMitutoyoLablesM1();
                    break;
                case "2":
                    updateMitutoyoLablesM2();
                    break;
                case "3":
                    updateMitutoyoLablesM3();
                    break;
                case "4":
                    updateMitutoyoLablesM4();
                    break;
                default:
                    updateMitutoyoLablesM1();
                    break;
            }
        }

        //Mitutoyo 1 Indicator
        private void updateMitutoyoLablesM1()
        {
            //Mitutoyo - 1
            mitutoyo_1_actual_value_lbl.Text = chart_1.mitutoyo_actual_value;

            if (chart_1.sto_lbl.Text != "")
            {
                sto_lbl.Text = chart_1.sto_lbl.Text;
                sto_height_captured_lbl.Text = chart_1.sto_height_captured_lbl.Text;
            }

            //Hysteresis
            hysteresis_lbl.Text = chart_1.getHysteresisValue();
        }

        //Mitutoyo 2 Indicators
        private void updateMitutoyoLablesM2()
        {
            //Mitutoyo - 1
            mitutoyo_1_actual_value_lbl.Text = chart_1.mitutoyo_actual_value;

            if (chart_1.sto_lbl.Text != "")
            {
                sto_lbl.Text = chart_1.sto_lbl.Text;
                sto_height_captured_lbl.Text = chart_1.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 2
            mitutoyo_2_actual_value_lbl.Text = chart_2.mitutoyo_actual_value;

            if (chart_2.sto_lbl.Text != "")
            {
                sto_2_lbl.Text = chart_2.sto_lbl.Text;
                sto_2_height_captured_lbl.Text = chart_2.sto_height_captured_lbl.Text;
            }

            //Hysteresis
            hysteresis_lbl.Text = chart_1.getHysteresisValue();
            hysteresis_2_lbl.Text = chart_2.getHysteresisValue();   
        }

        //Mitutoyo 3 Indicators
        private void updateMitutoyoLablesM3()
        {
            //Mitutoyo - 1
            mitutoyo_1_actual_value_lbl.Text = chart_1.mitutoyo_actual_value;

            if (chart_1.sto_lbl.Text != "")
            {
                sto_lbl.Text = chart_1.sto_lbl.Text;
                sto_height_captured_lbl.Text = chart_1.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 2
            mitutoyo_2_actual_value_lbl.Text = chart_2.mitutoyo_actual_value;

            if (chart_2.sto_lbl.Text != "")
            {
                sto_2_lbl.Text = chart_2.sto_lbl.Text;
                sto_2_height_captured_lbl.Text = chart_2.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 3
            mitutoyo_3_actual_value_lbl.Text = chart_3.mitutoyo_actual_value;

            if (chart_3.sto_lbl.Text != "")
            {
                sto_3_lbl.Text = chart_3.sto_lbl.Text;
                sto_3_height_captured_lbl.Text = chart_3.sto_height_captured_lbl.Text;
            }

            //Hysteresis
            hysteresis_lbl.Text = chart_1.getHysteresisValue();
            hysteresis_2_lbl.Text = chart_2.getHysteresisValue();
            hysteresis_3_lbl.Text = chart_3.getHysteresisValue();
        }

        //Mitutoyo 4 Indicators
        private void updateMitutoyoLablesM4()
        {
            //Mitutoyo - 1
            mitutoyo_1_actual_value_lbl.Text = chart_1.mitutoyo_actual_value;

            if (chart_1.sto_lbl.Text != "")
            {
                sto_lbl.Text = chart_1.sto_lbl.Text;
                sto_height_captured_lbl.Text = chart_1.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 2
            mitutoyo_2_actual_value_lbl.Text = chart_2.mitutoyo_actual_value;

            if (chart_2.sto_lbl.Text != "")
            {
                sto_2_lbl.Text = chart_2.sto_lbl.Text;
                sto_2_height_captured_lbl.Text = chart_2.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 3
            mitutoyo_3_actual_value_lbl.Text = chart_3.mitutoyo_actual_value;

            if (chart_3.sto_lbl.Text != "")
            {
                sto_3_lbl.Text = chart_3.sto_lbl.Text;
                sto_3_height_captured_lbl.Text = chart_3.sto_height_captured_lbl.Text;
            }

            //Mitutoyo - 4
            mitutoyo_4_actual_value_lbl.Text = chart_4.mitutoyo_actual_value;

            if (chart_4.sto_lbl.Text != "")
            {
                sto_4_lbl.Text = chart_4.sto_lbl.Text;
                sto_4_height_captured_lbl.Text = chart_4.sto_height_captured_lbl.Text;
            }

            //Hysteresis
            hysteresis_lbl.Text = chart_1.getHysteresisValue();
            hysteresis_2_lbl.Text = chart_2.getHysteresisValue();
            hysteresis_3_lbl.Text = chart_3.getHysteresisValue();
            hysteresis_4_lbl.Text = chart_4.getHysteresisValue();
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
        bool sendNextSetPointFlag; //for Rate 2

        //Huber OnlyUp
        private void updateHuberTargetTemperatureUp()
        {
            if (rate_cmBox.Text == "1")
            {
                if (flagToPrintSecondsToEnd == 1)
                {
                    huberSendNextTargetTemperatureRate1Up();
                }
            }
            else  //rate_cmBox.Text == "2"
            {           
                if (flagToPrintSecondsToEnd == 1)
                {
                    if (sendNextSetPointFlag == true)
                    {
                        huberSendNextTargetTemperatureRate1Up();
                        sendNextSetPointFlag = false;
                    }
                    else
                    { sendNextSetPointFlag = true; }
                }
            }
        }

        //Huber Full Test
        private void updateHuberTargetTemperatureFull()
        {
            if (rate_cmBox.Text == "1")
            {
                if (flagToPrintSecondsToEnd == 1)
                {                 
                    if (sumOfProgramRunningTicks > upperCheckLimit)  //sumOfProgramRunningTicks decrement every tick
                    {
                        huberSendNextTargetTemperatureRate1Up();
                    }
                    else if (sumOfProgramRunningTicks <= upperCheckLimit)  //sumOfProgramRunningTicks decrement every tick
                    {
                        huberSendNextTargetTemperatureRate1Down();
                    }
                }
            }
            else  //rate_cmBox.Text == "2"
            {
                if (flagToPrintSecondsToEnd == 1)
                {
                    if (sumOfProgramRunningTicks > upperCheckLimit)  //sumOfProgramRunningTicks decrement every tick
                    {
                        if (sendNextSetPointFlag == true)
                        {
                            huberSendNextTargetTemperatureRate1Up();
                            sendNextSetPointFlag = false;
                        }
                        else
                        { sendNextSetPointFlag = true; }
                    }
                    else if (sumOfProgramRunningTicks <= upperCheckLimit)  //sumOfProgramRunningTicks decrement every tick
                    {
                        if (sendNextSetPointFlag == true)
                        {
                            huberSendNextTargetTemperatureRate1Down();
                            sendNextSetPointFlag = false;
                        }
                        else
                        { sendNextSetPointFlag = true; }
                    }
                }
            }
        }

        //Huber update target temperature every second 
        int actualTemperature;
        private void huberSendNextTargetTemperatureRate1Up()
        {
            //values for adding to actual temperature
            int[] add_to_next_target = { 1, 2, 2 };

            actualTemperature = Int32.Parse(huber_dec_value_lbl.Text);

            //Increment actual temperature
            actualTemperature += add_to_next_target[position_in_array];
            if (position_in_array < 2)
                position_in_array++;
            else
                position_in_array = 0;

            string increased_temperature;
            //add zeros from left if HEX number less than 4. Example: F2A, A9, BC3, 5
            //It must be 4 HEX numbers, like A2B8, 11D5
            increased_temperature = addZeros2HexNumberFromLeft(actualTemperature.ToString("X"));
            huber_hex_value_lbl.Text = increased_temperature;                                                          /////////////////////////////////////////////////Do it not visible//////////////////////////
            huber_dec_value_lbl.Text = actualTemperature.ToString();

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

       
        //Huber update target temperature every second 
        private void huberSendNextTargetTemperatureRate1Down()
        {
            //values for adding to actual temperature
            int[] sub_from_next_target = { 1, 2, 2 };
            
            actualTemperature = Int32.Parse(huber_dec_value_lbl.Text);

            //sub first value after increment the left side of temperature(example: 43 to 44.00) => 44.02(first value .02 is added)
            actualTemperature -= sub_from_next_target[position_in_array];
            if (position_in_array < 2)
                position_in_array++;
            else
                position_in_array = 0;

            string increased_temperature;
            //add zeros from left if HEX number less than 4. Example: F2A, A9, BC3, 5
            //It must be 4 HEX numbers, like A2B8, 11D5
            increased_temperature = addZeros2HexNumberFromLeft(actualTemperature.ToString("X"));
            huber_hex_value_lbl.Text = increased_temperature;                                                          /////////////////////////////////////////////////Do it not visible//////////////////////////
            huber_dec_value_lbl.Text = actualTemperature.ToString();

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
        }

        //Huber
        private String getHuberID()
        {
            string path = @"C:\serPort\Settings.txt";
            string huberID = "";

            //initialize Huber Port
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 11;
            huberID = arrLine[line_to_edit - 1];
            huberID = huberID.Remove(0, 10);
            return huberID;
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

        //Excel - write content to worksheet 1 Indicator
        private void writeData2ExcelM1()
        {
            actualSheet.Cells[ROW, 1] = huberValueForExcel;           //A1  temperature/minute
            //convert only mitutoyo value to float
            actualSheet.Cells[ROW, 2] = chart_1.getMitutoyoValueForExcel();        //B1  mitutoyo height/minute 
            ROW++;
        }

        //Excel - write content to worksheet 2 Indicators
        private void writeData2ExcelM2()
        {
            actualSheet.Cells[ROW, 1] = huberValueForExcel;           //A1  temperature/minute
            //convert only mitutoyo value to float
            actualSheet.Cells[ROW, 2] = chart_1.getMitutoyoValueForExcel();        //B1  mitutoyo height/minute 
            actualSheet.Cells[ROW, 4] = chart_2.getMitutoyoValueForExcel();        //D1  mitutoyo-2 height/minute 
            ROW++;
        }

        //Excel - write content to worksheet 3 Indicators
        private void writeData2ExcelM3()
        {
            actualSheet.Cells[ROW, 1] = huberValueForExcel;           //A1  temperature/minute
            //convert only mitutoyo value to float
            actualSheet.Cells[ROW, 2] = chart_1.getMitutoyoValueForExcel();        //B1  mitutoyo height/minute 
            actualSheet.Cells[ROW, 4] = chart_2.getMitutoyoValueForExcel();        //D1  mitutoyo-2 height/minute 
            actualSheet.Cells[ROW, 6] = chart_3.getMitutoyoValueForExcel();        //F1  mitutoyo-3 height/minute 
            ROW++;
        }

        //Excel - write content to worksheet 4 Indicators
        private void writeData2ExcelM4()
        {
            actualSheet.Cells[ROW, 1] = huberValueForExcel;           //A1  temperature/minute
            //convert only mitutoyo value to float
            actualSheet.Cells[ROW, 2] = chart_1.getMitutoyoValueForExcel();        //B1  mitutoyo height/minute 
            actualSheet.Cells[ROW, 4] = chart_2.getMitutoyoValueForExcel();        //D1  mitutoyo-2 height/minute 
            actualSheet.Cells[ROW, 6] = chart_3.getMitutoyoValueForExcel();        //F1  mitutoyo-3 height/minute 
            actualSheet.Cells[ROW, 8] = chart_4.getMitutoyoValueForExcel();        //H1  mitutoyo-4 height/minute 
            ROW++;
        }

        //Excel Create Actual xlxs
        private void create_actual_xlxs_btn_Click(object sender, EventArgs e)
        {
            writeFinalData2ExcelTables();
            string reportName = getReportName();
            //After write the content to the cell, next step is to save the excel file in your system
            string path = @"C:\serPort\Reports\" + getDatetime() + " " + reportName + "_Temporary_" + xlxsCopiesCounter + ".xlsx";
            excelSheet.SaveAs(path);
            xlxsCopiesCounter++;
        }

        //Excel save workbook
        string excelSaveBookPath;
        private void saveCloseExcelWorkbook()
        {
            writeFinalData2ExcelTables();
            string reportName = getReportName();
            //After write the content to the cell, next step is to save the excel file
            if (indicators_cmBox.Text == "1")
            {
                excelSaveBookPath = @"C:\serPort\Reports\" + getDatetime() + "   " + reportName +
                    " " + personal_name_1_txtBox.Text + ".xlsx";
            }
            else if(indicators_cmBox.Text == "2")
            {
                excelSaveBookPath = @"C:\serPort\Reports\" + getDatetime() + "   " + reportName +
                    " " + personal_name_1_txtBox.Text + " " + personal_name_2_txtBox.Text + ".xlsx";
            }
            else if (indicators_cmBox.Text == "3")
            {
                excelSaveBookPath = @"C:\serPort\Reports\" + getDatetime() + "   " + reportName +
                    " " + personal_name_1_txtBox.Text + " " + personal_name_2_txtBox.Text + 
                    " " + personal_name_3_txtBox.Text + ".xlsx";
            }
            else if (indicators_cmBox.Text == "4")
            {
                excelSaveBookPath = @"C:\serPort\Reports\" + getDatetime() + "   " + reportName +
                    " " + personal_name_1_txtBox.Text + " " + personal_name_2_txtBox.Text +
                    " " + personal_name_3_txtBox.Text + " " + personal_name_4_txtBox.Text + ".xlsx";
            }
            excelSheet.SaveAs(excelSaveBookPath);
            excelSheet.Close();
            excelApp.Quit();
        }

        //Excel write final values to tables before save
        string date;
        private void writeFinalData2ExcelTables()
        {
            //Save data
            //save Operator name                                                                         
            actualSheet.Cells[9, 13] = operators_cmBox.Text;
            //save Huber ID                                                                         
            actualSheet.Cells[10, 13] = getHuberID();
            //save Check Type                                                                         
            actualSheet.Cells[11, 13] = check_type_cmBox.Text;
            //save Start Temperature                                                                        
            actualSheet.Cells[12, 13] = low_temperature_cmBox.Text;
            //save Stop Temperature                                                                        
            actualSheet.Cells[13, 13] = high_temperature_cmBox.Text;
            //save Date 
            date = getDatetime();
            actualSheet.Cells[15, 13] = date.Remove(10, 9);
            //save End time 
            actualSheet.Cells[17, 13] = date.Remove(0, 11);

            //Reference if indicators == "1"
            //Mitutoyo-1
            //save Doc Name value                                                                        
            actualSheet.Cells[2, 13] = getReportName() + personal_name_1_txtBox.Text;
            //save Sto value                                                                        
            actualSheet.Cells[4, 13] = sto_lbl.Text;
            //save Rate value   
            if (rate == "2")
            { actualSheet.Cells[5, 13] = "0.5"; }
            else
            { actualSheet.Cells[5, 13] = rate; }
            //save Str value                                                                         
            actualSheet.Cells[6, 13] = str_lbl.Text;
            //save Str Max value                                                                         
            actualSheet.Cells[7, 13] = str_max_lbl.Text;
            //save Hysteresis value 
            if (check_type_cmBox.Text == "Full Test")
            {
                actualSheet.Cells[8, 13] = hysteresis_lbl.Text;
            }
            //save Sto captured value                                                                        
            actualSheet.Cells[19, 13] = sto_height_captured_lbl.Text;


            if (indicators_cmBox.Text == "2")
            {
                //Mitutoyo-2
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 14] = getReportName() + personal_name_2_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 14] = sto_2_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 14] = "0.5"; }
                else
                { actualSheet.Cells[5, 14] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 14] = str_2_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 14] = str_max_2_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 14] = hysteresis_2_lbl.Text;
                }             
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 14] = sto_2_height_captured_lbl.Text;
            }
            else if (indicators_cmBox.Text == "3")
            {
                //Mitutoyo-2
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 14] = getReportName() + personal_name_2_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 14] = sto_2_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 14] = "0.5"; }
                else
                { actualSheet.Cells[5, 14] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 14] = str_2_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 14] = str_max_2_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 14] = hysteresis_2_lbl.Text;
                }
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 14] = sto_2_height_captured_lbl.Text;

                //Mitutoyo-3
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 15] = getReportName() + personal_name_3_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 15] = sto_3_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 15] = "0.5"; }
                else
                { actualSheet.Cells[5, 15] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 15] = str_3_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 15] = str_max_3_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 15] = hysteresis_3_lbl.Text;
                }
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 15] = sto_3_height_captured_lbl.Text;
            }
            else if (indicators_cmBox.Text == "4")
            {
                //Mitutoyo-2
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 14] = getReportName() + personal_name_2_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 14] = sto_2_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 14] = "0.5"; }
                else
                { actualSheet.Cells[5, 14] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 14] = str_2_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 14] = str_max_2_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 14] = hysteresis_2_lbl.Text;
                }
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 14] = sto_2_height_captured_lbl.Text;

                //Mitutoyo-3
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 15] = getReportName() + personal_name_3_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 15] = sto_3_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 15] = "0.5"; }
                else
                { actualSheet.Cells[5, 15] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 15] = str_3_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 15] = str_max_3_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 15] = hysteresis_3_lbl.Text;
                }
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 15] = sto_3_height_captured_lbl.Text;

                //Mitutoyo-4
                //save Doc Name value                                                                        
                actualSheet.Cells[2, 16] = getReportName() + personal_name_4_txtBox.Text;
                //save Sto value                                                                        
                actualSheet.Cells[4, 16] = sto_4_lbl.Text;
                //save Rate value                                                                        
                if (rate == "2")
                { actualSheet.Cells[5, 16] = "0.5"; }
                else
                { actualSheet.Cells[5, 16] = rate; }
                //save Str value                                                                         
                actualSheet.Cells[6, 16] = str_4_lbl.Text;
                //save Str Max value                                                                         
                actualSheet.Cells[7, 16] = str_max_4_lbl.Text;
                //save Hysteresis value 
                if (check_type_cmBox.Text == "Full Test")
                {
                    actualSheet.Cells[8, 16] = hysteresis_4_lbl.Text;
                }
                //save Sto captured value                                                                        
                actualSheet.Cells[19, 16] = sto_4_height_captured_lbl.Text;
            }
        }

        //Save Statistics to BigData File
        private void saveCloseStatisticsExcelWorkbook( string _firstTemperatureValue)
        {
            if(purpose_cmBox.Text == "Production")
            {
                try
                {
                    //Check if file in use...
                    using (Stream stream = new FileStream(@"\\dc-fs\company\Engineering Projects\Technology\HUB_Data\Bigdata.xlsx", FileMode.Open))
                    {
                        //Closing stream after check
                        stream.Close();
                        //Open destination Excel file ("Bigdata")
                        excelTemplatePath = @"\\dc-fs\company\Engineering Projects\Technology\HUB_Data\Bigdata.xlsx";
                        excelApp = new Excel.Application();
                        excelApp.Visible = false;

                        excelWorkBook = excelApp.Workbooks;
                        excelSheet = excelWorkBook.Open(excelTemplatePath);
                        actualSheet = (Excel.Worksheet)excelSheet.Worksheets.get_Item(1);

                        //Go to last row in the table
                        Excel.Range last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        Excel.Range range = actualSheet.get_Range("B5", last);

                        int lastUsedRow = last.Row;

                        //Thermostat 1 Data
                        //Write new data to last row
                        //Save Work Order "B" column
                        actualSheet.Cells[lastUsedRow + 1, 2] = work_order_txtBox.Text;
                        //Save Thermostat Part Number "C" column
                        actualSheet.Cells[lastUsedRow + 1, 3] = part_number_txtBox.Text;
                        //Save Thermostat Type "D" column
                        actualSheet.Cells[lastUsedRow + 1, 4] = thermostat_type_cmBox.Text;
                        //Save Date/Time "E" column
                        actualSheet.Cells[lastUsedRow + 1, 5] = DateTime.Now.ToString("dd/MM/yyyy");
                        //Save start Time "F" column
                        actualSheet.Cells[lastUsedRow + 1, 6] = startTime;
                        //Save stop Time "G" column
                        actualSheet.Cells[lastUsedRow + 1, 7] = DateTime.Now.ToString("h:mm:ss");
                        //Check type "H" column
                        actualSheet.Cells[lastUsedRow + 1, 8] = check_type_cmBox.Text;
                        //Doc. name "I" column
                        actualSheet.Cells[lastUsedRow + 1, 9] = project_name_txtBox.Text + " " + personal_name_1_txtBox.Text;
                        //Huber ID "J" column
                        actualSheet.Cells[lastUsedRow + 1, 10] = getHuberID();
                        //STO temperature "K" column
                        actualSheet.Cells[lastUsedRow + 1, 11] = sto_lbl.Text;
                        //STR temperature "L" column
                        actualSheet.Cells[lastUsedRow + 1, 12] = str_lbl.Text;
                        //STR MAX temperature "M" column
                        actualSheet.Cells[lastUsedRow + 1, 13] = str_max_lbl.Text;
                        //Rate "N" column
                        if (rate_cmBox.Text == "2")
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "0.5°C/min"; }
                        else
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "1°C/min"; }
                        //Hysteresis "O" column
                        actualSheet.Cells[lastUsedRow + 1, 15] = hysteresis_lbl.Text;
                        //Start temperature "P" column
                        //actualSheet.Cells[lastUsedRow + 1, 16] = low_temperature.ToString();
                        actualSheet.Cells[lastUsedRow + 1, 16] = _firstTemperatureValue;
                        //Stop temperature "Q" column
                        actualSheet.Cells[lastUsedRow + 1, 17] = temperature2Print;
                        //Captured value "R" column
                        actualSheet.Cells[lastUsedRow + 1, 18] = sto_height_captured_lbl.Text;
                        //Operator name "S" column
                        actualSheet.Cells[lastUsedRow + 1, 19] = operators_cmBox.Text;

                        //Add Excel Borders 1
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);
                        range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        range.Borders.Weight = Excel.XlBorderWeight.xlThin;


                        //Thermostat 2 Data
                        //Go to last row in the table
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);

                        lastUsedRow = last.Row;

                        //Write new data to last row
                        //Save Work Order "B" column
                        actualSheet.Cells[lastUsedRow + 1, 2] = work_order_txtBox.Text;
                        //Save Thermostat Part Number "C" column
                        actualSheet.Cells[lastUsedRow + 1, 3] = part_number_txtBox.Text;
                        //Save Thermostat Type "D" column
                        actualSheet.Cells[lastUsedRow + 1, 4] = thermostat_type_cmBox.Text;
                        //Save Date/Time "E" column
                        actualSheet.Cells[lastUsedRow + 1, 5] = DateTime.Now.ToString("dd/MM/yyyy");
                        //Save start Time "F" column
                        actualSheet.Cells[lastUsedRow + 1, 6] = startTime;
                        //Save stop Time "G" column
                        actualSheet.Cells[lastUsedRow + 1, 7] = DateTime.Now.ToString("h:mm:ss");
                        //Check type "H" column
                        actualSheet.Cells[lastUsedRow + 1, 8] = check_type_cmBox.Text;
                        //Doc. name "I" column
                        actualSheet.Cells[lastUsedRow + 1, 9] = project_name_txtBox.Text + " " + personal_name_2_txtBox.Text;
                        //Huber ID "J" column
                        actualSheet.Cells[lastUsedRow + 1, 10] = getHuberID();
                        //STO temperature "K" column
                        actualSheet.Cells[lastUsedRow + 1, 11] = sto_2_lbl.Text;
                        //STR temperature "L" column
                        actualSheet.Cells[lastUsedRow + 1, 12] = str_2_lbl.Text;
                        //STR MAX temperature "M" column
                        actualSheet.Cells[lastUsedRow + 1, 13] = str_max_2_lbl.Text;
                        //Rate "N" column
                        if (rate_cmBox.Text == "2")
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "0.5°C/min"; }
                        else
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "1°C/min"; }
                        //Hysteresis "O" column
                        actualSheet.Cells[lastUsedRow + 1, 15] = hysteresis_2_lbl.Text;
                        //Start temperature "P" column
                        actualSheet.Cells[lastUsedRow + 1, 16] = _firstTemperatureValue;
                        //Stop temperature "Q" column
                        actualSheet.Cells[lastUsedRow + 1, 17] = temperature2Print;
                        //Captured value "R" column
                        actualSheet.Cells[lastUsedRow + 1, 18] = sto_2_height_captured_lbl.Text;
                        //Operator name "S" column
                        actualSheet.Cells[lastUsedRow + 1, 19] = operators_cmBox.Text;

                        //Add Excel Borders 2
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);
                        range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        range.Borders.Weight = Excel.XlBorderWeight.xlThin;

                        //Thermostat 3 Data
                        //Go to last row in the table
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);

                        lastUsedRow = last.Row;

                        //Write new data to last row
                        //Save Work Order "B" column
                        actualSheet.Cells[lastUsedRow + 1, 2] = work_order_txtBox.Text;
                        //Save Thermostat Part Number "C" column
                        actualSheet.Cells[lastUsedRow + 1, 3] = part_number_txtBox.Text;
                        //Save Thermostat Type "D" column
                        actualSheet.Cells[lastUsedRow + 1, 4] = thermostat_type_cmBox.Text;
                        //Save Date/Time "E" column
                        actualSheet.Cells[lastUsedRow + 1, 5] = DateTime.Now.ToString("dd/MM/yyyy");
                        //Save start Time "F" column
                        actualSheet.Cells[lastUsedRow + 1, 6] = startTime;
                        //Save stop Time "G" column
                        actualSheet.Cells[lastUsedRow + 1, 7] = DateTime.Now.ToString("h:mm:ss");
                        //Check type "H" column
                        actualSheet.Cells[lastUsedRow + 1, 8] = check_type_cmBox.Text;
                        //Doc. name "I" column
                        actualSheet.Cells[lastUsedRow + 1, 9] = project_name_txtBox.Text + " " + personal_name_3_txtBox.Text;
                        //Huber ID "J" column
                        actualSheet.Cells[lastUsedRow + 1, 10] = getHuberID();
                        //STO temperature "K" column
                        actualSheet.Cells[lastUsedRow + 1, 11] = sto_3_lbl.Text;
                        //STR temperature "L" column
                        actualSheet.Cells[lastUsedRow + 1, 12] = str_3_lbl.Text;
                        //STR MAX temperature "M" column
                        actualSheet.Cells[lastUsedRow + 1, 13] = str_max_3_lbl.Text;
                        //Rate "N" column
                        if (rate_cmBox.Text == "2")
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "0.5°C/min"; }
                        else
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "1°C/min"; }
                        //Hysteresis "O" column
                        actualSheet.Cells[lastUsedRow + 1, 15] = hysteresis_3_lbl.Text;
                        //Start temperature "P" column
                        actualSheet.Cells[lastUsedRow + 1, 16] = _firstTemperatureValue;
                        //Stop temperature "Q" column
                        actualSheet.Cells[lastUsedRow + 1, 17] = temperature2Print;
                        //Captured value "R" column
                        actualSheet.Cells[lastUsedRow + 1, 18] = sto_3_height_captured_lbl.Text;
                        //Operator name "S" column
                        actualSheet.Cells[lastUsedRow + 1, 19] = operators_cmBox.Text;

                        //Add Excel Borders 3
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);
                        range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        range.Borders.Weight = Excel.XlBorderWeight.xlThin;

                        //Thermostat 4 Data
                        //Go to last row in the table
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);

                        lastUsedRow = last.Row;

                        //Write new data to last row
                        //Save Work Order "B" column
                        actualSheet.Cells[lastUsedRow + 1, 2] = work_order_txtBox.Text;
                        //Save Thermostat Part Number "C" column
                        actualSheet.Cells[lastUsedRow + 1, 3] = part_number_txtBox.Text;
                        //Save Thermostat Type "D" column
                        actualSheet.Cells[lastUsedRow + 1, 4] = thermostat_type_cmBox.Text;
                        //Save Date/Time "E" column
                        actualSheet.Cells[lastUsedRow + 1, 5] = DateTime.Now.ToString("dd/MM/yyyy");
                        //Save start Time "F" column
                        actualSheet.Cells[lastUsedRow + 1, 6] = startTime;
                        //Save stop Time "G" column
                        actualSheet.Cells[lastUsedRow + 1, 7] = DateTime.Now.ToString("h:mm:ss");
                        //Check type "H" column
                        actualSheet.Cells[lastUsedRow + 1, 8] = check_type_cmBox.Text;
                        //Doc. name "I" column
                        actualSheet.Cells[lastUsedRow + 1, 9] = project_name_txtBox.Text + " " + personal_name_4_txtBox.Text;
                        //Huber ID "J" column
                        actualSheet.Cells[lastUsedRow + 1, 10] = getHuberID();
                        //STO temperature "K" column
                        actualSheet.Cells[lastUsedRow + 1, 11] = sto_4_lbl.Text;
                        //STR temperature "L" column
                        actualSheet.Cells[lastUsedRow + 1, 12] = str_4_lbl.Text;
                        //STR MAX temperature "M" column
                        actualSheet.Cells[lastUsedRow + 1, 13] = str_max_4_lbl.Text;
                        //Rate "N" column
                        if (rate_cmBox.Text == "2")
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "0.5°C/min"; }
                        else
                        { actualSheet.Cells[lastUsedRow + 1, 14] = "1°C/min"; }
                        //Hysteresis "O" column
                        actualSheet.Cells[lastUsedRow + 1, 15] = hysteresis_4_lbl.Text;
                        //Start temperature "P" column
                        actualSheet.Cells[lastUsedRow + 1, 16] = _firstTemperatureValue;
                        //Stop temperature "Q" column
                        actualSheet.Cells[lastUsedRow + 1, 17] = temperature2Print;
                        //Captured value "R" column
                        actualSheet.Cells[lastUsedRow + 1, 18] = sto_4_height_captured_lbl.Text;
                        //Operator name "S" column
                        actualSheet.Cells[lastUsedRow + 1, 19] = operators_cmBox.Text;

                        //Add Excel Borders 4
                        last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        range = actualSheet.get_Range("B5", last);
                        range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        range.Borders.Weight = Excel.XlBorderWeight.xlThin;


                        if(indicators_cmBox.Text == "1")
                        {
                            //Delete 3 last rows (data from indicators 2,3,4) in Excel BigData file
                            //Go to last row in the table and delete
                            last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                            lastUsedRow = last.Row;
                            for (int i = 0; i < 3; i++)
                            {                              
                                actualSheet.Rows[lastUsedRow].Delete();
                                lastUsedRow--;
                            }                    
                        }
                        else if(indicators_cmBox.Text == "2")
                        {
                            //Delete 2 last rows (data from indicators 3,4) in Excel BigData file
                            //Go to last row in the table and delete
                            last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                            lastUsedRow = last.Row;
                            for (int i = 0; i < 2; i++)
                            {
                                actualSheet.Rows[lastUsedRow].Delete();
                                lastUsedRow--;
                            }
                        }
                        else if (indicators_cmBox.Text == "3")
                        {
                            //Delete 1 last row (data from indicator 4) in Excel BigData file
                            //Go to last row in the table and delete
                            last = actualSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                            lastUsedRow = last.Row;
                            for (int i = 0; i < 1; i++)
                            {
                                actualSheet.Rows[lastUsedRow].Delete();
                                lastUsedRow--;
                            }
                        }
                        else
                        {
                            //Do nothing... because programm saves data from 4 indicators as default
                        }

                        //Save updated excel file           
                        excelSheet.Save();
                        excelSheet.Close();
                        excelApp.Quit();
                    }
                }
                catch
                {
                    //Do nothing if the file is in use.
                }
            }                 
        }

        //Read Settings of Com Ports from .txt file ("Settings")
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
                chart_1.initializeComPortsName("1");
            }
            else if (indicators_cmBox.Text == "2")
            {
                //Mitutoyo-1
                chart_1.initializeComPortsName("1");
                //Mitutoyo-2
                chart_2.initializeComPortsName("2");
            }
            else if (indicators_cmBox.Text == "3")
            {
                //Mitutoyo-1
                chart_1.initializeComPortsName("1");
                //Mitutoyo-2
                chart_2.initializeComPortsName("2");
                //Mitutoyo-3
                chart_3.initializeComPortsName("3");
            }
            else if (indicators_cmBox.Text == "4")
            {
                //Mitutoyo-1
                chart_1.initializeComPortsName("1");
                //Mitutoyo-2
                chart_2.initializeComPortsName("2");
                //Mitutoyo-3
                chart_3.initializeComPortsName("3");
                //Mitutoyo-4
                chart_4.initializeComPortsName("4");
            }
        }

        //first read from Mitutoyo indicators
        private void indicatorsFirstRead()
        {
            if (indicators_cmBox.Text == "1")
            {
                //Read first time height from Mitutoyo
                chart_1.startReadMitutoyo();     //automatic open port in Class
            }
            else if (indicators_cmBox.Text == "2")
            {
                //Read first time height from Mitutoyo
                chart_1.startReadMitutoyo();     //automatic open port in Class
                chart_2.startReadMitutoyo();     //automatic open port in Class
            }
            else if (indicators_cmBox.Text == "3")
            {
                //Read first time height from Mitutoyo
                chart_1.startReadMitutoyo();     //automatic open port in Class
                chart_2.startReadMitutoyo();     //automatic open port in Class
                chart_3.startReadMitutoyo();     //automatic open port in Class
            }
            else if (indicators_cmBox.Text == "4")
            {
                //Read first time height from Mitutoyo
                chart_1.startReadMitutoyo();     //automatic open port in Class
                chart_2.startReadMitutoyo();     //automatic open port in Class
                chart_3.startReadMitutoyo();     //automatic open port in Class
                chart_4.startReadMitutoyo();     //automatic open port in Class
            }
        }

        //Settings button      
        private void settings_btn_Click_1(object sender, EventArgs e)
        {
            //mitutoyo_1.closePort(1);
            HuberPort.Close();
            new Settings().Show();
        }

        //Charts
        private void showCharts()
        {
            if (indicators_cmBox.Text == "1")
            {
                chart_1.Show();
            }
            else if (indicators_cmBox.Text == "2")
            {
                chart_1.Show();
                chart_2.Show();
            }
            else if (indicators_cmBox.Text == "3")
            {
                chart_1.Show();
                chart_2.Show();
                chart_3.Show();
            }
            else if (indicators_cmBox.Text == "4")
            {
                chart_1.Show();
                chart_2.Show();
                chart_3.Show();
                chart_4.Show();
            }
        }

        //Reports
        private void open_reports_folder_btn_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\serPort\Reports");
        }

        //Checkbox of Chart-1
        private void form_1_checkBox_CheckedChanged(object sender, EventArgs e)
        {       
            if (form_1_checkBox.Checked == true)
            {
                chart_1.Show();
            }
            else if (form_1_checkBox.Checked == false)
            {
                chart_1.Hide();
            }
        }

        //Checkbox of Chart-2
        private void form_2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (form_2_checkBox.Checked == true)
            {
                chart_2.Show();
            }
            else if (form_2_checkBox.Checked == false)
            {
                chart_2.Hide();
            }
        }

        //Checkbox of Chart-3
        private void form_3_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (form_3_checkBox.Checked == true)
            {
                chart_3.Show();
            }
            else if (form_3_checkBox.Checked == false)
            {
                chart_3.Hide();
            }
        }

        //Checkbox of Chart-4
        private void form_4_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (form_4_checkBox.Checked == true)
            {
                chart_4.Show();
            }
            else if (form_4_checkBox.Checked == false)
            {
                chart_4.Hide();
            }
        }

        //Get ReportName
        private string getReportName()
        {
            string reportName = project_name_txtBox.Text;
            return reportName;
        }    
        
        private void goToNewStartTemperature()
        {
            if (at_end_go_to_cmBox.Text != "")
            {
                int temperature = Int32.Parse(at_end_go_to_cmBox.Text);
                temperature *= 100;

                string newStartTemperature = addZeros2HexNumberFromLeft(temperature.ToString("X"));
                huber_hex_value_lbl.Text = newStartTemperature;                     /////////////////////////////////////////////////Do it not visible//////////////////////////
                huber_dec_value_lbl.Text = temperature.ToString();

                if (HuberPort.IsOpen == false) HuberPort.Open();
                if (HuberPort.BytesToRead > 0)
                {
                    HuberPort.DiscardInBuffer();
                    HuberPort.DiscardOutBuffer();
                }

                if (HuberPort.IsOpen) HuberPort.Write("{M00" + newStartTemperature + "\r\n");       //send SetPoint temperature to Huber for next second
                else MessageBox.Show("Serial port is closed!", "RS232 tester", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HuberPort.Close();
            }
            else
            {
                huberStop();
                HuberPort.Close();
            }
        }

        //Set variables in Charts
        private void initializeChartsVariables()
        {          
            if (indicators_cmBox.Text == "1")
            {
                //set Chart Form number
                chart_1.setFormNumber("1");
                //set Sto ("0.1" is defined as default value)
                chart_1.setSto(sto_cmBox.Text);
                //set Str
                chart_1.setStr(str_cmBox.Text);
                //set Str Max
                chart_1.setStrMax(str_max_cmBox.Text);
                //set Hysteresis Height
                if (check_type_cmBox.Text == "Full Test")
                { chart_1.setHysteresisHeight(hysteresis_cmBox.Text); }          
                chart_1.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
            }
            else if (indicators_cmBox.Text == "2")
            {
                //set Chart Form number
                chart_1.setFormNumber("1");
                chart_2.setFormNumber("2");
                //set Sto ("0.1" is defined as default value)
                chart_1.setSto(sto_cmBox.Text);
                chart_2.setSto(sto_cmBox.Text);
                //set Str
                chart_1.setStr(str_cmBox.Text);
                chart_2.setStr(str_cmBox.Text);
                //set Str Max
                chart_1.setStrMax(str_max_cmBox.Text);
                chart_2.setStrMax(str_max_cmBox.Text);
                //set Hysteresis Height
                if (check_type_cmBox.Text == "Full Test")
                {
                    chart_1.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_2.setHysteresisHeight(hysteresis_cmBox.Text);
                }
                chart_1.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_2.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
            }
            else if (indicators_cmBox.Text == "3")
            {
                //set Chart Form number
                chart_1.setFormNumber("1");
                chart_2.setFormNumber("2");
                chart_3.setFormNumber("3");
                //set Sto ("0.1" is defined as default value)
                chart_1.setSto(sto_cmBox.Text);
                chart_2.setSto(sto_cmBox.Text);
                chart_3.setSto(sto_cmBox.Text);
                //set Str
                chart_1.setStr(str_cmBox.Text);
                chart_2.setStr(str_cmBox.Text);
                chart_3.setStr(str_cmBox.Text);
                //set Str Max
                chart_1.setStrMax(str_max_cmBox.Text);
                chart_2.setStrMax(str_max_cmBox.Text);
                chart_3.setStrMax(str_max_cmBox.Text);
                //set Hysteresis Height
                if (check_type_cmBox.Text == "Full Test")
                {
                    chart_1.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_2.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_3.setHysteresisHeight(hysteresis_cmBox.Text);
                }
                chart_1.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_2.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_3.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
            }
            else if (indicators_cmBox.Text == "4")
            {
                //set Chart Form number
                chart_1.setFormNumber("1");
                chart_2.setFormNumber("2");
                chart_3.setFormNumber("3");
                chart_4.setFormNumber("4");
                //set Sto ("0.1" is defined as default value)
                chart_1.setSto(sto_cmBox.Text);
                chart_2.setSto(sto_cmBox.Text);
                chart_3.setSto(sto_cmBox.Text);
                chart_4.setSto(sto_cmBox.Text);
                //set Str
                chart_1.setStr(str_cmBox.Text);
                chart_2.setStr(str_cmBox.Text);
                chart_3.setStr(str_cmBox.Text);
                chart_4.setStr(str_cmBox.Text);
                //set Str Max
                chart_1.setStrMax(str_max_cmBox.Text);
                chart_2.setStrMax(str_max_cmBox.Text);
                chart_3.setStrMax(str_max_cmBox.Text);
                chart_4.setStrMax(str_max_cmBox.Text);
                //set Hysteresis Height
                if (check_type_cmBox.Text == "Full Test")
                {
                    chart_1.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_2.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_3.setHysteresisHeight(hysteresis_cmBox.Text);
                    chart_4.setHysteresisHeight(hysteresis_cmBox.Text);
                }
                chart_1.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_2.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_3.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
                chart_4.initializeVariables(operators_cmBox.Text, getHuberID(), rate_cmBox.Text);
            }
        }

        //Charts
        private void resetCharts()
        {
            if (indicators_cmBox.Text == "1")
            {
                chart_1.resetChart();
            }
            else if (indicators_cmBox.Text == "2")
            {
                chart_1.resetChart();
                chart_2.resetChart();
            }
            else if (indicators_cmBox.Text == "3")
            {
                chart_1.resetChart();
                chart_2.resetChart();
                chart_3.resetChart();
            }
            else if (indicators_cmBox.Text == "4")
            {
                chart_1.resetChart();
                chart_2.resetChart();
                chart_3.resetChart();
                chart_4.resetChart();
            }
        }

        private void closePorts()
        {
            if (indicators_cmBox.Text == "1")
            {
                chart_1.closePort(1);
            }
            else if (indicators_cmBox.Text == "2")
            {
                chart_1.closePort(1);
                chart_2.closePort(2);
            }
            else if (indicators_cmBox.Text == "3")
            {
                chart_1.closePort(1);
                chart_2.closePort(2);
                chart_3.closePort(3);
            }
            else if (indicators_cmBox.Text == "4")
            {
                chart_1.closePort(1);
                chart_2.closePort(2);
                chart_3.closePort(3);
                chart_4.closePort(4);
            }
        }

        //Charts
        private void saveCharts(string reportName)
        {
            chart_1.saveChart(getDatetime() + "   " + reportName + " " + personal_name_1_txtBox.Text, stamp_txtBox.Text);

            if (indicators_cmBox.Text == "2")
            {
                chart_2.saveChart(getDatetime() + "   " + reportName + " " + personal_name_2_txtBox.Text, stamp_txtBox.Text);
            }
            else if (indicators_cmBox.Text == "3")
            {
                chart_2.saveChart(getDatetime() + "   " + reportName + " " + personal_name_2_txtBox.Text, stamp_txtBox.Text);
                chart_3.saveChart(getDatetime() + "   " + reportName + " " + personal_name_3_txtBox.Text, stamp_txtBox.Text);
            }
            else if (indicators_cmBox.Text == "4")
            {
                chart_2.saveChart(getDatetime() + "   " + reportName + " " + personal_name_2_txtBox.Text, stamp_txtBox.Text);
                chart_3.saveChart(getDatetime() + "   " + reportName + " " + personal_name_3_txtBox.Text, stamp_txtBox.Text);
                chart_4.saveChart(getDatetime() + "   " + reportName + " " + personal_name_4_txtBox.Text, stamp_txtBox.Text);
            }
        }

        //CheckBoxes for hide/show charts
        private void checkBoxesRule()
        {
            //Chart-1 visible
            if (chart_1.Visible == false)
            { form_1_checkBox.Checked = false; }
            else
            { form_1_checkBox.Checked = true; }

            //Chart-2 visible
            if (chart_2.Visible == false)
            { form_2_checkBox.Checked = false; }
            else
            { form_2_checkBox.Checked = true; }

            //Chart-3 visible
            if (chart_3.Visible == false)
            { form_3_checkBox.Checked = false; }
            else
            { form_3_checkBox.Checked = true; }

            //Chart-4 visible
            if (chart_4.Visible == false)
            { form_4_checkBox.Checked = false; }
            else
            { form_4_checkBox.Checked = true; }
        }

        //Str M1
        private void checkStrM1()
        {
            if (str_lbl.Text == "")
            {
                //check if Str is now
                //convert value of temperature2Print to float for compare with Str temperature
                //was: if (Convert.ToDecimal(temperature2Print) >= str)
                if (decimal.Parse(temperature2Print) >= str)
                {
                    //Read actual value of Mitutoyo-1 
                    str_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStr();     //Output Str value to Chart window
                }
            }
        }

        //Str M2
        private void checkStrM2()
        {
            if (str_lbl.Text == "")
            {
                //check if Str is now
                //convert value of temperature2Print to float for compare with Str temperature
                // was: if (Convert.ToDecimal(temperature2Print) >= str)
                if (decimal.Parse(temperature2Print) >= str)
                {
                    //Read actual value of Mitutoyo-1 & Mitutoyo-2 
                    str_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStr();     //Output Str value to Chart window

                    str_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStr();     //Output Str value to Chart window
                }
            }
        }

        //Str M3
        private void checkStrM3()
        {
            if (str_lbl.Text == "")
            {
                //check if Str is now
                //convert value of temperature2Print to float for compare with Str temperature
                // was: if (Convert.ToDecimal(temperature2Print) >= str)
                if (decimal.Parse(temperature2Print) >= str)
                {
                    //Read actual value of Mitutoyo-1 & Mitutoyo-2 
                    str_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStr();     //Output Str value to Chart window

                    str_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStr();     //Output Str value to Chart window

                    str_3_lbl.Text = chart_3.getMitutoyoValueForExcel().ToString();
                    chart_3.outputStr();     //Output Str value to Chart window
                }
            }
        }

        //Str M4
        private void checkStrM4()
        {
            if (str_lbl.Text == "")
            {
                //check if Str is now
                //convert value of temperature2Print to float for compare with Str temperature
                // was: if (Convert.ToDecimal(temperature2Print) >= str)
                if (decimal.Parse(temperature2Print) >= str)
                {
                    //Read actual value of Mitutoyo-1 & Mitutoyo-2 
                    str_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStr();     //Output Str value to Chart window

                    str_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStr();     //Output Str value to Chart window

                    str_3_lbl.Text = chart_3.getMitutoyoValueForExcel().ToString();
                    chart_3.outputStr();     //Output Str value to Chart window

                    str_4_lbl.Text = chart_4.getMitutoyoValueForExcel().ToString();
                    chart_4.outputStr();     //Output Str value to Chart window
                }
            }
        }

        //Str Max M1
        private void checkStrMaxM1()
        {
            //check if Str Label is empty (if empty so Str is did not find yet)
            if (str_max_lbl.Text == "")
            {
                //check if StrMax is now
                //convert value of temperature2Print to float for compare with Str temperature
                if (Convert.ToDecimal(temperature2Print) >= strMax)
                {
                    //Read actual value of Mitutoyo 
                    str_max_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStrMax();     //Output Str value to Chart window
                }
            }
        }

        //Str Max M2
        private void checkStrMaxM2()
        {
            //check if Str Label is empty (if empty so Str is did not find yet)
            if (str_max_lbl.Text == "")
            {
                //check if StrMax is now
                //convert value of temperature2Print to float for compare with Str temperature
                if (Convert.ToDecimal(temperature2Print) >= strMax)
                {
                    //Read actual value of Mitutoyo 
                    str_max_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStrMax();     //Output Str value to Chart window

                    str_max_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStrMax();     //Output Str value to Chart window
                }
            }
        }

        //Str Max M3
        private void checkStrMaxM3()
        {
            //check if Str Label is empty (if empty so Str is did not find yet)
            if (str_max_lbl.Text == "")
            {
                //check if StrMax is now
                //convert value of temperature2Print to float for compare with Str temperature
                if (Convert.ToDecimal(temperature2Print) >= strMax)
                {
                    //Read actual value of Mitutoyo 
                    str_max_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStrMax();     //Output Str value to Chart window

                    str_max_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStrMax();     //Output Str value to Chart window

                    str_max_3_lbl.Text = chart_3.getMitutoyoValueForExcel().ToString();
                    chart_3.outputStrMax();     //Output Str value to Chart window
                }
            }
        }

        //Str Max M4
        private void checkStrMaxM4()
        {
            //check if Str Label is empty (if empty so Str is did not find yet)
            if (str_max_lbl.Text == "")
            {
                //check if StrMax is now
                //convert value of temperature2Print to float for compare with Str temperature
                if (Convert.ToDecimal(temperature2Print) >= strMax)
                {
                    //Read actual value of Mitutoyo 
                    str_max_lbl.Text = chart_1.getMitutoyoValueForExcel().ToString();
                    chart_1.outputStrMax();     //Output Str value to Chart window

                    str_max_2_lbl.Text = chart_2.getMitutoyoValueForExcel().ToString();
                    chart_2.outputStrMax();     //Output Str value to Chart window

                    str_max_3_lbl.Text = chart_3.getMitutoyoValueForExcel().ToString();
                    chart_3.outputStrMax();     //Output Str value to Chart window

                    str_max_4_lbl.Text = chart_4.getMitutoyoValueForExcel().ToString();
                    chart_4.outputStrMax();     //Output Str value to Chart window
                }
            }
        }

        //Date/Time
        private string getDatetime()
        {
            DateTime now = DateTime.Now;
            string dateTime = now.ToString("o");  //Get Date+Time of now 
            dateTime = dateTime.Replace('T', ' ').Replace(':', '-');
            return dateTime.Remove(19, 14);
        }

        //Open README file
        private void about_the_program_picBox_Click(object sender, EventArgs e)
        {
            string readmePath = @"C:\serPort\README.txt";
            Process.Start("notepad.exe", readmePath);
        }

        //Templates
        private void templates_btn_Click(object sender, EventArgs e)
        {
            new UserTemplate().Show();
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

        //Open Outlook for send email
        private void email_picBox_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                oMailItem.To = "igor@motorad.com";
                //Add Subject
                oMailItem.Subject = "Constructive feedback";
                // body, bcc etc...
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.ToString());
            }           
        }

        private void bug_report_picBox_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                oMailItem.To = "igor@motorad.com";
                //Add Subject
                oMailItem.Subject = "Bug Report";
                // body, bcc etc...
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.ToString());
            }
        }

        //Build Segments button
        private void igi_test_Click(object sender, EventArgs e)
        {
            HuberPort.Close();
            new Build_Segments().Show();
            this.Hide();
        }
         
    }
}
