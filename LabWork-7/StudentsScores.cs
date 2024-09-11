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

        public Dictionary<string, Dictionary<string, int>> Grades {  get { return grades; } }

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
            System.Console.WriteLine("--------------------------");
            // Итерируемся по всем студентам в словаре и выводим их оценки
            foreach (var student in grades)
            {
                // Вызываем метод PrintStudentScore для каждого студента
                PrintStudentScore(student.Key);
            }
            System.Console.WriteLine("--------------------------");
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

        // Сортировка словаря в алфавитном порядке по студентам
        public static Dictionary<string, Dictionary<string, int>> SortByStudent(StudentScores studentScores)
        {
            return studentScores.Grades
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToDictionary(v => v.Key, v => v.Value));
        }
        // Сортировка словаря в обратном алфавитном порядке по студентам
        public static Dictionary<string, Dictionary<string, int>> ReverseSortByStudent(StudentScores studentScores)
        {
            return studentScores.Grades
                .OrderByDescending(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToDictionary(v => v.Key, v => v.Value));
        }
        // Сортировка словаря в алфавитном порядке по предметам
        public static Dictionary<string, Dictionary<string, int>> SortBySubject(StudentScores studentScores)
        {
            return studentScores.Grades
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value));
        }
        // Сортировка словаря в обратном алфавитном порядке по предметам
        public static Dictionary<string, Dictionary<string, int>> ReverseSortBySubject(StudentScores studentScores)
        {
            return studentScores.Grades
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.OrderByDescending(v => v.Key).ToDictionary(v => v.Key, v => v.Value));
        }
        // Сортировка словаря по оценкам от меньшего к большему
        public static Dictionary<string, Dictionary<string, int>> SortByGrades(StudentScores studentScores)
        {
            return studentScores.Grades
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.OrderBy(v => v.Value).ToDictionary(v => v.Key, v => v.Value));
        }
        // Сортировка словаря по оценкам от большего к меньшему
        public static Dictionary<string, Dictionary<string, int>> ReverseSortByGrades(StudentScores studentScores)
        {
            return studentScores.Grades
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.OrderByDescending(v => v.Value).ToDictionary(v => v.Key, v => v.Value));
        }
        // Фильтрация словаря по студенту. Предмет и минимальная оценка опциональны.
        public static Dictionary<string, Dictionary<string, int>> FilterStudent(StudentScores studentScores, string student, string? optionalSubject = null, int optionalGrade = 0)
        {
            // Проверяем, есть ли указанный студент в словаре
            if (!studentScores.Grades.ContainsKey(student))
            {
                // Если студент не найден, возвращаем пустой словарь
                return new Dictionary<string, Dictionary<string, int>>();
            }

            // Получаем оценки студента
            var studentGrades = studentScores.Grades[student];

            // Если фильтруется по предмету и минимальной оценке
            var filteredGrades = studentGrades
                .Where(subjectGrade =>
                    (optionalSubject == null || subjectGrade.Key == optionalSubject) &&
                    subjectGrade.Value >= optionalGrade)
                .ToDictionary(subjectGrade => subjectGrade.Key, subjectGrade => subjectGrade.Value);

            // Возвращаем фильтрованный результат
            return new Dictionary<string, Dictionary<string, int>>
                {
                    { student, filteredGrades }
                };
        }

    }
}
