using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CaptchaGenerator
{
    public partial class Form1 : Form
    {
        private string currentCaptcha = "";
        private Random random = new Random();

        private List<PictureBox> captchaPictures = new List<PictureBox>();
        private HashSet<int> correctIndices = new HashSet<int>();
        private HashSet<int> selectedIndices = new HashSet<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string imagesFolder = Application.StartupPath + @"\CaptchaImages";
            if (!Directory.Exists(imagesFolder) || Directory.GetFiles(imagesFolder, "*.jpg").Length < 9)
            {
                CreateCaptchaImages();
            }

            rbText.Checked = true;
            GenerateCaptcha();
            this.BackColor = Color.WhiteSmoke;
            panelCaptchaImages.Left = (this.ClientSize.Width - panelCaptchaImages.Width) / 2;
            lblInstruction.Left = (this.ClientSize.Width - lblInstruction.Width) / 2;
            btnSubmit.Left = panelCaptchaImages.Left;
            btnRefresh.Left = btnSubmit.Right + 10;


        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruction.Visible = false;
            GenerateCaptcha();
            ClearInputs();
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            GenerateCaptcha();
            ClearInputs();
        }

        private void rbMath_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruction.Visible = false;
            GenerateCaptcha();
            ClearInputs();
        }

        private void rbCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruction.Visible = false;
            GenerateCaptcha();
            ClearInputs();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbImage.Checked)
            {
                if (selectedIndices.SetEquals(correctIndices) && correctIndices.Count > 0)
                {
                    labelResult.Text = "✅ Correct! Good job!";
                    labelResult.ForeColor = Color.Green;
                }
                else
                {
                    labelResult.Text = "❌ Incorrect, try again.";
                    labelResult.ForeColor = Color.Red;
                }
            }
            else if (rbCheckbox.Checked)
            {
                if (cbCaptcha.Checked)
                {
                    labelResult.Text = "✅ Correct! Checkbox selected.";
                    labelResult.ForeColor = Color.Green;
                }
                else
                {
                    labelResult.Text = "❌ Please check the box.";
                    labelResult.ForeColor = Color.Red;
                }
            }
            else
            {
                if (txtAnswer.Text.Trim() == currentCaptcha)
                {
                    labelResult.Text = "✅ Correct!";
                    labelResult.ForeColor = Color.Green;
                }
                else
                {
                    labelResult.Text = "❌ Incorrect CAPTCHA!";
                    labelResult.ForeColor = Color.Red;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
            ClearInputs();
            labelResult.Text = "";
        }

        private void ClearInputs()
        {
            txtAnswer.Text = "";
            cbCaptcha.Checked = false;
            selectedIndices.Clear();
        }

        private void GenerateCaptcha()
        {
            // إخفاء كل حاجة مبدئيًا
            lblCaptcha.Visible = false;
            pbCaptcha.Visible = false;
            cbCaptcha.Visible = false;
            panelCaptchaImages.Visible = false;
            lblInstruction.Visible = false;
            txtAnswer.Visible = false;  // 👈 أخفي صندوق الكتابة
            txtAnswer.Text = "";        // 🧼 امسح اللي فيه

            if (rbText.Checked)
            {
                txtAnswer.Visible = true;
                GenerateTextCaptcha();
            }
            else if (rbImage.Checked)
            {
                GenerateImageCaptcha();
            }
            else if (rbMath.Checked)
            {
                txtAnswer.Visible = true;
                GenerateMathCaptcha();
            }
            else if (rbCheckbox.Checked)
            {
                GenerateCheckboxCaptcha();
            }
        }


        private void GenerateTextCaptcha()
        {
            ClearOldCaptcha();

            currentCaptcha = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 6; i++)
                currentCaptcha += chars[random.Next(chars.Length)];

            lblCaptcha.Text = currentCaptcha;
            lblCaptcha.Font = new Font("Arial", 24, FontStyle.Bold);
            lblCaptcha.Visible = true;
            pbCaptcha.Visible = true;
        }

        private void GenerateImageCaptcha()
        {
            ClearOldCaptcha();

            string imagesFolder = Application.StartupPath + @"\CaptchaImages";
            string[] allImages = Directory.GetFiles(imagesFolder, "*.jpg");

            if (allImages.Length < 9)
            {
                MessageBox.Show("Please add at least 9 images inside CaptchaImages folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            panelCaptchaImages.Visible = true;
            panelCaptchaImages.Enabled = true;
            panelCaptchaImages.BringToFront();

            correctIndices.Clear();
            selectedIndices.Clear();

            List<string> selectedImages = new List<string>();
            while (selectedImages.Count < 9)
            {
                string img = allImages[random.Next(allImages.Length)];
                if (!selectedImages.Contains(img))
                    selectedImages.Add(img);
            }

            for (int i = 0; i < 9; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 100;
                pb.Height = 100;
                pb.Left = (i % 3) * 110;
                pb.Top = (i / 3) * 110;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromFile(selectedImages[i]);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Tag = i;

                // ✅ مهم جدًا
                pb.Cursor = Cursors.Hand;
                pb.Enabled = true;
                pb.BringToFront();
                pb.Click += new EventHandler(Pb_Click);

                panelCaptchaImages.Controls.Add(pb);
                captchaPictures.Add(pb);

                if (Path.GetFileName(selectedImages[i]).ToLower().Contains("apple"))
                    correctIndices.Add(i);
            }

            lblInstruction.Text = "👉 Please select all images containing APPLE 🍎";
            lblInstruction.Font = new Font("Arial", 14, FontStyle.Bold);
            lblInstruction.Visible = true;
        }


        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int index = (int)pb.Tag;

            if (selectedIndices.Contains(index))
            {
                selectedIndices.Remove(index);
                pb.BackColor = Color.Transparent;
                pb.Padding = new Padding(0); // شيل أي تأثير
            }
            else
            {
                selectedIndices.Add(index);
                pb.BackColor = Color.LimeGreen;
                pb.Padding = new Padding(3); // يخلي اللون باين
            }

            // ✅ للتأكيد خلي الصورة تتحدث
            pb.Invalidate();
        }




        private void ClearOldCaptcha()
        {
            foreach (var pb in captchaPictures)
            {
                panelCaptchaImages.Controls.Remove(pb);
                pb.Dispose();
            }
            captchaPictures.Clear();
        }

        private void GenerateMathCaptcha()
        {
            ClearOldCaptcha();

            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            currentCaptcha = (num1 + num2).ToString();
            lblCaptcha.Text = $"{num1} + {num2} = ?";
            lblCaptcha.Font = new Font("Arial", 24, FontStyle.Bold);
            lblCaptcha.Visible = true;
            pbCaptcha.Visible = true;
        }

        private void GenerateCheckboxCaptcha()
        {
            ClearOldCaptcha();
            cbCaptcha.Checked = false;
            cbCaptcha.Visible = true;
        }

        private void CreateCaptchaImages()
        {
            string outputFolder = Application.StartupPath + @"\CaptchaImages";
            Directory.CreateDirectory(outputFolder);

            string[] labels = {
                "Apple", "Apple", "Apple",
                "Banana", "Grapes", "Lemon",
                "Orange", "Strawberry", "Watermelon"
            };

            for (int i = 0; i < labels.Length; i++)
            {
                using (Bitmap bmp = new Bitmap(100, 100))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);

                        using (Font font = new Font("Arial", 12, FontStyle.Bold))
                        using (Brush brush = new SolidBrush(Color.Black))
                        {
                            StringFormat sf = new StringFormat()
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
                            g.DrawString(labels[i], font, brush, new RectangleF(0, 0, bmp.Width, bmp.Height), sf);
                        }
                    }

                    string fileName = $"{labels[i].ToLower()}{i + 1}.jpg";
                    bmp.Save(Path.Combine(outputFolder, fileName), ImageFormat.Jpeg);
                }
            }

            Thread.Sleep(500);
        }

        private void panelCaptchaImages_Paint(object sender, PaintEventArgs e) { }
    }
}
