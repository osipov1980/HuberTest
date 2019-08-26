using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace serPort
{
    public partial class UserTemplate : Form
    {
        public UserTemplate()
        {
            InitializeComponent();
            
            //Fill names of templates on load form
            PopulateListBox(templates_listBox, @"C:\serPort\ReportsTemplates\", "*.txt");
            LoadDataFromMain();
        }

        //View tempates Titles in ListBox 
        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            lsb.Items.Clear();

            string sourcePath = Folder;
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    string fileName = s.Substring(s.LastIndexOf("\\") + 1);
                    lsb.Items.Add(fileName);
                }
            }
        }

        //View tempates detiles
        private void templates_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When the item is selected view tempate title in templateTitle_txtBox
            if (templates_listBox.SelectedItem != null)
            {
                string fileName = templates_listBox.GetItemText(templates_listBox.SelectedItem);
                //templateTitle_txtBox.Text = fileName;

                //Load template(json file) detiles to txt boxes
                JsonToTextBoxes(fileName);
            }
        }

        //Load all data from template(json file) to text boxes
        private void JsonToTextBoxes(string jsonFile)
        {
            using (StreamReader r = new StreamReader(@"C:\serPort\ReportsTemplates\" + jsonFile))
            {
                string json = r.ReadToEnd();
                List<JsonTemplate> items = JsonConvert.DeserializeObject<List<JsonTemplate>>(json);

                dynamic array = JsonConvert.DeserializeObject(json);
                //start_T_txtBox.Text = array[0];
                foreach (var item in array)
                {
                    templateTitle_txtBox.Text = item.title.ToString();
                    start_T_cmBox.Text = item.startTemperature.ToString();
                    stop_T_cmBox.Text = item.stopTemperature.ToString();
                    sto_cmBox.Text = item.sto.ToString();
                    str1_cmBox.Text = item.str1.ToString();
                    str_max_cmBox.Text = item.strMax.ToString();
                    hysteresis_cmBox.Text = item.hysteresis.ToString();
                    rate_cmBox.Text = item.rate.ToString();
                    check_type_cmBox.Text = item.checkType.ToString();
                    indicators_cmBox.Text = item.indicators.ToString();
                    //Old version of Json Template does not contain "stamp"
                    try
                    { stamp_txtBox.Text = item.stamp.ToString(); }
                    catch
                    {
                        //Do nothing
                    }                  
                    at_end_go_to_cmBox.Text = item.atEndGoTo.ToString();
                }
            }
        }

        //Save/Update Template
        private void save_as_new_btn_Click(object sender, EventArgs e)
        {
            //Adding value to Objects:
            List<JsonTemplate> _data = new List<JsonTemplate>();
            _data.Add(new JsonTemplate()
            {
                title = templateTitle_txtBox.Text,
                startTemperature = start_T_cmBox.Text,
                stopTemperature = stop_T_cmBox.Text,
                checkType = check_type_cmBox.Text,
                sto = sto_cmBox.Text,
                str1 = str1_cmBox.Text,
                strMax = str_max_cmBox.Text,
                hysteresis = hysteresis_cmBox.Text,
                rate = rate_cmBox.Text,
                indicators = indicators_cmBox.Text,
                stamp = stamp_txtBox.Text,
                atEndGoTo = at_end_go_to_cmBox.Text
            });

            string json = JsonConvert.SerializeObject(_data.ToArray());

            //write all json data to file
            File.WriteAllText(@"C:\serPort\ReportsTemplates\" + templateTitle_txtBox.Text + ".json", json);

            //Fill names of templates on load form
            PopulateListBox(templates_listBox, @"C:\serPort\ReportsTemplates\", "*.txt");

            //Message
            complete_message_lbl.BackColor = Color.SteelBlue;
            complete_message_lbl.ForeColor = Color.White;
            complete_message_lbl.Text = templateTitle_txtBox.Text + " saved!";
        }

        //Delete Template
        private void delete_template_btn_Click(object sender, EventArgs e)
        {
            if (templates_listBox.SelectedIndex != -1)
            {
                //Delete file from folder
                if (File.Exists(@"C:\serPort\ReportsTemplates\" + templateTitle_txtBox.Text + ".json"))
                {
                    File.Delete(@"C:\serPort\ReportsTemplates\" + templateTitle_txtBox.Text + ".json");
                }

                //Delete file from list
                templates_listBox.Items.RemoveAt(templates_listBox.SelectedIndex);
            }

            //Message
            complete_message_lbl.BackColor = Color.Red;
            complete_message_lbl.ForeColor = Color.White;
            complete_message_lbl.Text = templateTitle_txtBox.Text + " deleted!";
        }

        private void load_template_btn_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];

            form.project_name_txtBox.Text = templateTitle_txtBox.Text;
            form.low_temperature_cmBox.Text = start_T_cmBox.Text;
            form.high_temperature_cmBox.Text = stop_T_cmBox.Text;
            form.check_type_cmBox.Text = check_type_cmBox.Text;
            form.sto_cmBox.Text = sto_cmBox.Text;
            form.str_cmBox.Text = str1_cmBox.Text;
            form.str_max_cmBox.Text = str_max_cmBox.Text;
            form.hysteresis_cmBox.Text = hysteresis_cmBox.Text;
            form.rate_cmBox.Text = rate_cmBox.Text;
            form.indicators_cmBox.Text = indicators_cmBox.Text;
            form.stamp_txtBox.Text = stamp_txtBox.Text;
            form.at_end_go_to_cmBox.Text = at_end_go_to_cmBox.Text;

            //Message
            complete_message_lbl.BackColor = Color.Teal;
            complete_message_lbl.ForeColor = Color.White;
            complete_message_lbl.Text = templateTitle_txtBox.Text + " loaded!";
        }

        private void LoadDataFromMain()
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];

            templateTitle_txtBox.Text = form.project_name_txtBox.Text;
            start_T_cmBox.Text = form.low_temperature_cmBox.Text;
            stop_T_cmBox.Text = form.high_temperature_cmBox.Text;
            check_type_cmBox.Text = form.check_type_cmBox.Text;
            sto_cmBox.Text = form.sto_cmBox.Text;
            str1_cmBox.Text = form.str_cmBox.Text;
            str_max_cmBox.Text = form.str_max_cmBox.Text;
            hysteresis_cmBox.Text = form.hysteresis_cmBox.Text;
            rate_cmBox.Text = form.rate_cmBox.Text;
            indicators_cmBox.Text = form.indicators_cmBox.Text;
            stamp_txtBox.Text = form.stamp_txtBox.Text;
            at_end_go_to_cmBox.Text = form.at_end_go_to_cmBox.Text;
        }
    }
}
