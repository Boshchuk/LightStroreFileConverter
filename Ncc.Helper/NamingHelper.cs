using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            string value;
            if (Dictionary.TryGetValue(inputName, out value))
            {
                return value;
            }
            // TODO: придумать способы определения "похожих названий" (полезно, что бы не менять словарь)
            // TODO: это не приоритетно сейчас
            // для изменения словаря перекомпиляция не требуется
            else
            {
                return string.Format("Не изменено-{0}", inputName);
            }
        }

        /// <summary>
        /// Анализ папки на наличе документов необходимого формата
        /// </summary>
        /// <param name="inputFolder"></param>
        /// <returns></returns>
        public InputFolderInfo AnalyzeFolder(string inputFolder)
        {
            var files = Directory.GetFiles(inputFolder);
            return AnalyzeFullFileNames(files.ToList());
        }

        public InputFolderInfo AnalyzeFullFileNames(List<string> filePathes)
        {
            var fileNames = new List<string>();

            foreach (var item in filePathes)
            {
                var fileInfo = new FileInfo(item);
                var fileName = fileInfo.Name;
                fileNames.Add(fileName);
            }

            return AnalyzeFileNames(fileNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public InputFolderInfo AnalyzeFileNames(List<string> fileNames)
        {
            // читаем что внутри
            //пытаемся разобраться
            // описываем выше что делает методе


            var result = new InputFolderInfo();

            foreach (var item in fileNames)
            {
                if (Dictionary.ContainsKey(item))
                {
                    result.PureItemsFromDictionaryCount++;
                    result.DictionaryItems.Add(item);
                }
                else
                {
                    result.UnknownItemsCount++;
                    result.UnknownItemes.Add(item);
                }
            }
            return result;
        }
    }
}
