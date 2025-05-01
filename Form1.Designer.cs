namespace CaptchaGenerator
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
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbCheckbox = new System.Windows.Forms.RadioButton();
            this.rbImage = new System.Windows.Forms.RadioButton();
            this.rbMath = new System.Windows.Forms.RadioButton();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.pbCaptcha = new System.Windows.Forms.PictureBox();
            this.cbCaptcha = new System.Windows.Forms.CheckBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelCaptchaImages = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(172, 10);
            this.rbText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(99, 17);
            this.rbText.TabIndex = 0;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text CAPTCHA";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.Click += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbCheckbox
            // 
            this.rbCheckbox.AutoSize = true;
            this.rbCheckbox.Location = new System.Drawing.Point(170, 108);
            this.rbCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCheckbox.Name = "rbCheckbox";
            this.rbCheckbox.Size = new System.Drawing.Size(126, 17);
            this.rbCheckbox.TabIndex = 1;
            this.rbCheckbox.TabStop = true;
            this.rbCheckbox.Text = "Checkbox CAPTCHA";
            this.rbCheckbox.UseVisualStyleBackColor = true;
            this.rbCheckbox.Click += new System.EventHandler(this.rbCheckbox_CheckedChanged);
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.Location = new System.Drawing.Point(170, 42);
            this.rbImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(107, 17);
            this.rbImage.TabIndex = 2;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "Image CAPTCHA";
            this.rbImage.UseVisualStyleBackColor = true;
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbImage_CheckedChanged);
            this.rbImage.Click += new System.EventHandler(this.rbImage_CheckedChanged);
            // 
            // rbMath
            // 
            this.rbMath.AutoSize = true;
            this.rbMath.Location = new System.Drawing.Point(170, 74);
            this.rbMath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMath.Name = "rbMath";
            this.rbMath.Size = new System.Drawing.Size(102, 17);
            this.rbMath.TabIndex = 3;
            this.rbMath.TabStop = true;
            this.rbMath.Text = "Math CAPTCHA";
            this.rbMath.UseVisualStyleBackColor = true;
            this.rbMath.Click += new System.EventHandler(this.rbMath_CheckedChanged);
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Location = new System.Drawing.Point(405, 392);
            this.lblCaptcha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(35, 13);
            this.lblCaptcha.TabIndex = 4;
            this.lblCaptcha.Text = "label1";
            // 
            // pbCaptcha
            // 
            this.pbCaptcha.Location = new System.Drawing.Point(707, 64);
            this.pbCaptcha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new System.Drawing.Size(120, 83);
            this.pbCaptcha.TabIndex = 5;
            this.pbCaptcha.TabStop = false;
            this.pbCaptcha.Visible = false;
            // 
            // cbCaptcha
            // 
            this.cbCaptcha.AutoSize = true;
            this.cbCaptcha.Location = new System.Drawing.Point(723, 202);
            this.cbCaptcha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbCaptcha.Name = "cbCaptcha";
            this.cbCaptcha.Size = new System.Drawing.Size(93, 17);
            this.cbCaptcha.TabIndex = 6;
            this.cbCaptcha.Text = "I\'m not a robot";
            this.cbCaptcha.UseVisualStyleBackColor = true;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(367, 370);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(257, 20);
            this.txtAnswer.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(367, 427);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(56, 19);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(427, 427);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 19);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelCaptchaImages
            // 
            this.panelCaptchaImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaptchaImages.Location = new System.Drawing.Point(353, 30);
            this.panelCaptchaImages.Name = "panelCaptchaImages";
            this.panelCaptchaImages.Size = new System.Drawing.Size(324, 329);
            this.panelCaptchaImages.TabIndex = 10;
            this.panelCaptchaImages.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCaptchaImages_Paint);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(350, 9);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(35, 13);
            this.lblInstruction.TabIndex = 12;
            this.lblInstruction.Text = "label1";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.Location = new System.Drawing.Point(393, 483);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(57, 20);
            this.labelResult.TabIndex = 13;
            this.labelResult.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1026, 553);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.panelCaptchaImages);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbCaptcha);
            this.Controls.Add(this.pbCaptcha);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.rbMath);
            this.Controls.Add(this.rbImage);
            this.Controls.Add(this.rbCheckbox);
            this.Controls.Add(this.rbText);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Submit";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbCheckbox;
        private System.Windows.Forms.RadioButton rbImage;
        private System.Windows.Forms.RadioButton rbMath;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.PictureBox pbCaptcha;
        private System.Windows.Forms.CheckBox cbCaptcha;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelCaptchaImages;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label labelResult;
    }
}

