namespace Client_Application
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
            this.components = new System.ComponentModel.Container();
            this.bStartApp = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.bTradeAuto = new System.Windows.Forms.Button();
            this.lProfit = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bStartApp
            // 
            this.bStartApp.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStartApp.Location = new System.Drawing.Point(795, 12);
            this.bStartApp.Name = "bStartApp";
            this.bStartApp.Size = new System.Drawing.Size(251, 126);
            this.bStartApp.TabIndex = 0;
            this.bStartApp.Text = "GET DATA";
            this.bStartApp.UseVisualStyleBackColor = true;
            this.bStartApp.Click += new System.EventHandler(this.bStartApp_Click);
            // 
            // bStop
            // 
            this.bStop.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.Location = new System.Drawing.Point(795, 278);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(251, 128);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbDisplay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplay.ForeColor = System.Drawing.Color.Gold;
            this.tbDisplay.Location = new System.Drawing.Point(12, 12);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(747, 528);
            this.tbDisplay.TabIndex = 2;
            // 
            // bTradeAuto
            // 
            this.bTradeAuto.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTradeAuto.Location = new System.Drawing.Point(795, 144);
            this.bTradeAuto.Name = "bTradeAuto";
            this.bTradeAuto.Size = new System.Drawing.Size(251, 128);
            this.bTradeAuto.TabIndex = 3;
            this.bTradeAuto.Text = "TRADE ";
            this.bTradeAuto.UseVisualStyleBackColor = true;
            this.bTradeAuto.Click += new System.EventHandler(this.bTradeAuto_Click);
            // 
            // lProfit
            // 
            this.lProfit.AutoSize = true;
            this.lProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProfit.Location = new System.Drawing.Point(795, 442);
            this.lProfit.Name = "lProfit";
            this.lProfit.Size = new System.Drawing.Size(215, 55);
            this.lProfit.TabIndex = 4;
            this.lProfit.Text = "Profit: $0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 591);
            this.Controls.Add(this.lProfit);
            this.Controls.Add(this.bTradeAuto);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStartApp);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartApp;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bTradeAuto;
        private System.Windows.Forms.Label lProfit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Timer timer2;
    }
}

