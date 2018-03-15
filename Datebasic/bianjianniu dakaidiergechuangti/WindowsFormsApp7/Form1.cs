using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usename, password;
            usename = textBox1.Text;
            password = textBox2.Text;
            if (usename == "123" && password == "abc")
            {
                MessageBox.Show("登录成功！");
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
                MessageBox.Show("请检查用户名或密码！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
