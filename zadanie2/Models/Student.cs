using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2.Models
{
    class Student
    {
        public string Name;
        public string Surname;
        public Studies Studies;
        public int Index;
        public string Birthday;
        public string Email;
        public string Mother;
        public string Father;

        public Student(string Name, string Surname, Studies Studies, int Index, string Birthday, string Email, string Mother, string Father)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Studies = Studies;
            this.Index = Index;
            this.Birthday = Birthday;
            this.Email = Email;
            this.Mother = Mother;
            this.Father = Father;
        }

        public string BirthdayParser()
        {
            return $"{DateTime.Parse(this.Birthday).Day}.{DateTime.Parse(this.Birthday).Month}.{DateTime.Parse(this.Birthday).Year}";
        }

        public string ShowStudent()
        {
            return $"Student: {this.Name} {this.Surname}, index: s{this.Index}, birthday: {this.BirthdayParser()}, email: {this.Email}, Parents: {this.Mother}, {this.Father}";
        }

        public Studies studies{
            get 
            {
                return this.Studies;   
            }
        }
    }

}
