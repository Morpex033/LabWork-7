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
        private Dictionary<string, Dictionary<string, int>> grades;

        // Конструктор класса
        public StudentScores()
        {
            grades = new Dictionary<string, Dictionary<string, int>>();
        }

        // Метод для добавления оценки студенту по определенному предмету
        public void AddScore(string student, string subject, int grade)
        {
            // Проверяем, существует ли студент в словаре
            if (!grades.ContainsKey(student))
            {
                // Если студента нет, добавляем его в словарь
                grades[student] = new Dictionary<string, int>();
            }

            // Проверяем, существует ли предмет у студента
            if (!grades[student].ContainsKey(subject))
            {
                // Если предмета нет, добавляем его в словарь
                grades[student][subject] = new int();
            }

            // Добавляем оценку студенту по предмету
            grades[student][subject] = grade;
        }
        // Метод для изменения оценки студента по предмету
        public void EditScore(string student, string subject, int grade)
        {
            // Проверяем, существует ли студент
            if(!grades.ContainsKey(student))
            {
                // Если нет, выбрасываем ошибку
                throw new Exception($"The {student} does not exist");
            }
            // Проверяем существует ли предмет у студента
            if (!grades[student].ContainsKey(subject))
            {
                // Если нет выбрасываем ошибку
                throw new Exception($"The {student} has no grades in this {subject}");
            }
            // Обновляем оценку у студента по предмету
            grades[student][subject] = grade;
        }
        // Метод для удаления студента
        public void DeleteStudent(string student)
        {
            // Проверяем существует ли студент
            if (grades.ContainsKey(student))
            {
                // Удаляем студента
                grades.Remove(student);
            }
            else
            {
                // Если студента нет, выбрасываем ошибку
                throw new Exception($"The {student} does not exists");
            }
        }

        // Метод для получения баллов студента по всем предметам
        public Dictionary<string, int> GetStudentScore(string student)
        {
            // Проверяем, существует ли студент в словаре
            if (grades.ContainsKey(student))
            {
                // Возвращаем словарь предметов с оценками
                return grades[student];
            }
            else
            {
                // Если студента нет выбрасывает ошибку
                throw new Exception($"The {student} does not exists");
            }
        }
        // Принт в консоль оценок студента
        public void PrintStudentScore(string student)
        {
            // Проверяем, существует ли студент
            if (grades.ContainsKey(student))
            {
                // Строка для вывода в консоль
                string result = $"The {student} grades:\n";
                // Перебор всех предметов студента
                foreach (var pair in grades[student])
                {
                    // Добавление в строку значений предмета и оценки
                    result += $"{pair.Key}: {pair.Value}\n";
                }
                // Вывод в консоль
                Console.WriteLine(result);
            }
            else
            {
                // Если студента нет, выбрасывает ошибку
                throw new Exception($"The {student} does not exists");
            }
        }

        // Метод для вывода всех оценок всех студентов в словаре
        public void PrintDictionary()
        {
            // Итерируемся по всем студентам в словаре и выводим их оценки
            foreach (var student in grades)
            {
                // Вызываем метод PrintStudentScore для каждого студента
                PrintStudentScore(student.Key);
            }
        }

        // Метод для получения словаря оценок (используется для сериализации/десериализации)
        public Dictionary<string, Dictionary<string, int>> GetGrades()
        {
            return this.grades;
        }

        // Метод для установки словаря оценок (используется для десериализации)
        public void SetGrades(Dictionary<string, Dictionary<string, int>> dictionary)
        {
            this.grades = dictionary;
        }

        // Переопределение метода ToString для формирования текстового представления оценок
        public override string ToString()
        {
            string result = "Student Grades:\n";

            // Итерируемся по всем студентам и их оценкам в словаре
            foreach (var student in grades)
            {
                result += $"{student.Key}:\n";
                foreach (var subject in student.Value)
                {
                    result += $"-{subject.Key}: {subject.Value}\n";
                }
            }

            return result;
        }
    }
}
