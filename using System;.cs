using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaptchaGenerator
{
    public partial class Form1 : Form
    {
        private string currentCaptchaAnswer = "";

        public Form1()
        {
            InitializeComponent();
            cmbCaptchaType.Items.AddRange(new string[] { "Text-Based", "Image-Based", "Math-Based", "reCAPTCHA Checkbox" });
            cmbCaptchaType.SelectedIndex = 0;
            GenerateCaptcha();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void cmbCaptchaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string selected = cmbCaptchaType.SelectedItem.ToString();
            bool isValid = false;

            if (selected == "reCAPTCHA Checkbox")
            {
                isValid = chkRecaptcha.Checked;
            }
            else
            {
                isValid = txtUserInput.Text.Trim().Equals(currentCaptchaAnswer, StringComparison.OrdinalIgnoreCase);
            }

            lblResult.Text = isValid ? "✅ CAPTCHA Passed!" : "❌ CAPTCHA Failed!";
            lblResult.ForeColor = isValid ? Color.Green : Color.Red;
        }

        private void GenerateCaptcha()
        {
            string selected = cmbCaptchaType.SelectedItem.ToString();
            txtUserInput.Visible = selected != "reCAPTCHA Checkbox";
            chkRecaptcha.Visible = selected == "reCAPTCHA Checkbox";
            picCaptcha.Visible = selected == "Image-Based";
            lblInstruction.Visible = true;

            switch (selected)
            {
                case "Text-Based":
                    lblInstruction.Text = "Enter the characters below:";
                    currentCaptchaAnswer = GenerateRandomText(6);
                    picCaptcha.Image = DrawCaptchaImage(currentCaptchaAnswer);
                    break;

                case "Image-Based":
                    lblInstruction.Text = "Enter the text in the image:";
                    currentCaptchaAnswer = GenerateRandomText(5);
                    picCaptcha.Image = DrawCaptchaImage(currentCaptchaAnswer);
                    break;

                case "Math-Based":
                    lblInstruction.Text = "Solve the math expression:";
                    Random rnd = new Random();
                    int a = rnd.Next(1, 10);
                    int b = rnd.Next(1, 10);
                    currentCaptchaAnswer = (a + b).ToString();
                    picCaptcha.Image = DrawCaptchaImage($"{a} + {b} = ?");
                    break;

                case "reCAPTCHA Checkbox":
                    lblInstruction.Text = "Please check the box to confirm you're not a robot:";
                    chkRecaptcha.Checked = false;
                    break;
            }

            txtUserInput.Clear();
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random rnd = new Random();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
                result[i] = chars[rnd.Next(chars.Length)];
            return new string(result);
        }

        private Bitmap DrawCaptchaImage(string text)
        {
            Bitmap bmp = new Bitmap(200, 60);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Random rnd = new Random();
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.DrawString(text, font, brush, new PointF(10, 10));
                }

                // Add noise lines
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(Pens.Gray, rnd.Next(bmp.Width), rnd.Next(bmp.Height),
                               rnd.Next(bmp.Width), rnd.Next(bmp.Height));
                }
            }
            return bmp;
        }
    }
}
