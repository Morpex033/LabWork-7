using LabWork_7;

namespace Lab_Work_7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StudentScores studentScores = new StudentScores();

            // Добавляем оценки
            studentScores.AddScore("Bob", "Math", 80);
            studentScores.AddScore("Bob", "Physics", 70);
            studentScores.AddScore("Bob", "Zoology", 60);
            studentScores.AddScore("Alice", "Math", 90);
            studentScores.AddScore("Alice", "Math", 85);
            studentScores.AddScore("Alice", "Physics", 75);
            

            // Сохранение словаря
            StudentDataStorage.Save(studentScores);

            //Загрузка словаря из сохраненого файла
            StudentScores studentScores1 = StudentDataStorage.Load();

            System.Console.WriteLine("Не тронутый словарь");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.SortByStudent);

            System.Console.WriteLine("Отсортированый словарь в алфавитном порядке по студентам");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.ReverseSortByStudent);

            System.Console.WriteLine("Отсортированый словарь в обратном алфавитном порядке по студентам");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.SortBySubject);

            System.Console.WriteLine("Отсортированый словарь в алфавитном порядке по предметам");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.ReverseSortBySubject);

            System.Console.WriteLine("Отсортированый словарь в обратном алфавитном порядке по предметам");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.SortByGrades);

            System.Console.WriteLine("Отсортированый словарь по оценкам от меньшему к большему");
            studentScores1.PrintDictionary();

            SortFilterDictionary.Sort(studentScores1, StudentScores.ReverseSortByGrades);

            System.Console.WriteLine("Отсортированый словарь по оценкам от большего к меньшему");
            studentScores1.PrintDictionary();

            StudentScores filteredStudentScore = SortFilterDictionary.Filter(studentScores1, StudentScores.FilterStudent, "Bob");

            System.Console.WriteLine("Отфильтрованая копия словаря");
            filteredStudentScore.PrintDictionary();

            StudentScores filteredStudentScore1 = SortFilterDictionary.Filter(studentScores1, StudentScores.FilterStudent, "Bob", "Math", 60);

            System.Console.WriteLine("Отфильтрованая копия словаря c опциональными параметрами");
            filteredStudentScore1.PrintDictionary();
        }
    }
}