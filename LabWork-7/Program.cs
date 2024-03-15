using LabWork_7;

namespace Lab_Work_7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StudentScores studentScores = new StudentScores();

            // Добавляем оценки
            studentScores.AddScore("Alice", "Math", 90);
            studentScores.AddScore("Alice", "Math", 85);
            studentScores.AddScore("Alice", "Physics", 75);
            studentScores.AddScore("Bob", "Math", 80);
            studentScores.AddScore("Bob", "Physics", 70);

            // Вывод баллов студентов
            studentScores.PrintStudentScore("Alice");
            studentScores.PrintStudentScore("Bob");
            Console.WriteLine("----------------------------------------------------");
            // Вывод словаря
            studentScores.PrintDictionary();
        }
    }
}