using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7.DTO
{
    internal class StudentScoresDTO
    {
        //Лист StudentDTO с именем студента и его оценками по предметам
        private List<StudentDTO> students = new List<StudentDTO>();

        //Метод для доступа к students
        public List<StudentDTO> Students
        {
            get { return students; }
            set { students = value; }
        }
    }
}
