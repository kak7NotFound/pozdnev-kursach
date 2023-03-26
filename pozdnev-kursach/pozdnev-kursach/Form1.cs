using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pozdnev_kursach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.database = new DataBase();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManualForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TestingForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}