namespace MoonJumpHack
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStatusTitle = new System.Windows.Forms.Label();
            this.labelProcessStatus = new System.Windows.Forms.Label();
            this.labelSwitchStatus = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.timerOperation = new System.Windows.Forms.Timer(this.components);
            this.timerProcessScan = new System.Windows.Forms.Timer(this.components);
            this.checkBoxRetailCD = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(55, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(282, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Rayman 2 Moon Jump Hack";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatusTitle
            // 
            this.labelStatusTitle.AutoSize = true;
            this.labelStatusTitle.Location = new System.Drawing.Point(12, 45);
            this.labelStatusTitle.Name = "labelStatusTitle";
            this.labelStatusTitle.Size = new System.Drawing.Size(77, 13);
            this.labelStatusTitle.TabIndex = 1;
            this.labelStatusTitle.Text = "Current Status:";
            // 
            // labelProcessStatus
            // 
            this.labelProcessStatus.AutoSize = true;
            this.labelProcessStatus.Location = new System.Drawing.Point(12, 72);
            this.labelProcessStatus.Name = "labelProcessStatus";
            this.labelProcessStatus.Size = new System.Drawing.Size(78, 13);
            this.labelProcessStatus.TabIndex = 2;
            this.labelProcessStatus.Text = "Process Status";
            // 
            // labelSwitchStatus
            // 
            this.labelSwitchStatus.AutoSize = true;
            this.labelSwitchStatus.Location = new System.Drawing.Point(12, 94);
            this.labelSwitchStatus.Name = "labelSwitchStatus";
            this.labelSwitchStatus.Size = new System.Drawing.Size(101, 13);
            this.labelSwitchStatus.TabIndex = 3;
            this.labelSwitchStatus.Text = "Hack Switch Status";
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(12, 127);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(336, 65);
            this.labelHelp.TabIndex = 4;
            this.labelHelp.Text = resources.GetString("labelHelp.Text");
            // 
            // timerOperation
            // 
            this.timerOperation.Interval = 10;
            this.timerOperation.Tick += new System.EventHandler(this.timerOperation_Tick);
            // 
            // timerProcessScan
            // 
            this.timerProcessScan.Interval = 5000;
            this.timerProcessScan.Tick += new System.EventHandler(this.timerProcessScan_Tick);
            // 
            // checkBoxRetailCD
            // 
            this.checkBoxRetailCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRetailCD.AutoSize = true;
            this.checkBoxRetailCD.Location = new System.Drawing.Point(301, 44);
            this.checkBoxRetailCD.Name = "checkBoxRetailCD";
            this.checkBoxRetailCD.Size = new System.Drawing.Size(71, 17);
            this.checkBoxRetailCD.TabIndex = 5;
            this.checkBoxRetailCD.Text = "Retail CD";
            this.checkBoxRetailCD.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.Controls.Add(this.checkBoxRetailCD);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelSwitchStatus);
            this.Controls.Add(this.labelProcessStatus);
            this.Controls.Add(this.labelStatusTitle);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Rayman 2 Moon Jump Hack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelStatusTitle;
        private System.Windows.Forms.Label labelProcessStatus;
        private System.Windows.Forms.Label labelSwitchStatus;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Timer timerOperation;
        private System.Windows.Forms.Timer timerProcessScan;
        private System.Windows.Forms.CheckBox checkBoxRetailCD;
    }
}

