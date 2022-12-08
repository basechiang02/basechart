namespace baseChart
{
    partial class DataCreateForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelRightDown = new System.Windows.Forms.Panel();
            this.flowLayoutPanelRightDown = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearchInfo = new System.Windows.Forms.Panel();
            this.pbCloseSearch = new System.Windows.Forms.PictureBox();
            this.lblSearchEndDate = new System.Windows.Forms.Label();
            this.lblSearchStartDate = new System.Windows.Forms.Label();
            this.lblSearchEndDateTitle = new System.Windows.Forms.Label();
            this.lblSearchStartDateTitle = new System.Windows.Forms.Label();
            this.panelRightMiddle = new System.Windows.Forms.Panel();
            this.tbPageNumber = new System.Windows.Forms.TextBox();
            this.lblDataShow = new System.Windows.Forms.Label();
            this.panelRightUp = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnShowDate = new System.Windows.Forms.Button();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.tbCustomerCount = new System.Windows.Forms.TextBox();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.rbPageDecrement = new CustomControlBase.RoundButton();
            this.rbPageIncrement = new CustomControlBase.RoundButton();
            this.rbCollaspe = new CustomControlBase.RoundButton();
            this.updateUI1 = new baseChart.UpdateUI();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelRightDown.SuspendLayout();
            this.flowLayoutPanelRightDown.SuspendLayout();
            this.panelSearchInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseSearch)).BeginInit();
            this.panelRightMiddle.SuspendLayout();
            this.panelRightUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.OldLace;
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightDown);
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightMiddle);
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightUp);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.splitContainerMain.Size = new System.Drawing.Size(800, 450);
            this.splitContainerMain.SplitterDistance = 165;
            this.splitContainerMain.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnCreateNew);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(149, 460);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.AutoSize = true;
            this.btnCreateNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreateNew.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateNew.Location = new System.Drawing.Point(3, 0);
            this.btnCreateNew.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCreateNew.MaximumSize = new System.Drawing.Size(180, 60);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(127, 60);
            this.btnCreateNew.TabIndex = 2;
            this.btnCreateNew.Text = "新增";
            this.btnCreateNew.UseVisualStyleBackColor = false;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUpdate.Location = new System.Drawing.Point(3, 80);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.btnUpdate.MaximumSize = new System.Drawing.Size(180, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(127, 60);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(3, 160);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.btnDelete.MaximumSize = new System.Drawing.Size(180, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 60);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch.Location = new System.Drawing.Point(3, 240);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.btnSearch.MaximumSize = new System.Drawing.Size(180, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 60);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜尋";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(3, 320);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.btnClose.MaximumSize = new System.Drawing.Size(180, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 60);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "關閉";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelRightDown
            // 
            this.panelRightDown.AutoScroll = true;
            this.panelRightDown.Controls.Add(this.flowLayoutPanelRightDown);
            this.panelRightDown.Controls.Add(this.panelSearchInfo);
            this.panelRightDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightDown.Location = new System.Drawing.Point(10, 254);
            this.panelRightDown.Name = "panelRightDown";
            this.panelRightDown.Padding = new System.Windows.Forms.Padding(10);
            this.panelRightDown.Size = new System.Drawing.Size(611, 186);
            this.panelRightDown.TabIndex = 7;
            // 
            // flowLayoutPanelRightDown
            // 
            this.flowLayoutPanelRightDown.AutoScroll = true;
            this.flowLayoutPanelRightDown.AutoSize = true;
            this.flowLayoutPanelRightDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanelRightDown.Controls.Add(this.updateUI1);
            this.flowLayoutPanelRightDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelRightDown.Location = new System.Drawing.Point(10, 43);
            this.flowLayoutPanelRightDown.Name = "flowLayoutPanelRightDown";
            this.flowLayoutPanelRightDown.Size = new System.Drawing.Size(574, 166);
            this.flowLayoutPanelRightDown.TabIndex = 1;
            // 
            // panelSearchInfo
            // 
            this.panelSearchInfo.BackColor = System.Drawing.Color.Khaki;
            this.panelSearchInfo.Controls.Add(this.pbCloseSearch);
            this.panelSearchInfo.Controls.Add(this.lblSearchEndDate);
            this.panelSearchInfo.Controls.Add(this.lblSearchStartDate);
            this.panelSearchInfo.Controls.Add(this.lblSearchEndDateTitle);
            this.panelSearchInfo.Controls.Add(this.lblSearchStartDateTitle);
            this.panelSearchInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchInfo.Location = new System.Drawing.Point(10, 10);
            this.panelSearchInfo.Name = "panelSearchInfo";
            this.panelSearchInfo.Size = new System.Drawing.Size(574, 33);
            this.panelSearchInfo.TabIndex = 2;
            this.panelSearchInfo.Visible = false;
            // 
            // pbCloseSearch
            // 
            this.pbCloseSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbCloseSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCloseSearch.Image = global::baseChart.Properties.Resources._106391_exit_512x512;
            this.pbCloseSearch.Location = new System.Drawing.Point(541, 3);
            this.pbCloseSearch.Name = "pbCloseSearch";
            this.pbCloseSearch.Size = new System.Drawing.Size(30, 27);
            this.pbCloseSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCloseSearch.TabIndex = 6;
            this.pbCloseSearch.TabStop = false;
            this.pbCloseSearch.Click += new System.EventHandler(this.pbCloseSearch_Click);
            // 
            // lblSearchEndDate
            // 
            this.lblSearchEndDate.AutoSize = true;
            this.lblSearchEndDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchEndDate.Location = new System.Drawing.Point(343, 8);
            this.lblSearchEndDate.Name = "lblSearchEndDate";
            this.lblSearchEndDate.Size = new System.Drawing.Size(52, 16);
            this.lblSearchEndDate.TabIndex = 5;
            this.lblSearchEndDate.Text = "label1";
            // 
            // lblSearchStartDate
            // 
            this.lblSearchStartDate.AutoSize = true;
            this.lblSearchStartDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchStartDate.Location = new System.Drawing.Point(99, 8);
            this.lblSearchStartDate.Name = "lblSearchStartDate";
            this.lblSearchStartDate.Size = new System.Drawing.Size(52, 16);
            this.lblSearchStartDate.TabIndex = 4;
            this.lblSearchStartDate.Text = "label1";
            // 
            // lblSearchEndDateTitle
            // 
            this.lblSearchEndDateTitle.AutoSize = true;
            this.lblSearchEndDateTitle.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchEndDateTitle.Location = new System.Drawing.Point(247, 6);
            this.lblSearchEndDateTitle.Name = "lblSearchEndDateTitle";
            this.lblSearchEndDateTitle.Size = new System.Drawing.Size(90, 19);
            this.lblSearchEndDateTitle.TabIndex = 3;
            this.lblSearchEndDateTitle.Text = "結束日期:";
            // 
            // lblSearchStartDateTitle
            // 
            this.lblSearchStartDateTitle.AutoSize = true;
            this.lblSearchStartDateTitle.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchStartDateTitle.Location = new System.Drawing.Point(3, 6);
            this.lblSearchStartDateTitle.Name = "lblSearchStartDateTitle";
            this.lblSearchStartDateTitle.Size = new System.Drawing.Size(90, 19);
            this.lblSearchStartDateTitle.TabIndex = 2;
            this.lblSearchStartDateTitle.Text = "起始日期:";
            // 
            // panelRightMiddle
            // 
            this.panelRightMiddle.BackColor = System.Drawing.Color.Gainsboro;
            this.panelRightMiddle.Controls.Add(this.tbPageNumber);
            this.panelRightMiddle.Controls.Add(this.rbPageDecrement);
            this.panelRightMiddle.Controls.Add(this.rbPageIncrement);
            this.panelRightMiddle.Controls.Add(this.lblDataShow);
            this.panelRightMiddle.Controls.Add(this.rbCollaspe);
            this.panelRightMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightMiddle.Location = new System.Drawing.Point(10, 220);
            this.panelRightMiddle.Name = "panelRightMiddle";
            this.panelRightMiddle.Size = new System.Drawing.Size(611, 34);
            this.panelRightMiddle.TabIndex = 13;
            // 
            // tbPageNumber
            // 
            this.tbPageNumber.Location = new System.Drawing.Point(234, 8);
            this.tbPageNumber.Name = "tbPageNumber";
            this.tbPageNumber.Size = new System.Drawing.Size(32, 22);
            this.tbPageNumber.TabIndex = 16;
            this.tbPageNumber.Text = "0";
            this.tbPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPageNumber_KeyPress);
            this.tbPageNumber.Leave += new System.EventHandler(this.tbPageNumber_Leave);
            // 
            // lblDataShow
            // 
            this.lblDataShow.AutoSize = true;
            this.lblDataShow.BackColor = System.Drawing.Color.Transparent;
            this.lblDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataShow.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDataShow.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblDataShow.Location = new System.Drawing.Point(0, 0);
            this.lblDataShow.Name = "lblDataShow";
            this.lblDataShow.Padding = new System.Windows.Forms.Padding(5);
            this.lblDataShow.Size = new System.Drawing.Size(119, 29);
            this.lblDataShow.TabIndex = 13;
            this.lblDataShow.Text = "保存的資料";
            // 
            // panelRightUp
            // 
            this.panelRightUp.Controls.Add(this.monthCalendar1);
            this.panelRightUp.Controls.Add(this.btnShowDate);
            this.panelRightUp.Controls.Add(this.tbDate);
            this.panelRightUp.Controls.Add(this.lblDate);
            this.panelRightUp.Controls.Add(this.tbCustomerCount);
            this.panelRightUp.Controls.Add(this.lblCustomerCount);
            this.panelRightUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightUp.Location = new System.Drawing.Point(10, 30);
            this.panelRightUp.Name = "panelRightUp";
            this.panelRightUp.Size = new System.Drawing.Size(611, 190);
            this.panelRightUp.TabIndex = 6;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthCalendar1.Location = new System.Drawing.Point(324, 12);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 11;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnShowDate
            // 
            this.btnShowDate.Location = new System.Drawing.Point(276, 12);
            this.btnShowDate.Name = "btnShowDate";
            this.btnShowDate.Size = new System.Drawing.Size(36, 23);
            this.btnShowDate.TabIndex = 10;
            this.btnShowDate.Text = "...";
            this.btnShowDate.UseVisualStyleBackColor = true;
            this.btnShowDate.Click += new System.EventHandler(this.btnShowDate_Click);
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(99, 12);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(158, 22);
            this.tbDate.TabIndex = 9;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(21, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(56, 16);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "日期：";
            // 
            // tbCustomerCount
            // 
            this.tbCustomerCount.Location = new System.Drawing.Point(99, 44);
            this.tbCustomerCount.Name = "tbCustomerCount";
            this.tbCustomerCount.Size = new System.Drawing.Size(158, 22);
            this.tbCustomerCount.TabIndex = 7;
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCustomerCount.Location = new System.Drawing.Point(21, 44);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(72, 16);
            this.lblCustomerCount.TabIndex = 6;
            this.lblCustomerCount.Text = "客人數：";
            // 
            // rbPageDecrement
            // 
            this.rbPageDecrement.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbPageDecrement.HoverColor = System.Drawing.SystemColors.Highlight;
            this.rbPageDecrement.Location = new System.Drawing.Point(181, 3);
            this.rbPageDecrement.Name = "rbPageDecrement";
            this.rbPageDecrement.Size = new System.Drawing.Size(50, 30);
            this.rbPageDecrement.TabIndex = 15;
            this.rbPageDecrement.Text = "-";
            this.rbPageDecrement.UseVisualStyleBackColor = false;
            this.rbPageDecrement.Click += new System.EventHandler(this.rbPageDecrement_Click);
            // 
            // rbPageIncrement
            // 
            this.rbPageIncrement.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbPageIncrement.HoverColor = System.Drawing.SystemColors.Highlight;
            this.rbPageIncrement.Location = new System.Drawing.Point(272, 2);
            this.rbPageIncrement.Name = "rbPageIncrement";
            this.rbPageIncrement.Size = new System.Drawing.Size(50, 30);
            this.rbPageIncrement.TabIndex = 14;
            this.rbPageIncrement.Text = "+";
            this.rbPageIncrement.UseVisualStyleBackColor = false;
            this.rbPageIncrement.Click += new System.EventHandler(this.rbPageIncrement_Click);
            // 
            // rbCollaspe
            // 
            this.rbCollaspe.AutoEllipsis = true;
            this.rbCollaspe.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rbCollaspe.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbCollaspe.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbCollaspe.ForeColor = System.Drawing.Color.Red;
            this.rbCollaspe.HoverColor = System.Drawing.SystemColors.Highlight;
            this.rbCollaspe.Location = new System.Drawing.Point(561, 0);
            this.rbCollaspe.Name = "rbCollaspe";
            this.rbCollaspe.Size = new System.Drawing.Size(50, 34);
            this.rbCollaspe.TabIndex = 12;
            this.rbCollaspe.Text = "⬆";
            this.rbCollaspe.UseVisualStyleBackColor = false;
            this.rbCollaspe.Click += new System.EventHandler(this.rbCollaspe_Click);
            // 
            // updateUI1
            // 
            this.updateUI1.Location = new System.Drawing.Point(3, 3);
            this.updateUI1.Name = "updateUI1";
            this.updateUI1.Size = new System.Drawing.Size(301, 160);
            this.updateUI1.TabIndex = 6;
            // 
            // DataCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerMain);
            this.DoubleBuffered = true;
            this.Name = "DataCreateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DataCreate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataCreateForm_FormClosed);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelRightDown.ResumeLayout(false);
            this.panelRightDown.PerformLayout();
            this.flowLayoutPanelRightDown.ResumeLayout(false);
            this.panelSearchInfo.ResumeLayout(false);
            this.panelSearchInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseSearch)).EndInit();
            this.panelRightMiddle.ResumeLayout(false);
            this.panelRightMiddle.PerformLayout();
            this.panelRightUp.ResumeLayout(false);
            this.panelRightUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelRightUp;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnShowDate;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox tbCustomerCount;
        private System.Windows.Forms.Label lblCustomerCount;
        private CustomControlBase.RoundButton rbCollaspe;
        private System.Windows.Forms.Panel panelRightDown;
        private System.Windows.Forms.Panel panelRightMiddle;
        private System.Windows.Forms.Label lblDataShow;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRightDown;
        private UpdateUI updateUI1;
        private System.Windows.Forms.TextBox tbPageNumber;
        private CustomControlBase.RoundButton rbPageDecrement;
        private CustomControlBase.RoundButton rbPageIncrement;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelSearchInfo;
        private System.Windows.Forms.Label lblSearchEndDateTitle;
        private System.Windows.Forms.Label lblSearchStartDateTitle;
        private System.Windows.Forms.Label lblSearchStartDate;
        private System.Windows.Forms.Label lblSearchEndDate;
        private System.Windows.Forms.PictureBox pbCloseSearch;
    }
}