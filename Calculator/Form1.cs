using System;
using System.Windows.Forms;
using System.Text;

namespace Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /*
         *  Basic variables 
         */
        double digit1 = 0, digit2 = 0, result = 0;
        char operation = '+';
        bool operationChoosed = false;
        StringBuilder currentState = new StringBuilder();

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text.IndexOf((sender as Button).Text) == -1)
                CalcTextBox.Text += (sender as Button).Text;            
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != "0")
            {
                CalcTextBox.Text += (sender as Button).Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text == "0")
                CalcTextBox.Text = (sender as Button).Text;
            else
                CalcTextBox.Text += (sender as Button).Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (operationChoosed)
            {
                Calculate();
                digit1 = result;
                digit2 = 0;
                result = 0;
                currentState.Append(CalcTextBox.Text);
                currentState.Append((sender as Button).Text);
                DisplayBox.Text = currentState.ToString();
            }
            else
            {
                try
                {
                    digit1 = Convert.ToDouble(CalcTextBox.Text);
                    currentState.Append(CalcTextBox.Text);
                    currentState.Append((sender as Button).Text);
                    DisplayBox.Text = currentState.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CalcTextBox.Clear();
                    return;
                }

                CalcTextBox.Clear();
                operation = (sender as Button).Text[0];
                operationChoosed = true;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                digit2 = Convert.ToDouble(CalcTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            Calculate();

            operationChoosed = false;

            currentState.Clear();
            DisplayBox.Clear();

            CalcTextBox.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            CalcTextBox.Text = "0";
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != "")
                if (CalcTextBox.Text[0] == '-')
                    CalcTextBox.Text = CalcTextBox.Text.Remove(0, 1);
                else CalcTextBox.Text = '-' + CalcTextBox.Text;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != "")
                CalcTextBox.Text = CalcTextBox.Text.Remove(CalcTextBox.Text.Length - 1, 1);
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            digit1 = 0;
            digit2 = 0;
            result = 0;
            operationChoosed = false;
            currentState.Clear();
            DisplayBox.Clear();
            CalcTextBox.Text = "0";
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator © 2015", "About Calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void Calculate()
        {
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
        }

        
    }
}
