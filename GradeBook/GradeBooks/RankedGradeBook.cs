using GradeBook.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text; 

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked; 
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //return base.GetLetterGrade(averageGrade); 
            if(studentsNumber < 5)
            {
                throw new InvalidOperationException(); 
            }
            var count = 0; 
            for(int i = 0; i < studentsNumber; i++)
            {
                if (Students[i].AverageGrade > averageGrade) count++; 
            }
            var percentGrade = (count * 100) / studentsNumber;
            if (percentGrade >= 0 && percentGrade < 20)
                return 'A';
            else if (percentGrade >= 20 && percentGrade < 40)
                return 'B';
            else if (percentGrade >= 40 && percentGrade < 50)
                return 'C';
            else if (percentGrade >= 60 && percentGrade < 80)
                return 'D';
            else 
                return 'F'; 
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 students."); 
            }
            else
            {
                base.CalculateStatistics(); 
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}