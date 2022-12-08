namespace baseChart
{
    partial class SearchForm
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
            this.lblSearchStartDate = new System.Windows.Forms.Label();
            this.lblSearchEndDate = new System.Windows.Forms.Label();
            this.tbSearchStartDate = new System.Windows.Forms.TextBox();
            this.tbSearchEndDate = new System.Windows.Forms.TextBox();
            this.monthCalendarSearch = new System.Windows.Forms.MonthCalendar();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearchStartDate
            // 
            this.lblSearchStartDate.AutoSize = true;
            this.lblSearchStartDate.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchStartDate.Location = new System.Drawing.Point(29, 34);
            this.lblSearchStartDate.Name = "lblSearchStartDate";
            this.lblSearchStartDate.Size = new System.Drawing.Size(90, 19);
            this.lblSearchStartDate.TabIndex = 0;
            this.lblSearchStartDate.Text = "起始日期:";
            // 
            // lblSearchEndDate
            // 
            this.lblSearchEndDate.AutoSize = true;
            this.lblSearchEndDate.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearchEndDate.Location = new System.Drawing.Point(29, 72);
            this.lblSearchEndDate.Name = "lblSearchEndDate";
            this.lblSearchEndDate.Size = new System.Drawing.Size(90, 19);
            this.lblSearchEndDate.TabIndex = 1;
            this.lblSearchEndDate.Text = "結束日期:";
            // 
            // tbSearchStartDate
            // 
            this.tbSearchStartDate.Location = new System.Drawing.Point(125, 31);
            this.tbSearchStartDate.Name = "tbSearchStartDate";
            this.tbSearchStartDate.Size = new System.Drawing.Size(136, 22);
            this.tbSearchStartDate.TabIndex = 2;
            this.tbSearchStartDate.Enter += new System.EventHandler(this.tbSearchStartDate_Enter);
            // 
            // tbSearchEndDate
            // 
            this.tbSearchEndDate.Location = new System.Drawing.Point(125, 72);
            this.tbSearchEndDate.Name = "tbSearchEndDate";
            this.tbSearchEndDate.Size = new System.Drawing.Size(136, 22);
            this.tbSearchEndDate.TabIndex = 3;
            this.tbSearchEndDate.Enter += new System.EventHandler(this.tbSearchEndDate_Enter);
            // 
            // monthCalendarSearch
            // 
            this.monthCalendarSearch.Location = new System.Drawing.Point(273, 31);
            this.monthCalendarSearch.MaxSelectionCount = 1;
            this.monthCalendarSearch.Name = "monthCalendarSearch";
            this.monthCalendarSearch.ShowToday = false;
            this.monthCalendarSearch.ShowTodayCircle = false;
            this.monthCalendarSearch.TabIndex = 4;
            this.monthCalendarSearch.Visible = false;
            this.monthCalendarSearch.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarSearch_DateSelected);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(125, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 34);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "確認";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 226);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.monthCalendarSearch);
            this.Controls.Add(this.tbSearchEndDate);
            this.Controls.Add(this.tbSearchStartDate);
            this.Controls.Add(this.lblSearchEndDate);
            this.Controls.Add(this.lblSearchStartDate);
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchStartDate;
        private System.Windows.Forms.Label lblSearchEndDate;
        private System.Windows.Forms.TextBox tbSearchStartDate;
        private System.Windows.Forms.TextBox tbSearchEndDate;
        private System.Windows.Forms.MonthCalendar monthCalendarSearch;
        private System.Windows.Forms.Button btnOK;
    }
}