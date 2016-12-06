using System.Collections.Generic;

namespace Ncc.Helper
{
    /// <summary>
    /// ��������� ��� ����������, ������� ����� �������� �� "������� �����"
    /// </summary>
    public class InputFolderInfo
    {
        /// <summary>
        /// ����� ���������� ������� ���� � �������
        /// </summary>
        public int PureItemsFromDictionary { get; set; }

        /// <summary>
        /// ����������� ��������
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
    }
}