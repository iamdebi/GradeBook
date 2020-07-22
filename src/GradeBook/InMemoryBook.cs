using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public const string CATEGORY = "Science";
        private List<double> grades;

        public override event GradeAddedDelegate GradedAdded;


        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
                if (GradedAdded != null)
                {
                    GradedAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invaild {nameof(grade)}");
            }
        }

        // public void ShowStatistics()
        // {
        //     Console.WriteLine($"The Total grade is {totalNumbers():N1}");
        //     Console.WriteLine($"The Average grade is {calulateAverage():N1}");
        //     Console.WriteLine($"The Lowest Grade is {lowGrade():N1}");
        //     Console.WriteLine($"The Highest Grade is {highGrade():N1}");
        //     Console.WriteLine($"The Highest Grade is {letterGrade():N1}");
        // }


        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in this.grades)
            {
                result.Add(grade);
            }
            return result;
        }


    }
}