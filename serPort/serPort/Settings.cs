using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;   //for read/write txt file


namespace serPort
{
    public partial class Settings : Form
    {
        //Public variables
        string path = @"C:\serPort\Settings.txt";

        public Settings()
        {
            InitializeComponent();
        }

        private void update_huber_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 1;
            string newText = "Huber(Pilot ONE) ComPort: COM" + huber_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        private void update_mitutoyo1_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 2;
            string newText = "Mitutoyo1(ITN)   ComPort: COM" + mitutoyo1_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }

        private void update_mitutoyo2_settings_btn_Click(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(path);
            int line_to_edit = 3;
            string newText = "Mitutoyo2(ITN)   ComPort: COM" + mitutoyo2_txtBox.Text;
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(path, arrLine);
        }
    }
}

