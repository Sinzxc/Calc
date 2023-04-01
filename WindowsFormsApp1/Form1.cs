using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
                InitializeComponent();
        }
        public void Log(string s)
        {
            StreamWriter outputFile = new StreamWriter("Log.txt",true);
            outputFile.WriteLine(DateTime.Now + " "+ s);
            outputFile.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Log("Пользователь нажал вычислить;");
            int a, b;
            double c=0;
            try
            {
                a=Convert.ToInt32(textBox1.Text);
                b = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                Log("Ошибка : Вы ввели не число;");
                MessageBox.Show("Вы ввели не число!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                a = 1;
                b=1;
            }
            textBox3.Text = $"{a} {comboBox1.Text} {b} =";
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: c = a + b; break;
                    case 1: c = a - b; break;
                    case 2: c = a * b; break;
                    case 3: c = a / b; break;
                    default: MessageBox.Show("Вы не выбрали операцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); break;

                }
            }
            catch (DivideByZeroException)
            {
                Log("Ошибка : Деление на ноль;");
                MessageBox.Show("На ноль делить нельзя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = 1;
            }
            textBox3.Text += " "+c ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log("Пользователь нажал очистить;");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log("Пользователь нажал выход;");
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
                Log($"Пользователь ввёл {textBox1.Text[textBox1.Text.Length-1]} в TextBox1;");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                Log($"Пользователь ввёл {textBox2.Text[textBox2.Text.Length - 1]} в TextBox2;");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Log($"Пользователь выбрал {comboBox1.Text[comboBox1.Text.Length - 1]} в ComboBox1;");
        }
    }
}
