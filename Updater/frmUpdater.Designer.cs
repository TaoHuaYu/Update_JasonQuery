namespace Updater
{
    partial class frmUpdater
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdater));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.picStep1 = new System.Windows.Forms.PictureBox();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.btnUpdateProduction = new C1.Win.C1Input.C1Button();
            this.btnClose = new C1.Win.C1Input.C1Button();
            this.txtList = new C1.Win.C1Input.C1TextBox();
            this.txtFrom = new C1.Win.C1Input.C1TextBox();
            this.picChecked = new System.Windows.Forms.PictureBox();
            this.picUnchecked = new System.Windows.Forms.PictureBox();
            this.picStep4 = new System.Windows.Forms.PictureBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new C1.Win.C1Input.C1TextBox();
            this.picStep2 = new System.Windows.Forms.PictureBox();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.pbDownloadStatus = new System.Windows.Forms.ProgressBar();
            this.chkLaunchJQ = new System.Windows.Forms.CheckBox();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.rdoUpdateProduction = new System.Windows.Forms.RadioButton();
            this.rdoUpdatePreview = new System.Windows.Forms.RadioButton();
            this.btnCancel = new C1.Win.C1Input.C1Button();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.picStep3 = new System.Windows.Forms.PictureBox();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.grpComplete = new System.Windows.Forms.GroupBox();
            this.btnUpdatePreview = new C1.Win.C1Input.C1Button();
            this.txtStep2 = new System.Windows.Forms.RichTextBox();
            this.txtStep3 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStep1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnchecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep3)).BeginInit();
            this.grpComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdatePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Download and Update";
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.ForeColor = System.Drawing.Color.Black;
            this.lblStep1.Location = new System.Drawing.Point(40, 45);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(265, 16);
            this.lblStep1.TabIndex = 1;
            this.lblStep1.Text = "Step 1: Manually close all running JasonQuery";
            // 
            // picStep1
            // 
            this.picStep1.Location = new System.Drawing.Point(20, 45);
            this.picStep1.Name = "picStep1";
            this.picStep1.Size = new System.Drawing.Size(16, 16);
            this.picStep1.TabIndex = 2;
            this.picStep1.TabStop = false;
            // 
            // lblStep4
            // 
            this.lblStep4.AutoSize = true;
            this.lblStep4.Location = new System.Drawing.Point(40, 237);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(273, 16);
            this.lblStep4.TabIndex = 3;
            this.lblStep4.Text = "Step 4: Update files and Delete temporary filles";
            // 
            // tmrCheck
            // 
            this.tmrCheck.Interval = 4000;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // btnUpdateProduction
            // 
            this.btnUpdateProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateProduction.Location = new System.Drawing.Point(362, 360);
            this.btnUpdateProduction.Name = "btnUpdateProduction";
            this.btnUpdateProduction.Size = new System.Drawing.Size(185, 29);
            this.btnUpdateProduction.TabIndex = 11;
            this.btnUpdateProduction.Text = "&Update (Production version)";
            this.btnUpdateProduction.UseVisualStyleBackColor = true;
            this.btnUpdateProduction.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnUpdateProduction.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnUpdateProduction.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(561, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 73);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtList
            // 
            this.txtList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtList.Location = new System.Drawing.Point(43, 64);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ReadOnly = true;
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtList.Size = new System.Drawing.Size(594, 86);
            this.txtList.TabIndex = 13;
            this.txtList.Tag = null;
            this.txtList.TextDetached = true;
            this.txtList.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.txtList.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrom.Location = new System.Drawing.Point(43, 278);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtFrom.Size = new System.Drawing.Size(594, 21);
            this.txtFrom.TabIndex = 14;
            this.txtFrom.Tag = null;
            this.txtFrom.TextDetached = true;
            this.txtFrom.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.txtFrom.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // picChecked
            // 
            this.picChecked.Image = ((System.Drawing.Image)(resources.GetObject("picChecked.Image")));
            this.picChecked.Location = new System.Drawing.Point(505, 253);
            this.picChecked.Name = "picChecked";
            this.picChecked.Size = new System.Drawing.Size(16, 16);
            this.picChecked.TabIndex = 87;
            this.picChecked.TabStop = false;
            this.picChecked.Visible = false;
            // 
            // picUnchecked
            // 
            this.picUnchecked.Image = ((System.Drawing.Image)(resources.GetObject("picUnchecked.Image")));
            this.picUnchecked.Location = new System.Drawing.Point(527, 253);
            this.picUnchecked.Name = "picUnchecked";
            this.picUnchecked.Size = new System.Drawing.Size(16, 16);
            this.picUnchecked.TabIndex = 88;
            this.picUnchecked.TabStop = false;
            this.picUnchecked.Visible = false;
            // 
            // picStep4
            // 
            this.picStep4.Location = new System.Drawing.Point(20, 237);
            this.picStep4.Name = "picStep4";
            this.picStep4.Size = new System.Drawing.Size(16, 16);
            this.picStep4.TabIndex = 89;
            this.picStep4.TabStop = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(40, 260);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 16);
            this.lblFrom.TabIndex = 92;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(40, 306);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(252, 16);
            this.lblTo.TabIndex = 94;
            this.lblTo.Text = "To: (The path where JasonQuery.exe exists.)";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTo.Location = new System.Drawing.Point(43, 324);
            this.txtTo.Name = "txtTo";
            this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtTo.Size = new System.Drawing.Size(594, 21);
            this.txtTo.TabIndex = 93;
            this.txtTo.Tag = null;
            this.txtTo.TextDetached = true;
            this.txtTo.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.txtTo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // picStep2
            // 
            this.picStep2.Location = new System.Drawing.Point(20, 163);
            this.picStep2.Name = "picStep2";
            this.picStep2.Size = new System.Drawing.Size(16, 16);
            this.picStep2.TabIndex = 96;
            this.picStep2.TabStop = false;
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Location = new System.Drawing.Point(40, 163);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(312, 16);
            this.lblStep2.TabIndex = 95;
            this.lblStep2.Text = "Step 2: Download JasonQuery.zip to temporary folder";
            this.lblStep2.Visible = false;
            // 
            // pbDownloadStatus
            // 
            this.pbDownloadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownloadStatus.Location = new System.Drawing.Point(43, 183);
            this.pbDownloadStatus.Name = "pbDownloadStatus";
            this.pbDownloadStatus.Size = new System.Drawing.Size(525, 20);
            this.pbDownloadStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDownloadStatus.TabIndex = 97;
            // 
            // chkLaunchJQ
            // 
            this.chkLaunchJQ.AutoSize = true;
            this.chkLaunchJQ.Checked = true;
            this.chkLaunchJQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLaunchJQ.Location = new System.Drawing.Point(23, 22);
            this.chkLaunchJQ.Name = "chkLaunchJQ";
            this.chkLaunchJQ.Size = new System.Drawing.Size(136, 20);
            this.chkLaunchJQ.TabIndex = 98;
            this.chkLaunchJQ.Text = "Launch JasonQuery";
            this.chkLaunchJQ.UseVisualStyleBackColor = true;
            // 
            // rdoUpdateProduction
            // 
            this.rdoUpdateProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoUpdateProduction.AutoSize = true;
            this.rdoUpdateProduction.BackColor = System.Drawing.Color.Transparent;
            this.rdoUpdateProduction.ForeColor = System.Drawing.Color.Black;
            this.rdoUpdateProduction.Location = new System.Drawing.Point(341, 367);
            this.rdoUpdateProduction.Name = "rdoUpdateProduction";
            this.rdoUpdateProduction.Size = new System.Drawing.Size(14, 13);
            this.rdoUpdateProduction.TabIndex = 106;
            this.c1ThemeController1.SetTheme(this.rdoUpdateProduction, "(default)");
            this.rdoUpdateProduction.UseVisualStyleBackColor = false;
            this.rdoUpdateProduction.CheckedChanged += new System.EventHandler(this.rdoUpdateProduction_CheckedChanged);
            // 
            // rdoUpdatePreview
            // 
            this.rdoUpdatePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoUpdatePreview.AutoSize = true;
            this.rdoUpdatePreview.BackColor = System.Drawing.Color.Transparent;
            this.rdoUpdatePreview.Enabled = false;
            this.rdoUpdatePreview.ForeColor = System.Drawing.Color.Black;
            this.rdoUpdatePreview.Location = new System.Drawing.Point(341, 410);
            this.rdoUpdatePreview.Name = "rdoUpdatePreview";
            this.rdoUpdatePreview.Size = new System.Drawing.Size(14, 13);
            this.rdoUpdatePreview.TabIndex = 107;
            this.c1ThemeController1.SetTheme(this.rdoUpdatePreview, "(default)");
            this.rdoUpdatePreview.UseVisualStyleBackColor = false;
            this.rdoUpdatePreview.CheckedChanged += new System.EventHandler(this.rdoUpdatePreview_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(574, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 29);
            this.btnCancel.TabIndex = 99;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.BackColor = System.Drawing.SystemColors.Control;
            this.lblStep3.ForeColor = System.Drawing.Color.Black;
            this.lblStep3.Location = new System.Drawing.Point(40, 214);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(286, 16);
            this.lblStep3.TabIndex = 100;
            this.lblStep3.Text = "Step 3: Unzip JasonQuery.zip to temporary folder";
            this.lblStep3.Visible = false;
            // 
            // picStep3
            // 
            this.picStep3.Location = new System.Drawing.Point(20, 214);
            this.picStep3.Name = "picStep3";
            this.picStep3.Size = new System.Drawing.Size(16, 16);
            this.picStep3.TabIndex = 101;
            this.picStep3.TabStop = false;
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Enabled = false;
            this.chkClose.Location = new System.Drawing.Point(23, 48);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(132, 20);
            this.chkClose.TabIndex = 102;
            this.chkClose.Text = "Close the program";
            // 
            // grpComplete
            // 
            this.grpComplete.BackColor = System.Drawing.SystemColors.Control;
            this.grpComplete.Controls.Add(this.chkLaunchJQ);
            this.grpComplete.Controls.Add(this.chkClose);
            this.grpComplete.ForeColor = System.Drawing.Color.Black;
            this.grpComplete.Location = new System.Drawing.Point(43, 358);
            this.grpComplete.Name = "grpComplete";
            this.grpComplete.Size = new System.Drawing.Size(267, 75);
            this.grpComplete.TabIndex = 103;
            this.grpComplete.TabStop = false;
            this.grpComplete.Text = "After the update is complete";
            // 
            // btnUpdatePreview
            // 
            this.btnUpdatePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePreview.ForeColor = System.Drawing.Color.Green;
            this.btnUpdatePreview.Location = new System.Drawing.Point(362, 404);
            this.btnUpdatePreview.Name = "btnUpdatePreview";
            this.btnUpdatePreview.Size = new System.Drawing.Size(185, 29);
            this.btnUpdatePreview.TabIndex = 104;
            this.btnUpdatePreview.Text = "Update (Preview version)";
            this.btnUpdatePreview.UseVisualStyleBackColor = true;
            this.btnUpdatePreview.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnUpdatePreview.Click += new System.EventHandler(this.btnUpdatePreview_Click);
            // 
            // txtStep2
            // 
            this.txtStep2.BackColor = System.Drawing.SystemColors.Control;
            this.txtStep2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStep2.Location = new System.Drawing.Point(43, 163);
            this.txtStep2.Name = "txtStep2";
            this.txtStep2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtStep2.Size = new System.Drawing.Size(528, 16);
            this.txtStep2.TabIndex = 108;
            this.txtStep2.Text = "";
            // 
            // txtStep3
            // 
            this.txtStep3.BackColor = System.Drawing.SystemColors.Control;
            this.txtStep3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStep3.Location = new System.Drawing.Point(43, 214);
            this.txtStep3.Name = "txtStep3";
            this.txtStep3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtStep3.Size = new System.Drawing.Size(528, 16);
            this.txtStep3.TabIndex = 109;
            this.txtStep3.Text = "";
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.txtStep3);
            this.Controls.Add(this.txtStep2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rdoUpdatePreview);
            this.Controls.Add(this.rdoUpdateProduction);
            this.Controls.Add(this.btnUpdatePreview);
            this.Controls.Add(this.grpComplete);
            this.Controls.Add(this.picStep3);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.pbDownloadStatus);
            this.Controls.Add(this.picStep2);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.picStep4);
            this.Controls.Add(this.picUnchecked);
            this.Controls.Add(this.picChecked);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.picStep1);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnUpdateProduction);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater - JasonQuery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdater_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStep1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnchecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep3)).EndInit();
            this.grpComplete.ResumeLayout(false);
            this.grpComplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdatePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.PictureBox picStep1;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Timer tmrCheck;
        private C1.Win.C1Input.C1Button btnUpdateProduction;
        private C1.Win.C1Input.C1Button btnClose;
        private C1.Win.C1Input.C1TextBox txtList;
        private C1.Win.C1Input.C1TextBox txtFrom;
        private System.Windows.Forms.PictureBox picChecked;
        private System.Windows.Forms.PictureBox picUnchecked;
        private System.Windows.Forms.PictureBox picStep4;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private C1.Win.C1Input.C1TextBox txtTo;
        private System.Windows.Forms.PictureBox picStep2;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.ProgressBar pbDownloadStatus;
        private System.Windows.Forms.CheckBox chkLaunchJQ;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Input.C1Button btnCancel;
        private System.Windows.Forms.PictureBox picStep3;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.GroupBox grpComplete;
        private C1.Win.C1Input.C1Button btnUpdatePreview;
        private System.Windows.Forms.RadioButton rdoUpdateProduction;
        private System.Windows.Forms.RadioButton rdoUpdatePreview;
        private System.Windows.Forms.RichTextBox txtStep2;
        private System.Windows.Forms.RichTextBox txtStep3;
    }
}

