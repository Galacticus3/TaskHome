using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;

namespace task2
{
    enum EducationType { serednya, bakalawr, vyshcha };
    enum ProfessionType { buhgalter, programist, sesurity, ekonomist, yurist, admin, krutan, kasyr };

    public partial class Form1 : Form
    {
        List<Person> myList = new List<Person>();

        
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        SQLiteDataAdapter DB;
        DataSet DS = new DataSet();
        DataTable DT = new DataTable();

        public Form1()
        {
            InitializeComponent();
            // додавання освіт та професій в комбобокси
            cmbEducation.DataSource = Enum.GetValues(typeof(EducationType));
            cmbProfession.DataSource = Enum.GetValues(typeof(ProfessionType));
        }
        
        public bool textFieldValivation(TextBox field, Label label)
        {
            if (field.Text == "") { label.ForeColor = Color.Red; return false; } 
            label.ForeColor = Color.Black; return true;
        }

        public bool textFieldValivation2(ComboBox field, Label label)
        {
            if (field.Text == "") { label.ForeColor = Color.Red; return false; }
            label.ForeColor = Color.Black; return true;
        }

        public void fieldsClear()
        {
            txtName.Text = ""; txtSurname.Text = ""; cmbEducation.Text = ""; cmbProfession.Text = ""; txtZp.Text = "";
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
        private void label3_Click(object sender, EventArgs e) {   }
        private void label4_Click(object sender, EventArgs e) {   }

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
           Person m = new Person();
           List<Person> myList2 = new List<Person>();

           using (XmlReader xml = XmlReader.Create("PersonsData.xml"))
            {
                while (xml.Read())
                {   // Only detect start elements.
                    if (xml.IsStartElement())
                    {   // Get element name and switch on it.
                        switch (xml.Name)
                        {
                            case "Person": if (m.name != "") myList2.Add(m); m = new Person(); break;
                            case "Name": if (xml.Read()) { m.name = xml.Value; } break;
                            case "Surname": if (xml.Read()) { m.surname = xml.Value; } break;
                            case "DayOfBirthday": if (xml.Read()) { m.dob = DateTime.Parse(xml.Value); } break;
                            case "Education": if (xml.Read()) { m.education = xml.Value; } break;
                            case "Profession": if (xml.Read()) { m.profession = xml.Value; } break;
                            case "Money": if (xml.Read()) { m.zp = Convert.ToDouble(xml.Value); } break;
                        }
                    }
                }
                myList2.Add(m);
            }

            //======== to table ====
            foreach (Person value in myList2)
            {
                dataGridView1.Rows.Add(value.name, value.surname, value.dob.ToString("dd.MM.yyyy"), value.education, value.profession, Convert.ToString(value.zp));

            } 

            // 2 sposib  ===================

            /* string lastNodeName = "";
               using (XmlReader xml = XmlReader.Create("PersonsData.xml"))
                          {
                            while (xml.Read())
                            {
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
                                                m = new Person();
                                            }
                                            break;
                                    }
                            } 
               
                          }*/


        }

    /*  SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        SQLiteDataAdapter DB;
        DataSet DS = new DataSet();
        DataTable DT = new DataTable(); */

        //set up the Connection
        void SetConnection()
        { sql_con = new SQLiteConnection("Data Source=E:\\ProfectsCatHome\\TaskHome\\task2\\task2\\base11.db"); }

        //generic function to execute Create Command queries
        void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        //function to access the SQLite database and retrieve the data from the table and fill the Dataset
        void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT * FROM table1";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        //To add/edit/delete an entry to and from the table, just pass the required query to the already created ExecuteQuery function
        void Add()
        {
            string txtSQLQuery = "insert into  mains (desc) values ";//('" + txtDesc.Text+ "')";
            ExecuteQuery(txtSQLQuery);
        }
        
        
        private void btnLoadFromDataBase_Click(object sender, EventArgs e)
        {
            //LoadData();

            string conn_str = @"Data Source = E:\ProfectsCatHome\base";
            
            using (SQLiteConnection conn = new SQLiteConnection(conn_str))
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("connection ok!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
