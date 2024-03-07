using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7
{
    class StudentScores
    {
        // Словарь для хранения оценок студентов
        private Dictionary<string, Dictionary<string, List<int>>> scores;

        // Конструктор класса
        public StudentScores()
        {
            scores = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        // Метод для добавления оценки студенту по определенному предмету
        public void AddScore(string student, string subject, int score)
        {
            // Проверяем, существует ли студент в словаре
            if (!scores.ContainsKey(student))
            {
                // Если студента нет, добавляем его в словарь
                scores[student] = new Dictionary<string, List<int>>();
            }

            // Проверяем, существует ли предмет у студента
            if (!scores[student].ContainsKey(subject))
            {
                // Если предмета нет, добавляем его в словарь
                scores[student][subject] = new List<int>();
            }

            // Добавляем оценку студенту по предмету
            scores[student][subject].Add(score);
        }

        // Метод для получения среднего балла студента по всем предметам
        public double? GetAverageScore(string student)
        {
            // Проверяем, существует ли студент в словаре
            if (scores.ContainsKey(student))
            {
                // Переменные для хранения суммы всех оценок и общего количества предметов
                double totalScores = 0;
                int totalSubjects = 0;

                // Перебираем все предметы у студента
                foreach (var subjectScores in scores[student])
                {
                    // Суммируем все оценки по предмету
                    totalScores += subjectScores.Value.Sum();
                    // Увеличиваем количество предметов
                    totalSubjects += subjectScores.Value.Count;
                }

                // Вычисляем средний балл, если есть оценки
                return totalSubjects > 0 ? totalScores / totalSubjects : (double?)null;
            }
            else
            {
                // Если студента нет, возвращаем null
                return null;
            }
        }
    }
}
