using System;

namespace SandE1
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;
            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static void Main(string[] args)
        {
           double Point = 0; 
            Difficulty Level = 0;
            PageMenu(Point,Level);
        }
        static void PageMenu(double p1,Difficulty p2enumdif)
        {
            int numPage;
            Console.WriteLine("Score:{0},Difficulty:{1}",p1,p2enumdif);
            Check(out numPage);
            if (numPage == 0)
            { Play( p1,p2enumdif); }
            else if (numPage == 1)
            { Seting(p1, p2enumdif); }
            else if (numPage == 2)
            {}
        }
        static void Check(out int page)
        {
            do
            {
                page = int.Parse(Console.ReadLine());
                if (page != 0 && page !=1 && page!=2)
                { Console.WriteLine("Please input 0-2."); }
            } while (page != 0 && page != 1 && page != 2);
        }
        static void Play( double Point, Difficulty Level)
        {
            int d = (int)Level;
            double Answer;
            double Qc = 0;
            double Qa;
            Problem[] RandomProblems = GenerateRandomProblems(d * 2 + 3);
            long Start = DateTimeOffset.Now.ToUnixTimeSeconds();
            for (int j = 0; j < RandomProblems.Length; j++)
            {
                Console.Write(RandomProblems[j].Message);
                Console.WriteLine("");
                Answer = int.Parse(Console.ReadLine());
                if (Answer == RandomProblems[j].Answer)
                { Qc = Qc + 1; }   
            }
            long Stop = DateTimeOffset.Now.ToUnixTimeSeconds();
            long RangeTime = Stop - Start;
            Qa = d * 2 + 3;
            Point = Point + ((Qc / Qa) * ((25 - Math.Pow(d, 2)) / Math.Max(RangeTime, 25 - (double)Math.Pow(d, 2))) * (Math.Pow(2 * d + 1, 2)));
            PageMenu(Point, Level);
        }
        static void Seting(double Point, Difficulty Level)
        {
            int LevelCheck;
            Console.WriteLine("Score: {0}, Difficulty: {1}", Point, (Difficulty)Level);
            do
            {
                LevelCheck = int.Parse(Console.ReadLine());
                if (LevelCheck != 0 && LevelCheck != 1 && LevelCheck != 2)
                { Console.WriteLine("Please input 0-2."); }
            } while (LevelCheck != 0 && LevelCheck != 1 && LevelCheck != 2);
               Level = (Difficulty)LevelCheck;
            PageMenu(Point,Level);
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];
            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }
            return randomProblems;
        }
    }
}
