using StandardTask2;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text.Any() ? textBox1.Text : "Empty Name";
            var greetings = Utilities.EnrichString(name);

            MessageBox.Show(greetings);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
