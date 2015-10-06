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
            this.btnOpenService = new System.Windows.Forms.Button();
            this.btnGetService = new System.Windows.Forms.Button();
            this.txtSecurity = new System.Windows.Forms.TextBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnHistoryRequest = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartSession
            // 
            this.btnStartSession.Location = new System.Drawing.Point(24, 23);
            this.btnStartSession.Margin = new System.Windows.Forms.Padding(6);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(208, 44);
            this.btnStartSession.TabIndex = 0;
            this.btnStartSession.Text = "Start Session";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.sessionStartBtn_Click);
            // 
            // btnStopSession
            // 
            this.btnStopSession.Enabled = false;
            this.btnStopSession.Location = new System.Drawing.Point(24, 79);
            this.btnStopSession.Margin = new System.Windows.Forms.Padding(6);
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(208, 44);
            this.btnStopSession.TabIndex = 0;
            this.btnStopSession.Text = "Stop Session";
            this.btnStopSession.UseVisualStyleBackColor = true;
            this.btnStopSession.Click += new System.EventHandler(this.btnStopSession_Click);
            // 
            // btnOpenService
            // 
            this.btnOpenService.Enabled = false;
            this.btnOpenService.Location = new System.Drawing.Point(24, 135);
            this.btnOpenService.Margin = new System.Windows.Forms.Padding(6);
            this.btnOpenService.Name = "btnOpenService";
            this.btnOpenService.Size = new System.Drawing.Size(208, 44);
            this.btnOpenService.TabIndex = 0;
            this.btnOpenService.Text = "Open Service";
            this.btnOpenService.UseVisualStyleBackColor = true;
            this.btnOpenService.Click += new System.EventHandler(this.btnOpenService_Click);
            // 
            // btnGetService
            // 
            this.btnGetService.Enabled = false;
            this.btnGetService.Location = new System.Drawing.Point(24, 190);
            this.btnGetService.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetService.Name = "btnGetService";
            this.btnGetService.Size = new System.Drawing.Size(208, 44);
            this.btnGetService.TabIndex = 0;
            this.btnGetService.Text = "Get Service";
            this.btnGetService.UseVisualStyleBackColor = true;
            this.btnGetService.Click += new System.EventHandler(this.btnGetService_Click);
            // 
            // txtSecurity
            // 
            this.txtSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurity.Location = new System.Drawing.Point(298, 23);
            this.txtSecurity.Margin = new System.Windows.Forms.Padding(6);
            this.txtSecurity.Name = "txtSecurity";
            this.txtSecurity.Size = new System.Drawing.Size(824, 62);
            this.txtSecurity.TabIndex = 1;
            this.txtSecurity.Text = "sia sp Equity";
            this.txtSecurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSecurity.TextChanged += new System.EventHandler(this.txtSecurity_TextChanged);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Enabled = false;
            this.btnRequest.Location = new System.Drawing.Point(298, 135);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(6);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(238, 100);
            this.btnRequest.TabIndex = 2;
            this.btnRequest.Text = "Make request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(298, 273);
            this.txtResult.Margin = new System.Windows.Forms.Padding(6);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(824, 83);
            this.txtResult.TabIndex = 3;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHistoryRequest
            // 
            this.btnHistoryRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoryRequest.Enabled = false;
            this.btnHistoryRequest.Location = new System.Drawing.Point(596, 135);
            this.btnHistoryRequest.Margin = new System.Windows.Forms.Padding(6);
            this.btnHistoryRequest.Name = "btnHistoryRequest";
            this.btnHistoryRequest.Size = new System.Drawing.Size(238, 100);
            this.btnHistoryRequest.TabIndex = 2;
            this.btnHistoryRequest.Text = "Make history request";
            this.btnHistoryRequest.UseVisualStyleBackColor = true;
            this.btnHistoryRequest.Click += new System.EventHandler(this.btnHistoryRequest_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.Enabled = false;
            this.btnSubscribe.Location = new System.Drawing.Point(888, 135);
            this.btnSubscribe.Margin = new System.Windows.Forms.Padding(6);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(238, 100);
            this.btnSubscribe.TabIndex = 2;
            this.btnSubscribe.Text = "Real-time";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 654);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.btnHistoryRequest);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.txtSecurity);
            this.Controls.Add(this.btnGetService);
            this.Controls.Add(this.btnOpenService);
            this.Controls.Add(this.btnStopSession);
            this.Controls.Add(this.btnStartSession);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSession;
        private System.Windows.Forms.Button btnStopSession;
        private System.Windows.Forms.Button btnOpenService;
        private System.Windows.Forms.Button btnGetService;
        private System.Windows.Forms.TextBox txtSecurity;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnHistoryRequest;
        private System.Windows.Forms.Button btnSubscribe;
    }
}

