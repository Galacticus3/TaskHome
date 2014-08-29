using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
  

    public partial class Form1 : Form
    {
        Class1 class1 = new Class1();
        string k;

        List<Class1> myList= new List<Class1>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            class1.AddData(txtName.Text,txtSurname.Text);
            myList.Add(class1);
            //textBox1.Text = class1.name + " 11 " + class1.surname;
            textBox1.Text = myList[0].name + "   22   " + myList[0].surname;

         //   listBox1.Items.Add(myList);
            dataGridView1.Rows.Add(myList[0].name, myList[0].surname);
        }
          
    }
}
