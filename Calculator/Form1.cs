using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

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
        private double digit1 = 0, digit2 = 0, result = 0;
        private char operation = '+';
        private bool operationChoosed = false;
        private bool operationCompleted = false;
        private StringBuilder currentState = new StringBuilder();

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text.IndexOf((sender as Button).Text) == -1)
                CalcTextBox.Text += (sender as Button).Text;            
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != "0")
            {
                if (operationCompleted)
                {
                    CalcTextBox.Text = "0";
                    DisplayBox.Clear();
                    operationCompleted = false;
                }

                CalcTextBox.Text += (sender as Button).Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (operationCompleted)
            {
                CalcTextBox.Text = "0";
                DisplayBox.Clear();
                operationCompleted = false;
            }

            if (CalcTextBox.Text == "0")
                CalcTextBox.Text = (sender as Button).Text;
            else
                CalcTextBox.Text += (sender as Button).Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (operationChoosed)
                {
                    digit2 = Convert.ToDouble(CalcTextBox.Text);
                    Calculate();
                    digit1 = result;
                }
                else
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

            currentState.Append(digit2);

            DisplayBox.Text = currentState.ToString();
            CalcTextBox.Text = result.ToString();

            currentState.Clear();
            result = 0;
            operationCompleted = true;
            operationChoosed = false;
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
            if (operationCompleted)
            {
                CalcTextBox.Text = "0";
                operationCompleted = false;
            }
            else if (CalcTextBox.Text != "")
                CalcTextBox.Text = CalcTextBox.Text.Remove(CalcTextBox.Text.Length - 1, 1);
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            digit1 = 0;
            digit2 = 0;
            result = 0;
            operationChoosed = false;
            operationCompleted = false;
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
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0: button0_Click(button0, null);
                    break;
                case Keys.D1:
                case Keys.NumPad1: button1_Click(button1, null);
                    break;
                case Keys.D2:
                case Keys.NumPad2: button1_Click(button2, null);
                    break;
                case Keys.D3:
                case Keys.NumPad3: button1_Click(button3, null);
                    break;
                case Keys.D4:
                case Keys.NumPad4: button1_Click(button4, null);
                    break;
                case Keys.D5:
                case Keys.NumPad5: button1_Click(button5, null);
                    break;
                case Keys.D6:
                case Keys.NumPad6: button1_Click(button6, null);
                    break;
                case Keys.D7:
                case Keys.NumPad7: button1_Click(button7, null);
                    break;
                case Keys.D8:
                case Keys.NumPad8: button1_Click(button8, null);
                    break;
                case Keys.D9:
                case Keys.NumPad9: button1_Click(button9, null);
                    break;
                case Keys.Oemplus:
                case Keys.Add: buttonPlus_Click(buttonPlus, null);
                    break;
                case Keys.OemMinus:
                case Keys.Subtract: buttonPlus_Click(buttonMinus, null);
                    break;
                case Keys.Multiply: buttonPlus_Click(buttonMul, null);
                    break;
                case Keys.Divide: buttonPlus_Click(buttonMinus, null);
                    break;
                case Keys.Back:
                case Keys.Delete: buttonRemove_Click(buttonRemove, null);
                    break;
                case Keys.Oemcomma: buttonDot_Click(buttonDot, null);
                    break;
                case Keys.Enter: buttonEquals_Click(buttonEquals, null);
                    break;
                default: break;
            }
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
