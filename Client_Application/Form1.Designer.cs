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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dOrderTable = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lProfit = new System.Windows.Forms.Label();
            this.bStop = new System.Windows.Forms.Button();
            this.bTradeAuto = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.bStartApp = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PricePlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.ltime = new System.Windows.Forms.Label();
            this.runningTIme = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cBuyingSelling = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dOrderTable)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricePlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBuyingSelling)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Controls.Add(this.dOrderTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1113, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Order Book";
            // 
            // dOrderTable
            // 
            this.dOrderTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dOrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dOrderTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.Symbol,
            this.Price,
            this.Quantity,
            this.Side});
            this.dOrderTable.Location = new System.Drawing.Point(3, 3);
            this.dOrderTable.Name = "dOrderTable";
            this.dOrderTable.RowTemplate.Height = 28;
            this.dOrderTable.Size = new System.Drawing.Size(1107, 617);
            this.dOrderTable.TabIndex = 0;
            // 
            // TimeStamp
            // 
            this.TimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeStamp.HeaderText = "Time Stamp";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            // 
            // Symbol
            // 
            this.Symbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Side
            // 
            this.Side.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Side.HeaderText = "Side";
            this.Side.Name = "Side";
            this.Side.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.lPosition);
            this.tabPage1.Controls.Add(this.runningTIme);
            this.tabPage1.Controls.Add(this.ltime);
            this.tabPage1.Controls.Add(this.lProfit);
            this.tabPage1.Controls.Add(this.bStop);
            this.tabPage1.Controls.Add(this.bTradeAuto);
            this.tabPage1.Controls.Add(this.tbDisplay);
            this.tabPage1.Controls.Add(this.bStartApp);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1113, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // lProfit
            // 
            this.lProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lProfit.AutoSize = true;
            this.lProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProfit.Location = new System.Drawing.Point(819, 427);
            this.lProfit.Name = "lProfit";
            this.lProfit.Size = new System.Drawing.Size(135, 36);
            this.lProfit.TabIndex = 5;
            this.lProfit.Text = "Profit: $0";
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.BackColor = System.Drawing.Color.Gainsboro;
            this.bStop.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.Location = new System.Drawing.Point(819, 272);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(288, 128);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bTradeAuto
            // 
            this.bTradeAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bTradeAuto.BackColor = System.Drawing.Color.Gainsboro;
            this.bTradeAuto.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTradeAuto.Location = new System.Drawing.Point(819, 138);
            this.bTradeAuto.Name = "bTradeAuto";
            this.bTradeAuto.Size = new System.Drawing.Size(288, 128);
            this.bTradeAuto.TabIndex = 3;
            this.bTradeAuto.Text = "TRADE ";
            this.bTradeAuto.UseVisualStyleBackColor = false;
            this.bTradeAuto.Click += new System.EventHandler(this.bTradeAuto_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbDisplay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplay.ForeColor = System.Drawing.Color.Gold;
            this.tbDisplay.Location = new System.Drawing.Point(6, 3);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(807, 614);
            this.tbDisplay.TabIndex = 3;
            // 
            // bStartApp
            // 
            this.bStartApp.BackColor = System.Drawing.Color.Gainsboro;
            this.bStartApp.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStartApp.Location = new System.Drawing.Point(819, 6);
            this.bStartApp.Name = "bStartApp";
            this.bStartApp.Size = new System.Drawing.Size(288, 126);
            this.bStartApp.TabIndex = 0;
            this.bStartApp.Text = "GET DATA";
            this.bStartApp.UseVisualStyleBackColor = false;
            this.bStartApp.Click += new System.EventHandler(this.bStartApp_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 656);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.PricePlot);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1113, 623);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decomposition";
            // 
            // PricePlot
            // 
            this.PricePlot.BackColor = System.Drawing.Color.DimGray;
            this.PricePlot.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            chartArea3.BackColor = System.Drawing.Color.Snow;
            chartArea3.Name = "ChartArea1";
            chartArea4.AlignWithChartArea = "ChartArea1";
            chartArea4.BackColor = System.Drawing.Color.Snow;
            chartArea4.Name = "ChartArea2";
            chartArea5.AlignWithChartArea = "ChartArea2";
            chartArea5.BackColor = System.Drawing.Color.Snow;
            chartArea5.Name = "ChartArea3";
            this.PricePlot.ChartAreas.Add(chartArea3);
            this.PricePlot.ChartAreas.Add(chartArea4);
            this.PricePlot.ChartAreas.Add(chartArea5);
            this.PricePlot.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.BackColor = System.Drawing.Color.Snow;
            legend3.DockedToChartArea = "ChartArea1";
            legend3.MaximumAutoSize = 20F;
            legend3.Name = "Legend1";
            legend4.BackColor = System.Drawing.Color.Snow;
            legend4.DockedToChartArea = "ChartArea2";
            legend4.Name = "Legend2";
            legend5.BackColor = System.Drawing.Color.Snow;
            legend5.DockedToChartArea = "ChartArea3";
            legend5.Name = "Legend3";
            this.PricePlot.Legends.Add(legend3);
            this.PricePlot.Legends.Add(legend4);
            this.PricePlot.Legends.Add(legend5);
            this.PricePlot.Location = new System.Drawing.Point(3, 3);
            this.PricePlot.Name = "PricePlot";
            series8.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series8.BackImageTransparentColor = System.Drawing.Color.White;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Blue;
            series8.Legend = "Legend1";
            series8.Name = "MFM";
            series8.YValuesPerPoint = 4;
            series9.ChartArea = "ChartArea2";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Color = System.Drawing.Color.Indigo;
            series9.Legend = "Legend2";
            series9.Name = "Trend";
            series10.ChartArea = "ChartArea3";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Color = System.Drawing.Color.Magenta;
            series10.Legend = "Legend3";
            series10.Name = "Signal";
            this.PricePlot.Series.Add(series8);
            this.PricePlot.Series.Add(series9);
            this.PricePlot.Series.Add(series10);
            this.PricePlot.Size = new System.Drawing.Size(1107, 617);
            this.PricePlot.TabIndex = 0;
            this.PricePlot.Text = "Price";
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // ltime
            // 
            this.ltime.AutoSize = true;
            this.ltime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltime.Location = new System.Drawing.Point(821, 574);
            this.ltime.Name = "ltime";
            this.ltime.Size = new System.Drawing.Size(162, 26);
            this.ltime.TabIndex = 6;
            this.ltime.Text = "Current Time:";
            // 
            // runningTIme
            // 
            this.runningTIme.AutoSize = true;
            this.runningTIme.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runningTIme.Location = new System.Drawing.Point(821, 532);
            this.runningTIme.Name = "runningTIme";
            this.runningTIme.Size = new System.Drawing.Size(172, 26);
            this.runningTIme.TabIndex = 7;
            this.runningTIme.Text = "Running Time: ";
            // 
            // lPosition
            // 
            this.lPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPosition.Location = new System.Drawing.Point(819, 476);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(156, 36);
            this.lPosition.TabIndex = 8;
            this.lPosition.Text = "Position: 0";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Silver;
            this.tabPage4.Controls.Add(this.cBuyingSelling);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1113, 623);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chart";
            // 
            // cBuyingSelling
            // 
            this.cBuyingSelling.BackColor = System.Drawing.Color.DimGray;
            this.cBuyingSelling.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.cBuyingSelling.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Snow;
            chartArea1.Name = "ChartArea1";
            chartArea2.AlignWithChartArea = "ChartArea1";
            chartArea2.BackColor = System.Drawing.Color.Snow;
            chartArea2.Name = "ChartArea2";
            chartArea2.Visible = false;
            this.cBuyingSelling.ChartAreas.Add(chartArea1);
            this.cBuyingSelling.ChartAreas.Add(chartArea2);
            this.cBuyingSelling.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Snow;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.Name = "Legend1";
            legend2.BackColor = System.Drawing.Color.Snow;
            legend2.DockedToChartArea = "ChartArea2";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend2.Name = "Legend2";
            this.cBuyingSelling.Legends.Add(legend1);
            this.cBuyingSelling.Legends.Add(legend2);
            this.cBuyingSelling.Location = new System.Drawing.Point(3, 3);
            this.cBuyingSelling.Name = "cBuyingSelling";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "MFM";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.DarkViolet;
            series2.Legend = "Legend1";
            series2.Name = "50 Tick Moving Average";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Gold;
            series3.Legend = "Legend1";
            series3.Name = "200 Tick Moving Average";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series4.Color = System.Drawing.Color.Green;
            series4.Legend = "Legend1";
            series4.Name = "Buying Point";
            series4.YValuesPerPoint = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Selling Points";
            series6.ChartArea = "ChartArea2";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend2";
            series6.Name = "MACD Line";
            series7.ChartArea = "ChartArea2";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.OrangeRed;
            series7.Legend = "Legend2";
            series7.Name = "Signal Line";
            this.cBuyingSelling.Series.Add(series1);
            this.cBuyingSelling.Series.Add(series2);
            this.cBuyingSelling.Series.Add(series3);
            this.cBuyingSelling.Series.Add(series4);
            this.cBuyingSelling.Series.Add(series5);
            this.cBuyingSelling.Series.Add(series6);
            this.cBuyingSelling.Series.Add(series7);
            this.cBuyingSelling.Size = new System.Drawing.Size(1107, 617);
            this.cBuyingSelling.TabIndex = 0;
            this.cBuyingSelling.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 681);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Client";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dOrderTable)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PricePlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cBuyingSelling)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lProfit;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bTradeAuto;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button bStartApp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dOrderTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Side;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart PricePlot;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label ltime;
        private System.Windows.Forms.Label runningTIme;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart cBuyingSelling;
    }
}

