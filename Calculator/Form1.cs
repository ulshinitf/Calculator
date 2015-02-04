using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double digit1 = 0, digit2 = 0, result = 0;
        char operation = '+';

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            try
            {
                digit1 = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                return;
            }

            textBox1.Clear();
            operation = (sender as Button).Text[0];
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                digit2 = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                return;
            }

            switch (operation)
            {
                case '+': result = digit1 + digit2;
                    break;
                case '-': result = digit1 - digit2;
                    break;
                case 'x': result = digit1 * digit2;
                    break;
                case '/': result = digit1 / digit2;
                    break;
            }

            textBox1.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                if (textBox1.Text[0] == '-')
                    textBox1.Text = textBox1.Text.Remove(0, 1);
                else textBox1.Text = '-' + textBox1.Text;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator © 2015", "About Calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
