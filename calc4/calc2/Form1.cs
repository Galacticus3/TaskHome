using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc2
{
    public partial class Form1 : Form
    { 
        double rez = 0;    //результат
        double n1 = 0;     //перше число вираження
        double n2 = 0;     //друге число вираження
        bool dilenzero = false;  //чи відбулось ділення на нуль
        bool flag = false;  //для очищення екрану перед вводом першої цифри нового числа
        bool flagEqv = false;  //відбулась дія "="

        enum znaky { pusto = 1, plus, minus, mnozh, dilen };  //знак дії 
        znaky znak = znaky.pusto;       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "1";
                flag = false;
            }
            else
            { return; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "2";
                flag = false;
            }
            else
            { return; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "3";
                flag = false;
            }
            else
            { return; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "4";
                flag = false;
            }
            else
            { return; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "5";
                flag = false;
            }
            else
            { return; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "6";
                flag = false;
            }
            else
            { return; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "7";
                flag = false;
            }
            else
            { return; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "8";
                flag = false;
            }
            else
            { return; }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (flag == true) textBox1.Text = "";
                textBox1.Text = textBox1.Text + "9";
                flag = false;
            }
            else
            { return; }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if (textBox1.Text != "") textBox1.Text = textBox1.Text + "0";
                if (flag == true) { textBox1.Text = "0"; // textBox1.Text = ""; textBox1.Text = textBox1.Text + "0"; 
                                   }

                flag = false;
            }
            else
            { return; }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Tag = "";
            znak = znaky.pusto;
            rez = 0;
            n1 = 0;
            n2 = 0;
            
            dilenzero = false;
            flag = false;
        }

        // sqrt
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                rez = Math.Sqrt(Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(rez);
            }
            else
            { return; }
        }

        // + -
        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                rez = Convert.ToDouble(textBox1.Text) * (-1);
                textBox1.Text = Convert.ToString(rez);
            }
            else
            { return; }
        }

        // 1/x
        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                rez = 1 / Convert.ToDouble(textBox1.Text);
                textBox1.Text = Convert.ToString(rez);
            }
            else
            { return; }
        }

        // ,
        private void button11_Click(object sender, EventArgs e)
        {
            if (dilenzero == false)
            {
                if ((znak == znaky.pusto) && (textBox1.Text == "")) textBox1.Text = textBox1.Text + "0";
                if (textBox1.Text.Contains(",") == false) textBox1.Text = textBox1.Text + ",";
            }
            else
            { return; }
        }

        //кнопка +
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                Actionn();
                znak = znaky.plus;
                flag = true;
                n1 = 0;
            }
            else
            { return; }
        }

        //кнопка -
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                Actionn();
                znak = znaky.minus;
                flag = true;
                n1 = 0;
            }
            else
            { return; }
        }

        //кнопка *
        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                Actionn();
                znak = znaky.mnozh;
                flag = true;
                n1 = 0;
            }
            else
            { return; }
        }

        //кнопка /
        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                Actionn();
                znak = znaky.dilen;
                flag = true;
                n1 = 0;
            }
            else
            { return; }
        }
        //кнопка =
        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && dilenzero == false)
            {
                Actionn();
                flag = true;
            }
            else
            { return; }
        }

        void Actionn()
        {
            n2 = Convert.ToDouble(textBox1.Text);

            switch (znak)
            {
                case znaky.pusto:
                    {
                        rez = Convert.ToDouble(textBox1.Text);
                        break;
                    }
                case znaky.plus:
                    {
                        if (n1 != 0) n2 = n1;
                        rez = rez + n2;
                        textBox1.Text = Convert.ToString(rez);
                        n1 = n2;
                        break;
                    }
                case znaky.minus:
                    {
                        if (n1 != 0) n2 = n1;
                        rez = rez - n2;
                        textBox1.Text = Convert.ToString(rez);
                        n1 = n2;
                        break;
                    }

                case znaky.mnozh:
                    {
                        if (n1 != 0) n2 = n1;
                        rez = rez * n2;
                        textBox1.Text = Convert.ToString(rez);
                        n1 = n2;
                        break;
                    }
                case znaky.dilen:
                    {
                        if (Convert.ToDouble(textBox1.Text) == 0)
                        {
                            textBox1.Text = "На ноль нельзя!";
                            znak = znaky.pusto;
                            dilenzero = true;
                            flag = false;
                        }
                        else
                        {
                            if (n1 != 0) n2 = n1;
                            rez = rez / n2;
                            textBox1.Text = Convert.ToString(rez); //Convert.ToDouble(textBox1.Text));
                            n1 = n2;
                        }
                        break;
                    }
            }
                      
           
        }

    }
}
