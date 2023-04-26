using System;

namespace Student_scorecard
{
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public int MathMarks { get; set; }
        public int ScienceMarks { get; set; }
        public int EnglishMarks { get; set; }
        public int LangMarks { get; set; }
        public int SstMarks { get; set; }
        public int TotalMarks { get; set; }
        public string Grade { get; set; }

        public bool IsPassed()
        {
            return (MathMarks >= 35 && ScienceMarks >= 35 && EnglishMarks >= 35 && LangMarks >= 35 && SstMarks >= 35);
        }

        public void GetGrade()
        {
            if (TotalMarks >= 450)
            {
                Grade = "A";
            }
            else if (TotalMarks >= 400)
            {
                Grade = "B";
            }
            else if (TotalMarks >= 350)
            {
                Grade = "C";
            }
            else if (TotalMarks >= 300)
            {
                Grade = "D";
            }
            else if (TotalMarks >= 250)
            {
                Grade = "E";
            }
            else
            {
                Grade = "F";
            }
        }
    }

    class ScoreCard
    {
        Student[] students;

        public void getDetails()
        {
            Console.Write("Enter the number of students: ");
            int numStudents = Convert.ToInt16(Console.ReadLine());

            students = new Student[numStudents];

            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"Enter Details for Student {i + 1}");

                Console.WriteLine("Enter Roll No:");
                int rollno = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Enter Student Name:");
                string name = Console.ReadLine();

                Console.Write("Enter Marks for Maths:");
                int maths = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Marks for Science:");
                int science = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Marks for English:");
                int english = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Marks for Language:");
                int lang = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Marks for SST:");
                int sst = Convert.ToInt16(Console.ReadLine());

                int total = maths + science + english + lang + sst;

                students[i] = new Student() { RollNo = rollno, Name = name, MathMarks = maths, ScienceMarks = science, EnglishMarks = english, LangMarks = lang, SstMarks = sst, TotalMarks = total };

                students[i].GetGrade();
            }
        }

        public void ShowDetails()
        {
            int sum = 0;
            int max = 0;

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Roll No: {students[i].RollNo} Name: {students[i].Name}");
                Console.WriteLine($"Math: {students[i].MathMarks}, Science: {students[i].ScienceMarks}, English: {students[i].EnglishMarks}, Language: {students[i].LangMarks}, SST: {students[i].SstMarks}");
                Console.WriteLine($"Total Marks: {students[i].TotalMarks}, Grade: {students[i].Grade}");
            }


            int maxTotalMarks = -1;
            string topScorerName = "";
            int topScorerRollNo = 0;


            foreach (Student student in students)

            {

                if (student.TotalMarks > maxTotalMarks)

                {

                    maxTotalMarks = student.TotalMarks;

                    topScorerName = student.Name;

                    topScorerRollNo = student.RollNo;

                }

            }

            Console.WriteLine($"\nTop Scorer: {topScorerName} (Roll No.: {topScorerRollNo}), Total Marks: {maxTotalMarks}");





            double avgMath = 0, avgScience = 0, avgEnglish = 0, avgLanguage = 0, avgSST = 0;



            foreach (Student student in students)

            {

                avgMath += student.MathMarks;

                avgScience += student.ScienceMarks;

                avgEnglish += student.EnglishMarks;

                avgLanguage += student.LangMarks;

                avgSST += student.SstMarks;

            }



            avgMath /= students.Length;

            avgScience /= students.Length;

            avgEnglish /= students.Length;

            avgLanguage /= students.Length;

            avgSST /= students.Length;



            Console.WriteLine($"\nAverage Marks\nMath: {avgMath:F2}\nScience: {avgScience:F2}\nEnglish: {avgEnglish:F2}\nLanguage: {avgLanguage:F2}\nSocial Studies: {avgSST:F2}");





            Console.WriteLine("\nStudents who have cleared the examination:");

            foreach (Student student in students)

            {

                if (student.MathMarks >= 35 && student.ScienceMarks >= 35 && student.EnglishMarks >= 35 && student.LangMarks >= 35 && student.SstMarks >= 35)

                {

                    Console.WriteLine($"{student.Name} (Roll No.: {student.RollNo})");

                }

            }





            int failedStudents = 0;

            for (int i = 0; i < students.Length; i++)

            {

                if (!students[i].IsPassed())

                {

                    failedStudents++;

                }

            }



            Console.WriteLine("\nNumber of students who need to mandatorily repeat the examination: {0}", failedStudents);

            Console.WriteLine("\nDetails of students who need to mandatorily repeat the examination:");

            Console.WriteLine("Roll No\tName");

            Console.WriteLine("None");

            for (int i = 0; i < students.Length; i++)

            {

                if (!students[i].IsPassed())

                {

                    Console.WriteLine("{0}\t{1}", students[i].RollNo, students[i].Name);

                }

            }

            Console.WriteLine();

        }



        public void Grade()

        {

            string Grade = "A";

            foreach (Student student in students)

            {

                double studentAverage = 0;

                studentAverage = student.TotalMarks / 5;

                if (studentAverage >= 95)

                {

                    Grade = "A";

                }

                else if (studentAverage >= 80)

                {

                    Grade = "B";

                }

                else if (studentAverage >= 70)

                {

                    Grade = "C";

                }

                else if (studentAverage >= 60)

                {

                    Grade = "D";

                }

                else if (studentAverage >= 50)

                {

                    Grade = "E";

                }

                else

                {

                    Grade = "F";

                }

            }

            Console.WriteLine();

        }



        public void StudentScore(int roll)

        {

            Console.WriteLine("ScoreCard");

            foreach (Student student in students)

            {

                if (roll == student.RollNo)

                {

                    Console.WriteLine($"Name of the student: {student.Name}");

                    Console.WriteLine($"Roll Number: {student.RollNo}");

                    Console.WriteLine($"Math Marks: {student.MathMarks}");

                    Console.WriteLine($"Science Marks: {student.ScienceMarks}");

                    Console.WriteLine($"English Marks: {student.EnglishMarks}");

                    Console.WriteLine($"Language Marks: {student.LangMarks}");

                    Console.WriteLine($"Social Marks: {student.SstMarks}");

                    Console.WriteLine($"Total Marks Obtained: {student.TotalMarks}");

                    string Grade = "A";

                    double studentAverage = 0;

                    studentAverage = student.TotalMarks / 5;

                    if (studentAverage >= 95)

                    {

                        Grade = "A";

                    }

                    else if (studentAverage >= 80)

                    {

                        Grade = "B";

                    }

                    else if (studentAverage >= 70)

                    {

                        Grade = "C";

                    }

                    else if (studentAverage >= 60)

                    {

                        Grade = "D";

                    }

                    else if (studentAverage >= 50)

                    {

                        Grade = "E";

                    }

                    else

                    {

                        Grade = "F";

                    }



                    Console.WriteLine($"Grade Achived {Grade}");

                }



            }

        }

    }


    class Program

    {

        static void Main(string[] args)

        {

            ScoreCard t = new ScoreCard();

            t.getDetails();

            t.ShowDetails();

            t.Grade();

            Console.WriteLine("Enter a Roll Number:");

            int roll = Convert.ToInt16(Console.ReadLine());

            t.StudentScore(roll);

        }

    }

}
