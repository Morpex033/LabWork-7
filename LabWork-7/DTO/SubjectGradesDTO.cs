using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7.DTO
{
    internal class SubjectGradesDTO
    {
        //Название предмета
        private string subject;
        //Оценка
        private int grade;

        // Свойство для доступа к предмету
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        // Свойство для доступа к оценке
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
