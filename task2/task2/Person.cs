using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Person
    {
        public string name, surname, education, profession, day, money;
        public DateTime dob;
        public double zp;        

        public Person (string nm, string snm, DateTime dob, string education, string profession, double zp)
        {
            this.name = nm;
            this.surname = snm;
            this.dob = dob;
            this.education = education;
            this.profession = profession;
            this.zp = zp;
             
        }

        public Person()
        {
            name = "";
            surname = "";
            dob = DateTime.Parse("27.01.1985");
            //day = "";
            education = "";
            profession = "";
            zp = 0;

        }
    }
}