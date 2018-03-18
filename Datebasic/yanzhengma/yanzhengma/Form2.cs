using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“scaourseDataSet1.student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter1.Fill(this.scaourseDataSet1.student);
            // TODO: 这行代码将数据加载到表“scaourseDataSet.student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.scaourseDataSet.student);

        }
    }
}
