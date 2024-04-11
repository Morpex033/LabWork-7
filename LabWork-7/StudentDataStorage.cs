using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace LabWork_7
{
    internal class StudentDataStorage
    {
        //Путь к файлу
        public static string defaultFilePath = "StudentStorage.bin";
        
        //Метод для сохранения словаря в файл
        public static void Save(StudentScores studentScores)
        {
            //Создание BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open(defaultFilePath, FileMode.OpenOrCreate)))
            {
                //Сериалезация словаря в строку формата JSON
                string json = StudentJsonConverter.Serialize(studentScores);
                //Запись строки в файл
                writer.Write(json);
            }
        }

        //Метод для загрузки словаря из файла
        public static StudentScores Load() 
        {
            //Создание BinaryReader
            using (BinaryReader reader = new BinaryReader(File.OpenRead(defaultFilePath)))
            {
                //Считывание строки формата JSON из файла
                string json = reader.ReadString();
                //Возвращает десереализованую строку
                return StudentJsonConverter.Deserialize(json);
            }
        }
    }
}
