using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using Excel = Microsoft.Office.Interop.Excel;   //For Excel
using System.IO;                                //for read/write txt file
using System.Diagnostics;
using System.Drawing.Imaging;                  //for Image save
using Word = Microsoft.Office.Interop.Word;    //for Word
using System.Web;
using Microsoft.Office.Interop.Word;           //for Word
using System.Runtime.InteropServices;


namespace serPort
{
    public partial class Chart: Form
    {
        string InputData = String.Empty;
        private float sto;                         
        private decimal str;   
        private int strMax;
        private string formNumber;
        //public float str;
        public string mitutoyo_actual_value;
        //for BeginInvoke Method in "startReadMitutoyo()"
        private float mitutoyoValueForExcel;
        private float hysteresisHeight;
        private decimal hysteresisUp;
        private decimal hysteresisDown;
        private decimal hysteresisFinal;
        public string hysteresisFlag;
        private string operatorName;
        private string huberID;
        private string rate;
        DateTime now = DateTime.Now;

        SerialPort MitutoyoPort = new SerialPort();
        public delegate void SetTextCallback(string text);

        private readonly string templateFileName = @"C:\serPort\Huber Template.docx";

        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            MitutoyoPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);

            // no legend
            chart_ch.Legends.Clear();
            //chart_ch.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
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

        //Close Port
        public void closePort(int mitutoyo_number)
        {
            MitutoyoPort.Close();   //Every object(windows form) have MitutoyoPort
        }

