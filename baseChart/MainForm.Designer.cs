namespace baseChart
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTest = new System.Windows.Forms.ToolStripButton();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.chartStoreData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.btnRecent10Data = new System.Windows.Forms.Button();
            this.btnLast10Days = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblStoreDataInfo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStoreData)).BeginInit();
            this.panelLeftBottom.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtnCreate,
            this.toolStripButtonTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtnCreate
            // 
            this.toolStripbtnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripbtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtnCreate.Image")));
            this.toolStripbtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtnCreate.Name = "toolStripbtnCreate";
            this.toolStripbtnCreate.Size = new System.Drawing.Size(35, 22);
            this.toolStripbtnCreate.Text = "建立";
            this.toolStripbtnCreate.Click += new System.EventHandler(this.toolStripbtnCreate_Click);
            // 
            // toolStripButtonTest
            // 
            this.toolStripButtonTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTest.Image")));
            this.toolStripButtonTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTest.Name = "toolStripButtonTest";
            this.toolStripButtonTest.Size = new System.Drawing.Size(34, 22);
            this.toolStripButtonTest.Text = "Test";
            this.toolStripButtonTest.Click += new System.EventHandler(this.toolStripButtonTest_Click);
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.AutoSize = true;
            this.panelLeftTop.Controls.Add(this.chartStoreData);
            this.panelLeftTop.Location = new System.Drawing.Point(12, 28);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(498, 292);
            this.panelLeftTop.TabIndex = 1;
            // 
            // chartStoreData
            // 
            this.chartStoreData.BackColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "時間";
            chartArea1.AxisY.Title = "人數";
            chartArea1.Name = "ChartArea1";
            this.chartStoreData.ChartAreas.Add(chartArea1);
            this.chartStoreData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartStoreData.Legends.Add(legend1);
            this.chartStoreData.Location = new System.Drawing.Point(0, 0);
            this.chartStoreData.Name = "chartStoreData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.LegendText = "客人數";
            series1.Name = "SeriesStoreData";
            this.chartStoreData.Series.Add(series1);
            this.chartStoreData.Size = new System.Drawing.Size(498, 292);
            this.chartStoreData.TabIndex = 0;
            this.chartStoreData.Text = "統計";
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeftBottom.Controls.Add(this.btnRecent10Data);
            this.panelLeftBottom.Controls.Add(this.btnLast10Days);
            this.panelLeftBottom.Location = new System.Drawing.Point(0, 338);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(516, 115);
            this.panelLeftBottom.TabIndex = 2;
            // 
            // btnRecent10Data
            // 
            this.btnRecent10Data.Location = new System.Drawing.Point(117, 15);
            this.btnRecent10Data.Name = "btnRecent10Data";
            this.btnRecent10Data.Size = new System.Drawing.Size(85, 36);
            this.btnRecent10Data.TabIndex = 1;
            this.btnRecent10Data.Text = "最新10筆";
            this.btnRecent10Data.UseVisualStyleBackColor = true;
            this.btnRecent10Data.Click += new System.EventHandler(this.btnRecent10Data_Click);
            // 
            // btnLast10Days
            // 
            this.btnLast10Days.Location = new System.Drawing.Point(15, 15);
            this.btnLast10Days.Name = "btnLast10Days";
            this.btnLast10Days.Size = new System.Drawing.Size(85, 36);
            this.btnLast10Days.TabIndex = 0;
            this.btnLast10Days.Text = "最新10天內";
            this.btnLast10Days.UseVisualStyleBackColor = true;
            this.btnLast10Days.Click += new System.EventHandler(this.btnLast10Days_Click);
            // 
            // panelRight
            // 
            this.panelRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelRight.AutoSize = true;
            this.panelRight.Controls.Add(this.lblStoreDataInfo);
            this.panelRight.Location = new System.Drawing.Point(516, 28);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(272, 410);
            this.panelRight.TabIndex = 3;
            // 
            // lblStoreDataInfo
            // 
            this.lblStoreDataInfo.AutoSize = true;
            this.lblStoreDataInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStoreDataInfo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStoreDataInfo.Location = new System.Drawing.Point(0, 0);
            this.lblStoreDataInfo.Name = "lblStoreDataInfo";
            this.lblStoreDataInfo.Padding = new System.Windows.Forms.Padding(20);
            this.lblStoreDataInfo.Size = new System.Drawing.Size(40, 56);
            this.lblStoreDataInfo.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeftBottom);
            this.Controls.Add(this.panelLeftTop);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelLeftTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStoreData)).EndInit();
            this.panelLeftBottom.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtnCreate;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Panel panelLeftBottom;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonTest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStoreData;
        private System.Windows.Forms.Button btnRecent10Data;
        private System.Windows.Forms.Button btnLast10Days;
        private System.Windows.Forms.Label lblStoreDataInfo;
    }
}

