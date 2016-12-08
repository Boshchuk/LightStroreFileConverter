using System;
using System.Collections.Generic;

namespace Ncc.Helper
{
    /// <summary>
    /// Контейней для информации, которую можно получить из "вхожной папки"
    /// </summary>
    public class InputFolderInfo
    {
        /// <summary>
        /// Файлы соотвтсвие которым есть в словаре
        /// </summary>
        public int PureItemsFromDictionary { get; set; }

        /// <summary>
        /// Неизвестные элементы
        /// </summary>
        public int UnknowItems { get; set; }

        public List<string> DictionaryItems { get; set; }

        public List<string> UnknownItmes { get; set; }

        public InputFolderInfo()
        {
            PureItemsFromDictionary = 0;
            UnknowItems = 0;

            DictionaryItems = new List<string>();
            UnknownItmes = new List<string>();
        }

        public override string ToString()
        {
            return string.Format("Items from dictionary: {0};{2}Unknowns items: {1}", PureItemsFromDictionary, UnknowItems, Environment.NewLine);
        }
    }
}