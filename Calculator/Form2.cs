using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class ValueForm : Form
    {
        public ValueForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ValueData.Data = Convert.ToDouble(ValueTextBox.Text);
                ValueData.Cancelled = false;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ValueData.Cancelled = true;
            this.Close();
        }
    }
}