        //Initialize variables (called from Main)
        public void initializeVariables(string _operator, string _huberID, string _rate)
        {          
            mitutoyo_raw_value_lbl.Text = "";
            mitutoyo_actual_value_lbl.Text = "";
            sto_target_lbl.Text = "STO at " + getSto() + " mm:";
            sto_lbl.Text = "";
            sto_height_captured_lbl.Text = "";
            mitutoyo_actual_value = "";
            mitutoyoValueForExcel = 0.0f;
            str_lbl.Text = "     (mm)";
            str_target_lbl.Text = "STR at" + " " + getStr() + " (°C):";
            str_max_target_lbl.Text = "STR Max at" + " " + getStrMax() + " (°C):";
            str_max_lbl.Text = "";
            hyst_target_lbl.Text = "Hyst. at " + hysteresisHeight.ToString() + " mm:";
            hyst_lbl.Text = "";
            huberID = _huberID;
            operatorName = _operator;
            if (_rate == "1")
            { rate = "1"; }
            else if (_rate == "2")
            { rate = "0.5"; }

            //Window title
            this.Text = "Chart" + "-" + getFormNumber();

            hysteresisFlag = "UP";
            hysteresisUp = 0.0M;
            hysteresisDown = 0.0M;
            hysteresisFinal = 0.0M;          
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
            mitutoyoValueForExcel = float.Parse(String.Format("{0:F2}", rawData));    
            mitutoyo_actual_value_lbl.Text = mitutoyoValueForExcel.ToString();   //output final data to mitutoyo_actual_value_lbl
            mitutoyo_actual_value = mitutoyoValueForExcel.ToString();          

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

        //Get actual Mitutoyo value
        public string getActualMitutoyoValue()
        {         
            return mitutoyoValueForExcel.ToString();
        }

        //Str value
        public void outputStr()
        {
            str_lbl.Text = mitutoyoValueForExcel.ToString();
        }

        //Str Max value
        public void outputStrMax()
        {
            str_max_lbl.Text = mitutoyoValueForExcel.ToString();
        }

        //Chart
        public void resetChart()
        {
            chart_ch.Series["Heat"].Points.Clear();
            chart_ch.Series["Cooling"].Points.Clear(); 
        }

        //Chart
        public void updateUpChart(string huber_temperature)
        {
            float xAxis = float.Parse(huber_temperature);      //xAxis value
            float yAxis = mitutoyoValueForExcel;               //yAxis value

            chart_ch.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart_ch.Series["Heat"].Points.AddXY(xAxis, yAxis);
            chart_ch.ChartAreas[0].AxisX.Minimum = MainForm.low_temperature - 1;
            chart_ch.ChartAreas[0].AxisX.Maximum = MainForm.high_temperature;
            chart_ch.ChartAreas[0].AxisX.Interval = 1;
            chart_ch.ChartAreas[0].AxisX.Title = "Temperature [ °C ]";
            chart_ch.ChartAreas[0].AxisY.Title = "Stroke [ mm ]";
            chart_ch.Refresh();
        }

        //Chart
        public void updateDownChart(string huber_temperature)
        {
            float xAxis = float.Parse(huber_temperature);      //xAxis value
            float yAxis = mitutoyoValueForExcel;               //yAxis value

            chart_ch.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart_ch.Series["Cooling"].Points.AddXY(xAxis, yAxis);
            chart_ch.ChartAreas[0].AxisX.Minimum = MainForm.low_temperature - 1;
            chart_ch.ChartAreas[0].AxisX.Maximum = MainForm.high_temperature;
            chart_ch.ChartAreas[0].AxisX.Interval = 1;
            chart_ch.ChartAreas[0].AxisX.Title = "Temperature [ °C ]";
            chart_ch.ChartAreas[0].AxisY.Title = "Stroke [ mm ]";
            chart_ch.Refresh();
        }

        //called from Main Form
        public void saveChart(string reportName, string stamp)
        {
            saveChartImage();
            insertDataToWordAndSavePdf(reportName, stamp);
        }
        
        //save chart to image file
        private void saveChartImage()
        {
            this.chart_ch.SaveImage("C:\\serPort\\chart.png", ChartImageFormat.Png);
        }

        //Word to PDF
        private void insertDataToWordAndSavePdf(string reportName, string stamp)
        {
            //open MS Word
            Word._Application wordApp = new Word.Application();

            //open word Template
            Document doc = wordApp.Documents.Open(templateFileName);

            //Insert sto nominal value
            doc.Bookmarks["stoNominalBookmark"].Select();
            wordApp.Selection.TypeText(sto_target_lbl.Text);

            //Insert sto value
            doc.Bookmarks["stoBookmark"].Select();
            wordApp.Selection.TypeText(sto_lbl.Text);

            //Insert str nominal value
            doc.Bookmarks["str1TemperatureBookmark"].Select();
            wordApp.Selection.TypeText(str_target_lbl.Text);

            //Insert str_1 value
            doc.Bookmarks["strBookmark"].Select();
            wordApp.Selection.TypeText(str_lbl.Text);

            //Insert str max nominal value
            doc.Bookmarks["strMaxTemperatureBookmark"].Select();
            wordApp.Selection.TypeText(str_max_target_lbl.Text);

            //Insert str max value
            doc.Bookmarks["strMaxBookmark"].Select();
            wordApp.Selection.TypeText(str_max_lbl.Text);

            //Insert hysteresis nominal value
            doc.Bookmarks["hystHBookmark"].Select();
            wordApp.Selection.TypeText(hyst_target_lbl.Text);

            //Insert hysteresis value
            doc.Bookmarks["hystBookmark"].Select();
            wordApp.Selection.TypeText(hyst_lbl.Text);

            //Insert operatorName
            doc.Bookmarks["operatorBookmark"].Select();
            wordApp.Selection.TypeText(operatorName);

            //Insert huberID
            doc.Bookmarks["huberIdBookmark"].Select();
            wordApp.Selection.TypeText(huberID);

            //Insert Report name
            doc.Bookmarks["reportNameBookmark"].Select();
            wordApp.Selection.TypeText(reportName + " " + this.Text);

            //Insert Start temperature
            doc.Bookmarks["startTemperatureBookmark"].Select();
            wordApp.Selection.TypeText(MainForm.low_temperature.ToString());

            //Insert End temperature
            doc.Bookmarks["endTemperatureBookmark"].Select();
            wordApp.Selection.TypeText(MainForm.high_temperature.ToString());

            //Insert Rate
            doc.Bookmarks["rateBookmark"].Select();
            wordApp.Selection.TypeText(rate);

            //Insert Stamp/Part Number
            doc.Bookmarks["partNumberBookmark"].Select();
            wordApp.Selection.TypeText(stamp);

            //add chart image to
            object oRange = doc.Bookmarks["chartBookmark"].Range;
            object saveWithDocument = true;
            object missing = Type.Missing;
            string pictureName = @"C:\serPort\chart.png";
            doc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);

            //save PDF file
            doc.ExportAsFixedFormat(@"C:\serPort\Reports\" + " " + reportName + " " + this.Text + ".pdf", WdExportFormat.wdExportFormatPDF);

            //delete chart image
            var filePath = "C:\\serPort\\chart.png";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            //save word Template without changes
            object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
            object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;
            doc.Close(ref saveOption, ref originalFormat, ref routeDocument);
            ((_Application)wordApp).Quit();

            //close docs
            doc = null;
            wordApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //checkBox1 for hide window
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            checkBox1.Checked = false;
        }

        //Sto get/set
        public void setSto(string _sto)
        {
            sto = float.Parse(_sto);
        }

        public string getSto()
        {
            return sto.ToString();
        }

        //Str get/set
        public void setStr(string _str)
        {
            //was: str = Int32.Parse(_str);
            str = decimal.Parse(_str);
        }

        public string getStr()
        {
            return str.ToString();
        }

        //Str Max get/set
        public void setStrMax(string _strMax)
        {
            strMax = Int32.Parse(_strMax);
        }

        public string getStrMax()
        {
            return strMax.ToString();
        }

        //MitutoyoValueForExcel 
        public float getMitutoyoValueForExcel()
        {
            return mitutoyoValueForExcel;
        }  

        //Form name get/set
        public void setFormNumber(string _formNumber)
        {
            formNumber = _formNumber;
        }

        //Form number
        public string getFormNumber()
        {
            return formNumber;
        }

        //Set Hysteresis height
        public void setHysteresisHeight(string _hysteresisHeight)
        {
            hysteresisHeight = float.Parse(_hysteresisHeight);
        }

        //Check Hysteresis        
        public void checkHysteresis(string actualTemperature)
        {
            //if (hysteresisFinal != 0.0M)
            //{ /*Do nothing*/ }
            if (hysteresisUp == 0.0M)
            {
                if (mitutoyoValueForExcel >= hysteresisHeight)
                {
                    hysteresisUp = Convert.ToDecimal(actualTemperature);
                    hyst_lbl.Text = "UP" + actualTemperature.ToString();
                }
            }
            else if (hysteresisDown == 0.0M && hysteresisFlag == "DOWN")
            {
                if (mitutoyoValueForExcel <= hysteresisHeight)
                {
                    hysteresisDown = Convert.ToDecimal(actualTemperature);
                    hysteresisFinal = hysteresisUp - hysteresisDown;        
                    hyst_lbl.Text =  String.Format("{0:0.00}", hysteresisFinal);    // Example: value = 92.20;   
                }
            }
        }

        //Send Hysteresis value to Main window
        public string getHysteresisValue()
        {
            return hyst_lbl.Text;
        }   

    }
}
