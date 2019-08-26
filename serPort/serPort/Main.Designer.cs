namespace serPort
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.start_stop_btn = new System.Windows.Forms.Button();
            this.OnlyUpR1M1 = new System.Windows.Forms.Timer(this.components);
            this.project_name_txtBox = new System.Windows.Forms.TextBox();
            this.HuberPort = new System.IO.Ports.SerialPort(this.components);
            this.huber_stop_temperature_lbl = new System.Windows.Forms.Label();
            this.captured_values_groupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.str_max_4_lbl = new System.Windows.Forms.Label();
            this.hysteresis_4_lbl = new System.Windows.Forms.Label();
            this.sto_4_height_captured_lbl = new System.Windows.Forms.Label();
            this.str_4_lbl = new System.Windows.Forms.Label();
            this.sto_4_lbl = new System.Windows.Forms.Label();
            this.hysteresis_3_lbl = new System.Windows.Forms.Label();
            this.str_max_3_lbl = new System.Windows.Forms.Label();
            this.str_3_lbl = new System.Windows.Forms.Label();
            this.sto_3_height_captured_lbl = new System.Windows.Forms.Label();
            this.sto_3_lbl = new System.Windows.Forms.Label();
            this.str_max_2_lbl = new System.Windows.Forms.Label();
            this.hysteresis_2_lbl = new System.Windows.Forms.Label();
            this.sto_2_height_captured_lbl = new System.Windows.Forms.Label();
            this.str_2_lbl = new System.Windows.Forms.Label();
            this.sto_2_lbl = new System.Windows.Forms.Label();
            this.hysteresis_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.str_max_lbl = new System.Windows.Forms.Label();
            this.str_lbl = new System.Windows.Forms.Label();
            this.str_max_mm_txt = new System.Windows.Forms.Label();
            this.sto_tC_txt = new System.Windows.Forms.Label();
            this.captured_Sto_value_txt = new System.Windows.Forms.Label();
            this.sto_height_captured_lbl = new System.Windows.Forms.Label();
            this.str_mm_txt = new System.Windows.Forms.Label();
            this.sto_lbl = new System.Windows.Forms.Label();
            this.real_time_data_control_groupBox = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.form_3_checkBox = new System.Windows.Forms.CheckBox();
            this.form_4_checkBox = new System.Windows.Forms.CheckBox();
            this.form_2_checkBox = new System.Windows.Forms.CheckBox();
            this.form_1_checkBox = new System.Windows.Forms.CheckBox();
            this.personal_name_4_txtBox = new System.Windows.Forms.TextBox();
            this.personal_name_1_txtBox = new System.Windows.Forms.TextBox();
            this.personal_name_3_txtBox = new System.Windows.Forms.TextBox();
            this.personal_name_2_txtBox = new System.Windows.Forms.TextBox();
            this.mitutoyo_4_actual_value_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_3_actual_value_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_2_actual_value_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_1_actual_value_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_to_end_sec_txt = new System.Windows.Forms.Label();
            this.time_to_end_lbl = new System.Windows.Forms.Label();
            this.actual_temperature_lbl = new System.Windows.Forms.Label();
            this.actual_tC_txt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.work_order_txtBox = new System.Windows.Forms.TextBox();
            this.part_number_txtBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.thermostat_type_cmBox = new System.Windows.Forms.ComboBox();
            this.stamp_txtBox = new System.Windows.Forms.TextBox();
            this.start_temperature_txt = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rate_cmBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.indicators_cmBox = new System.Windows.Forms.ComboBox();
            this.indicators_txt = new System.Windows.Forms.Label();
            this.str_txt = new System.Windows.Forms.Label();
            this.hysteresis_cmBox = new System.Windows.Forms.ComboBox();
            this.purpose_cmBox = new System.Windows.Forms.ComboBox();
            this.check_type_cmBox = new System.Windows.Forms.ComboBox();
            this.rate_txt = new System.Windows.Forms.Label();
            this.operators_cmBox = new System.Windows.Forms.ComboBox();
            this.low_temperature_cmBox = new System.Windows.Forms.ComboBox();
            this.hysteresis__txt = new System.Windows.Forms.Label();
            this.sto_txt = new System.Windows.Forms.Label();
            this.str_cmBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.operators_txt = new System.Windows.Forms.Label();
            this.str_max_cmBox = new System.Windows.Forms.ComboBox();
            this.end_temperature_txt = new System.Windows.Forms.Label();
            this.high_temperature_cmBox = new System.Windows.Forms.ComboBox();
            this.sto_cmBox = new System.Windows.Forms.ComboBox();
            this.check_type_txt = new System.Windows.Forms.Label();
            this.str_max_txt = new System.Windows.Forms.Label();
            this.at_end_go_to_cmBox = new System.Windows.Forms.ComboBox();
            this.huber_dec_value_lbl = new System.Windows.Forms.Label();
            this.huber_hex_value_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.keyboard_btn = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.templates_btn = new System.Windows.Forms.Button();
            this.open_reports_folder_btn = new System.Windows.Forms.Button();
            this.create_actual_xlxs_btn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.about_the_program_picBox = new System.Windows.Forms.PictureBox();
            this.email_picBox = new System.Windows.Forms.PictureBox();
            this.bug_report_picBox = new System.Windows.Forms.PictureBox();
            this.OnlyUpR1M2 = new System.Windows.Forms.Timer(this.components);
            this.OnlyUpR1M3 = new System.Windows.Forms.Timer(this.components);
            this.OnlyUpR1M4 = new System.Windows.Forms.Timer(this.components);
            this.FullTestR1M1 = new System.Windows.Forms.Timer(this.components);
            this.FullTestR1M2 = new System.Windows.Forms.Timer(this.components);
            this.FullTestR1M3 = new System.Windows.Forms.Timer(this.components);
            this.FullTestR1M4 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.igi_test_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.captured_values_groupBox.SuspendLayout();
            this.real_time_data_control_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.about_the_program_picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email_picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bug_report_picBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_stop_btn
            // 
            this.start_stop_btn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.start_stop_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.start_stop_btn.Location = new System.Drawing.Point(519, 481);
            this.start_stop_btn.Name = "start_stop_btn";
            this.start_stop_btn.Size = new System.Drawing.Size(233, 60);
            this.start_stop_btn.TabIndex = 6;
            this.start_stop_btn.Text = "START";
            this.start_stop_btn.UseVisualStyleBackColor = false;
            this.start_stop_btn.Click += new System.EventHandler(this.start_stop_btn_Click);
            // 
            // OnlyUpR1M1
            // 
            this.OnlyUpR1M1.Interval = 495;
            this.OnlyUpR1M1.Tick += new System.EventHandler(this.OnlyUpR1M1_Tick);
            // 
            // project_name_txtBox
            // 
            this.project_name_txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.project_name_txtBox.Location = new System.Drawing.Point(20, 29);
            this.project_name_txtBox.Name = "project_name_txtBox";
            this.project_name_txtBox.Size = new System.Drawing.Size(986, 29);
            this.project_name_txtBox.TabIndex = 11;
            this.project_name_txtBox.Text = "Report Name";
            // 
            // HuberPort
            // 
            this.HuberPort.PortName = "COM17";
            // 
            // huber_stop_temperature_lbl
            // 
            this.huber_stop_temperature_lbl.AutoSize = true;
            this.huber_stop_temperature_lbl.ForeColor = System.Drawing.Color.DarkGray;
            this.huber_stop_temperature_lbl.Location = new System.Drawing.Point(545, 10);
            this.huber_stop_temperature_lbl.Name = "huber_stop_temperature_lbl";
            this.huber_stop_temperature_lbl.Size = new System.Drawing.Size(71, 13);
            this.huber_stop_temperature_lbl.TabIndex = 21;
            this.huber_stop_temperature_lbl.Text = "Huber Stop T";
            // 
            // captured_values_groupBox
            // 
            this.captured_values_groupBox.Controls.Add(this.label4);
            this.captured_values_groupBox.Controls.Add(this.label5);
            this.captured_values_groupBox.Controls.Add(this.label1);
            this.captured_values_groupBox.Controls.Add(this.label12);
            this.captured_values_groupBox.Controls.Add(this.str_max_4_lbl);
            this.captured_values_groupBox.Controls.Add(this.hysteresis_4_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_4_height_captured_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_4_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_4_lbl);
            this.captured_values_groupBox.Controls.Add(this.hysteresis_3_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_max_3_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_3_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_3_height_captured_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_3_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_max_2_lbl);
            this.captured_values_groupBox.Controls.Add(this.hysteresis_2_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_2_height_captured_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_2_lbl);
            this.captured_values_groupBox.Controls.Add(this.sto_2_lbl);
            this.captured_values_groupBox.Controls.Add(this.hysteresis_lbl);
            this.captured_values_groupBox.Controls.Add(this.label2);
            this.captured_values_groupBox.Controls.Add(this.str_max_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_max_mm_txt);
            this.captured_values_groupBox.Controls.Add(this.sto_tC_txt);
            this.captured_values_groupBox.Controls.Add(this.captured_Sto_value_txt);
            this.captured_values_groupBox.Controls.Add(this.sto_height_captured_lbl);
            this.captured_values_groupBox.Controls.Add(this.str_mm_txt);
            this.captured_values_groupBox.Controls.Add(this.sto_lbl);
            this.captured_values_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.captured_values_groupBox.ForeColor = System.Drawing.Color.GhostWhite;
            this.captured_values_groupBox.Location = new System.Drawing.Point(20, 64);
            this.captured_values_groupBox.Name = "captured_values_groupBox";
            this.captured_values_groupBox.Size = new System.Drawing.Size(491, 163);
            this.captured_values_groupBox.TabIndex = 48;
            this.captured_values_groupBox.TabStop = false;
            this.captured_values_groupBox.Text = "Captured Values";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(402, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(333, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "3";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(261, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(192, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // str_max_4_lbl
            // 
            this.str_max_4_lbl.AutoSize = true;
            this.str_max_4_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_4_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_max_4_lbl.Location = new System.Drawing.Point(399, 107);
            this.str_max_4_lbl.Name = "str_max_4_lbl";
            this.str_max_4_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_max_4_lbl.TabIndex = 68;
            this.str_max_4_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hysteresis_4_lbl
            // 
            this.hysteresis_4_lbl.AutoSize = true;
            this.hysteresis_4_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_4_lbl.ForeColor = System.Drawing.Color.Blue;
            this.hysteresis_4_lbl.Location = new System.Drawing.Point(394, 134);
            this.hysteresis_4_lbl.Name = "hysteresis_4_lbl";
            this.hysteresis_4_lbl.Size = new System.Drawing.Size(0, 20);
            this.hysteresis_4_lbl.TabIndex = 67;
            this.hysteresis_4_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_4_height_captured_lbl
            // 
            this.sto_4_height_captured_lbl.AutoSize = true;
            this.sto_4_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_4_height_captured_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_4_height_captured_lbl.Location = new System.Drawing.Point(391, 27);
            this.sto_4_height_captured_lbl.Name = "sto_4_height_captured_lbl";
            this.sto_4_height_captured_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_4_height_captured_lbl.TabIndex = 66;
            this.sto_4_height_captured_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_4_lbl
            // 
            this.str_4_lbl.AutoSize = true;
            this.str_4_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_4_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_4_lbl.Location = new System.Drawing.Point(399, 79);
            this.str_4_lbl.Name = "str_4_lbl";
            this.str_4_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_4_lbl.TabIndex = 65;
            this.str_4_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_4_lbl
            // 
            this.sto_4_lbl.AutoSize = true;
            this.sto_4_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_4_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_4_lbl.Location = new System.Drawing.Point(391, 52);
            this.sto_4_lbl.Name = "sto_4_lbl";
            this.sto_4_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_4_lbl.TabIndex = 64;
            this.sto_4_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hysteresis_3_lbl
            // 
            this.hysteresis_3_lbl.AutoSize = true;
            this.hysteresis_3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_3_lbl.ForeColor = System.Drawing.Color.Blue;
            this.hysteresis_3_lbl.Location = new System.Drawing.Point(326, 134);
            this.hysteresis_3_lbl.Name = "hysteresis_3_lbl";
            this.hysteresis_3_lbl.Size = new System.Drawing.Size(0, 20);
            this.hysteresis_3_lbl.TabIndex = 63;
            this.hysteresis_3_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_max_3_lbl
            // 
            this.str_max_3_lbl.AutoSize = true;
            this.str_max_3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_3_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_max_3_lbl.Location = new System.Drawing.Point(331, 107);
            this.str_max_3_lbl.Name = "str_max_3_lbl";
            this.str_max_3_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_max_3_lbl.TabIndex = 62;
            this.str_max_3_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_3_lbl
            // 
            this.str_3_lbl.AutoSize = true;
            this.str_3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_3_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_3_lbl.Location = new System.Drawing.Point(331, 79);
            this.str_3_lbl.Name = "str_3_lbl";
            this.str_3_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_3_lbl.TabIndex = 61;
            this.str_3_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_3_height_captured_lbl
            // 
            this.sto_3_height_captured_lbl.AutoSize = true;
            this.sto_3_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_3_height_captured_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_3_height_captured_lbl.Location = new System.Drawing.Point(323, 27);
            this.sto_3_height_captured_lbl.Name = "sto_3_height_captured_lbl";
            this.sto_3_height_captured_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_3_height_captured_lbl.TabIndex = 60;
            this.sto_3_height_captured_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_3_lbl
            // 
            this.sto_3_lbl.AutoSize = true;
            this.sto_3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_3_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_3_lbl.Location = new System.Drawing.Point(323, 52);
            this.sto_3_lbl.Name = "sto_3_lbl";
            this.sto_3_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_3_lbl.TabIndex = 59;
            this.sto_3_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_max_2_lbl
            // 
            this.str_max_2_lbl.AutoSize = true;
            this.str_max_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_2_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_max_2_lbl.Location = new System.Drawing.Point(259, 107);
            this.str_max_2_lbl.Name = "str_max_2_lbl";
            this.str_max_2_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_max_2_lbl.TabIndex = 58;
            this.str_max_2_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hysteresis_2_lbl
            // 
            this.hysteresis_2_lbl.AutoSize = true;
            this.hysteresis_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_2_lbl.ForeColor = System.Drawing.Color.Blue;
            this.hysteresis_2_lbl.Location = new System.Drawing.Point(254, 134);
            this.hysteresis_2_lbl.Name = "hysteresis_2_lbl";
            this.hysteresis_2_lbl.Size = new System.Drawing.Size(0, 20);
            this.hysteresis_2_lbl.TabIndex = 57;
            this.hysteresis_2_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_2_height_captured_lbl
            // 
            this.sto_2_height_captured_lbl.AutoSize = true;
            this.sto_2_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_2_height_captured_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_2_height_captured_lbl.Location = new System.Drawing.Point(251, 27);
            this.sto_2_height_captured_lbl.Name = "sto_2_height_captured_lbl";
            this.sto_2_height_captured_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_2_height_captured_lbl.TabIndex = 56;
            this.sto_2_height_captured_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_2_lbl
            // 
            this.str_2_lbl.AutoSize = true;
            this.str_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_2_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_2_lbl.Location = new System.Drawing.Point(259, 79);
            this.str_2_lbl.Name = "str_2_lbl";
            this.str_2_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_2_lbl.TabIndex = 55;
            this.str_2_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sto_2_lbl
            // 
            this.sto_2_lbl.AutoSize = true;
            this.sto_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_2_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_2_lbl.Location = new System.Drawing.Point(251, 52);
            this.sto_2_lbl.Name = "sto_2_lbl";
            this.sto_2_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_2_lbl.TabIndex = 54;
            this.sto_2_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hysteresis_lbl
            // 
            this.hysteresis_lbl.AutoSize = true;
            this.hysteresis_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_lbl.ForeColor = System.Drawing.Color.Blue;
            this.hysteresis_lbl.Location = new System.Drawing.Point(185, 134);
            this.hysteresis_lbl.Name = "hysteresis_lbl";
            this.hysteresis_lbl.Size = new System.Drawing.Size(0, 20);
            this.hysteresis_lbl.TabIndex = 53;
            this.hysteresis_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(57, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Hysteresis (°C)";
            // 
            // str_max_lbl
            // 
            this.str_max_lbl.AutoSize = true;
            this.str_max_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_max_lbl.Location = new System.Drawing.Point(190, 107);
            this.str_max_lbl.Name = "str_max_lbl";
            this.str_max_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_max_lbl.TabIndex = 51;
            this.str_max_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_lbl
            // 
            this.str_lbl.AutoSize = true;
            this.str_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_lbl.ForeColor = System.Drawing.Color.Blue;
            this.str_lbl.Location = new System.Drawing.Point(190, 79);
            this.str_lbl.Name = "str_lbl";
            this.str_lbl.Size = new System.Drawing.Size(0, 20);
            this.str_lbl.TabIndex = 50;
            this.str_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_max_mm_txt
            // 
            this.str_max_mm_txt.AutoSize = true;
            this.str_max_mm_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_mm_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_max_mm_txt.Location = new System.Drawing.Point(56, 107);
            this.str_max_mm_txt.Name = "str_max_mm_txt";
            this.str_max_mm_txt.Size = new System.Drawing.Size(114, 20);
            this.str_max_mm_txt.TabIndex = 49;
            this.str_max_mm_txt.Text = "STR Max (mm)";
            // 
            // sto_tC_txt
            // 
            this.sto_tC_txt.AutoSize = true;
            this.sto_tC_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_tC_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sto_tC_txt.Location = new System.Drawing.Point(89, 52);
            this.sto_tC_txt.Name = "sto_tC_txt";
            this.sto_tC_txt.Size = new System.Drawing.Size(80, 20);
            this.sto_tC_txt.TabIndex = 48;
            this.sto_tC_txt.Text = "STO T(°C)";
            // 
            // captured_Sto_value_txt
            // 
            this.captured_Sto_value_txt.AutoSize = true;
            this.captured_Sto_value_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.captured_Sto_value_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.captured_Sto_value_txt.Location = new System.Drawing.Point(11, 27);
            this.captured_Sto_value_txt.Name = "captured_Sto_value_txt";
            this.captured_Sto_value_txt.Size = new System.Drawing.Size(158, 20);
            this.captured_Sto_value_txt.TabIndex = 47;
            this.captured_Sto_value_txt.Text = "Capt. STO vals. (mm)";
            // 
            // sto_height_captured_lbl
            // 
            this.sto_height_captured_lbl.AutoSize = true;
            this.sto_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_height_captured_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_height_captured_lbl.Location = new System.Drawing.Point(182, 27);
            this.sto_height_captured_lbl.Name = "sto_height_captured_lbl";
            this.sto_height_captured_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_height_captured_lbl.TabIndex = 46;
            this.sto_height_captured_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // str_mm_txt
            // 
            this.str_mm_txt.AutoSize = true;
            this.str_mm_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_mm_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_mm_txt.Location = new System.Drawing.Point(89, 79);
            this.str_mm_txt.Name = "str_mm_txt";
            this.str_mm_txt.Size = new System.Drawing.Size(81, 20);
            this.str_mm_txt.TabIndex = 45;
            this.str_mm_txt.Text = "STR (mm)";
            // 
            // sto_lbl
            // 
            this.sto_lbl.AutoSize = true;
            this.sto_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_lbl.ForeColor = System.Drawing.Color.Blue;
            this.sto_lbl.Location = new System.Drawing.Point(182, 52);
            this.sto_lbl.Name = "sto_lbl";
            this.sto_lbl.Size = new System.Drawing.Size(0, 20);
            this.sto_lbl.TabIndex = 44;
            this.sto_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // real_time_data_control_groupBox
            // 
            this.real_time_data_control_groupBox.Controls.Add(this.label43);
            this.real_time_data_control_groupBox.Controls.Add(this.label44);
            this.real_time_data_control_groupBox.Controls.Add(this.label42);
            this.real_time_data_control_groupBox.Controls.Add(this.label41);
            this.real_time_data_control_groupBox.Controls.Add(this.form_3_checkBox);
            this.real_time_data_control_groupBox.Controls.Add(this.form_4_checkBox);
            this.real_time_data_control_groupBox.Controls.Add(this.form_2_checkBox);
            this.real_time_data_control_groupBox.Controls.Add(this.form_1_checkBox);
            this.real_time_data_control_groupBox.Controls.Add(this.personal_name_4_txtBox);
            this.real_time_data_control_groupBox.Controls.Add(this.personal_name_1_txtBox);
            this.real_time_data_control_groupBox.Controls.Add(this.personal_name_3_txtBox);
            this.real_time_data_control_groupBox.Controls.Add(this.personal_name_2_txtBox);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_4_actual_value_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_3_actual_value_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_2_actual_value_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_1_actual_value_lbl);
            this.real_time_data_control_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.real_time_data_control_groupBox.ForeColor = System.Drawing.Color.GhostWhite;
            this.real_time_data_control_groupBox.Location = new System.Drawing.Point(20, 226);
            this.real_time_data_control_groupBox.Name = "real_time_data_control_groupBox";
            this.real_time_data_control_groupBox.Size = new System.Drawing.Size(491, 159);
            this.real_time_data_control_groupBox.TabIndex = 49;
            this.real_time_data_control_groupBox.TabStop = false;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(43, 120);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(38, 24);
            this.label43.TabIndex = 80;
            this.label43.Text = "#4";
            this.label43.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(43, 89);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(38, 24);
            this.label44.TabIndex = 79;
            this.label44.Text = "#3";
            this.label44.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(43, 55);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(38, 24);
            this.label42.TabIndex = 78;
            this.label42.Text = "#2";
            this.label42.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(43, 26);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 24);
            this.label41.TabIndex = 77;
            this.label41.Text = "#1";
            this.label41.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // form_3_checkBox
            // 
            this.form_3_checkBox.AutoSize = true;
            this.form_3_checkBox.Location = new System.Drawing.Point(313, 97);
            this.form_3_checkBox.Name = "form_3_checkBox";
            this.form_3_checkBox.Size = new System.Drawing.Size(15, 14);
            this.form_3_checkBox.TabIndex = 57;
            this.form_3_checkBox.UseVisualStyleBackColor = true;
            this.form_3_checkBox.CheckedChanged += new System.EventHandler(this.form_3_checkBox_CheckedChanged);
            // 
            // form_4_checkBox
            // 
            this.form_4_checkBox.AutoSize = true;
            this.form_4_checkBox.Location = new System.Drawing.Point(313, 127);
            this.form_4_checkBox.Name = "form_4_checkBox";
            this.form_4_checkBox.Size = new System.Drawing.Size(15, 14);
            this.form_4_checkBox.TabIndex = 58;
            this.form_4_checkBox.UseVisualStyleBackColor = true;
            this.form_4_checkBox.CheckedChanged += new System.EventHandler(this.form_4_checkBox_CheckedChanged);
            // 
            // form_2_checkBox
            // 
            this.form_2_checkBox.AutoSize = true;
            this.form_2_checkBox.Location = new System.Drawing.Point(313, 65);
            this.form_2_checkBox.Name = "form_2_checkBox";
            this.form_2_checkBox.Size = new System.Drawing.Size(15, 14);
            this.form_2_checkBox.TabIndex = 57;
            this.form_2_checkBox.UseVisualStyleBackColor = true;
            this.form_2_checkBox.CheckedChanged += new System.EventHandler(this.form_2_checkBox_CheckedChanged);
            // 
            // form_1_checkBox
            // 
            this.form_1_checkBox.AutoSize = true;
            this.form_1_checkBox.Location = new System.Drawing.Point(313, 33);
            this.form_1_checkBox.Name = "form_1_checkBox";
            this.form_1_checkBox.Size = new System.Drawing.Size(15, 14);
            this.form_1_checkBox.TabIndex = 55;
            this.form_1_checkBox.UseVisualStyleBackColor = true;
            this.form_1_checkBox.CheckedChanged += new System.EventHandler(this.form_1_checkBox_CheckedChanged);
            // 
            // personal_name_4_txtBox
            // 
            this.personal_name_4_txtBox.Location = new System.Drawing.Point(82, 120);
            this.personal_name_4_txtBox.Name = "personal_name_4_txtBox";
            this.personal_name_4_txtBox.Size = new System.Drawing.Size(216, 26);
            this.personal_name_4_txtBox.TabIndex = 54;
            // 
            // personal_name_1_txtBox
            // 
            this.personal_name_1_txtBox.Location = new System.Drawing.Point(82, 25);
            this.personal_name_1_txtBox.Name = "personal_name_1_txtBox";
            this.personal_name_1_txtBox.Size = new System.Drawing.Size(216, 26);
            this.personal_name_1_txtBox.TabIndex = 53;
            // 
            // personal_name_3_txtBox
            // 
            this.personal_name_3_txtBox.Location = new System.Drawing.Point(82, 89);
            this.personal_name_3_txtBox.Name = "personal_name_3_txtBox";
            this.personal_name_3_txtBox.Size = new System.Drawing.Size(216, 26);
            this.personal_name_3_txtBox.TabIndex = 52;
            // 
            // personal_name_2_txtBox
            // 
            this.personal_name_2_txtBox.Location = new System.Drawing.Point(82, 57);
            this.personal_name_2_txtBox.Name = "personal_name_2_txtBox";
            this.personal_name_2_txtBox.Size = new System.Drawing.Size(216, 26);
            this.personal_name_2_txtBox.TabIndex = 51;
            // 
            // mitutoyo_4_actual_value_lbl
            // 
            this.mitutoyo_4_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mitutoyo_4_actual_value_lbl.ForeColor = System.Drawing.Color.Black;
            this.mitutoyo_4_actual_value_lbl.Location = new System.Drawing.Point(333, 120);
            this.mitutoyo_4_actual_value_lbl.Name = "mitutoyo_4_actual_value_lbl";
            this.mitutoyo_4_actual_value_lbl.Size = new System.Drawing.Size(98, 24);
            this.mitutoyo_4_actual_value_lbl.TabIndex = 50;
            this.mitutoyo_4_actual_value_lbl.Text = "Indicator-4";
            this.mitutoyo_4_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // mitutoyo_3_actual_value_lbl
            // 
            this.mitutoyo_3_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mitutoyo_3_actual_value_lbl.ForeColor = System.Drawing.Color.Black;
            this.mitutoyo_3_actual_value_lbl.Location = new System.Drawing.Point(328, 89);
            this.mitutoyo_3_actual_value_lbl.Name = "mitutoyo_3_actual_value_lbl";
            this.mitutoyo_3_actual_value_lbl.Size = new System.Drawing.Size(107, 25);
            this.mitutoyo_3_actual_value_lbl.TabIndex = 49;
            this.mitutoyo_3_actual_value_lbl.Text = "Indicator-3";
            this.mitutoyo_3_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // mitutoyo_2_actual_value_lbl
            // 
            this.mitutoyo_2_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mitutoyo_2_actual_value_lbl.ForeColor = System.Drawing.Color.Black;
            this.mitutoyo_2_actual_value_lbl.Location = new System.Drawing.Point(332, 58);
            this.mitutoyo_2_actual_value_lbl.Name = "mitutoyo_2_actual_value_lbl";
            this.mitutoyo_2_actual_value_lbl.Size = new System.Drawing.Size(100, 24);
            this.mitutoyo_2_actual_value_lbl.TabIndex = 48;
            this.mitutoyo_2_actual_value_lbl.Text = "Indicator-2";
            this.mitutoyo_2_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // mitutoyo_1_actual_value_lbl
            // 
            this.mitutoyo_1_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mitutoyo_1_actual_value_lbl.ForeColor = System.Drawing.Color.Black;
            this.mitutoyo_1_actual_value_lbl.Location = new System.Drawing.Point(329, 26);
            this.mitutoyo_1_actual_value_lbl.Name = "mitutoyo_1_actual_value_lbl";
            this.mitutoyo_1_actual_value_lbl.Size = new System.Drawing.Size(107, 24);
            this.mitutoyo_1_actual_value_lbl.TabIndex = 40;
            this.mitutoyo_1_actual_value_lbl.Text = "Indicator-1";
            this.mitutoyo_1_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(50, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "updated every 10 seconds";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_to_end_sec_txt
            // 
            this.time_to_end_sec_txt.AutoSize = true;
            this.time_to_end_sec_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time_to_end_sec_txt.Location = new System.Drawing.Point(68, 94);
            this.time_to_end_sec_txt.Name = "time_to_end_sec_txt";
            this.time_to_end_sec_txt.Size = new System.Drawing.Size(94, 20);
            this.time_to_end_sec_txt.TabIndex = 43;
            this.time_to_end_sec_txt.Text = "Time to End";
            this.time_to_end_sec_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_to_end_lbl
            // 
            this.time_to_end_lbl.AutoSize = true;
            this.time_to_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.time_to_end_lbl.ForeColor = System.Drawing.Color.Red;
            this.time_to_end_lbl.Location = new System.Drawing.Point(76, 117);
            this.time_to_end_lbl.Name = "time_to_end_lbl";
            this.time_to_end_lbl.Size = new System.Drawing.Size(80, 24);
            this.time_to_end_lbl.TabIndex = 41;
            this.time_to_end_lbl.Text = "00:00:00";
            this.time_to_end_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_temperature_lbl
            // 
            this.actual_temperature_lbl.AutoSize = true;
            this.actual_temperature_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.actual_temperature_lbl.ForeColor = System.Drawing.Color.Red;
            this.actual_temperature_lbl.Location = new System.Drawing.Point(88, 60);
            this.actual_temperature_lbl.Name = "actual_temperature_lbl";
            this.actual_temperature_lbl.Size = new System.Drawing.Size(55, 24);
            this.actual_temperature_lbl.TabIndex = 42;
            this.actual_temperature_lbl.Text = "00.00";
            this.actual_temperature_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_tC_txt
            // 
            this.actual_tC_txt.AutoSize = true;
            this.actual_tC_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actual_tC_txt.Location = new System.Drawing.Point(68, 23);
            this.actual_tC_txt.Name = "actual_tC_txt";
            this.actual_tC_txt.Size = new System.Drawing.Size(97, 20);
            this.actual_tC_txt.TabIndex = 44;
            this.actual_tC_txt.Text = "Actual  t (°C)";
            this.actual_tC_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Location = new System.Drawing.Point(760, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 477);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Up Report Parameters";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.work_order_txtBox);
            this.panel1.Controls.Add(this.part_number_txtBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.thermostat_type_cmBox);
            this.panel1.Controls.Add(this.stamp_txtBox);
            this.panel1.Controls.Add(this.start_temperature_txt);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.rate_cmBox);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.indicators_cmBox);
            this.panel1.Controls.Add(this.indicators_txt);
            this.panel1.Controls.Add(this.str_txt);
            this.panel1.Controls.Add(this.hysteresis_cmBox);
            this.panel1.Controls.Add(this.purpose_cmBox);
            this.panel1.Controls.Add(this.check_type_cmBox);
            this.panel1.Controls.Add(this.rate_txt);
            this.panel1.Controls.Add(this.operators_cmBox);
            this.panel1.Controls.Add(this.low_temperature_cmBox);
            this.panel1.Controls.Add(this.hysteresis__txt);
            this.panel1.Controls.Add(this.sto_txt);
            this.panel1.Controls.Add(this.str_cmBox);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.operators_txt);
            this.panel1.Controls.Add(this.str_max_cmBox);
            this.panel1.Controls.Add(this.end_temperature_txt);
            this.panel1.Controls.Add(this.high_temperature_cmBox);
            this.panel1.Controls.Add(this.sto_cmBox);
            this.panel1.Controls.Add(this.check_type_txt);
            this.panel1.Controls.Add(this.str_max_txt);
            this.panel1.Controls.Add(this.at_end_go_to_cmBox);
            this.panel1.Location = new System.Drawing.Point(6, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 446);
            this.panel1.TabIndex = 77;
            // 
            // work_order_txtBox
            // 
            this.work_order_txtBox.Location = new System.Drawing.Point(109, 502);
            this.work_order_txtBox.Name = "work_order_txtBox";
            this.work_order_txtBox.Size = new System.Drawing.Size(100, 26);
            this.work_order_txtBox.TabIndex = 84;
            // 
            // part_number_txtBox
            // 
            this.part_number_txtBox.Location = new System.Drawing.Point(109, 468);
            this.part_number_txtBox.Name = "part_number_txtBox";
            this.part_number_txtBox.Size = new System.Drawing.Size(100, 26);
            this.part_number_txtBox.TabIndex = 83;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(16, 505);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 20);
            this.label15.TabIndex = 82;
            this.label15.Text = "Work Order";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(18, 538);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 20);
            this.label16.TabIndex = 80;
            this.label16.Text = "Therm type";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(74, 471);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 20);
            this.label19.TabIndex = 78;
            this.label19.Text = "PN";
            // 
            // thermostat_type_cmBox
            // 
            this.thermostat_type_cmBox.BackColor = System.Drawing.Color.White;
            this.thermostat_type_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.thermostat_type_cmBox.FormattingEnabled = true;
            this.thermostat_type_cmBox.Items.AddRange(new object[] {
            " ",
            "Pellet",
            "Thermostat",
            "Housing"});
            this.thermostat_type_cmBox.Location = new System.Drawing.Point(109, 535);
            this.thermostat_type_cmBox.Name = "thermostat_type_cmBox";
            this.thermostat_type_cmBox.Size = new System.Drawing.Size(100, 28);
            this.thermostat_type_cmBox.TabIndex = 79;
            // 
            // stamp_txtBox
            // 
            this.stamp_txtBox.Location = new System.Drawing.Point(109, 433);
            this.stamp_txtBox.Name = "stamp_txtBox";
            this.stamp_txtBox.Size = new System.Drawing.Size(100, 26);
            this.stamp_txtBox.TabIndex = 76;
            // 
            // start_temperature_txt
            // 
            this.start_temperature_txt.AutoSize = true;
            this.start_temperature_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.start_temperature_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_temperature_txt.Location = new System.Drawing.Point(25, 7);
            this.start_temperature_txt.Name = "start_temperature_txt";
            this.start_temperature_txt.Size = new System.Drawing.Size(83, 20);
            this.start_temperature_txt.TabIndex = 45;
            this.start_temperature_txt.Text = "Srart T(°C)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(50, 436);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 20);
            this.label13.TabIndex = 64;
            this.label13.Text = "Stamp";
            // 
            // rate_cmBox
            // 
            this.rate_cmBox.BackColor = System.Drawing.Color.White;
            this.rate_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rate_cmBox.FormattingEnabled = true;
            this.rate_cmBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.rate_cmBox.Location = new System.Drawing.Point(109, 252);
            this.rate_cmBox.Name = "rate_cmBox";
            this.rate_cmBox.Size = new System.Drawing.Size(100, 28);
            this.rate_cmBox.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(37, 365);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 20);
            this.label18.TabIndex = 62;
            this.label18.Text = "Purpose";
            // 
            // indicators_cmBox
            // 
            this.indicators_cmBox.BackColor = System.Drawing.Color.White;
            this.indicators_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.indicators_cmBox.FormattingEnabled = true;
            this.indicators_cmBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "10"});
            this.indicators_cmBox.Location = new System.Drawing.Point(109, 289);
            this.indicators_cmBox.Name = "indicators_cmBox";
            this.indicators_cmBox.Size = new System.Drawing.Size(100, 28);
            this.indicators_cmBox.TabIndex = 55;
            // 
            // indicators_txt
            // 
            this.indicators_txt.AutoSize = true;
            this.indicators_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.indicators_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.indicators_txt.Location = new System.Drawing.Point(27, 292);
            this.indicators_txt.Name = "indicators_txt";
            this.indicators_txt.Size = new System.Drawing.Size(79, 20);
            this.indicators_txt.TabIndex = 56;
            this.indicators_txt.Text = "Indicators";
            // 
            // str_txt
            // 
            this.str_txt.AutoSize = true;
            this.str_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_txt.Location = new System.Drawing.Point(76, 149);
            this.str_txt.Name = "str_txt";
            this.str_txt.Size = new System.Drawing.Size(30, 20);
            this.str_txt.TabIndex = 49;
            this.str_txt.Text = "Str";
            // 
            // hysteresis_cmBox
            // 
            this.hysteresis_cmBox.BackColor = System.Drawing.Color.White;
            this.hysteresis_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_cmBox.FormattingEnabled = true;
            this.hysteresis_cmBox.Items.AddRange(new object[] {
            "",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.hysteresis_cmBox.Location = new System.Drawing.Point(109, 217);
            this.hysteresis_cmBox.Name = "hysteresis_cmBox";
            this.hysteresis_cmBox.Size = new System.Drawing.Size(100, 28);
            this.hysteresis_cmBox.TabIndex = 43;
            // 
            // purpose_cmBox
            // 
            this.purpose_cmBox.BackColor = System.Drawing.Color.White;
            this.purpose_cmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purpose_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.purpose_cmBox.FormattingEnabled = true;
            this.purpose_cmBox.Items.AddRange(new object[] {
            "Other",
            "NPR",
            "Validation",
            "SetUp",
            "Customer Comlaint",
            "CPK",
            "Production"});
            this.purpose_cmBox.Location = new System.Drawing.Point(109, 362);
            this.purpose_cmBox.Name = "purpose_cmBox";
            this.purpose_cmBox.Size = new System.Drawing.Size(100, 28);
            this.purpose_cmBox.TabIndex = 61;
            // 
            // check_type_cmBox
            // 
            this.check_type_cmBox.BackColor = System.Drawing.Color.White;
            this.check_type_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.check_type_cmBox.FormattingEnabled = true;
            this.check_type_cmBox.Items.AddRange(new object[] {
            "Only UP",
            "Full Test",
            "IGI Test"});
            this.check_type_cmBox.Location = new System.Drawing.Point(109, 75);
            this.check_type_cmBox.Name = "check_type_cmBox";
            this.check_type_cmBox.Size = new System.Drawing.Size(100, 28);
            this.check_type_cmBox.TabIndex = 41;
            // 
            // rate_txt
            // 
            this.rate_txt.AutoSize = true;
            this.rate_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rate_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rate_txt.Location = new System.Drawing.Point(62, 255);
            this.rate_txt.Name = "rate_txt";
            this.rate_txt.Size = new System.Drawing.Size(44, 20);
            this.rate_txt.TabIndex = 50;
            this.rate_txt.Text = "Rate";
            // 
            // operators_cmBox
            // 
            this.operators_cmBox.BackColor = System.Drawing.Color.White;
            this.operators_cmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operators_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.operators_cmBox.FormattingEnabled = true;
            this.operators_cmBox.Items.AddRange(new object[] {
            "Emil",
            "Alex",
            "Nerya",
            "Slava T.",
            "Igor O.",
            "Igor M.",
            "Sagi",
            "Stas",
            "Taras",
            "Raz",
            "Daniel",
            "Slava L."});
            this.operators_cmBox.Location = new System.Drawing.Point(109, 325);
            this.operators_cmBox.Name = "operators_cmBox";
            this.operators_cmBox.Size = new System.Drawing.Size(100, 28);
            this.operators_cmBox.TabIndex = 57;
            // 
            // low_temperature_cmBox
            // 
            this.low_temperature_cmBox.BackColor = System.Drawing.Color.White;
            this.low_temperature_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.low_temperature_cmBox.FormattingEnabled = true;
            this.low_temperature_cmBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136"});
            this.low_temperature_cmBox.Location = new System.Drawing.Point(109, 4);
            this.low_temperature_cmBox.Name = "low_temperature_cmBox";
            this.low_temperature_cmBox.Size = new System.Drawing.Size(100, 28);
            this.low_temperature_cmBox.TabIndex = 37;
            // 
            // hysteresis__txt
            // 
            this.hysteresis__txt.AutoSize = true;
            this.hysteresis__txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis__txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hysteresis__txt.Location = new System.Drawing.Point(23, 220);
            this.hysteresis__txt.Name = "hysteresis__txt";
            this.hysteresis__txt.Size = new System.Drawing.Size(83, 20);
            this.hysteresis__txt.TabIndex = 44;
            this.hysteresis__txt.Text = "Hysteresis";
            // 
            // sto_txt
            // 
            this.sto_txt.AutoSize = true;
            this.sto_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sto_txt.Location = new System.Drawing.Point(72, 114);
            this.sto_txt.Name = "sto_txt";
            this.sto_txt.Size = new System.Drawing.Size(34, 20);
            this.sto_txt.TabIndex = 48;
            this.sto_txt.Text = "Sto";
            // 
            // str_cmBox
            // 
            this.str_cmBox.BackColor = System.Drawing.Color.White;
            this.str_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_cmBox.FormattingEnabled = true;
            this.str_cmBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136"});
            this.str_cmBox.Location = new System.Drawing.Point(109, 146);
            this.str_cmBox.Name = "str_cmBox";
            this.str_cmBox.Size = new System.Drawing.Size(100, 28);
            this.str_cmBox.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(10, 401);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 20);
            this.label17.TabIndex = 60;
            this.label17.Text = "At end go to";
            // 
            // operators_txt
            // 
            this.operators_txt.AutoSize = true;
            this.operators_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.operators_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.operators_txt.Location = new System.Drawing.Point(33, 329);
            this.operators_txt.Name = "operators_txt";
            this.operators_txt.Size = new System.Drawing.Size(72, 20);
            this.operators_txt.TabIndex = 58;
            this.operators_txt.Text = "Operator";
            // 
            // str_max_cmBox
            // 
            this.str_max_cmBox.BackColor = System.Drawing.Color.White;
            this.str_max_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_cmBox.FormattingEnabled = true;
            this.str_max_cmBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136"});
            this.str_max_cmBox.Location = new System.Drawing.Point(109, 182);
            this.str_max_cmBox.Name = "str_max_cmBox";
            this.str_max_cmBox.Size = new System.Drawing.Size(100, 28);
            this.str_max_cmBox.TabIndex = 51;
            // 
            // end_temperature_txt
            // 
            this.end_temperature_txt.AutoSize = true;
            this.end_temperature_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.end_temperature_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.end_temperature_txt.Location = new System.Drawing.Point(31, 42);
            this.end_temperature_txt.Name = "end_temperature_txt";
            this.end_temperature_txt.Size = new System.Drawing.Size(77, 20);
            this.end_temperature_txt.TabIndex = 46;
            this.end_temperature_txt.Text = "End T(°C)";
            // 
            // high_temperature_cmBox
            // 
            this.high_temperature_cmBox.BackColor = System.Drawing.Color.White;
            this.high_temperature_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.high_temperature_cmBox.FormattingEnabled = true;
            this.high_temperature_cmBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140"});
            this.high_temperature_cmBox.Location = new System.Drawing.Point(109, 39);
            this.high_temperature_cmBox.Name = "high_temperature_cmBox";
            this.high_temperature_cmBox.Size = new System.Drawing.Size(100, 28);
            this.high_temperature_cmBox.TabIndex = 38;
            // 
            // sto_cmBox
            // 
            this.sto_cmBox.BackColor = System.Drawing.Color.White;
            this.sto_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_cmBox.FormattingEnabled = true;
            this.sto_cmBox.Items.AddRange(new object[] {
            "0.1",
            "0.3",
            "0.2"});
            this.sto_cmBox.Location = new System.Drawing.Point(109, 111);
            this.sto_cmBox.Name = "sto_cmBox";
            this.sto_cmBox.Size = new System.Drawing.Size(100, 28);
            this.sto_cmBox.TabIndex = 39;
            // 
            // check_type_txt
            // 
            this.check_type_txt.AutoSize = true;
            this.check_type_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.check_type_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.check_type_txt.Location = new System.Drawing.Point(18, 78);
            this.check_type_txt.Name = "check_type_txt";
            this.check_type_txt.Size = new System.Drawing.Size(88, 20);
            this.check_type_txt.TabIndex = 47;
            this.check_type_txt.Text = "Check type";
            // 
            // str_max_txt
            // 
            this.str_max_txt.AutoSize = true;
            this.str_max_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_max_txt.Location = new System.Drawing.Point(43, 185);
            this.str_max_txt.Name = "str_max_txt";
            this.str_max_txt.Size = new System.Drawing.Size(63, 20);
            this.str_max_txt.TabIndex = 52;
            this.str_max_txt.Text = "Str Max";
            // 
            // at_end_go_to_cmBox
            // 
            this.at_end_go_to_cmBox.BackColor = System.Drawing.Color.White;
            this.at_end_go_to_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.at_end_go_to_cmBox.FormattingEnabled = true;
            this.at_end_go_to_cmBox.Items.AddRange(new object[] {
            "",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136"});
            this.at_end_go_to_cmBox.Location = new System.Drawing.Point(109, 398);
            this.at_end_go_to_cmBox.Name = "at_end_go_to_cmBox";
            this.at_end_go_to_cmBox.Size = new System.Drawing.Size(100, 28);
            this.at_end_go_to_cmBox.TabIndex = 59;
            // 
            // huber_dec_value_lbl
            // 
            this.huber_dec_value_lbl.AutoSize = true;
            this.huber_dec_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.huber_dec_value_lbl.ForeColor = System.Drawing.Color.DarkGray;
            this.huber_dec_value_lbl.Location = new System.Drawing.Point(690, 10);
            this.huber_dec_value_lbl.Name = "huber_dec_value_lbl";
            this.huber_dec_value_lbl.Size = new System.Drawing.Size(77, 13);
            this.huber_dec_value_lbl.TabIndex = 51;
            this.huber_dec_value_lbl.Text = "Huber Decimal";
            // 
            // huber_hex_value_lbl
            // 
            this.huber_hex_value_lbl.AutoSize = true;
            this.huber_hex_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.huber_hex_value_lbl.ForeColor = System.Drawing.Color.DarkGray;
            this.huber_hex_value_lbl.Location = new System.Drawing.Point(829, 10);
            this.huber_hex_value_lbl.Name = "huber_hex_value_lbl";
            this.huber_hex_value_lbl.Size = new System.Drawing.Size(58, 13);
            this.huber_hex_value_lbl.TabIndex = 52;
            this.huber_hex_value_lbl.Text = "Huber Hex";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 66);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // keyboard_btn
            // 
            this.keyboard_btn.BackColor = System.Drawing.SystemColors.GrayText;
            this.keyboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyboard_btn.ForeColor = System.Drawing.Color.White;
            this.keyboard_btn.Location = new System.Drawing.Point(16, 145);
            this.keyboard_btn.Name = "keyboard_btn";
            this.keyboard_btn.Size = new System.Drawing.Size(205, 36);
            this.keyboard_btn.TabIndex = 57;
            this.keyboard_btn.Text = "KEYBOARD";
            this.keyboard_btn.UseVisualStyleBackColor = false;
            this.keyboard_btn.Click += new System.EventHandler(this.keyboard_btn_Click);
            // 
            // settings_btn
            // 
            this.settings_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.settings_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_btn.ForeColor = System.Drawing.Color.Black;
            this.settings_btn.Location = new System.Drawing.Point(16, 103);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(205, 36);
            this.settings_btn.TabIndex = 2;
            this.settings_btn.Text = "SETTINGS";
            this.settings_btn.UseVisualStyleBackColor = false;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click_1);
            // 
            // templates_btn
            // 
            this.templates_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.templates_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templates_btn.ForeColor = System.Drawing.Color.Black;
            this.templates_btn.Location = new System.Drawing.Point(16, 60);
            this.templates_btn.Name = "templates_btn";
            this.templates_btn.Size = new System.Drawing.Size(205, 36);
            this.templates_btn.TabIndex = 1;
            this.templates_btn.Text = "TEMPLATES";
            this.templates_btn.UseVisualStyleBackColor = false;
            this.templates_btn.Click += new System.EventHandler(this.templates_btn_Click);
            // 
            // open_reports_folder_btn
            // 
            this.open_reports_folder_btn.BackColor = System.Drawing.Color.Gold;
            this.open_reports_folder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_reports_folder_btn.ForeColor = System.Drawing.Color.Black;
            this.open_reports_folder_btn.Location = new System.Drawing.Point(16, 18);
            this.open_reports_folder_btn.Name = "open_reports_folder_btn";
            this.open_reports_folder_btn.Size = new System.Drawing.Size(205, 36);
            this.open_reports_folder_btn.TabIndex = 0;
            this.open_reports_folder_btn.Text = "REPORTS";
            this.open_reports_folder_btn.UseVisualStyleBackColor = false;
            this.open_reports_folder_btn.Click += new System.EventHandler(this.open_reports_folder_btn_Click);
            // 
            // create_actual_xlxs_btn
            // 
            this.create_actual_xlxs_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.create_actual_xlxs_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.create_actual_xlxs_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.create_actual_xlxs_btn.ForeColor = System.Drawing.Color.Black;
            this.create_actual_xlxs_btn.Image = ((System.Drawing.Image)(resources.GetObject("create_actual_xlxs_btn.Image")));
            this.create_actual_xlxs_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.create_actual_xlxs_btn.Location = new System.Drawing.Point(16, 229);
            this.create_actual_xlxs_btn.Name = "create_actual_xlxs_btn";
            this.create_actual_xlxs_btn.Size = new System.Drawing.Size(205, 36);
            this.create_actual_xlxs_btn.TabIndex = 46;
            this.create_actual_xlxs_btn.Text = "       CREATE  ACTUAL";
            this.create_actual_xlxs_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.create_actual_xlxs_btn.UseVisualStyleBackColor = false;
            this.create_actual_xlxs_btn.Click += new System.EventHandler(this.create_actual_xlxs_btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.time_to_end_sec_txt);
            this.groupBox4.Controls.Add(this.time_to_end_lbl);
            this.groupBox4.Controls.Add(this.actual_tC_txt);
            this.groupBox4.Controls.Add(this.actual_temperature_lbl);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox4.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox4.Location = new System.Drawing.Point(262, 386);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 153);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            // 
            // about_the_program_picBox
            // 
            this.about_the_program_picBox.Image = ((System.Drawing.Image)(resources.GetObject("about_the_program_picBox.Image")));
            this.about_the_program_picBox.Location = new System.Drawing.Point(16, 25);
            this.about_the_program_picBox.Name = "about_the_program_picBox";
            this.about_the_program_picBox.Size = new System.Drawing.Size(54, 50);
            this.about_the_program_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.about_the_program_picBox.TabIndex = 58;
            this.about_the_program_picBox.TabStop = false;
            this.about_the_program_picBox.Click += new System.EventHandler(this.about_the_program_picBox_Click);
            // 
            // email_picBox
            // 
            this.email_picBox.Image = ((System.Drawing.Image)(resources.GetObject("email_picBox.Image")));
            this.email_picBox.Location = new System.Drawing.Point(85, 17);
            this.email_picBox.Name = "email_picBox";
            this.email_picBox.Size = new System.Drawing.Size(61, 58);
            this.email_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.email_picBox.TabIndex = 58;
            this.email_picBox.TabStop = false;
            this.email_picBox.Click += new System.EventHandler(this.email_picBox_Click);
            // 
            // bug_report_picBox
            // 
            this.bug_report_picBox.Image = ((System.Drawing.Image)(resources.GetObject("bug_report_picBox.Image")));
            this.bug_report_picBox.Location = new System.Drawing.Point(158, 25);
            this.bug_report_picBox.Name = "bug_report_picBox";
            this.bug_report_picBox.Size = new System.Drawing.Size(54, 52);
            this.bug_report_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bug_report_picBox.TabIndex = 0;
            this.bug_report_picBox.TabStop = false;
            this.bug_report_picBox.Click += new System.EventHandler(this.bug_report_picBox_Click);
            // 
            // OnlyUpR1M2
            // 
            this.OnlyUpR1M2.Interval = 495;
            this.OnlyUpR1M2.Tick += new System.EventHandler(this.OnlyUpR1M2_Tick);
            // 
            // OnlyUpR1M3
            // 
            this.OnlyUpR1M3.Interval = 495;
            this.OnlyUpR1M3.Tick += new System.EventHandler(this.OnlyUpR1M3_Tick);
            // 
            // OnlyUpR1M4
            // 
            this.OnlyUpR1M4.Interval = 495;
            this.OnlyUpR1M4.Tick += new System.EventHandler(this.OnlyUpR1M4_Tick);
            // 
            // FullTestR1M1
            // 
            this.FullTestR1M1.Interval = 495;
            this.FullTestR1M1.Tick += new System.EventHandler(this.FullTestR1M1_Tick);
            // 
            // FullTestR1M2
            // 
            this.FullTestR1M2.Interval = 495;
            this.FullTestR1M2.Tick += new System.EventHandler(this.FullTestR1M2_Tick);
            // 
            // FullTestR1M3
            // 
            this.FullTestR1M3.Interval = 495;
            this.FullTestR1M3.Tick += new System.EventHandler(this.FullTestR1M3_Tick);
            // 
            // FullTestR1M4
            // 
            this.FullTestR1M4.Interval = 495;
            this.FullTestR1M4.Tick += new System.EventHandler(this.FullTestR1M4_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.about_the_program_picBox);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.email_picBox);
            this.groupBox2.Controls.Add(this.bug_report_picBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox2.Location = new System.Drawing.Point(20, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 155);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.igi_test_btn);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.open_reports_folder_btn);
            this.groupBox3.Controls.Add(this.create_actual_xlxs_btn);
            this.groupBox3.Controls.Add(this.templates_btn);
            this.groupBox3.Controls.Add(this.keyboard_btn);
            this.groupBox3.Controls.Add(this.settings_btn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox3.Location = new System.Drawing.Point(519, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 410);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(16, 359);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(205, 36);
            this.button4.TabIndex = 61;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(16, 315);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 36);
            this.button3.TabIndex = 60;
            this.button3.Text = "CHANGE PATH";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // igi_test_btn
            // 
            this.igi_test_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.igi_test_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.igi_test_btn.ForeColor = System.Drawing.Color.Black;
            this.igi_test_btn.Location = new System.Drawing.Point(16, 271);
            this.igi_test_btn.Name = "igi_test_btn";
            this.igi_test_btn.Size = new System.Drawing.Size(205, 36);
            this.igi_test_btn.TabIndex = 59;
            this.igi_test_btn.Text = "IGI TEST";
            this.igi_test_btn.UseVisualStyleBackColor = false;
            this.igi_test_btn.Click += new System.EventHandler(this.igi_test_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(16, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 36);
            this.button1.TabIndex = 58;
            this.button1.Text = "SEND TO";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1021, 551);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.start_stop_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.huber_hex_value_lbl);
            this.Controls.Add(this.huber_dec_value_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.real_time_data_control_groupBox);
            this.Controls.Add(this.captured_values_groupBox);
            this.Controls.Add(this.huber_stop_temperature_lbl);
            this.Controls.Add(this.project_name_txtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Version  0.3.39";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.captured_values_groupBox.ResumeLayout(false);
            this.captured_values_groupBox.PerformLayout();
            this.real_time_data_control_groupBox.ResumeLayout(false);
            this.real_time_data_control_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.about_the_program_picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email_picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bug_report_picBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_stop_btn;
        private System.Windows.Forms.Timer OnlyUpR1M1;
        public System.Windows.Forms.TextBox project_name_txtBox;
        private System.IO.Ports.SerialPort HuberPort;
        private System.Windows.Forms.Label huber_stop_temperature_lbl;
        private System.Windows.Forms.GroupBox captured_values_groupBox;
        private System.Windows.Forms.Label hysteresis_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label str_max_lbl;
        private System.Windows.Forms.Label str_lbl;
        private System.Windows.Forms.Label str_max_mm_txt;
        private System.Windows.Forms.Label sto_tC_txt;
        private System.Windows.Forms.Label captured_Sto_value_txt;
        private System.Windows.Forms.Label str_mm_txt;
        private System.Windows.Forms.GroupBox real_time_data_control_groupBox;
        private System.Windows.Forms.Label time_to_end_sec_txt;
        private System.Windows.Forms.Label time_to_end_lbl;
        public System.Windows.Forms.Label actual_temperature_lbl;
        private System.Windows.Forms.Label actual_tC_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label str_max_txt;
        public System.Windows.Forms.ComboBox str_max_cmBox;
        private System.Windows.Forms.Label rate_txt;
        private System.Windows.Forms.Label str_txt;
        private System.Windows.Forms.Label sto_txt;
        private System.Windows.Forms.Label check_type_txt;
        private System.Windows.Forms.Label end_temperature_txt;
        private System.Windows.Forms.Label start_temperature_txt;
        private System.Windows.Forms.Label hysteresis__txt;
        public System.Windows.Forms.ComboBox hysteresis_cmBox;
        public System.Windows.Forms.ComboBox rate_cmBox;
        public System.Windows.Forms.ComboBox check_type_cmBox;
        public System.Windows.Forms.ComboBox str_cmBox;
        public System.Windows.Forms.ComboBox sto_cmBox;
        public System.Windows.Forms.ComboBox high_temperature_cmBox;
        public System.Windows.Forms.ComboBox low_temperature_cmBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label huber_dec_value_lbl;
        public System.Windows.Forms.Label huber_hex_value_lbl;
        public System.Windows.Forms.Label sto_height_captured_lbl;
        public System.Windows.Forms.Label sto_lbl;
        public System.Windows.Forms.Label mitutoyo_1_actual_value_lbl;
        private System.Windows.Forms.Label indicators_txt;
        public System.Windows.Forms.ComboBox indicators_cmBox;
        public System.Windows.Forms.Label mitutoyo_2_actual_value_lbl;
        public System.Windows.Forms.Label sto_2_lbl;
        private System.Windows.Forms.Label str_2_lbl;
        public System.Windows.Forms.Label sto_2_height_captured_lbl;
        private System.Windows.Forms.Label hysteresis_2_lbl;
        private System.Windows.Forms.Label operators_txt;
        private System.Windows.Forms.ComboBox operators_cmBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label str_max_4_lbl;
        private System.Windows.Forms.Label hysteresis_4_lbl;
        public System.Windows.Forms.Label sto_4_height_captured_lbl;
        private System.Windows.Forms.Label str_4_lbl;
        public System.Windows.Forms.Label sto_4_lbl;
        private System.Windows.Forms.Label hysteresis_3_lbl;
        private System.Windows.Forms.Label str_max_3_lbl;
        private System.Windows.Forms.Label str_3_lbl;
        public System.Windows.Forms.Label sto_3_height_captured_lbl;
        public System.Windows.Forms.Label sto_3_lbl;
        private System.Windows.Forms.Label str_max_2_lbl;
        public System.Windows.Forms.Label mitutoyo_4_actual_value_lbl;
        public System.Windows.Forms.Label mitutoyo_3_actual_value_lbl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button open_reports_folder_btn;
        private System.Windows.Forms.Button templates_btn;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox at_end_go_to_cmBox;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Button create_actual_xlxs_btn;
        private System.Windows.Forms.TextBox personal_name_4_txtBox;
        private System.Windows.Forms.TextBox personal_name_1_txtBox;
        private System.Windows.Forms.TextBox personal_name_3_txtBox;
        private System.Windows.Forms.TextBox personal_name_2_txtBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox purpose_cmBox;
        private System.Windows.Forms.CheckBox form_1_checkBox;
        private System.Windows.Forms.Button keyboard_btn;
        private System.Windows.Forms.CheckBox form_3_checkBox;
        private System.Windows.Forms.CheckBox form_4_checkBox;
        private System.Windows.Forms.CheckBox form_2_checkBox;
        private System.Windows.Forms.PictureBox bug_report_picBox;
        private System.Windows.Forms.PictureBox email_picBox;
        private System.Windows.Forms.PictureBox about_the_program_picBox;
        private System.Windows.Forms.Timer OnlyUpR1M2;
        private System.Windows.Forms.Timer OnlyUpR1M3;
        private System.Windows.Forms.Timer OnlyUpR1M4;
        private System.Windows.Forms.Timer FullTestR1M1;
        private System.Windows.Forms.Timer FullTestR1M2;
        private System.Windows.Forms.Timer FullTestR1M3;
        private System.Windows.Forms.Timer FullTestR1M4;
        public System.Windows.Forms.Label label41;
        public System.Windows.Forms.Label label42;
        public System.Windows.Forms.Label label43;
        public System.Windows.Forms.Label label44;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox stamp_txtBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.ComboBox thermostat_type_cmBox;
        public System.Windows.Forms.TextBox work_order_txtBox;
        public System.Windows.Forms.TextBox part_number_txtBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button igi_test_btn;
    }
}

