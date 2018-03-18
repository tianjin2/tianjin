using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string VerifyCode = "";
        public Form1()
        {
            InitializeComponent();
            VerifyCode = MakeCode(5);
            pictureBox1.Image = CreateCodeImg(VerifyCode);
        }
        private string MakeCode(int codeLen)
        {
            if (codeLen < 1)
            {
                return string.Empty;
            }

            int number;
            string checkCode = string.Empty;
            Random random = new Random();

            for (int index = 0; index < codeLen; index++)
            {

                number = random.Next();

                if (number % 2 == 0)
                {
                    checkCode += (char)('0' + (char)(number % 10));     //生成数字
                }
                else
                {
                    checkCode += (char)('A' + (char)(number % 26));     //生成字母
                }
            }

            return checkCode;
        }
        private Image CreateCodeImg(string checkCode)
        {
            if (string.IsNullOrEmpty(checkCode))
            {
                return null;
            }

            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);

            Graphics graphic = Graphics.FromImage(image);

            try
            {
                Random random = new Random();

                graphic.Clear(Color.White);

                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;

                for (int index = 0; index < 25; index++)
                {
                    x1 = random.Next(image.Width);
                    x2 = random.Next(image.Width);
                    y1 = random.Next(image.Height);
                    y2 = random.Next(image.Height);

                    graphic.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Red, Color.DarkRed, 1.2f, true);
                graphic.DrawString(checkCode, font, brush, 2, 2);

                int x = 0;
                int y = 0;

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    x = random.Next(image.Width);
                    y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                graphic.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                return image;

            }
            finally
            {
                graphic.Dispose();
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VerifyCode = MakeCode(5);
            pictureBox1.Image = CreateCodeImg(VerifyCode);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string usename, password;
            usename = textBox1.Text;
            password = textBox2.Text;
            if (string.IsNullOrEmpty(usename))
            {
                MessageBox.Show("请输入您的账号");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入您的密码");
                return;
            }
            if (string.IsNullOrEmpty(txtVerifyCode.Text))
            {
                MessageBox.Show("请输入验证码");
                return;
            }
            
            if (txtVerifyCode.Text.Equals(VerifyCode, StringComparison.OrdinalIgnoreCase))
            {
                if (usename == "123" && password == "abc")
                {
                    MessageBox.Show("登录成功！");
                    Form2 form2 = new Form2();
                    form2.Show();

                }
                else
                {
                    message.Text="您的密码不正确，请重新输入！";
                    textBox1.Clear();
                    textBox2.Clear();
                    txtVerifyCode.Clear();
                }
            }
            else
            {
                MessageBox.Show("验证码错误!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            txtVerifyCode.Clear();
        }
    }
}
