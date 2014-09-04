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
        List<Person> myList = new List<Person>();
        enum EducationList {serednya, bakalawr, vyshcha};
        enum Professionlist { buhgalter, programist, sesurity, ekonomist, yurist, admin, krutan, kasyr};

        public Form1()
        {
            InitializeComponent();
            // додавання освіт та професій в комбобокси
            cmbEducation.DataSource = Enum.GetValues(typeof(EducationList));
            cmbProfession.DataSource = Enum.GetValues(typeof(Professionlist));
        }
        
        public bool textFieldValivation(TextBox field, Label label)
        {
            if (field.Text == "")
            {
                label.ForeColor = Color.Red;
                return false;
            }
            label.ForeColor = Color.Black;
            return true;
        }

        public bool textFieldValivation2(ComboBox field, Label label)
        {
            if (field.Text == "")
            {
                label.ForeColor = Color.Red;
                return false;
            }
            label.ForeColor = Color.Black; 
            return true;
        }

        public void fieldsClear()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            cmbEducation.Text = "";
            cmbProfession.Text = "";
            txtZp.Text = "";
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            //перевірка полів 
            bool isValid = textFieldValivation(txtName, lblName) && textFieldValivation(txtSurname, lblSurname) && textFieldValivation2(cmbEducation, lblEducation) && textFieldValivation2(cmbProfession, lblProfession) && textFieldValivation(txtZp, lblZp);
            if (!isValid)
            {
                return;
            }
                   
            //введення та додавання даних про людину в список
            Person person = new Person(txtName.Text, txtSurname.Text, dtmDateOfBirth.Value, cmbEducation.Text, cmbProfession.Text, Convert.ToDouble(txtZp.Text));
            myList.Add(person);
            dataGridView1.Rows.Add(person.name, person.surname, person.dob.ToString("dd.MM.yyyy"), person.education, person.profession, person.zp);
            fieldsClear();
        }
        //лишнє
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
