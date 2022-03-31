using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    class RankedGradeBook :BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {

            Type = GradeBookType.Ranked;

        }
   
        public override char GetLetterGrade(double averageGrade)
        {

            char grade = 'F';
            double HighScore = (from student in Students select student.AverageGrade).Max();


            if(Students.Count < 5)
            {

                throw new InvalidCastException();

            }

            if (averageGrade > HighScore/20)
            {

                grade = 'A';
            
            }

            else if (averageGrade > HighScore / 15)
            {

                grade = 'F';

            }

            else if (averageGrade > HighScore / 10)
            {

                grade = 'C';

            }

            else if (averageGrade > HighScore / 5)
            {

                grade = 'D';

            }

            return grade;
        }

        public override void CalculateStatistics()
        {

            if (Students.Count <5)
            {

                Console.WriteLine("Ranked grading requires at least 5 students.");

            }

            else
            {

                base.CalculateStatistics();

            }
        }
    }
}
