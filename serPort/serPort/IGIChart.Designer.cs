namespace serPort
{
    partial class IGIChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_ch = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.actual_indicator_H_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_actual_value_lbl = new System.Windows.Forms.Label();
            this.mitutoyo_raw_value_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_ch
            // 
            chartArea6.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea6.AxisX.Title = "Temperature [°C]";
            chartArea6.AxisY.Title = "Stroke [mm]";
            chartArea6.Name = "ChartArea1";
            this.chart_ch.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart_ch.Legends.Add(legend6);
            this.chart_ch.Location = new System.Drawing.Point(30, 65);
            this.chart_ch.Name = "chart_ch";
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Color = System.Drawing.Color.Red;
            series11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            series11.Legend = "Legend1";
            series11.Name = "Heat";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Color = System.Drawing.Color.Blue;
            series12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            series12.Legend = "Legend1";
            series12.Name = "Cooling";
            this.chart_ch.Series.Add(series11);
            this.chart_ch.Series.Add(series12);
            this.chart_ch.Size = new System.Drawing.Size(1028, 478);
            this.chart_ch.TabIndex = 1;
            this.chart_ch.Text = "chart";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1010, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Hide";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actual_indicator_H_lbl);
            this.groupBox1.Controls.Add(this.mitutoyo_actual_value_lbl);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 38);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
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
            // mitutoyo_raw_value_lbl
            // 
            this.mitutoyo_raw_value_lbl.AutoSize = true;
            this.mitutoyo_raw_value_lbl.Location = new System.Drawing.Point(969, 551);
            this.mitutoyo_raw_value_lbl.Name = "mitutoyo_raw_value_lbl";
            this.mitutoyo_raw_value_lbl.Size = new System.Drawing.Size(87, 13);
            this.mitutoyo_raw_value_lbl.TabIndex = 13;
            this.mitutoyo_raw_value_lbl.Text = "Mitutoyo_1_Raw";
            // 
            // IGIChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 573);
            this.Controls.Add(this.mitutoyo_raw_value_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chart_ch);
            this.Name = "IGIChart";
            this.Text = "IGIChart";
            ((System.ComponentModel.ISupportInitialize)(this.chart_ch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ch;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label actual_indicator_H_lbl;
        private System.Windows.Forms.Label mitutoyo_actual_value_lbl;
        private System.Windows.Forms.Label mitutoyo_raw_value_lbl;
    }
}