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
            this.huber_start_temperature_lbl = new System.Windows.Forms.Label();
            this.readTimer = new System.Windows.Forms.Timer(this.components);
            this.project_name_txtBox = new System.Windows.Forms.TextBox();
            this.HuberPort = new System.IO.Ports.SerialPort(this.components);
            this.huber_stop_temperature_lbl = new System.Windows.Forms.Label();
            this.captured_values_groupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.mitutoyo_2_actual_value_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_to_end_sec_txt = new System.Windows.Forms.Label();
            this.mitutoyo_1_actual_value_lbl = new System.Windows.Forms.Label();
            this.time_to_end_lbl = new System.Windows.Forms.Label();
            this.actual_temperature_lbl = new System.Windows.Forms.Label();
            this.actual_mitutoyo_1_height_txt = new System.Windows.Forms.Label();
            this.actual_tC_txt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.operators_txt = new System.Windows.Forms.Label();
            this.operators_cmBox = new System.Windows.Forms.ComboBox();
            this.indicators_txt = new System.Windows.Forms.Label();
            this.indicators_cmBox = new System.Windows.Forms.ComboBox();
            this.data_resolution_txt = new System.Windows.Forms.Label();
            this.data_resolution_cmBox = new System.Windows.Forms.ComboBox();
            this.str_max_txt = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rate_txt = new System.Windows.Forms.Label();
            this.str_txt = new System.Windows.Forms.Label();
            this.sto_txt = new System.Windows.Forms.Label();
            this.check_type_txt = new System.Windows.Forms.Label();
            this.end_temperature_txt = new System.Windows.Forms.Label();
            this.start_temperature_txt = new System.Windows.Forms.Label();
            this.hysteresis__txt = new System.Windows.Forms.Label();
            this.hysteresis_cmBox = new System.Windows.Forms.ComboBox();
            this.rate_cmBox = new System.Windows.Forms.ComboBox();
            this.check_type_cmBox = new System.Windows.Forms.ComboBox();
            this.str_cmBox = new System.Windows.Forms.ComboBox();
            this.sto_cmBox = new System.Windows.Forms.ComboBox();
            this.high_temperature_cmBox = new System.Windows.Forms.ComboBox();
            this.low_temperature_cmBox = new System.Windows.Forms.ComboBox();
            this.huber_dec_value_lbl = new System.Windows.Forms.Label();
            this.huber_hex_value_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.email_settings_btn = new System.Windows.Forms.Button();
            this.create_actual_xlxs_btn = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.open_reports_folder_btn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.captured_values_groupBox.SuspendLayout();
            this.real_time_data_control_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_stop_btn
            // 
            this.start_stop_btn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.start_stop_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.start_stop_btn.Location = new System.Drawing.Point(567, 598);
            this.start_stop_btn.Name = "start_stop_btn";
            this.start_stop_btn.Size = new System.Drawing.Size(217, 63);
            this.start_stop_btn.TabIndex = 6;
            this.start_stop_btn.Text = "START";
            this.start_stop_btn.UseVisualStyleBackColor = false;
            this.start_stop_btn.Click += new System.EventHandler(this.start_stop_btn_Click);
            // 
            // huber_start_temperature_lbl
            // 
            this.huber_start_temperature_lbl.AutoSize = true;
            this.huber_start_temperature_lbl.Location = new System.Drawing.Point(699, 60);
            this.huber_start_temperature_lbl.Name = "huber_start_temperature_lbl";
            this.huber_start_temperature_lbl.Size = new System.Drawing.Size(71, 13);
            this.huber_start_temperature_lbl.TabIndex = 8;
            this.huber_start_temperature_lbl.Text = "Huber Start T";
            this.huber_start_temperature_lbl.Visible = false;
            // 
            // readTimer
            // 
            this.readTimer.Interval = 495;
            this.readTimer.Tick += new System.EventHandler(this.readTimer_Tick);
            // 
            // project_name_txtBox
            // 
            this.project_name_txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.project_name_txtBox.Location = new System.Drawing.Point(26, 82);
            this.project_name_txtBox.Name = "project_name_txtBox";
            this.project_name_txtBox.Size = new System.Drawing.Size(1071, 29);
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
            this.huber_stop_temperature_lbl.Location = new System.Drawing.Point(578, 60);
            this.huber_stop_temperature_lbl.Name = "huber_stop_temperature_lbl";
            this.huber_stop_temperature_lbl.Size = new System.Drawing.Size(71, 13);
            this.huber_stop_temperature_lbl.TabIndex = 21;
            this.huber_stop_temperature_lbl.Text = "Huber Stop T";
            this.huber_stop_temperature_lbl.Visible = false;
            // 
            // captured_values_groupBox
            // 
            this.captured_values_groupBox.Controls.Add(this.label5);
            this.captured_values_groupBox.Controls.Add(this.label6);
            this.captured_values_groupBox.Controls.Add(this.label7);
            this.captured_values_groupBox.Controls.Add(this.label8);
            this.captured_values_groupBox.Controls.Add(this.label9);
            this.captured_values_groupBox.Controls.Add(this.label10);
            this.captured_values_groupBox.Controls.Add(this.label11);
            this.captured_values_groupBox.Controls.Add(this.label12);
            this.captured_values_groupBox.Controls.Add(this.label13);
            this.captured_values_groupBox.Controls.Add(this.label14);
            this.captured_values_groupBox.Controls.Add(this.label1);
            this.captured_values_groupBox.Controls.Add(this.label4);
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
            this.captured_values_groupBox.Location = new System.Drawing.Point(26, 122);
            this.captured_values_groupBox.Name = "captured_values_groupBox";
            this.captured_values_groupBox.Size = new System.Drawing.Size(517, 196);
            this.captured_values_groupBox.TabIndex = 48;
            this.captured_values_groupBox.TabStop = false;
            this.captured_values_groupBox.Text = "Captured Values";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(455, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "M4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(455, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "M4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(455, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "M4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(455, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 20);
            this.label8.TabIndex = 65;
            this.label8.Text = "M4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(455, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 64;
            this.label9.Text = "M4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(381, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "M3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(381, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 20);
            this.label11.TabIndex = 62;
            this.label11.Text = "M3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(381, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 20);
            this.label12.TabIndex = 61;
            this.label12.Text = "M3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(381, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 20);
            this.label13.TabIndex = 60;
            this.label13.Text = "M3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(381, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 20);
            this.label14.TabIndex = 59;
            this.label14.Text = "M3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(312, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "M2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(312, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "M2";
            // 
            // sto_2_height_captured_lbl
            // 
            this.sto_2_height_captured_lbl.AutoSize = true;
            this.sto_2_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_2_height_captured_lbl.ForeColor = System.Drawing.Color.Red;
            this.sto_2_height_captured_lbl.Location = new System.Drawing.Point(312, 49);
            this.sto_2_height_captured_lbl.Name = "sto_2_height_captured_lbl";
            this.sto_2_height_captured_lbl.Size = new System.Drawing.Size(31, 20);
            this.sto_2_height_captured_lbl.TabIndex = 56;
            this.sto_2_height_captured_lbl.Text = "M2";
            // 
            // str_2_lbl
            // 
            this.str_2_lbl.AutoSize = true;
            this.str_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_2_lbl.ForeColor = System.Drawing.Color.Red;
            this.str_2_lbl.Location = new System.Drawing.Point(312, 99);
            this.str_2_lbl.Name = "str_2_lbl";
            this.str_2_lbl.Size = new System.Drawing.Size(31, 20);
            this.str_2_lbl.TabIndex = 55;
            this.str_2_lbl.Text = "M2";
            // 
            // sto_2_lbl
            // 
            this.sto_2_lbl.AutoSize = true;
            this.sto_2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_2_lbl.ForeColor = System.Drawing.Color.Red;
            this.sto_2_lbl.Location = new System.Drawing.Point(312, 72);
            this.sto_2_lbl.Name = "sto_2_lbl";
            this.sto_2_lbl.Size = new System.Drawing.Size(31, 20);
            this.sto_2_lbl.TabIndex = 54;
            this.sto_2_lbl.Text = "M2";
            // 
            // hysteresis_lbl
            // 
            this.hysteresis_lbl.AutoSize = true;
            this.hysteresis_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_lbl.ForeColor = System.Drawing.Color.Red;
            this.hysteresis_lbl.Location = new System.Drawing.Point(238, 156);
            this.hysteresis_lbl.Name = "hysteresis_lbl";
            this.hysteresis_lbl.Size = new System.Drawing.Size(31, 20);
            this.hysteresis_lbl.TabIndex = 53;
            this.hysteresis_lbl.Text = "M1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(107, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Hysteresis (C)";
            // 
            // str_max_lbl
            // 
            this.str_max_lbl.AutoSize = true;
            this.str_max_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_lbl.ForeColor = System.Drawing.Color.Red;
            this.str_max_lbl.Location = new System.Drawing.Point(238, 127);
            this.str_max_lbl.Name = "str_max_lbl";
            this.str_max_lbl.Size = new System.Drawing.Size(31, 20);
            this.str_max_lbl.TabIndex = 51;
            this.str_max_lbl.Text = "M1";
            // 
            // str_lbl
            // 
            this.str_lbl.AutoSize = true;
            this.str_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_lbl.ForeColor = System.Drawing.Color.Red;
            this.str_lbl.Location = new System.Drawing.Point(238, 99);
            this.str_lbl.Name = "str_lbl";
            this.str_lbl.Size = new System.Drawing.Size(31, 20);
            this.str_lbl.TabIndex = 50;
            this.str_lbl.Text = "M1";
            // 
            // str_max_mm_txt
            // 
            this.str_max_mm_txt.AutoSize = true;
            this.str_max_mm_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_mm_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_max_mm_txt.Location = new System.Drawing.Point(100, 127);
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
            this.sto_tC_txt.Location = new System.Drawing.Point(146, 72);
            this.sto_tC_txt.Name = "sto_tC_txt";
            this.sto_tC_txt.Size = new System.Drawing.Size(68, 20);
            this.sto_tC_txt.TabIndex = 48;
            this.sto_tC_txt.Text = "STO t(c)";
            // 
            // captured_Sto_value_txt
            // 
            this.captured_Sto_value_txt.AutoSize = true;
            this.captured_Sto_value_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.captured_Sto_value_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.captured_Sto_value_txt.Location = new System.Drawing.Point(22, 49);
            this.captured_Sto_value_txt.Name = "captured_Sto_value_txt";
            this.captured_Sto_value_txt.Size = new System.Drawing.Size(192, 20);
            this.captured_Sto_value_txt.TabIndex = 47;
            this.captured_Sto_value_txt.Text = "Captured STO value (mm)";
            // 
            // sto_height_captured_lbl
            // 
            this.sto_height_captured_lbl.AutoSize = true;
            this.sto_height_captured_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_height_captured_lbl.ForeColor = System.Drawing.Color.Red;
            this.sto_height_captured_lbl.Location = new System.Drawing.Point(238, 49);
            this.sto_height_captured_lbl.Name = "sto_height_captured_lbl";
            this.sto_height_captured_lbl.Size = new System.Drawing.Size(31, 20);
            this.sto_height_captured_lbl.TabIndex = 46;
            this.sto_height_captured_lbl.Text = "M1";
            // 
            // str_mm_txt
            // 
            this.str_mm_txt.AutoSize = true;
            this.str_mm_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_mm_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_mm_txt.Location = new System.Drawing.Point(133, 99);
            this.str_mm_txt.Name = "str_mm_txt";
            this.str_mm_txt.Size = new System.Drawing.Size(81, 20);
            this.str_mm_txt.TabIndex = 45;
            this.str_mm_txt.Text = "STR (mm)";
            // 
            // sto_lbl
            // 
            this.sto_lbl.AutoSize = true;
            this.sto_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_lbl.ForeColor = System.Drawing.Color.Red;
            this.sto_lbl.Location = new System.Drawing.Point(238, 72);
            this.sto_lbl.Name = "sto_lbl";
            this.sto_lbl.Size = new System.Drawing.Size(31, 20);
            this.sto_lbl.TabIndex = 44;
            this.sto_lbl.Text = "M1";
            // 
            // real_time_data_control_groupBox
            // 
            this.real_time_data_control_groupBox.Controls.Add(this.label15);
            this.real_time_data_control_groupBox.Controls.Add(this.label16);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_2_actual_value_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.label3);
            this.real_time_data_control_groupBox.Controls.Add(this.time_to_end_sec_txt);
            this.real_time_data_control_groupBox.Controls.Add(this.mitutoyo_1_actual_value_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.time_to_end_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.actual_temperature_lbl);
            this.real_time_data_control_groupBox.Controls.Add(this.actual_mitutoyo_1_height_txt);
            this.real_time_data_control_groupBox.Controls.Add(this.actual_tC_txt);
            this.real_time_data_control_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.real_time_data_control_groupBox.ForeColor = System.Drawing.Color.GhostWhite;
            this.real_time_data_control_groupBox.Location = new System.Drawing.Point(26, 334);
            this.real_time_data_control_groupBox.Name = "real_time_data_control_groupBox";
            this.real_time_data_control_groupBox.Size = new System.Drawing.Size(517, 327);
            this.real_time_data_control_groupBox.TabIndex = 49;
            this.real_time_data_control_groupBox.TabStop = false;
            this.real_time_data_control_groupBox.Text = "Real Time Data Control";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(438, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 30);
            this.label15.TabIndex = 50;
            this.label15.Text = "M4";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(368, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 30);
            this.label16.TabIndex = 49;
            this.label16.Text = "M3";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mitutoyo_2_actual_value_lbl
            // 
            this.mitutoyo_2_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mitutoyo_2_actual_value_lbl.ForeColor = System.Drawing.Color.Red;
            this.mitutoyo_2_actual_value_lbl.Location = new System.Drawing.Point(300, 66);
            this.mitutoyo_2_actual_value_lbl.Name = "mitutoyo_2_actual_value_lbl";
            this.mitutoyo_2_actual_value_lbl.Size = new System.Drawing.Size(59, 30);
            this.mitutoyo_2_actual_value_lbl.TabIndex = 48;
            this.mitutoyo_2_actual_value_lbl.Text = "M2";
            this.mitutoyo_2_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(313, 238);
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
            this.time_to_end_sec_txt.Location = new System.Drawing.Point(312, 140);
            this.time_to_end_sec_txt.Name = "time_to_end_sec_txt";
            this.time_to_end_sec_txt.Size = new System.Drawing.Size(133, 20);
            this.time_to_end_sec_txt.TabIndex = 43;
            this.time_to_end_sec_txt.Text = "Time to End (sec)";
            this.time_to_end_sec_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mitutoyo_1_actual_value_lbl
            // 
            this.mitutoyo_1_actual_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mitutoyo_1_actual_value_lbl.ForeColor = System.Drawing.Color.Red;
            this.mitutoyo_1_actual_value_lbl.Location = new System.Drawing.Point(220, 66);
            this.mitutoyo_1_actual_value_lbl.Name = "mitutoyo_1_actual_value_lbl";
            this.mitutoyo_1_actual_value_lbl.Size = new System.Drawing.Size(66, 30);
            this.mitutoyo_1_actual_value_lbl.TabIndex = 40;
            this.mitutoyo_1_actual_value_lbl.Text = "M1";
            this.mitutoyo_1_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_to_end_lbl
            // 
            this.time_to_end_lbl.AutoSize = true;
            this.time_to_end_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.time_to_end_lbl.ForeColor = System.Drawing.Color.Red;
            this.time_to_end_lbl.Location = new System.Drawing.Point(343, 163);
            this.time_to_end_lbl.Name = "time_to_end_lbl";
            this.time_to_end_lbl.Size = new System.Drawing.Size(82, 24);
            this.time_to_end_lbl.TabIndex = 41;
            this.time_to_end_lbl.Text = "seconds";
            this.time_to_end_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_temperature_lbl
            // 
            this.actual_temperature_lbl.AutoSize = true;
            this.actual_temperature_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.actual_temperature_lbl.ForeColor = System.Drawing.Color.Red;
            this.actual_temperature_lbl.Location = new System.Drawing.Point(327, 257);
            this.actual_temperature_lbl.Name = "actual_temperature_lbl";
            this.actual_temperature_lbl.Size = new System.Drawing.Size(111, 24);
            this.actual_temperature_lbl.TabIndex = 42;
            this.actual_temperature_lbl.Text = "temperature";
            this.actual_temperature_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_mitutoyo_1_height_txt
            // 
            this.actual_mitutoyo_1_height_txt.AutoSize = true;
            this.actual_mitutoyo_1_height_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actual_mitutoyo_1_height_txt.Location = new System.Drawing.Point(258, 38);
            this.actual_mitutoyo_1_height_txt.Name = "actual_mitutoyo_1_height_txt";
            this.actual_mitutoyo_1_height_txt.Size = new System.Drawing.Size(213, 20);
            this.actual_mitutoyo_1_height_txt.TabIndex = 45;
            this.actual_mitutoyo_1_height_txt.Text = "Actual  Mitutoyo Height (mm)";
            this.actual_mitutoyo_1_height_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_tC_txt
            // 
            this.actual_tC_txt.AutoSize = true;
            this.actual_tC_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actual_tC_txt.Location = new System.Drawing.Point(333, 218);
            this.actual_tC_txt.Name = "actual_tC_txt";
            this.actual_tC_txt.Size = new System.Drawing.Size(92, 20);
            this.actual_tC_txt.TabIndex = 44;
            this.actual_tC_txt.Text = "Actual  t (C)";
            this.actual_tC_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.operators_txt);
            this.groupBox1.Controls.Add(this.operators_cmBox);
            this.groupBox1.Controls.Add(this.indicators_txt);
            this.groupBox1.Controls.Add(this.indicators_cmBox);
            this.groupBox1.Controls.Add(this.data_resolution_txt);
            this.groupBox1.Controls.Add(this.data_resolution_cmBox);
            this.groupBox1.Controls.Add(this.str_max_txt);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.rate_txt);
            this.groupBox1.Controls.Add(this.str_txt);
            this.groupBox1.Controls.Add(this.sto_txt);
            this.groupBox1.Controls.Add(this.check_type_txt);
            this.groupBox1.Controls.Add(this.end_temperature_txt);
            this.groupBox1.Controls.Add(this.start_temperature_txt);
            this.groupBox1.Controls.Add(this.hysteresis__txt);
            this.groupBox1.Controls.Add(this.hysteresis_cmBox);
            this.groupBox1.Controls.Add(this.rate_cmBox);
            this.groupBox1.Controls.Add(this.check_type_cmBox);
            this.groupBox1.Controls.Add(this.str_cmBox);
            this.groupBox1.Controls.Add(this.sto_cmBox);
            this.groupBox1.Controls.Add(this.high_temperature_cmBox);
            this.groupBox1.Controls.Add(this.low_temperature_cmBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Location = new System.Drawing.Point(811, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 539);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Up Report Parameters";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(69, 476);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 20);
            this.label17.TabIndex = 60;
            this.label17.Text = "At end go to";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "-50",
            "-49",
            "-48",
            "-47",
            "-46",
            "-45",
            "-44",
            "-43",
            "-42",
            "-41",
            "-40",
            "-39",
            "-38",
            "-37",
            "-36",
            "-35",
            "-34",
            "-33",
            "-32",
            "-31",
            "-30",
            "-29",
            "-28",
            "-27",
            "-26",
            "-25",
            "-24",
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.comboBox2.Location = new System.Drawing.Point(181, 473);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(86, 28);
            this.comboBox2.TabIndex = 59;
            // 
            // operators_txt
            // 
            this.operators_txt.AutoSize = true;
            this.operators_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.operators_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.operators_txt.Location = new System.Drawing.Point(85, 441);
            this.operators_txt.Name = "operators_txt";
            this.operators_txt.Size = new System.Drawing.Size(80, 20);
            this.operators_txt.TabIndex = 58;
            this.operators_txt.Text = "Operators";
            // 
            // operators_cmBox
            // 
            this.operators_cmBox.BackColor = System.Drawing.Color.White;
            this.operators_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.operators_cmBox.FormattingEnabled = true;
            this.operators_cmBox.Items.AddRange(new object[] {
            "Emil",
            "Alex",
            "Slava T.",
            "Oren",
            "Igor O.",
            "Igor M."});
            this.operators_cmBox.Location = new System.Drawing.Point(181, 436);
            this.operators_cmBox.Name = "operators_cmBox";
            this.operators_cmBox.Size = new System.Drawing.Size(86, 28);
            this.operators_cmBox.TabIndex = 57;
            this.operators_cmBox.Text = "Enter ID";
            // 
            // indicators_txt
            // 
            this.indicators_txt.AutoSize = true;
            this.indicators_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.indicators_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.indicators_txt.Location = new System.Drawing.Point(86, 398);
            this.indicators_txt.Name = "indicators_txt";
            this.indicators_txt.Size = new System.Drawing.Size(79, 20);
            this.indicators_txt.TabIndex = 56;
            this.indicators_txt.Text = "Indicators";
            // 
            // indicators_cmBox
            // 
            this.indicators_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.indicators_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.indicators_cmBox.FormattingEnabled = true;
            this.indicators_cmBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.indicators_cmBox.Location = new System.Drawing.Point(181, 395);
            this.indicators_cmBox.Name = "indicators_cmBox";
            this.indicators_cmBox.Size = new System.Drawing.Size(86, 28);
            this.indicators_cmBox.TabIndex = 55;
            this.indicators_cmBox.Text = "1";
            // 
            // data_resolution_txt
            // 
            this.data_resolution_txt.AutoSize = true;
            this.data_resolution_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.data_resolution_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.data_resolution_txt.Location = new System.Drawing.Point(41, 355);
            this.data_resolution_txt.Name = "data_resolution_txt";
            this.data_resolution_txt.Size = new System.Drawing.Size(124, 20);
            this.data_resolution_txt.TabIndex = 54;
            this.data_resolution_txt.Text = "Data Resolution";
            // 
            // data_resolution_cmBox
            // 
            this.data_resolution_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.data_resolution_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.data_resolution_cmBox.FormattingEnabled = true;
            this.data_resolution_cmBox.Items.AddRange(new object[] {
            "1 time/min",
            "2 times/min",
            "3 times/min",
            "4 times/min",
            "5 times/min",
            "6 times/min"});
            this.data_resolution_cmBox.Location = new System.Drawing.Point(181, 352);
            this.data_resolution_cmBox.Name = "data_resolution_cmBox";
            this.data_resolution_cmBox.Size = new System.Drawing.Size(86, 28);
            this.data_resolution_cmBox.TabIndex = 53;
            // 
            // str_max_txt
            // 
            this.str_max_txt.AutoSize = true;
            this.str_max_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_max_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_max_txt.Location = new System.Drawing.Point(102, 232);
            this.str_max_txt.Name = "str_max_txt";
            this.str_max_txt.Size = new System.Drawing.Size(63, 20);
            this.str_max_txt.TabIndex = 52;
            this.str_max_txt.Text = "Str Max";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-50",
            "-49",
            "-48",
            "-47",
            "-46",
            "-45",
            "-44",
            "-43",
            "-42",
            "-41",
            "-40",
            "-39",
            "-38",
            "-37",
            "-36",
            "-35",
            "-34",
            "-33",
            "-32",
            "-31",
            "-30",
            "-29",
            "-28",
            "-27",
            "-26",
            "-25",
            "-24",
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.comboBox1.Location = new System.Drawing.Point(181, 229);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 28);
            this.comboBox1.TabIndex = 51;
            this.comboBox1.Text = "135";
            // 
            // rate_txt
            // 
            this.rate_txt.AutoSize = true;
            this.rate_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rate_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rate_txt.Location = new System.Drawing.Point(121, 314);
            this.rate_txt.Name = "rate_txt";
            this.rate_txt.Size = new System.Drawing.Size(44, 20);
            this.rate_txt.TabIndex = 50;
            this.rate_txt.Text = "Rate";
            // 
            // str_txt
            // 
            this.str_txt.AutoSize = true;
            this.str_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.str_txt.Location = new System.Drawing.Point(135, 191);
            this.str_txt.Name = "str_txt";
            this.str_txt.Size = new System.Drawing.Size(30, 20);
            this.str_txt.TabIndex = 49;
            this.str_txt.Text = "Str";
            // 
            // sto_txt
            // 
            this.sto_txt.AutoSize = true;
            this.sto_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sto_txt.Location = new System.Drawing.Point(131, 152);
            this.sto_txt.Name = "sto_txt";
            this.sto_txt.Size = new System.Drawing.Size(34, 20);
            this.sto_txt.TabIndex = 48;
            this.sto_txt.Text = "Sto";
            // 
            // check_type_txt
            // 
            this.check_type_txt.AutoSize = true;
            this.check_type_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.check_type_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.check_type_txt.Location = new System.Drawing.Point(77, 112);
            this.check_type_txt.Name = "check_type_txt";
            this.check_type_txt.Size = new System.Drawing.Size(88, 20);
            this.check_type_txt.TabIndex = 47;
            this.check_type_txt.Text = "Check type";
            // 
            // end_temperature_txt
            // 
            this.end_temperature_txt.AutoSize = true;
            this.end_temperature_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.end_temperature_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.end_temperature_txt.Location = new System.Drawing.Point(36, 70);
            this.end_temperature_txt.Name = "end_temperature_txt";
            this.end_temperature_txt.Size = new System.Drawing.Size(129, 20);
            this.end_temperature_txt.TabIndex = 46;
            this.end_temperature_txt.Text = "End temperature";
            // 
            // start_temperature_txt
            // 
            this.start_temperature_txt.AutoSize = true;
            this.start_temperature_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.start_temperature_txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_temperature_txt.Location = new System.Drawing.Point(30, 31);
            this.start_temperature_txt.Name = "start_temperature_txt";
            this.start_temperature_txt.Size = new System.Drawing.Size(135, 20);
            this.start_temperature_txt.TabIndex = 45;
            this.start_temperature_txt.Text = "Srart temperature";
            // 
            // hysteresis__txt
            // 
            this.hysteresis__txt.AutoSize = true;
            this.hysteresis__txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis__txt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hysteresis__txt.Location = new System.Drawing.Point(82, 273);
            this.hysteresis__txt.Name = "hysteresis__txt";
            this.hysteresis__txt.Size = new System.Drawing.Size(83, 20);
            this.hysteresis__txt.TabIndex = 44;
            this.hysteresis__txt.Text = "Hysteresis";
            // 
            // hysteresis_cmBox
            // 
            this.hysteresis_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.hysteresis_cmBox.FormattingEnabled = true;
            this.hysteresis_cmBox.Items.AddRange(new object[] {
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.hysteresis_cmBox.Location = new System.Drawing.Point(181, 270);
            this.hysteresis_cmBox.Name = "hysteresis_cmBox";
            this.hysteresis_cmBox.Size = new System.Drawing.Size(86, 28);
            this.hysteresis_cmBox.TabIndex = 43;
            this.hysteresis_cmBox.Text = "3";
            // 
            // rate_cmBox
            // 
            this.rate_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.rate_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rate_cmBox.FormattingEnabled = true;
            this.rate_cmBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.rate_cmBox.Location = new System.Drawing.Point(181, 311);
            this.rate_cmBox.Name = "rate_cmBox";
            this.rate_cmBox.Size = new System.Drawing.Size(86, 28);
            this.rate_cmBox.TabIndex = 42;
            this.rate_cmBox.Text = "1";
            // 
            // check_type_cmBox
            // 
            this.check_type_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.check_type_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.check_type_cmBox.FormattingEnabled = true;
            this.check_type_cmBox.Items.AddRange(new object[] {
            "Only UP",
            "Full Test"});
            this.check_type_cmBox.Location = new System.Drawing.Point(181, 109);
            this.check_type_cmBox.Name = "check_type_cmBox";
            this.check_type_cmBox.Size = new System.Drawing.Size(86, 28);
            this.check_type_cmBox.TabIndex = 41;
            this.check_type_cmBox.Text = "Only UP";
            // 
            // str_cmBox
            // 
            this.str_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.str_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str_cmBox.FormattingEnabled = true;
            this.str_cmBox.Items.AddRange(new object[] {
            "-50",
            "-49",
            "-48",
            "-47",
            "-46",
            "-45",
            "-44",
            "-43",
            "-42",
            "-41",
            "-40",
            "-39",
            "-38",
            "-37",
            "-36",
            "-35",
            "-34",
            "-33",
            "-32",
            "-31",
            "-30",
            "-29",
            "-28",
            "-27",
            "-26",
            "-25",
            "-24",
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.str_cmBox.Location = new System.Drawing.Point(181, 188);
            this.str_cmBox.Name = "str_cmBox";
            this.str_cmBox.Size = new System.Drawing.Size(86, 28);
            this.str_cmBox.TabIndex = 40;
            this.str_cmBox.Text = "89";
            // 
            // sto_cmBox
            // 
            this.sto_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.sto_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sto_cmBox.FormattingEnabled = true;
            this.sto_cmBox.Items.AddRange(new object[] {
            "0.1",
            "0.3"});
            this.sto_cmBox.Location = new System.Drawing.Point(181, 149);
            this.sto_cmBox.Name = "sto_cmBox";
            this.sto_cmBox.Size = new System.Drawing.Size(86, 28);
            this.sto_cmBox.TabIndex = 39;
            this.sto_cmBox.Text = "0.1";
            // 
            // high_temperature_cmBox
            // 
            this.high_temperature_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.high_temperature_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.high_temperature_cmBox.FormattingEnabled = true;
            this.high_temperature_cmBox.Items.AddRange(new object[] {
            "-50",
            "-49",
            "-48",
            "-47",
            "-46",
            "-45",
            "-44",
            "-43",
            "-42",
            "-41",
            "-40",
            "-39",
            "-38",
            "-37",
            "-36",
            "-35",
            "-34",
            "-33",
            "-32",
            "-31",
            "-30",
            "-29",
            "-28",
            "-27",
            "-26",
            "-25",
            "-24",
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.high_temperature_cmBox.Location = new System.Drawing.Point(181, 67);
            this.high_temperature_cmBox.Name = "high_temperature_cmBox";
            this.high_temperature_cmBox.Size = new System.Drawing.Size(86, 28);
            this.high_temperature_cmBox.TabIndex = 38;
            this.high_temperature_cmBox.Text = "136";
            // 
            // low_temperature_cmBox
            // 
            this.low_temperature_cmBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.low_temperature_cmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.low_temperature_cmBox.FormattingEnabled = true;
            this.low_temperature_cmBox.Items.AddRange(new object[] {
            "-50",
            "-49",
            "-48",
            "-47",
            "-46",
            "-45",
            "-44",
            "-43",
            "-42",
            "-41",
            "-40",
            "-39",
            "-38",
            "-37",
            "-36",
            "-35",
            "-34",
            "-33",
            "-32",
            "-31",
            "-30",
            "-29",
            "-28",
            "-27",
            "-26",
            "-25",
            "-24",
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
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
            this.low_temperature_cmBox.Location = new System.Drawing.Point(181, 28);
            this.low_temperature_cmBox.Name = "low_temperature_cmBox";
            this.low_temperature_cmBox.Size = new System.Drawing.Size(86, 28);
            this.low_temperature_cmBox.TabIndex = 37;
            this.low_temperature_cmBox.Text = "-10";
            // 
            // huber_dec_value_lbl
            // 
            this.huber_dec_value_lbl.AutoSize = true;
            this.huber_dec_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.huber_dec_value_lbl.ForeColor = System.Drawing.Color.Red;
            this.huber_dec_value_lbl.Location = new System.Drawing.Point(824, 60);
            this.huber_dec_value_lbl.Name = "huber_dec_value_lbl";
            this.huber_dec_value_lbl.Size = new System.Drawing.Size(114, 20);
            this.huber_dec_value_lbl.TabIndex = 51;
            this.huber_dec_value_lbl.Text = "Huber Decimal";
            // 
            // huber_hex_value_lbl
            // 
            this.huber_hex_value_lbl.AutoSize = true;
            this.huber_hex_value_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.huber_hex_value_lbl.ForeColor = System.Drawing.Color.Red;
            this.huber_hex_value_lbl.Location = new System.Drawing.Point(974, 60);
            this.huber_hex_value_lbl.Name = "huber_hex_value_lbl";
            this.huber_hex_value_lbl.Size = new System.Drawing.Size(85, 20);
            this.huber_hex_value_lbl.TabIndex = 52;
            this.huber_hex_value_lbl.Text = "Huber Hex";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 66);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.email_settings_btn);
            this.groupBox2.Controls.Add(this.create_actual_xlxs_btn);
            this.groupBox2.Controls.Add(this.settings_btn);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.open_reports_folder_btn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox2.Location = new System.Drawing.Point(567, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 284);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(16, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 32);
            this.button1.TabIndex = 48;
            this.button1.Text = "COMMENTS";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // email_settings_btn
            // 
            this.email_settings_btn.BackColor = System.Drawing.Color.SkyBlue;
            this.email_settings_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_settings_btn.ForeColor = System.Drawing.Color.Black;
            this.email_settings_btn.Location = new System.Drawing.Point(16, 152);
            this.email_settings_btn.Name = "email_settings_btn";
            this.email_settings_btn.Size = new System.Drawing.Size(187, 32);
            this.email_settings_btn.TabIndex = 47;
            this.email_settings_btn.Text = "EMAIL SETTINGS";
            this.email_settings_btn.UseVisualStyleBackColor = false;
            // 
            // create_actual_xlxs_btn
            // 
            this.create_actual_xlxs_btn.BackColor = System.Drawing.Color.SkyBlue;
            this.create_actual_xlxs_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.create_actual_xlxs_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.create_actual_xlxs_btn.ForeColor = System.Drawing.Color.Black;
            this.create_actual_xlxs_btn.Image = ((System.Drawing.Image)(resources.GetObject("create_actual_xlxs_btn.Image")));
            this.create_actual_xlxs_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.create_actual_xlxs_btn.Location = new System.Drawing.Point(16, 232);
            this.create_actual_xlxs_btn.Name = "create_actual_xlxs_btn";
            this.create_actual_xlxs_btn.Size = new System.Drawing.Size(187, 32);
            this.create_actual_xlxs_btn.TabIndex = 46;
            this.create_actual_xlxs_btn.Text = "       CREATE  ACTUAL";
            this.create_actual_xlxs_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.create_actual_xlxs_btn.UseVisualStyleBackColor = false;
            this.create_actual_xlxs_btn.Click += new System.EventHandler(this.create_actual_xlxs_btn_Click);
            // 
            // settings_btn
            // 
            this.settings_btn.BackColor = System.Drawing.Color.SkyBlue;
            this.settings_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_btn.ForeColor = System.Drawing.Color.Black;
            this.settings_btn.Location = new System.Drawing.Point(14, 113);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(187, 32);
            this.settings_btn.TabIndex = 2;
            this.settings_btn.Text = "SETTINGS";
            this.settings_btn.UseVisualStyleBackColor = false;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(14, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "CREATE TEMPLATE";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // open_reports_folder_btn
            // 
            this.open_reports_folder_btn.BackColor = System.Drawing.Color.SkyBlue;
            this.open_reports_folder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_reports_folder_btn.ForeColor = System.Drawing.Color.Black;
            this.open_reports_folder_btn.Location = new System.Drawing.Point(14, 36);
            this.open_reports_folder_btn.Name = "open_reports_folder_btn";
            this.open_reports_folder_btn.Size = new System.Drawing.Size(187, 32);
            this.open_reports_folder_btn.TabIndex = 0;
            this.open_reports_folder_btn.Text = "REPORTS";
            this.open_reports_folder_btn.UseVisualStyleBackColor = false;
            this.open_reports_folder_btn.Click += new System.EventHandler(this.open_reports_folder_btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox4.ForeColor = System.Drawing.Color.GhostWhite;
            this.groupBox4.Location = new System.Drawing.Point(567, 423);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 157);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1127, 690);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.huber_hex_value_lbl);
            this.Controls.Add(this.huber_dec_value_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.real_time_data_control_groupBox);
            this.Controls.Add(this.captured_values_groupBox);
            this.Controls.Add(this.huber_stop_temperature_lbl);
            this.Controls.Add(this.project_name_txtBox);
            this.Controls.Add(this.huber_start_temperature_lbl);
            this.Controls.Add(this.start_stop_btn);
            this.Name = "MainForm";
            this.Text = "Version  0.2.04 (Alpha) - Two Indicators & Only UP (Rate 1)";
            this.captured_values_groupBox.ResumeLayout(false);
            this.captured_values_groupBox.PerformLayout();
            this.real_time_data_control_groupBox.ResumeLayout(false);
            this.real_time_data_control_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_stop_btn;
        private System.Windows.Forms.Timer readTimer;
        private System.Windows.Forms.TextBox project_name_txtBox;
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
        private System.Windows.Forms.Label actual_temperature_lbl;
        private System.Windows.Forms.Label actual_mitutoyo_1_height_txt;
        private System.Windows.Forms.Label actual_tC_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label str_max_txt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label rate_txt;
        private System.Windows.Forms.Label str_txt;
        private System.Windows.Forms.Label sto_txt;
        private System.Windows.Forms.Label check_type_txt;
        private System.Windows.Forms.Label end_temperature_txt;
        private System.Windows.Forms.Label start_temperature_txt;
        private System.Windows.Forms.Label hysteresis__txt;
        private System.Windows.Forms.ComboBox hysteresis_cmBox;
        private System.Windows.Forms.ComboBox rate_cmBox;
        private System.Windows.Forms.ComboBox check_type_cmBox;
        private System.Windows.Forms.ComboBox str_cmBox;
        private System.Windows.Forms.ComboBox sto_cmBox;
        private System.Windows.Forms.ComboBox high_temperature_cmBox;
        private System.Windows.Forms.ComboBox low_temperature_cmBox;
        private System.Windows.Forms.Label data_resolution_txt;
        private System.Windows.Forms.ComboBox data_resolution_cmBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label huber_dec_value_lbl;
        public System.Windows.Forms.Label huber_hex_value_lbl;
        public System.Windows.Forms.Label huber_start_temperature_lbl;
        public System.Windows.Forms.Label sto_height_captured_lbl;
        public System.Windows.Forms.Label sto_lbl;
        public System.Windows.Forms.Label mitutoyo_1_actual_value_lbl;
        private System.Windows.Forms.Label indicators_txt;
        private System.Windows.Forms.ComboBox indicators_cmBox;
        public System.Windows.Forms.Label mitutoyo_2_actual_value_lbl;
        public System.Windows.Forms.Label sto_2_lbl;
        private System.Windows.Forms.Label str_2_lbl;
        public System.Windows.Forms.Label sto_2_height_captured_lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label operators_txt;
        private System.Windows.Forms.ComboBox operators_cmBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button open_reports_folder_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Button create_actual_xlxs_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button email_settings_btn;
    }
}

