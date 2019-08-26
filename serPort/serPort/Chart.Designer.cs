namespace serPort
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_ch = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.actual_indicator_H_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_raw_value_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_actual_value_lbl = new System.Windows.Forms.Label();
            this.sto_lbl = new System.Windows.Forms.Label();
            this.sto_height_captured_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sto_target_lbl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.str_lbl = new System.Windows.Forms.Label();
            this.str_target_lbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.str_max_lbl = new System.Windows.Forms.Label();
            this.str_max_target_lbl = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.hyst_lbl = new System.Windows.Forms.Label();
            this.hyst_target_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_ch
            // 
            chartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisX.Title = "Temperature [°C]";
            chartArea1.AxisY.Title = "Stroke [mm]";
            chartArea1.Name = "ChartArea1";
            this.chart_ch.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_ch.Legends.Add(legend1);
            this.chart_ch.Location = new System.Drawing.Point(30, 65);
            this.chart_ch.Name = "chart_ch";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            series1.Legend = "Legend1";
            series1.Name = "Heat";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            series2.Legend = "Legend1";
            series2.Name = "Cooling";
            this.chart_ch.Series.Add(series1);
            this.chart_ch.Series.Add(series2);
            this.chart_ch.Size = new System.Drawing.Size(1028, 478);
            this.chart_ch.TabIndex = 0;
            this.chart_ch.Text = "chart";
            // 
            // actual_indicator_H_lbl
            // 
            this.actual_indicator_H_lbl.AutoSize = true;
            this.actual_indicator_H_lbl.Location = new System.Drawing.Point(7, 16);
            this.actual_indicator_H_lbl.Name = "actual_indicator_H_lbl";
            this.actual_indicator_H_lbl.Size = new System.Drawing.Size(120, 13);
            this.actual_indicator_H_lbl.TabIndex = 1;
            this.actual_indicator_H_lbl.Text = "Actual Indicator H (mm):";
            this.actual_indicator_H_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mitutoyo_raw_value_lbl
            // 
            this.mitutoyo_raw_value_lbl.AutoSize = true;
            this.mitutoyo_raw_value_lbl.Location = new System.Drawing.Point(969, 551);
            this.mitutoyo_raw_value_lbl.Name = "mitutoyo_raw_value_lbl";
            this.mitutoyo_raw_value_lbl.Size = new System.Drawing.Size(87, 13);
            this.mitutoyo_raw_value_lbl.TabIndex = 2;
            this.mitutoyo_raw_value_lbl.Text = "Mitutoyo_1_Raw";
            // 
            // mitutoyo_actual_value_lbl
            // 
            this.mitutoyo_actual_value_lbl.AutoSize = true;
            this.mitutoyo_actual_value_lbl.Location = new System.Drawing.Point(142, 16);
            this.mitutoyo_actual_value_lbl.Name = "mitutoyo_actual_value_lbl";
            this.mitutoyo_actual_value_lbl.Size = new System.Drawing.Size(47, 13);
            this.mitutoyo_actual_value_lbl.TabIndex = 3;
            this.mitutoyo_actual_value_lbl.Text = "Mitutoyo";
            this.mitutoyo_actual_value_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sto_lbl
            // 
            this.sto_lbl.AutoSize = true;
            this.sto_lbl.Location = new System.Drawing.Point(100, 16);
            this.sto_lbl.Name = "sto_lbl";
            this.sto_lbl.Size = new System.Drawing.Size(43, 13);
            this.sto_lbl.TabIndex = 4;
            this.sto_lbl.Text = "Sto (°C)";
            this.sto_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sto_height_captured_lbl
            // 
            this.sto_height_captured_lbl.AutoSize = true;
            this.sto_height_captured_lbl.Location = new System.Drawing.Point(134, 16);
            this.sto_height_captured_lbl.Name = "sto_height_captured_lbl";
            this.sto_height_captured_lbl.Size = new System.Drawing.Size(33, 13);
            this.sto_height_captured_lbl.TabIndex = 5;
            this.sto_height_captured_lbl.Text = "value";
            this.sto_height_captured_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actual_indicator_H_lbl);
            this.groupBox1.Controls.Add(this.mitutoyo_actual_value_lbl);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 38);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sto_target_lbl);
            this.groupBox2.Controls.Add(this.sto_lbl);
            this.groupBox2.Location = new System.Drawing.Point(240, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 38);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // sto_target_lbl
            // 
            this.sto_target_lbl.AutoSize = true;
            this.sto_target_lbl.Location = new System.Drawing.Point(15, 16);
            this.sto_target_lbl.Name = "sto_target_lbl";
            this.sto_target_lbl.Size = new System.Drawing.Size(81, 13);
            this.sto_target_lbl.TabIndex = 5;
            this.sto_target_lbl.Text = "STO at 0.1 mm:";
            this.sto_target_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.sto_height_captured_lbl);
            this.groupBox3.Location = new System.Drawing.Point(395, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 38);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sto Captured Value (mm):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.str_lbl);
            this.groupBox4.Controls.Add(this.str_target_lbl);
            this.groupBox4.Location = new System.Drawing.Point(596, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 38);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // str_lbl
            // 
            this.str_lbl.AutoSize = true;
            this.str_lbl.Location = new System.Drawing.Point(95, 16);
            this.str_lbl.Name = "str_lbl";
            this.str_lbl.Size = new System.Drawing.Size(62, 13);
            this.str_lbl.TabIndex = 9;
            this.str_lbl.Text = "           (mm)";
            this.str_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // str_target_lbl
            // 
            this.str_target_lbl.AutoSize = true;
            this.str_target_lbl.Location = new System.Drawing.Point(6, 16);
            this.str_target_lbl.Name = "str_target_lbl";
            this.str_target_lbl.Size = new System.Drawing.Size(55, 13);
            this.str_target_lbl.TabIndex = 5;
            this.str_target_lbl.Text = "Str at (°C):";
            this.str_target_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1034, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Hide";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.str_max_lbl);
            this.groupBox5.Controls.Add(this.str_max_target_lbl);
            this.groupBox5.Location = new System.Drawing.Point(760, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(188, 38);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // str_max_lbl
            // 
            this.str_max_lbl.AutoSize = true;
            this.str_max_lbl.Location = new System.Drawing.Point(123, 15);
            this.str_max_lbl.Name = "str_max_lbl";
            this.str_max_lbl.Size = new System.Drawing.Size(65, 13);
            this.str_max_lbl.TabIndex = 9;
            this.str_max_lbl.Text = "            (mm)";
            this.str_max_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // str_max_target_lbl
            // 
            this.str_max_target_lbl.AutoSize = true;
            this.str_max_target_lbl.Location = new System.Drawing.Point(6, 16);
            this.str_max_target_lbl.Name = "str_max_target_lbl";
            this.str_max_target_lbl.Size = new System.Drawing.Size(78, 13);
            this.str_max_target_lbl.TabIndex = 5;
            this.str_max_target_lbl.Text = "Str Max at (°C):";
            this.str_max_target_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.hyst_lbl);
            this.groupBox6.Controls.Add(this.hyst_target_lbl);
            this.groupBox6.Location = new System.Drawing.Point(954, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(131, 38);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            // 
            // hyst_lbl
            // 
            this.hyst_lbl.AutoSize = true;
            this.hyst_lbl.Location = new System.Drawing.Point(76, 16);
            this.hyst_lbl.Name = "hyst_lbl";
            this.hyst_lbl.Size = new System.Drawing.Size(36, 13);
            this.hyst_lbl.TabIndex = 9;
            this.hyst_lbl.Text = " value";
            // 
            // hyst_target_lbl
            // 
            this.hyst_target_lbl.AutoSize = true;
            this.hyst_target_lbl.Location = new System.Drawing.Point(6, 16);
            this.hyst_target_lbl.Name = "hyst_target_lbl";
            this.hyst_target_lbl.Size = new System.Drawing.Size(54, 13);
            this.hyst_target_lbl.TabIndex = 5;
            this.hyst_target_lbl.Text = "Hyst. (°C):";
            this.hyst_target_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 573);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mitutoyo_raw_value_lbl);
            this.Controls.Add(this.chart_ch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Chart";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_ch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ch;
        private System.Windows.Forms.Label actual_indicator_H_lbl;
        private System.Windows.Forms.Label mitutoyo_raw_value_lbl;
        private System.Windows.Forms.Label mitutoyo_actual_value_lbl;
        public System.Windows.Forms.Label sto_lbl;
        public System.Windows.Forms.Label sto_height_captured_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label sto_target_lbl;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label str_lbl;
        public System.Windows.Forms.Label str_target_lbl;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Label str_max_lbl;
        public System.Windows.Forms.Label str_max_target_lbl;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.Label hyst_lbl;
        public System.Windows.Forms.Label hyst_target_lbl;
    }
}