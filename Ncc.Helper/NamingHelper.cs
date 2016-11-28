using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ncc.Helper
{
    public class NamingHelper
    {
        /// <summary>
        /// Словарь соотвествия присылаемого имени файла - названию категории
        /// </summary>
        public Dictionary<string, string> Dictionary { get; set; }

        /// <summary>
        /// Имя файла где лежит словарь в формате csv - comma separated values
        /// </summary>
        public string ConfigFileName { get; set; }

        /// <summary>
        /// Инициализация словаря из файла по умолчанию 
        /// ( 1. должен находиться в дириктории приложения
        ///   2  название должно быть "Dictionary.csv")
        /// </summary>
        public void ReadDictionary()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var fileName =  !string.IsNullOrEmpty(ConfigFileName) ? ConfigFileName : "Dictionary.csv";

            var path = string.Format(@"{0}/{1}", dir, fileName);

            ReadDictionary(path);
        }

        /// <summary>
        /// Инициализация словаря используя путь к файлу
        /// </summary>
        /// <param name="path">Путь К файлу</param>
        public void ReadDictionary(string path)
        {
            try
            {
                string[] allLines = File.ReadAllLines(path,Encoding.Default);
                                
                var query = from line in allLines
                            let data = line.Split(',')
                            select new
                            {
                                Key = data[0],
                                Value = data[1],
                            };
                Dictionary = new Dictionary<string, string>();
                foreach (var item in query)
                {
                    Dictionary.Add(item.Key, item.Value);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Выдает имя категории по названию файла
        /// Если имени нет в словаре выдает значение по умолчанию формата: Не изменено-[имя файла c расширением]
        /// </summary>
        /// <param name="inputName">Название файла</param>
        /// <returns>имя категории</returns>
        public string GetNameFromDictionary(string inputName)
        {
            if (Dictionary == null || Dictionary.Count == 0)
            {
                throw new InvalidProgramException("Dictionary not ready");
            }

            // 1 iteartion
            if (Dictionary.ContainsKey(inputName))
            {
                return Dictionary[inputName];
            }
            // TODO: придумать способы определения "похожих названий" (полезно, что бы не менять словарь)
            // для изменения словаря перекомпиляция не требуется
            else
            {
                return string.Format("Не изменено-{0}", inputName);
            }
        }
    }
}
