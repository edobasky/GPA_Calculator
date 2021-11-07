using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator
{
    class Program
    {
        public class Course
        {
            public Course(string nameCode, int unit, int score )
            {
                Name_Code = nameCode;
                Unit = unit;
                Score = score;
            }

            public string Name_Code { get; set; }
            public int Unit { get; set; }
            public int Score { get; set; }
        }

        public struct Grade
        {
            char ScoreGrade;
            public int GradePoint(int score)
            {
                int ScorePoint = 0;
               

                if (score >= 0 && score <= 39)
                {
                    ScorePoint = 0;
                    ScoreGrade = 'F';
                }
                else if(score >= 40 && score <= 44)
                {
                    ScorePoint = 1;
                    ScoreGrade = 'E';
                }
                else if (score >= 45 && score <= 49)
                {
                    ScorePoint = 2;
                    ScoreGrade = 'D';
                }
                else if (score >= 50 && score <= 59)
                {
                    ScorePoint = 3;
                    ScoreGrade = 'C';
                }
                else if (score >= 60 && score <= 69)
                {
                    ScorePoint = 4;
                    ScoreGrade = 'B';
                }
                else if (score >= 70 && score <= 100) {
                    ScorePoint = 5;
                    ScoreGrade = 'A';
                }



                return ScorePoint;
            }
        }
        static void Main(string[] args)
        {

           


            // ***************storage part ************************
            
            List<Course> CourseList = new List<Course>();


            //************************ take inputs****************
            //***********************validate course number****************
          
                Console.Write("Please enter the total number of courses: ");
                int courseNumber;
                bool checkInput = int.TryParse(Console.ReadLine(), out courseNumber);
                while (checkInput != true)
                {
                    Console.Write("Please enter the total number of courses: ");
                    checkInput = int.TryParse(Console.ReadLine(), out courseNumber);
                }

             //*************** Validate course related inputs ***************

            int count = 0;
            while (count < courseNumber)
            {
                Console.Write("Please enter course and code: ");
                string courseCode = (Console.ReadLine()).ToUpper();


                Console.Write("Please enter course unit: ");
                int unit = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter course score: ");
                int score = Convert.ToInt32(Console.ReadLine());


                Course course = new Course(courseCode,unit,score);
                CourseList.Add(course);

                //  Console.WriteLine(courseCode);
              count++;
            }

            // ****************** gpa calculation *********************
            //*****Assign various gpa variables by loping course list ********
            float GPA;
            int Course_Unit;
            int Grade_Unit;
            int Total_Quality_Point = 0;
            int Total_Grade_Unit = 0;
            int Total_Course_Unit = 0;

        // access grade class for grade unit values
            Grade grade = new Grade();

            foreach (var item in CourseList)
            {
                Course_Unit = item.Unit;

                Total_Course_Unit += item.Unit;

                Grade_Unit = grade.GradePoint(item.Score);

                Total_Quality_Point += (Course_Unit * Grade_Unit);

               // Total_Grade_Unit += Grade_Unit;

                /* Console.WriteLine("This is C_Code: {0}", item.Name_Code);
                 Console.WriteLine("This is C_score: {0}", item.Score);
                 Console.WriteLine("This is C_unit: {0}", item.Unit);*/

                Console.WriteLine(" garde unit : " + Grade_Unit);
                Console.WriteLine("Course unit : " + Course_Unit);
                Console.WriteLine("TG : " + Total_Grade_Unit);
                Console.WriteLine("TC : " + Total_Course_Unit);
            }

            Console.WriteLine("TQP : " + Total_Quality_Point);
            var answer = Total_Quality_Point / (float)Total_Course_Unit;

            GPA = (float)Math.Round(answer, 2);




            Console.WriteLine("Your GPA is =  " + GPA);



            // Console.WriteLine(courseCode);

            //**************************** Calculation of GPA ******************************
            /*  GPA = (total quality point) / (total grade unit);

             (quality point) = (course unit) *(grade unit);*/








            Console.ReadLine();
        }
    }
}
