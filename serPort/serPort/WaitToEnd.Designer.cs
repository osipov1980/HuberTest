namespace serPort
{
    partial class WaitToEnd
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
            this.message_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message_lbl
            // 
            this.message_lbl.AutoSize = true;
            this.message_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message_lbl.Location = new System.Drawing.Point(97, 62);
            this.message_lbl.Name = "message_lbl";
            this.message_lbl.Size = new System.Drawing.Size(119, 24);
            this.message_lbl.TabIndex = 0;
            this.message_lbl.Text = "Please wait...";
            // 
            // WaitToEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 153);
            this.Controls.Add(this.message_lbl);
            this.Name = "WaitToEnd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message_lbl;
    }
}