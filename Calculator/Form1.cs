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

        #region Basic variables

        private double _digit1, _digit2, _result;
        private string _operation = "+";
        private bool _operationChoosed;
        private bool _operationCompleted;
        private readonly StringBuilder _currentState = new StringBuilder();

        private const string _zero = "0";

        #endregion

        #region Buttons handlers

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text.IndexOf(((Button) sender).Text) == -1)
                CalcTextBox.Text += ((Button) sender).Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != _zero)
            {
                if (_operationCompleted)
                {
                    CalcTextBox.Text = _zero;
                    DisplayBox.Clear();
                    _operationCompleted = false;
                }

                CalcTextBox.Text += ((Button) sender).Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_operationCompleted)
            {
                CalcTextBox.Text = _zero;
                DisplayBox.Clear();
                _operationCompleted = false;
            }
            
            if (CalcTextBox.Text == _zero)
                CalcTextBox.Text = ((Button) sender).Text;
            else
                CalcTextBox.Text += ((Button) sender).Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (_operationChoosed)
                {
                    _digit2 = Convert.ToDouble(CalcTextBox.Text);
                    Calculate();
                    _digit1 = _result;
                }
                else
                    _digit1 = Convert.ToDouble(CalcTextBox.Text);

                _currentState.Append(CalcTextBox.Text);
                _currentState.Append(((Button) sender).Text);
                DisplayBox.Text = _currentState.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            CalcTextBox.Clear();
            _operation = ((Button) sender).Text;
            _operationChoosed = true;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                _digit2 = Convert.ToDouble(CalcTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            Calculate();

            _currentState.Append(_digit2);

            DisplayBox.Text = _currentState.ToString();
            CalcTextBox.Text = _result.ToString();

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            CalcTextBox.Text = _zero;
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (CalcTextBox.Text != "")
            {
                if (CalcTextBox.Text[0] == '-')
                    CalcTextBox.Text = CalcTextBox.Text.Remove(0, 1);
                else CalcTextBox.Text = '-' + CalcTextBox.Text;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (_operationCompleted)
            {
                CalcTextBox.Text = _zero;
                _operationCompleted = false;
            }
            else if (CalcTextBox.Text != "")
                CalcTextBox.Text = CalcTextBox.Text.Remove(CalcTextBox.Text.Length - 1, 1);
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            _digit1 = 0;
            _digit2 = 0;
            _result = 0;
            _operationChoosed = false;
            _operationCompleted = false;
            _currentState.Clear();
            DisplayBox.Clear();
            CalcTextBox.Text = _zero;
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Sin(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("Sin({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Cos(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("Cos({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonTg_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Tan(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("Tg({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonASin_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Asin(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("ASin({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonACos_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Acos(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("ACos({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonATg_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Atan(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("Atg({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Pow(Convert.ToDouble(CalcTextBox.Text), 2);
                _currentState.Append(String.Format("Square({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            try
            {
                _digit1 = Convert.ToDouble(CalcTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            var f = new ValueForm();
            f.ShowDialog();

            if (!ValueData.Cancelled)
            {
                _result = Math.Pow(_digit1, ValueData.Data);

                _currentState.Append(String.Format("Pow({0}), N = {1}", _digit1, ValueData.Data));

                DisplayBox.Text = _currentState.ToString();
                CalcTextBox.Text = _result.ToString();

                _currentState.Clear();
                _result = 0;
                _operationCompleted = true;
                _operationChoosed = false;
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                _result = Math.Sqrt(Convert.ToDouble(CalcTextBox.Text));
                _currentState.Append(String.Format("Sqrt({0})", CalcTextBox.Text));
                DisplayBox.Text = _currentState.ToString();

                CalcTextBox.Text = _result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            _currentState.Clear();
            _result = 0;
            _operationCompleted = true;
            _operationChoosed = false;
        }

        private void buttonNrt_Click(object sender, EventArgs e)
        {
            try
            {
                _digit1 = Convert.ToDouble(CalcTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CalcTextBox.Clear();
                return;
            }

            ValueForm f = new ValueForm();
            f.ShowDialog();

            if (!ValueData.Cancelled)
            {
                NthRoot(_digit1, ValueData.Data);

                _currentState.Append(String.Format("NthRoot({0}), N = {1}", _digit1, ValueData.Data));

                DisplayBox.Text = _currentState.ToString();
                CalcTextBox.Text = _result.ToString();

                _currentState.Clear();
                _result = 0;
                _operationCompleted = true;
                _operationChoosed = false;
            }
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculator © 2015", "About Calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sqrt - Square Root\nNrt - N-th root\nSqr - Square\nPowN - Raise to the N power", "Help",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                case Keys.NumPad0:
                    button0_Click(button0, null);
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    button1_Click(button1, null);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    button1_Click(button2, null);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    button1_Click(button3, null);
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    button1_Click(button4, null);
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    button1_Click(button5, null);
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    button1_Click(button6, null);
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    button1_Click(button7, null);
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    button1_Click(button8, null);
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    button1_Click(button9, null);
                    break;
                case Keys.Oemplus:
                case Keys.Add:
                    buttonPlus_Click(buttonPlus, null);
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    buttonPlus_Click(buttonMinus, null);
                    break;
                case Keys.Multiply:
                    buttonPlus_Click(buttonMul, null);
                    break;
                case Keys.Divide:
                    buttonPlus_Click(buttonMinus, null);
                    break;
                case Keys.Back:
                case Keys.Delete:
                    buttonRemove_Click(buttonRemove, null);
                    break;
                case Keys.Oemcomma:
                    buttonDot_Click(buttonDot, null);
                    break;
                case Keys.Enter:
                    buttonEquals_Click(buttonEquals, null);
                    break;
            }
        }

        #endregion

        private void Calculate()
        {
            switch (_operation)
            {
                case "+":
                    _result = _digit1 + _digit2;
                    break;
                case "-":
                    _result = _digit1 - _digit2;
                    break;
                case "x":
                    _result = _digit1*_digit2;
                    break;
                case "/":
                    _result = _digit1/_digit2;
                    break;
                case "%":
                    _result = (_digit1/_digit2)*100;
                    break;
            }
        }

        private void NthRoot(double digit, double n)
        {
            _result = Math.Pow(digit, 1.0/n);
        }
    }
}