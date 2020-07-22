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

        public void ShowStatistics()
        {
            Console.WriteLine($"The Total grade is {totalNumbers():N1}");
            Console.WriteLine($"The Average grade is {calulateAverage():N1}");
            Console.WriteLine($"The Lowest Grade is {lowGrade():N1}");
            Console.WriteLine($"The Highest Grade is {highGrade():N1}");
            Console.WriteLine($"The Highest Grade is {letterGrade():N1}");
        }


        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in this.grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= this.grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }


        public double totalNumbers()
        {
            double length = this.grades.Count;
            double total = 0;
            for (int i = 0; i < length; i++)
            {
                total += this.grades[i];
            }
            return total;
        }

        public double calulateAverage()
        {
            double length = this.grades.Count;
            double total = totalNumbers();
            double average = 0;
            var i = 0;
            do
            {
                average = total / length;
                i += 1;
            } while (i < length);
            return average;

        }

        public double highGrade()
        {
            double highGrade = double.MinValue;
            foreach (var number in this.grades)
            {
                highGrade = Math.Max(number, highGrade);
            }
            return highGrade;
        }

        public double lowGrade()
        {
            double lowGrade = double.MaxValue;
            foreach (var number in this.grades)
            {
                lowGrade = Math.Min(number, lowGrade);
            }
            return lowGrade;
        }

        public char letterGrade()
        {
            double average = calulateAverage();
            switch (average)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }

    }
}