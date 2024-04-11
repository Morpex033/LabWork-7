using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LabWork_7.DTO;

namespace LabWork_7
{
    internal class StudentJsonConverter
    {
        // Метод для сериализации объекта StudentScores в JSON строку
        public static string Serialize(StudentScores studentScores)
        {
            // Создаем новый объект StudentScoresDTO для представления данных в формате, подходящем для сериализации
            StudentScoresDTO studentScoresDTO = new StudentScoresDTO();

            // Проходимся по словарю с оценками из переданного объекта StudentScores
            foreach (var student in studentScores.GetGrades())
            {
                // Создаем новый объект StudentDTO для представления студента и его оценок
                StudentDTO studentDTO = new StudentDTO();

                // Устанавливаем имя студента в объекте StudentDTO
                studentDTO.StudentName = student.Key;

                // Проходимся по словарю оценок для текущего студента
                foreach (var grades in student.Value)
                {
                    // Создаем новый объект SubjectGradesDTO для представления предмета и оценки
                    SubjectGradesDTO subject = new SubjectGradesDTO();

                    // Устанавливаем предмет и оценку в объекте SubjectGradesDTO
                    subject.Subject = grades.Key;
                    subject.Grade = grades.Value;

                    // Добавляем объект SubjectGradesDTO в список оценок студента в StudentDTO
                    studentDTO.SubjectGrades.Add(subject);
                }

                // Добавляем объект StudentDTO, представляющий студента, в список студентов в StudentScoresDTO
                studentScoresDTO.Students.Add(studentDTO);
            }

            // Сериализуем объект StudentScoresDTO в JSON строку и возвращаем результат
            return JsonSerializer.Serialize(studentScoresDTO);
        }

        // Метод для десериализации JSON строки в объект StudentScores
        public static StudentScores Deserialize(string json)
        {
            // Создаем новый объект StudentScores для хранения распакованных данных
            StudentScores studentScores = new StudentScores();

            // Объект, в который будем десериализовывать JSON строку
            StudentScoresDTO studentScoresDTO;

            try
            {
                // Десериализуем JSON строку в объект StudentScoresDTO
                studentScoresDTO = JsonSerializer.Deserialize<StudentScoresDTO>(json);
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (JsonException e)
            {
                throw e;
            }

            // Проходимся по списку студентов в объекте StudentScoresDTO
            foreach (var student in studentScoresDTO.Students)
            {
                // Проходимся по списку оценок студента в объекте StudentDTO
                foreach (var grades in student.SubjectGrades)
                {
                    // Добавляем оценку в объект StudentScores
                    studentScores.AddScore(student.StudentName, grades.Subject, grades.Grade);
                }
            }

            // Возвращаем объект StudentScores, содержащий десериализованные данные
            return studentScores;
        }
    }
}
