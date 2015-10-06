namespace Basic
{
    partial class Form1
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
            this.btnStartSession = new System.Windows.Forms.Button();
            this.btnStopSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartSession
            // 
            this.btnStartSession.Location = new System.Drawing.Point(12, 12);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(104, 23);
            this.btnStartSession.TabIndex = 0;
            this.btnStartSession.Text = "Start Session";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.sessionStartBtn_Click);
            // 
            // btnStopSession
            // 
            this.btnStopSession.Enabled = false;
            this.btnStopSession.Location = new System.Drawing.Point(12, 41);
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(104, 23);
            this.btnStopSession.TabIndex = 0;
            this.btnStopSession.Text = "Stop Session";
            this.btnStopSession.UseVisualStyleBackColor = true;
            this.btnStopSession.Click += new System.EventHandler(this.btnStopSession_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 363);
            this.Controls.Add(this.btnStopSession);
            this.Controls.Add(this.btnStartSession);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartSession;
        private System.Windows.Forms.Button btnStopSession;
    }
}

