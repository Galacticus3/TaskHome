using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace task2
{
    enum EducationType { serednya, bakalawr, vyshcha };
    enum ProfessionType { buhgalter, programist, sesurity, ekonomist, yurist, admin, krutan, kasyr };

    public partial class Form1 : Form
    {
        List<Person> myList = new List<Person>();

        public Form1()
        {
            InitializeComponent();
            // додавання освіт та професій в комбобокси
            cmbEducation.DataSource = Enum.GetValues(typeof(EducationType));
            cmbProfession.DataSource = Enum.GetValues(typeof(ProfessionType));
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

        private void btnSaveToXml_Click(object sender, EventArgs e)
        {
            if (myList.Count == 0) return;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;

            using (XmlWriter writer = XmlWriter.Create("PersonsData.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Persons");

                foreach (Person value in myList)
                {
                    writer.WriteStartElement("Person");

                    writer.WriteElementString("Name", value.name);
                    writer.WriteElementString("Surname", value.surname);
                    writer.WriteElementString("DayOfBirthday", value.dob.ToString("dd.MM.yyyy"));
                    writer.WriteElementString("Education", value.education);
                    writer.WriteElementString("Profession", value.profession);
                    writer.WriteElementString("Money", value.zp.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                MessageBox.Show("Saved!");
            }
        }

        private void btnLoadFromXml_Click(object sender, EventArgs e)
        {
            string lastNodeName = "";
           Person m = new Person();  //(txtName.Text, txtSurname.Text, dtmDateOfBirth.Value, cmbEducation.Text, cmbProfession.Text, Convert.ToDouble(txtZp.Text));
            List<Person> myList2 = new List<Person>();

              using (XmlReader xml = XmlReader.Create("PersonsData.xml"))
               {
                 while (xml.Read())
                 {
                     //if ((xml.NodeType == XmlNodeType.Element) && (xml.Name == "Person"))
                     //{
                         //Person m = new Person();
                         switch (xml.NodeType)
                         {
                             case XmlNodeType.Element:
                                 // нашли элемент member
                                 if (xml.Name == "Person")
                                 {

                                     //поиск атрибутов ...
                                 }

                                 // запоминаем имя найденного элемента
                                 lastNodeName = xml.Name;
                                 break;

                             case XmlNodeType.Text:
                                 // нашли текст, смотрим по имени элемента, что это за текст
                                 if (lastNodeName == "Name") { m.name = xml.Value; }
                                 else if (lastNodeName == "Surname") { m.surname = xml.Value; }
                                 else if (lastNodeName == "DayOfBirthday") { m.day = xml.Value; } //m.dob = Convert.ToDateTime(xml.Value); } //DateTime.ParseExact(xml.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture); }
                                 else if (lastNodeName == "Education") { m.education = xml.Value; }
                                 else if (lastNodeName == "Profession") { m.profession = xml.Value; }
                                 else if (lastNodeName == "Money") { m.zp = Convert.ToDouble(xml.Value); }
                                 break;

                             case XmlNodeType.EndElement:
                                 if (xml.Name == "Person")
                                 {
                                     myList2.Add(m);
                                 }
                                 break;
                         }
                    // }

                  } 
               
               }

            // 2 sposib  ===================
  /*                 using (XmlReader xml = XmlReader.Create("PersonsData.xml"))
                   {
                       while (xml.Read())
                       {
                         //  if (xml.IsStartElement() && (xml.Name == "Person"))
                         //  {
                        //       Person m = new Person();
                               if (xml.IsStartElement())
                               {


                                   // Get element name and switch on it.
                                   switch (xml.Name)
                                   {
                                       case "Name": if (xml.Read()) { m.name = xml.Value; } break;
                                       case "Surname": if (xml.Read()) { m.surname = xml.Value; } break;
                                       case "DayOfBirthday": if (xml.Read()) { m.day = xml.Value; } break;
                                       case "Education": if (xml.Read()) { m.education = xml.Value; } break;
                                       case "Profession": if (xml.Read()) { m.profession = xml.Value; } break;
                                       case "Money": if (xml.Read()) { m.zp = Convert.ToDouble(xml.Value); } break;
                                      // default: myList2.Add(m); break;
                                   }

                               }
                          // }
                       } myList2.Add(m);
                    }
                   */
              //=====================





                    
            //======== to table ====
         //   textBox1.Text = myList2[1].name + "  --  " + myList2[1].surname;
            foreach (Person value in myList2)
            {
                dataGridView1.Rows.Add(value.name, value.surname, value.day, value.education, value.profession, Convert.ToString(value.zp));
                textBox1.Text = Convert.ToString(myList2.Count);
            }
        }

    }
}
