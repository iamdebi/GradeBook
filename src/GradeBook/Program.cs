﻿using System;
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
            // Console.WriteLine($"The folowing grades for {InMemoryBook.CATEGORY}");

            // book.ShowStatistics();


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
