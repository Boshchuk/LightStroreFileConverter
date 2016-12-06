﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ncc.Helper
{
    public class NamingHelper
    {
        public Dictionary<string, string> Dictionary { get; set; }
    

        public string ConfigFileName { get; set; }

        public void ReadDictionary()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            var fileName =  !string.IsNullOrEmpty(ConfigFileName) ? ConfigFileName : "Dictionary.csv";

            var path = string.Format(@"{0}/{1}", dir, fileName);

            ReadDictionary(path);
        }

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


        public  string GetNameFromDictionary(string inputName)
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
            else
            {
                return string.Format("Не изменино-{0}", inputName);
            }
            // TODO: add iteration 2
        }

        /// <summary>
        /// Анализ папки на наличе документов необходимого формата
        /// </summary>
        /// <param name="inputFolder"></param>
        /// <returns></returns>
        public InputFolderInfo AnalyzeFolder(string inputFolder)
        {
            var result = new InputFolderInfo();

            var files = Directory.GetFiles(inputFolder);
            foreach (var item in files)
            {
                if (Dictionary.ContainsKey(item))
                {
                    result.PureItemsFromDictionary++;
                    result.DictionaryItems.Add(item);
                }
                else
                {
                    result.UnknowItems++;
                    result.UnknownItmes.Add(item);
                }
            }
            return result;
        }
    }
}
