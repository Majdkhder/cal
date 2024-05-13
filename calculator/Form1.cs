using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {

        private double[] numbers = new double[50];
        private char[] operations = new char[50];
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                label1.Text += b.Text;
            }
        }
        private void button_op_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length!=0)
            {
                numbers[count] = double.Parse(label1.Text);
                button_Click(sender, e);
                label2.Text += label1.Text;
                operations[count] = label1.Text[label1.Text.Length - 1];
                label1.Text = "";
                count++;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = label2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string text ="";
            for (int i = 0; i < label1.Text.Length-1; i++)
            {
                text += label1.Text[i];
            }
            label1.Text = text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_op_Click(sender, e);
            double result = 0;
            for (int j = 0; j < count; j++)
            {
                switch (operations[j])
                {
                    case '×':
                        if (count == 2)
                        {
                            result = numbers[j] * numbers[j + 1];
                            break;
                        }
                        if (j == 0)
                        {
                            numbers[j + 1] = numbers[j] * numbers[j + 1];
                            break;
                        }
                        numbers[j] = numbers[j] * numbers[j + 1];
                        break;
                    case '÷':
                        if (count == 2)
                        {
                            result = numbers[j] / numbers[j + 1];
                            break;
                        }
                        if (j == 0)
                        {
                            numbers[j + 1] = numbers[j] / numbers[j + 1];
                            break;
                        }
                        numbers[j] = numbers[j] / numbers[j + 1];
                        break;
                    case '%':
                        if (count == 2)
                        {
                            result = numbers[j] % numbers[j + 1];
                            break;
                        }
                        if (j == 0)
                        {
                            numbers[j + 1] = numbers[j] % numbers[j + 1];
                            break;
                        }
                        numbers[j] = numbers[j] % numbers[j + 1];
                        break;
                }
            }
            for (int i = 0; i < count; i++)
            {
                switch (operations[i])
                {
                    case '+':
                        result += numbers[i] + numbers[i + 1];
                        break;
                    case '-':
                        result += numbers[i] - numbers[i + 1];
                        break;
                }
            }
            if (count == 1)
            {
                result = numbers[0];
            }
            label1.Text = result.ToString();
            count = 0;
        }
    }
}