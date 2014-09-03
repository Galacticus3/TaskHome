using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Person
    {
        public string name, surname, education, profession;
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
            this.name = "Name";
            this.surname = "Surname";
        }
    }
}