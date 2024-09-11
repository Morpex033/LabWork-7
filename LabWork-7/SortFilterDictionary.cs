using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7
{
    internal class SortFilterDictionary
    {
        // Делегат для сортировки
        public delegate Dictionary<string, Dictionary<string, int>> SortDelegate(StudentScores studentScores);

        public delegate Dictionary<string, Dictionary<string, int>> FilterDelegate(StudentScores studentScores, string student, string? optionalSubject = null, int optionalGrade = 0);

        // Метод для сортировки
        public static void Sort(StudentScores studentScores, SortDelegate sortDelegate) 
        {
            studentScores.SetGrades(sortDelegate(studentScores));
        }

        // Метод фильтрации
        public static StudentScores Filter(StudentScores studentScores, FilterDelegate filterDelegate, string student, string? optionalSubject = null, int optionalGrade = 0)
        {
            // Применяем фильтрацию через делегат
            var filteredData = filterDelegate(studentScores, student, optionalSubject, optionalGrade);

            // Создаем новый объект StudentScores для хранения отфильтрованных данных
            StudentScores filteredStudentScores = new StudentScores();

            // Копируем отфильтрованные данные в новый объект
            foreach (var entry in filteredData)
            {
                filteredStudentScores.Grades.Add(entry.Key, entry.Value);
            }

            return filteredStudentScores;
        }
    }
}
