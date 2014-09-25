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
 

    public partial class Form1 : Form
    {
        List<Person> myList = new List<Person>();

        
        SQLiteConnection sql_con;
        SQLiteCommand sql_cmd;
        SQLiteDataAdapter DB;
        DataSet DS = new DataSet();
        DataTable DT = new DataTable();
        string SetRow;

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
        private void button1_Click(object sender, EventArgs e) {   }


        //=====================Запис в xml файл==========================

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

       //==========================Читання з xml файлу=============================
        
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

       
        //===========================Робота з базою даних========================

        /* string conn_str = @"Data Source = E:\ProfectsCatHome\base";
            
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
           }*/

        //set up the Connection
        void SetConnection()
        {
            string conn_str = @"Data Source = E:\ProfectsCatHome\base";
            sql_con = new SQLiteConnection(conn_str);
        }
                //"Data Source=E:\\ProfectsCatHome\\TaskHome\\task2\\task2\\base11.db"); }

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
            dataGridView2.DataSource = DT;
            dataGridView2.Columns[0].Visible = false;
            sql_con.Close();
        }

        //To add/edit/delete an entry to and from the table, just pass the required query to the already created ExecuteQuery function
        void AddFromDB()
        {
            string txtSQLQuery = @"INSERT INTO table1 (NAME,SURNAME,DAYOFBIRTHDAY,EDUCATION,PROFESSION,ZP)"
                                 +"VALUES ('"+ txtName.Text+"','"+ txtSurname.Text + "','" + dtmDateOfBirth.Value.ToString("dd.MM.yyyy")+ "',"
                                 +"'" + cmbEducation.Text + "','" + cmbProfession.Text + "','" + Convert.ToDouble(txtZp.Text)+"')";

          //  string txtSQLQuery = @"DELETE FROM table1 WHERE ID='4'";
            ExecuteQuery(txtSQLQuery);
            MessageBox.Show("Add ok!");
        }
        
        void DeleteFromDB()
        {
            string txtSQLQuery = @"DELETE FROM table1 WHERE ID=" + dataGridView2.CurrentRow.Cells[0].Value.ToString() +"";
            ExecuteQuery(txtSQLQuery);
            MessageBox.Show("Delete ok!");
        }

        void UpdateInDB()
        {
            string txtSQLQuery = "UPDATE table1 SET NAME='" + txtName.Text + "', SURNAME='" + txtSurname.Text + "', DAYOFBIRTHDAY='" + dtmDateOfBirth.Value.ToString("dd.MM.yyyy") + "',"
                                +"EDUCATION='" + cmbEducation.Text + "', PROFESSION='" + cmbProfession.Text + "', ZP='" + Convert.ToDouble(txtZp.Text) + "'"
                                + "WHERE ID=" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + " ";
            
            ExecuteQuery(txtSQLQuery);
            MessageBox.Show("Update ok!");
        }

        
        private void btnLoadFromDataBase_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void btnAddToDatabase_Click(object sender, EventArgs e)
        {
            //перевірка полів 
            bool isValid = textFieldValivation(txtName, lblName) && textFieldValivation(txtSurname, lblSurname) && textFieldValivation2(cmbEducation, lblEducation) && textFieldValivation2(cmbProfession, lblProfession) && textFieldValivation(txtZp, lblZp);
            if (!isValid)
            {
                return;
            }
            AddFromDB();
            LoadData();
        }

        private void btnDelFromDatabase_Click(object sender, EventArgs e)
        {
            DeleteFromDB();
            LoadData();
        }

        private void btnSetRowForUpdate_Click(object sender, EventArgs e)
        {
            //номер строки в таблице, которую собираемся отредактировать
            int RowIndex = Convert.ToInt32(dataGridView2.CurrentRow.Index.ToString());
            //запоминаем ID в строке для дальнейшего редактирования в btnUpdateRowOfDatabase_Click
            SetRow = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = SetRow;

            //забиваем данные со строки из таблицы в поля для дальнейшего редактирования
            txtName.Text = dataGridView2.Rows[RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView2.Rows[RowIndex].Cells[2].Value.ToString();
            dtmDateOfBirth.Value = DateTime.Parse(dataGridView2.Rows[RowIndex].Cells[3].Value.ToString());
            cmbEducation.Text = dataGridView2.Rows[RowIndex].Cells[4].Value.ToString();
            cmbProfession.Text = dataGridView2.Rows[RowIndex].Cells[5].Value.ToString();
            txtZp.Text = dataGridView2.Rows[RowIndex].Cells[6].Value.ToString();
        }

        private void btnUpdateRowOfDatabase_Click(object sender, EventArgs e)
        {
            //перевірка полів 
            bool isValid = textFieldValivation(txtName, lblName) && textFieldValivation(txtSurname, lblSurname) && textFieldValivation2(cmbEducation, lblEducation) && textFieldValivation2(cmbProfession, lblProfession) && textFieldValivation(txtZp, lblZp);
            if (!isValid)
            {
                return;
            }
            UpdateInDB();
            LoadData();
        }

    }
}
