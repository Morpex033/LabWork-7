using LabWork_7;

namespace Lab_Work_7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // LabWork7();

            //Загрузка словаря из сохраненого файла в методе LabWork7()
            StudentScores studentScores1 = StudentDataStorage.Load();

            studentScores1.PrintDictionary();
        }

        /*
            Статический метод LabWork7 это часть кода из Лабораторной роботы 7,
            который был вынесем в отдельный метод для удобста демонстрации загрузки словаря из файла.
        */
        public static void LabWork7()
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
            //Переопределенный ToString
            Console.WriteLine(studentScores);
            Console.WriteLine("----------------------------------------------------");
            // Вывод словаря
            studentScores.PrintDictionary();
            // Сохранение словаря
            StudentDataStorage.Save(studentScores);
        }
    }
}