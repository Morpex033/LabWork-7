using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7.DTO
{
    internal class StudentDTO
    {
        //Имя студента
        private string studentName;
        //Лист SubjectGradesDTO с именем предмета и оценкой по мему
        private List<SubjectGradesDTO> subjectGrades = new List<SubjectGradesDTO>();

        // Свойство для доступа к имени студента
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        // Свойство для доступа к списку оценок по предметам
        public List<SubjectGradesDTO> SubjectGrades
        {
            get { return subjectGrades; }
            set { subjectGrades = value; }
        }
    }
}
