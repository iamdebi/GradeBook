using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade was added");
        }


        static void Main(string[] args)
        {

            IBook book = new DiskBook("Debbie's grade book");
            book.GradedAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"The following grades for {book.Name}");
            Console.WriteLine($"The Average grade is {stats.Average: N1}");
            Console.WriteLine($"The Lowest Grade is {stats.Low}");
            Console.WriteLine($"The Highest Grade is {stats.High}");
            Console.WriteLine($"The Letter Grade is {stats.Letter}");
            // Console.WriteLine($"The folowing grades for {InMemoryBook.CATEGORY}");



        }

        private static void EnterGrades(IBook book)
        {

            while (true)
            {
                Console.WriteLine("Enter a grade of 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }
    }
}
